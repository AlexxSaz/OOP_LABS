using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ShapeLib
{
    //TODO: RSDN - название класса (V)
    /// <summary>
    /// Геометрические фигуры
    /// </summary>
    public abstract class ShapeBase : BindableBase
    {
        /// <summary>
        /// Имя фигуры
        /// </summary>
        private string _nameOfShape;

        /// <summary>
        /// Название фигуры
        /// </summary>
        public string NameOfShape
        {
            get => _nameOfShape;
            set
            {
                _nameOfShape = value;
            }
        }

        /// <summary>
        /// Расчет объема фигуры
        /// </summary>
        public abstract double Volume { get; }
    }
}
