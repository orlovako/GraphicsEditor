using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Basis;
using TypesFigures;

namespace Modes
{
    /// <summary>
    /// Класс, выполнящий отвечающий за рисование фигур.
    /// </summary>
    public class DrawMode : IModes
    {
        /// <summary>
        /// Переменная, хранящая список точек для построения фигур.
        /// </summary>
        private List<PointF> _points = new List<PointF>();

        /// <summary>
        /// Переменная, хранящая класс для отрисовки и сохранения фигур.
        /// </summary>
        private DrawOnCanvas _drawClass;

        /// <summary>
        /// Переменная, хранящая класс для выделения.
        /// </summary>
        private Selection _selectClass;

        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<ITypesFigures> _listIFigures = new List<ITypesFigures>();


        public DrawMode(List<ITypesFigures> FiguresBuild, Selection SelectClass, DrawOnCanvas DrawOnCanvas)
        {
            _listIFigures = FiguresBuild;
            _selectClass = SelectClass;
            _drawClass = DrawOnCanvas;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "e">Переменная, хранящая данные о мыши</para>
        /// <para name = "Currentfigure">Переменная, хранящий данные о выбранной фигуре</para>        
        public void MouseDown(MouseEventArgs e, int currentfigure)
        {
            IMouseEvent mouseEvent = (IMouseEvent)_listIFigures[currentfigure];
            mouseEvent.MouseDown(_points, e, currentfigure, _listIFigures);
        }

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "e">Переменная, хранящий данные о мыши</para>
        /// <para name = "Currentfigure">Переменная, хранящий данные о выбранной фигуре.</para>
        /// <para name = "CurrentActions">Переменная, хранящий данные о выбранном действии.</para>        
        public List<PointF> MouseMove(MouseEventArgs e, int Currentfigure, int CurrentActions)
        {            
            IMouseEvent MouseEvent = (IMouseEvent)_listIFigures[Currentfigure];
            _points = MouseEvent.MouseMove(_points, e);
            return _points;
        }

        /// <summary>
        /// Метод, выполняющий действие при отпускании мыши.
        /// </summary>
        /// <para name = "e">Переменная, хранящая данные о мыши</para>
        /// <para name = "Currentfigure">Переменная, хранящая данные о выбранной фигуре</para>
        /// <para name = "linecolor">Переменная, хранящая цвет фигуры.</para>
        /// <para name = "thickness">Переменная. хранящая толщину фигуры.</para>
        /// <para name = "dashstyle">Переменная, хранящая тип линии фигуры.</para>
        /// <para name = "brushcolor">Переменная, хранящая перо с заливкой.</para>
        /// <para name = "fill">Переменная, хранящая информацию о заливке фигуры.</para>
        public void MouseUp(MouseEventArgs e, int Currentfigure, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)
        {
            _drawClass.MouseUp(Currentfigure, _points, e, linecolor, thickness, dashstyle, brushcolor, fill);
        }        
    }
}
