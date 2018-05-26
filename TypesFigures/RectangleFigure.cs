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
    public class RectangleFigure : ITypesFigures, IMouseEvent, IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построеня структуры опорных точек.
        /// </summary>
        private RectangleLTRB _rectangleLTRBd = new RectangleLTRB();
        private RectangleLTRB _rectangleForPivots = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая класс для построения структуры эллипса.
        /// </summary>
        private RectangleLTRB _RectangleLTRB = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая опорные точки.
        /// </summary>
        private Pivots _pivots;

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "_points">Объект хранящий данные о точках построения фигурые</para>
        public List<PointF> MouseMove(List<PointF> _points, MouseEventArgs e)
        {
            if ((_points != null) && (_points.Count != 0))
            {
                _points[1] = new PointF(e.Location.X, e.Location.Y);
            }

            return _points;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии отпукании мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "_points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "DrawClass">Объект хранящий данные о классе используемом для отрисовки фигур</para>
        /// <para name = "TypesFigureList">Объект хранящий о классах построения</para>
        public List<PointF> MouseUp(List<PointF> _points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFigureList)
        {
            if ((_points != null) && (_points.Count != 0))
            {
                _points[1] = new PointF(e.Location.X, e.Location.Y);
            }
            return _points;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>
        /// <para name = "e">Объект хранящий данные о мыши</para>
        /// <para name = "_points">Объект хранящий данные о точках построения фигурые</para>
        /// <para name = "Currentfigure">Объект хранящий данные о выбранной фигуре</para>
        /// <para name = "TypesFigureList">Объект хранящий о классах построения</para>
        public void MouseDown(List<PointF> _points, MouseEventArgs e, int Currentfigure, List<ITypesFigures> TypesFigureList)
        {
            _points.Add(new PointF(e.Location.X, e.Location.Y));
            _points.Add(new PointF(e.Location.X, e.Location.Y));
        }

        /// <summary>
        /// Метод, выполняющий отрисовку прямоугольника при построении.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения эллипса</para>
        /// <para name = "Points">Точки для построения эллипса</para>
        /// <para name = "PenFigure">Кисть которая будет использоваться в построение эллипса</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            e.Graphics.DrawRectangle(PenFigure, _RectangleLTRB.ShowRectangle(Points[0], Points[1]));
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "SelectObject">Переменная хранащая объект для которого нужно построить опорные точки</para>
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
        /// <para name = "_figure">Переменная хранащая объект для которого нужно выполнять действия</para>
        /// <para name = "pivots">Переменная хранащая опорные точки выбранного объекта</para>
        /// <para name = "DeltaX">Переменная хранащая разницу по координате X</para>
        /// <para name = "DeltaY">Переменная хранащая разницу по координате Y</para>
        public void ScaleSelectFigure(Figure Selectedfigure, Pivots pivots, int DeltaX, int DeltaY)
        {
            if ((Selectedfigure.PointSelect[0].X - Selectedfigure.PointSelect[2].X != 0) && (Selectedfigure.PointSelect[0].Y - Selectedfigure.PointSelect[2].Y != 0))
            {
                Selectedfigure.PointSelect = Selectedfigure.Path.PathPoints;
            }

            if (Selectedfigure.IdFigure == pivots.IdFigure)
            {

                switch (pivots.ControlPointF)
                {
                    case 0:
                        if (Selectedfigure.PointSelect[0].X + DeltaX < Selectedfigure.PointSelect[1].X)
                        {
                            Selectedfigure.PointSelect[0].X += DeltaX;

                        }

                        if (Selectedfigure.PointSelect[0].Y + DeltaY < Selectedfigure.PointSelect[3].Y)
                        {
                            Selectedfigure.PointSelect[0].Y += DeltaY;

                        }
                        Selectedfigure.Path.Reset();
                        Selectedfigure.Path.AddRectangle(_rectangleLTRBd.ShowRectangle(Selectedfigure.PointSelect[0], Selectedfigure.PointSelect[2]));
                        break;

                    case 1:
                        if (Selectedfigure.PointSelect[2].X + DeltaX > Selectedfigure.PointSelect[0].X)
                        {
                            Selectedfigure.PointSelect[2].X += DeltaX;
                        }
                        if (Selectedfigure.PointSelect[0].Y + DeltaY < Selectedfigure.PointSelect[2].Y)
                        {
                            Selectedfigure.PointSelect[0].Y += DeltaY;
                        }
                        Selectedfigure.Path.Reset();
                        Selectedfigure.Path.AddRectangle(_rectangleLTRBd.ShowRectangle(Selectedfigure.PointSelect[0], Selectedfigure.PointSelect[2]));
                        break;

                    case 2:
                        if (Selectedfigure.PointSelect[2].X + DeltaX > Selectedfigure.PointSelect[3].X)
                        {
                            Selectedfigure.PointSelect[2].X += DeltaX;
                        }
                        if (Selectedfigure.PointSelect[2].Y + DeltaY > Selectedfigure.PointSelect[1].Y)
                        {
                            Selectedfigure.PointSelect[2].Y += DeltaY;
                        }
                        Selectedfigure.Path.Reset();
                        Selectedfigure.Path.AddRectangle(_rectangleLTRBd.ShowRectangle(Selectedfigure.PointSelect[0], Selectedfigure.PointSelect[2]));
                        break;

                    case 3:
                        if (Selectedfigure.PointSelect[0].X + DeltaX < Selectedfigure.PointSelect[2].X)
                        {
                            Selectedfigure.PointSelect[0].X += DeltaX;
                        }
                        if (Selectedfigure.PointSelect[2].Y + DeltaY > Selectedfigure.PointSelect[0].Y)
                        {
                            Selectedfigure.PointSelect[2].Y += DeltaY;
                        }
                        Selectedfigure.Path.Reset();
                        Selectedfigure.Path.AddRectangle(_rectangleLTRBd.ShowRectangle(Selectedfigure.PointSelect[0], Selectedfigure.PointSelect[2]));
                        break;
                }

            }
            if (Selectedfigure.CurrentFigure != 1)
            {
                for (int i = 0; i < Selectedfigure.PointSelect.Length; i++)
                {
                    Selectedfigure.EditPivots(i, _rectangleForPivots.SelectFigure(Selectedfigure.PointSelect[i], Selectedfigure.Pen.Width));
                }
            }
            else
            {
                int k = 0;
                for (int i = 0; i < Selectedfigure.PointSelect.Length; i += 3)
                {
                    Selectedfigure.EditPivots(k, _rectangleForPivots.SelectFigure(Selectedfigure.PointSelect[i], Selectedfigure.Pen.Width));
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
        public void ScaleFigure(MouseEventArgs e, Figure figuree, List<Figure> figuresSelectedList)
        {
            figuree.PointSelect = figuree.Path.PathPoints;
            figuree.SelectFigure = true;
            figuresSelectedList.Add(figuree);
        }
    }
}
