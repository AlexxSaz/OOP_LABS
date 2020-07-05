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
    public class Sphere : ShapeBase
    {
        /// <summary>
        /// Радиус сферы
        /// </summary>
        private double _radius = 1;

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
                if (value > 0)
                {
                    _radius = value;
                }
                RaisePropertyChanged(nameof(Volume));
                RaisePropertyChanged(nameof(Radius));
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

        /// <summary>
        /// Параметры сферы
        /// </summary>
        public override string ParametersOfShape
        {
            get
            {
                return string.Format($"Радиус={Radius}");
            }
        }
    }
}
