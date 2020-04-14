using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    /// <summary>
    /// Сфера
    /// </summary>
    public class Sphere : Shape
    {
        /// <summary>
        /// Радиус сферы
        /// </summary>
        private double _radius;

        /// <summary>
        /// Радиус сферы
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                CheckData(value);
                _radius = value;
            }
        }

        /// <summary>
        /// Расчет объема
        /// </summary>
        public override double Volume
        {
            get
            {
                return Math.Round((4 / 3) * Math.PI * 
                    Math.Pow(Radius, 3.0), 2);
            }
        }
    }
}
