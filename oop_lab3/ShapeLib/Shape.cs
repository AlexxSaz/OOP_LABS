using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    /// <summary>
    /// Геометрические фигуры
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Расчет объема фигуры
        /// </summary>
        public virtual double Volume
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Проверка правильности введенных данных
        /// </summary>
        /// <param name="data">Введенные данные</param>
        protected static void CheckData(double data)
        {
            if (double.IsNaN(data))
            {
                throw new ArgumentException(
                    string.Format("***isNotaNumber***", nameof(data)));
            }
            else if (data < 0)
            {
                throw new ArgumentException(
                    string.Format("***isNegative***", nameof(data)));
            }
        }
    }
}
