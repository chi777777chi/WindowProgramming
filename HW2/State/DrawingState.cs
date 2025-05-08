using HW2.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.State
{
    public class DrawingState : IState
    {
        IGraphics graphics;
        Point start_point, end_point;   // 記錄圖的左上角、右下角
        public bool start_pressed;            // 記錄左上角按了沒
        public Shape hintShape;        // 記錄正在畫的圖
        PointerState pointerState;  // 記錄PointerState
        string shapeText = "text";
        public DrawingState(PointerState pointerState)
        {
            // 建立DrawingState時，傳入PointerState，使得DrawingState可以指定PointerState選取剛剛新增的圖形
            this.pointerState = pointerState;
        }
        void IState.Initialize(Model m)
        {
            start_pressed = false;
            hintShape = null;
        }

        public void MouseDown(Model m, Point point)
        {
            CurrentShapes shape = m.currentShape;
            start_pressed = true;
            start_point = end_point = point;
            switch (shape)
            {
                case (CurrentShapes.START):
                    hintShape = new Start(shapeText, start_point.X, start_point.Y, 0, 0);
                    break;
                case (CurrentShapes.TERMINATOR):
                    hintShape = new Terminator(shapeText, start_point.X, start_point.Y, 0, 0);
                    break;
                case (CurrentShapes.PROCESS):
                    hintShape = new Process(shapeText, start_point.X, start_point.Y, 0, 0);
                    break;
                case (CurrentShapes.DECISION):
                    hintShape = new Decision(shapeText, start_point.X, start_point.Y, 0, 0);
                    break;
                default:
                    //currentShape = CurrentShapes._NULL;
                    break;
            }
            
        }

        public void MouseMove(Model m, Point point)
        {
            if (start_pressed)
            {
                hintShape.width = point.X - hintShape.x;
                hintShape.height = point.Y - hintShape.y;
            }
        }
        public void MouseMove(Model m, MockPoint mockPoint)
        {
            MouseMove(m, new System.Drawing.Point(mockPoint.x, mockPoint.y));
        }

        public void MouseUp(Model m, Point point)
        {
            if ((hintShape.width == 0) && (hintShape.height == 0))
            {
                m.EnterPointerState();
                return;
            }
            //AddCommand addCommand = new AddCommand();
            start_pressed = false;
            hintShape.Normalize();
            // 畫完之後，將圖形加入到圖形清單中
            m.commandManager.Execute(new DrawCommand(m, hintShape));
            // 等return後，Model才會真正切換到PointerState
            m.EnterPointerState();
            // 指定PointerState選取剛剛新增的圖形，不能與前面那行對調順序
            pointerState.AddSelectedShape(hintShape);
        }
        public void MouseUp(Model m, MockPoint mockPoint)
        {
            MouseUp(m, new System.Drawing.Point(mockPoint.x, mockPoint.y));
        }
        public void OnPaint(Model m, Graphics g)
        {
            IGraphics adapter = new FormGraphicAdapter(g);
            // 繪製所有形狀
            foreach (Shape shape in m.shapes.shapeList)
                shape.Draw(adapter);

            // 繪製提示形狀（如果正在繪製）
            if (start_pressed && hintShape != null)
            {
                hintShape.DrawDashedOutline(adapter);
            }
            foreach (Line completedLine in m.lineList)
                completedLine.Draw(adapter);
        }

    }
}
