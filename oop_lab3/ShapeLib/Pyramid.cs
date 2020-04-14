using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    /// <summary>
    /// Пирамида
    /// </summary>
    public class Pyramid : Shape
    {
        /// <summary>
        /// Высота
        /// </summary>
        private double _height;

        /// <summary>
        /// Площадь основания
        /// </summary>
        private double _squareOfBase;

        /// <summary>
        /// Высота пирамиды
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                CheckData(value);
                _height = value;
            }
        }

        /// <summary>
        /// Площадь основания пирамиды
        /// </summary>
        public double SquareOfBase
        {
            get
            {
                return _squareOfBase;
            }
            set
            {
                CheckData(value);
                _squareOfBase = value;
            }
        }

        /// <summary>
        /// Расчет объема пирамиды
        /// </summary>
        public override double Volume
        {
            get
            {
                return 1 / 3 * SquareOfBase * Height;
            }
        }
    }
}
