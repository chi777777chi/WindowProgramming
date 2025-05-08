using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Command.Tests
{
    [TestClass()]
    public class TextChangedCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Shape("OldText", 50, 50, 100, 100);
            TextChangedCommand command = new TextChangedCommand(model, shape, "NewText");

            command.Execute();

            Assert.AreEqual("NewText", shape.shapeText, "Text after Execute is incorrect.");
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Shape("OldText", 50, 50, 100, 100);
            TextChangedCommand command = new TextChangedCommand(model, shape, "NewText");

            command.Execute();
            command.UnExecute();

            Assert.AreEqual("OldText", shape.shapeText, "Text after UnExecute is incorrect.");
        }

    }
}