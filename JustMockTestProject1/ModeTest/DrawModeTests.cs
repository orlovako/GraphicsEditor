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
using Modes;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для DrawModeTests
    /// </summary>
    [TestClass]
    public class DrawModeTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var drawMode = Mock.Create<Modes.DrawMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            drawMode.MouseDown(e, new int());
            Mock.Assert(() => drawMode.MouseDown(e, new int()));
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var drawMode = Mock.Create<Modes.DrawMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            Mock.Arrange(() => drawMode.MouseMove(e, new int(), new int())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var drawMode = Mock.Create<Modes.DrawMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            drawMode.MouseUp(e, new int(), new Color(), new int(), new DashStyle(), new Color(), new bool());
            Mock.Assert(() => drawMode.MouseUp(e, new int(), new Color(), new int(), new DashStyle(), new Color(), new bool()));
        }        
    }
}
