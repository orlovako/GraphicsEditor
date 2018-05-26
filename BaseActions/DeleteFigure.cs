using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using TypesFigures;
using BaseActions;
using DataFigure;

namespace BaseActions
{
    [Serializable]
    public class DeleteFigure : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая список выделенных фигур
        /// </summary>
        private List<Figure> _selectResult;

        /// <summary>
        /// Переменная, хранящая список удаленных фигур. Которые будут использоваться для восстановления изначального списка фигур.
        /// </summary>
        private List<Figure> _saveFigure;

        /// <summary>
        /// Переменная, хранящая ссылку на список фигур.
        /// </summary>
        private List<Figure> _figure;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;
        
        /// <summary>
        /// Метод, выполняющий удаление выбранных фигур.
        /// </summary>
        /// <para name = "SeleckResult">Переменная, хранящая список выделенных фигур</para>
        /// <para name = "Figures">Переменная, хранящая ссылку на список фигур.</para>
        public DeleteFigure(List<Figure> SeleckResult, List<Figure> Figures)
        {
            _selectResult = SeleckResult.GetRange(0, SeleckResult.Count);

            _saveFigure = Figures.GetRange(0, Figures.Count);

            _figure = Figures;

            foreach (Figure SelectObject in _selectResult)
            {
                _figure.RemoveAt(SelectObject.IdFigure);
                int i = 0;
                foreach (Figure DrawObject in _figure)
                {
                    DrawObject.IdFigure = i;
                    i++;
                }
            }
            _operatorValue = "Removing selected figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            foreach (Figure SelectObject in _selectResult)
            {
                _figure.RemoveAt(SelectObject.IdFigure);
                int i = 0;
                foreach (Figure DrawObject in _figure)
                {
                    DrawObject.IdFigure = i;
                    i++;
                }
            }
            _operatorValue = "Removing selected figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            _figure.Clear();
            _figure.InsertRange(0, _saveFigure);


            int i = 0;
            foreach (Figure DrawObject in _figure)
            {
                DrawObject.IdFigure = i;
                i++;
            }
            _operatorValue = "Inserting removed figures";
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
