using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Parallelepiped : Shape
    {
        /// <summary>
        /// Высота фигуры
        /// </summary>
        private double _height;

        /// <summary>
        /// Площадь основания фигуры
        /// </summary>
        private double _squareOfBase;

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        public override double Volume
        {
            get
            {
                return SquareOfBase * Height;
            }
        }
    }
}
