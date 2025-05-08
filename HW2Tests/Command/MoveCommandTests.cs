using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.Command;
using HW2;
using System.Drawing;

namespace HW2.Command.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        private Model model;
        private MoveCommand moveCommand;
        private Shape shape;

        [TestInitialize()]
        public void SetUp()
        {
            model = new Model();
            shape = new Shape("TestShape", 50, 50, 100, 100); 
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            // Arrange
            Point oldPosition = new Point(200, 200); 
            moveCommand = new MoveCommand(model, shape, oldPosition);

            // Act
            moveCommand.Execute();

            // Assert
            Assert.AreEqual(50, shape.x);
            Assert.AreEqual(50, shape.y);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            // Arrange
            Point newPosition = new Point(shape.x, shape.y); 
            Point originalPosition = new Point(200, 200);
            moveCommand = new MoveCommand(model, shape, newPosition);

            // Act
            moveCommand.Execute(); // 先移動到新位置
            moveCommand.UnExecute(); // 再撤銷

            // Assert
            Assert.AreEqual(newPosition.X, shape.x);
            Assert.AreEqual(newPosition.Y, shape.y);
        }
    }
}
