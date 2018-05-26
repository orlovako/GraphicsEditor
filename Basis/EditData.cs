using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using BaseActions;
using Basis;
using DataFigure;
using System.Drawing;
using System.Drawing.Drawing2D;
using Unity;

namespace Basis
{
    /// <summary>
    /// Класс, отвечающий за редактирование данных после внесения изменений.
    /// </summary>
    public class EditData
    {
        /// <summary>
        /// Переменная, хранящая класс для отрисовки и сохранения фигур.
        /// </summary>
        private DrawOnCanvas _drawClass;

        /// <summary>
        /// Переменная, хранящая класс с командой для отчистки рабочей области.
        /// </summary>
        private ClearCanva _clearCanva;

        /// <summary>
        /// Переменная, хранящая класс дествий над фигурами.
        /// </summary>
        private Actions _actions;

        /// <summary>
        /// Переменная, хранящая класс с вырезанием фигуры.
        /// </summary>
        private CutFigure _cutFigure;

        /// <summary>
        /// Переменная, хранящая список команд.
        /// </summary>
        private List<IBaseActions> _listIFigures = new List<IBaseActions>();

        public EditData(DrawOnCanvas DrawClass, Actions Action)
        {
            _drawClass = DrawClass;
            _actions = Action;
            _listIFigures.Add(_clearCanva);
        }

        /// <summary>
        /// Метод, выполняющий копирование выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "copyFigure">Переменная, хранящая  класс, отвечающий за копирование фигур.</para>
        public void CopyFigures(List<Figure> selectedFigures, CopyFigure copyFigure)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();
                _listIFigures[0] = copyFigure;
                _actions.AddAction(_listIFigures);
            }
        }

        /// <summary>
        /// Метод, выполняющий вырезание выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "cutFigure">Переменная, хранящая  класс, отвечающий за вырезание фигур.</para>
        public void CutFigure(List<Figure> selectedFigures, CutFigure cutFigure)
        {
            if (selectedFigures.Count != 0)
            {
                _cutFigure = cutFigure;
                _drawClass.EditFigure();

                _listIFigures[0] = _cutFigure;
                _actions.AddAction(_listIFigures);
            }
        }

        /// <summary>
        /// Метод, выполняющий вставку выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "insertFigure">Переменная, хранящая  класс, отвечающий за вставку фигур.</para>
        public void InsertFigure(List<Figure> selectedFigures, InsertFigure insertFigure)
        {
            if (_cutFigure.ReturnSelectedFigureList().Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = insertFigure;
                _actions.AddAction(_listIFigures);
            }
        }

        /// <summary>
        /// Метод, выполняющий удаление выбранных фигуры.
        /// </summary>
        /// <para name = "SeleckResult">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "deleteFigure">Переменная, хранящая  класс, отвечающий за удаление выделенных фигур.</para>
        public void DeleteFigure(List<Figure> selectedFigures, DeleteFigure deleteFigure)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = deleteFigure;
                _actions.AddAction(_listIFigures);

            }

        }

        /// <summary>
        /// Метод, выполняющий удаление фона у выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "deleteFigure">Переменная, хранящая  класс, отвечающий за удаление фона у выделенных фигур.</para>
        public void DeleteFillingFigure(List<Figure> selectedFigures, DeleteFilling deleteBrush)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = deleteBrush;
                _actions.AddAction(_listIFigures);

            }
        }

        /// <summary>
        /// Метод, выполняющий изменение цвета фона у выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "editFilling">Переменная, хранящая новый цвет фона.</para>
        public void СhangeBackgroundFigure(List<Figure> selectedFigures, EditFilling editFilling)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = editFilling;
                _actions.AddAction(_listIFigures);

            }

        }

        /// <summary>
        /// Метод, выполняющий изменение цвета у выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая  список выделенных фигур.</para>
        /// <para name = "changePenColor">Переменная, хранящая новый цвет кисти.</para>
        public void СhangePenColorFigure(List<Figure> selectedFigures, СhangePenColor changePenColor)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = changePenColor;
                _actions.AddAction(_listIFigures);
            }

        }

        /// <summary>
        /// Метод, отвечающий за перемещение фигуры.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая список выделенных фигур.</para>
        /// <para name = "Boot">Переменная, хранящая текущее действие над фигурой.</para>
        /// <para name = "deleteFigure">Переменная, хранящая  класс, отвечающий за перемещение выделенных фигур.</para>
        public void СhangeMoveFigure(List<Figure> selectedFigures, string str, MoveFigure moveFigure)
        {
            if (selectedFigures.Count != 0)
            {
                if (str == "Down")
                {
                    _drawClass.EditFigure();

                    var UnityContainerInit = new UnityContainer();

                    moveFigure = UnityContainerInit.Resolve<MoveFigure>(new OrderedParametersOverride(new object[] { selectedFigures }));
                }
                else
                {
                    moveFigure.СhangeMoveEnd(selectedFigures);

                    _listIFigures[0] = moveFigure;
                    _actions.AddAction(_listIFigures);
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий изменение толщины пера у выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая список выделенных фигур.</para>
        /// <para name = "changePenThickness">Переменная, хранящая  класс, отвечающий за изменение толщины линии у выделенных фигур.</para>
        public void СhangePenWidthFigure(List<Figure> selectedFigures, СhangePenThickness changePenThickness)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = changePenThickness;
                _actions.AddAction(_listIFigures);
            }
        }

        /// <summary>
        /// Метод, выполняющий изменения стиля линий у выбранных фигур.
        /// </summary>
        /// <para name = "selectedFigures">Переменная, хранящая список выделенных фигур.</para>
        /// <para name = "changePenStyle">Переменная, хранящая  класс, отвечающий за изменение стиля линии у выделенных фигур.</para>
        public void СhangePenStyleFigure(List<Figure> selectedFigures, СhangePenStyle changePenStyle)
        {
            if (selectedFigures.Count != 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = changePenStyle;
                _actions.AddAction(_listIFigures);
            }
        }

        /// <summary>
        /// Метод, очищающий список с фигурами.
        /// </summary>
        public void Clear(ClearCanva clearCanva)
        {
            if (_drawClass.FiguresList.Count == 0)
            {
                _drawClass.EditFigure();

                _listIFigures[0] = clearCanva;
                _actions.AddAction(_listIFigures);
            }
        }
    }
}
