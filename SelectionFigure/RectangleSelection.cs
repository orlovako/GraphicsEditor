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
using SDK;

namespace SelectionFigure
{
    /// <summary>
    /// Класс, отвечающий за выделение фигуры прямоугольной областью. 
    /// </summary>
    public class RectangleSelection : ISelection
    {
        /// <summary>
        /// Переменная, хранящая список с выделенными фигурами
        /// </summary>
        private List<Figure> _selectedFigures;

        /// <summary>
        /// Переменная, хранящая тукущие координаты мыщи.
        /// </summary>
        private Point _oldPoint;

        /// <summary>
        /// Переменная, хранящая зону выделения.
        /// </summary>
        private RectangleF _rectangleF;
        private RectangleLTRB _figureBuild = new RectangleLTRB();

        /// <summary>
        ///  Метод, выполняющий выделение фигуры.
        /// </summary>
        /// <param name="e">Переменная, хранящая класс с текущими координатами мышки.</param>
        /// <param name="Rect">Переменная, хранящая класс для прямоугольной области.</param>
        /// <param name="Figures">Переменная, хранящая класс со списком фигур.</param>
        /// <param name="ListIFigures">Переменная, хранящая класс со списком фигур.</param>
        /// <param name="fill">Переменная, храннящая информацию о заливке фигуры.</param>
        /// <param name="selectedFigures">Переменная, хранящая класс со списком выделенных фигур.</param>
        public void MouseDown(MouseEventArgs e, Rectangle Rect, List<Figure> Figures, List<ITypesFigures> ListIFigures, bool fill, List<Figure> selectedFigures)
        {
            _selectedFigures = selectedFigures;
            
            _oldPoint = e.Location;

            float figurestartX, figurestartY, figureendX, figureendY;

            if (_selectedFigures.Count == 0)
            {
                foreach (Figure DrawObject in Figures)
                {
                    figurestartX = DrawObject.PointStart.X;
                    figurestartY = DrawObject.PointStart.Y;

                    figureendX = DrawObject.PointEnd.X;
                    figureendY = DrawObject.PointEnd.Y;
                    
                    _rectangleF = DrawObject.Path.GetBounds();

                    if (figurestartX == figureendX)
                    {
                        _rectangleF.Inflate(10, 5);
                    }

                    if (figurestartY == figureendY)
                    {
                        _rectangleF.Inflate(5, 10);
                    }

                    if (_rectangleF.IntersectsWith(Rect))
                    {
                        DrawObject.PointSelect = DrawObject.Path.PathPoints;
                        DrawObject.SelectFigure = true;
                        //DrawObject.Pen.Width += 1;
                        _selectedFigures.Add(DrawObject);
                    }
                }
            }
        }
    }
}
