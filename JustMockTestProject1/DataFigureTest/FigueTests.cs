using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFigure;
using Telerik.JustMock;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using TypesFigures;
using System.Windows.Forms;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для FigueTests
    /// </summary>
    [TestClass]
    public class FigueTests
    {
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        public void IdFigureTest(int n)
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Arrange(() => figure.IdFigure).Returns(n);
        }

        [TestMethod]
        public void GraphicsPathTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Arrange(() => figure.Path).Returns(new GraphicsPath());
        }

        [TestMethod]
        public void AddListFigureTest()
        {
            Pen examplePen = new Pen(Color.AliceBlue);
            GraphicsPath grPath = new GraphicsPath();
            var figure = Mock.Create<Figure>(() => new Figure(examplePen, grPath, Color.Bisque, 1, false));
            Pivots sp = new Pivots(examplePen, grPath);
            figure.AddPivots(sp);
            Mock.Assert(() => figure.AddPivots(sp), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void EditPivotsTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, true));
            figure.EditPivots(new int(), new Rectangle());
            Mock.Assert(() => figure.EditPivots(new int(), new Rectangle()), Occurs.AtLeastOnce());

        }

        [TestMethod]
        public void ClearListPivotsTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            figure.ClearListPivots();
            Mock.Assert(() => figure.ClearListPivots(), Occurs.AtLeastOnce());
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        public void CurrentFigureTest(int n)
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Arrange(() => figure.CurrentFigure).Returns(n);
        }

        [TestMethod]
        public void PointSelectTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            PointF[] points = { new PointF(100, 50), new PointF(50, 100) };
            Mock.Arrange(() => figure.PointSelect).Returns(points);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectFigureTest(bool b)
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Arrange(() => figure.SelectFigure).Returns(b);
        }

        [TestCase(20, 40)]
        [TestCase(40.5F, 20.5F)]
        [TestCase(70.2F, 40)]
        public void PointStartTest(float x, float y)
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            PointF point = new PointF(x, y);
            Mock.Arrange(() => figure.PointStart).Returns(point);
        }

        [TestCase(30, 80)]
        [TestCase(50.5F, 30.5F)]
        [TestCase(80.2F, 20)]
        public void PointEndTest(float x, float y)
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            PointF point = new PointF(x, y);
            Mock.Arrange(() => figure.PointEnd).Returns(point);
        }

        [TestMethod]
        public void BrushTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Assert(() => figure.Brush, Occurs.Never());
        }

        [TestMethod]
        public void FillTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Assert(() => figure.Fill, Occurs.Never());
        }

        [TestMethod]
        public void PenTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            Mock.Arrange(() => figure.Pen).Returns(new Pen(Color.Aqua));
        }

        [TestMethod]
        public void CloneFigureTest()
        {
            var figure = Mock.Create<Figure>(() => new Figure(new Pen(Color.AliceBlue), new GraphicsPath(), Color.Bisque, 1, false));
            GraphicsPath grPath = new GraphicsPath();
            Mock.Arrange(() => figure.CloneFigure()).Returns(new Figure(new Pen(Color.Aqua), grPath.Clone() as GraphicsPath, Color.Bisque, 0, false));
        }
    }
}
