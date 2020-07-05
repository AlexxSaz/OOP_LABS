using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
#if DEBUG
    /// <summary>
    /// Рандом фигур
    /// </summary>
    public static class ShapeRandom
    {
        /// <summary>
        /// Случайное значение
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Создание рандомной фигуры
        /// </summary>
        /// <returns>Рандомная фигура</returns>
        public static ShapeBase GetRandomShape()
        {
            double randRadius = _random.Next(1, 100);
            double randSquareOfBase = _random.Next(1, 100);
            double randHeight = _random.Next(1, 100);
            int randShape = _random.Next(1, 4);

            switch (randShape)
            {
                case 1:
                    var paral = new Parallelepiped();
                    paral.NameOfShape = "Параллелепипед";
                    paral.Height = randHeight;
                    paral.SquareOfBase = randSquareOfBase;
                    return paral;
                case 2:
                    var pyramid = new Pyramid();
                    pyramid.NameOfShape = "Пирамида";
                    pyramid.SquareOfBase = randSquareOfBase;
                    pyramid.Height = randHeight;
                    return pyramid;
                case 3:
                    var sphere = new Sphere();
                    sphere.NameOfShape = "Сфера";
                    sphere.Radius = randRadius;
                    return sphere;
            }

            throw new ArgumentException(string.Format("Нет такой фигуры"));
        }
    }
#endif
}
