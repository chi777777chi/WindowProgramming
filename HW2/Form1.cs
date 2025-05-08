using HW2.Command;
using HW2.State;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Model model;
        private PresentationModel pModel;
        private FormGraphicAdapter formGraphics;
        private bool isDrawing = false;
        private Point startPoint, endPoint;
        ToolStripButton drawingModeButton;
        ToolStripButton pointerModeButton;
        private string currentText;
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic, null, panel1, new object[] { true });
            model = new Model();
            pModel = new PresentationModel(model);
            pModel.DataChanged += UpdateView;
            pModel.DrawShape += Invalidate;
            pModel.ShowDialog += PromptForText;
            Undo.Enabled = pModel.IsUndoEnabled;
            Redo.Enabled = pModel.IsRedoEnabled;

            pModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(PresentationModel.IsUndoEnabled))
                    Undo.Enabled = pModel.IsUndoEnabled;
                if (e.PropertyName == nameof(PresentationModel.IsRedoEnabled))
                    Redo.Enabled = pModel.IsRedoEnabled;
            };

            AddButton.DataBindings.Add("Enabled", pModel, "IsAddButtonEnabled");
            ShapeDecide.DataBindings.Add("ForeColor", pModel, "ShapeChangedColor");
            textLabel.DataBindings.Add("ForeColor", pModel, "DescribtionColor");
            xLabel.DataBindings.Add("ForeColor", pModel, "XInputTextColor");
            yLabel.DataBindings.Add("ForeColor", pModel, "YInputTextColor");
            hLabel.DataBindings.Add("ForeColor", pModel, "HInputTextColor");
            wLabel.DataBindings.Add("ForeColor", pModel, "WInputTextColor");
            model.EnterPointerState();
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            model.MouseDown(e.Location);  // 更新模型狀態
            panel1.Invalidate();          // 觸發 Panel 重繪
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            model.MouseMove(e.Location);  // 更新模型狀態
            panel1.Invalidate();          // 觸發 Panel 重繪
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            model.MouseUp(e.Location);    // 更新模型狀態
            panel1.Invalidate();          // 觸發 Panel 重繪
            UpdateGridView();
        }
        private void PointerModeHandler(Object sender, EventArgs e)
        {
            pModel.PointerState();
            model.EnterPointerState();
            RefreshControls();
        }
        public void UpdateView(string data)
        {
            pModel.UpdateUndoRedo();
            Invalidate();
        }

        //刪除圖形
        private void ShapesINFOGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ShapesINFOGridView.Rows.RemoveAt(e.RowIndex);
                model.commandManager.Execute(new DeleteCommand(model,e.RowIndex));
                //model.DeleteShape(e.RowIndex);
                UpdateGridView();
                panel1.Invalidate();
            }
            
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            model.BuildShape(ShapeDecide.Text, DescribtionInput.Text ,XInput.Text, YInput.Text, HInput.Text, WInput.Text);
            UpdateGridView();
            panel1.Invalidate();
        }

        private void UpdateGridView()
        {
            ShapesINFOGridView.Rows.Clear();
            for (int i = 0; i < model.shapes.shapeList.Count; i++)
            {
                var shape = model.shapes.GetShapeByIndex(i);
                ShapesINFOGridView.Rows.Add("刪除", (i + 1).ToString(), shape.shapeName, shape.shapeText, shape.x, shape.y, shape.height, shape.width);
            }
        }
        private void ShapeDecide_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ShapeDecide.SelectedItem.ToString();
            pModel.ShapeDecide_SelectedIndexChanged(selectedValue);
        }

        private void toolStart_Click(object sender, EventArgs e)
        {
            pModel.Start();
            model.ChangeCurrentShape(0);
            Cursor = Cursors.Cross;
            model.EnterDrawingState();
            RefreshControls();
        }
        private void toolTerminator_Click(object sender, EventArgs e)
        {
            pModel.Termination();
            model.ChangeCurrentShape(1);
            Cursor = Cursors.Cross;
            model.EnterDrawingState();
            RefreshControls();
        }
        private void toolProcess_Click(object sender, EventArgs e)
        {
            pModel.Process();
            model.ChangeCurrentShape(2);
            Cursor = Cursors.Cross;
            model.EnterDrawingState();
            RefreshControls();
        }

        private void toolDecision_Click(object sender, EventArgs e)
        {
            pModel.Decision();
            model.ChangeCurrentShape(3);
            Cursor = Cursors.Cross;
            model.EnterDrawingState();
            RefreshControls();
        }
        private void XInput_TextChanged(object sender, EventArgs e)
        {
            pModel.XInput_TextChanged(XInput.Text);
        }
        private void YInput_TextChanged(object sender, EventArgs e)
        {
            pModel.YInput_TextChanged(YInput.Text);
        }

        private void HInput_TextChanged(object sender, EventArgs e)
        {
            pModel.HInput_TextChanged(HInput.Text);
        }
        private void WInput_TextChanged(object sender, EventArgs e)
        {
            pModel.WInput_TextChanged(WInput.Text);
        }
        private void DescribtionInput_TextChanged(object sender, EventArgs e)
        {
            pModel.DescribtionInput_TextChanged(DescribtionInput.Text);
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            model.OnPaint(e.Graphics);
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            pModel.DoUndo();
            UpdateGridView();
            panel1.Invalidate();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            pModel.DoRedo();
            UpdateGridView();
            panel1.Invalidate();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pModel.CheckIsInTexBoundingBox(e.Location);
        }

        private void RefreshControls()
        {
            toolStart.Checked = pModel.IsStartEnabled();
            toolTerminator.Checked = pModel.IsTerminatorEnabled();
            toolProcess.Checked = pModel.IsProcessEnabled();
            toolDecision.Checked = pModel.IsDecisionEnabled();
            PointerButton.Checked = pModel.IsPointerEnabled();
            lineButton.Checked = pModel.IsLineEnabled();
            Invalidate();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            pModel.Line();
            model.EnterLineState();
            RefreshControls();
        }

        private void PromptForText()
        {
            using (EditTextDialog dialog = new EditTextDialog(pModel.currentText))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //currentText = dialog.EditedText;
                    pModel.ChangeText(dialog.EditedText);
                    UpdateGridView();
                }
                
            }
            return;
        }

    }
}

