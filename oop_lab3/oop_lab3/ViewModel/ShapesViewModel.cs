using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;

using ShapeLib;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace oop_lab3.ViewModel
{
    public class ShapesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ShapeBase> Shapes { get; set; }
        private ShapeBase _shapeBase;
        public ShapeBase SelectedShape
        {
            get => _shapeBase;
            set
            {
                _shapeBase = value;
                OnPropertyChanged(nameof(SelectedShape));
            }
        }

        public ShapesViewModel()
        {
            Shapes = new ObservableCollection<ShapeBase>
            {
                new Parallelepiped {NameOfShape=nameof(Parallelepiped), Height=0, SquareOfBase=0},
                new Sphere {NameOfShape=nameof(Sphere), Radius=0},
                new Pyramid {NameOfShape=nameof(Pyramid), Height=0, SquareOfBase=0}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
