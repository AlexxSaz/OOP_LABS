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
using System.Windows;

namespace oop_lab4.ViewModels
{
    /// <summary>
    /// Реализация логики окна с поиском
    /// </summary>
    public class SearchWindowViewModel : ObservableObject
    {
        /// <summary>
        /// Выбранная фигура
        /// </summary>
        private ShapeBase _selectedShape;

        /// <summary>
        /// Выбран ли поиск по названию фигур
        /// </summary>
        private bool _isShapeSelected;

        /// <summary>
        /// Выбран ли поиск по объему
        /// </summary>
        private bool _isVolumeEntered;

        /// <summary>
        /// Искомый объем
        /// </summary>
        private double _volume;

        /// <summary>
        /// Колекция фигур по которым будет вестись поиск
        /// </summary>
        public ObservableCollection<ShapeBase> ShapeForSearch { get; set; }

        /// <summary>
        /// Набор найденных фигур
        /// </summary>
        public ObservableCollection<ShapeBase> SearchedShapes { get; set; }

        /// <summary>
        /// Набор полученных от главного окна фигур 
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
        /// Производится ли поиск по объему фигур
        /// </summary>
        public bool IsVolumeEntered
        {
            get => _isVolumeEntered;
            set
            {
                _isVolumeEntered = value;

                RaisePropertyChanged(nameof(IsVolumeEntered));
            }
        }

        /// <summary>
        /// Производится ли поиск по назанию фигур
        /// </summary>
        public bool IsShapeSelected
        {
            get => _isShapeSelected;
            set
            {
                _isShapeSelected = value;

                RaisePropertyChanged(nameof(IsShapeSelected));
            }
        }

        /// <summary>
        /// Введенный объем
        /// </summary>
        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;

                RaisePropertyChanged(nameof(Volume));
            }
        }

        /// <summary>
        /// Команда поиска фигуры
        /// </summary>
        public RelayCommand SearchShapeCommand { get; }

        /// <summary>
        /// Инициализация окна поиска фигур
        /// </summary>
        public SearchWindowViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase> { };
            ShapeForSearch = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape="Параллелепипед"},
                new Sphere {NameOfShape="Сфера"},
                new Pyramid {NameOfShape="Пирамида"}
            };
            SearchedShapes = new ObservableCollection<ShapeBase> { };

            Messenger.Default.
                Register<ObservableCollection<ShapeBase>>(this, GetShapes);

            SearchShapeCommand = new RelayCommand(SearchShape);
        }

        /// <summary>
        /// Поиск фигур в полученной коллекции
        /// </summary>
        private void SearchShape()
        {
            SearchedShapes.Clear();

            if (Shapes != null)
            {
                foreach (ShapeBase shape in Shapes)
                {
                    if (SelectedShape != null
                        && IsVolumeEntered)
                    {
                        if (shape.NameOfShape==SelectedShape.NameOfShape &&
                            shape.Volume==Volume)
                        {
                            SearchedShapes.Add(shape);
                        }
                    }
                    else if (SelectedShape != null
                        && !IsVolumeEntered)
                    {
                        if (shape.NameOfShape == SelectedShape.NameOfShape)
                        {
                            SearchedShapes.Add(shape);
                        }
                    }
                    else if (!IsShapeSelected && IsVolumeEntered)
                    {
                        if (shape.Volume == Volume)
                        {
                            SearchedShapes.Add(shape);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получение коллекции фигур из главного окна
        /// </summary>
        /// <param name="shapes">Полученные фигуры</param>
        private void GetShapes(ObservableCollection<ShapeBase> shapes)
        {
            Shapes = shapes;
        }
    }
}
