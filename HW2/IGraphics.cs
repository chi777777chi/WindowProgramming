using System.Drawing;

namespace HW2
{
    public interface IGraphics
    {
        void DrawLine(Pen pen, int x, int y, int height, int width);

        void DrawRectangle(Pen pen, int x, int y, int height, int width);

        void DrawEllipse(Pen pen, int x, int y, int height, int width);

        void DrawArc(Pen pen, int x, int y, int height, int width, float startAngle, float sweepAngle);
        //void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle);
        void DrawString(string text, int x, int y);
        //void DrawString(string text, Font font, Brush brush, int x, int y);
        void DrawPolygon(Pen pen, int x, int y, int height, int width);
        //void DrawPolygon(Pen pen, Point[] points);

    }
}
