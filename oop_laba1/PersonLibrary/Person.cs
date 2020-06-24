using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Проверка на корректность присваиваемых данных
        /// </summary>
        /// <param name="data">Проверяемое значение</param>
        private static void CheckNameData(string data)
        {
            /// <summary>
            /// Выражение для проверки введенных символов
            /// </summary>
            Regex regex =
                new Regex(@"(^[а-яa-z]+$)|(^[а-яa-z]+[-][а-яa-z]+$)");

            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException(
                     string.Format("***Is null or empty***", nameof(data)));
            }
            if (!regex.IsMatch(data.ToLower()))
            {
                throw new ArgumentException(
                    string.Format("***Wrong char***", nameof(data)));
            }
        }


        /// <summary>
        /// Преобразование регистра имени
        /// </summary>
        /// <param name="name">Имя/фамилия человека</param>
        /// <returns>Имя/фамилия человека в верном регистре</returns>
        private static string ToRightBound(string name)
        {
            name = name.Substring(0, 1).ToUpper()
                        + name.Substring(1, name.Length - 1);

            return name;
        }

        /// <summary>
        /// Изменение формата введенных данных 
        /// </summary>
        /// <param name="name">Имя/Фамилия</param>
        /// <returns>Верный формат Имени/Фамилии</returns>
        public static Person ToCorrect(Person person)
        {
            Regex regex = new Regex(@"[-]");

            string[] name = new string[2];

            name[0] = person.Name;
            name[1] = person.Surname;

            for (int i = 0; i < 2; i++)
            {
                name[i] = name[i].ToLower();

                //Проверка на двойное имя/фамилию
                if (regex.IsMatch(name[i]))
                {
                    string[] doubleName = name[i].Split('-');
                    name[i] = ToRightBound(doubleName[0])
                    + "-" + ToRightBound(doubleName[1]);
                }
                else
                {
                    name[i] = ToRightBound(name[i]);
                }
            }

            person.Name = name[0];
            person.Surname = name[1];

            return person;
        }

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;
        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;


        /// <summary>
        /// Имя человека
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                CheckNameData(value);
                _name = value;
            }
        }

        /// <summary>
        /// Фамилия человека
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                CheckNameData(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Возраст человека
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 122)
                {
                    throw new ArgumentException(
                        string.Format("***Over bound***", nameof(value)));
                }
                _age = value;
            }
        }

        /// <summary>
        /// Пол человека
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Содержит стандартные данные человека
        /// </summary>
        public Person() : this("A", "A", 0, Gender.Female) { }

        /// <summary>
        /// Содержит имя, фамилию, возраст и пол 
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="sname">фамилия</param>
        /// <param name="old">возраст</param>
        /// <param name="gender">пол</param>
        public Person(string name, string sname, int old, Gender gender)
        {
            Name = name;
            Surname = sname;
            Age = old;
            Gender = gender;
        }

        /// <summary>
        /// Возвращает информацию о человеке
        /// </summary>
        public string Information
        {
            get
            {
                return string.Format("{0,-14} | {1,-14} | {2,-13} | {3,-13}",
                Name, Surname, Age, Gender);
            }
        }
    }
}
