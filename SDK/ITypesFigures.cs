using DataFigure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TypesFigures
{
    /// <summary>
    /// Интерфейс, 
    /// </summary>
    public interface ITypesFigures
    {
        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <param name="Figures">Переменная, хранящая информацию о фигуре.</param>
        /// <param name="ColorLine">Переменная, хранящая информацию о цвете фигуры.</param>
        void AddPivots(Figure Figures, Color ColorLine);

        /// <summary>
        /// Метод, отвечающий за перемещение и масштабирование фигур.
        /// </summary>
        /// <para name = "Figures">Переменная хранащая объект для которого нужно выполнять действия</para>
        /// <para name = "Pivots">Переменная хранащая опорные точки выбранного объекта</para>
        /// <para name = "DeltaX">Переменная хранащая разницу по координате X</para>
        /// <para name = "DeltaY">Переменная хранащая разницу по координате Y</para>        
        void ScaleSelectFigure(Figure Figures, Pivots Pivots, int DeltaX, int DeltaY);

        /// <summary>
        /// Метод, выполняющий выделение фигуры
        /// </summary>
        /// <para name = "e">Переменная хранащая значение координат курсора мыши</para>
        /// <para name = "Figures">Переменная хранащая объект выделения</para>
        /// <para name = "SelectedFigures">Список выделенных объектов</para>
        void ScaleFigure(MouseEventArgs e, Figure Figures, List<Figure> SelectedFigures);
    }
}
