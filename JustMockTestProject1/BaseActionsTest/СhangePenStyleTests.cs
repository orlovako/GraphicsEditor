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
    /// Сводное описание для СhangePenStyleTests
    /// </summary>
    [TestClass]
    public class СhangePenStyleTests
    {      

        [TestMethod]
        public void RedoTest()
        {
            var deleteFigure = Mock.Create<СhangePenStyle>(() => new СhangePenStyle(new List<Figure>(), new DashStyle()));
            deleteFigure.Redo();
            Mock.Assert(() => deleteFigure.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var deleteFigure = Mock.Create<СhangePenStyle>(() => new СhangePenStyle(new List<Figure>(), new DashStyle()));
            deleteFigure.Undo();
            Mock.Assert(() => deleteFigure.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var deleteFigure = Mock.Create<СhangePenStyle>(() => new СhangePenStyle(new List<Figure>(), new DashStyle()));
            Mock.Arrange(() => deleteFigure.Operation()).Returns(s);
        }
    }
}
