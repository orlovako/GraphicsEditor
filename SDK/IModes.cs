using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Modes
{
    /// <summary>
    /// Интерфейс, методы которого отвечают за события мыши при выборе режима работы.
    /// </summary>
    public interface IModes
    {
        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>        
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>        
        void MouseDown(MouseEventArgs e, int Currentfigure);

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>        
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>        
        /// <para name = "CurrentActions">Объект хранящий данные о выбранной действии</para> 
        List<PointF> MouseMove(MouseEventArgs e, int Currentfigure, int CurrentActions);

        /// <summary>
        /// Метод, выполняющий действие при отпускании мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>        
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "linecolor">Объект хранящий данные о цвете фигуры</para>
        /// <para name = "thickness">Объект хранящий данные о толщине фигуры</para>
        /// <para name = "brushcolor">Объект хранящий данные о цвете заливки фигуры</para>
        /// <para name = "fill">Объект хранящий данные о заливке фигуры</para>
        void MouseUp(MouseEventArgs e, int Currentfigure, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill);    
    }
}
