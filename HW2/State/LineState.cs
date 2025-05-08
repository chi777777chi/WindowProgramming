using HW2.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW2.State
{

    public class LineState : IState
    {
        Shape startShape;
        Shape endShape;
        int startIndex;
        int endIndex;
        public bool isDrawingLine;
        Line line;
        public Line drawingLine;
        public Shape selectedShape;
        public bool start_pressed;
        public void Initialize(Model m) {

            start_pressed = false;
            isDrawingLine = false;
            drawingLine = null;
        }
        public void AddSelectedShape(Shape shape)
        {
            // Bug: 應該寫判斷式，不重複加入相同的Shape比較好
            selectedShape = shape;
        }
        public void MouseDown(Model m, Point point)
        {
            if (m.shapes == null || m.shapes.shapeList == null || m.shapes.shapeList.Count == 0)
                return; 

            start_pressed = true;

            foreach (Shape shape in Enumerable.Reverse(m.shapes.shapeList))
            {
                if (shape != null && shape.IsPointInShape(point))
                {
                    selectedShape = shape;
                }
            }

            foreach (Shape shape in m.shapes.shapeList)
            {
                if (shape != null)
                {
                    int index = shape.IsPointInBoundingPoint(point);
                    if (index >= 0)
                    {
                        startShape = endShape = shape;
                        startIndex = endIndex = index;
                        isDrawingLine = true;
                        drawingLine = new Line(startShape, endShape, startIndex, endIndex);
                        return;
                    }
                }
            }
        }

        public void MouseMove(Model m, Point point) 
        {
            if (!isDrawingLine || drawingLine == null) return;
            foreach (Shape shape in m.shapes.shapeList)
            {
                int index = shape.IsPointInBoundingPoint(point);
                if (index >= 0)
                {
                    endShape = shape;
                    endIndex = index;
                    drawingLine.SetEndShape(endShape);
                    drawingLine.SetEndShapeIndex(endIndex);
                    return; // 找到吸附點後直接返回
                }
            }

            // 如果沒有靠近任何形狀的點，則使用滑鼠位置作為終點
            drawingLine.TemporaryPoint = point;
        }
        public void MouseUp(Model m, Point point)
        {
            if (drawingLine == null) return;
            if (start_pressed && selectedShape!= null ) { }
            //檢查放開的地方是否是boundingPoint
            foreach (Shape shape in m.shapes.shapeList)
            {
                int index = shape.IsPointInBoundingPoint(point);
            
                if (index >= 0 && isDrawingLine == true)
                {

                    //起始點 = 終點 不畫
                    if ((startShape == endShape) && (startIndex == endIndex)) {
                        start_pressed = false;
                        isDrawingLine = false;
                        line = null;
                        drawingLine = null; return; }
                    //line.SetEndShape(endShape);
                    //line.SetEndShapeIndex(endIndex);
                    line = new Line(startShape, endShape, startIndex, endIndex);
                    m.commandManager.Execute(new DrawCommand(m, line));
                }

            }
            
            start_pressed = false; 
            isDrawingLine = false;
            line = null;
            drawingLine = null;
            m.EnterPointerState();
        }
        public void OnPaint(Model m, Graphics g)
        {
            IGraphics adapter = new FormGraphicAdapter(g);

            // 繪製所有形狀
            foreach (Shape shape in m.shapes.shapeList)
                shape.Draw(adapter);
            if (selectedShape != null)
            {
                selectedShape.DrawBoundingBox(g);
                selectedShape.DrawBoundingPoints(g);
            }
                // 繪製所有完成的線條
            foreach (Line completedLine in m.lineList)
                completedLine.Draw(adapter);

            // 繪製當前正在繪製的線條（預覽效果）
            if (start_pressed && drawingLine != null)
                drawingLine.DrawTemporary(adapter);
        }

    }
}
