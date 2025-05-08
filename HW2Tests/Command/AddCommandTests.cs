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
    public class AddCommandTests
    {
        Model model;
        AddCommand command;
        [TestInitialize()]
        public void SetUp()
        {
            model = new Model();
            //command = new AddCommand(model);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Decision decision = new Decision("text", 2, 3, 45, 6);
            Decision decision2 = new Decision("text2", 12, 13, 145, 16);
            command = new AddCommand(model, decision);
            model.shapes.AddShape(decision);
            model.shapes.AddShape(decision);
            model.shapesHistory.AddShape(decision); 
            model.shapesHistory.AddShape(decision);
            model.shapesHistory.AddShape(decision2);

            Assert.AreEqual(2, command.GetModel().shapes.GetShapeCount());
            Assert.AreEqual(3, command.GetModel().shapesHistory.GetShapeCount());

            model.shapes.DeleteShape(1);
            Assert.AreEqual(1, command.GetModel().shapes.GetShapeCount());
            command.Execute();

            Assert.AreEqual(2, command.GetModel().shapes.GetShapeCount());
            command.Execute();
            Assert.AreEqual(3, command.GetModel().shapes.GetShapeCount());
            Assert.AreEqual(145, command.GetModel().shapes.shapeList[2].height);
        }


        [TestMethod()]
        public void UnExecuteTest()
        {
            Decision decision = new Decision("text", 2, 3, 45, 6);
            model.shapes.AddShape(decision);
            AddCommand command = new AddCommand(model, decision);
            command.UnExecute();
            Assert.AreEqual(0, command.GetModel().shapes.shapeList.Count);
        }
    }
}