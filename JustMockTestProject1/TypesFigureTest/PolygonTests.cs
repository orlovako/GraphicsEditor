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
    /// Сводное описание для PolygonTests
    /// </summary>
    [TestClass]
    public class PolygonTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polygon.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => polygon.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polygon.MouseMove(new List<PointF>(), e);
            Mock.Assert(() => polygon.MouseMove(new List<PointF>(), e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            //polygon.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>());
            Mock.Arrange(() => polygon.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void AddSupportPointTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            polygon.AddPivots(figure, Color.Gainsboro);
            Mock.Assert(() => polygon.AddPivots(figure, Color.Gainsboro), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleSelectFigureTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            Pivots pivots = new Pivots(new Pen(Color.AliceBlue), new GraphicsPath());
            polygon.ScaleSelectFigure(figure, pivots, new int(), new int());
            Mock.Assert(() => polygon.ScaleSelectFigure(figure, pivots, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleFigureTest()
        {
            var polygon = Mock.Create<PolygonFigure>(() => new PolygonFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            polygon.ScaleFigure(e, figure, new List<Figure>());
            Mock.Assert(() => polygon.ScaleFigure(e, figure, new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
