using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace HW2.Command.Tests
{
    [TestClass()]
    public class TextMoveCommandTests
    {
        Model model;
        Shape shape;
        Point newPosition;
        TextMoveCommand command;
        [TestInitialize()]
        public void SetUp()
        {
            model = new Model();
            shape = new Shape("TestShape", 50, 50, 100, 100);
            newPosition = new Point(200, 150);
            command = new TextMoveCommand(model, shape, newPosition);
        }
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Shape("SampleText", 50, 50, 100, 100);
            Point newPosition = new Point(200, 150);
            TextMoveCommand command = new TextMoveCommand(model, shape, newPosition);

            command.Execute();

            Assert.AreEqual(50, shape.TextX);
            Assert.AreEqual(50, shape.TextY);
        }


        [TestMethod()]
        public void UnExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Shape("SampleText", 50, 50, 100, 100);
            Point newPosition = new Point(200, 150);
            TextMoveCommand command = new TextMoveCommand(model, shape, newPosition);

            command.Execute();
            command.UnExecute();

            Assert.AreEqual(200, shape.TextX);
            Assert.AreEqual(150, shape.TextY);
        }

    }
}