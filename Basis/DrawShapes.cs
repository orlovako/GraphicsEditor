using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TypesFigures;
using BaseActions;
using DataFigure;
using Microsoft.Practices.Unity;
using Basis;
using Unity;

namespace Basis
{
    /// <summary>
    /// Класс, отвечающий за отрисовку фигуры.
    /// </summary>
    public class DrawShapes
    {
        /// <summary>
        /// Переменная, хранящая хранящая список со всеми фигурами.
        /// </summary>
        private List<Figure> _listFigures;

        /// <summary>
        /// Переменная, хранящая параметры пера для фигуры.
        /// </summary>
        private Pen _penFigure;

        /// <summary>
        /// Переменная, хранящая зону отрисовки фигур.
        /// </summary>
        private Bitmap _bmp;

        /// <summary>
        /// Переменная, хранящая ширину зоны отрисовки.
        /// </summary>
        private int _widthDraw;

        /// <summary>
        /// Переменная, хранящая высоту зоны отрисовки.
        /// </summary>
        private int _heightDraw;

        /// <summary>
        /// Переменная, хранящая класс вспомогательный класс для отрисовки. 
        /// </summary>
        private RectangleLTRB _rectL = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая прямоугольник для выделения фигур.
        /// </summary>
        private Rectangle _rect;

        /// <summary>
        /// Переменная, хранящая значения о текущей выбранной фигуры.
        /// </summary>
        private int _currentfigure;

        /// <summary>
        /// Переменная, хранящая информацию о сохранении проекта.
        /// </summary>
        private bool _saveProject = false;

        /// <summary>
        /// Переменная, хранящая класс, отвечающий за добавление графической части фигуры.
        /// </summary>
        private SaveFigurePath _savePath;       

        public DrawShapes(int Width, int Height)
        {
            _widthDraw = Width;
            _heightDraw = Height;
            _bmp = new Bitmap(Width, Height);
            _listFigures = new List<Figure>();
            var unityContainerInit = new UnityContainer();
            _savePath = unityContainerInit.Resolve<SaveFigurePath>(new OrderedParametersOverride(new object[] { _listFigures }));

        }

        /// <summary>
        /// Метод, отвечающий за отрисовку фигуры.
        /// </summary>
        /// <param name="e">Переменная, хранящая информацию для графики.</param>
        /// <param name="Currentfigure">Переменная, хранящая информацию о номере текущей фигуры</param>
        /// <param name="Points">Переменная, хранящая список точек</param>
        /// <param name="DrawListFigures">Переменная, хранящая список фигур</param>
        /// <param name="linecolor">Переменная,хранящая цвет фигуры.</param>
        /// <param name="thickness">Переменная, хранящая толщину фигуры.</param>
        /// <param name="dashstyle">Переменная, хранящая стиль линии фигуры.</param>
        public void Paint(PaintEventArgs e, int Currentfigure, List<PointF> Points, List<IDrawFigures> DrawListFigures, Color linecolor, int thickness, DashStyle dashstyle)
        {
            _currentfigure = Currentfigure;

            if ((Points != null) && (Points.Count != 0))
            {                
                _penFigure = new Pen(linecolor, thickness);
                _penFigure.DashStyle = dashstyle;

                DrawListFigures[_currentfigure].PaintFigure(e, Points, _penFigure);    

                if (Points.Count > 1)
                {
                    _rect = _rectL.ShowRectangle(Points[0], Points[1]);
                }
            }
            e.Graphics.DrawImage(_bmp, 0, 0);
        }

        /// <summary>
        /// Метод, выполняющий отрисовку всех фигур на рабочей области.
        /// </summary>
        public void RefreshBitmap()
        {
            if (_bmp != null) _bmp.Dispose();

            _bmp = new Bitmap(_widthDraw, _heightDraw);

            //Прорисовка всех объектов из списка

            using (Graphics DrawList = Graphics.FromImage(_bmp))
            {
                if (_saveProject == true)
                {
                    DrawList.Clear(Color.White);
                    _saveProject = false;
                }

                foreach (Figure figure in _savePath.FiguresList)
                {
                    DrawList.DrawPath(figure.Pen, figure.Path);

                    if (figure.Fill == true)
                    {
                        DrawList.FillPath(figure.Brush, figure.Path);  
                    }

                    foreach (Pivots pivots in figure.ReturnListPivots())
                    {
                        DrawList.DrawPath(pivots.Pen, pivots.Path);
                    }
                }
            }
        }

        /// <summary>
        /// Метод, возвращающий прямоугольник выделения.
        /// </summary>
        public Rectangle SelectionArea()
        {
            return _rect;
        }

        /// <summary>
        /// Метод, возвращающий битмапя.
        /// </summary>
        public Bitmap BitmapReturn()
        {
            return _bmp;
        }

        /// <summary>
        /// Метод, возвращяющий список со всеми фигурами.
        /// </summary>
        public List<Figure> FiguresList
        {
            get { return _savePath.FiguresList; }
            set { _savePath.FiguresList = value; }
        }

        /// <summary>
        /// Метод, отвечающий за импорт изображения.
        /// </summary>
        public void ImportImage()
        {
            _saveProject = true;
            RefreshBitmap();
        }

        /// <summary>
        /// Метод, выполняющий сохранение графической части фигуры.
        /// </summary>
        /// <para name = "currentfigure">Переменная, хранящая  текущую выбранную фигуру</para>
        /// <para name = "points">Переменная, хранящая  координаты отрисовки фигуры</para>        
        /// <param name="linecolor">Переменная,хранящая цвет фигуры.</param>
        /// <param name="thickness">Переменная, хранящая толщину фигуры.</param>
        /// <param name="dashstyle">Переменная, хранящая стиль линии фигуры.</param>
            public AddFigurePath SaveGraphicsPath(int currentfigure, List<PointF> points, MouseEventArgs e, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)
            {    
                return _savePath.SaveGraphicsPath(currentfigure, points, e, linecolor, thickness, dashstyle, brushcolor, fill);
            }
}
}
