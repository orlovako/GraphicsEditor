using Modes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Basis;
using TypesFigures;
using BaseActions;
using DataFigure;
using Microsoft.Practices.Unity;
using Unity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SelectionFigure;
using NUnit.Framework;

namespace BaseData
{
    [Serializable]
    public class Workspace : IWorkspace
    {
        /// <summary>
        /// Переменная, хранящая список точек для построения фигур.
        /// </summary>
        private List<PointF> _points = new List<PointF>();

        /// <summary>
        /// Переменная, хранящая класс для отрисовки и сохранения фигур.
        /// </summary>
        private DrawOnCanvas _drawOnCanvas;

        /// <summary>
        /// Переменная, хранящая класс для выделения.
        /// </summary>
        private Selection _selectClass;        
        
        /// <summary>
        /// Переменная, хранящая класс для сохранения фигур.
        /// </summary>
        private ISave _saveClass;
        //private SaveFigures saveFigure;

        /// <summary>
        /// Переменная, хранящая класс для загрузки фигур.
        /// </summary>
        private ISave _saveLoad;
        //private LoadFigures loadFigures;

        /// <summary>
        /// Переменная, хранящая класс для сериализации и десериализации объекта.
        /// </summary>
        private BinaryFormatter _binaryForm;

        /// <summary>
        /// Переменная, хранящая класс для чтения и записи.
        /// </summary>
        private FileStream _stream;
        
        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<ITypesFigures> _typesFigureList = new List<ITypesFigures>();

        /// <summary>
        /// Переменная, хранящая список с фигурами при загрузке старого проекта.
        /// </summary>
        private List<Figure> _listFigure = new List<Figure>();

        /// <summary>
        /// Переменная, хранящая список действий для построения различных фигур.
        /// </summary>
        private List<IModes> _modesList = new List<IModes>();

        /// <summary>
        /// Переменная, хранящая класс с параметрами.
        /// </summary>
        private EditData _editData;

        /// <summary>
        /// Переменная, хранящая класс с DI-контейнером.
        /// </summary>
        UnityContainer UnityContainerInit = new UnityContainer();
               
        /// <summary>
        /// Переменная, хранящая класс с командой для изменения размера кисти.
        /// </summary>
        private СhangePenThickness _penWidth;

        /// <summary>
        /// Переменная, хранящая класс с командой для изменения цвета кисти.
        /// </summary>
        private СhangePenColor _penColor;

        /// <summary>
        /// Переменная, хранящая класс с командой для изменения стиля кисти.
        /// </summary>
        private СhangePenStyle _penStyle;

        /// <summary>
        /// Переменная, хранящая класс с командой для изменения цвета заливки.
        /// </summary>
        private EditFilling _brushColor;

        /// <summary>
        /// Переменная, хранящая класс с командой для удаления заливки.
        /// </summary>
        private DeleteFilling _deleteBrush;

        /// <summary>
        /// Переменная, хранящая класс с командой для удаления фигур.
        /// </summary>
        private DeleteFigure _deleteFigure;

        /// <summary>
        /// Переменная, хранящая класс с командой для вставки фигур.
        /// </summary>
        private InsertFigure _insertFigure;

        /// <summary>
        /// Переменная, хранящая класс с командой для копирования фигур.
        /// </summary>
        private CopyFigure _replicationFigure;

        /// <summary>
        /// Переменная, хранящая класс с командой для вырезания фигур.
        /// </summary>
        private CutFigure _cutFigure;

        /// <summary>
        /// Переменная, хранящая класс для отображения рисунка.
        /// </summary>
        public PictureBox _canvas = new PictureBox();

        /// <summary>
        /// Переменная, хранящая список фигур для отрисовки.
        /// </summary>
        private List<IDrawFigures> _drawListFigures;

        /// <summary>
        /// Переменная, хранящая класс с командой для отчистки рабочей области.
        /// </summary>
        private ClearCanva _clearCanva;

        /// <summary>
        /// Переменная, хранящая класс для построеня структуры фигур.
        /// </summary>
        private RectangleLTRB _rect = new RectangleLTRB();

        public Workspace(Selection selectClass, DrawOnCanvas drawOnCanvas, EditData editData, List<ITypesFigures> figuresBuild, List<IModes> actionsBuild, List<IDrawFigures> DrawListFigures)
        {
            _selectClass = selectClass;            

            _drawOnCanvas = drawOnCanvas;

            _editData = editData;

            _typesFigureList = figuresBuild.GetRange(0, figuresBuild.Count);

            _modesList = actionsBuild.GetRange(0, actionsBuild.Count);

            _drawListFigures = DrawListFigures;
        }

