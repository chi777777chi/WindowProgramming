using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Command
{
    public class DeleteCommand : ICommand
    {
        Shape shape;
        Model model;
        int index;
        public DeleteCommand(Model m, int index)
        {
            model = m;
            this.index = index;
            shape = model.shapes.GetShapeByIndex(index);
        }
        public void Execute() 
        {
            model.DeleteShape(index);
            model.DeleteHistoryShape(index);
        }
        public void UnExecute() 
        {
            model.shapes.AddShape(shape);
            model.shapesHistory.AddShape(shape);
        }
        public Model GetModel() { return  model; }
    }

}
