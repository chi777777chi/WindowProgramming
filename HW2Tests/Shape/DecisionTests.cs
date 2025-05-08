using HW2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class DecisionTests
    {

        [TestMethod()]
        public void DrawTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            //var mockGraphics = new MockGraphics();
            Decision decision = new Decision("text", 100, 750, 70, 3);
            decision.Draw(mockGraphics);
            //DrawPolygon(pen, x, y, width, height);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawPolygon Color [Black] (100, 750, 70, 3)");
           
        }

        [TestMethod()]
        public void DrawDashedOutlineTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            //var mockGraphics = new MockGraphics();
            Decision decision = new Decision("text", 100, 750, 70, 3);
            decision.DrawDashedOutline(mockGraphics);
            //DrawPolygon(pen, x, y, width, height);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawPolygon Color [Green] (100, 750, 70, 3)");
        }
    }
}