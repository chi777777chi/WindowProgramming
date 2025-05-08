//using HW2.Mock;
using System;
using System.Drawing;

namespace HW2
{
    public class FormGraphicAdapter : IGraphics
    {
        private Graphics _graphics;

        public FormGraphicAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public void DrawLine(Pen pen, int x, int y, int height, int width)
        {
            //Pen pen = new Pen(Color.Black, 2);
            _graphics.DrawLine(pen, x, y, height, width);
        }

        public void DrawRectangle(Pen pen, int x, int y, int height, int width)
        {
            //Pen pen = new Pen(Color.Black, 2);
            _graphics.DrawRectangle(pen, x, y, width, height);

        }

        public void DrawEllipse(Pen pen,int x, int y, int height, int width)
        {
            //Pen pen = new Pen(Color.Black, 2);
            _graphics.DrawEllipse(pen, x, y, width, height);

        }
        public void DrawArc(Pen pen, int x, int y, int height, int width, float startAngle, float sweepAngle)
        {
           
            //Pen pen = new Pen(Color.Black, 2);
            Rectangle rect = new Rectangle(x, y, height, width);
            _graphics.DrawArc(pen, rect, startAngle, sweepAngle);

        }

        public void DrawString(string text, int x, int y)
        {
            using (Font font = new Font("Arial", 12))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                _graphics.DrawString(text, font, brush, x, y);
            }
        }

        public void DrawPolygon(Pen pen, int x, int y, int height, int width)
        {
            using (pen)
            {
                Point[] points = new Point[]
                {
                    new Point(x + width / 2, y),               // 上頂點
                    new Point(x + width, y + height / 2),      // 右頂點
                    new Point(x + width / 2, y + height),      // 下頂點
                    new Point(x, y + height / 2)               // 左頂點
                };
                _graphics.DrawPolygon(pen, points);
            }
        }

    }
}
