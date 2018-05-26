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
    /// Сводное описание для EllipseTests
    /// </summary>
    [TestClass]
    public class EllipseTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            ellipse.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>());
            Mock.Assert(() => ellipse.MouseDown(new List<PointF>(), e, new int(), new List<ITypesFigures>()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            ellipse.MouseMove(new List<PointF>(), e);
            Mock.Assert(() => ellipse.MouseMove(new List<PointF>(), e), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            ellipse.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>());
            Mock.Arrange(() => ellipse.MouseUp(new List<PointF>(), new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int()), new int(), new List<ITypesFigures>())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void AddSupportPointTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            ellipse.AddPivots(figure, Color.Gainsboro);
            Mock.Assert(() => ellipse.AddPivots(figure, Color.Gainsboro), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleSelectFigureTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            Pivots pivots = new Pivots(new Pen(Color.AliceBlue), new GraphicsPath());
            ellipse.ScaleSelectFigure(figure, pivots, new int(), new int());
            Mock.Assert(() => ellipse.ScaleSelectFigure(figure, pivots, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ScaleFigureTest()
        {
            var ellipse = Mock.Create<EllipseFigure>(() => new EllipseFigure());
            Figure figure = new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            ellipse.ScaleFigure(e, figure, new List<Figure>());
            Mock.Assert(() => ellipse.ScaleFigure(e, figure, new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
