using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using ShapeLib;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using oop_lab4.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;

namespace oop_lab4.ViewModels
{
    /// <summary>
    /// Реализация логики окна с добавлением фигур
    /// </summary>
    public class AddWindowViewModel : ObservableObject
    {
        /// <summary>
        /// ВЫбранная фигура
        /// </summary>
        private ShapeBase _selectedShape;

        /// <summary>
        /// Объем фигуры
        /// </summary>
        private double _volume;

        /// <summary>
        /// Отображение параметра радиус
        /// </summary>
        private bool _radiusVisability = false;

        /// <summary>
        /// Отображение параметра высота
        /// </summary>
        private bool _heightVisability = false;

        /// <summary>
        /// Отображение параметра площадь основания
        /// </summary>
        private bool _squareVisability = false;

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

                switch (SelectedShape)
                {
                    case Sphere sphere:
                        RadiusVisability = true;
                        HeightVisability = false;
                        SquareVisability = false;
                        break;
                    case Parallelepiped parallelepiped:
                        RadiusVisability = false;
                        HeightVisability = true;
                        SquareVisability = true;
                        break;
                    case Pyramid pyramid:
                        RadiusVisability = false;
                        HeightVisability = true;
                        SquareVisability = true;
                        break;
                    case null:
                        break;
                }

                RaisePropertyChanged(nameof(SelectedShape));
            }
        }

        /// <summary>
        /// Отображение параметра радиус
        /// </summary>
        public bool RadiusVisability
        {
            get => _radiusVisability;
            set
            {
                _radiusVisability = value;
                RaisePropertyChanged(nameof(RadiusVisability));
            }
        }

        /// <summary>
        /// Отображение параметра высота
        /// </summary>
        public bool HeightVisability
        {
            get => _heightVisability;
            set
            {
                _heightVisability = value;
                RaisePropertyChanged(nameof(HeightVisability));
            }
        }

        /// <summary>
        /// Отображение параметра площадь основания
        /// </summary>
        public bool SquareVisability
        {
            get => _squareVisability;
            set
            {
                _squareVisability = value;
                RaisePropertyChanged(nameof(SquareVisability));
            }
        }

        /// <summary>
        /// Объем фигуры
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
        /// Команда для расчета объема фигуры
        /// </summary>
        public RelayCommand SendShapeCommand { get; }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="window"></param>
        public void SendShape()
        {
            Messenger.Default.Send<ShapeBase>(SelectedShape);
        }

        /// <summary>
        /// Инициализация окна добавления фигур
        /// </summary>
        public AddWindowViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape="Параллелепипед"},
                new Sphere {NameOfShape="Сфера"},
                new Pyramid {NameOfShape="Пирамида"}
            };


            SendShapeCommand = new RelayCommand(SendShape);
        }
    }
}
