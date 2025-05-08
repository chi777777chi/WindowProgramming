using System;
using System.Drawing;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HW2
{
    public class EditTextDialog : Form
    {
        private Button okButton;
        private TextBox textBox;
        private System.ComponentModel.IContainer components;
        private Button cancelButton;
        private string originalText;
        public string EditedText { get; private set; }

        public EditTextDialog(string currentText)
        {
            originalText = currentText;
            InitializeComponent();
            textBox.Text = currentText;
        }

        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(56, 146);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(150, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(56, 103);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(169, 25);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // EditTextDialog
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "EditTextDialog";
            this.Text = "文字編輯方塊";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            EditedText = textBox.Text;          // 將 TextBox 的內容儲存到屬性中
            this.DialogResult = DialogResult.OK; // 設置對話框的結果為 OK
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 設置對話框的結果為 Cancel
            this.Close();                            // 關閉視窗
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrWhiteSpace(textBox.Text) && textBox.Text != originalText;
        }
    }
}
