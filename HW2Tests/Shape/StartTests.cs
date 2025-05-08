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
    public class StartTests
    {

        [TestMethod()]
        public void DrawTest()
        {
            var mockGraphics = new MockGraphics();
            Start start = new Start("text", 90, 70, 80, 100);
            start.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawEllipse Color [Black] (90, 70) -> (80, 100)");
            //Assert.Fail();
        }

        [TestMethod()]
        public void DrawDashedOutlineTest()
        {
            var mockGraphics = new MockGraphics();
            Start start = new Start("text", 90, 70, 80, 100);
            start.DrawDashedOutline(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawEllipse Color [Green] (90, 70) -> (80, 100)");
        }
    }
}