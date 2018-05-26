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
    /// Сводное описание для EditDataTests
    /// </summary>
    [TestClass]
    public class EditDataTests
    {
        [TestMethod]
        public void ReplicationFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var copyFig = new CopyFigure(new List<Figure>(), new List<Figure>());
            editData.CopyFigures(new List<Figure>(), copyFig);
            Mock.Assert(() => editData.CopyFigures(new List<Figure>(), copyFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void CutFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var cutFig = new CutFigure(new List<Figure>(), new List<Figure>());
            editData.CutFigure(new List<Figure>(), cutFig);
            Mock.Assert(() => editData.CutFigure(new List<Figure>(), cutFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void InsertFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var insertFig = new InsertFigure(new List<Figure>(), new List<Figure>());
            editData.InsertFigure(new List<Figure>(), insertFig);
            Mock.Assert(() => editData.InsertFigure(new List<Figure>(), insertFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void DeleteFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new DeleteFigure(new List<Figure>(), new List<Figure>());
            editData.DeleteFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.DeleteFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void DeleteFillingFigureFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new DeleteFilling(new List<Figure>());
            editData.DeleteFillingFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.DeleteFillingFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangeBackgroundFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new EditFilling(new List<Figure>(), new Color());
            editData.СhangeBackgroundFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.СhangeBackgroundFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangePenColorFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new СhangePenColor(new List<Figure>(), new Color());
            editData.СhangePenColorFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.СhangePenColorFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangeMoveFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new MoveFigure(new List<Figure>());            
            editData.СhangeMoveFigure(new List<Figure>(), "", deleteFig);
            Mock.Assert(() => editData.СhangeMoveFigure(new List<Figure>(), "", deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangePenWidthFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new СhangePenThickness(new List<Figure>(), new int());
            editData.СhangePenWidthFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.СhangePenWidthFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangePenStyleFigureTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new СhangePenStyle(new List<Figure>(), new DashStyle());
            editData.СhangePenStyleFigure(new List<Figure>(), deleteFig);
            Mock.Assert(() => editData.СhangePenStyleFigure(new List<Figure>(), deleteFig), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void ClearTest()
        {
            var editData = Mock.Create<EditData>(Constructor.Mocked);
            var deleteFig = new ClearCanva(new List<Figure>(), new List<Figure>());
            editData.Clear(deleteFig);
            Mock.Assert(() => editData.Clear(deleteFig), Occurs.AtLeastOnce());
        }
    }
}
