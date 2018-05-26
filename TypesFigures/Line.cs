using DataFigure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TypesFigures
{
    public class Line : ITypesFigures, IMouseEvent, IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построения структуры опорных точек.
        /// </summary>
        private RectangleLTRB _rectangleLTRB = new RectangleLTRB();
        private RectangleLTRB _rectangleForPivots = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая опорные точки.
        /// </summary>
        private Pivots _pivots;

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "TypesFiguresList">Объект хранящий о классах построения</para>
        public void MouseDown(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFiguresList)
        {
            points.Add(new PointF(e.Location.X, e.Location.Y));
            points.Add(new PointF(e.Location.X, e.Location.Y));
        }

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
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
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
        /// Метод, выполняющий отрисовку линии при построении.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения линии</para>
        /// <para name = "Points">Точки для построения линии</para>
        /// <para name = "PenFigure">Кисть которая будет использоваться в построение линии</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            e.Graphics.DrawLine(PenFigure, Points[0], Points[1]);
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "figure">Переменная хранащая объект для которого нужно построить опорные точки</para>
        public void AddPivots(Figure figure, Color ColorLine)
        {
            for (int i = 0; i < figure.PointSelect.Length; i++)
            {
                _pivots = new Pivots(new Pen(ColorLine, 1), new GraphicsPath());
                _pivots.Path.AddEllipse(_rectangleLTRB.SelectFigure(figure.PointSelect[i], figure.Pen.Width));
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
            if ((figureSelect.PointSelect[0].X - figureSelect.PointSelect[1].X != 0) && (figureSelect.PointSelect[0].Y - figureSelect.PointSelect[1].Y != 0))
            {
                figureSelect.PointSelect = figureSelect.Path.PathPoints;
            }
            if (figureSelect.IdFigure == pivots.IdFigure)
            {
                switch (pivots.ControlPointF)
                {
                    case 0:

                        figureSelect.PointSelect[0].X += DeltaX;
                        figureSelect.PointSelect[0].Y += DeltaY;
                        figureSelect.Path.Reset();
                        figureSelect.Path.AddLine(figureSelect.PointSelect[0], figureSelect.PointSelect[1]);

                        break;

                    case 1:

                        figureSelect.PointSelect[1].X += DeltaX;
                        figureSelect.PointSelect[1].Y += DeltaY;
                        figureSelect.Path.Reset();
                        figureSelect.Path.AddLine(figureSelect.PointSelect[0], figureSelect.PointSelect[1]);

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
        /// <para name = "SelectedFigures">Список выделенных объектов</para>
        public void ScaleFigure(MouseEventArgs e, Figure figure, List<Figure> SelectedFigures)
        {
            float LineX, LineY;

            LineY = (-(figure.Path.PathPoints[1].X * figure.Path.PathPoints[0].Y - figure.Path.PathPoints[0].X * figure.Path.PathPoints[1].Y) - ((figure.Path.PathPoints[1].Y - figure.Path.PathPoints[0].Y) * e.Location.X)) / (figure.Path.PathPoints[0].X - figure.Path.PathPoints[1].X);

            LineX = (-(figure.Path.PathPoints[1].X * figure.Path.PathPoints[0].Y - figure.Path.PathPoints[0].X * figure.Path.PathPoints[1].Y) - ((figure.Path.PathPoints[0].X - figure.Path.PathPoints[1].X) * e.Location.Y)) / (figure.Path.PathPoints[1].Y - figure.Path.PathPoints[0].Y);

            if ((e.Location.Y >= LineY - figure.Pen.Width - 2) && (e.Location.Y <= LineY + figure.Pen.Width + 2) || (e.Location.X >= LineX - figure.Pen.Width - 2) && (e.Location.X <= LineX + figure.Pen.Width + 2))
            {
                figure.PointSelect = figure.Path.PathPoints;
                figure.SelectFigure = true;
                SelectedFigures.Add(figure);
            }

        }
    }
}
