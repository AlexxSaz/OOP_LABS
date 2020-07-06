using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    [Serializable]
    /// <summary>
    /// Геометрические фигуры
    /// </summary>
    public abstract class ShapeBase
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

        /// <summary>
        /// Все параметры фигуры
        /// </summary>
        public abstract string ParametersOfShape { get; }
    }
}
