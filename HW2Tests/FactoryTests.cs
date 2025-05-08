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
    public class FactoryTests
    {

        [TestMethod()]
        public void CreateShapeTest()
        {
            //CreateShape(string ShapeName, int X, int Y, int Height, int Width)
            Factory factory = new Factory();

            Shape shape = factory.CreateShape("Process", "text", 100, 110, 9, 50);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.shapeName, "Process");

            shape = factory.CreateShape("Start", "text", 100, 110, 9, 50);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.shapeName, "Start");

            shape = factory.CreateShape("Terminator", "text", 100, 110, 9, 50);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.shapeName, "Terminator");

            shape = factory.CreateShape("Decision", "text", 100, 110, 9, 50);
            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.shapeName, "Decision");

            shape = factory.CreateShape("", "text", 100, 110, 9, 50);
            Assert.IsNull(shape);
        }
    }

}