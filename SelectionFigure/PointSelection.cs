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
    /// Класс, отвечающий за выделение фигуры указателем.
    /// </summary>
    public class PointSelection : ISelection
    {        
        /// <summary>
        /// Переменная, хранящая список с выделенными фигурами.
        /// </summary>
        private List<Figure> _selectedFigures;
 
        /// <summary>
        /// Переменная, хранящая тукущие координаты мыщи.
        /// </summary>
        private Point _oldPoint;

        /// <summary>
        /// Переменная, хранящая прямоугольник выделения.
        /// </summary>
        private RectangleF _rectangleF;

        /// <summary>
        /// Метод, выполняющий выделение фигур.
        /// </summary>
        /// <param name="e">Переменная, хранящая класс с текущими координатами мыши.</param>
        /// <param name="Rect">Переменная, хранящая класс.</param>
        /// <param name="Figures">Переменная, хранящая класс со списком фигур.</param>
        /// <param name="ListIFigures">Переменная, хранящая класс со списком фигур.</param>
        /// <param name="fill">переменная, хранящая информацию о заливке фигуры.</param>
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

                    // Получение области выделения
                    _rectangleF = DrawObject.Path.GetBounds();

                    if (figurestartX == figureendX)
                    {
                        _rectangleF.Inflate(10, 5);
                    }

                    if (figurestartY == figureendY)
                    {
                        _rectangleF.Inflate(5, 10);
                    }

                    if (_rectangleF.Contains(e.Location))
                    {
                        switch (DrawObject.CurrentFigure)
                        {

                            case 0:
                                for (int i = 1; i < 4; i++)
                                {
                                    float RectLineX, RectLineY;
                                    RectLineY = (-(DrawObject.Path.PathPoints[i - 1].X * DrawObject.Path.PathPoints[i].Y - DrawObject.Path.PathPoints[i].X * DrawObject.Path.PathPoints[i - 1].Y) - ((DrawObject.Path.PathPoints[i - 1].Y - DrawObject.Path.PathPoints[i].Y) * e.Location.X)) / (DrawObject.Path.PathPoints[i].X - DrawObject.Path.PathPoints[i - 1].X);
                                    RectLineX = (-(DrawObject.Path.PathPoints[i - 1].X * DrawObject.Path.PathPoints[i].Y - DrawObject.Path.PathPoints[i].X * DrawObject.Path.PathPoints[i - 1].Y) - ((DrawObject.Path.PathPoints[i].X - DrawObject.Path.PathPoints[i - 1].X) * e.Location.Y)) / (DrawObject.Path.PathPoints[i - 1].Y - DrawObject.Path.PathPoints[i].Y);
                                    if ((DrawObject.Fill == false) && ((e.Location.Y >= RectLineY - DrawObject.Pen.Width - 2) && (e.Location.Y <= RectLineY + DrawObject.Pen.Width + 2) || (e.Location.X >= RectLineX - DrawObject.Pen.Width - 2) && (e.Location.X <= RectLineX + DrawObject.Pen.Width + 2)))
                                    {
                                        ListIFigures[DrawObject.CurrentFigure].ScaleFigure(e, DrawObject, _selectedFigures);
                                    }
                                }
                                float RectLineXY, RectLineYX;
                                RectLineYX = (-(DrawObject.Path.PathPoints[0].X * DrawObject.Path.PathPoints[3].Y - DrawObject.Path.PathPoints[3].X * DrawObject.Path.PathPoints[0].Y) - ((DrawObject.Path.PathPoints[0].Y - DrawObject.Path.PathPoints[3].Y) * e.Location.X)) / (DrawObject.Path.PathPoints[3].X - DrawObject.Path.PathPoints[0].X);
                                RectLineXY = (-(DrawObject.Path.PathPoints[0].X * DrawObject.Path.PathPoints[3].Y - DrawObject.Path.PathPoints[3].X * DrawObject.Path.PathPoints[0].Y) - ((DrawObject.Path.PathPoints[3].X - DrawObject.Path.PathPoints[0].X) * e.Location.Y)) / (DrawObject.Path.PathPoints[0].Y - DrawObject.Path.PathPoints[3].Y);
                                if ((DrawObject.Fill == true) || ((DrawObject.Fill == false) && ((e.Location.Y >= RectLineYX - DrawObject.Pen.Width - 2) && (e.Location.Y <= RectLineYX + DrawObject.Pen.Width + 2) || (e.Location.X >= RectLineXY - DrawObject.Pen.Width - 2) && (e.Location.X <= RectLineXY + DrawObject.Pen.Width + 2))))
                                {
                                    ListIFigures[DrawObject.CurrentFigure].ScaleFigure(e, DrawObject, _selectedFigures);
                                }
                                break;

                            case 1:
                                float x0, y0, ry, rx;
                                rx = (DrawObject.Path.PathPoints[0].X -
                                      DrawObject.Path.PathPoints[6].X) / 2;
                                ry = (DrawObject.Path.PathPoints[3].Y -
                                      DrawObject.Path.PathPoints[9].Y) / 2;
                                x0 = DrawObject.Path.PathPoints[6].X + rx;
                                y0 = DrawObject.Path.PathPoints[9].Y + ry;
                                if (((DrawObject.Fill == false) && (((e.Location.X - x0) * (e.Location.X - x0) / rx / rx +
                                      (e.Location.Y - y0) * (e.Location.Y - y0) / ry / ry) <= 1.02) &&
                                    (((e.Location.X - x0) * (e.Location.X - x0) / rx / rx +
                                      (e.Location.Y - y0) * (e.Location.Y - y0) / ry / ry) >= 0.99)) || ((DrawObject.Fill == true) && (((e.Location.X - x0) * (e.Location.X - x0) / rx / rx +
                                      (e.Location.Y - y0) * (e.Location.Y - y0) / ry / ry) <= 1.02)))
                                {

                                    ListIFigures[DrawObject.CurrentFigure].ScaleFigure(e, DrawObject, _selectedFigures);
                                }
                                break;

                            case 2:
                                float LineX, LineY;
                                LineY = (-(DrawObject.Path.PathPoints[1].X * DrawObject.Path.PathPoints[0].Y - DrawObject.Path.PathPoints[0].X * DrawObject.Path.PathPoints[1].Y) - ((DrawObject.Path.PathPoints[1].Y - DrawObject.Path.PathPoints[0].Y) * e.Location.X)) / (DrawObject.Path.PathPoints[0].X - DrawObject.Path.PathPoints[1].X);
                                LineX = (-(DrawObject.Path.PathPoints[1].X * DrawObject.Path.PathPoints[0].Y - DrawObject.Path.PathPoints[0].X * DrawObject.Path.PathPoints[1].Y) - ((DrawObject.Path.PathPoints[0].X - DrawObject.Path.PathPoints[1].X) * e.Location.Y)) / (DrawObject.Path.PathPoints[1].Y - DrawObject.Path.PathPoints[0].Y);

                                if ((e.Location.Y >= LineY - DrawObject.Pen.Width - 2) && (e.Location.Y <= LineY + DrawObject.Pen.Width + 2) || (e.Location.X >= LineX - DrawObject.Pen.Width - 2) && (e.Location.X <= LineX + DrawObject.Pen.Width + 2))
                                {
                                    ListIFigures[DrawObject.CurrentFigure].ScaleFigure(e, DrawObject, _selectedFigures);
                                }
                                break;

                            case 3:
                            case 4:

                                for (int i = 1; i < DrawObject.Path.PathPoints.Length; i++)
                                {
                                    float PoliLineX, PoliLineY;

                                    PoliLineY = (-(DrawObject.Path.PathPoints[i - 1].X * DrawObject.Path.PathPoints[i].Y - DrawObject.Path.PathPoints[i].X * DrawObject.Path.PathPoints[i - 1].Y) - ((DrawObject.Path.PathPoints[i - 1].Y - DrawObject.Path.PathPoints[i].Y) * e.Location.X)) / (DrawObject.Path.PathPoints[i].X - DrawObject.Path.PathPoints[i - 1].X);

                                    PoliLineX = (-(DrawObject.Path.PathPoints[i - 1].X * DrawObject.Path.PathPoints[i].Y - DrawObject.Path.PathPoints[i].X * DrawObject.Path.PathPoints[i - 1].Y) - ((DrawObject.Path.PathPoints[i].X - DrawObject.Path.PathPoints[i - 1].X) * e.Location.Y)) / (DrawObject.Path.PathPoints[i - 1].Y - DrawObject.Path.PathPoints[i].Y);

                                    if ((e.Location.Y >= PoliLineY - DrawObject.Pen.Width - 2) && (e.Location.Y <= PoliLineY + DrawObject.Pen.Width + 2) || (e.Location.X >= PoliLineX - DrawObject.Pen.Width - 2) && (e.Location.X <= PoliLineX + DrawObject.Pen.Width + 2))
                                    {
                                        ListIFigures[DrawObject.CurrentFigure].ScaleFigure(e, DrawObject, _selectedFigures);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
