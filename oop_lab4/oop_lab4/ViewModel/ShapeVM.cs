using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using ShapeLib;
using System.Collections.ObjectModel;
using oop_lab4.View;

namespace oop_lab4.ViewModel
{
    public class ShapeVM : BindableBase
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
                
                RaisePropertyChanged(nameof(SelectedShape));
            }
        }

        public AddWindow AddWindow { get; set; }

        private ShapeBase Add()
        {
            AddWindow = new AddWindow();
            AddWindow.Show();
            return new Parallelepiped();
        }

        /// <summary>
        /// Команда добавление фигуры в список
        /// </summary>
        public DelegateCommand AddShape { get; }

        /// <summary>
        /// Команда для удаления фигуры из списка
        /// </summary>
        public DelegateCommand RemoveShape { get; }

        public ShapeVM()
        {
            Shapes = new ObservableCollection<ShapeBase> { };



            AddShape = new DelegateCommand(() => { Add(); }).ObservesProperty(() => AddWindow);
        }

    }
}
