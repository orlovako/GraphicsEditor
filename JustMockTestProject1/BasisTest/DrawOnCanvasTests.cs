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
    /// Сводное описание для DrawOnCanvasTests
    /// </summary>
    [TestClass]
    public class DrawOnCanvasTests
    {
        [TestMethod]
        public void PaintTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            Form form = new Form();
            Graphics g = form.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs e = new PaintEventArgs(g, rec);
            drawOnCanvas.Paint(e, new int(), new List<PointF>(), new List<IDrawFigures>(), new Color(), new int(), new DashStyle());
            Mock.Assert(() => drawOnCanvas.Paint(e, new int(), new List<PointF>(), new List<IDrawFigures>(), new Color(), new int(), new DashStyle()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            drawOnCanvas.MouseUp(new int(), new List<PointF>(), e, new Color(), new int(), new DashStyle(), new Color(), new bool());
            Mock.Assert(() => drawOnCanvas.MouseUp(new int(), new List<PointF>(), e, new Color(), new int(), new DashStyle(), new Color(), new bool()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RefreshBitmapTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);           
            drawOnCanvas.RefreshBitmap();
            Mock.Assert(() => drawOnCanvas.RefreshBitmap(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void PivotsTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            drawOnCanvas.Pivots(new List<Figure>(), new List<ITypesFigures>(), new Color());
            Mock.Assert(() => drawOnCanvas.Pivots(new List<Figure>(), new List<ITypesFigures>(), new Color()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void SaveProjectTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            var pictureBox = new PictureBox();
            drawOnCanvas.SaveProject(pictureBox);
            Mock.Assert(() => drawOnCanvas.SaveProject(pictureBox), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ClearProjectTest()
        {
            var action = new Actions();
            var pictureBox = new PictureBox();
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            drawOnCanvas.ClearProject(pictureBox);
            Mock.Assert(() => drawOnCanvas.ClearProject(pictureBox), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            drawOnCanvas.UndoFigure();
            Mock.Assert(() => drawOnCanvas.UndoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RedoTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            drawOnCanvas.RedoFigure();
            Mock.Assert(() => drawOnCanvas.RedoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ListIBaseActionsTest()
        {
            var action = new Actions();
            var listActions = new List<IBaseActions>();
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            Mock.Arrange(() => drawOnCanvas.ListIBaseActions).Returns(listActions);
        }

        [TestMethod]
        public void FiguresListTest()
        {            
            var list = new List<Figure>();
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            Mock.Arrange(() => drawOnCanvas.FiguresList).Returns(list);
        }

        [TestMethod]
        public void IndexCommandTest()
        {
            var drawOnCanvas = Mock.Create<DrawOnCanvas>(Constructor.Mocked);
            Mock.Arrange(() => drawOnCanvas.NumberAction).Returns(new int());
        }
    }
}
