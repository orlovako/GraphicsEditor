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
using System.Windows.Forms;
using SDK;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для LineTests
    /// </summary>
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            line.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => line.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            line.MouseMove(new List<PointF>(), e);
            Mock.Assert(() => line.MouseMove(new List<PointF>(), e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            line.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>());
            Mock.Arrange(() => line.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void AddSupportPointTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            line.AddPivots(figure, Color.Gainsboro);
            Mock.Assert(() => line.AddPivots(figure, Color.Gainsboro), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleSelectFigureTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            Pivots pivots = new Pivots(new Pen(Color.AliceBlue), new GraphicsPath());
            line.ScaleSelectFigure(figure, pivots, new int(), new int());
            Mock.Assert(() => line.ScaleSelectFigure(figure, pivots, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleFigureTest()
        {
            var line = Mock.Create<Line>(() => new Line());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            line.ScaleFigure(e, figure, new List<Figure>());
            Mock.Assert(() => line.ScaleFigure(e, figure, new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
