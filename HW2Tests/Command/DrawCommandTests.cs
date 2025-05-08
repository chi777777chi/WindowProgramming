using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.Command;
using System.Drawing;

namespace HW2.Command.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        private Model _model;
        private Decision _testShape;
        private DrawCommand _drawCommand;

        [TestInitialize]
        public void Setup()
        {
            // 初始化測試環境
            _model = new Model();
            _testShape = new Decision("TestText", 10, 20, 100, 50);
            _drawCommand = new DrawCommand(_model, _testShape);
        }



        [TestMethod()]
        public void UnExecute_ShouldRemoveShapeFromModel()
        {
            // Arrange
            _drawCommand.Execute();
            Assert.AreEqual(1, _model.shapes.GetShapeCount(), "Setup failed: Shape was not added.");

            // Act
            _drawCommand.UnExecute();

            // Assert
            Assert.AreEqual(0, _model.shapes.GetShapeCount(), "Shape count should be 0 after UnExecute.");
        }

        [TestMethod()]
        public void Execute_UnExecute_Execute_ShouldWorkCorrectly()
        {
            // Arrange & Act
            _drawCommand.Execute();
            _drawCommand.UnExecute();
            _drawCommand.Execute();

            // Assert
            Assert.AreEqual(1, _model.shapes.GetShapeCount(), "Shape count should be 1 after Execute -> UnExecute -> Execute.");
        }

        [TestMethod()]
        public void UnExecute_WithoutExecute_ShouldNotThrowException()
        {
            // Act & Assert

                _drawCommand.UnExecute();
                Assert.AreEqual(0, _model.shapes.GetShapeCount(), "Shape count should remain 0 after UnExecute without Execute.");
            

        }

        [TestMethod()]
        public void DrawCommandTest()
        {
            // Arrange
            var shape = new Process("SampleText", 50, 60, 100, 150);
            var drawCommand = new DrawCommand(_model, shape);

            // Act
            drawCommand.Execute();

            // Assert
            Assert.AreEqual(1, _model.shapes.GetShapeCount(), "Shape count should be 1 after Execute.");
            Assert.AreEqual(shape, _model.shapes.shapeList[0], "The shape in the model should match the executed shape.");

            // Undo the action
            drawCommand.UnExecute();

            // Assert
            Assert.AreEqual(0, _model.shapes.GetShapeCount(), "Shape count should be 0 after UnExecute.");
        }
        [TestMethod()]
        public void DrawLineCommandTest()
        {
            // Arrange
            var shape1 = new Start("StartText", 10, 10, 50, 50);
            var shape2 = new Terminator("EndText", 200, 200, 50, 50);
            var line = new Line(shape1, shape2, 0, 0);
            var drawLineCommand = new DrawCommand(_model, line);

            // Act
            drawLineCommand.Execute();

            // Assert
            Assert.AreEqual(1, _model.lineList.Count, "Line count should be 1 after Execute.");
            Assert.AreEqual(line, _model.lineList[0], "The line in the model should match the executed line.");

            // Undo the action
            drawLineCommand.UnExecute();

            // Assert
            Assert.AreEqual(0, _model.lineList.Count, "Line count should be 0 after UnExecute.");
        }

    }
}
