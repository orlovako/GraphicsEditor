using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using TypesFigures;
using BaseActions;
using DataFigure;

namespace BaseActions
{
    [Serializable]
    public class DeleteFilling : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая список выделенных фигур
        /// </summary>
        private List<Figure> _selectResult;

        /// <summary>
        /// Переменная, хранящая цвет заливки у выделенных фигур.
        /// </summary>
        private Color[] _brush;

        /// <summary>
        /// Переменная, хранящая значение о заливке фигур.
        /// </summary>
        private bool[] _fill;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;        

        /// <summary>
        /// Метод, выполняющий удаление заливки у выбранных фигур.
        /// </summary>
        /// <para name = "figuresList">Переменная, хранящая список выделенных фигур</para>
        public DeleteFilling(List<Figure> figuresList)
        {

            _brush = new Color[figuresList.Count];
            _fill = new bool[figuresList.Count];


            int i = 0;
            foreach (Figure SelectObject in figuresList)
            {
                _fill[i] = SelectObject.Fill;
                _brush[i] = SelectObject.BrushColor;
                i++;
            }
            _selectResult = figuresList.GetRange(0, figuresList.Count);

            foreach (Figure SelectObject in _selectResult)
            {
                if (SelectObject.CurrentFigure != 3)
                {
                    SelectObject.Fill = false;
                }
            }
            _operatorValue = "Removed the fill of selected figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            foreach (Figure SelectObject in _selectResult)
            {
                if (SelectObject.CurrentFigure != 3)
                {
                    SelectObject.Fill = false;
                }
            }
            _operatorValue = "Removed the fill of selected figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            int i = 0;
            foreach (Figure SelectObject in _selectResult)
            {
                if (SelectObject.CurrentFigure != 3)
                {
                    SelectObject.BrushColor = _brush[i];
                    SelectObject.Fill = _fill[i];
                }
                i++;
            }
            _operatorValue = "Filled for selected figures";
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
