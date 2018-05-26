using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypesFigures;
using BaseActions;
using DataFigure;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseActions
{
    [Serializable]
    public class MoveFigure : IBaseActions
    {
        /// <summary>
        /// Переменная, хранящая скопированый список выделенных фигур.ы
        /// </summary>
        private List<Figure> _copySelectedList;

        /// <summary>
        /// Переменная, хранящая положение фигуры до перемещения.
        /// </summary>
        [NonSerialized()]
        private GraphicsPath[] _pathUndo;

        /// <summary>
        /// Переменная, хранящая положение фигуры после перемещения.
        /// </summary>
        [NonSerialized()]
        private GraphicsPath[] _pathRedo;

        /// <summary>
        /// Переменная, хранящая строку с текущим действием.
        /// </summary>
        private string _operatorValue;        

        /// <summary>
        /// Метод, выполняющий изменения положения фигур.
        /// </summary>
        /// <para name = "listFigure">Переменная, хранящая список выделенных фигур</para>
        public MoveFigure(List<Figure> listFigure)
        {
            _copySelectedList = listFigure.GetRange(0, listFigure.Count);
            _pathRedo = new GraphicsPath[_copySelectedList.Count];
            _pathUndo = new GraphicsPath[listFigure.Count];
            int i = 0;
            foreach (Figure SelectObjectResult in _copySelectedList)
            {
                _pathUndo[i] = (GraphicsPath)SelectObjectResult.PathClone.Clone();
                i++;
            }
            _operatorValue = "Moving figures";
        }

        /// <summary>
        /// Метод, выполняющий сохранения координат фигуры после перемещения.
        /// </summary>
        public void СhangeMoveEnd(List<Figure> SeleckResult)
        {
            _pathRedo = new GraphicsPath[SeleckResult.Count];
            int i = 0;
            foreach (Figure SelectObject in SeleckResult)
            {
                _pathRedo[i] = (GraphicsPath)SelectObject.PathClone.Clone();
                i++;
            }
            _operatorValue = "Moving figures";
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        public void Redo()
        {
            int i = 0;
            foreach (Figure ObjectRedo in _copySelectedList)
            {
                ObjectRedo.Path = (GraphicsPath)_pathRedo[i].Clone();
                i++;
            }
            _operatorValue = "Moving figures";
        }

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        public void Undo()
        {
            int i = 0;
            foreach (Figure ObjectUndo in _copySelectedList)
            {
                ObjectUndo.Path = (GraphicsPath)_pathUndo[i].Clone();
                i++;
                _operatorValue = "Moving figures";
            }
        }

        /// <summary>
        /// Метод, возвращающий строку с текущим действием.
        /// </summary>
        public string Operation()
        {
            return _operatorValue;
        }
    }
}
