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

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для DrawShapesTests
    /// </summary>
    [TestClass]
    public class DrawShapesTests
    {
        [TestMethod]
        public void PaintTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            Form form = new Form();
            Graphics g = form.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs e = new PaintEventArgs(g, rec);
            drawShapes.Paint(e, new int(), new List<PointF>(), new List<IDrawFigures>(), new Color(), new int(), new DashStyle());
            Mock.Assert(() => drawShapes.Paint(e, new int(), new List<PointF>(), new List<IDrawFigures>(), new Color(), new int(), new DashStyle()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            drawShapes.SaveGraphicsPath(new int(), new List<PointF>(), e, new Color(), new int(), new DashStyle(), new Color(), new bool());
            Mock.Assert(() => drawShapes.SaveGraphicsPath(new int(), new List<PointF>(), e, new Color(), new int(), new DashStyle(), new Color(), new bool()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RefreshBitmapTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            drawShapes.RefreshBitmap();
            Mock.Assert(() => drawShapes.RefreshBitmap(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void IndexCommandTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            Random rnd = new Random();
            int i = rnd.Next(500,600);
            int j = rnd.Next(500, 600);
            Bitmap bitmap = new Bitmap(i, j);
            Mock.Arrange(() => drawShapes.BitmapReturn()).Returns(bitmap);
        }

        [TestMethod]
        public void SaveProjectTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            drawShapes.ImportImage();
            Mock.Assert(() => drawShapes.ImportImage(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void FiguresListTest()
        {
            var drawShapes = Mock.Create<DrawShapes>(Constructor.Mocked);
            var list = new List<Figure>();
            Mock.Arrange(() => drawShapes.FiguresList).Returns(list);
        }

    }
}
