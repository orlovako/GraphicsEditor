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
    /// Сводное описание для AddFigurePathTest
    /// </summary>
    [TestClass]
    public class AddFigurePathTests
    {       

        [TestMethod]
        public void RedoTest()
        {
            var addFigure = Mock.Create<AddFigurePath>(Constructor.Mocked);
            addFigure.Redo();
            Mock.Assert(() => addFigure.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var addFigure = Mock.Create<AddFigurePath>(Constructor.Mocked);
            addFigure.Undo();
            Mock.Assert(() => addFigure.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var addFigure = Mock.Create<AddFigurePath>(Constructor.Mocked);
            Mock.Arrange(() => addFigure.Operation()).Returns(s);
        }

        [TestMethod]
        public void OutputTest()
        {
            var addFigure = Mock.Create<AddFigurePath>(Constructor.Mocked);
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, true);
            Mock.Arrange(() => addFigure.Output()).Returns(figure);
        }

        [TestCase("Rectangle")]
        [TestCase("Line")]
        [TestCase("Polyline")]
        public void TypeFigureTest(string s)
        {
            var addFigure = Mock.Create<AddFigurePath>(Constructor.Mocked);
            Mock.Arrange(() => addFigure.TypeFigure()).Returns(s);
        }
    }
}
