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
    /// <summary>
    /// Связь между моделью и представлением
    /// </summary>
    public class ShapesViewModel : BindableBase
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
                Volume = 0;
                RaisePropertyChanged(nameof(SelectedShape));
                RaisePropertyChanged(nameof(Volume));
            }
        }

        /// <summary>
        /// Объем фигуры
        /// </summary>
        public double Volume
        {
            get => _volume;
            private set
            {
                _volume = value;
                RaisePropertyChanged(nameof(Volume));
            }
        }

        /// <summary>
        /// Инициализация фигур
        /// </summary>
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

        /// <summary>
        /// Получение значения объема фигуры
        /// </summary>
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

        /// <summary>
        /// Команда для расчета объема фигуры
        /// </summary>
        public DelegateCommand CalcVolume { get; }
    }
}
