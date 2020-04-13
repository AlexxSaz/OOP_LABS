using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Взрослый
    /// </summary>
    public class Adult : PersonBase
    {
        //TODO: В автосвойство (V)

        /// <summary>
        /// Серия и номер паспорт
        /// </summary>
        private int _passportData;

        /// <summary>
        /// Название работы
        /// </summary>
        private string _nameOfJob;

        /// <summary>
        /// Название работы
        /// </summary>
        private string _marriage;

        /// <summary>
        /// Партнер в браке
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// Серия и номер паспорт взрослого
        /// </summary>
        public int PassportData
        {
            get
            {
                return _passportData;
            }
            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ArgumentException(
                        string.Format("***Wrong number of numeral***",
                        nameof(value)));
                }
                _passportData = value;
            }
        }


        /// <summary>
        /// Возраст взрослого
        /// </summary>
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value <= 18)
                {
                    throw new ArgumentException(
                        string.Format("***Too young for adult***",
                        nameof(value)));
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Сведения о браке взрослого
        /// </summary>
        public string StateOfMarriage
        {
            get
            {
                return _marriage;
            }
            set
            {
                CheckStringData(value);
                _marriage = value;
            }
        }

        /// <summary>
        /// Название работы взрослого
        /// </summary>
        public string NameOfJob
        {
            get
            {
                return _nameOfJob;
            }
            set
            {
                CheckStringData(value);
                _nameOfJob = value;
            }
        }

        /// <summary>
        /// Создание данных о взрослом
        /// </summary>
        public Adult() : base("A", "A", 19, Gender.Male) { }

        /// <summary>
        /// Возвращает информацию о человеке
        /// </summary>
        public override string Information
        {
            get
            {
                string info = base.Information + string.Format(
                    " | {0,-16} | {1,-13}", StateOfMarriage, NameOfJob);
                if (StateOfMarriage == "Married")
                {
                    switch (Gender)
                    {
                        case Gender.Male:
                            Partner = (Adult)AnyRandom.GetRandomAdult(Gender.Female);
                            break;

                        case Gender.Female:
                            Partner = (Adult)AnyRandom.GetRandomAdult(Gender.Male);
                            break;
                    }
                    string dopinfo = Partner.Name + " " + Partner.Surname + 
                        " " + Partner.Age;

                    info = info + string.Format(" | {0, -13}", dopinfo);
                }
                else
                {
                    info = info + "   -";
                }
                return info;
            }
        }
    }
}
