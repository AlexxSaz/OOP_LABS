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
        /// Окно добавления фигур
        /// </summary>
        public AddWindow AddWindow = new AddWindow();

        /// <summary>
        /// Окно поиска
        /// </summary>
        public SearchWindow SearchWindow = new SearchWindow();

        /// <summary>
        /// Вызов окон
        /// </summary>
        private void ShowWindow(Window win)
        {
            switch (win)
            {
                case SearchWindow searchWindow:
                    win = new SearchWindow();
                    Messenger.Default.Send<ObservableCollection<ShapeBase>>(Shapes);
                    break;
                case AddWindow addWindow:
                    win = new AddWindow();
                    break;
            }

            if (win.IsActive == false)
            {
                win.Show();
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
            ShowWindow(AddWindow));
            ShowSearchWindowCommand = new RelayCommand(() =>
            ShowWindow(SearchWindow));
            RemoveShapeCommand = new RelayCommand(ShapeRemove);
            SaveShapeCollectionCommand = new RelayCommand(SaveShapeCollection);
            LoadShapeCollectionCommand = new RelayCommand(LoadShapeCollection);
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

            var shapeBases = new List<ShapeBase>(Shapes);

            using (var fs = new FileStream("paol.saz", FileMode.OpenOrCreate))
            {
                writer.Serialize(fs, shapeBases);

                MessageBox.Show("Файл сохранен");
            }
        }

        /// <summary>
        /// Загрузка коллекции фигур
        /// </summary>
        private void LoadShapeCollection()
        {
            Shapes.Clear();
            using (var fs = new FileStream("paol.saz", FileMode.Open))
            {
                var listOfDeserializedShape =
                    (List<ShapeBase>)writer.Deserialize(fs);
                foreach (ShapeBase shape in listOfDeserializedShape)
                {
                    Shapes.Add(shape);
                }
                MessageBox.Show("Файл загружен");
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
