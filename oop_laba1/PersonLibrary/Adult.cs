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
    class Adult : Person
    {
        /// <summary>
        /// Серия и номер паспорт
        /// </summary>
        private int _passportData;

        /// <summary>
        /// Сведения о браке
        /// </summary>
        private bool _marrige;

        /// <summary>
        /// Название работы
        /// </summary>
        private string _nameOfJob;

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
                if (value.ToString().Length!=10)
                {
                    throw new ArgumentException(
                        string.Format("***Over bound***", nameof(value)));
                }

            }
        }

        /// <summary>
        /// Сведения о браке взрослого
        /// </summary>
        public bool Marrige { get; set; }

        /// <summary>
        /// Название работы взрослого
        /// </summary>
        public string NameOfJob { get; set; }
    }
}
