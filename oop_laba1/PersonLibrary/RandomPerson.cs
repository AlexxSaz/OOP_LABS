using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonLibrary
{
    /// <summary>
    /// Получение случайного человека
    /// </summary>
    public static class RandomPerson
    {
        /// <summary>
        /// Случайное значение
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Возвращает имя из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Имя человека</returns>
        private static string NameReader(string path)
        {
            var streamReader = new StreamReader(path);

            int randName = _random.Next(0, File.ReadAllLines(path).Length);
            var names = new string[randName + 1];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Convert.ToString(streamReader.ReadLine());
            }
            streamReader.Close();
            return names[randName];
        }

        /// <summary>
        /// Возвращает случайные данные человека
        /// </summary>
        /// <returns>Данные человека</returns>
        public static Person GetRandomPerson()
        {
            int randAge = _random.Next(1, 122);
            int randGender = _random.Next(0, 2);

            if (randGender == 0)
            {
                return new Person(NameReader(@"MaleFirstNames.txt"),
                NameReader(@"MaleLastNames.txt"),
                    randAge, (Gender)randGender);
            }
            else if (randGender == 1)
            {
                return new Person(NameReader(@"FemaleFirstNames.txt"),
                NameReader(@"FemaleLastNames.txt"),
                    randAge, (Gender)randGender);
            }
            throw new ArgumentException(string.Format("wrong gender",
                nameof(randGender)));
        }

    }
}
