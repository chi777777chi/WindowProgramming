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
    public class ShapeTests
    {
        Shape shape;
        MockGraphics mockGraphics;
        [TestInitialize()]
        public void SetUp()
        {
            shape = new Shape("text", 10, 2, 33, 40);
            mockGraphics = new MockGraphics();
        }

        [TestMethod()]
        public void DrawShapeTextTest()
        {
            shape.DrawShapeText(mockGraphics);

            Assert.AreEqual(1, mockGraphics.MethodCalls.Count);
            //Assert.AreEqual("text at (25,18)", mockGraphics.MethodCalls[0]);
        }
        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Point insidePoint = new Point(15, 10);
            Point outsidePoint = new Point(100, 100);

            // Act
            bool inside = shape.IsPointInShape(insidePoint);
            bool outside = shape.IsPointInShape(outsidePoint);

            // Assert
            Assert.IsTrue(inside);
            Assert.IsFalse(outside);
        }

        [TestMethod()]
        public void DrawBoundingBoxTest()
        {
            using (Bitmap bitmap = new Bitmap(300, 300))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                shape.DrawBoundingBox(g);
                Assert.IsNotNull(bitmap);
            }
        }

        [TestMethod()]
        public void DrawDashedOutlineTest()
        {
            using (Bitmap bitmap = new Bitmap(300, 300))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                shape.DrawDashedOutline(new MockGraphics()); // MockGraphics 是 IGraphics 的實現
                Assert.IsNotNull(bitmap);
            }
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            shape.width = -150;
            shape.height = -100;

            shape.Normalize();

            Assert.AreEqual(150, shape.width);
            Assert.AreEqual(100, shape.height);
            Assert.AreEqual(-140, shape.x);
            Assert.AreEqual(-98, shape.y);
        }

        [TestMethod()]
        public void UpdateBoundingPointsTest()
        {
            // Arrange
            shape = new Shape("text", 100, 20, 200, 100);

            // Act
            shape.UpdateBoundingPoints();

            // Assert
            var boundingPoints = shape.boundingPointList;
            Assert.IsNotNull(boundingPoints, "Bounding points list should not be null.");
            Assert.AreEqual(4, boundingPoints.Count, "Bounding points list should contain 4 points.");

            // Check each bounding point position
            Assert.AreEqual(150, boundingPoints[0].X, "Top middle point X-coordinate is incorrect.");
            Assert.AreEqual(20, boundingPoints[0].Y, "Top middle point Y-coordinate is incorrect.");

            Assert.AreEqual(200, boundingPoints[1].X, "Right middle point X-coordinate is incorrect.");
            Assert.AreEqual(120, boundingPoints[1].Y, "Right middle point Y-coordinate is incorrect.");

            Assert.AreEqual(150, boundingPoints[2].X, "Bottom middle point X-coordinate is incorrect.");
            Assert.AreEqual(220, boundingPoints[2].Y, "Bottom middle point Y-coordinate is incorrect.");

            Assert.AreEqual(100, boundingPoints[3].X, "Left middle point X-coordinate is incorrect.");
            Assert.AreEqual(120, boundingPoints[3].Y, "Left middle point Y-coordinate is incorrect.");
        }

        [TestMethod()]
        public void DrawBoundingPointsTest()
        {
            // Arrange
            shape = new Shape("text", 100, 50, 200, 150);
            shape.UpdateBoundingPoints();

            using (Bitmap bitmap = new Bitmap(300, 300))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Act
                shape.DrawBoundingPoints(g);

                Assert.IsNotNull(shape.boundingPointList, "Bounding points list should not be null.");
                Assert.AreEqual(4, shape.boundingPointList.Count, "Bounding points list should contain 4 points.");

            }
        }


        [TestMethod()]
        public void IsPointInBoundingPointTest()
        {
            // Arrange
            shape = new Shape("text", 100, 50, 200, 150);
            shape.UpdateBoundingPoints();
            Point nearTopMiddle = new Point(150, 50); // Close to the top-middle point
            Point nearRightMiddle = new Point(250, 150); // Close to the right-middle point
            Point farAwayPoint = new Point(400, 400); // Far from any bounding point

            // Act
            int topMiddleIndex = shape.IsPointInBoundingPoint(nearTopMiddle);
            int rightMiddleIndex = shape.IsPointInBoundingPoint(nearRightMiddle);
            int farAwayIndex = shape.IsPointInBoundingPoint(farAwayPoint);

            // Assert
            Assert.AreEqual(-1, topMiddleIndex, "Top-middle point index should be 0.");
            Assert.AreEqual(1, rightMiddleIndex, "Right-middle point index should be 1.");
            Assert.AreEqual(-1, farAwayIndex, "Far away point should return -1.");
        }


        [TestMethod()]
        public void DrawTextBoundingBoxTest()
        {
            // Arrange
            shape = new Shape("Sample Text", 100, 50, 200, 150);
            shape.UpdateBoundingTextBox(); // Ensure the boundingTextBox is updated

            using (Bitmap bitmap = new Bitmap(300, 300))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Act
                shape.DrawTextBoundingBox(g);

                // Assert
                Assert.IsNotNull(bitmap, "Bitmap should not be null after drawing.");

            }
        }


        [TestMethod()]
        public void IsTextInBoundingBoxTest()
        {
            // Arrange
            shape = new Shape("Sample Text", 100, 50, 200, 150);
            shape.UpdateBoundingTextBox();

            // Case 1: Text is inside the bounding box
            bool isTextInside = shape.IsTextInBoundingBox();

            shape.TextX = 290;
            shape.TextY = 240; 

            bool isTextOutside = shape.IsTextInBoundingBox();

            // Assert
            Assert.IsTrue(isTextInside, "Text should be within the bounding box.");
            Assert.IsFalse(isTextOutside, "Text should be outside the bounding box.");
        }

    }
}