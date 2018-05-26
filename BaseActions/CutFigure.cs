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
    public class CutFigure : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая скопированый список выделенных фигур
        /// </summary>
        private List<Figure> _selectFigure;

        /// <summary>
        /// Переменная, хранящая скопированый список всех фигур
        /// </summary>
        private List<Figure> _saveFigure;

        /// <summary>
        /// Переменная, хранящая скопированый список скопированных фигур
        /// </summary>
        private List<Figure> _saveResult;

        /// <summary>
        /// Переменная, хранящая ссылку на список фигур
        /// </summary>
        private List<Figure> _figure;

        /// <summary>
        /// Переменная, хранящая количество элементов в списке с выделенными фигурами.
        /// </summary>
        private int _summFigureSelect;

        /// <summary>
        /// Переменная, хранящая количество элементов в списке со всеми фигурами.
        /// </summary>
        private int _summFigureBase;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;

        /// <summary>
        /// Метод, выполняющий вырезание выбранных фигур.
        /// </summary>
        /// <param name="SelectedFiguresList">Переменная, хранящая список выделенных фигур</param>
        /// <param name="Figures">Переменная, хранящая список фигур</param>
        public CutFigure(List<Figure> SelectedFiguresList, List<Figure> Figures)
        {
            _summFigureSelect = SelectedFiguresList.Count;
            _summFigureBase = Figures.Count;

            _selectFigure = SelectedFiguresList.GetRange(0, SelectedFiguresList.Count);

            _saveFigure = Figures.GetRange(0, Figures.Count);

            _figure = Figures;

            foreach (Figure SelectObject in _selectFigure)
            {
                _figure.RemoveAt(SelectObject.IdFigure);
                int i = 0;
                foreach (Figure DrawObject in _figure)
                {
                    DrawObject.IdFigure = i;
                    i++;
                }
            }
            _saveResult = _figure.GetRange(0, _figure.Count);
            _operatorValue = "Cutting selected figures";
        }

        /// <summary>
        /// Метод, возвращающий список выделенных фигур.
        /// </summary>
        /// <returns></returns>
        public List<Figure> ReturnSelectedFigureList()
        {
            return _selectFigure;
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            _figure.Clear();
            _figure.InsertRange(0, _saveResult);

            _operatorValue = "Cutting selected figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            foreach (Figure SelectObject in _selectFigure)
            {
                _figure.Clear();
                _figure.InsertRange(0, _saveFigure);

                int i = 0;
                foreach (Figure DrawObject in _figure)
                {
                    DrawObject.IdFigure = i;
                    i++;
                }
            }
            _operatorValue = "Inserting selected figures";
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
