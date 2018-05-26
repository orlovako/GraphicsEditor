using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using TypesFigures;
using BaseActions;
using DataFigure;
using SDK;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basis
{
    /// <summary>
    /// Класс, содержащий структуру с параметрами фигуры.
    /// </summary>
    public class FigureProperties
    {
        [Serializable]
        public struct PropertiesFigure
        {
        /// <summary>
        /// Переменная, хранящая цвет фигуры.
        /// </summary>
        public Color ColorLine;

        /// <summary>
        /// Переменная, хранящая цвет заливки.
        /// </summary>
        public Color ColorBrush;

        /// <summary>
        /// Переменная, хранящая толщину линии фигуры.
        /// </summary>
        public float PenThickness;

        /// <summary>
        /// Переменная, хранящая стиль линии фигуры.
        /// </summary>
        public System.Drawing.Drawing2D.DashStyle PenDashStyle;

        /// <summary>
        /// Переменная, хранящая информацию о заливке.
        /// </summary>
        public bool Fill;

        /// <summary>
        /// Переменная, хранящая набор точек фигуры.
        /// </summary>
        public PointF[] FiguresPoints;

        /// <summary>
        /// Переменная, хранящая тип структуры.
        /// </summary>
        public byte[] FigureType;

        /// <summary>
        /// Переменная, хранящая номер фигуры.
        /// </summary>
        public int IdFigure;

        /// <summary>
        /// Переменная, хранящая тип фигуры.
        /// </summary>
        public int CurrentFigure;
        }
    }
}
