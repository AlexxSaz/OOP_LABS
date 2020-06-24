using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;
using System.Collections.ObjectModel;
using oop_lab4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace oop_lab4.ViewModels
{
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

        public AddWindow AddWindow { get; set; }

        private void ShowAddWindow()
        {
            if (AddWindow == null)
            {
                AddWindow = new AddWindow();
            }

            if (AddWindow.IsActive == false)
            {
                AddWindow.Show();
            }
        }

        private void ShapeRemove()
        {
            Shapes.Remove(SelectedShape);
        }

        /// <summary>
        /// Команда добавление фигуры в список
        /// </summary>
        public RelayCommand ShowAddWindowCommand { get; }

        /// <summary>
        /// Команда для удаления фигуры из списка
        /// </summary>
        public RelayCommand RemoveShapeCommand { get; }

        public MainWindowViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase> { };


            Messenger.Default.Register<ShapeBase>(this, ShapeReceived);

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow);
            RemoveShapeCommand = new RelayCommand(ShapeRemove);
        }

        private void ShapeReceived(ShapeBase shape)
        {
            Shapes.Add(shape);
        }
    }
}
