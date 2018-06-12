namespace CSMDbgEvaluateFunction
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (this.managedProcess != null))
            {
               var thread = MTAThreadHelper.RunInMTAThread( managedProcess.Dispose);
               thread.Join();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbApplicationToDebug = new System.Windows.Forms.Label();
            this.lbProcess = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.pnlOperation = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.pnlEvaluate = new System.Windows.Forms.Panel();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.cmbExpression = new System.Windows.Forms.ComboBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbExpression = new System.Windows.Forms.Label();
            this.pnlVariable = new System.Windows.Forms.Panel();
            this.dgVariable = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbVariables = new System.Windows.Forms.Label();
            this.pnlThreads = new System.Windows.Forms.Panel();
            this.dgThread = new System.Windows.Forms.DataGridView();
            this.colThreadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourcePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlThreadsLabel = new System.Windows.Forms.Panel();
            this.lbThreads = new System.Windows.Forms.Label();
            this.pnlOperation.SuspendLayout();
            this.pnlEvaluate.SuspendLayout();
            this.pnlVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVariable)).BeginInit();
            this.pnlThreads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgThread)).BeginInit();
            this.pnlThreadsLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbApplicationToDebug
            // 
            this.lbApplicationToDebug.AutoSize = true;
            this.lbApplicationToDebug.Location = new System.Drawing.Point(12, 9);
            this.lbApplicationToDebug.Name = "lbApplicationToDebug";
            this.lbApplicationToDebug.Size = new System.Drawing.Size(113, 13);
            this.lbApplicationToDebug.TabIndex = 0;
            this.lbApplicationToDebug.Text = "Application To Debug:";
            // 
            // lbProcess
            // 
            this.lbProcess.AutoSize = true;
            this.lbProcess.Location = new System.Drawing.Point(150, 9);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(0, 13);
            this.lbProcess.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(15, 25);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(110, 25);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // pnlOperation
            // 
            this.pnlOperation.Controls.Add(this.btnDetach);
            this.pnlOperation.Controls.Add(this.lbApplicationToDebug);
            this.pnlOperation.Controls.Add(this.btnContinue);
            this.pnlOperation.Controls.Add(this.lbProcess);
            this.pnlOperation.Controls.Add(this.btnStop);
            this.pnlOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperation.Location = new System.Drawing.Point(0, 0);
            this.pnlOperation.Name = "pnlOperation";
            this.pnlOperation.Size = new System.Drawing.Size(749, 73);
            this.pnlOperation.TabIndex = 3;
            // 
            // btnDetach
            // 
            this.btnDetach.Location = new System.Drawing.Point(210, 24);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(75, 23);
            this.btnDetach.TabIndex = 3;
            this.btnDetach.Text = "Detach";
            this.btnDetach.UseVisualStyleBackColor = true;
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // pnlEvaluate
            // 
            this.pnlEvaluate.Controls.Add(this.tbResult);
            this.pnlEvaluate.Controls.Add(this.cmbExpression);
            this.pnlEvaluate.Controls.Add(this.lbResult);
            this.pnlEvaluate.Controls.Add(this.btnEvaluate);
            this.pnlEvaluate.Controls.Add(this.lbDescription);
            this.pnlEvaluate.Controls.Add(this.lbExpression);
            this.pnlEvaluate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEvaluate.Location = new System.Drawing.Point(0, 396);
            this.pnlEvaluate.Name = "pnlEvaluate";
            this.pnlEvaluate.Size = new System.Drawing.Size(749, 208);
            this.pnlEvaluate.TabIndex = 4;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(267, 45);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(392, 160);
            this.tbResult.TabIndex = 8;
            // 
            // cmbExpression
            // 
            this.cmbExpression.FormattingEnabled = true;
            this.cmbExpression.Items.AddRange(new object[] {
            "this.IntegerMethod(100)",
            "this.StringMethod(\"Hello World\")",
            "this.GenericMethod([3,4])",
            "System.Diagnostics.Process.GetCurrentProcess()"});
            this.cmbExpression.Location = new System.Drawing.Point(267, 11);
            this.cmbExpression.Name = "cmbExpression";
            this.cmbExpression.Size = new System.Drawing.Size(392, 21);
            this.cmbExpression.TabIndex = 6;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(207, 45);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(37, 13);
            this.lbResult.TabIndex = 5;
            this.lbResult.Text = "Result";
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Enabled = false;
            this.btnEvaluate.Location = new System.Drawing.Point(671, 14);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(75, 23);
            this.btnEvaluate.TabIndex = 2;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(3, 14);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(198, 117);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = resources.GetString("lbDescription.Text");
            // 
            // lbExpression
            // 
            this.lbExpression.AutoSize = true;
            this.lbExpression.Location = new System.Drawing.Point(203, 14);
            this.lbExpression.Name = "lbExpression";
            this.lbExpression.Size = new System.Drawing.Size(58, 13);
            this.lbExpression.TabIndex = 0;
            this.lbExpression.Text = "Expression";
            // 
            // pnlVariable
            // 
            this.pnlVariable.Controls.Add(this.dgVariable);
            this.pnlVariable.Controls.Add(this.lbVariables);
            this.pnlVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVariable.Location = new System.Drawing.Point(0, 185);
            this.pnlVariable.Name = "pnlVariable";
            this.pnlVariable.Size = new System.Drawing.Size(749, 211);
            this.pnlVariable.TabIndex = 5;
            // 
            // dgVariable
            // 
            this.dgVariable.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVariable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVariable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVariable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColType,
            this.ColValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVariable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVariable.Location = new System.Drawing.Point(0, 13);
            this.dgVariable.Name = "dgVariable";
            this.dgVariable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVariable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVariable.RowHeadersVisible = false;
            this.dgVariable.Size = new System.Drawing.Size(749, 198);
            this.dgVariable.TabIndex = 0;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColType
            // 
            this.ColType.DataPropertyName = "Type";
            this.ColType.HeaderText = "Type";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            this.ColType.Width = 300;
            // 
            // ColValue
            // 
            this.ColValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColValue.DataPropertyName = "Value";
            this.ColValue.HeaderText = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            // 
            // lbVariables
            // 
            this.lbVariables.AutoSize = true;
            this.lbVariables.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbVariables.Location = new System.Drawing.Point(0, 0);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.Size = new System.Drawing.Size(50, 13);
            this.lbVariables.TabIndex = 1;
            this.lbVariables.Text = "Variables";
            // 
            // pnlThreads
            // 
            this.pnlThreads.Controls.Add(this.dgThread);
            this.pnlThreads.Controls.Add(this.pnlThreadsLabel);
            this.pnlThreads.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThreads.Location = new System.Drawing.Point(0, 73);
            this.pnlThreads.Name = "pnlThreads";
            this.pnlThreads.Size = new System.Drawing.Size(749, 112);
            this.pnlThreads.TabIndex = 5;
            // 
            // dgThread
            // 
            this.dgThread.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgThread.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgThread.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgThread.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThreadID,
            this.colFunction,
            this.colSourcePosition});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgThread.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgThread.Location = new System.Drawing.Point(0, 26);
            this.dgThread.MultiSelect = false;
            this.dgThread.Name = "dgThread";
            this.dgThread.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgThread.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgThread.RowHeadersVisible = false;
            this.dgThread.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgThread.Size = new System.Drawing.Size(749, 86);
            this.dgThread.TabIndex = 0;
            this.dgThread.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgThread_CellClick);
            // 
            // colThreadID
            // 
            this.colThreadID.DataPropertyName = "ThreadID";
            this.colThreadID.HeaderText = "Thread ID";
            this.colThreadID.Name = "colThreadID";
            this.colThreadID.ReadOnly = true;
            // 
            // colFunction
            // 
            this.colFunction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFunction.DataPropertyName = "Function";
            this.colFunction.HeaderText = "Function";
            this.colFunction.Name = "colFunction";
            this.colFunction.ReadOnly = true;
            // 
            // colSourcePosition
            // 
            this.colSourcePosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSourcePosition.DataPropertyName = "SourcePosition";
            this.colSourcePosition.HeaderText = "SourcePosition";
            this.colSourcePosition.Name = "colSourcePosition";
            this.colSourcePosition.ReadOnly = true;
            // 
            // pnlThreadsLabel
            // 
            this.pnlThreadsLabel.Controls.Add(this.lbThreads);
            this.pnlThreadsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThreadsLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlThreadsLabel.Name = "pnlThreadsLabel";
            this.pnlThreadsLabel.Size = new System.Drawing.Size(749, 26);
            this.pnlThreadsLabel.TabIndex = 2;
            // 
            // lbThreads
            // 
            this.lbThreads.AutoSize = true;
            this.lbThreads.Location = new System.Drawing.Point(3, 2);
            this.lbThreads.Name = "lbThreads";
            this.lbThreads.Size = new System.Drawing.Size(289, 13);
            this.lbThreads.TabIndex = 1;
            this.lbThreads.Text = "Click a Thread to see the variables and evaluate a function.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 604);
            this.Controls.Add(this.pnlVariable);
            this.Controls.Add(this.pnlThreads);
            this.Controls.Add(this.pnlEvaluate);
            this.Controls.Add(this.pnlOperation);
            this.Name = "MainForm";
            this.Text = "CSMDbgEvaluateFunction";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlOperation.ResumeLayout(false);
            this.pnlOperation.PerformLayout();
            this.pnlEvaluate.ResumeLayout(false);
            this.pnlEvaluate.PerformLayout();
            this.pnlVariable.ResumeLayout(false);
            this.pnlVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVariable)).EndInit();
            this.pnlThreads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgThread)).EndInit();
            this.pnlThreadsLabel.ResumeLayout(false);
            this.pnlThreadsLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbApplicationToDebug;
        private System.Windows.Forms.Label lbProcess;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel pnlOperation;
        private System.Windows.Forms.Panel pnlEvaluate;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.Panel pnlVariable;
        private System.Windows.Forms.DataGridView dgVariable;
        private System.Windows.Forms.Panel pnlThreads;
        private System.Windows.Forms.DataGridView dgThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourcePosition;
        private System.Windows.Forms.Label lbExpression;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.ComboBox cmbExpression;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbVariables;
        private System.Windows.Forms.Panel pnlThreadsLabel;
        private System.Windows.Forms.Label lbThreads;
        private System.Windows.Forms.Button btnDetach;
    }
}

