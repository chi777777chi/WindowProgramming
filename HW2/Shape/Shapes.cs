using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HW2
{
    public class Shapes
    {
        private Factory factory = new Factory();
        public List<Shape> shapeList = new List<Shape>();

        public Shapes() { }

        public bool AddShape(string name, string shapeText, int X, int Y, int Height, int Width)
        {
            Shape newShape = factory.CreateShape(name, shapeText , X, Y, Height, Width);

            if (newShape == null)
            {
                return false;
            }

            shapeList.Add(newShape);
            return true;
        }
        public void AddShape(Shape shape)
        {
            shapeList.Add(shape);
        }
        public void DeleteShape(int index)
        {
            if (index >= 0 && index < shapeList.Count)
            {
                shapeList.RemoveAt(index);
                //NotifyObserver();
            }
        }

        public Shape GetShapeByIndex(int index)
        {
            if (index >= 0 && index < shapeList.Count)
            {
                return shapeList[index];
            }
            else
            {
                return null;
            }
        }
        public int GetShapeCount()
        {
            return shapeList.Count;
        }
    }
}
