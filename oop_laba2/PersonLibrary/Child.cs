using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Родители
        /// </summary>
        private Adult[] _parents = new Adult[2];

        /// <summary>
        /// Название детского сада
        /// </summary>
        private string _nameOfGarden;

        /// <summary>
        /// Состав семьи
        /// </summary>
        public StateOfFamily StateOfFamily { get; set; }

        /// <summary>
        /// Родители ребенка
        /// </summary>
        public Adult[] Parents
        {
            get
            {
                return _parents;
            }
        }

        /// <summary>
        /// Создание данных о ребенке
        /// </summary>
        public Child() : base("A", "A", 2, Gender.Male) { }

        /// <summary>
        /// Возраст ребенка
        /// </summary>
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > 18)
                {
                    throw new ArgumentException(
                        string.Format("***Too old for child***",
                        nameof(value)));
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Название детского сада ребенка
        /// </summary>
        public string NameOfGarden
        {
            get
            {
                return _nameOfGarden;
            }
            set
            {
                if (Age > 7)
                {
                    _nameOfGarden = "-";
                    return;
                }
                CheckStringData(value);
                _nameOfGarden = value;
            }
        }

        /// <summary>
        /// Информация о ребенке
        /// </summary>
        public override string Information
        {
            get
            {
                string info = base.Information + string.Format(
                    " | {0,-16} | {1,-13}", StateOfFamily, NameOfGarden);

                string dopInfo = "-";
                switch (StateOfFamily)
                {
                    case StateOfFamily.TwoParents:
                        Parents[0] = (Adult)AnyRandom.GetRandomAdult(Gender.Male);
                        Parents[1] = (Adult)AnyRandom.GetRandomAdult(Gender.Female);
                        dopInfo = string.Format("{0,-13} \n {1,-93} {2,-13}", Parents[0].Name + " " +
                            Parents[0].Surname + " " + Parents[0].Age, "",
                             Parents[1].Name + " " + Parents[1].Surname +
                            " " + Parents[1].Age);
                        break;
                    case StateOfFamily.OneParent:
                        Parents[0] = (Adult)AnyRandom.GetRandomAdult();
                        dopInfo = Parents[0].Name + " " +
                            Parents[0].Surname + " " + Parents[0].Age;
                        break;
                    default:
                        break;
                }

                info = info + string.Format(" | {0, -13}", dopInfo);

                return info;
            }
        }
    }
}
