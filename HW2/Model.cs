using HW2.Command;
using HW2.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace HW2
{
    public enum  CurrentShapes
    {
        START,
        TERMINATOR,
        PROCESS,
        DECISION,
        _NULL
    }
    public class Model
    {
        public CommandManager commandManager = new CommandManager();
        public CurrentShapes currentShape = CurrentShapes._NULL;
        public Shape selectedShape;
        public Shapes shapes = new Shapes();
        public Shapes shapesHistory = new Shapes();
        public event ModelChangedEventHandler ModelChanged;
        public event Action<IState> StateChanged;
        public delegate void ModelChangedEventHandler();
        public List<string> shapeText = new List<string>();
        public List<Line> lineList = new List<Line>();
        Factory factory = new Factory();
        // 宣告狀態物件
        IState pointerState;
        IState drawingState;
        IState lineState;
        // 直接用reference作為狀態變數
        IState currentState;
        
        public Model() {
            pointerState = new PointerState();
            // 建立drawingState物件，令DrawingState知道PointerState
            drawingState = new DrawingState((PointerState)pointerState);

            lineState = new LineState();
            // 預設為PointerState
            EnterPointerState();
        }
        public void NotifyObserver()
        {
            ModelChanged?.Invoke();
        }
        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
            StateChanged?.Invoke(currentState);
        }

        public void EnterDrawingState()
        {
            drawingState.Initialize(this);
            currentState = drawingState;
            StateChanged?.Invoke(currentState);
        }

        public void EnterLineState()
        {
            lineState.Initialize(this);
            currentState = lineState;
            StateChanged?.Invoke(currentState);
        }
        public void MouseDown(Point point)
        {
            currentState.MouseDown(this, point);
        }
        
        public void MouseMove(Point point)
        {
            currentState.MouseMove(this, point);
        }

        public void MouseUp(Point point)
        {
            
            currentState.MouseUp(this, point);
            NotifyObserver();
        }

        public void OnPaint(Graphics g)
        {
            currentState.OnPaint(this, g);
        }
        public void BuildShape(string shapeName, string text, string x, string y, string height, string width)
        {
            int.TryParse(x, out int resultX); int.TryParse(y, out int resultY);
            int.TryParse(height, out int resultH); int.TryParse(width, out int resultW);
            Shape shape = factory.CreateShape(shapeName, text, resultX, resultY, resultH, resultW);
            commandManager.Execute(new AddCommand(this, shape));
            if (shapes.GetShapeCount() > shapesHistory.GetShapeCount())
            {
                shapesHistory.AddShape(shape);
            }
            NotifyObserver();
            
        }

        public bool IsPointerButtonChecked
        {
            get { return currentState == pointerState; }
        }

        public bool IsDrawingButtonChecked
        {
            get { return currentState == drawingState; }
        }
        public bool IsLineButtonChecked
        {
            get { return currentState == lineState; }
        }
        public void DeleteShape(int index)
        {
            shapes.DeleteShape(index);
            NotifyObserver();
        }
        public void DeleteHistoryShape(int index)
        {
            shapesHistory.DeleteShape(index);
            NotifyObserver();
        }
        public void ChangeCurrentShape(int shapeIndex)
        {
            switch (shapeIndex)
            {
                case ((int)CurrentShapes.START):
                    currentShape = CurrentShapes.START;
                    break;
                case ((int)CurrentShapes.TERMINATOR):
                    currentShape = CurrentShapes.TERMINATOR;
                    break;
                case ((int)CurrentShapes.PROCESS):
                    currentShape = CurrentShapes.PROCESS;
                    break;
                case ((int)CurrentShapes.DECISION):
                    currentShape = CurrentShapes.DECISION;
                    break;
                default:
                    currentShape = CurrentShapes._NULL;
                    break;
            }
            
        }
        public string IsInTexBoundingBox(Point point)
        {
            foreach (Shape shape in shapes.shapeList)
            {
                if (shape.IsPointInText(point))
                {
                    selectedShape = shape;
                    return shape.shapeText;
                }
            }
            return null;
            
        }

        public void addLine(Line newLine)
        {
            lineList.Add(newLine);
        }
        public void removeLine(Line newLine)
        {
            lineList.Remove(newLine);
        }
    }
}


