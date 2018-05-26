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
using System.Windows.Forms;
using Basis;

namespace JustMockTestProject1.BasisTest
{
    [TestClass]
    public class SaveFigurePathTests
    {
        [TestMethod]
        public void SaveGraphicsPathTest()
        {
            List<Figure> listFigures = new List<Figure>();
            var actions = Mock.Create<SaveFigurePath>(() => new SaveFigurePath(listFigures));
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            var addPath = Mock.Create<AddFigurePath>(Constructor.Mocked);
            Mock.Arrange(() => actions.SaveGraphicsPath(new int(), new  List <PointF>(), e, new Color(), new int(), new DashStyle(), new Color(), new bool())).Returns(addPath);
        }

        [TestMethod]
        public void FiguresListTest()
        {
            List<Figure> listFigures = new List<Figure>();
            var actions = Mock.Create<SaveFigurePath>(() => new SaveFigurePath(listFigures));
            Mock.Arrange(() => actions.FiguresList).Returns(new List<Figure>());
        }
    }
}
