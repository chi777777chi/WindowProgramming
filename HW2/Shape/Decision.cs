using HW2;
using System.Drawing;

public class Decision : Shape
{
    public Decision(string shapeText, int x, int y, int height, int width)
        : base(shapeText, x, y, height, width) {
        this.shapeName = "Decision";
    }

    public override void Draw(IGraphics graphics)
    {
        Pen pen = new Pen(Color.Black, 2);
        graphics.DrawPolygon(pen, x, y, height, width);
    }
    public override void DrawDashedOutline(IGraphics g)
    {
        // 創建虛線筆
        using (Pen dashPen = new Pen(Color.Green, 1.5f))
        {
            dashPen.DashPattern = new float[] { 3.0f, 3.0f };
            g.DrawPolygon(dashPen, x, y, height, width);
        }
    }

}
