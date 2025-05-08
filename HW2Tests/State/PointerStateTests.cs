using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HW2.State.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        Model model;
        PointerState pointerState;
        MockPoint point1;
        MockPoint point2;
        MockPoint point3;
        Shape shape;
        MockGraphics mockGraphics;
        [TestInitialize()]
        public void SetUp()
        {
            model = new Model();
            model.EnterPointerState();
            pointerState = new PointerState();
            mockGraphics = new MockGraphics();
            shape = new Shape("text", 10,1,2,3);
        }
        [TestMethod()]
        public void InitializeTest()
        {
            pointerState.Initialize(model);
            Assert.IsFalse(pointerState.shapeCanMove);
            Assert.IsFalse(pointerState.start_pressed);
        }

        [TestMethod()]
        public void AddSelectedShapeTest()
        {
            Shape shape  = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 20, 30, 40);
            Shape shape3 = new Shape("text", 100, 200, 300, 400);
            pointerState.AddSelectedShape(shape);
            pointerState.AddSelectedShape(shape2);
            pointerState.AddSelectedShape(shape3);
            Shapes shapes = pointerState.GetSelectedShape();
            Assert.AreEqual(shapes.shapeList[0].width, 4);
            Assert.AreEqual(shapes.shapeList[2].y, 200);
            Assert.AreEqual(shapes.shapeList[0].x, 1);
            Assert.AreEqual(shapes.shapeList[1].height, 30);
            //Assert.Fail();
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            Shape shape = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 20, 30, 40);
            Shape shape3 = new Shape("text", 100, 200, 300, 400);
            point1 = new MockPoint(2, 2);
            point2 = new MockPoint(22, 22);
            model.shapes.AddShape(shape);
            pointerState.MouseDown(model, point1);
            Assert.IsTrue(pointerState.start_pressed);
            model.shapes.AddShape(shape2);
            pointerState.MouseDown(model, point2);
            Assert.IsTrue(pointerState.start_pressed);
            //Assert.Fail();
        }

        [TestMethod()]
        public void MouseMoveTest()
        {

            Shape shape = new Shape("text", 10, 10, 20, 20); 
            model.shapes.AddShape(shape);

            point1 = new MockPoint(15, 15); // Inside the shape
            pointerState.MouseDown(model, point1);

            point2 = new MockPoint(30, 30); 
            pointerState.MouseMove(model, point2);

            Assert.AreEqual(10, shape.x); 
            Assert.AreEqual(10, shape.y); 
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            Shape shape = new Shape("text", 10, 10, 20, 20); // A shape at (10, 10) with width=20, height=20
            model.shapes.AddShape(shape);
            MockPoint startPoint = new MockPoint(15, 15); // Point inside the shape
            MockPoint movePoint = new MockPoint(30, 30); // Point to drag the shape to


            pointerState.MouseDown(model, startPoint);
            pointerState.MouseMove(model, movePoint);
            pointerState.MouseUp(model, movePoint);

            // Assert
            Assert.IsFalse(pointerState.start_pressed, "start_pressed should be false after MouseUp.");
            Assert.IsFalse(pointerState.shapeCanMove, "shapeCanMove should be false after MouseUp.");
            
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            // Arrange
            SetUp();
            Shape shape1 = new Shape("text1", 10, 10, 50, 50);
            Shape shape2 = new Shape("text2", 70, 70, 30, 30);
            model.shapes.AddShape(shape1);
            model.shapes.AddShape(shape2);

            pointerState.AddSelectedShape(shape1);

            Bitmap bitmap = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Act
                pointerState.OnPaint(model, g);

                Assert.AreEqual(2, model.shapes.shapeList.Count, "Shapes list should contain two shapes.");
                Assert.AreEqual(shape1, pointerState.GetSelectedShape().shapeList[0], "Selected shape should be shape1.");

               
            }
        }



    }
}