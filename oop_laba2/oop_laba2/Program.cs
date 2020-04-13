using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace oop_laba2
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
            Console.WriteLine("-----------------------------------------" +
                "---------Cписок----------------------------------------" +
                "----------");
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
            Console.WriteLine("{0,-14} | {1,-14} | {2,-10} | {3,-10} " +
                "| {4,-15} | {5, -13} | {6, -13}", "Имя", "Фамилия", "Возраст", "Пол",
                "Состояние брака/", "Работа/", "Супруг/");
            Console.WriteLine("{0,-14} {1,-14} {2,-10} {3,-17} " +
                " {4,-18} {5, -14} {6, -13}", "", "", "", "",
                "Состав семьи", "Детский сад", "Родители");
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
            Console.WindowWidth = 123;

            var personList = new PersonList();

            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                var randomPerson = random.Next(1, 3);

                switch (randomPerson)
                {
                    case 1:
                        personList.Add(AnyRandom.GetRandomAdult());
                        break;
                    case 2:
                        personList.Add(AnyRandom.GetRandomChild());
                        break;
                }
            }

            ShowStructure();
            ShowInfo(personList);

            Console.WriteLine("Нажмите любую, чтобы узнать " +
                "тип четвертого человека");

            Console.ReadKey();
            Console.Clear();
            Console.Write("Тип четвертого человека в списке: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(personList.Person[3].GetType().ToString() + "\n");
            Console.ResetColor();
            Console.WriteLine("Вот его данные: ");
            ShowStructure();
            Console.WriteLine(personList.Person[3].Information);
            Console.WriteLine();
            Console.WriteLine("Для завершения программы нажмите " +
                "любую кнопку");

            Console.ReadKey();
        }
    }
}
