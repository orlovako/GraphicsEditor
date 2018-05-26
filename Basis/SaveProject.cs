using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using TypesFigures;
using BaseActions;
using DataFigure;
using SDK;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basis
{
    /// <summary>
    /// Класс, отвечающий за сохранение файла.
    /// </summary>
    [Serializable]
    public class SaveProject : ISave
    {   
        /// <summary>
        /// Переменная, хранящая стурктуру для сохранения.
        /// </summary>
        private FigureProperties.PropertiesFigure _figureProperties;

        /// <summary>
        /// Переменная, хранящая список фигур.
        /// </summary>
        private List<Figure> _figuresList;

        /// <summary>
        /// Переменная хранящая класс для сериализации.
        /// </summary>
        private BinaryFormatter _binaryForm;

        /// <summary>
        /// Переменная, хранящая класс для чтения и записи.
        /// </summary>
        private FileStream _stream;
        
        public SaveProject(BinaryFormatter binaryForm, FileStream stream)
        {
            _binaryForm = binaryForm;
            _stream = stream;
        }

        /// <summary>
        /// Метод, выполняющий сериализацию списка фигур.
        /// </summary>        
        public void Save(object figures)
        {
            List<FigureProperties.PropertiesFigure> _figurePropertiesList = new List<FigureProperties.PropertiesFigure>();
            List<Figure> _figures = new List<Figure>();
            _figures = (List<Figure>)figures;

            foreach (Figure selectObjectResult in _figures)
            {                
                _figureProperties.ColorLine = selectObjectResult.Pen.Color;
                _figureProperties.PenThickness = selectObjectResult.Pen.Width;
                _figureProperties.PenDashStyle = selectObjectResult.Pen.DashStyle;
                _figureProperties.Fill = selectObjectResult.Fill;

                if (_figureProperties.Fill == true)
                {
                    _figureProperties.ColorBrush = selectObjectResult.BrushColor;
                }            
                
                _figureProperties.FiguresPoints = selectObjectResult.Path.PathPoints;
                _figureProperties.FigureType = selectObjectResult.Path.PathTypes;
                
                _figureProperties.IdFigure = selectObjectResult.IdFigure;
                _figureProperties.CurrentFigure = selectObjectResult.CurrentFigure;

                _figurePropertiesList.Add(_figureProperties);                
            }
            _binaryForm.Serialize(_stream, _figurePropertiesList);            
        }

        public List<Figure> Load(FileStream stream, BinaryFormatter binaryForm) { return _figuresList; }
    }
}
