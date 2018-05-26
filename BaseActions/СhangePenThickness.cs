using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypesFigures;
using BaseActions;
using DataFigure;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseActions
{
    [Serializable]
    public class СhangePenThickness : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая скопированый список выделенных фигур.
        /// </summary>
        private List<Figure> _selectResult;

        /// <summary>
        /// Переменная, хранящая новую толщину линий.
        /// </summary>
        public int _currentThickness;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;

        /// <summary>
        /// Переменная, хранящая кисть для рисования.
        /// </summary>
        [NonSerialized()]
        private Pen[] _pen;

        /// <summary>
        /// Метод, выполняющий изменения толщины линий у выбранных фигур.
        /// </summary>
        /// <para name = "SeleckResult">Переменная, хранящая список выделенных фигур</para>
        /// <para name = "CurrentThickness">Переменная, хранящая новую толщину линий.</para>
        public СhangePenThickness(List<Figure> SeleckResult, int CurrentThickness)
        {
            _currentThickness = CurrentThickness;
            _pen = new Pen[SeleckResult.Count];

            int i = 0;
            foreach (Figure SelectObject in SeleckResult)
            {
                _pen[i] = SelectObject.Pen;
                i++;
            }
            _selectResult = SeleckResult.GetRange(0, SeleckResult.Count);

            foreach (Figure SelectObject in SeleckResult)
            {
                Pen CurrentPen = new Pen(SelectObject.Pen.Color);
                CurrentPen.Width = _currentThickness;
                CurrentPen.DashStyle = SelectObject.Pen.DashStyle;

                SelectObject.Pen = CurrentPen;
            }
            _operatorValue = "Changing width line";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            foreach (Figure SelectObject in _selectResult)
            {
                Pen CurrentPen = new Pen(SelectObject.Pen.Color);
                CurrentPen.Width = _currentThickness;
                CurrentPen.DashStyle = SelectObject.Pen.DashStyle;

                SelectObject.Pen = CurrentPen;
            }
            _operatorValue = "Changing width line";
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            int i = 0;
            foreach (Figure SelectObject in _selectResult)
            {
                SelectObject.Pen = _pen[i];
                i++;
            }
            _operatorValue = "Changing width line cancel";
        }

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        public string Operation()
        {
            return _operatorValue;
        }
    }
}
