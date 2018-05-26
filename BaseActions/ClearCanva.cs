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
    public class ClearCanva : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая список с фигурами.
        /// </summary>
        private List<Figure> _figure;

        /// <summary>
        /// Переменная, хранящая список фигур при загрузке.
        /// </summary>
        private List<Figure> _figureLoad;

        /// <summary>
        /// Переменная, хранящая список фигур для восстановления.
        /// </summary>
        private List<Figure> _figureSave;        

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;        

        /// <summary>
        /// Метод, выполняющий очистку канвы.
        /// </summary>
        /// <para name = "Figure">Переменная,хранящая список с фигурами для отображения.</para>
        /// <para name = "FigureLoad">Переменная, хранящая список фигур при загрузке</para>
        public ClearCanva(List<Figure> Figure, List<Figure> FigureLoad)
        {
            _figureLoad = FigureLoad.GetRange(0, FigureLoad.Count);

            _figureSave = Figure.GetRange(0, Figure.Count);

            _figure = Figure;

            _figure.Clear();

            _operatorValue = "Сanvas cleaned";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            _figure.Clear();

            _operatorValue = "Сanvas cleaned";
        }


        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            _figure.AddRange(_figureLoad);
            _figure.AddRange(_figureSave);

            _operatorValue = "Restoring figures on the canvas";
        }

        /// <summary>
        /// Метод, возвращающий фигуру над которой проводятся действия.
        /// </summary>
        public string Operation()
        {
            return _operatorValue;
        }       
    }
}
