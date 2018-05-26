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
using SDK;
using System.IO;
using System.Windows.Forms;
using Basis;
using SelectionFigure;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для RectangleSelectionTests
    /// </summary>
    [TestClass]
    public class RectangleSelectionTests
    {
        [TestMethod]
        public void MouseDownTest()
        {
            var rectSelection = Mock.Create<RectangleSelection>(() => new RectangleSelection());            
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            rectSelection.MouseDown(e, new Rectangle(), new List<Figure>(), new List<ITypesFigures>(), new bool(), new List<Figure>());
            Mock.Assert(() => rectSelection.MouseDown(e, new Rectangle(), new List<Figure>(), new List<ITypesFigures>(), new bool(), new List<Figure>()), Occurs.AtLeastOnce());
        }
    }
}
