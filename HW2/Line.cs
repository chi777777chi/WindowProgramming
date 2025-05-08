using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Line
    {
        public Shape startShape;
        public Shape endShape;
        public int startIndex;
        public int endIndex;
        public Point Start => startShape.boundingPointList[startIndex];
        public Point End => endShape.boundingPointList[endIndex];
        public Point TemporaryPoint;

        public Line(Shape startShape, Shape endShape, int startIndex, int endIndex)
        {
            this.startShape = startShape;
            this.endShape = endShape;   
            this.startIndex = startIndex;   
            this.endIndex = endIndex;
        }
        public void Draw(IGraphics graphics) {
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, Start.X, Start.Y, End.X, End.Y);
        }
        public void DrawTemporary(IGraphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, Start.X, Start.Y, TemporaryPoint.X, TemporaryPoint.Y);
        }
        public void SetStartShape(Shape startShape)
        {
            this.startShape = startShape;
        }
        public void SetEndShape(Shape endShape)
        {
            this.endShape = endShape;
        }
        public void SetEndShapeIndex(int endIndex)
        {
            this.endIndex = endIndex;
        }

    }
}
