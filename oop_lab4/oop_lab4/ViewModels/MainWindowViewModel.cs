using System;
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
#if DEBUG
            RandomizeShapeCommand = new RelayCommand(ShapeRandomize);
#endif
        }

        /// <summary>
        /// Сохранение коллекции фигур
        /// </summary>
        private void SaveShapeCollection()
        {
            
        }
#if DEBUG
        /// <summary>
        /// Добавление рандомных фигур
        /// </summary>
        private void ShapeRandomize()
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Shapes.Add(ShapeRandom.GetRandomShape());
            }
            MessageBox.Show($"Зарандомлено {i} фигур");
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
