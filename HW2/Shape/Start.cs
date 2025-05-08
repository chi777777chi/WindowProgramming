using HW2;
using System.Drawing;

public class Start : Shape
{
    public Start(string shapeText, int x, int y, int height, int width)
        : base(shapeText, x, y, height, width) 
    { 
        this.shapeName = "Start"; 
    }

    public override void Draw(IGraphics graphics)
    {
        Pen pen = new Pen(Color.Black, 2);
        graphics.DrawEllipse(pen, x, y, height, width);
    }
    public override void DrawDashedOutline(IGraphics g)
    {
        using (Pen dashPen = new Pen(Color.Green, 1.5f))
        {
            dashPen.DashPattern = new float[] { 3.0f, 3.0f };
            g.DrawEllipse(dashPen, x, y, height, width);
        }
    }
}
