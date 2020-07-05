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
        private double _height = 1;

        /// <summary>
        /// Площадь основания
        /// </summary>
        private double _squareOfBase = 1;

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
                if (value > 0)
                {
                    _height = value;
                }
                RaisePropertyChanged(nameof(Volume));
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
                if (value > 0)
                {
                    _squareOfBase = value;
                }
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

        /// <summary>
        /// Параметры пирамиды
        /// </summary>
        public override string ParametersOfShape
        {
            get
            {
                return string.Format($"Высота={Height}\n" +
                    $"Полщадь основания={SquareOfBase}");
            }
        }
    }
}
