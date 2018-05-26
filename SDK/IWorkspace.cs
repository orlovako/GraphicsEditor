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
//using Unity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using SelectionFigure;
using NUnit.Framework;

namespace BaseData
{
    /// <summary>
    /// Интерфейс для рабочей области.
    /// </summary>
    public interface IWorkspace
    {
        void DrawFigure(PaintEventArgs e, int currentfigure, Color linecolor, int thickness, DashStyle dashstyle, Color linecolorSupport);

        /// <summary>
        /// Метод, выполняемый при перемещении мыши по рабочей области
        /// </summary>        
        void MouseMove(MouseEventArgs e, int currentfigure, int currentActions);

        /// <summary>
        /// Метод, выполняемый при нажатии мыши на рабочей области
        /// </summary>        
        void MouseUp(MouseEventArgs e, int _currentfigure, int _currentActions, Color linecolor, int thickness, DashStyle dashstyle, Color brushcolor, bool fill);

        /// <summary>
        /// Метод, выполняемый при отпускании кнопки мыши на рабочей области
        /// </summary>        
        void MouseDown(MouseEventArgs e, int currentfigure, int currentActions);

        /// <summary>
        /// Метод, выполняющий обновление рабочей области.
        /// </summary>
        void RefreshBitmap();

        /// <summary>
        /// Метод, выполняющий удаление опорных точек.
        /// </summary>
        void DeletePivots();

        /// <summary>
        /// Метод, выполняющий удаление фигур.
        /// </summary>
        void DeleteFigure();

        /// <summary>
        /// Метод, выполняющий удаление списка действий.
        /// </summary>
        void DeleteListActions();

        /// <summary>
        /// Метод, выполняющий копирование выделенных фигур.
        /// </summary>
        void СopyFigure();

        /// <summary>
        /// Метод, выполняющий вырезание выделенных фигур.
        /// </summary>
        void CutFigure();

        /// <summary>
        /// Метод, выполняющий вставку вырезанных фигур.
        /// </summary>
        void InsertFigure();

        /// <summary>
        /// Метод, выполняющий удаление выделенных фигур.
        /// </summary>
        void DeleteSelectFigure();

        /// <summary>
        /// Метод, выполняющий изменение заливки у выбранных фигур.
        /// </summary>
        void СhangeFilled(Color fillColor);

        /// <summary>
        /// Метод, выполняющий удаление заливки у выбранных фигур.
        /// </summary>
        void DeleteFilled();

        /// <summary>
        /// Метод, выполняющий изменение цвета кисти у выбранных фигур.
        /// </summary>
        /// <para name = "ColorPen">Переменная, хранящая новый цвет кисти.</para>
        void ChangeColorPen(Color ColorPen);

        /// <summary>
        /// Метод, выполняющий изменение стиля кисти у выбранных фигур.
        /// </summary>
        void СhangePenStyleFigure(DashStyle dashstylee);

        /// <summary>
        /// Метод, выполняющий изменение толщины кисти у выбранных фигур.
        /// </summary>
        void СhangePenWidthFigure(int thickness);

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        void UndoFigure();

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        void RedoFigure();

        /// <summary>
        /// Метод, выполняющий сериализацию списка фигур.
        /// </summary>
        void SavingCanvasFigures();

        /// <summary>
        /// Метод, выполняющий десериализацию списка фигур.
        /// </summary>
        void LoadingCanvasFigures();

        /// <summary>
        /// Метод, возвращающий список действий.
        /// </summary>
        List<IBaseActions> ReturnListActions();

        /// <summary>
        /// Метод, возвращяющий переменную, хранящую класс для чтения и записи.
        /// </summary>
        FileStream PostStream
        {
            get;
            set;
        }

        /// <summary>
        /// Метод, возвращяющий переменную, хранящую класс для сериализации и десериализации объекта.
        /// </summary>
        BinaryFormatter PostBinarry
        {
            get;
            set;
        }

        /// <summary>
        /// Метод, выполняющий возвращающение индекс комманды.
        /// </summary>
        int NumberAction
        {
            get;
            set;            
        }

        /// <summary>
        /// Метод, выполняющий экспортирование рисунка.
        /// </summary>
        PictureBox SaveProject();

        /// <summary>
        /// Метод, возвращающий список выделенных фигур.
        /// </summary>
        bool SelectFigure();        
    }
}
