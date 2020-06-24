using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace oop_laba1
{
    /// <summary>
    /// Выполняемая программа
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Вывод информации о человеке в консоль
        /// </summary>
        /// <param name="personList">Список людей</param>
        public static void ShowInfo(PersonList personList)
        {
            Console.WriteLine("------------------------Cписок-------" +
                "----------------");
            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList.Person[i].Information);
            }
        }

        /// <summary>
        /// Вывод структуры в консоль
        /// </summary>
        public static void ShowStructure()
        {
            Console.WriteLine("{0,-14} | {1,-14} | {2,-13} | {3,-13}",
                "Имя", "Фамилия", "Возраст", "Пол");
        }

        /// <summary>
        /// Ввод данных в консоль
        /// </summary>
        /// <param name="data">Название вводимых данных</param>
        /// <returns>Введенные данные</returns>
        public static void MistakeOfInput(ArgumentException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }

        /// <summary>
        /// Главный метод, с которого начинается программа
        /// </summary>
        /// <param name="args">Агрументы, с которыми запускается программа</param>
        public static void Main(string[] args)
        {
            var personList1 = new PersonList();
            var personList2 = new PersonList();

            for (int i = 0; i < 3; i++)
            {
                personList1.Add(RandomPerson.GetRandomPerson());
                personList2.Add(RandomPerson.GetRandomPerson());
            }

            ShowStructure();
            ShowInfo(personList1);
            ShowInfo(personList2);

            Console.WriteLine("Для добавления нового человека в первый" +
                " список - нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            personList1.Add(InputPerson.ReadFrom());

            Console.Clear();

            ShowStructure();
            ShowInfo(personList1);
            ShowInfo(personList2);

            Console.WriteLine("Для копирования человека из первого списка" +
                " во второй - нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            personList2.Add(personList1.IndexAt(1));
            Console.Clear();

            ShowStructure();
            ShowInfo(personList1);
            ShowInfo(personList2);

            Console.WriteLine("Для удаления второго человека из первого" +
                " списка - нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            personList1.RemoveAt(1);

            ShowStructure();
            ShowInfo(personList1);
            ShowInfo(personList2);

            Console.WriteLine("Для очистки второго" + " списка -" +
                " нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            personList2.RemoveAll();

            ShowStructure();
            ShowInfo(personList1);
            ShowInfo(personList2);

            Console.WriteLine("Чтобы завершить программу - " +
                " нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
