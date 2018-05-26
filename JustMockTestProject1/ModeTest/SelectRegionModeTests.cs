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
    /// Сводное описание для SelectRegionModeTests
    /// </summary>
    [TestClass]
    public class SelectRegionModeTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var selection = Mock.Create<Modes.SelectRegionMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            selection.MouseDown(e, new int());
            Mock.Assert(() => selection.MouseDown(e, new int()));
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var selection = Mock.Create<Modes.SelectRegionMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            Mock.Arrange(() => selection.MouseMove(e, new int(), new int())).Returns(new List<PointF>());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var selection = Mock.Create<Modes.SelectRegionMode>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            selection.MouseUp(e, new int(), new Color(), new int(), new DashStyle(), new Color(), new bool());
            Mock.Assert(() => selection.MouseUp(e, new int(), new Color(), new int(), new DashStyle(), new Color(), new bool()));
        }
    }
}
