using System;
using System.Drawing;

namespace HW2.Command
{
    public class TextMoveCommand : ICommand
    {
        private Model model;          // 模型對象
        private Shape shapeToMove;    // 需要移動的形狀
        private Point originalPosition; // 原始文本位置
        private Point newPosition;      // 新的文本位置

        public TextMoveCommand(Model m, Shape shape, Point oldPos)
        {
            if (shape == null) { return; }
            model = m;
            shapeToMove = shape;
            originalPosition = oldPos;
            newPosition = new Point(shape.TextX, shape.TextY);
        }

        public void Execute()
        {
            // 執行文本移動
            if (shapeToMove != null)
            {
                MoveText(newPosition);
            }
        }

        public void UnExecute()
        {
            // 撤銷文本移動
            if (shapeToMove != null)
            {
                MoveText(originalPosition);
            }
        }

        private void MoveText(Point position)
        {
            // 更新形狀的文本位置
            shapeToMove.TextX = position.X;
            shapeToMove.TextY = position.Y;

        }
    }
}
