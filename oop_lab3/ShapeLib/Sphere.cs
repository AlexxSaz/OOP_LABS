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
    public class Sphere : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        private double _radius;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public override double Volume
        {
            get
            {
                return 4 / 3 * Math.PI * Math.Pow(Radius, 3.0);
            }
        }
    }
}
