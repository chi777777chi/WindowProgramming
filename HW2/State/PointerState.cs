using HW2.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HW2.State
{
    public class PointerState : IState
    {
        Shapes selectedShapes = new Shapes();
        Shape selectedShape;
        IGraphics graphics;
        public bool start_pressed;
        public bool shapeCanMove;
        public bool textCanMove;
        //bool textMove = false;
        private Point offset;
        private Point originPosition;
        private Point originTextPosition;
        public void Initialize(Model m)
        {
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShapes
            selectedShapes.shapeList.Clear();
            start_pressed = false;
            shapeCanMove = false;
            textCanMove = false;
        }
        public void AddSelectedShape(Shape shape)
        {
            // Bug: 應該寫判斷式，不重複加入相同的Shape比較好
            selectedShapes.AddShape(shape);
        }
        public Shapes GetSelectedShape()
        {
            return selectedShapes;
        }
        public void MouseDown(Model m, Point point)
        {
            start_pressed = true;
            textCanMove = false;
            shapeCanMove = false;

            // Check for text click first
            foreach (Shape shape in Enumerable.Reverse(m.shapes.shapeList))
            {
                if (shape.IsPointInText(point))
                {
                    selectedShapes.shapeList.Clear();
                    selectedShapes.AddShape(shape);
                    textCanMove = true;
                    offset = new Point(point.X - shape.TextX, point.Y - shape.TextY);
                    originTextPosition = new Point(shape.TextX, shape.TextY);
                    return;
                }
            }

            // Check for shape click
            foreach (Shape shape in Enumerable.Reverse(m.shapes.shapeList))
            {
                if (shape.IsPointInShape(point))
                {
                    selectedShapes.shapeList.Clear();
                    selectedShapes.AddShape(shape);
                    shapeCanMove = true;
                    offset = new Point(point.X - shape.x, point.Y - shape.y);
                    originPosition = new Point(shape.x, shape.y);
                    return;
                }
            }
        }
        public void MouseDown(Model m, MockPoint mockPoint)
        {
            MouseDown(m, new System.Drawing.Point(mockPoint.x, mockPoint.x));
        }
        public void MouseMove(Model m, Point point)
        {
            
            //text移動
            if (start_pressed  && selectedShapes.shapeList.Count > 0 && textCanMove)
            {
                int newTextX = point.X - offset.X;
                int newTextY = point.Y - offset.Y;

                selectedShape = selectedShapes.shapeList[0];
                Rectangle boundingBox = selectedShape.boundingBox;
                Rectangle textBox = selectedShape.boundingTextBox;

                newTextX = Math.Max(boundingBox.Left, Math.Min(newTextX, boundingBox.Right - textBox.Width));
                newTextY = Math.Max(boundingBox.Top, Math.Min(newTextY, boundingBox.Bottom - textBox.Height));
                //if ()
                selectedShape.TextX = newTextX;
                selectedShape.TextY = newTextY;
                return;
            }
            if (start_pressed && selectedShapes.shapeList.Count > 0 && shapeCanMove)
            {
                selectedShape = selectedShapes.shapeList[0];
                selectedShape.x = point.X - offset.X;
                selectedShape.y = point.Y - offset.Y;
                return; 
            }
            //shape移動
            
        }
        public void MouseMove(Model m, MockPoint mockPoint)
        {
            MouseMove(m, new System.Drawing.Point(mockPoint.x, mockPoint.y));
        }
        public void MouseUp(Model m, Point point)
        {
            //textMove
            if ((offset.X != 0 || offset.Y != 0) && textCanMove && selectedShape != null)
            {
                // 創建並執行 TextMoveCommand
                m.commandManager.Execute(new TextMoveCommand(m, selectedShape, originTextPosition));
            }

            //shapeMove
            if ((offset.X != 0) && (offset.Y != 0) && shapeCanMove && selectedShape != null)
            {
                m.commandManager.Execute(new MoveCommand(m, selectedShape, originPosition));
            }
            start_pressed = false;
            shapeCanMove = false;
            textCanMove = false;
            // do nothing
        }
        public void MouseUp(Model m, MockPoint mockPoint)
        {
            MouseUp(m, new System.Drawing.Point(mockPoint.x, mockPoint.y));
        }
        public void OnPaint(Model m, Graphics g)
        {
            if (textCanMove)
            {
                using (Pen dashedPen = new Pen(Color.Blue, 2))
                {
                    dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                }
            }
            IGraphics adapter = new FormGraphicAdapter(g);
            // 繪製所有形狀
            foreach (Shape shape in m.shapes.shapeList)
            {
                shape.Draw(adapter);
                shape.DrawShapeText(adapter);
            }
            foreach (Line completedLine in m.lineList)
            {
                if (completedLine == null) { break; }
                completedLine.Draw(adapter);
            }
            // 畫出所有的Ellipse
            // 畫出被選中圖形的外框
            foreach (Shape shape in selectedShapes.shapeList)
            {
                foreach (Shape mshape in m.shapes.shapeList)
                    if (mshape ==  shape)
                        shape.DrawBoundingBox(g);
                if (textCanMove)
                {
                    shape.DrawTextBoundingBox(g);
                }
            }
        }
    }
}
