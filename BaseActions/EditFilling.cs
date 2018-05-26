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
    public class EditFilling : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая скопированый список выделенных фигур.
        /// </summary>
        private List<Figure> _selectResult;

        /// <summary>
        /// Переменная, хранящая цвет заливки до его изменения.
        /// </summary>
        private Color[] _brushColor;

        /// <summary>
        /// Переменная, хранящая цвет новой заливки.
        /// </summary>
        private Color _brushCurrentColor;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;

        /// <summary>
        /// Переменная, хранящая знчение об использовании заливки.
        /// </summary>
        private bool[] _fillFigure;
        
        /// <summary>
        /// Метод, выполняющий изменения цвета заливки у выбранных фигур.
        /// </summary>
        /// <para name = "SeleckResult">Переменная, хранящая список выделенных фигур</para>
        /// <para name = "CurrentColor">Переменная, хранящая новый цвет заливки фигур.</para>
        public EditFilling(List<Figure> SeleckResult, Color CurrentColor)
        {
            _brushCurrentColor = CurrentColor;
            _brushColor = new Color[SeleckResult.Count];
            _fillFigure = new bool[SeleckResult.Count];
            int i = 0;
            foreach (Figure SelectObject in SeleckResult)
            {
                _brushColor[i] = SelectObject.BrushColor;
                _fillFigure[i] = SelectObject.Fill;
                i++;
            }

            _selectResult = SeleckResult.GetRange(0, SeleckResult.Count);

            foreach (Figure SelectObject in _selectResult)
            {
                if (SelectObject.CurrentFigure != 3)
                {
                    SelectObject.BrushColor = _brushCurrentColor;
                    SelectObject.Fill = true;
                }
            }
            _operatorValue = "Changing the color of selected figures";
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
                    SelectObject.BrushColor = _brushCurrentColor;
                    SelectObject.Fill = true;
                }
            }
            _operatorValue = "Changing the color of selected figures";
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
                    SelectObject.BrushColor = _brushColor[i];
                    SelectObject.Fill = _fillFigure[i];
                }
                i++;
            }
            _operatorValue = "Changing the color of selected figures cancel";
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
