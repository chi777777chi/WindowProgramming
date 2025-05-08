using System;
using System.Drawing;

namespace HW2.Command
{
    public class MoveCommand : ICommand
    {
        private Model model;
        private Shape shapeToMove;
        private Point originalPosition;
        private Point newPosition;

        public MoveCommand(Model model, Shape shape, Point originPosition)
        {
            this.model = model;
            this.shapeToMove = shape;
            this.originalPosition = originPosition;
            newPosition = new Point(shape.x, shape.y); 
        }

        // 執行移動命令
        public void Execute()
        {
            if (shapeToMove != null)
            {
                MoveShape(newPosition);
            }
        }

        // 撤銷移動命令
        public void UnExecute()
        {
            if (shapeToMove != null)
            {
                MoveShape(originalPosition);
            }
        }

        // 移動形狀到指定位置
        private void MoveShape(Point position)
        {
            shapeToMove.x = position.X;
            shapeToMove.y = position.Y;
        }
    }
}