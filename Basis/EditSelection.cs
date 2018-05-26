using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TypesFigures;
using BaseActions;
using DataFigure;
using System.Drawing.Drawing2D;

namespace Basis
{
    public class Selection
    {
        /// <summary>
        /// Переменная, хранящая список с выделенными фигурами.
        /// </summary>
        private List<Figure> _selectedFigures = new List<Figure>();

        /// <summary>
        /// Переменная, хранящая выделенную фигуру.
        /// </summary>
        private Pivots _supportObj;

        /// <summary>
        /// Переменная, хранящая тукущие координаты мыщи.
        /// </summary>
        private Point _oldPoint;

        /// <summary>
        /// Переменная, хранящая зону выделения.
        /// </summary>
        private RectangleF _rectangleF;
        private RectangleLTRB _figureBuild = new RectangleLTRB();

        /// <summary>
        /// Метод, выполняющий отмену выделения.
        /// </summary>
        public void MouseUp()
        {
            foreach (Figure SelectObject in _selectedFigures)
            {
                if (SelectObject != null)
                {
                    //SelectObject.Pen.Width -= 1;//Возвращаем ширину пера
                    SelectObject.ClearListPivots();
                    SelectObject.PointSelect = null;
                    SelectObject.SelectFigure = false;
                    //SelectObject. = null;//Убираем ссылку на объект
                    _supportObj = null;
                }
            }
            _selectedFigures.Clear();
        }

        public void MouseUpSupport()
        {
            if (_supportObj != null)
            {
                //_supportObj.Pen.Width -= 5;
                _supportObj = null;
            }
        }

        public void SavePoint(MouseEventArgs e)
        {
            _oldPoint = e.Location;

            if (_selectedFigures.Count != 0)
            {
                foreach (Figure selectObject in _selectedFigures)
                {
                    foreach (Pivots supportObjecFigure in selectObject.ReturnListPivots())
                    {
                        _rectangleF = supportObjecFigure.Path.GetBounds();

                        if (_rectangleF.Contains(e.Location))
                        {
                            _supportObj = supportObjecFigure;                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий действия над выделенными фигурами.
        /// </summary>
        /// <para name = "e">Переменная, хранящая координаты мыши.</para>
        /// <para name = "CurrentActions">Переменная, хранящая действие над выбранной фигурой.</para>
        /// <para name = "FiguresBuild">Переменная, хранящая список действий.</para>
        public void MouseMove(MouseEventArgs e, int CurrentActions, List<ITypesFigures> FiguresBuild)
        {
            //Считаем смещение курсора
            int deltaX, deltaY;

            deltaX = e.Location.X - _oldPoint.X;
            deltaY = e.Location.Y - _oldPoint.Y;

            foreach (Figure SelectObject in _selectedFigures)
            {
                //Масштабирование опорных точек
                if ((SelectObject != null) && (_supportObj != null))
                {
                    FiguresBuild[SelectObject.CurrentFigure].ScaleSelectFigure(SelectObject, _supportObj, deltaX, deltaY);

                }
                else
                {
                    if (SelectObject != null)
                    {
                        SelectObject.PointSelect = SelectObject.Path.PathPoints;

                        SelectObject.Path.Transform(new Matrix(1, 0, 0, 1, deltaX, deltaY));

                        //_edipParametr.MoveObjectSupport(SelectObject, deltaX, deltaY);

                        if (SelectObject.CurrentFigure != 1)
                        {
                            for (int i = 0; i < SelectObject.PointSelect.Length; i++)
                            {
                                SelectObject.EditPivots(i, _figureBuild.SelectFigure(SelectObject.PointSelect[i], SelectObject.Pen.Width));
                            }
                        }
                        else
                        {
                            int k = 0;
                            for (int i = 0; i < SelectObject.PointSelect.Length; i += 3)
                            {
                                SelectObject.EditPivots(k, _figureBuild.SelectFigure(SelectObject.PointSelect[i], SelectObject.Pen.Width));
                                k++;
                            }
                        }
                    }
                }
                _oldPoint = e.Location;
            }
        }

        /// <summary>
        /// Метод, возвращающий список выделенных фигур.
        /// </summary>
        public List<Figure> ReturnSelectedFigure()
        {
            return _selectedFigures;
        }
    }
}
