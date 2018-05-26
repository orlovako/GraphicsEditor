using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TypesFigures;
using Basis;
using System.Drawing.Drawing2D;
using BaseActions;
using Unity;
using Microsoft.Practices.Unity;
using SelectionFigure;
using SDK;

namespace Modes
{
    /// <summary>
    /// Класс, выполнящий выделение фигур прямоугольной областью.
    /// </summary>
    public class SelectRegionMode : IModes
    {
        /// <summary>
        /// Переменная, хранящая список точек для построения фигур.
        /// </summary>
        private List<PointF> _points = new List<PointF>();

        /// <summary>
        /// Переменная, хранящая класс для отрисовки и сохранения фигур.
        /// </summary>
        private DrawOnCanvas _drawClass;

        /// <summary>
        /// Переменная, хранящая класс для выделения.
        /// </summary>
        private Selection _selectClass;
        //private RectangleSelection _rectangleSelection;

        /// <summary>
        /// Переменная, хранящая класс unity.
        /// </summary>
        UnityContainer UnityContainerInit = new UnityContainer();

        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<ITypesFigures> _listTypesFigure = new List<ITypesFigures>();

        /// <summary>
        /// Переменная, виды выделения фигур.
        /// </summary>
        private List<ISelection> _selectionList = new List<ISelection>();

        /// <summary>
        /// Переменная, хранящая класс для редактирования фигур.
        /// </summary>
        private EditData _editData;

        /// <summary>
        /// Переменная, хранящая класс для перемещения фигур.
        /// </summary>
        private MoveFigure _moveFigure;

        public SelectRegionMode(List<ITypesFigures> ListIFigures, Selection SelectClass, DrawOnCanvas DrawOnCanvas, EditData editData, List<ISelection> selectionList)
        {
            _listTypesFigure = ListIFigures;
            _selectClass = SelectClass;
            _selectionList = selectionList;
            _drawClass = DrawOnCanvas;
            _editData = editData;
        }

        /// <summary>
        /// Метод, выполняющий действие при нажатии мыши.
        /// </summary>       
        /// <para name = "e">Переменная, хранящая данные о мыши.</para>
        /// <para name = "Currentfigure">Переменная, хранящая данные о выбранной фигуре.</para>  
        public void MouseDown(MouseEventArgs e, int Currentfigure)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_selectClass.ReturnSelectedFigure().Count == 0)
                {
                    _selectClass.MouseUp();

                    _points.Add(new PointF(e.Location.X, e.Location.Y));
                    _points.Add(new PointF(e.Location.X, e.Location.Y));
                }
                else
                {
                    _moveFigure = UnityContainerInit.Resolve<MoveFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure() }));
                    _editData.СhangeMoveFigure(_selectClass.ReturnSelectedFigure(), "Down", _moveFigure);
                    _selectClass.SavePoint(e);
                }

            }

        }

        /// <summary>
        /// Метод, выполняющий действие при перемещении мыши.
        /// </summary>     
        /// <param name="e">Переменная, хранящая данные о мыши.</param>
        /// <param name="Currentfigure">Переменная, хранящая данные о выбранной фигуре.</param>
        /// <param name="CurrentActions">Переменная, хранящая данные о выбранном действии.</param> 
        public List<PointF> MouseMove(MouseEventArgs e, int Currentfigure, int CurrentActions)
        {
            if (_selectClass.ReturnSelectedFigure().Count == 0)
            {
                if ((e.Button == MouseButtons.Left) && (_points.Count != 0))
                {
                    _points[1] = new PointF(e.Location.X, e.Location.Y);
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    _selectClass.MouseMove(e, CurrentActions, _listTypesFigure);
                }
            }

            return _points;
        }

        /// <summary>
        /// Метод, выполняющий действие при отпускании мыши.
        /// </summary>       
        /// <para name = "e">Переменная, хранящая данные о мыши</para>
        /// <para name = "Currentfigure">Переменная, хранящая данные о выбранной фигуре</para>
        /// <para name = "linecolor">Переменная, хранящая цвет фигуры.</para>
        /// <para name = "thickness">Переменная. хранящая толщину фигуры.</para>
        /// <para name = "dashstyle">Переменная, хранящая тип линии фигуры.</para>
        /// <para name = "brushcolor">Переменная, хранящая перо с заливкой.</para>
        /// <para name = "fill">Переменная, хранящая информацию о заливке фигуры.</para>
        public void MouseUp(MouseEventArgs e, int Currentfigure, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_selectClass.ReturnSelectedFigure().Count == 0)
                {
                    //_rectangleSelection.MouseDown(e, _drawClass.SeparationZone(), _drawClass.FiguresList, _figuresBuild, fill, _selectClass.ReturnSelectedFigure());
                    _selectionList[1].MouseDown(e, _drawClass.SelectionArea(), _drawClass.FiguresList, _listTypesFigure, fill, _selectClass.ReturnSelectedFigure());
                    _points.Clear();
                }
                else
                {
                    _selectClass.MouseUpSupport();
                    _moveFigure = UnityContainerInit.Resolve<MoveFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure() }));
                    _editData.СhangeMoveFigure(_selectClass.ReturnSelectedFigure(), "MouseUp", _moveFigure);
                }

            }
            else
            {
                if (_selectClass.ReturnSelectedFigure().Count == 0)
                {
                    _selectClass.MouseUp();

                }
                else
                {
                    _selectClass.MouseUp();
                }
            }
        }        
    }
}
