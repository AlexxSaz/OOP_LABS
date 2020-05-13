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
                RaisePropertyChanged(nameof(SelectedShape));
            }
        }

        public double Volume { get; set; }

        public ShapesViewModel()
        {
            SelectedShape = new Parallelepiped();
            SelectedShape.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            Shapes = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape=nameof(Parallelepiped)},
                new Sphere {NameOfShape=nameof(Sphere)},
                new Pyramid {NameOfShape=nameof(Pyramid)}
            };
            CalcVolume = new DelegateCommand(() => { ExecuteCalc(); }).ObservesProperty(() => Volume);
        }

        private void ExecuteCalc()
        {
            Volume = SelectedShape.Volume;
            RaisePropertyChanged(nameof(Volume));
        }

        public DelegateCommand CalcVolume { get; }
    }
}
