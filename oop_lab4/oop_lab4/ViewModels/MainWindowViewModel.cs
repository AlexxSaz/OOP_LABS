using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShapeLib;
using System.Collections.ObjectModel;
using oop_lab4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Microsoft.Win32;

namespace oop_lab4.ViewModels
{
    /// <summary>
    /// Реализация логики главного окна
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// ВЫбранная фигура
        /// </summary>
        private ShapeBase _selectedShape;

        /// <summary> 
        /// Набор рассматриваемых фигур
        /// </summary>
        public ObservableCollection<ShapeBase> Shapes { get; set; }

        /// <summary>
        /// Выбранная фигура
        /// </summary>
        public ShapeBase SelectedShape
        {
            get => _selectedShape;
            set
            {
                _selectedShape = value;

                RaisePropertyChanged(nameof(SelectedShape));
            }
        }

        /// <summary>
        /// Вызов окон
        /// </summary>
        private void ShowWindow(Window win)
        {
            if (win.IsActive == false)
            {
                switch (win)
                {
                    case SearchWindow searchWindow:
                        Messenger.Default.
                            Send<ObservableCollection<ShapeBase>>(Shapes);
                        searchWindow.ShowDialog();
                        break;
                    case AddWindow addWindow:
                        addWindow.ShowDialog();
                        break;
                }
            }
        }

        /// <summary>
        /// Удаление фигуры
        /// </summary>
        private void ShapeRemove()
        {
            Shapes.Remove(SelectedShape);
        }

        /// <summary>
        /// Команда вызова окна с добавлением
        /// </summary>
        public RelayCommand ShowAddWindowCommand { get; }

        /// <summary>
        /// Команда вызова окна с поиском
        /// </summary>
        public RelayCommand ShowSearchWindowCommand { get; }

        /// <summary>
        /// Команда для удаления фигуры из списка
        /// </summary>
        public RelayCommand RemoveShapeCommand { get; }
#if DEBUG
        /// <summary>
        /// Команда рандом фигур
        /// </summary>
        public RelayCommand RandomizeShapeCommand { get; }
#endif

        /// <summary>
        /// Команда для сохранения коллекции фигур
        /// </summary>
        public RelayCommand SaveShapeCollectionCommand { get; }

        /// <summary>
        /// Команда для сохранения коллекции фигур
        /// </summary>
        public RelayCommand LoadShapeCollectionCommand { get; }

        /// <summary>
        /// Инициализация главного окна
        /// </summary>
        public MainWindowViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase> { };

            Messenger.Default.Register<ShapeBase>(this, ShapeReceived);

            ShowAddWindowCommand = new RelayCommand(() =>
            ShowWindow(new AddWindow()));
            ShowSearchWindowCommand = new RelayCommand(() =>
            ShowWindow(new SearchWindow()));
            RemoveShapeCommand = new RelayCommand(ShapeRemove);
            SaveShapeCollectionCommand =
                new RelayCommand(SaveShapeCollection);
            LoadShapeCollectionCommand =
                new RelayCommand(LoadShapeCollection);
#if DEBUG
            RandomizeShapeCommand = new RelayCommand(ShapeRandomize);
#endif
        }

        static BinaryFormatter writer = new BinaryFormatter();
        /// <summary>
        /// Сохранение коллекции фигур
        /// </summary>
        private void SaveShapeCollection()
        {
            var saveFile = new SaveFileDialog();
            var shapesToSave = new List<ShapeBase>(Shapes);
            string filePath;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".saz";
            saveFile.Filter = "Saz documents (.saz)|*.saz";

            if (saveFile.ShowDialog() == true)
            {
                filePath = saveFile.FileName;
            }
            else
            {
                MessageBox.Show("Путь не определен!\n" +
                    "Необходимо выбрать путь сохранения файла!");
                return;
            }

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                writer.Serialize(fs, shapesToSave);

                MessageBox.Show($"Файл {Path.GetFileName(filePath)} " +
                    $"сохранен");
            }
        }

        /// <summary>
        /// Загрузка коллекции фигур
        /// </summary>
        private void LoadShapeCollection()
        {
            string filePath;
            var openFile = new OpenFileDialog();
            openFile.Filter = "Saz documents (.saz)|*.saz";

            if (openFile.ShowDialog() == true)
            {
                filePath = openFile.FileName;
            }
            else
            {
                MessageBox.Show("Файл не выбран!\nНеобходимо выбрать файл!");
                return;
            }

            Shapes.Clear();

            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var listOfDeserializedShape =
                    (List<ShapeBase>)writer.Deserialize(fs);
                foreach (ShapeBase shape in listOfDeserializedShape)
                {
                    Shapes.Add(shape);
                }
                MessageBox.Show($"Файл {Path.GetFileName(filePath)} " +
                    $"загружен");
            }
        }
#if DEBUG
        /// <summary>
        /// Добавление рандомных фигур
        /// </summary>
        private void ShapeRandomize()
        {
            const int numberOfShapes = 10;
            for (int i = 0; i < numberOfShapes; i++)
            {
                Shapes.Add(ShapeRandom.GetRandomShape());
            }
            MessageBox.Show($"Зарандомлено {numberOfShapes} фигур");
        }
#endif
        /// <summary>
        /// Добавление новой фигуры
        /// </summary>
        /// <param name="shape">Созданная фигура</param>
        private void ShapeReceived(ShapeBase shape)
        {
            Shapes.Add(shape);
        }
    }
}
