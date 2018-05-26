using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TypesFigures;
using BaseActions;
using DataFigure;
using Basis;
using Unity;
using Microsoft.Practices.Unity;
using System;

namespace Basis
{    
    [Serializable]
    public class DrawOnCanvas
    {
        /// <summary>
        /// Переменная, хранящая список классов с действиями.
        /// </summary>        
        private List<IBaseActions> _listIFigures = new List<IBaseActions>();

        /// <summary>
        /// Переменная, хранящая класс с командой для отчистки рабочей области.
        /// </summary>
        private ClearCanva _clearCanva;

        /// <summary>
        /// Переменная, хранящая класс, отвечающий за действия над фигурами..
        /// </summary>
        private Actions _action;

        /// <summary>
        /// Переменная, хранящая класс для отрисовки фигур.
        /// </summary>
        private DrawShapes _drawingClass;

        /// <summary>
        /// Метод, создающий рабочую область, и инициализирующий остальные объекты.
        /// </summary>
        /// <para name = "Width">Переменная, хранящая  ширину рабочей области.</para>
        /// <para name = "Height">Переменная, хранящая  высоту рабочей области</para>
        public DrawOnCanvas(int width, int height, Actions action)
        {
            var unityContainerInit = new UnityContainer();            
            _drawingClass = unityContainerInit.Resolve<DrawShapes>(new OrderedParametersOverride(new object[] { width, height }));
            _listIFigures.Add(_clearCanva);
            _action = action;
        }

        /// <summary>
        /// Метод, выполняющий отрисовку фигур и возвращение области выделения.
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
            _drawingClass.Paint(e, Currentfigure, Points, DrawListFigures, linecolor, thickness, dashstyle);
        }

        /// <summary>
        /// Метод, выполняющий сохранение графической части фигуры.
        /// </summary>
        /// <para name = "Currentfigure">Переменная, хранящая  текущую выбранную фигуру</para>
        /// <para name = "Points">Переменная, хранящая  координаты отрисовки фигуры</para>
        public void MouseUp(int Currentfigure, List<PointF> Points, MouseEventArgs e, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)
        {
            if ((Points != null) && (Points.Count > 1))
            {
                if ((Currentfigure != 3) && (Currentfigure != 4))
                {
                    EditFigure();

                    _listIFigures[0] = _drawingClass.SaveGraphicsPath(Currentfigure, Points, e, linecolor, thickness, dashstyle, brushcolor, fill);
                    _action.AddAction(_listIFigures);

                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        EditFigure();

                        _listIFigures[0] = _drawingClass.SaveGraphicsPath(Currentfigure, Points, e, linecolor, thickness, dashstyle, brushcolor, fill);
                        _action.AddAction(_listIFigures);
                    }
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий отрисовку всех фигур на рабочей области.
        /// </summary>
        public void RefreshBitmap()
        {
            _drawingClass.RefreshBitmap();
        }

        /// <summary>
        /// Метод, выполняющий отрисовку опорных точек.
        /// </summary>
        /// <para name = "e">Переменная, хранящая  события отрисовки.</para>
        /// <para name = "SelectedFigure">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "ListIFigures">Переменная, хранящая класс отрисовки.</para>
        public void Pivots(List<Figure> SelectedFigure, List<ITypesFigures> ListIFigures, Color linecolor)
        {
            foreach (Figure SelectObject in SelectedFigure)
            {
                if (SelectObject.SelectFigure == true)
                {
                    SelectObject.SelectFigure = false;
                    SelectObject.ClearListPivots();

                    Color ColorLine = linecolor;

                    ListIFigures[SelectObject.CurrentFigure].AddPivots(SelectObject, ColorLine);
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий импорт изображения.
        /// </summary>
        public void SaveProject(PictureBox DrawForm)
        {
            _drawingClass.ImportImage();
            DrawForm.Image = _drawingClass.BitmapReturn();
        }


        /// <summary>
        /// Метод, выполняющий отчистку проекта.
        /// </summary>
        public void ClearProject(PictureBox DrawForm)
        {
            DrawForm.Image = null;
            DrawForm.Invalidate();
        }

        /// <summary>
        /// Метод, возвращающий зону выделения.
        /// </summary>
        public Rectangle SelectionArea()
        {
            return _drawingClass.SelectionArea();
        }
        
        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        public void UndoFigure()
        {
            _action.UndoFigure();
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void RedoFigure()
        {
            _action.RedoFigure();
        }


        /// <summary>
        /// Метод, выполняющий проверку списка команд и удаление лишних элементов.
        /// </summary>
        public void EditFigure()
        {
            _action.EditFigure();
        }

        /// <summary>
        /// Метод, возвращяющий список действий над фигурами.
        /// </summary>
        public List<IBaseActions> ListIBaseActions
        {
            get { return _action.BaseActionsList; }
            set { _action.BaseActionsList = value; }
        }

        /// <summary>
        /// Метод, возвращяющий список со всеми фигурами.
        /// </summary>
        public List<Figure> FiguresList
        {
            get { return _drawingClass.FiguresList; }
            set { _drawingClass.FiguresList = value; }
        }

        /// <summary>
        /// Метод, возвращяющий номер действия над фигурой.
        /// </summary>
        public int NumberAction
        {
            get { return _action.ActionNumber; }
            set { _action.ActionNumber = value; }
        }
    }
}
