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
    /// Сводное описание для DeleteFillingTests
    /// </summary>
    [TestClass]
    public class DeleteFillingTests
    {       

        [TestMethod]
        public void RedoTest()
        {
            var deleteBackgroundFigure = Mock.Create<DeleteFilling>(() => new DeleteFilling(new List<Figure>()));
            deleteBackgroundFigure.Redo();
            Mock.Assert(() => deleteBackgroundFigure.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var deleteBackgroundFigure = Mock.Create<DeleteFilling>(() => new DeleteFilling(new List<Figure>()));
            deleteBackgroundFigure.Undo();
            Mock.Assert(() => deleteBackgroundFigure.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var deleteBackgroundFigure = Mock.Create<DeleteFilling>(() => new DeleteFilling(new List<Figure>()));
            Mock.Arrange(() => deleteBackgroundFigure.Operation()).Returns(s);
        }
    }
}
