using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HW2.Mock;

namespace HW2.Command.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        private CommandManager commandManager;
        private MockCommand command;

        [TestInitialize]
        public void Setup()
        {
            commandManager = new CommandManager();
            command = new MockCommand();
        }
        [TestMethod()]
        public void ExecuteTest()
        {
            commandManager.Execute(command);

            commandManager.Undo();

            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.AreEqual("UnExecuted", command.State);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.ThrowsException<Exception>(() => commandManager.Undo());
            commandManager.Execute(command);
            commandManager.Undo();

            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.AreEqual("UnExecuted", command.State);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.ThrowsException<Exception>(() => commandManager.Redo());
            commandManager.Execute(command);
            commandManager.Undo();
            commandManager.Redo();

            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.AreEqual("Executed", command.State);
        }
    }
}