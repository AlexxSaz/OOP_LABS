using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Список людей
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив людей
        /// </summary>
        public Person[] Person { get; private set; } = new Person[0];

        /// <summary>
        /// Возвращает число элементов в списке
        /// </summary>
        public int Length
        {
            get
            {
                return Person.Length;
            }
        }

        /// <summary>
        /// Проверка на наличие элементов в массиве 
        /// </summary>
        private void CheckZeroLength()
        {
            if (Person.Length == 0)
            {
                throw new ArgumentException(string.Format("null massive",
                    nameof(Person)));
            }
        }

        /// <summary>
        /// Добавляет данные о человеке в лист
        /// </summary>
        /// <param name="person">Данные человека</param>
        public void Add(Person person)
        {
            Person[] _newPerson = Person;
            Person = new Person[Person.Length + 1];

            for (int i = 0; i < _newPerson.Length; i++)
            {
                Person[i] = _newPerson[i];
            }

            Person[Person.Length - 1] = person;
        }

        /// <summary>
        /// Удаляет элемент из списка
        /// </summary>
        /// <param name="person">Данные человека</param>
        public bool Remove(Person person)
        {
            CheckZeroLength();

            int i = IndexOf(person);

            RemoveAt(i);
            return true;
        }

        /// <summary>
        /// Удаление элемента по указанному индексу index
        /// </summary>
        /// <param name="index">Индекс элемента в списке</param>
        public void RemoveAt(int index)
        {
            CheckZeroLength();

            Person[] _newPerson = Person;
            Person = new Person[Person.Length - 1];
            int changeIndex = 0;

            for (int j = 0; j < _newPerson.Length; j++)
            {
                if (j == index)
                {
                    continue;
                }

                Person[changeIndex] = _newPerson[j];
                changeIndex++;
            }
        }

        /// <summary>
        /// Удаляет все элементы в списке
        /// </summary>
        public void RemoveAll()
        {
            Person = new Person[0];
        }

        /// <summary>
        /// Возвращает индекс человека в списке
        /// </summary>
        /// <param name="person">Данные человека</param>
        /// <returns>Индекс человека в списке</returns>
        public int IndexOf(Person person)
        {
            CheckZeroLength();

            for (int i = 0; i < Person.Length; i++)
            {
                if (person.Name == Person[i].Name
                    && person.Surname == Person[i].Surname
                    && person.Age == Person[i].Age)
                {
                    return i;
                }
            }
            throw new ArgumentException(string.Format("index not found",
                nameof(person)));
        }

        /// <summary>
        /// Возвращает данные человека по индексу
        /// </summary>
        /// <param name="index">Индекс человека в списке</param>
        /// <returns>Данные человека</returns>
        public Person IndexAt(int index)
        {
            CheckZeroLength();

            if (index > Person.Length)
            {
                throw new ArgumentException(string.Format("overflow index",
                    nameof(index)));
            }
            return Person[index];
        }
    }
}
