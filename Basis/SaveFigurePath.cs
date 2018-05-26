using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BaseActions;
using DataFigure;
using Microsoft.Practices.Unity;
using Unity;

namespace Basis
{
    /// <summary>
    /// Класс, отвечающий за добавление графической части фигуры.
    /// </summary>
    public class SaveFigurePath
    {
        /// <summary>
        /// Переменная, хранящая фигуру для отрисовки.
        /// </summary>
        private Figure _figure;

        /// <summary>
        /// Переменная, хранящая хранящая список со всеми фигурами.
        /// </summary>
        private List<Figure> _listFigures;

        /// <summary>
        /// Переменная, хранящая параметры кисти для отрисовки фигур.
        /// </summary>
        private Pen _penFigure;

        /// <summary>
        /// Переменная, хранящая значения о текущей выбранной фигуры.
        /// </summary>
        private int _currentfigure;
        
        /// <summary>
        /// Переменная, хранящая информацию о заливки фигур.
        /// </summary>
        private bool _brushFill;

        public SaveFigurePath(List<Figure> listFigures)
        {
            _listFigures = listFigures;
        }

        /// <summary>
        /// Метод, выполняющий сохранение графической части фигуры.
        /// </summary>
        /// <para name = "Currentfigure">Переменная, хранящая  текущую выбранную фигуру</para>
        /// <para name = "Points">Переменная, хранящая  координаты отрисовки фигуры</para>        
        /// <param name="linecolor">Переменная,хранящая цвет фигуры.</param>
        /// <param name="thickness">Переменная, хранящая толщину фигуры.</param>
        /// <param name="dashstyle">Переменная, хранящая стиль линии фигуры.</param>
        public AddFigurePath SaveGraphicsPath(int currentfigure, List<PointF> points, MouseEventArgs e, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)
        {
            _currentfigure = currentfigure;
            //EditFigure(linecolor, thickness, dashstyle);
            _penFigure = new Pen(linecolor, thickness);
            _penFigure.DashStyle = dashstyle;

            if (_currentfigure == 3)
            {
                _brushFill = false;
            }
            else
            {
                _brushFill = fill;
            }
            _figure = new Figure(_penFigure, new GraphicsPath(), brushcolor, _currentfigure, _brushFill);

            var unityContainerInit = new UnityContainer();
            var newFigure = unityContainerInit.Resolve<AddFigurePath>(new OrderedParametersOverride(new object[] { _figure, points, _listFigures }));
            _listFigures.Add(newFigure.Output());
            points.Clear();

            return newFigure;
        }

        /// <summary>
        /// Метод, возвращяющий список со всеми фигурами.
        /// </summary>
        public List<Figure> FiguresList
        {
            get { return _listFigures; }
            set { _listFigures = value; }
        }
    }
}
