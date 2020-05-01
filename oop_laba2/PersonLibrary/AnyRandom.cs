using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
using System.Reflection;

namespace PersonLibrary
{
    /// <summary>
    /// Получение случайного человека
    /// </summary>
    public static class AnyRandom
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
        private static string TextReader(string path)
        {
            path = "Resources\\" + path;

            var streamReader = new StreamReader(path);

            int randString = _random.Next(0, File.ReadAllLines(path).Length);
            var str = new string[randString + 1];

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Convert.ToString(streamReader.ReadLine());
            }
            streamReader.Close();

            return str[randString];
        }

        /// <summary>
        /// Заполенение основных свойств человека
        /// </summary>
        /// <param name="person">Человек</param>
        /// <param name="gender">Пол</param>
        /// <param name="age">Возраст</param>
        private static void GetBaseInfo(PersonBase person, Gender gender, int age)
        {
            switch (gender)
            {
                case Gender.Male:
                    person.Name = TextReader("MaleFirstNames.txt");
                    person.Surname = TextReader("MaleLastNames.txt");
                    person.Age = age;
                    person.Gender = gender;
                    break;
                case Gender.Female:
                    person.Name = TextReader("FemaleFirstNames.txt");
                    person.Surname = TextReader("FemaleLastNames.txt");
                    person.Age = age;
                    person.Gender = gender;
                    break;
                default:
                    throw new ArgumentException(string.Format("wrong gender", nameof(gender)));
            }
        }

        /// <summary>
        /// Возвращает случайные данные взрослого определенного пола
        /// </summary>
        /// <param name="gender">Пол взрослого</param>
        /// <returns>Данные врослого</returns>
        public static PersonBase GetRandomAdult(Gender gender)
        {
            int randAge = _random.Next(19, 122);

            var adult = new Adult();

            GetBaseInfo(adult, gender, randAge);

            adult.StateOfMarriage = TextReader("Marriage.txt");
            adult.NameOfJob = TextReader("NameOfJob.txt");
            return adult;
        }

        /// <summary>
        /// Возвращает случайные данные взрослого
        /// </summary>
        /// <returns>Данные взрослого</returns>
        public static PersonBase GetRandomAdult()
        {
            int randGender = _random.Next(0, 2);
            return GetRandomAdult((Gender)randGender);
        }

        /// <summary>
        /// Возвращает случайные данные ребенка
        /// </summary>
        /// <returns>Данные ребенка</returns>
        public static PersonBase GetRandomChild()
        {
            int randAge = _random.Next(0, 18);
            int randGender = _random.Next(0, 2);
            int randStateOfFamily = _random.Next(0, 3);

            var child = new Child();

            GetBaseInfo(child, (Gender)randGender, randAge);

            child.StateOfFamily = (StateOfFamily)randStateOfFamily;
            child.NameOfGarden = TextReader("NameOfGarden.txt");
            return child;
        }
    }

}

