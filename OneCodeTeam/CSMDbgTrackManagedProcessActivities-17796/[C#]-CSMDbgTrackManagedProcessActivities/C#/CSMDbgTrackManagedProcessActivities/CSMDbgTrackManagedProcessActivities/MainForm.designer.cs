namespace CSMDbgTrackManagedProcessActivities
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
            this.lbApplicationToDebug = new System.Windows.Forms.Label();
            this.lbProcess = new System.Windows.Forms.Label();
            this.pnlOperation = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.pnlThreads = new System.Windows.Forms.Panel();
            this.tbActivities = new System.Windows.Forms.TextBox();
            this.pnlOperation.SuspendLayout();
            this.pnlThreads.SuspendLayout();
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
            // pnlOperation
            // 
            this.pnlOperation.Controls.Add(this.btnDetach);
            this.pnlOperation.Controls.Add(this.lbApplicationToDebug);
            this.pnlOperation.Controls.Add(this.lbProcess);
            this.pnlOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperation.Location = new System.Drawing.Point(0, 0);
            this.pnlOperation.Name = "pnlOperation";
            this.pnlOperation.Size = new System.Drawing.Size(749, 34);
            this.pnlOperation.TabIndex = 3;
            // 
            // btnDetach
            // 
            this.btnDetach.Location = new System.Drawing.Point(637, 4);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(75, 23);
            this.btnDetach.TabIndex = 3;
            this.btnDetach.Text = "Detach";
            this.btnDetach.UseVisualStyleBackColor = true;
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // pnlThreads
            // 
            this.pnlThreads.Controls.Add(this.tbActivities);
            this.pnlThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThreads.Location = new System.Drawing.Point(0, 34);
            this.pnlThreads.Name = "pnlThreads";
            this.pnlThreads.Size = new System.Drawing.Size(749, 570);
            this.pnlThreads.TabIndex = 5;
            // 
            // tbActivities
            // 
            this.tbActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActivities.Location = new System.Drawing.Point(0, 0);
            this.tbActivities.Multiline = true;
            this.tbActivities.Name = "tbActivities";
            this.tbActivities.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbActivities.Size = new System.Drawing.Size(749, 570);
            this.tbActivities.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 604);
            this.Controls.Add(this.pnlThreads);
            this.Controls.Add(this.pnlOperation);
            this.Name = "MainForm";
            this.Text = "CSMDbgTrackManagedProcessActivities";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlOperation.ResumeLayout(false);
            this.pnlOperation.PerformLayout();
            this.pnlThreads.ResumeLayout(false);
            this.pnlThreads.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbApplicationToDebug;
        private System.Windows.Forms.Label lbProcess;
        private System.Windows.Forms.Panel pnlOperation;
        private System.Windows.Forms.Panel pnlThreads;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.TextBox tbActivities;
    }
}

