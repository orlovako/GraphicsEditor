using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DataFigure;

namespace BaseActions
{
    /// <summary>
    /// Интерфейс, описывающий основные методы действий над фигурами. 
    /// </summary>
    public interface IBaseActions
    {
        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        void Redo();

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        void Undo();

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        string Operation();   
    }
}
