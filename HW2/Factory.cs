using System;

namespace HW2
{
    public class Factory
    {
        public Factory() { }

        public Shape CreateShape(string ShapeName, string shapeText, int X, int Y, int Height, int Width)
        {
            switch (ShapeName)
            {
                case "Start":
                    return new Start(shapeText, X, Y, Height, Width);
                case "Terminator":
                    return new Terminator(shapeText, X, Y, Height, Width);
                case "Process":
                    return new Process(shapeText, X, Y, Height, Width);
                case "Decision":
                    return new Decision(shapeText, X, Y, Height, Width);
                default:
                    return null; 
            }
        }
    }
}
