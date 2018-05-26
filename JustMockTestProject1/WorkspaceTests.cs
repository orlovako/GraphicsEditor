using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock;
using System.Threading.Tasks;
using DataFigure;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using TypesFigures;
using System.Windows.Forms;
using Basis;
using BaseActions;
using System.IO;
using BaseData;

namespace JustMockTestProject1
{
    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class WorkspaceTests
    {
        [TestMethod]
        public void DrawFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            Form form = new Form();
            Graphics g = form.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs e = new PaintEventArgs(g, rec);
            workspace.DrawFigure(e, new int(), new Color(), new int(), new DashStyle(), new Color());
            Mock.Assert(() => workspace.DrawFigure(e, new int(), new Color(), new int(), new DashStyle(), new Color()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseDownTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            workspace.MouseDown(e, new int(), new int());
            Mock.Assert(() => workspace.MouseDown(e, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            workspace.MouseMove(e, new int(), new int());
            Mock.Assert(() => workspace.MouseMove(e, new int(), new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void MouseUpTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, new int(), new int(), new int(), new int());
            workspace.MouseUp(e, new int(), new int(), new Color(), new int(), new DashStyle(), new Color(), new bool());
            Mock.Assert(() => workspace.MouseUp(e, new int(), new int(), new Color(), new int(), new DashStyle(), new Color(), new bool()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RefreshBitmapTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.RefreshBitmap();
            Mock.Assert(() => workspace.RefreshBitmap(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void DeletePivotsTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.DeletePivots();
            Mock.Assert(() => workspace.DeletePivots(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СopyFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.СopyFigure();
            Mock.Assert(() => workspace.СopyFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void CutFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.CutFigure();
            Mock.Assert(() => workspace.CutFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void InsertFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.InsertFigure();
            Mock.Assert(() => workspace.InsertFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void DeleteSelectFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.DeleteSelectFigure();
            Mock.Assert(() => workspace.DeleteSelectFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangeFilledTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.СhangeFilled(new Color());
            Mock.Assert(() => workspace.СhangeFilled(new Color()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void DeleteFilledTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.DeleteFilled();
            Mock.Assert(() => workspace.DeleteFilled(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangePenStyleTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.СhangePenStyleFigure(new DashStyle());
            Mock.Assert(() => workspace.СhangePenStyleFigure(new DashStyle()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void СhangePenWidthTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.СhangePenWidthFigure(new int());
            Mock.Assert(() => workspace.СhangePenWidthFigure(new int()), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void UndoFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.UndoFigure();
            Mock.Assert(() => workspace.UndoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RedoFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.RedoFigure();
            Mock.Assert(() => workspace.RedoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void SaveProjectTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            PictureBox picture = new PictureBox();
            Mock.Arrange(() => workspace.SaveProject()).Returns(picture);
        }

        [TestMethod]
        public void SelectFigureTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            Mock.Arrange(() => workspace.SelectFigure()).Returns(new bool());
        }

        [TestMethod]
        public void ReturnListActionsTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            Mock.Arrange(() => workspace.ReturnListActions()).Returns(new List<IBaseActions>());
        }

        /*[TestMethod]
        public void ReturnSaveProjectTest()
        {
            var workspace = Mock.Create<Workspace>(Constructor.Mocked);
            workspace.ReturnSaveProject();
            Mock.Assert(() => workspace.ReturnSaveProject(), Occurs.AtLeastOnce());
        }*/
    }
}
