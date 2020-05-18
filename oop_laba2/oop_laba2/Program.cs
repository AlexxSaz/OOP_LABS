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
        /// <summary>d
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
        public static void ShowStructure(PersonBase person)
        {
            if (person.GetType() == typeof(Adult))
            {
                Console.WriteLine("{0,-14} | {1,-14} | {2,-10} | {3,-10} " +
                "| {4,-16} | {5, -13} | {6, -13}", "Имя", "Фамилия",
                "Возраст", "Пол", "Состояние брака", "Работа", "Супруг");
            }
            else if (person.GetType() == typeof(Child))
            {
                Console.WriteLine("{0,-14} | {1,-14} | {2,-10} | {3,-10} " +
                "| {4,-16} | {5, -13} | {6, -13}", "Имя", "Фамилия",
                "Возраст", "Пол", "Состав семьи", "Детский сад", "Родители");
            }
        }

        /// <summary>
        /// Главный метод, с которого начинается программа
        /// </summary>
        /// <param name="args">Агрументы, с которыми запускается программа</param>
        public static void Main(string[] args)
        {
            Console.WindowWidth = 123;

            var personList = new PersonList();
            var childList = new PersonList();
            var adultList = new PersonList();

            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                var randomPerson = random.Next(1, 3);

                switch (randomPerson)
                {
                    case 1:
                        personList.Add(AnyRandom.GetRandomAdult());
                        adultList.Add(personList.Person[i]);
                        break;
                    case 2:
                        personList.Add(AnyRandom.GetRandomChild());
                        childList.Add(personList.Person[i]);
                        break;
                }
            }

            ShowStructure(childList.Person[0]);
            ShowInfo(childList);

            Console.WriteLine();

            ShowStructure(adultList.Person[0]);
            ShowInfo(adultList);

            Console.WriteLine("Нажмите любую клавишу, чтобы узнать " +
                "тип четвертого человека");

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Тип четвертого человека в списке: ");
            Console.ForegroundColor = ConsoleColor.Red;

            switch (personList.Person[3])
            {
                case Adult adult:
                {
                    Console.WriteLine($"Взрослый {adult.Name} {adult.Surname}," +
                                      $" который работает {adult.NameOfJob}");
                    break;
                }
                case Child child:
                {
                    Console.WriteLine($"Ребенок {child.Name} {child.Surname}," +
                                      $"состояние семьи которого {child.StateOfFamily}");
                    break;
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nНажите любую клавишу для выходы из программы.");
            Console.ReadKey();
        }
    }
}
