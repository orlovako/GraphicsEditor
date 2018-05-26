using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TypesFigures;
using BaseActions;
using DataFigure;
using System.Drawing.Drawing2D;


namespace SDK
{
    /// <summary>
    /// Интерфейс, отвечающий за метод выделения фигур.
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// Метод, выполняющий выделение фигур.
        /// </summary>
        /// <param name="e">Объект, хранящий координаты курсора.</param>
        /// <param name="Rect">Объект, хранящий прямоугольник для выделения</param>
        /// <param name="Figures">Объект, хранящий список фигур.</param>
        /// <param name="FiguresList">Объект, хранящий список фигур.</param>
        /// <param name="fill">Объект,хранящий информацию о заливке.</param>
        /// <param name="selectedFigures">Объект, хранящий список выделенных фигур.</param>
        void MouseDown(MouseEventArgs e, Rectangle Rect, List<Figure> Figures, List<ITypesFigures> FiguresList, bool fill, List<Figure> selectedFigures);
    }
}
