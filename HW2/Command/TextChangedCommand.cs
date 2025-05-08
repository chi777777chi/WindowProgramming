using System;

namespace HW2.Command
{
    public class TextChangedCommand : ICommand
    {
        private Model model;
        private Shape shapeToChange;     // 要更改文本的形狀
        private string originalText;    // 原始文本
        private string newText;         // 新文本

        public TextChangedCommand(Model m, Shape shape, string newText)
        {
            model = m;
            shapeToChange = shape;
            originalText = shape.shapeText; // 記錄原始文本
            this.newText = newText;
        }

        public void Execute()
        {
            // 執行文本更改
            if (shapeToChange != null)
            {
                shapeToChange.shapeText = newText;
            }
        }

        public void UnExecute()
        {
            // 撤銷文本更改
            if (shapeToChange != null)
            {
                shapeToChange.shapeText = originalText;
            }
        }

    }
}
