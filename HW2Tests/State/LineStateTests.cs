using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2.State;
using System.Drawing;
using System.Linq;

namespace HW2.Tests
{
    [TestClass()]
    public class LineStateTests
    {
        private LineState lineState;
        private Model model;
        private MockGraphics mockGraphics;

        [TestInitialize()]
        public void SetUp()
        {
            lineState = new LineState();
            model = new Model();
            mockGraphics = new MockGraphics();

            // 確保 shapes 被正確初始化
            Assert.IsNotNull(model.shapes);
            Assert.IsNotNull(model.shapes.shapeList);

            // 添加測試形狀
            model.BuildShape("StartShape", "Start", "10", "20", "50", "50");
            model.BuildShape("EndShape", "End", "100", "120", "50", "50");

            // 確保形狀已成功添加
            Assert.AreEqual(2, model.shapes.GetShapeCount());
        }



        [TestMethod()]
        public void MouseDownTest()
        {
            lineState.Initialize(model);
            Point point = new Point(15, 25); // 應確保在第一個形狀的 boundingBox 范圍內

            // Act
            lineState.MouseDown(model, point);

            // Assert
            Assert.IsTrue(lineState.start_pressed);
            Assert.AreEqual(model.shapes.GetShapeCount(), 2);
        }



        [TestMethod()]
        public void MouseMoveTest()
        {
            Point startPoint = new Point(15, 25); // 在第一個形狀的邊界內
            lineState.MouseDown(model, startPoint);

            Point movePoint = new Point(105, 125); // 在第二個形狀的邊界點附近
            lineState.MouseMove(model, movePoint);


        }

        [TestMethod()]
        public void MouseUpTest()
        {
            Point startPoint = new Point(15, 25); 
            lineState.MouseDown(model, startPoint);

            Point endPoint = new Point(105, 125);
            lineState.MouseMove(model, endPoint);

            lineState.MouseUp(model, endPoint);

            Assert.IsFalse(lineState.isDrawingLine);
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            // Arrange
            Point startPoint = new Point(15, 25);
            lineState.MouseDown(model, startPoint);

            Point endPoint = new Point(105, 125);
            lineState.MouseMove(model, endPoint);


        }
    }
}
