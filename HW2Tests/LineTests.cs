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
    public class LineTests
    {
        private Shape startShape;
        private Shape endShape;
        private Line line;

        [TestInitialize]
        public void SetUp()
        {
            // 初始化起點和終點圖形
            startShape = new Shape("Start", 0, 0, 100, 100);
            endShape = new Shape("End", 200, 200, 100, 100);

            // 初始化 Line
            line = new Line(startShape, endShape, 0, 0);

            // 設定圖形的頂點
            startShape.boundingPointList = new List<Point>
        {
            new Point(0, 0), // 左上
            new Point(100, 0), // 右上
            new Point(100, 100), // 右下
            new Point(0, 100) // 左下
        };

            endShape.boundingPointList = new List<Point>
        {
            new Point(200, 200), // 左上
            new Point(300, 200), // 右上
            new Point(300, 300), // 右下
            new Point(200, 300) // 左下
        };
        }
        [TestMethod()]
        public void LineTest()
        {
            // 驗證起點和終點是否正確初始化
            Assert.AreEqual(new Point(0, 0), line.Start);
            Assert.AreEqual(new Point(200, 200), line.End);
        }

        [TestMethod()]
        public void DrawTest()
        {
            // 使用 MockGraphics 模擬繪圖
            var mockGraphics = new MockGraphics();

            // 初始化起點和終點形狀
            Shape startShape = new Shape("Start", 0, 0, 100, 100);
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            startShape.boundingPointList = new List<Point>
            {
                new Point(0, 0), new Point(100, 0), new Point(100, 100), new Point(0, 100)
            };
            endShape.boundingPointList = new List<Point>
            {
                new Point(200, 200), new Point(300, 200), new Point(300, 300), new Point(200, 300)
            };

            Line line = new Line(startShape, endShape, 0, 0);

            // 執行繪圖
            line.Draw(mockGraphics);

            // 驗證繪圖方法是否被正確調用
            Assert.AreEqual(1, mockGraphics.MethodCalls.Count);
            Assert.IsTrue(mockGraphics.MethodCalls[0].Contains("DrawLine"));
        }

        [TestMethod()]
        public void DrawTemporaryTest()
        {
            // 使用 MockGraphics 模擬繪圖
            var mockGraphics = new MockGraphics();

            // 初始化 Line 並設置臨時終點
            Shape startShape = new Shape("Start", 0, 0, 100, 100);
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            startShape.boundingPointList = new List<Point> { new Point(0, 0) };
            endShape.boundingPointList = new List<Point> { new Point(200, 200) };

            Line line = new Line(startShape, endShape, 0, 0);
            line.TemporaryPoint = new Point(150, 150);

            // 執行繪製臨時終點
            line.DrawTemporary(mockGraphics);

            // 驗證繪圖方法是否被正確調用
            Assert.AreEqual(1, mockGraphics.MethodCalls.Count);
            Assert.IsTrue(mockGraphics.MethodCalls[0].Contains("DrawLine"));
        }


        [TestMethod()]
        public void SetStartShapeTest()
        {
            // 初始化起點和終點
            Shape startShape = new Shape("Start", 0, 0, 100, 100);
            Shape newStartShape = new Shape("NewStart", 50, 50, 100, 100);
            startShape.boundingPointList = new List<Point>
            {
                new Point(0, 0), new Point(100, 0), new Point(100, 100), new Point(0, 100)
            };
            newStartShape.boundingPointList = new List<Point>
            {
                new Point(50, 50), new Point(150, 50), new Point(150, 150), new Point(50, 150)
            };

            Line line = new Line(startShape, startShape, 0, 0);

            // 更新起點形狀
            line.SetStartShape(newStartShape);

            // 驗證起點是否正確更新
            Assert.AreEqual(new Point(50, 50), line.Start);
        }


        [TestMethod()]
        public void SetEndShapeTest()
        {
            // 初始化終點
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            Shape newEndShape = new Shape("NewEnd", 400, 400, 100, 100);
            endShape.boundingPointList = new List<Point>
            {
                new Point(200, 200), new Point(300, 200), new Point(300, 300), new Point(200, 300)
            };
            newEndShape.boundingPointList = new List<Point>
            {
                new Point(400, 400), new Point(500, 400), new Point(500, 500), new Point(400, 500)
            };

            Line line = new Line(endShape, endShape, 0, 0);

            // 更新終點形狀
            line.SetEndShape(newEndShape);

            // 驗證終點是否正確更新
            Assert.AreEqual(new Point(400, 400), line.End);
        }


        [TestMethod()]
        public void SetEndShapeIndexTest()
        {
            // 初始化終點形狀
            Shape endShape = new Shape("End", 200, 200, 100, 100);
            endShape.boundingPointList = new List<Point>
            {
                new Point(200, 200), new Point(300, 200), new Point(300, 300), new Point(200, 300)
            };

            Line line = new Line(endShape, endShape, 0, 0);

            // 更新終點索引
            line.SetEndShapeIndex(2);

            // 驗證終點是否正確更新
            Assert.AreEqual(new Point(300, 300), line.End);
        }

    }
}