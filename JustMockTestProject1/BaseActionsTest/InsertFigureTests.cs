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
    /// Сводное описание для InsertFigureTests
    /// </summary>
    [TestClass]
    public class InsertFigureTests
    {      

        [TestMethod]
        public void RedoTest()
        {
            var insertFigure = Mock.Create<InsertFigure>(() => new InsertFigure(new List<Figure>(), new List<Figure>()));
            insertFigure.Redo();
            Mock.Assert(() => insertFigure.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var insertFigure = Mock.Create<InsertFigure>(() => new InsertFigure(new List<Figure>(), new List<Figure>()));
            insertFigure.Undo();
            Mock.Assert(() => insertFigure.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var insertFigure = Mock.Create<InsertFigure>(() => new InsertFigure(new List<Figure>(), new List<Figure>()));
            Mock.Arrange(() => insertFigure.Operation()).Returns(s);
        }
    }
}
