using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DataFigure
{
    [Serializable]
    public class Figure
    {
        /// <summary>
        /// Переменная, хранящая основную структуру фигуры.
        /// </summary>
        [NonSerialized()]
        private GraphicsPath _path;

        /// <summary>
        /// Переменная, хранящая перо для отрисовки фигуры.
        /// </summary>
        [NonSerialized()]
        private Pen _pen;

        /// <summary>
        /// Переменная, хранящая набор точек фигуры.
        /// </summary>        
        private PointF[] _points;
        /// <summary>
        /// Переменная, хранящая начальную точку.
        /// </summary>
        private PointF _pointStart = new Point();

        /// <summary>
        /// Переменная, хранящая конечную точку.
        /// </summary>                
        private PointF _pointEnd = new Point();

        /// <summary>
        /// Переменная, хранящая значение выбрана ли фигура.
        /// </summary>                        
        private bool _selectFigure = false;

        /// <summary>
        /// Переменная, хранящая номер фигуры.
        /// </summary>
        private int _idFigure;

        /// <summary>
        /// Переменная, хранящая заливку фигуры.
        /// </summary>
        [NonSerialized()]
        private SolidBrush _brush;

        /// <summary>
        /// Переменная, хранящая значение заливки.
        /// </summary>
        private bool _fill;

        /// <summary>
        /// Переменная, хранящая тип фигуры.
        /// </summary>
        private int _currentFigure;

        /// <summary>
        /// Переменная, хранящая список опорных точек.
        /// </summary>
        [NonSerialized()]
        private List<Pivots> _pivotsList = new List<Pivots>();

        /// <summary>
        /// Метод, выполняющий действия над номером фигуры.
        /// </summary>
        public int IdFigure
        {
            get { return _idFigure; }
            set { _idFigure = value; }
        }

        /// <summary>
        /// Метод, выполняющий действия над графическим представлением фигуры.
        /// </summary>
        public GraphicsPath Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Метод, выполняющий клонирование фигуры.
        /// </summary>
        public GraphicsPath PathClone
        {
            get { return (GraphicsPath)_path.Clone(); }
            set { _path = value; }
        }

        /// <summary>
        /// Метод, выполняющий добавление опорных точек в список.
        /// </summary>
        public void AddPivots(Pivots pivots)
        {
            _pivotsList.Add(pivots);
        }

        /// <summary>
        /// Метод, выполняющий перерисовку опорных точек.
        /// </summary>
        public void EditPivots(int index, Rectangle Rectangles)
        {
            _pivotsList[index].Path.Reset();

            _pivotsList[index].Path.AddEllipse(Rectangles);
        }

        /// <summary>
        /// Метод, выполняющий удаление опорных точек из списка.
        /// </summary>
        public void ClearListPivots()
        {
            _pivotsList.Clear();
        }

        /// <summary>
        /// Метод, выполняющий возврат опорных точек.
        /// </summary>
        public List<Pivots> ReturnListPivots()
        {
            return _pivotsList;
        }

        /// <summary>
        /// Метод, возвращающий номер типа текущей фигуры.
        /// </summary>
        public int CurrentFigure
        {
            get { return _currentFigure; }
            set { _currentFigure = value; }
        }

        /// <summary>
        /// Метод, возвращающий точки в фигуре.
        /// </summary>
        public PointF[] PointSelect
        {
            get { return _points; }
            set { _points = value; }
        }

        /// <summary>
        /// Метод, возвращающий значение выделенной фигуры.
        /// </summary>
        public bool SelectFigure
        {
            get { return _selectFigure; }
            set { _selectFigure = value; }
        }

        /// <summary>
        /// Метод, возвращающий действия начальную координату.
        /// </summary>
        public PointF PointStart
        {
            get { return _pointStart; }
            set { _pointStart = value; }
        }

        /// <summary>
        /// Метод, возвращающий конечную координату.
        /// </summary>
        public PointF PointEnd
        {
            get { return _pointEnd; }
            set { _pointEnd = value; }
        }

        /// <summary>
        /// Метод, возвращающий цвет заливки.
        /// </summary>
        public Color BrushColor
        {
            get { return _brush.Color; }
            set { _brush.Color = value; }
        }

        /// <summary>
        /// Метод, возвращающий перо с заливкой.
        /// </summary>
        public SolidBrush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        /// <summary>
        /// Метод, возвращающий значение заливки.
        /// </summary>
        public bool Fill
        {
            get { return _fill; }
            set { _fill = value; }
        }

        /// <summary>
        /// Метод, возращающий перо.
        /// </summary>
        public Pen @Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        /// <summary>
        /// Метод, выполняющий создание фигуры.
        /// </summary>
        /// <para name = "Pen">Переменная, хранящая кисть.</para>
        /// <para name = "Path">Переменная, хранящая графическое представление фигуры.</para>
        /// <para name = "Brush">Переменная, хранящая заливки.</para>
        /// <para name = "CurrentFigure">Переменная, хранящая тип фигуры.</para>
        /// <para name = "Fill">Переменная, хранящая параметны заливки.</para>
        public Figure(Pen Pen, GraphicsPath Path, Color Brush, int CurrentFigure, bool Fill)
        {
            _brush = new SolidBrush(Color.Black);
            _path = Path;
            _pen = Pen;
            _brush.Color = Brush;
            _currentFigure = CurrentFigure;
            _fill = Fill;

        }

        /// <summary>
        /// Метод, выполняющий создание клона объекта.
        /// </summary>
        public Figure CloneFigure()
        {
            return new Figure(Pen, Path.Clone() as GraphicsPath, _brush.Color, _currentFigure, _fill);
        }
    }
}
