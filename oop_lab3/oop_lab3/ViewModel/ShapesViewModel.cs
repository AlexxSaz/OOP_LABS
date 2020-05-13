using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using ShapeLib;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Common;
using System.Windows.Input;

namespace oop_lab3.ViewModel
{
    public class ShapesViewModel : BindableBase
    {
        public ObservableCollection<ShapeBase> Shapes { get; set; }
        private ShapeBase _selectedShape;
        private double _volume;
        public ShapeBase SelectedShape
        {
            get => _selectedShape;
            set
            {
                _selectedShape = value;
                Volume = 0;
                RaisePropertyChanged(nameof(SelectedShape));
                RaisePropertyChanged(nameof(Volume));
            }
        }

        public double Volume
        {
            get => _volume;
            private set
            {
                _volume = value;
                RaisePropertyChanged(nameof(Volume));
            }
        }


        public ShapesViewModel()
        {
           Shapes = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape="Параллелепипед"},
                new Sphere {NameOfShape="Сфера"},
                new Pyramid {NameOfShape="Пирамида"}
            };

            CalcVolume = new DelegateCommand(() => 
            { ExecuteCalc(); }).ObservesProperty(() => Volume);
        }

        private void ExecuteCalc()
        {
            if (SelectedShape != null)
            {
                Volume = SelectedShape.Volume;
            }
            else
            {
                MessageBox.Show("Не выбрана ни одна из фигур!\n" +
                    "Выберите фигуру.");
            }
        }

        public DelegateCommand CalcVolume { get; }
    }
}
