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
    public class PolygonFigure : ITypesFigures, IMouseEvent, IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построения структуры эллипса.
        /// </summary>
        private RectangleLTRB _RectangleLTRB = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая опорные точки.
        /// </summary>
        private Pivots _pivots;

        /// <summary>
        /// Переменная, хранящая класс для построеня структуры фигур.
        /// </summary>
        private RectangleLTRB _rectangleForPivots = new RectangleLTRB();

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "ListIFigure">Объект хранящий о классах построения</para>
        public void MouseDown(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> ListIFigure)
        {
            if (e.Button == MouseButtons.Left)              
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
        /// <para name = "ListIFigure">Объект хранящий о классах построения</para>
        public List<PointF> MouseUp(List<PointF> points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> ListIFigure)
        {
            return null;
        }        

        /// <summary>
        /// Метод, выполняющий отрисовку фигуры.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения эллипса</para>
        /// <para name = "Points">Точки для построения эллипса</para>
        /// <para name = "PenFigure">Кисть которая будет использоваться в построение эллипса</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            if ((Points != null) && (Points.Count > 1))
            {
                PointF[] PointPolygon = Points.ToArray();

                e.Graphics.DrawLines(PenFigure, PointPolygon);
            }
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "figure">Переменная хранащая объект для которого нужно построить опорные точки</para>
        /// <para name = "colorLine">Переменная хранащая цвет опорных точек.</para>
        public void AddPivots(Figure figure, Color colorLine)
        {
            for (int i = 0; i < figure.PointSelect.Length; i++)
            {
                _pivots = new Pivots(new Pen(colorLine, 1), new GraphicsPath());
                _pivots.Path.AddEllipse(_RectangleLTRB.SelectFigure(figure.PointSelect[i], figure.Pen.Width));
                _pivots.IdFigure = figure.IdFigure;
                _pivots.ControlPointF = i;
                figure.AddPivots(_pivots);
            }
        }

        /// <summary>
        /// Метод, отвечающий за перемещение и масштабирование фигур.
        /// </summary>
        /// <para name = "figureSelected">Переменная хранащая объект для которого нужно выполнять действия</para>
        /// <para name = "pivots">Переменная хранащая опорные точки выбранного объекта</para>
        /// <para name = "DeltaX">Переменная хранащая разницу по координате X</para>
        /// <para name = "DeltaY">Переменная хранащая разницу по координате Y</para>        
        public void ScaleSelectFigure(Figure figureSelected, Pivots pivots, int deltaX, int deltaY)
        {
            if ((figureSelected.PointSelect[0].X - figureSelected.PointSelect[1].X != 0) && (figureSelected.PointSelect[0].Y - figureSelected.PointSelect[1].Y != 0))
            {
                figureSelected.PointSelect = figureSelected.Path.PathPoints;
            }
            if (figureSelected.IdFigure == pivots.IdFigure)
            {
                figureSelected.PointSelect[pivots.ControlPointF].X += deltaX;
                figureSelected.PointSelect[pivots.ControlPointF].Y += deltaY;

                PointF[] pointF = figureSelected.PointSelect.ToArray();
                figureSelected.Path.Reset();
                figureSelected.Path.AddLines(pointF);

                if (figureSelected.CurrentFigure == 4)
                {
                    figureSelected.Path.CloseFigure();
                }
            }
            if (figureSelected.CurrentFigure != 1)
            {
                for (int i = 0; i < figureSelected.PointSelect.Length; i++)
                {
                    figureSelected.EditPivots(i, _rectangleForPivots.SelectFigure(figureSelected.PointSelect[i], figureSelected.Pen.Width));
                }
            }
            else
            {
                int k = 0;
                for (int i = 0; i < figureSelected.PointSelect.Length; i += 3)
                {
                    figureSelected.EditPivots(k, _rectangleForPivots.SelectFigure(figureSelected.PointSelect[i], figureSelected.Pen.Width));
                    k++;
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий выделение фигуры
        /// </summary>
        /// <para name = "e">Переменная хранащая значение координат курсора мыши</para>
        /// <para name = "figuree">Переменная хранащая объект выделения</para>
        /// <para name = "SelectedFigures">Список выделенных объектов</para>
        public void ScaleFigure(MouseEventArgs e, Figure figure, List<Figure> selectedFiguresList)
        {
            figure.PointSelect = figure.Path.PathPoints;
            figure.SelectFigure = true;
            //DrawObject.Pen.Width += 1;
            selectedFiguresList.Add(figure);
        }
    }
}
