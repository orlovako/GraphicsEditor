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
    /// Сводное описание для RectangleLTRBTests
    /// </summary>
    [TestClass]
    public class RectangleLTRBTests
    {
        [TestMethod]
        public void ShowRectangleTest()
        {
            var rect = Mock.Create<RectangleLTRB>(() => new RectangleLTRB());
            //rect.ShowRectangle(new PointF(), new PointF());
            Mock.Arrange(() => rect.ShowRectangle(new PointF(), new PointF())).Returns(new Rectangle());
        }

        [TestMethod]
        public void SelectFigureTest()
        {
            var rect = Mock.Create<RectangleLTRB>(() => new RectangleLTRB());
            Mock.Arrange(() => rect.SelectFigure(new PointF(), new float())).Returns(new Rectangle());
        }
    }
}
