using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace HW2.State.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        private PointerState pointerState;
        private DrawingState drawingState;
        private Model model;

        public void SetUp()
        {
            // Initialize PointerState
            pointerState = new PointerState();

            // Initialize DrawingState with PointerState
            drawingState = new DrawingState(pointerState);

            // Create a new Model
            model = new Model();
            model.currentShape = CurrentShapes.PROCESS; // Default shape for tests
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            SetUp();
            var startPoint = new Point(10, 10);

            // Act
            drawingState.MouseDown(model, startPoint);

            // Assert
            Assert.IsTrue(drawingState.start_pressed);
            Assert.IsNotNull(drawingState.hintShape);
            Assert.AreEqual(10, drawingState.hintShape.x);
            Assert.AreEqual(10, drawingState.hintShape.y);

            model.currentShape = CurrentShapes.DECISION;
            drawingState.MouseDown(model, startPoint);
            model.currentShape = CurrentShapes.START;
            drawingState.MouseDown(model, startPoint);
            model.currentShape = CurrentShapes.TERMINATOR;
            drawingState.MouseDown(model, startPoint);
            model.currentShape = CurrentShapes._NULL;
            drawingState.MouseDown(model, startPoint);
            // Assert


        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            SetUp();
            var startPoint = new Point(10, 10);
            var movePoint = new Point(50, 60);

            drawingState.MouseDown(model, startPoint);

            // Act
            drawingState.MouseMove(model, movePoint);

            // Assert
            Assert.IsNotNull(drawingState.hintShape);
            Assert.AreEqual(40, drawingState.hintShape.width);
            Assert.AreEqual(50, drawingState.hintShape.height);
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            SetUp();
            var startPoint = new Point(10, 10);
            var endPoint = new Point(50, 60);

            drawingState.MouseDown(model, startPoint);

            // Act
            drawingState.MouseMove(model, endPoint);
            drawingState.MouseUp(model, endPoint);

            // Assert
            Assert.IsFalse(drawingState.start_pressed);
            Assert.AreEqual(1, model.shapes.shapeList.Count);
            Assert.AreEqual(40, model.shapes.shapeList[0].width);
            Assert.AreEqual(50, model.shapes.shapeList[0].height);
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            // Arrange
            SetUp();
            var startPoint = new Point(10, 10);
            var endPoint = new Point(50, 60);

            // Simulate mouse operations to create a shape
            drawingState.MouseDown(model, startPoint);
            drawingState.MouseMove(model, endPoint);

            // Create a mock graphics object
            Bitmap bitmap = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Act
                drawingState.OnPaint(model, g);

                Assert.IsNotNull(drawingState.hintShape); 
                Assert.AreEqual(40, drawingState.hintShape.width);
                Assert.AreEqual(50, drawingState.hintShape.height);
            }
        }
    }
}