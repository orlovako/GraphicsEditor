using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFigure;
using Telerik.JustMock;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using TypesFigures;
using BaseActions;
using SDK;
using System.IO;
using System.Windows.Forms;
using Basis;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для SelectionTests
    /// </summary>
    [TestClass]
    public class SelectionTests
    {
        [TestMethod]
        public void MouseUpTest()
        {
            var selection = Mock.Create<Selection>(Constructor.Mocked);
            selection.MouseUp();
            Mock.Assert(() => selection.MouseUp(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void SavePointTest()
        {
            var selection = Mock.Create<Selection>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            selection.SavePoint(e);
            Mock.Assert(() => selection.SavePoint(e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var selection = Mock.Create<Selection>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            selection.MouseMove(e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => selection.MouseMove(e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ReturnSelectedFigureTest()
        {
            var selection = Mock.Create<Selection>(Constructor.Mocked);            
            Mock.Arrange(() => selection.ReturnSelectedFigure()).Returns(new List<Figure>());
        }


    }
}