        /// <summary>
        /// Метод, выполняющий отрисовку фигур на канве
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentfigure">Переменная, хранящая координаты мыши.</param>
        /// <param name="linecolor">Переменная, хранящая цвет фигур.</param>
        /// <param name="thickness">Переменная, хранящая толщину фигур.</param>
        /// <param name="dashstyle">Переменная, хранящая тип линии фигур.</param>
        /// <param name="colorPivots">Переменная, хранящая цвет опорных точек.</param>
        public void DrawFigure(PaintEventArgs e, int currentfigure, Color linecolor, int thickness, DashStyle dashstyle, Color colorPivots)
        {
            _drawOnCanvas.Paint(e, currentfigure, _points, _drawListFigures, linecolor, thickness, dashstyle);
            _drawOnCanvas.Paint(e, currentfigure, _points, _drawListFigures, linecolor, thickness, dashstyle);

            if (_selectClass.ReturnSelectedFigure() != null)
            {
                _drawOnCanvas.Pivots(_selectClass.ReturnSelectedFigure(), _typesFigureList, colorPivots);
            }
        }

        /// <summary>
        /// Метод, выполняющийся при нажатии мышки.
        /// </summary>        
        /// <para name = "e">Переменная, хранящая координаты мыщи</para>
        /// <para name = "currentfigure">Переменная, хранящая номер текущей фигуры.</para>
        /// <para name = "currentActions">Переменная, хранящая номер текущего действия.</para>
        public void MouseDown(MouseEventArgs e, int currentfigure, int currentActions)
        {
            _modesList[currentActions].MouseDown(e, currentfigure);
        }

        /// <summary>
        /// Метод, выполняющийся при перемещении мыши.
        /// </summary>
        /// <para name = "currentfigure">Переменная, хранящая номер текущей фигуры.</para>
        /// <para name = "e">Переменная, хранящая координаты мыщи</para>
        public void MouseMove(MouseEventArgs e, int currentfigure, int currentActions)
        {
            _points = _modesList[currentActions].MouseMove(e, currentfigure, currentActions);
        }

        /// <summary>
        /// Метод, выполняющийся при отпускании мыши.
        /// </summary>        
        /// <para name = "e">Переменная, хранящая координаты мыщи</para>        
        /// <param name="currentfigure">Переменная, хранящая координаты мыши.</param>
        /// <param name="linecolor">Переменная, хранящая цвет фигур.</param>
        /// <param name="thickness">Переменная, хранящая толщину фигур.</param>
        /// <param name="dashstyle">Переменная, хранящая тип линии фигур.</param>
        /// <param name="colorPivots">Переменная, хранящая цвет опорных точек.</param>
        public void MouseUp(MouseEventArgs e, int _currentfigure, int _currentActions, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill)    // Нажата клавиша 
        {
            _modesList[_currentActions].MouseUp(e, _currentfigure, linecolor, thickness, dashstyle, brushcolor, fill);

        }

        /// <summary>
        /// Метод, выполняющий обновление рабочей области.
        /// </summary>
        public void RefreshBitmap()
        {
            _drawOnCanvas.RefreshBitmap();
        }

