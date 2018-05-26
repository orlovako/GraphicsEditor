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
using DataFigure;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basis
{
    /// <summary>
    /// Интерфейс, отвечающий за сохранение фигур.
    /// </summary>
    public interface ISave
    {
        /// <summary>
        /// Метод, отвечающий за загрузку файла.
        /// </summary>
        /// <param name="stream">Переменная, хранящая класс для чтения и записи.</param>
        /// <param name="binaryForm">Переменная, хранящая класс для десериализации.</param>
        /// <returns></returns>
        List<Figure> Load(FileStream stream, BinaryFormatter binaryForm);

        /// <summary>
        /// Метод, отвечающий за сохранение файла.
        /// </summary>
        /// <param name="figures"></param>
        void Save(object figures);

    }
}
