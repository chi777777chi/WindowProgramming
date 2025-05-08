namespace HW2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ShapesINFOGridView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShapeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShapeDecide = new System.Windows.Forms.ComboBox();
            this.DescribtionInput = new System.Windows.Forms.TextBox();
            this.YInput = new System.Windows.Forms.TextBox();
            this.HInput = new System.Windows.Forms.TextBox();
            this.WInput = new System.Windows.Forms.TextBox();
            this.DataCombo = new System.Windows.Forms.GroupBox();
            this.wLabel = new System.Windows.Forms.Label();
            this.hLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.XInput = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.Page1 = new System.Windows.Forms.Button();
            this.Page2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.toolTerminator = new System.Windows.Forms.ToolStripButton();
            this.toolProcess = new System.Windows.Forms.ToolStripButton();
            this.toolDecision = new System.Windows.Forms.ToolStripButton();
            this.PointerButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.Undo = new System.Windows.Forms.ToolStripButton();
            this.Redo = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ShapesINFOGridView)).BeginInit();
            this.DataCombo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShapesINFOGridView
            // 
            this.ShapesINFOGridView.AllowUserToAddRows = false;
            this.ShapesINFOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShapesINFOGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteButton,
            this.ID,
            this.Shape,
            this.ShapeText,
            this.PositionX,
            this.PositionY,
            this.Height,
            this.Width});
            this.ShapesINFOGridView.Location = new System.Drawing.Point(13, 56);
            this.ShapesINFOGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShapesINFOGridView.Name = "ShapesINFOGridView";
            this.ShapesINFOGridView.RowHeadersVisible = false;
            this.ShapesINFOGridView.RowHeadersWidth = 51;
            this.ShapesINFOGridView.RowTemplate.Height = 27;
            this.ShapesINFOGridView.Size = new System.Drawing.Size(433, 482);
            this.ShapesINFOGridView.TabIndex = 0;
            this.ShapesINFOGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapesINFOGridView_CellContentClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "刪除";
            this.DeleteButton.MinimumWidth = 6;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Width = 30;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "形狀";
            this.Shape.MinimumWidth = 6;
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            this.Shape.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Shape.Width = 40;
            // 
            // ShapeText
            // 
            this.ShapeText.HeaderText = "文字";
            this.ShapeText.MinimumWidth = 6;
            this.ShapeText.Name = "ShapeText";
            this.ShapeText.ReadOnly = true;
            this.ShapeText.Width = 70;
            // 
            // PositionX
            // 
            this.PositionX.HeaderText = "X";
            this.PositionX.MinimumWidth = 6;
            this.PositionX.Name = "PositionX";
            this.PositionX.ReadOnly = true;
            this.PositionX.Width = 40;
            // 
            // PositionY
            // 
            this.PositionY.HeaderText = "Y";
            this.PositionY.MinimumWidth = 6;
            this.PositionY.Name = "PositionY";
            this.PositionY.ReadOnly = true;
            this.PositionY.Width = 40;
            // 
            // Height
            // 
            this.Height.HeaderText = "H";
            this.Height.MinimumWidth = 6;
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            this.Height.Width = 40;
            // 
            // Width
            // 
            this.Width.HeaderText = "W";
            this.Width.MinimumWidth = 6;
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.Width = 40;
            // 
            // ShapeDecide
            // 
            this.ShapeDecide.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ShapeDecide.FormattingEnabled = true;
            this.ShapeDecide.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.ShapeDecide.Location = new System.Drawing.Point(107, 28);
            this.ShapeDecide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShapeDecide.Name = "ShapeDecide";
            this.ShapeDecide.Size = new System.Drawing.Size(64, 23);
            this.ShapeDecide.TabIndex = 1;
            this.ShapeDecide.Text = "形狀";
            this.ShapeDecide.SelectedIndexChanged += new System.EventHandler(this.ShapeDecide_SelectedIndexChanged);
            // 
            // DescribtionInput
            // 
            this.DescribtionInput.Location = new System.Drawing.Point(176, 28);
            this.DescribtionInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescribtionInput.Name = "DescribtionInput";
            this.DescribtionInput.Size = new System.Drawing.Size(76, 25);
            this.DescribtionInput.TabIndex = 2;
            this.DescribtionInput.TextChanged += new System.EventHandler(this.DescribtionInput_TextChanged);
            // 
            // YInput
            // 
            this.YInput.Location = new System.Drawing.Point(311, 28);
            this.YInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YInput.Name = "YInput";
            this.YInput.Size = new System.Drawing.Size(33, 25);
            this.YInput.TabIndex = 4;
            this.YInput.TextChanged += new System.EventHandler(this.YInput_TextChanged);
            // 
            // HInput
            // 
            this.HInput.Location = new System.Drawing.Point(349, 28);
            this.HInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HInput.Name = "HInput";
            this.HInput.Size = new System.Drawing.Size(33, 25);
            this.HInput.TabIndex = 5;
            this.HInput.TextChanged += new System.EventHandler(this.HInput_TextChanged);
            // 
            // WInput
            // 
            this.WInput.Location = new System.Drawing.Point(389, 28);
            this.WInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WInput.Name = "WInput";
            this.WInput.Size = new System.Drawing.Size(33, 25);
            this.WInput.TabIndex = 6;
            this.WInput.TextChanged += new System.EventHandler(this.WInput_TextChanged);
            // 
            // DataCombo
            // 
            this.DataCombo.Controls.Add(this.wLabel);
            this.DataCombo.Controls.Add(this.hLabel);
            this.DataCombo.Controls.Add(this.yLabel);
            this.DataCombo.Controls.Add(this.xLabel);
            this.DataCombo.Controls.Add(this.textLabel);
            this.DataCombo.Controls.Add(this.XInput);
            this.DataCombo.Controls.Add(this.AddButton);
            this.DataCombo.Controls.Add(this.ShapesINFOGridView);
            this.DataCombo.Controls.Add(this.WInput);
            this.DataCombo.Controls.Add(this.ShapeDecide);
            this.DataCombo.Controls.Add(this.HInput);
            this.DataCombo.Controls.Add(this.DescribtionInput);
            this.DataCombo.Controls.Add(this.YInput);
            this.DataCombo.Location = new System.Drawing.Point(708, 64);
            this.DataCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataCombo.Name = "DataCombo";
            this.DataCombo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataCombo.Size = new System.Drawing.Size(447, 495);
            this.DataCombo.TabIndex = 7;
            this.DataCombo.TabStop = false;
            this.DataCombo.Text = "資料顯示";
            // 
            // wLabel
            // 
            this.wLabel.AutoSize = true;
            this.wLabel.Location = new System.Drawing.Point(394, 10);
            this.wLabel.Name = "wLabel";
            this.wLabel.Size = new System.Drawing.Size(20, 15);
            this.wLabel.TabIndex = 13;
            this.wLabel.Text = "W";
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.Location = new System.Drawing.Point(355, 10);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(17, 15);
            this.hLabel.TabIndex = 12;
            this.hLabel.Text = "H";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(316, 10);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 15);
            this.yLabel.TabIndex = 11;
            this.yLabel.Text = "Y";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(274, 11);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 15);
            this.xLabel.TabIndex = 10;
            this.xLabel.Text = "X";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(192, 11);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(37, 15);
            this.textLabel.TabIndex = 9;
            this.textLabel.Text = "文字";
            // 
            // XInput
            // 
            this.XInput.Location = new System.Drawing.Point(268, 28);
            this.XInput.Name = "XInput";
            this.XInput.Size = new System.Drawing.Size(37, 25);
            this.XInput.TabIndex = 8;
            this.XInput.TextChanged += new System.EventHandler(this.XInput_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(11, 18);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 32);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "新增";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Page1
            // 
            this.Page1.Location = new System.Drawing.Point(12, 80);
            this.Page1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(92, 78);
            this.Page1.TabIndex = 8;
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // Page2
            // 
            this.Page2.Location = new System.Drawing.Point(13, 163);
            this.Page2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(91, 78);
            this.Page2.TabIndex = 9;
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1167, 30);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Silver;
            this.richTextBox1.Location = new System.Drawing.Point(0, 64);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(115, 493);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStart,
            this.toolTerminator,
            this.toolProcess,
            this.toolDecision,
            this.PointerButton,
            this.lineButton,
            this.Undo,
            this.Redo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1167, 31);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStart
            // 
            this.toolStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStart.Image")));
            this.toolStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStart.Name = "toolStart";
            this.toolStart.Size = new System.Drawing.Size(29, 28);
            this.toolStart.Text = "start";
            this.toolStart.Click += new System.EventHandler(this.toolStart_Click);
            // 
            // toolTerminator
            // 
            this.toolTerminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTerminator.Image = ((System.Drawing.Image)(resources.GetObject("toolTerminator.Image")));
            this.toolTerminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTerminator.Name = "toolTerminator";
            this.toolTerminator.Size = new System.Drawing.Size(29, 28);
            this.toolTerminator.Text = "terminator";
            this.toolTerminator.Click += new System.EventHandler(this.toolTerminator_Click);
            // 
            // toolProcess
            // 
            this.toolProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolProcess.Image = ((System.Drawing.Image)(resources.GetObject("toolProcess.Image")));
            this.toolProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolProcess.Name = "toolProcess";
            this.toolProcess.Size = new System.Drawing.Size(29, 28);
            this.toolProcess.Text = "process";
            this.toolProcess.Click += new System.EventHandler(this.toolProcess_Click);
            // 
            // toolDecision
            // 
            this.toolDecision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDecision.Image = ((System.Drawing.Image)(resources.GetObject("toolDecision.Image")));
            this.toolDecision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDecision.Name = "toolDecision";
            this.toolDecision.Size = new System.Drawing.Size(29, 28);
            this.toolDecision.Text = "decision";
            this.toolDecision.Click += new System.EventHandler(this.toolDecision_Click);
            // 
            // PointerButton
            // 
            this.PointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PointerButton.Image = ((System.Drawing.Image)(resources.GetObject("PointerButton.Image")));
            this.PointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PointerButton.Name = "PointerButton";
            this.PointerButton.Size = new System.Drawing.Size(29, 28);
            this.PointerButton.Text = "toolStripButton1";
            this.PointerButton.Click += new System.EventHandler(this.PointerModeHandler);
            // 
            // lineButton
            // 
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(29, 28);
            this.lineButton.Text = "line";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // Undo
            // 
            this.Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Undo.Image = ((System.Drawing.Image)(resources.GetObject("Undo.Image")));
            this.Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(29, 28);
            this.Undo.Text = "Undo";
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Redo
            // 
            this.Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Redo.Image = ((System.Drawing.Image)(resources.GetObject("Redo.Image")));
            this.Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(29, 28);
            this.Redo.Text = "Redo";
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(111, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 490);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 536);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Page2);
            this.Controls.Add(this.Page1);
            this.Controls.Add(this.DataCombo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.richTextBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "MyDrawing";
            ((System.ComponentModel.ISupportInitialize)(this.ShapesINFOGridView)).EndInit();
            this.DataCombo.ResumeLayout(false);
            this.DataCombo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ShapesINFOGridView;
        private System.Windows.Forms.ComboBox ShapeDecide;
        private System.Windows.Forms.TextBox DescribtionInput;
        private System.Windows.Forms.TextBox YInput;
        private System.Windows.Forms.TextBox HInput;
        private System.Windows.Forms.TextBox WInput;
        private System.Windows.Forms.GroupBox DataCombo;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button Page1;
        private System.Windows.Forms.Button Page2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShapeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.TextBox XInput;
        private System.Windows.Forms.Label wLabel;
        private System.Windows.Forms.Label hLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripButton toolTerminator;
        private System.Windows.Forms.ToolStripButton toolProcess;
        private System.Windows.Forms.ToolStripButton toolDecision;
        private System.Windows.Forms.ToolStripButton PointerButton;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton Undo;
        private System.Windows.Forms.ToolStripButton Redo;
    }
}

