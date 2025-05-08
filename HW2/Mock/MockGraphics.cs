using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class MockGraphics : IGraphics
    {
        public List<Point> DrawnPoints = new List<Point>();
        public List<string> MethodCalls { get; private set; } = new List<string>();
        public void DrawLine(Pen pen, int x, int y, int height, int width) 
        {
            MethodCalls.Add($"DrawLine {pen.Color} ({x}, {y}) -> ({height}, {width})");
        }

        public void DrawRectangle(Pen pen, int x, int y, int height, int width) 
        {
            MethodCalls.Add($"DrawRectangle {pen.Color} ({x}, {y}) -> ({height}, {width})");
        }

        public void DrawEllipse(Pen pen, int x, int y, int height, int width) 
        {
            MethodCalls.Add($"DrawEllipse {pen.Color} ({x}, {y}) -> ({height}, {width})");
        } 

        public void DrawArc(Pen pen, int x, int y, int height, int width, float startAngle, float sweepAngle) 
        {
            MethodCalls.Add($"DrawArc {pen.Color} ({x}, {y}, {height}, {width}, StartAngle={startAngle}, SweepAngle={sweepAngle})");
        }
        //public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle) { }
        public void DrawString(string text, int x, int y) 
        {
            MethodCalls.Add($"DrawString {text} ({x}, {y}) ");
            DrawnPoints.Add(new Point(x, y));
        }
        //public void DrawString(string text, Font font, Brush brush, int x, int y) { }
        public void DrawPolygon(Pen pen, int x, int y, int height, int width) 
        {
            MethodCalls.Add($"DrawPolygon {pen.Color} ({x}, {y}, {height}, {width})");
        }
        //public void DrawPolygon(Pen pen, Point[] points) { }

    }
}
