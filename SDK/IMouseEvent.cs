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
    /// Интерфейс, методы котрого отвечают за работу с мышью при рисовании фигур.
    /// </summary>
    public interface IMouseEvent
    {
        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "Points">Объект хранящий данные о точках</para>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "Currentfigure">Объект хранящий номер выбранной фигуры</para>
        /// <para name = "FiguresList">Объект хранящий список с фигурами</para>
        void MouseDown(List<PointF> PointsList, MouseEventArgs e, int Currentfigure, List<ITypesFigures> FiguresList);

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "Points">Объект хранящий данные о точках</para>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        List<PointF> MouseMove(List<PointF> PointsList, MouseEventArgs e);

        /// <summary>
        /// Метод, выполняющий действие при отпускании мыши.
        /// </summary>
        /// <para name = "Points">Объект хранящий данные о точках</para>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "FiguresList">Объект хранящий список с фигурами</para>
        List<PointF> MouseUp(List<PointF> PointsList, MouseEventArgs e, int Currentfigure, List<ITypesFigures> FiguresList);        
    }
}
