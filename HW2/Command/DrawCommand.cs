using System;
using System.Drawing;

namespace HW2.Command
{
    public class DrawCommand : ICommand
    {
        private Shape shape;    // 繪製的矩形
        private Model model;       // 模型
        private Shape drawnShape;  // 被繪製的形狀，用於撤銷操作
        private Line drawnLine;
        public DrawCommand(Model m, Shape s)
        {
            drawnShape = s;
            model = m;
        }
        public DrawCommand(Model m, Line l)
        {
            drawnLine = l;
            model = m;
        }
        public void Execute()
        {
            if (drawnLine == null)
            {
                model.shapes.AddShape(drawnShape); // 添加形狀到模型
                return;
            }
            if (drawnShape == null)
            {
                model.addLine(drawnLine); // 添加形狀到模型
            }
        }

        public void UnExecute()
        {
            // 從模型中移除剛剛添加的形狀
            if (drawnShape != null)
            {
                model.shapes.DeleteShape(model.shapes.shapeList.IndexOf(drawnShape));
            }
            if (drawnLine != null)
            {
                // 從模型中移除線條
                model.removeLine(drawnLine);
            }
        }
    }
}
