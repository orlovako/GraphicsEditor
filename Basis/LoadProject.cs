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
    /// Класс, отвечающий за занрузку проекта.
    /// </summary>
    [Serializable]
    public class LoadProject : ISave
    {        
        /// <summary>
        /// Метод, выполняющий десериализацию списка фигур.
        /// </summary>
        public List<Figure> Load(FileStream stream, BinaryFormatter binaryForm)
        {
            List<Figure> figures = new List<Figure>();

            List<FigureProperties.PropertiesFigure> _figurePropertiesList = (List<FigureProperties.PropertiesFigure>)binaryForm.Deserialize(stream);

            foreach (FigureProperties.PropertiesFigure loadObject in _figurePropertiesList)
            {
                Pen newPen = new Pen(loadObject.ColorLine, loadObject.PenThickness);

                newPen.DashStyle = loadObject.PenDashStyle;

                GraphicsPath newPath = new GraphicsPath(loadObject.FiguresPoints, loadObject.FigureType);

                Figure newObject = new Figure(newPen, newPath, loadObject.ColorBrush, loadObject.CurrentFigure, loadObject.Fill);

                newObject.IdFigure = loadObject.IdFigure;

                figures.Add(newObject);
            }
            return figures;
        }

        public void Save(object figures) { }
    }
}
