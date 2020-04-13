using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Хранит методы для ввода данных
    /// </summary>
    /// <param name="data">Название введенных данных</param>
    /// <returns>Введенные данные</returns>
    public delegate string PersonDelegate(string data);

    /// <summary>
    /// Хранит методы для вывода ошибок
    /// </summary>
    /// <param name="e">Ошибка ввода</param>
    public delegate void MistakeDelegate(ArgumentException e);
}
