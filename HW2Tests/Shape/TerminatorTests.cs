using HW2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TerminatorTests
    {

        [TestMethod()]
        public void DrawTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            //var mockGraphics = new MockGraphics();
            Terminator terminator = new Terminator("text", 50, 990, 70, 1);
            terminator.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 4);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawArc Color [Black] (50, 990, 70, 70, StartAngle=90, SweepAngle=180)");
            Assert.AreEqual(mockGraphics.MethodCalls[1], "DrawArc Color [Black] (-19, 990, 70, 70, StartAngle=270, SweepAngle=180)");
            Assert.AreEqual(mockGraphics.MethodCalls[2], "DrawLine Color [Black] (85, 990) -> (16, 990)");
            Assert.AreEqual(mockGraphics.MethodCalls[3], "DrawLine Color [Black] (85, 1060) -> (16, 1060)");
        }

        [TestMethod()]
        public void DrawDashedOutlineTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            Terminator terminator = new Terminator("text", 50, 990, 70, 1);
            terminator.DrawDashedOutline(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 2);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawLine Color [Green] (85, 990) -> (16, 990)");
            Assert.AreEqual(mockGraphics.MethodCalls[1], "DrawLine Color [Green] (85, 1060) -> (16, 1060)");
        }
    }
}