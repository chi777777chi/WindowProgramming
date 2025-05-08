using HW2;
using System.Drawing;

public class Terminator : Shape
{
    public Terminator(string shapeText, int x, int y, int height, int width)
        : base(shapeText, x, y, height, width) 
    { 
        this.shapeName = "Terminator"; 
    }

    public override void Draw(IGraphics graphics)
    {
        int Width = width - height;
        Pen pen = new Pen(Color.Black, 2);
        graphics.DrawArc(pen, x, y, height, height, 90, 180);
        graphics.DrawArc(pen, x + Width, y, height, height, 270, 180);
        graphics.DrawLine(pen, x + height / 2, y, x + Width + height / 2, y);
        graphics.DrawLine(pen, x + height / 2, y + height, x + Width + height / 2, y + height);
    }
    public override void DrawDashedOutline(IGraphics g)
    {
        int Width = width - height;
        using (Pen dashPen = new Pen(Color.Green, 1.5f))
        {
            dashPen.DashPattern = new float[] { 3.0f, 3.0f };
            //g.DrawArc(dashPen, x, y, height, height, 90, 180);
            //g.DrawArc(dashPen, x + Width, y, height, height, 270, 180);
            g.DrawLine(dashPen, x + height / 2, y, x + Width + height / 2, y);
            g.DrawLine(dashPen, x + height / 2, y + height, x + Width + height / 2, y + height);
        }
    }
}