        /// <summary>
        /// Метод, выполняющий вырезание выделенных фигур.
        /// </summary>
        public void CutFigure()
        {
            if ((_selectClass.ReturnSelectedFigure() != null) && (_selectClass.ReturnSelectedFigure().Count != 0))
            {
                _cutFigure = UnityContainerInit.Resolve<CutFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), _drawOnCanvas.FiguresList }));
                _editData.CutFigure(_selectClass.ReturnSelectedFigure(), _cutFigure);
                _selectClass.MouseUp();
            }
        }

        /// <summary>
        /// Метод, выполняющий вставку вырезанных фигур.
        /// </summary>
        public void InsertFigure()
        {
            if ((_cutFigure != null) && (_cutFigure.ReturnSelectedFigureList() != null) && (_cutFigure.ReturnSelectedFigureList().Count != 0))
            {
                _insertFigure = UnityContainerInit.Resolve<InsertFigure>(new OrderedParametersOverride(new object[] { _cutFigure.ReturnSelectedFigureList(), _drawOnCanvas.FiguresList }));
                _editData.InsertFigure(_cutFigure.ReturnSelectedFigureList(), _insertFigure);
                //_cutFigure.InsertFigure(_selectClass.SeleckResult());
            }
            //_selectClass.MouseUp();
        }

        /// <summary>
        /// Метод, выполняющий удаление выделенных фигур.
        /// </summary>
        public void DeleteSelectFigure()
        {
            if ((_selectClass.ReturnSelectedFigure() != null) && (_selectClass.ReturnSelectedFigure().Count != 0))
            {
                _deleteFigure = UnityContainerInit.Resolve<DeleteFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), _drawOnCanvas.FiguresList }));
                _editData.DeleteFigure(_selectClass.ReturnSelectedFigure(), _deleteFigure);
            }
            _selectClass.MouseUp();
        }

        /// <summary>
        /// Метод, выполняющий удаление опорных точек.
        /// </summary>
        public void DeletePivots()
        {
            _selectClass.MouseUp();
        }
        
        /// <summary>
        /// Метод, выполняющий очистку канвы.
        /// </summary>
        public void DeleteFigure()
        {
            if (_points.Count != 0)
            {
                _points.Clear();
            }
            _clearCanva = UnityContainerInit.Resolve<ClearCanva>(new OrderedParametersOverride(new object[] { _drawOnCanvas.FiguresList, _listFigure }));
            _editData.Clear(_clearCanva);
            _selectClass.MouseUp();
        }

        /// <summary>
        /// Метод, выполняющий удаление списка действий.
        /// </summary>
        public void DeleteListActions()
        {
            _drawOnCanvas.ListIBaseActions.Clear();
        }

        /// <summary>
        /// Метод, выполняющий копирование выделенных фигур.
        /// </summary>
        public void СopyFigure()
        {
            if ((_selectClass.ReturnSelectedFigure() != null) && (_selectClass.ReturnSelectedFigure().Count != 0))
            {
                _replicationFigure = UnityContainerInit.Resolve<CopyFigure>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), _drawOnCanvas.FiguresList }));
                _editData.CopyFigures(_selectClass.ReturnSelectedFigure(), _replicationFigure);
            }
        }
                
        /// <summary>
        /// Метод, выполняющий изменение заливки у выбранных фигур.
        /// </summary>
        /// <param name="fillColor">Переменная, хранящая цвет заливки фигуры.</param>
        public void СhangeFilled(Color fillColor)
        {
            if (_selectClass.ReturnSelectedFigure().Count != 0)
            {
                _brushColor = UnityContainerInit.Resolve<EditFilling>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), fillColor }));
                _editData.СhangeBackgroundFigure(_selectClass.ReturnSelectedFigure(), _brushColor);
            }
        }

        /// <summary>
        /// Метод, выполняющий удаление заливки у выбранных фигур.
        /// </summary>
        public void DeleteFilled()
        {
            if ((_selectClass.ReturnSelectedFigure() != null) && (_selectClass.ReturnSelectedFigure().Count != 0))
            {
                _deleteBrush = UnityContainerInit.Resolve<DeleteFilling>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure() }));
                _editData.DeleteFillingFigure(_selectClass.ReturnSelectedFigure(), _deleteBrush);
            }
        } 

        /// <summary>
        /// Метод, выполняющий изменение цвета выделенных фигур.
        /// </summary>
        /// <para name = "ColorPen">Переменная, хранящая новый цвет фигуры.</para>
        public void ChangeColorPen(Color ColorPen)
        {
            if (_selectClass.ReturnSelectedFigure().Count != 0)
            {
                _penColor = UnityContainerInit.Resolve<СhangePenColor>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), ColorPen }));
                _editData.СhangePenColorFigure(_selectClass.ReturnSelectedFigure(), _penColor);
            }
        }

        /// <summary>
        /// Метод, выполняющий изменение типа линии у выделенных фигур.
        /// </summary>
        /// <param name="dashstylee">Переменная, хранящая тип выделенной фигуры.</param>
        public void СhangePenStyleFigure(DashStyle dashstylee)
        {
            if (_selectClass.ReturnSelectedFigure().Count != 0)
            {
                _penStyle = UnityContainerInit.Resolve<СhangePenStyle>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), dashstylee }));
                _editData.СhangePenStyleFigure(_selectClass.ReturnSelectedFigure(), _penStyle);
            }
        }

        /// <summary>
        /// Метод, выполняющий изменение толщины линии у выделенных фигур.
        /// </summary>
        /// <param name="thickness">Переменная, хранящая толщину выделенной фигуры.</param>
        public void СhangePenWidthFigure(int thickness)
        {
            if (_selectClass.ReturnSelectedFigure().Count != 0)
            {
                _penWidth = UnityContainerInit.Resolve<СhangePenThickness>(new OrderedParametersOverride(new object[] { _selectClass.ReturnSelectedFigure(), thickness }));
                _editData.СhangePenWidthFigure(_selectClass.ReturnSelectedFigure(), _penWidth);

                foreach (Figure selectFigure in _selectClass.ReturnSelectedFigure())
                {
                    if (selectFigure.CurrentFigure != 1)
                    {
                        for (int i = 0; i < selectFigure.PointSelect.Length; i++)
                        {
                            selectFigure.EditPivots(i, _rect.SelectFigure(selectFigure.PointSelect[i], selectFigure.Pen.Width));
                        }
                    }
                    else
                    {
                        int k = 0;
                        for (int i = 0; i < selectFigure.PointSelect.Length; i += 3)
                        {
                            selectFigure.EditPivots(k, _rect.SelectFigure(selectFigure.PointSelect[i], selectFigure.Pen.Width));
                            k++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий отмену действия.
        /// </summary>
        public void UndoFigure()
        {
            if ((_points != null) && (_points.Count != 0))
            {
                _points.Clear();
            }
            _selectClass.MouseUp();
            _drawOnCanvas.UndoFigure();
            _drawOnCanvas.RefreshBitmap();
        }

        /// <summary>
        /// Метод, выполняющий повтор действия.
        /// </summary>
        public void RedoFigure()
        {
            _drawOnCanvas.RedoFigure();
        }
        
        /// <summary>
        /// Метод, возвращяющий переменную, хранящую класс для чтения и записи.
        /// </summary>
        public FileStream PostStream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        /// <summary>
        /// Метод, возвращяющий переменную, хранящую класс для сериализации и десериализации объекта.
        /// </summary>
        public BinaryFormatter PostBinarry
        {
            get { return _binaryForm; }
            set { _binaryForm = value; }
        }

        /// <summary>
        /// Метод, выполняющий сериализацию списка фигур.
        /// </summary>
        public void SavingCanvasFigures()
        {
            _saveClass = UnityContainerInit.Resolve<SaveProject>(new OrderedParametersOverride(new object[] { _binaryForm, _stream }));
            _saveClass.Save(_drawOnCanvas.FiguresList);                      
        }

        /// <summary>
        /// Метод, выполняющий десериализацию списка фигур.
        /// </summary>
        public void LoadingCanvasFigures()
        {
            _saveLoad = UnityContainerInit.Resolve<LoadProject>(new OrderedParametersOverride(new object[] {}));            
            _drawOnCanvas.FiguresList = _saveLoad.Load(_stream, _binaryForm);
            _drawOnCanvas.ListIBaseActions.Clear();
            _drawOnCanvas.NumberAction = -1;            
        }

        /// <summary>
        /// Метод, выполняющий экспортирование рисунка.
        /// </summary>
        public PictureBox SaveProject()
        {
            _drawOnCanvas.SaveProject(_canvas);
            return _canvas;

        }

        /// <summary>
        /// Метод, возвращающий список выделенных фигур.
        /// </summary>
        public bool SelectFigure()
        {
            bool selectedFigure = false;
            if (_selectClass.ReturnSelectedFigure().Count != 0)
            {
                selectedFigure = true;
            }
            return selectedFigure;
        }

        /// <summary>
        /// Метод, возвращающий список фигур для истории.
        /// </summary>
        public object HistoryFigure
        {
            get
            {                
                return _drawOnCanvas.FiguresList;
            }
            set
            {                
                _drawOnCanvas.FiguresList = (List<Figure>)value;
            }
        }

        /// <summary>
        /// Метод, возвращающий список действий.
        /// </summary>
        public List<IBaseActions> ReturnListActions()
        {
            return _drawOnCanvas.ListIBaseActions;
        }

        /// <summary>
        /// Метод, возвращающий список фигур.
        /// </summary>
        public List<Figure> ReturnFiguresList()
        {
            return _drawOnCanvas.FiguresList;
        }        

        /// <summary>
        /// Метод, выполняющий возвращающение индекс комманды.
        /// </summary>
        public int NumberAction
        {
            get
            {
                if ((_points != null) && (_points.Count != 0))
                {
                    _points.Clear();
                }
                return _drawOnCanvas.NumberAction;
            }
            set
            {
                _drawOnCanvas.NumberAction = value;
            }
        }     
    }
}
