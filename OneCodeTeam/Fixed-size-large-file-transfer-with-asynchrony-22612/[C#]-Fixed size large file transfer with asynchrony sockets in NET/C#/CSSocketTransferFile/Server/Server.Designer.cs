namespace Server
{
    partial class Server
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
            this.btnStartup = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbxServer = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lblClients = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartup
            // 
            this.btnStartup.Location = new System.Drawing.Point(228, 168);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(75, 48);
            this.btnStartup.TabIndex = 0;
            this.btnStartup.Text = "Startup";
            this.btnStartup.UseVisualStyleBackColor = true;
            this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 47);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(77, 12);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "File to send";
            // 
            // tbxFile
            // 
            this.tbxFile.Enabled = false;
            this.tbxFile.Location = new System.Drawing.Point(95, 44);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(127, 21);
            this.tbxFile.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(228, 44);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 21);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "Browse...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lbxServer
            // 
            this.lbxServer.AccessibleDescription = "";
            this.lbxServer.AccessibleName = "";
            this.lbxServer.FormattingEnabled = true;
            this.lbxServer.ItemHeight = 12;
            this.lbxServer.Location = new System.Drawing.Point(15, 92);
            this.lbxServer.Name = "lbxServer";
            this.lbxServer.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxServer.Size = new System.Drawing.Size(207, 124);
            this.lbxServer.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(228, 138);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 24);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 21);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 12);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(95, 21);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 21);
            this.tbxPort.TabIndex = 7;
            this.tbxPort.Text = "11000";
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(12, 78);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(107, 12);
            this.lblClients.TabIndex = 8;
            this.lblClients.Text = "Connected Clients";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 232);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbxServer);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnStartup);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartup;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox lbxServer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label lblClients;
    }
}

