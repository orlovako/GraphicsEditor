using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFigure;
using Telerik.JustMock;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using TypesFigures;
using BaseActions;
using SDK;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для ClearCanvaTests
    /// </summary>
    [TestClass]
    public class ClearCanvaTests
    {
        [TestMethod]
        public void RedoTest()
        {
            var clearCanva = Mock.Create<ClearCanva>(() => new ClearCanva(new List<Figure>(), new List<Figure>()));
            clearCanva.Redo();
            Mock.Assert(() => clearCanva.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var clearCanva = Mock.Create<ClearCanva>(() => new ClearCanva(new List<Figure>(), new List<Figure>()));
            clearCanva.Undo();
            Mock.Assert(() => clearCanva.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var clearCanva = Mock.Create<ClearCanva>(() => new ClearCanva(new List<Figure>(), new List<Figure>()));
            Mock.Arrange(() => clearCanva.Operation()).Returns(s);
        }
    }
}
