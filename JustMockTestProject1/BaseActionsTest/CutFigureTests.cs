﻿using System;
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
using System.Text;
using System.Collections.Generic;

namespace JustMockTestProject1
{
    /// <summary>
    /// Сводное описание для CutFigureTests
    /// </summary>
    [TestClass]
    public class CutFigureTests
    {      

        [TestMethod]
        public void RedoTest()
        {
            var cutFigure = Mock.Create<CutFigure>(() => new CutFigure(new List<Figure>(), new List<Figure>()));
            cutFigure.Redo();
            Mock.Assert(() => cutFigure.Redo(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ReturnSelectedFigureListTest()
        {
            var cutFigure = Mock.Create<CutFigure>(() => new CutFigure(new List<Figure>(), new List<Figure>()));
            cutFigure.ReturnSelectedFigureList();
            Mock.Arrange(() => cutFigure.ReturnSelectedFigureList()).Returns(new List<Figure>());
        }

        [TestMethod]
        public void UndoTest()
        {
            var cutFigure = Mock.Create<CutFigure>(() => new CutFigure(new List<Figure>(), new List<Figure>()));
            cutFigure.Undo();
            Mock.Assert(() => cutFigure.Undo(), Occurs.AtLeastOnce());
        }

        [TestCase("Aded Rectangle")]
        [TestCase("Aded Line")]
        [TestCase("Aded Polyline")]
        public void OperationTest(string s)
        {
            var cutFigure = Mock.Create<CutFigure>(() => new CutFigure(new List<Figure>(), new List<Figure>()));
            Mock.Arrange(() => cutFigure.Operation()).Returns(s);
        }

    }
}
