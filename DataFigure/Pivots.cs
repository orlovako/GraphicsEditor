using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DataFigure
{
    public class Pivots : ICloneable
    {
        /// <summary>
        /// Переменная, хранящая основную структуру опорных точек.
        /// </summary>
        private GraphicsPath _path;

        /// <summary>
        /// Переменная, хранящая перо.
        /// </summary>
        private Pen _pen;

        /// <summary>
        /// Переменная, хранящая номер опорной точки.
        /// </summary>
        private int _controlPointF;

        /// <summary>
        /// Переменная, хранящая номер фигуры.
        /// </summary>
        private int _idFigure;

        /// <summary>
        /// Метод, возвращающий номер фигуры.
        /// </summary>
        public int IdFigure
        {
            get { return _idFigure; }
            set { _idFigure = value; }
        }

        /// <summary>
        /// Метод, возвращающий графическую часть фигуры.
        /// </summary>
        public GraphicsPath Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Метод, возвращающий номер опорной точки.
        /// </summary>
        public int ControlPointF
        {
            get { return _controlPointF; }
            set { _controlPointF = value; }
        }

        /// <summary>
        /// Метод, возвращающий перо.
        /// </summary>
        public Pen @Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        /// <summary>
        /// Метод, выполняющий создание опорных точкек.
        /// </summary>
        /// <para name = "Pen">Переменная, хранящая кисть.</para>
        /// <para name = "Path">Переменная, хранящая графическое представление фигуры.</para>
        public Pivots(Pen Pen, GraphicsPath Path)
        {
            _path = Path;
            _pen = Pen;
        }

        #region ICloneable Members

        /// <summary>
        /// Метод, выполняющий клонирование опорных точек.
        /// </summary>
        public object Clone()
        {
            return new Pivots(this.Pen, this.Path.Clone() as GraphicsPath);
        }

        #endregion
    }
}
