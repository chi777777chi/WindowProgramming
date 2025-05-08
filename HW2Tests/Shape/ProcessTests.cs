using HW2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ProcessTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            Process process = new Process("text", 20, 30, 1000, 160);
            process.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawRectangle Color [Black] (20, 30) -> (1000, 160)");
        }

        [TestMethod()]
        public void DrawDashedOutlineTest()
        {
            MockGraphics mockGraphics = new MockGraphics();
            Process process = new Process("text", 20, 30, 1000, 160);
            process.DrawDashedOutline(mockGraphics);
            Assert.AreEqual(mockGraphics.MethodCalls.Count, 1);
            Assert.AreEqual(mockGraphics.MethodCalls[0], "DrawRectangle Color [Green] (20, 30) -> (1000, 160)");
        }
    }
}