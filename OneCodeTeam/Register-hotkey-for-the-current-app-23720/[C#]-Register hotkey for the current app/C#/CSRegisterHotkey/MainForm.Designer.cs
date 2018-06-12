namespace CSRegisterHotkey
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbKey = new System.Windows.Forms.Label();
            this.tbHotKey = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.lbNotice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(13, 33);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(89, 13);
            this.lbKey.TabIndex = 0;
            this.lbKey.Text = "Press the HotKey";
            // 
            // tbHotKey
            // 
            this.tbHotKey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbHotKey.Location = new System.Drawing.Point(109, 29);
            this.tbHotKey.Name = "tbHotKey";
            this.tbHotKey.Size = new System.Drawing.Size(339, 20);
            this.tbHotKey.TabIndex = 1;
            this.tbHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHotKey_KeyDown);
            // 
            // btnRegister
            // 
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(467, 28);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Enabled = false;
            this.btnUnregister.Location = new System.Drawing.Point(549, 28);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnUnregister.TabIndex = 3;
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.Location = new System.Drawing.Point(13, 59);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(571, 26);
            this.lbNotice.TabIndex = 4;
            this.lbNotice.Text = "Please click the textbox and press the keys.  The keys that must be pressed in co" +
                "mbination with the key Ctrl, Shift or Alt.\r\nLike Ctrl+Alt+T ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 96);
            this.Controls.Add(this.lbNotice);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbHotKey);
            this.Controls.Add(this.lbKey);
            this.Name = "MainForm";
            this.Text = "RegisterHotkey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox tbHotKey;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.Label lbNotice;
    }
}

