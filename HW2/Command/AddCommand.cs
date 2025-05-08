using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Command
{
    public class AddCommand : ICommand
    {
        Model model;
        Shape shape;
        public AddCommand(Model m, Shape shape)
        {
            model = m;
            this.shape = shape;
        }
        public void Execute()
        {
            int currentIndex = model.shapes.GetShapeCount();
            int historyLength = model.shapesHistory.GetShapeCount();
            if (currentIndex == historyLength )
            {
                model.shapes.AddShape(shape);
                return;
            }
            if (currentIndex < historyLength)
            {
                shape = model.shapesHistory.shapeList[currentIndex];
                model.shapes.AddShape(shape);
            }
        }

        public void UnExecute() 
        { 
            model.DeleteShape(model.shapes.GetShapeCount() - 1);
        }

        public Model GetModel() { return model; }
    }

}
