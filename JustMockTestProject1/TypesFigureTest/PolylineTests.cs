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
    /// Сводное описание для PolylineTests
    /// </summary>
    [TestClass]
    public class PolylineTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polyline.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => polyline.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polyline.MouseMove(new List<PointF>(), e);
            Mock.Assert(() => polyline.MouseMove(new List<PointF>(), e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            polyline.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>());
            Mock.Arrange(() => polyline.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void AddSupportPointTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            polyline.AddPivots(figure, Color.Gainsboro);
            Mock.Assert(() => polyline.AddPivots(figure, Color.Gainsboro), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleSelectFigureTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            Pivots pivots = new Pivots(new Pen(Color.AliceBlue), new GraphicsPath());
            polyline.ScaleSelectFigure(figure, pivots, new int(), new int());
            Mock.Assert(() => polyline.ScaleSelectFigure(figure, pivots, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleFigureTest()
        {
            var polyline = Mock.Create<PolylineFigure>(() => new PolylineFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polyline.ScaleFigure(e, figure, new List<Figure>());
            Mock.Assert(() => polyline.ScaleFigure(e, figure, new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
