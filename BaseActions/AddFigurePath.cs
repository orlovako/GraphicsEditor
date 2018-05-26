using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DataFigure;

namespace BaseActions
{
    [Serializable]
    public class AddFigurePath : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая опорные точки для построения прямоугольника.
        /// </summary>
        private List<PointF> _points;

        /// <summary>
        /// Переменная, хранящая класс с фигурой.
        /// </summary>        
        private Figure _figure;

        /// <summary>
        /// Переменная, хранящая ссылку на список фигурна канве.
        /// </summary>        
        private List<Figure> _figureList;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;

        /// <summary>
        /// Переменная, хранящая тип фигур.
        /// </summary>
        private string _typeFigure;

        /// <summary>
        /// Переменная, хранящая верхнуую координату фигуры.
        /// </summary>
        private int _top;

        /// <summary>
        /// Переменная, хранящая левую координату фигуры.
        /// </summary>       
        private int _left;

        /// <summary>
        /// Переменная, хранящая нижнюю координату фигуры.
        /// </summary>           
        private int _down;

        /// <summary>
        /// Переменная, хранящая правую координату фигуры.
        /// </summary>        
        private int _right;        

        /// <summary>
        /// Метод, выполняющий построение прямоугольника.
        /// </summary>
        /// <para name = "figure">Переменная для сохранения созданного объекта</para>
        /// <para name = "points">Точки для построения прямоугольника</para>
        /// <para name = "figures">Переменная хранащая список всех фигур</para>
        public AddFigurePath(Figure figure, List<PointF> points, List<Figure> figures)
        {
            _figure = figure;
            _points = points;
            _figureList = figures;
            _figure.PointStart = points[0];
            _figure.PointEnd = points[1];
            _figure.IdFigure = figures.Count;

            if (figure.CurrentFigure == 0)
            {
                _figure.Path.AddRectangle(ShowRectangle(_points[0], _points[1]));
                _typeFigure = "Rectangle";
            }
            if (figure.CurrentFigure == 1)
            {
                _figure.Path.AddEllipse(ShowRectangle(_points[0], _points[1]));
                _typeFigure = "Ellipse";
            }
            if (figure.CurrentFigure == 2)
            {
                _figure.Path.AddLine(_points[0], _points[1]);
                _typeFigure = "Line";
            }
            if (figure.CurrentFigure == 3)
            {
                PointF[] PointPoliLine = _points.ToArray();
                _figure.Path.AddLines(PointPoliLine);
                _typeFigure = "Polyline";
            }
            if (figure.CurrentFigure == 4)
            {
                PointF[] PointPolygon = _points.ToArray();
                _figure.Path.AddLines(PointPolygon);
                _figure.Path.CloseFigure();
                _typeFigure = "Poligon";
            }
            _operatorValue = "Added" + _typeFigure;
        }

        /// <summary>
        /// Метод, выполняющий пострение структуры фигуры.
        /// </summary>
        /// <para name = "Start">Переменная, хранящая начальную координату фигуры.</para>
        /// <para name = "End">Переменная, хранящая конечную координату фигуры.</para>
        public Rectangle ShowRectangle(PointF Start, PointF End)
        {
            _left = (int)((Start.X - End.X > 0) ? End.X : Start.X);
            _down = (int)((Start.Y - End.Y > 0) ? Start.Y : End.Y);
            _top = (int)((Start.Y - End.Y > 0) ? End.Y : Start.Y);
            _right = (int)((Start.X - End.X > 0) ? Start.X : End.X);
            Rectangle rect = Rectangle.FromLTRB(_left, _top, _right, _down);
            return rect;
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {            
            _figureList.Insert(_figure.IdFigure, _figure);
            _operatorValue = "Added" + _typeFigure;
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void Undo()
        {
            /*foreach (Figure figureReturn in _figureList)
            {
                if (figureReturn.IdFigure == _figure.IdFigure)
                {
                    _figure = figureReturn;
                }
            }*/
            _figureList.RemoveAt(_figure.IdFigure);
            _operatorValue = "Removed " + _typeFigure;
        }

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        public string Operation()
        {
            return _operatorValue;
        }

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        public string TypeFigure()
        {
            return _typeFigure;
        }

        /// <summary>
        /// Метод, возвращающий фигуру над которой проводятся действия.
        /// </summary>
        public Figure Output()
        {
            return _figure;
        }        
    }
}
