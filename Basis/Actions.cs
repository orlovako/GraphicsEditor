using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseActions;

namespace Basis
{
    /// <summary>
    /// Класс, отвечающий за действия над фигурами.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// Список, хранящий действия над фигурами.
        /// </summary>
        private List<IBaseActions> ListBaseAction = new List<IBaseActions>();

        /// <summary>
        /// Переменная, хранящая номер текущего действия.
        /// </summary>
        private int numberAction = -1;

        /// <summary>
        /// Метод, выполняющий отмену действия.
        /// </summary>
        public void UndoFigure()
        {
            if (numberAction >= 0)
            {
                ListBaseAction[numberAction].Undo();
                numberAction -= 1;                
            }
        }        

        /// <summary>
        /// Метод, выполняющий повтор действия.
        /// </summary>
        public void RedoFigure()
        {
            if (numberAction < ListBaseAction.Count - 1)
            {
                if (numberAction == 0)
                {
                    numberAction += 1;
                    ListBaseAction[numberAction].Redo();
                }
                else
                {
                    numberAction += 1;
                    ListBaseAction[numberAction].Redo();
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий проверку списка команд и удаление лишних элементов.
        /// </summary>
        public void EditFigure()
        {
            if ((numberAction != ListBaseAction.Count - 1) && (ListBaseAction.Count != 0))
            {

                int summ = ListBaseAction.Count - 1 - numberAction;

                ListBaseAction.RemoveRange(numberAction + 1, summ);

                numberAction = ListBaseAction.Count - 1;
            }
            numberAction += 1;
        }

        /// <summary>
        /// Метод, возвращяющий и принимающий список действий.
        /// </summary>
        public List<IBaseActions> BaseActionsList
        {
            get { return ListBaseAction; }
            set { ListBaseAction = value; }
        }        

        /// <summary>
        /// Метод, возвращяющий и принимающий номер действия.
        /// </summary>
        public int ActionNumber
        {
            get { return numberAction; }
            set { numberAction = value; }
        }

        /// <summary>
        /// Метод, добавляющий действие в список.
        /// </summary>
        /// <param name="action"></param>
        public void AddAction(List<IBaseActions> action)
        {
            ListBaseAction.Add(action[0]);
        }
    }
}
