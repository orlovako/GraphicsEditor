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
    /// Сводное описание для ActionsTests
    /// </summary>
    [TestClass]
    public class ActionsTests
    {
        [TestMethod]
        public void UndoTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());
            actions.UndoFigure();
            Mock.Assert(() => actions.UndoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void RedoTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());
            actions.RedoFigure();
            Mock.Assert(() => actions.RedoFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void EditFigureTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());
            actions.EditFigure();
            Mock.Assert(() => actions.EditFigure(), Occurs.AtLeastOnce());
        }

        [TestMethod]
        public void BaseActionsListTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());            
            Mock.Arrange(() => actions.BaseActionsList).Returns(new List<IBaseActions>());
        }

        [TestMethod]
        public void ActionNumberTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());
            Mock.Arrange(() => actions.ActionNumber).Returns(new int());
        }

        [TestMethod]
        public void AddActionTest()
        {
            var actions = Mock.Create<Actions>(() => new Actions());
            actions.AddAction(new List<IBaseActions>());
            Mock.Assert(() => actions.AddAction(new List<IBaseActions>()), Occurs.AtLeastOnce());
        }
    }
}
