using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Basis;
using System.Drawing.Drawing2D;
using TypesFigures;
using DataFigure;
using Unity;
using BaseActions;
using Microsoft.Practices.Unity;
using SelectionFigure;
using SDK;

namespace Modes
{
    /// <summary>
    /// Класс, выполнящий выделение фигур указателем.
    /// </summary>
    public class SelectPointoMode : IModes
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
        //private PointSelection _pointSelection;        

        /// <summary>
        /// Переменная, хранящая список с видами выделения фигур.
        /// </summary>
        private List<ISelection> _selectionList = new List<ISelection>();

        /// <summary>
        /// Переменная, хранящая информацию о заливке фигуры.
        /// </summary>
        private bool _fill;

        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<ITypesFigures> _listIFigures = new List<ITypesFigures>();

        /// <summary>
        /// Переменная, хранящая класс для выполнения различных действий
        /// </summary>
        private EditData _editData;

        /// <summary>
        /// Переменная, хранящая класс для выполнения различных действий
        /// </summary>
        private MoveFigure _penMove;

        /// <summary>
        /// Переменная, хранящая класс unity.
        /// </summary>
        UnityContainer UnityContainerInit = new UnityContainer();

        public SelectPointoMode(List<ITypesFigures> ListIFigures, Selection SelectClass, DrawOnCanvas DrawClass, EditData EditDat, List<ISelection> selectionList)
        {
            _listIFigures = ListIFigures;
            _selectClass = SelectClass;            
            _selectionList = selectionList;
            _drawClass = DrawClass;
            _editData = EditDat;
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
                }
                else
                {
                    _penMove = UnityContainerInit.Resolve<MoveFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure() }));
                    _editData.СhangeMoveFigure(_selectClass.ReturnSelectedFigure(), "Down", _penMove);
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
            if (e.Button == MouseButtons.Left)
            {
                if (_selectClass.ReturnSelectedFigure().Count != 0)
                {
                    _selectClass.MouseMove(e, CurrentActions, _listIFigures);
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
            _fill = fill;
            if (e.Button == MouseButtons.Left)
            {
                if (_selectClass.ReturnSelectedFigure().Count == 0)
                {                    
                    //ISelection selectionPoint = new PointSelection();
                    _selectionList[0].MouseDown(e, _drawClass.SelectionArea(), _drawClass.FiguresList, _listIFigures, fill, _selectClass.ReturnSelectedFigure());
                    //selectionPoint.MouseDown(e, _drawClass.SeparationZone(), _drawClass.FiguresList, _figuresBuild, fill, _selectClass.ReturnSelectedFigure());

                }
                else
                {
                    _selectClass.MouseUpSupport();
                    _penMove = UnityContainerInit.Resolve<MoveFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure() }));
                    _editData.СhangeMoveFigure(_selectClass.ReturnSelectedFigure(), "MouseUp", _penMove);
                }
            }

            if (e.Button == MouseButtons.Right)
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
