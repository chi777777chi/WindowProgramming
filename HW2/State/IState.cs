using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.State
{
    public interface IState
    {
        void Initialize(Model m);
        void OnPaint(Model m, Graphics g);
        void MouseDown(Model m, Point point);
        void MouseMove(Model m, Point point);
        void MouseUp(Model m, Point point);
        //void KeyDown(Model m, int keyValue);
        //void KeyUp(Model m, int keyValue);
    }
}
