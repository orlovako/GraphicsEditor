using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TypesFigures;
using DataFigure;

namespace TypesFigures
{
    public class EllipseFigure : ITypesFigures, IMouseEvent, IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построеня структуры фигур.
        /// </summary>
        private RectangleLTRB _rectangleLTRBd = new RectangleLTRB();
        private RectangleLTRB _rectangleForPivots = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая координаты начальной точки.
        /// </summary>
        private PointF _pointStart;

        /// <summary>
        /// Переменная, хранящая координаты конечной точки.
        /// </summary>
        private PointF _pointEnd;

        /// <summary>
        /// Переменная, хранящая опорные точки.
        /// </summary>
        private Pivots _pivots;

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        public List<PointF> MouseMove(List<PointF> points, MouseEventArgs e)
        {
            if ((points != null) && (points.Count != 0))
            {
                points[1] = new PointF(e.Location.X, e.Location.Y);
            }
            return points;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии отпукании мыши.
        /// </summary>        
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "TypesFiguresList">Объект хранящий о классах построения</para>
        public List<PointF> MouseUp(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFiguresList)
        {
            if ((points != null) && (points.Count != 0))
            {
                points[1] = new PointF(e.Location.X, e.Location.Y);
            }
            return points;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>        
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "TypesFiguresList">Объект хранящий о классах построения</para>
        public void MouseDown(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFiguresList)
        {
            points.Add(new PointF(e.Location.X, e.Location.Y));
            points.Add(new PointF(e.Location.X, e.Location.Y));
        }


        /// <summary>
        /// Метод, выполняющий отрисовку фигуры.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения эллипса</para>
        /// <para name = "Points">Точки для построения эллипса</para>
        /// <para name = "PenFigure">Кисть которая будет использоваться в построение эллипса</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            e.Graphics.DrawEllipse(PenFigure, _rectangleLTRBd.ShowRectangle(Points[0], Points[1]));
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "SelectObject">Переменная хранащая объект для которого нужно построить опорные точки</para>
        /// /// <para name = "ColorLine">Переменная хранащая цвет опорных точек.</para>
        public void AddPivots(Figure figure, Color ColorLine)
        {
            for (int i = 0; i < figure.PointSelect.Length; i += 3)
            {
                _pivots = new Pivots(new Pen(ColorLine, 1), new GraphicsPath());
                _pivots.Path.AddEllipse(_rectangleLTRBd.SelectFigure(figure.PointSelect[i], figure.Pen.Width));
                _pivots.IdFigure = figure.IdFigure;
                _pivots.ControlPointF = i;

                figure.AddPivots(_pivots);
            }

        }

        /// <summary>
        /// Метод, отвечающий за перемещение и масштабирование фигур.
        /// </summary>
        /// <para name = "figureSelect">Переменная хранащая объект для которого нужно выполнять действия</para>
        /// <para name = "pivots">Переменная хранащая опорные точки выбранного объекта</para>
        /// <para name = "DeltaX">Переменная хранащая разницу по координате X</para>
        /// <para name = "DeltaY">Переменная хранащая разницу по координате Y</para>        
        public void ScaleSelectFigure(Figure figureSelect, Pivots pivots, int DeltaX, int DeltaY)
        {
            figureSelect.PointSelect = figureSelect.Path.PathPoints;

            if (figureSelect.IdFigure == pivots.IdFigure)
            {
                switch (pivots.ControlPointF)
                {
                    case 12:

                        if (figureSelect.PointSelect[0].X + DeltaX > figureSelect.PointSelect[6].X)
                        {
                            figureSelect.PointSelect[0].X += DeltaX;
                        }

                        figureSelect.PointSelect[0].Y += DeltaY;

                        _pointStart.X = figureSelect.PointSelect[6].X;
                        _pointStart.Y = figureSelect.PointSelect[9].Y;

                        _pointEnd.X = figureSelect.PointSelect[0].X;
                        _pointEnd.Y = figureSelect.PointSelect[3].Y;

                        figureSelect.Path.Reset();

                        figureSelect.Path.AddEllipse(_rectangleLTRBd.ShowRectangle(_pointEnd, _pointStart));

                        break;

                    case 3:

                        if (figureSelect.PointSelect[3].Y + DeltaY > figureSelect.PointSelect[9].Y)
                        {
                            figureSelect.PointSelect[3].Y += DeltaY;

                        }

                        figureSelect.PointSelect[3].X += DeltaX;

                        _pointStart.X = figureSelect.PointSelect[6].X;
                        _pointStart.Y = figureSelect.PointSelect[9].Y;

                        _pointEnd.X = figureSelect.PointSelect[0].X;
                        _pointEnd.Y = figureSelect.PointSelect[3].Y;

                        figureSelect.Path.Reset();

                        figureSelect.Path.AddEllipse(_rectangleLTRBd.ShowRectangle(_pointStart, _pointEnd));

                        break;

                    case 6:

                        if (figureSelect.PointSelect[6].X + DeltaX < figureSelect.PointSelect[0].X)
                        {
                            figureSelect.PointSelect[6].X += DeltaX;

                        }

                        figureSelect.PointSelect[6].Y += DeltaY;

                        _pointStart.X = figureSelect.PointSelect[6].X;
                        _pointStart.Y = figureSelect.PointSelect[9].Y;

                        _pointEnd.X = figureSelect.PointSelect[0].X;
                        _pointEnd.Y = figureSelect.PointSelect[3].Y;

                        figureSelect.Path.Reset();

                        figureSelect.Path.AddEllipse(_rectangleLTRBd.ShowRectangle(_pointStart, _pointEnd));

                        break;

                    case 9:
                        if (figureSelect.PointSelect[9].Y + DeltaY < figureSelect.PointSelect[3].Y)
                        {
                            figureSelect.PointSelect[9].Y += DeltaY;
                        }

                        figureSelect.PointSelect[9].X += DeltaX;

                        _pointStart.X = figureSelect.PointSelect[6].X;
                        _pointStart.Y = figureSelect.PointSelect[9].Y;

                        _pointEnd.X = figureSelect.PointSelect[0].X;
                        _pointEnd.Y = figureSelect.PointSelect[3].Y;

                        figureSelect.Path.Reset();

                        figureSelect.Path.AddEllipse(_rectangleLTRBd.ShowRectangle(_pointStart, _pointEnd));
                        break;
                }
            }
            if (figureSelect.CurrentFigure != 1)
            {
                for (int i = 0; i < figureSelect.PointSelect.Length; i++)
                {
                    figureSelect.EditPivots(i, _rectangleForPivots.SelectFigure(figureSelect.PointSelect[i], figureSelect.Pen.Width));
                }
            }
            else
            {
                int k = 0;
                for (int i = 0; i < figureSelect.PointSelect.Length; i += 3)
                {
                    figureSelect.EditPivots(k, _rectangleForPivots.SelectFigure(figureSelect.PointSelect[i], figureSelect.Pen.Width));
                    k++;
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий выделение фигуры
        /// </summary>
        /// <para name = "e">Переменная хранащая значение координат курсора мыши</para>
        /// <para name = "figure">Переменная хранащая объект выделения</para>
        /// <para name = "figureSelecList">Список выделенных объектов</para>
        public void ScaleFigure(MouseEventArgs e, Figure figure, List<Figure> figureSelecList)
        {
            figure.PointSelect = figure.Path.PathPoints;
            figure.SelectFigure = true;
            figureSelecList.Add(figure);
        }
    }
}
