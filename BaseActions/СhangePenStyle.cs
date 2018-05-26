using DataFigure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace BaseActions
{
    [Serializable]
    public class СhangePenStyle : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая скопированый список выделенных фигур.
        /// </summary>
        private List<Figure> _selectResult;

        /// <summary>
        /// Переменная, хранящая новый стиль линий.
        /// </summary>
        private DashStyle _dashStyle;

        /// <summary>
        /// Переменная, хранящая кисть для рисования.
        /// </summary>
        [NonSerialized()]
        private Pen[] _pen;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;

        /// <summary>
        /// Метод, выполняющий изменения стиля линий у выбранных фигур.
        /// </summary>
        /// <para name = "SeleckResult">Переменная, хранящая список выделенных фигур</para>
        /// <para name = "DashStyle">Переменная, хранящая новый стиль линий.</para>
        public СhangePenStyle(List<Figure> SeleckResult, DashStyle dashStyle)
        {
            _dashStyle = dashStyle;
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
                CurrentPen.Width = SelectObject.Pen.Width;
                CurrentPen.DashStyle = _dashStyle;
                SelectObject.Pen = CurrentPen;
            }
            _operatorValue = "Changing style line";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            foreach (Figure SelectObject in _selectResult)
            {
                Pen CurrentPen = new Pen(SelectObject.Pen.Color);
                CurrentPen.Width = SelectObject.Pen.Width;
                CurrentPen.DashStyle = _dashStyle;

                SelectObject.Pen = CurrentPen;
            }
            _operatorValue = "Changing style line";
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
            _operatorValue = "Changing style line cancel";
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
