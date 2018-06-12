namespace CSMDbgEvaluateFunction
{
    partial class ProcessSelector
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstProcess = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.radLaunchApplication = new System.Windows.Forms.RadioButton();
            this.tbApplicationPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.radDebugRunningProcess = new System.Windows.Forms.RadioButton();
            this.lbNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstProcess
            // 
            this.lstProcess.DisplayMember = "ProcessName";
            this.lstProcess.FormattingEnabled = true;
            this.lstProcess.Location = new System.Drawing.Point(42, 103);
            this.lstProcess.Name = "lstProcess";
            this.lstProcess.Size = new System.Drawing.Size(483, 277);
            this.lstProcess.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(450, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(532, 103);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radLaunchApplication
            // 
            this.radLaunchApplication.AutoSize = true;
            this.radLaunchApplication.Checked = true;
            this.radLaunchApplication.Location = new System.Drawing.Point(23, 13);
            this.radLaunchApplication.Name = "radLaunchApplication";
            this.radLaunchApplication.Size = new System.Drawing.Size(175, 17);
            this.radLaunchApplication.TabIndex = 6;
            this.radLaunchApplication.TabStop = true;
            this.radLaunchApplication.Text = "Launch an application to debug";
            this.radLaunchApplication.UseVisualStyleBackColor = true;
            // 
            // tbApplicationPath
            // 
            this.tbApplicationPath.Location = new System.Drawing.Point(42, 37);
            this.tbApplicationPath.Name = "tbApplicationPath";
            this.tbApplicationPath.ReadOnly = true;
            this.tbApplicationPath.Size = new System.Drawing.Size(483, 20);
            this.tbApplicationPath.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(532, 34);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // radDebugRunningProcess
            // 
            this.radDebugRunningProcess.AutoSize = true;
            this.radDebugRunningProcess.Location = new System.Drawing.Point(23, 80);
            this.radDebugRunningProcess.Name = "radDebugRunningProcess";
            this.radDebugRunningProcess.Size = new System.Drawing.Size(144, 17);
            this.radDebugRunningProcess.TabIndex = 6;
            this.radDebugRunningProcess.TabStop = true;
            this.radDebugRunningProcess.Text = "Debug a running process";
            this.radDebugRunningProcess.UseVisualStyleBackColor = true;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(39, 397);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(307, 26);
            this.lbNote.TabIndex = 9;
            this.lbNote.Text = "NOTE:\r\nMake sure that the application has symbol file and source code.";
            // 
            // ProcessSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 435);
            this.ControlBox = false;
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbApplicationPath);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.radDebugRunningProcess);
            this.Controls.Add(this.radLaunchApplication);
            this.Controls.Add(this.lstProcess);
            this.Name = "ProcessSelector";
            this.Text = "ProcessSelector";
            this.Load += new System.EventHandler(this.ProcessSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProcess;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton radLaunchApplication;
        private System.Windows.Forms.TextBox tbApplicationPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton radDebugRunningProcess;
        private System.Windows.Forms.Label lbNote;
    }
}