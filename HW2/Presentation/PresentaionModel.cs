using HW2.Command;
using HW2.State;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HW2
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string currentText;
        private bool isAddButtonEnabled = false;
        //shapeInformationInput
        public  bool isShapeChanged = false;
        public  bool isDescribtionChanged = false;
        public  bool isXInputTextChanged = false;
        public  bool isYInputTextChanged = false;
        public  bool isHInputTextChanged = false;
        public  bool isWInputTextChanged = false;
        //DrawingState
        private bool isStartEnabled = false;
        private bool isTerminatorEnabled = false;
        private bool isProcessEnabled = false;
        private bool isDecisionEnabled = false;
        private bool isLineEnabled = false;
        //PointerState
        private bool isPointerEnabled = false;
        //Command
        private bool isUndoEnabled = false;
        private bool isRedoEnabled = false;
        private readonly Model model;

        public event Action<string> DataChanged;
        public event Action DrawShape;
        public event Action ShowDialog;
        public PresentationModel(Model model)
        {
            this.model = model;
            model.ModelChanged += ModelDataChanged;
            model.StateChanged += OnStateChanged;
        }
        
        private void OnStateChanged(IState newState)
        {
            // 根據新狀態更新 PresentationModel 的邏輯
            if (newState is PointerState)
            {
                UpdateState(start: false, terminator: false, process: false, decision: false);
                isPointerEnabled = true;
            }

            // 通知 UI 更新
            Notify("CurrentState");
        }
        private void ModelDataChanged()
        {
            DataChanged?.Invoke("");
        }

        public bool IsStartEnabled() => isStartEnabled;
        public bool IsTerminatorEnabled() => isTerminatorEnabled;
        public bool IsProcessEnabled() => isProcessEnabled;
        public bool IsDecisionEnabled() => isDecisionEnabled;
        public bool IsPointerEnabled() => isPointerEnabled;
        public bool IsLineEnabled() => isLineEnabled;
        public void DoUndo()
        {
            model.commandManager.Undo();
            model.NotifyObserver();
            UpdateUndoRedo();
        }
        public void DoRedo()
        {
            model.commandManager.Redo();
            model.NotifyObserver();
            UpdateUndoRedo();
        }
        private void UpdateState(bool start, bool terminator, bool process, bool decision)
        {
            isStartEnabled = start;
            isTerminatorEnabled = terminator;
            isProcessEnabled = process;
            isDecisionEnabled = decision;

            DataChanged?.Invoke(GetEnabledStatus());
            DrawShape?.Invoke();
        }
        public void UpdateUndoRedo()
        {
            isRedoEnabled = model.commandManager.IsRedoEnabled;
            isUndoEnabled = model.commandManager.IsUndoEnabled;
            Notify(nameof(IsUndoEnabled));
            Notify(nameof(IsRedoEnabled));
        }
        public void Line()
        {
            isLineEnabled = true;
            isPointerEnabled = false;
            UpdateState(start: false, terminator: false, process: false, decision: false);
        }
        public void Start()
        {
            isPointerEnabled = false;
            isLineEnabled = false;
            UpdateState(start: true, terminator: false, process: false, decision: false);
        }

        public void Termination()
        {
            isPointerEnabled = false;
            isLineEnabled = false;
            UpdateState(start: false, terminator: true, process: false, decision: false);
        }

        public void Process()
        {
            isPointerEnabled = false;
            isLineEnabled = false;
            UpdateState(start: false, terminator: false, process: true, decision: false);
        }

        public void Decision()
        {
            isPointerEnabled = false;
            isLineEnabled = false;
            UpdateState(start: false, terminator: false, process: false, decision: true);
        }
        public void PointerState() 
        {
            isLineEnabled = false;
            UpdateState(start: false, terminator: false, process: false, decision: false); 
            isPointerEnabled = true; 
        }
        public string GetEnabledStatus()
        {
            if (isStartEnabled) return "Start";
            if (isTerminatorEnabled) return "Terminator";
            if (isProcessEnabled) return "Process";
            if (isDecisionEnabled) return "Decision";
            return "None";
        }

        public void DescribtionInput_TextChanged(string text)
        {
            isDescribtionChanged = !string.IsNullOrEmpty(text);
            Notify(nameof(isDescribtionChanged));
            Notify(nameof(DescribtionColor));
            CheckInputEnabled();
        }
        public void XInput_TextChanged(string text)
        {
            if (int.TryParse(text, out int value) && value > 0)
            {
                isXInputTextChanged = true;
            }
            else
            {
                isXInputTextChanged = false;
            }
            Notify(nameof(isXInputTextChanged));
            Notify(nameof(XInputTextColor));
            CheckInputEnabled();
        }
        public void YInput_TextChanged(string text)
        {
            if (int.TryParse(text, out int value) && value > 0)
            {
                isYInputTextChanged = true;
            }
            else
            {
                isYInputTextChanged = false;
            }
            Notify(nameof(isYInputTextChanged));
            Notify(nameof(YInputTextColor));
            CheckInputEnabled();
        }
        public void HInput_TextChanged(string text)
        {
            if (int.TryParse(text, out int value) && value > 0)
            {
                isHInputTextChanged = true;
            }
            else
            {
                isHInputTextChanged = false;
            }
            Notify(nameof(isHInputTextChanged));
            Notify(nameof(HInputTextColor));
            CheckInputEnabled();
        }
        public void WInput_TextChanged(string text)
        {
            if (int.TryParse(text, out int value) && value > 0)
            {
                isWInputTextChanged = true;
            }
            else
            {
                isWInputTextChanged = false;
            }

            Notify(nameof(isWInputTextChanged));
            Notify(nameof(WInputTextColor));
            CheckInputEnabled();
        }
        public void ShapeDecide_SelectedIndexChanged(string text)
        {
            isShapeChanged = text != "形狀";
            Notify(nameof(isShapeChanged));
            Notify(nameof(ShapeChangedColor));
            CheckInputEnabled();
        }
        public void CheckInputEnabled()
        {
            if (isXInputTextChanged == true && isYInputTextChanged == true &&
                isHInputTextChanged == true && isWInputTextChanged == true &&
                isDescribtionChanged == true && isShapeChanged == true)
            { 
                isAddButtonEnabled = true;
                Notify("isAddButtonEnabled");
            } 
        }
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsAddButtonEnabled
        {
            get { return isAddButtonEnabled; }
        }
        public bool IsLineButtonEnabled
        {
            get { return isLineEnabled; }
        }
        public Color ShapeChangedColor
        {
            get
            {
                return isShapeChanged ? Color.Black : Color.Red;
            }
        }
        public Color DescribtionColor
        {
            get
            {
                return isDescribtionChanged ? Color.Black : Color.Red;
            }
        }
        public Color XInputTextColor
        {
            get
            {
                return isXInputTextChanged ? Color.Black : Color.Red;
            }
        }
        public Color YInputTextColor
        {
            get
            {
                return isYInputTextChanged ? Color.Black : Color.Red;
            }
        }
        public Color HInputTextColor
        {
            get
            {
                return isHInputTextChanged ? Color.Black : Color.Red;
            }
        }
        public Color WInputTextColor
        {
            get
            {
                return isWInputTextChanged ? Color.Black : Color.Red;
            }
        }
        public bool IsUndoEnabled
        {
            get { return isUndoEnabled; }
        }
        public bool IsRedoEnabled
        {
            get { return isRedoEnabled; }
        }

        public void CheckIsInTexBoundingBox(Point point)
        {
            currentText = model.IsInTexBoundingBox(point);
            if (currentText != null)
            {
                ShowDialog?.Invoke();
            }
        }
        public void ChangeText(string newText)
        {
            model.commandManager.Execute(new TextChangedCommand(model,model.selectedShape, newText));
        }
    }
}
