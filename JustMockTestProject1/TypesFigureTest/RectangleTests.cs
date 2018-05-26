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
    /// Сводное описание для RectangleTests
    /// </summary>
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            rect.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => rect.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            rect.MouseMove(new List<PointF>(), e);
            Mock.Assert(() => rect.MouseMove(new List<PointF>(), e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            rect.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>());
            Mock.Arrange(() => rect.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void AddSupportPointTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            rect.AddPivots(figure, Color.Gainsboro);
            Mock.Assert(() => rect.AddPivots(figure, Color.Gainsboro), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleSelectFigureTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            Pivots pivots = new Pivots(new Pen(Color.AliceBlue), new GraphicsPath());
            rect.ScaleSelectFigure(figure, pivots, new int(), new int());
            Mock.Assert(() => rect.ScaleSelectFigure(figure, pivots, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleFigureTest()
        {
            var rect = Mock.Create<RectangleFigure>(() => new RectangleFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            rect.ScaleFigure(e, figure, new List<Figure>());
            Mock.Assert(() => rect.ScaleFigure(e, figure, new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
