using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basis;
using Microsoft.Practices.Unity;
using Modes;
using TypesFigures;
using Unity;
using SelectionFigure;
using SDK;

namespace BaseData
{
    /// <summary>
    /// Класс отвечающий за инициализацию объектов
    /// </summary>
    public class DataInitialization
    {
        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<ITypesFigures> _listFigures = new List<ITypesFigures>();

        /// <summary>
        /// Переменная, хранящая список классов для построения различных фигур.
        /// </summary>
        private List<IDrawFigures> _drawListFigures = new List<IDrawFigures>();

        /// <summary>
        /// Переменная, хранящая список действий для построения различных фигур.
        /// </summary>
        private List<IModes> _modesList= new List<IModes>();

        /// <summary>
        /// Переменная, хранящая ссылку на лист с видами выделения фигур.
        /// </summary>
        private List<ISelection> _selectionList = new List<ISelection>();

        /// <summary>
        /// Переменная, хранящая класс, отвечающий за действия.
        /// </summary>
        private Actions _action;

        /// <summary>
        /// Переменная, хранящая класс, отвечающий за редактирование данных.
        /// </summary>
        private EditData _editDate;

        /// <summary>
        /// Переменная, хранящая класс для отрисовки и сохранения фигур.
        /// </summary>
        private DrawOnCanvas _drawClass;

        /// <summary>
        /// Переменные, хранящие классы для выделения.
        /// </summary>
        private Selection _selectClass;
        private PointSelection _pointSelection;
        private RectangleSelection _rectangleSelection;        

        /// <summary>
        /// Переменные, хранящие классы фигур.
        /// </summary>
        private RectangleFigure _rectangl;
        private EllipseFigure _ellipse;
        private Line _line;
        private PolylineFigure _poliLine;
        private PolygonFigure _polygon;
        private RectangleSelect _rectangleSelect;

        /// <summary>
        /// Переменная, хранящая класс, отвечающий за обработку входных событий.
        /// </summary>
        private IWorkspace _workspace;
        //private Workspace _workspace;

        public DataInitialization(int Width, int Height)
        {
            var unityContainerInit = new UnityContainer();

            _action = unityContainerInit.Resolve<Actions>();

            _selectClass = unityContainerInit.Resolve<Selection>(); 
            
            _pointSelection = unityContainerInit.Resolve<PointSelection>();

            _rectangleSelection = unityContainerInit.Resolve<RectangleSelection>();

            _drawClass = unityContainerInit.Resolve<DrawOnCanvas>(new OrderedParametersOverride(new object[] { Width, Height, _action }));

            _editDate = unityContainerInit.Resolve<EditData>(new OrderedParametersOverride(new object[] { _drawClass, _action }));

            _rectangl = unityContainerInit.Resolve<RectangleFigure>();
            _ellipse = unityContainerInit.Resolve<EllipseFigure>();
            _line = unityContainerInit.Resolve<Line>();
            _poliLine = unityContainerInit.Resolve<PolylineFigure>();
            _polygon = unityContainerInit.Resolve<PolygonFigure>();
            _rectangleSelect = unityContainerInit.Resolve<RectangleSelect>();

            _listFigures.Add(_rectangl);
            _listFigures.Add(_ellipse);
            _listFigures.Add(_line);
            _listFigures.Add(_poliLine);
            _listFigures.Add(_polygon);

            _drawListFigures.Add(_rectangl);
            _drawListFigures.Add(_ellipse);
            _drawListFigures.Add(_line);
            _drawListFigures.Add(_poliLine);
            _drawListFigures.Add(_polygon);
            _drawListFigures.Add(_rectangleSelect);

            _selectionList.Add(_pointSelection);
            _selectionList.Add(_rectangleSelection);

            _modesList.Add(unityContainerInit.Resolve<DrawMode>(new OrderedParametersOverride(new object[] { _listFigures, _selectClass, _drawClass })));
            _modesList.Add(unityContainerInit.Resolve<SelectRegionMode>(new OrderedParametersOverride(new object[] { _listFigures, _selectClass, _drawClass, _editDate, _selectionList })));
            _modesList.Add(unityContainerInit.Resolve<SelectPointoMode>(new OrderedParametersOverride(new object[] { _listFigures, _selectClass, _drawClass, _editDate, _selectionList })));

            _workspace = new Workspace(_selectClass, _drawClass, _editDate, _listFigures, _modesList, _drawListFigures);
        }

        public IWorkspace ReturnWorkspace()
        {
            return _workspace;
        }
    }
}
