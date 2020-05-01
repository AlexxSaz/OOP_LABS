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
    public abstract class PersonBase
    {
        /// <summary>
        /// Проверка на корректность присваиваемых данных
        /// </summary>
        /// <param name="data">Проверяемое значение</param>
        protected static void CheckStringData(string data)
        {
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
        protected static string ToRightBound(string name)
        {
            name = name.Substring(0, 1).ToUpper()
                        + name.Substring(1, name.Length - 1);

            return name;
        }

        /// <summary>
        /// Изменение формата данных о человеке
        /// </summary>
        /// <param name="person">Информация о человеке</param>
        /// <returns>Верный формат данных о человеке</returns>
        public static PersonBase ToCorrect(PersonBase person)
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
                CheckStringData(value);
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
                CheckStringData(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Возраст человека
        /// </summary>
        public virtual int Age
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
        protected PersonBase() : this("A", "A", 0, Gender.Female) { }

        /// <summary>
        /// Содержит имя, фамилию, возраст и пол 
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="old">возраст</param>
        /// <param name="gender">пол</param>
        protected PersonBase(string name, string surname, int old, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = old;
            Gender = gender;
        }

        /// <summary>
        /// Возвращает информацию о человеке
        /// </summary>
        public virtual string Information
        {
            get
            {
                return string.Format("{0,-14} | {1,-14} | {2,-10} | {3,-10}",
                Name, Surname, Age, Gender);
            }
        }
    }
}
