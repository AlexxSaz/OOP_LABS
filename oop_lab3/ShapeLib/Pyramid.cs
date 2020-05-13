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
    public class Pyramid : ShapeBase
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
                RaisePropertyChanged(nameof(Height));
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
                RaisePropertyChanged(nameof(SquareOfBase));
            }
        }

        /// <summary>
        /// Расчет объема пирамиды
        /// </summary>
        public override double Volume
        {
            get
            {
                return Math.Round(SquareOfBase * Height * 1 / 3, 2);
            }
        }
    }
}
