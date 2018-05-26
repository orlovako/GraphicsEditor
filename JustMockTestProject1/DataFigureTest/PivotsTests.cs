using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Сводное описание для PivotsTests
    /// </summary>
    [TestClass]
    public class PivotsTests
    {
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        public void IdFigureTest(int n)
        {
            var pivots = Mock.Create<Pivots>(() => new Pivots(new Pen(Color.AliceBlue), new GraphicsPath()));
            Mock.Arrange(() => pivots.IdFigure).Returns(n);
        }

        [TestMethod]
        public void GraphicsPathTest()
        {
            var pivots = Mock.Create<Pivots>(() => new Pivots(new Pen(Color.AliceBlue), new GraphicsPath()));
            Mock.Arrange(() => pivots.Path).Returns(new GraphicsPath());
        }

        [TestMethod]
        public void ControlPointFTest()
        {
            var pivots = Mock.Create<Pivots>(() => new Pivots(new Pen(Color.AliceBlue), new GraphicsPath()));
            Mock.Assert(() => pivots.ControlPointF, Occurs.Never());
        }

        [TestMethod]
        public void PenTest()
        {
            var pivots = Mock.Create<Pivots>(() => new Pivots(new Pen(Color.AliceBlue), new GraphicsPath()));
            Mock.Arrange(() => pivots.Pen).Returns(new Pen(Color.Aqua));
        }

        [TestMethod]
        public void CloneTest()
        {
            var pivots = Mock.Create<Pivots>(() => new Pivots(new Pen(Color.AliceBlue), new GraphicsPath()));
            GraphicsPath grPath = new GraphicsPath();
            Mock.Arrange(() => pivots.Clone()).Returns(new Pivots(new Pen(Color.Aqua), grPath.Clone() as GraphicsPath));
        }
    }
}
