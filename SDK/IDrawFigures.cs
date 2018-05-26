using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFigure;
using System.Drawing;
using System.Windows.Forms;

namespace TypesFigures
{
    /// <summary>
    /// Интерфейс, метод которого выполняет отрисовку фигур.
    /// </summary>
    public interface IDrawFigures
    {
        /// <summary>
        /// Метод, выполняющий отрисовку фигур при построении.
        /// </summary>
        /// <para name = "e">Объект хранящий данные для отображения.</para>
        /// <para name = "Points">Объект, хранящий точки для построения.</para>
        /// <para name = "PenFigure">Объект, хранящий перо для рисования.</para>
        void PaintFigure(PaintEventArgs e, List<PointF> Points, Pen PenFigure);
    }
}
