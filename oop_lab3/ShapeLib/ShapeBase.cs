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

        /// <summary>
        /// Проверка правильности введенных данных
        /// </summary>
        /// <param name="data">Введенные данные</param>
        protected static void CheckData(double data)
        {
            if (double.IsNaN(data))
            {
                throw new ArgumentException(
                    string.Format("***Это не число***\nВведите число!",
                    nameof(data)));
            }
            else if (data < 0)
            {
                throw new ArgumentException(
                    string.Format("***Это число отрицаетльное***\n" +
                    "Введите число не меньше нуля!", nameof(data)));
            }
        }
    }
}
