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
    class Child : Person
    {
        /// <summary>
        /// Родители
        /// </summary>
        private Adult[] _parents= new Adult[2];

        /// <summary>
        /// Название детского сада
        /// </summary>
        private string _nameOfGarden;

        /// <summary>
        /// Родители ребенка
        /// </summary>
        public Adult[] Parents { get; set; }

        /// <summary>
        /// Название детского сада ребенка
        /// </summary>
        public string NameOfGarden { get; set; }
    }
}
