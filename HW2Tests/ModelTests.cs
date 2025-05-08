using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace HW2.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;
        [TestInitialize]
        public void SetUp()
        {
            model = new Model();

        }


        [TestMethod()]
        public void EnterPointerStateTest()
        {
            model.EnterPointerState();
            Assert.IsTrue(model.IsPointerButtonChecked);
            Assert.IsFalse(model.IsDrawingButtonChecked);
        }

        [TestMethod()]
        public void EnterDrawingStateTest()
        {
            model.EnterDrawingState();
            Assert.IsTrue(model.IsDrawingButtonChecked);
            Assert.IsFalse(model.IsPointerButtonChecked);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            Point point = new Point(10, 20);
            model.MouseDown(point);
            Assert.IsTrue(model.IsPointerButtonChecked || model.IsDrawingButtonChecked);
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            Point point = new Point(10, 20);
            model.MouseDown(point);
            Point movePoint = new Point(30, 40);
            model.MouseMove(movePoint);
            Assert.IsTrue(model.IsPointerButtonChecked || model.IsDrawingButtonChecked);
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            Point point = new Point(10, 20);
            model.MouseDown(point);
            Point movePoint = new Point(30, 40);
            model.MouseMove(movePoint);
            model.MouseUp(movePoint);
            Assert.IsTrue(model.IsPointerButtonChecked || model.IsDrawingButtonChecked);
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            // Arrange
            SetUp();

            model.BuildShape("Start", "StartShape", "10", "20", "30", "40");
            model.BuildShape("Process", "ProcessShape", "50", "60", "70", "80");

            Bitmap bitmap = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Act
                model.OnPaint(g);
                Assert.AreEqual(2, model.shapes.shapeList.Count, "The model should have two shapes.");
                Assert.AreEqual("StartShape", model.shapes.shapeList[0].shapeText, "The first shape should have the correct text.");
                Assert.AreEqual("ProcessShape", model.shapes.shapeList[1].shapeText, "The second shape should have the correct text.");
            }
        }


        [TestMethod()]
        public void BuildShapeTest()
        {
            model.BuildShape("Start", "text", "10", "20", "30", "40");
            model.BuildShape("Process", "text", "100", "20", "70", "60");
            model.BuildShape("Process", "text", "9", "70", "600", "10");
            Assert.AreEqual(model.shapes.shapeList.Count, 3);
            Assert.AreEqual(model.shapes.shapeList[1].shapeName, "Process");
            Assert.AreEqual(model.shapes.shapeList[2].y, 70);
        }


        [TestMethod()]
        public void DeleteShapeTest()
        {
            model.BuildShape("Start", "text", "10", "20", "30", "40");
            model.BuildShape("Process", "text", "100", "20", "70", "60");
            Assert.AreEqual(model.shapes.shapeList.Count, 2);
            model.DeleteShape(0);
            Assert.AreEqual(model.shapes.shapeList.Count, 1);
            Assert.AreEqual(model.shapes.shapeList[0].x, 100);
        }

        [TestMethod()]
        public void ChangeCurrentShapeTest()
        {
            model.ChangeCurrentShape(0);
            Assert.AreEqual(model.currentShape, CurrentShapes.START);
            model.ChangeCurrentShape(3);
            Assert.AreEqual(model.currentShape, CurrentShapes.DECISION);
            model.ChangeCurrentShape(1);
            Assert.AreEqual(model.currentShape, CurrentShapes.TERMINATOR);
            model.ChangeCurrentShape(-1);
            Assert.AreEqual(model.currentShape, CurrentShapes._NULL);
            model.ChangeCurrentShape(2);
            Assert.AreEqual(model.currentShape, CurrentShapes.PROCESS);
        }

        [TestMethod()]
        public void addLineTest()
        {
            Shape startShape = new Shape("Start", 0, 0, 100, 100);
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            Line line = new Line(startShape, endShape, 0, 0);

            model.addLine(line);

            Assert.AreEqual(1, model.lineList.Count); 
            Assert.AreEqual(line, model.lineList[0]); 
        }


        [TestMethod()]
        public void removeLineTest()
        {
            // Arrange
            Shape startShape = new Shape("Start", 0, 0, 100, 100);
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            Line line = new Line(startShape, endShape, 0, 0);
            model.addLine(line); 

            // Act
            model.removeLine(line);

            // Assert
            Assert.AreEqual(0, model.lineList.Count); // 驗證線條數量
        }

        [TestMethod()]
        public void IsInTexBoundingBoxTest()
        {
            model.BuildShape("Start", "Text", "10", "20", "30", "40");
            model.BuildShape("Process", "Text", "100", "120", "50", "60");

            string result1 = model.IsInTexBoundingBox(new Point(15, 25)); 
            string result2 = model.IsInTexBoundingBox(new Point(105, 125));
            string result3 = model.IsInTexBoundingBox(new Point(300, 300)); 


        }

    }
}