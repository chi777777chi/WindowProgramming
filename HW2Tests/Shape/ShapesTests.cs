using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes shapes;
        [TestInitialize()]
        public void SetUp() 
        {
            shapes = new Shapes();        
        }
        [TestMethod()]
        public void AddShapeTest()
        {
            Shape shape = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 9, 8, 7);
            Shape shape3 = new Shape("text", 18, 20, 3, 5);
            shapes.AddShape(shape);
            shapes.AddShape(shape2);
            Assert.AreEqual(shapes.shapeList.Count, 2);
            Assert.AreEqual(shapes.shapeList[0].x, 1); 
            Assert.AreEqual(shapes.shapeList[0].width, 4);
            Assert.AreEqual(shapes.shapeList[1].y, 9);
            Assert.AreEqual(shapes.shapeList[1].height, 8);
            shapes.AddShape(shape3);
            Assert.AreEqual(shapes.shapeList.Count, 3);
            Assert.AreEqual(shapes.shapeList[0].width, 4);
            Assert.AreEqual(shapes.shapeList[1].y, 9);
            Assert.AreEqual(shapes.shapeList[2].x, 18);
            Assert.AreEqual(shapes.shapeList[2].height, 3);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            Shape shape = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 9, 8, 7);
            Shape shape3 = new Shape("text", 18, 20, 3, 5);
            shapes.AddShape(shape);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
            
            Assert.AreEqual(shapes.shapeList.Count, 3);
            shapes.DeleteShape(1);
            Assert.AreEqual(shapes.shapeList.Count, 2);
            Assert.AreEqual(shapes.shapeList[0].x, 1);
            Assert.AreEqual(shapes.shapeList[1].x, 18);
            Assert.AreEqual(shapes.shapeList[1].y, 20);
            Assert.AreEqual(shapes.shapeList[1].height, 3);
            Assert.AreEqual(shapes.shapeList[1].width, 5);
            //shapes
        }

        [TestMethod()]
        public void GetShapeByIndexTest()
        {
            Shape shape = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 9, 8, 7);
            Shape shape3 = new Shape("text", 18, 20, 3, 5);
            shapes.AddShape(shape);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
            shapes.AddShape(shape);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
            Assert.AreEqual(shapes.shapeList.Count, 6);
            Assert.AreEqual(shapes.GetShapeByIndex(0).x, 1);
            Assert.AreEqual(shapes.GetShapeByIndex(4).x, 10);
        }

        [TestMethod()]
        public void GetShapeCountTest()
        {
            Shape shape = new Shape("text", 1, 2, 3, 4);
            Shape shape2 = new Shape("text", 10, 9, 8, 7);
            Shape shape3 = new Shape("text", 18, 20, 3, 5);
            shapes.AddShape(shape);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
            
            Assert.AreEqual(shapes.GetShapeCount(), 3);
        }
    }
}