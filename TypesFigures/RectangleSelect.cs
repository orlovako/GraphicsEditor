using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TypesFigures;
using DataFigure;

namespace TypesFigures
{
    public class RectangleSelect : IDrawFigures
    {
        /// <summary>
        /// Переменная, хранящая класс для построения структуры фигуры для выделения.
        /// </summary>
        private RectangleLTRB _RectangleLTRB = new RectangleLTRB();

        /// <summary>
        /// Переменная, хранящая кисть для выделения фигур.
        /// </summary>
        private Pen _pen = new Pen(Color.Black, 1);

        /// <summary>
        /// Метод, выполняющий отрисовку прямоугольника для выделения фигур.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения эллипса</para>
        /// <para name = "Points">Точки для построения эллипса</para>
        /// <para name = "_pen">Кисть которая будет использоваться в построение эллипса</para>
        public void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure)
        {
            e.Graphics.DrawRectangle(_pen, _RectangleLTRB.ShowRectangle(Points[0], Points[1]));
        }
    }
}
