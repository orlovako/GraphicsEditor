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
    public class PolylineFigure : ITypesFigures, IMouseEvent, IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построения структуры опорных точек.
        /// </summary>
        private RectangleLTRB _RectangleLTRB = new RectangleLTRB();
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
        /// <para name = "TypesFigureList">Объект хранящий о классах построения</para>
        public void MouseDown(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFigureList)
        {
            if (e.Button == MouseButtons.Left)              //если нажата левая кнопка мыши
            {
                points.Add(new PointF(e.Location.X, e.Location.Y));
            }
        }

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        public List<PointF> MouseMove(List<PointF> points, MouseEventArgs e)
        {
            return points;
        }
        
        /// <summary>
        /// Метод, выполняющий действие при нажатии отпукании мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "_points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "TypesFigureList">Объект хранящий о классах построения</para>
        public List<PointF> MouseUp(List<PointF> _points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFigureList)
        {
            return null;
        }        

        /// <summary>
        /// Метод, выполняющий отрисовку полилинии при построении.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения эллипса</para>
        /// <para name = "Points">Точки для построения эллипса</para>
        /// <para name = "PenFigure">Кисть которая будет использоваться в построение эллипса</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            if ((Points != null) && (Points.Count > 1))
            {
                PointF[] PointPoliLine = Points.ToArray();

                e.Graphics.DrawLines(PenFigure, PointPoliLine);
            }
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "figure">Переменная хранащая объект для которого нужно построить опорные точки</para>
        /// <para name = "ColorLine">Переменная хранащая цвет линии</para>
        public void AddPivots(Figure figure, Color ColorLine)
        {
            for (int i = 0; i < figure.PointSelect.Length; i++)
            {
                _pivots = new Pivots(new Pen(ColorLine, 1), new GraphicsPath());
                _pivots.Path.AddEllipse(_RectangleLTRB.SelectFigure(figure.PointSelect[i], figure.Pen.Width));
                _pivots.IdFigure = figure.IdFigure;
                _pivots.ControlPointF = i;

                figure.AddPivots(_pivots);
            }
        }

        /// <summary>
        /// Метод, отвечающий за перемещение и масштабирование фигур.
        /// </summary>
        /// <para name = "figureSelect">Переменная хранащая объект для которого нужно выполнять действия</para>
        /// <para name = "pivotsFigure">Переменная хранащая опорные точки выбранного объекта</para>
        /// <para name = "DeltaX">Переменная хранащая разницу по координате X</para>
        /// <para name = "DeltaY">Переменная хранащая разницу по координате Y</para>
        public void ScaleSelectFigure(Figure figureSelect, Pivots pivotsFigure, int DeltaX, int DeltaY)
        {
            if ((figureSelect.PointSelect[0].X - figureSelect.PointSelect[1].X != 0) && (figureSelect.PointSelect[0].Y - figureSelect.PointSelect[1].Y != 0))
            {
                figureSelect.PointSelect = figureSelect.Path.PathPoints;
            }
            if (figureSelect.IdFigure == pivotsFigure.IdFigure)
            {
                figureSelect.PointSelect[pivotsFigure.ControlPointF].X += DeltaX;
                figureSelect.PointSelect[pivotsFigure.ControlPointF].Y += DeltaY;

                PointF[] PointF = figureSelect.PointSelect.ToArray();
                figureSelect.Path.Reset();
                figureSelect.Path.AddLines(PointF);

                if (figureSelect.CurrentFigure == 4)
                {
                    figureSelect.Path.CloseFigure();
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
        /// <para name = "DrawObject">Переменная хранащая объект выделения</para>
        /// <para name = "SelectedFigures">Список выделенных объектов</para>
        public void ScaleFigure(MouseEventArgs e, Figure figure, List<Figure> SelectedFiguresList)
        {
            for (int i = 1; i < figure.Path.PathPoints.Length; i++)
            {
                float PoliLineX, PoliLineY;
                PoliLineY = (-(figure.Path.PathPoints[i - 1].X * figure.Path.PathPoints[i].Y - figure.Path.PathPoints[i].X * figure.Path.PathPoints[i - 1].Y) - ((figure.Path.PathPoints[i - 1].Y - figure.Path.PathPoints[i].Y) * e.Location.X)) / (figure.Path.PathPoints[i].X - figure.Path.PathPoints[i - 1].X);
                PoliLineX = (-(figure.Path.PathPoints[i - 1].X * figure.Path.PathPoints[i].Y - figure.Path.PathPoints[i].X * figure.Path.PathPoints[i - 1].Y) - ((figure.Path.PathPoints[i].X - figure.Path.PathPoints[i - 1].X) * e.Location.Y)) / (figure.Path.PathPoints[i - 1].Y - figure.Path.PathPoints[i].Y);
                if ((e.Location.Y >= PoliLineY - figure.Pen.Width - 2) && (e.Location.Y <= PoliLineY + figure.Pen.Width + 2) || (e.Location.X >= PoliLineX - figure.Pen.Width - 2) && (e.Location.X <= PoliLineX + figure.Pen.Width + 2))
                {
                    figure.PointSelect = figure.Path.PathPoints;
                    figure.SelectFigure = true;
                    SelectedFiguresList.Add(figure);
                }
            }
        }
    }
}
