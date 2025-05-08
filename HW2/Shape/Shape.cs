using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HW2
{
    public class Shape
    {
        public Rectangle boundingBox;
        public Rectangle boundingTextBox;
        public List<Point> boundingPointList;
        public int TextOffsetX { get; set; }
        public int TextOffsetY { get; set; }
        public int TextX
        {
            get { return boundingTextBox.X; }
            set
            {
                TextOffsetX = value - boundingBox.X;
                boundingTextBox.X = value;
            }
        }
        public int TextY
        {
            get { return boundingTextBox.Y; }
            set
            {
                TextOffsetY = value - boundingBox.Y;
                boundingTextBox.Y = value;
            }
        }
        public string shapeName { get; set; }
        public string shapeText
        {
            get; set;
        }
        public int x
        {
            get { return boundingBox.X; }
            set
            {
                boundingBox.X = value;
                UpdateBoundingTextBox();
                UpdateBoundingPoints();
            }
        }
        public int y
        {
            get { return boundingBox.Y; }
            set
            {
                boundingBox.Y = value;
                UpdateBoundingTextBox();
                UpdateBoundingPoints();
            }
        }
        public int height
        {
            get { return boundingBox.Height; }
            set
            {
                boundingBox.Height = value;
                UpdateBoundingTextBox();
                UpdateBoundingPoints();
            }
        }
        public int width
        {
            get { return boundingBox.Width; }
            set
            {
                boundingBox.Width = value;
                UpdateBoundingTextBox();
                UpdateBoundingPoints();
            }
        }
        public Shape(string shapeText, int x, int y, int height, int width)
        {
            this.shapeText = shapeText;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }


        public virtual void Draw(IGraphics graphics) { }
        public void DrawShapeText(IGraphics graphics)
        {
            graphics.DrawString(shapeText, boundingTextBox.X, boundingTextBox.Y);
        }

        public bool IsPointInShape(Point point)
        {
            // 建立GrpahicsPath以判斷某個點是否落在圖形內
            // 此副程式常常被call，但是path通常不會變，若要提高效率，建立path的code可以改寫在Normalize()裡面
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(boundingBox);
            return path.IsVisible(point);
        }
        public bool IsPointInText(Point point)
        {
            // 建立GrpahicsPath以判斷某個點是否落在圖形內
            // 此副程式常常被call，但是path通常不會變，若要提高效率，建立path的code可以改寫在Normalize()裡面
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(boundingTextBox);
            return path.IsVisible(point);
        }
        public void DrawBoundingBox(Graphics g)
        {
            using (Pen pen = new Pen(Color.Yellow, 3))
            {
                g.DrawRectangle(pen, boundingBox); // 繪製矩形
            }

        }
        public void DrawTextBoundingBox(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Green, 3))
            {
                graphics.DrawRectangle(pen, boundingTextBox); // 繪製矩形
            }
        }
        public virtual void DrawDashedOutline(IGraphics g) { }

        public void Normalize()
        {
            if (width < 0)
            {
                x += width;  // 向左調整 x
                width = Math.Abs(width); // 確保 width 為正
            }
            if (height < 0)
            {
                y += height; // 向上調整 y
                height = Math.Abs(height); // 確保 height 為正
            }
        }
        public bool IsTextInBoundingBox()
        {
            // Check if boundingTextBox is completely inside boundingBox
            return boundingTextBox.Left >= boundingBox.Left &&
                   boundingTextBox.Right <= boundingBox.Right &&
                   boundingTextBox.Top >= boundingBox.Top &&
                   boundingTextBox.Bottom <= boundingBox.Bottom;
        }

        public void UpdateBoundingTextBox()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                // Use a default font for measurement
                Font font = new Font("Arial", 12);
                SizeF textSize = g.MeasureString(shapeText, font);
                boundingTextBox = new Rectangle(
                    boundingBox.X + TextOffsetX,
                    boundingBox.Y + TextOffsetY,
                    (int)textSize.Width,
                    (int)textSize.Height
                );
            }
        }
        public void UpdateBoundingPoints()
        {
            boundingPointList = new List<Point>
            {
                new Point((boundingBox.Left + boundingBox.Right) / 2, boundingBox.Top), // 上中點
                new Point(boundingBox.Right, (boundingBox.Top + boundingBox.Bottom) / 2), // 右中點
                new Point((boundingBox.Left + boundingBox.Right) / 2, boundingBox.Bottom), // 下中點
                new Point(boundingBox.Left, (boundingBox.Top + boundingBox.Bottom) / 2)  // 左中點
            };
        }

        public int IsPointInBoundingPoint(Point point)
        {
            if (boundingPointList == null || boundingPointList.Count == 0)
                return -1;

            int range = 10; // 點擊範圍半徑

            for (int i = 0; i < boundingPointList.Count; i++)
            {
                Point boundingPoint = boundingPointList[i];
                double distance = Math.Sqrt(Math.Pow(point.X - boundingPoint.X, 2) + Math.Pow(point.Y - boundingPoint.Y, 2));

                if (distance <= range)
                    return i; // 返回點的索引
            }

            return -1; // 沒有找到點
        }


        public void DrawBoundingPoints(Graphics g)
        {
            if (boundingPointList == null || boundingPointList.Count == 0)
                return;

            // 設定邊界點的樣式
            int pointSize = 6; // 邊界點的直徑
            Brush pointBrush = Brushes.Blue; // 使用藍色填充

            // 繪製每個邊界點
            foreach (var point in boundingPointList)
            {
                g.FillEllipse(pointBrush,
                    point.X - pointSize / 2,
                    point.Y - pointSize / 2,
                    pointSize,
                    pointSize);
            }
        }
    }
}