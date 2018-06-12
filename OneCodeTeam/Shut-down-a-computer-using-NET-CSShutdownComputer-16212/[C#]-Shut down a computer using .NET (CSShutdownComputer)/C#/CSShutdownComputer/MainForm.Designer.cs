namespace CSShutdownComputer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.radExitWindowEx = new System.Windows.Forms.RadioButton();
            this.radInitiateShutdown = new System.Windows.Forms.RadioButton();
            this.radInitiateSystemShutdownEx = new System.Windows.Forms.RadioButton();
            this.radAbortSystemShutdown = new System.Windows.Forms.RadioButton();
            this.grpbxExitWindowEx = new System.Windows.Forms.GroupBox();
            this.chkEWX_LOGOFF = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtReasonEWE = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEWX_FORCEIFHUNG = new System.Windows.Forms.CheckBox();
            this.chkEWX_FORCE = new System.Windows.Forms.CheckBox();
            this.chkEWX_RESTARTAPPS = new System.Windows.Forms.CheckBox();
            this.chkEWX_SHUTDOWN = new System.Windows.Forms.CheckBox();
            this.chkEWX_REBOOT = new System.Windows.Forms.CheckBox();
            this.chkEWX_POWEROFF = new System.Windows.Forms.CheckBox();
            this.chkEWX_HYBRID_SHUTDOWN = new System.Windows.Forms.CheckBox();
            this.grpbxInitiateShutdown = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkSHUTDOWN_RESTARTAPPS = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_RESTART = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_POWEROFF = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_NOREBOOT = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_HYBRID = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_INSTALL_UPDATES = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_GRACE_OVERRIDE = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_FORCE_SELF = new System.Windows.Forms.CheckBox();
            this.chkSHUTDOWN_FORCE_OTHERS = new System.Windows.Forms.CheckBox();
            this.lnkShutDownReason = new System.Windows.Forms.LinkLabel();
            this.txtReasonIS = new System.Windows.Forms.TextBox();
            this.txtGracePeriodIS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessageIS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMachineNameIS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxInitiateSystemShutdownEx = new System.Windows.Forms.GroupBox();
            this.chkRebootAfterShutdown = new System.Windows.Forms.CheckBox();
            this.chkForceAppsClosed = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtReasonISSE = new System.Windows.Forms.TextBox();
            this.txtTimeOutISSE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessageISSE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMachineNameISSE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lnkDocumentationExitWindowEx = new System.Windows.Forms.LinkLabel();
            this.lnkDocInitiateShutdown = new System.Windows.Forms.LinkLabel();
            this.lnkDocInitiateSystemShutdownEx = new System.Windows.Forms.LinkLabel();
            this.lnkDocAbortSystemShutdown = new System.Windows.Forms.LinkLabel();
            this.txtMachineNameASS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpbxAbortSystemShutdown = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lnkPInvokeEWE = new System.Windows.Forms.LinkLabel();
            this.lnkPInvokeLinkISSE = new System.Windows.Forms.LinkLabel();
            this.lnkPInvokeLinkASS = new System.Windows.Forms.LinkLabel();
            this.grpbxExitWindowEx.SuspendLayout();
            this.grpbxInitiateShutdown.SuspendLayout();
            this.grpbxInitiateSystemShutdownEx.SuspendLayout();
            this.grpbxAbortSystemShutdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // radExitWindowEx
            // 
            this.radExitWindowEx.AutoSize = true;
            this.radExitWindowEx.Location = new System.Drawing.Point(22, 23);
            this.radExitWindowEx.Name = "radExitWindowEx";
            this.radExitWindowEx.Size = new System.Drawing.Size(120, 17);
            this.radExitWindowEx.TabIndex = 0;
            this.radExitWindowEx.TabStop = true;
            this.radExitWindowEx.Text = "Use ExitWindowsEx";
            this.radExitWindowEx.UseVisualStyleBackColor = true;
            this.radExitWindowEx.CheckedChanged += new System.EventHandler(this.radExitWindowEx_CheckedChanged);
            // 
            // radInitiateShutdown
            // 
            this.radInitiateShutdown.AutoSize = true;
            this.radInitiateShutdown.Location = new System.Drawing.Point(22, 219);
            this.radInitiateShutdown.Name = "radInitiateShutdown";
            this.radInitiateShutdown.Size = new System.Drawing.Size(126, 17);
            this.radInitiateShutdown.TabIndex = 12;
            this.radInitiateShutdown.TabStop = true;
            this.radInitiateShutdown.Text = "Use InitiateShutdown";
            this.radInitiateShutdown.UseVisualStyleBackColor = true;
            this.radInitiateShutdown.CheckedChanged += new System.EventHandler(this.radInitiateShutdown_CheckedChanged);
            // 
            // radInitiateSystemShutdownEx
            // 
            this.radInitiateSystemShutdownEx.AutoSize = true;
            this.radInitiateSystemShutdownEx.Location = new System.Drawing.Point(25, 458);
            this.radInitiateSystemShutdownEx.Name = "radInitiateSystemShutdownEx";
            this.radInitiateSystemShutdownEx.Size = new System.Drawing.Size(175, 17);
            this.radInitiateSystemShutdownEx.TabIndex = 28;
            this.radInitiateSystemShutdownEx.TabStop = true;
            this.radInitiateSystemShutdownEx.Text = "Use InitiateSystemShutdownEx ";
            this.radInitiateSystemShutdownEx.UseVisualStyleBackColor = true;
            this.radInitiateSystemShutdownEx.CheckedChanged += new System.EventHandler(this.radInitiateSystemShutdownEx_CheckedChanged);
            // 
            // radAbortSystemShutdown
            // 
            this.radAbortSystemShutdown.AutoSize = true;
            this.radAbortSystemShutdown.Location = new System.Drawing.Point(25, 591);
            this.radAbortSystemShutdown.Name = "radAbortSystemShutdown";
            this.radAbortSystemShutdown.Size = new System.Drawing.Size(169, 17);
            this.radAbortSystemShutdown.TabIndex = 37;
            this.radAbortSystemShutdown.TabStop = true;
            this.radAbortSystemShutdown.Text = "Use AbortSystemShutdown     ";
            this.radAbortSystemShutdown.UseVisualStyleBackColor = true;
            this.radAbortSystemShutdown.CheckedChanged += new System.EventHandler(this.radAbortSystemShutdown_CheckedChanged);
            // 
            // grpbxExitWindowEx
            // 
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_LOGOFF);
            this.grpbxExitWindowEx.Controls.Add(this.groupBox6);
            this.grpbxExitWindowEx.Controls.Add(this.linkLabel2);
            this.grpbxExitWindowEx.Controls.Add(this.txtReasonEWE);
            this.grpbxExitWindowEx.Controls.Add(this.groupBox2);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_FORCEIFHUNG);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_FORCE);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_RESTARTAPPS);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_SHUTDOWN);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_REBOOT);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_POWEROFF);
            this.grpbxExitWindowEx.Controls.Add(this.chkEWX_HYBRID_SHUTDOWN);
            this.grpbxExitWindowEx.Location = new System.Drawing.Point(22, 46);
            this.grpbxExitWindowEx.Name = "grpbxExitWindowEx";
            this.grpbxExitWindowEx.Size = new System.Drawing.Size(464, 167);
            this.grpbxExitWindowEx.TabIndex = 4;
            this.grpbxExitWindowEx.TabStop = false;
            this.grpbxExitWindowEx.Text = "Flags for ExitWindowsEx and Parameters";
            // 
            // chkEWX_LOGOFF
            // 
            this.chkEWX_LOGOFF.AutoSize = true;
            this.chkEWX_LOGOFF.Location = new System.Drawing.Point(279, 19);
            this.chkEWX_LOGOFF.Name = "chkEWX_LOGOFF";
            this.chkEWX_LOGOFF.Size = new System.Drawing.Size(99, 17);
            this.chkEWX_LOGOFF.TabIndex = 3;
            this.chkEWX_LOGOFF.Tag = "0";
            this.chkEWX_LOGOFF.Text = "EWX_LOGOFF";
            this.chkEWX_LOGOFF.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(3, 120);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 10);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(15, 136);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(47, 13);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Reason:";
            // 
            // txtReasonEWE
            // 
            this.txtReasonEWE.Location = new System.Drawing.Point(76, 133);
            this.txtReasonEWE.Name = "txtReasonEWE";
            this.txtReasonEWE.Size = new System.Drawing.Size(126, 20);
            this.txtReasonEWE.TabIndex = 11;
            this.txtReasonEWE.Text = "30000";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 10);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // chkEWX_FORCEIFHUNG
            // 
            this.chkEWX_FORCEIFHUNG.AutoSize = true;
            this.chkEWX_FORCEIFHUNG.Location = new System.Drawing.Point(279, 100);
            this.chkEWX_FORCEIFHUNG.Name = "chkEWX_FORCEIFHUNG";
            this.chkEWX_FORCEIFHUNG.Size = new System.Drawing.Size(134, 17);
            this.chkEWX_FORCEIFHUNG.TabIndex = 9;
            this.chkEWX_FORCEIFHUNG.Tag = "10";
            this.chkEWX_FORCEIFHUNG.Text = "EWX_FORCEIFHUNG";
            this.chkEWX_FORCEIFHUNG.UseVisualStyleBackColor = true;
            // 
            // chkEWX_FORCE
            // 
            this.chkEWX_FORCE.AutoSize = true;
            this.chkEWX_FORCE.Location = new System.Drawing.Point(18, 100);
            this.chkEWX_FORCE.Name = "chkEWX_FORCE";
            this.chkEWX_FORCE.Size = new System.Drawing.Size(93, 17);
            this.chkEWX_FORCE.TabIndex = 8;
            this.chkEWX_FORCE.Tag = "4";
            this.chkEWX_FORCE.Text = "EWX_FORCE";
            this.chkEWX_FORCE.UseVisualStyleBackColor = true;
            // 
            // chkEWX_RESTARTAPPS
            // 
            this.chkEWX_RESTARTAPPS.AutoSize = true;
            this.chkEWX_RESTARTAPPS.Location = new System.Drawing.Point(18, 65);
            this.chkEWX_RESTARTAPPS.Name = "chkEWX_RESTARTAPPS";
            this.chkEWX_RESTARTAPPS.Size = new System.Drawing.Size(136, 17);
            this.chkEWX_RESTARTAPPS.TabIndex = 6;
            this.chkEWX_RESTARTAPPS.Tag = "40";
            this.chkEWX_RESTARTAPPS.Text = "EWX_RESTARTAPPS";
            this.chkEWX_RESTARTAPPS.UseVisualStyleBackColor = true;
            // 
            // chkEWX_SHUTDOWN
            // 
            this.chkEWX_SHUTDOWN.AutoSize = true;
            this.chkEWX_SHUTDOWN.Location = new System.Drawing.Point(279, 65);
            this.chkEWX_SHUTDOWN.Name = "chkEWX_SHUTDOWN";
            this.chkEWX_SHUTDOWN.Size = new System.Drawing.Size(122, 17);
            this.chkEWX_SHUTDOWN.TabIndex = 7;
            this.chkEWX_SHUTDOWN.Tag = "1";
            this.chkEWX_SHUTDOWN.Text = "EWX_SHUTDOWN";
            this.chkEWX_SHUTDOWN.UseVisualStyleBackColor = true;
            // 
            // chkEWX_REBOOT
            // 
            this.chkEWX_REBOOT.AutoSize = true;
            this.chkEWX_REBOOT.Location = new System.Drawing.Point(279, 42);
            this.chkEWX_REBOOT.Name = "chkEWX_REBOOT";
            this.chkEWX_REBOOT.Size = new System.Drawing.Size(102, 17);
            this.chkEWX_REBOOT.TabIndex = 5;
            this.chkEWX_REBOOT.Tag = "2";
            this.chkEWX_REBOOT.Text = "EWX_REBOOT";
            this.chkEWX_REBOOT.UseVisualStyleBackColor = true;
            // 
            // chkEWX_POWEROFF
            // 
            this.chkEWX_POWEROFF.AutoSize = true;
            this.chkEWX_POWEROFF.Location = new System.Drawing.Point(18, 42);
            this.chkEWX_POWEROFF.Name = "chkEWX_POWEROFF";
            this.chkEWX_POWEROFF.Size = new System.Drawing.Size(118, 17);
            this.chkEWX_POWEROFF.TabIndex = 4;
            this.chkEWX_POWEROFF.Tag = "8";
            this.chkEWX_POWEROFF.Text = "EWX_POWEROFF";
            this.chkEWX_POWEROFF.UseVisualStyleBackColor = true;
            // 
            // chkEWX_HYBRID_SHUTDOWN
            // 
            this.chkEWX_HYBRID_SHUTDOWN.AutoSize = true;
            this.chkEWX_HYBRID_SHUTDOWN.Location = new System.Drawing.Point(18, 19);
            this.chkEWX_HYBRID_SHUTDOWN.Name = "chkEWX_HYBRID_SHUTDOWN";
            this.chkEWX_HYBRID_SHUTDOWN.Size = new System.Drawing.Size(231, 17);
            this.chkEWX_HYBRID_SHUTDOWN.TabIndex = 2;
            this.chkEWX_HYBRID_SHUTDOWN.Tag = "400000";
            this.chkEWX_HYBRID_SHUTDOWN.Text = "EWX_HYBRID_SHUTDOWN (Windows 8)";
            this.chkEWX_HYBRID_SHUTDOWN.UseVisualStyleBackColor = true;
            // 
            // grpbxInitiateShutdown
            // 
            this.grpbxInitiateShutdown.Controls.Add(this.groupBox5);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_RESTARTAPPS);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_RESTART);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_POWEROFF);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_NOREBOOT);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_HYBRID);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_INSTALL_UPDATES);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_GRACE_OVERRIDE);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_FORCE_SELF);
            this.grpbxInitiateShutdown.Controls.Add(this.chkSHUTDOWN_FORCE_OTHERS);
            this.grpbxInitiateShutdown.Controls.Add(this.lnkShutDownReason);
            this.grpbxInitiateShutdown.Controls.Add(this.txtReasonIS);
            this.grpbxInitiateShutdown.Controls.Add(this.txtGracePeriodIS);
            this.grpbxInitiateShutdown.Controls.Add(this.label3);
            this.grpbxInitiateShutdown.Controls.Add(this.txtMessageIS);
            this.grpbxInitiateShutdown.Controls.Add(this.label2);
            this.grpbxInitiateShutdown.Controls.Add(this.txtMachineNameIS);
            this.grpbxInitiateShutdown.Controls.Add(this.label1);
            this.grpbxInitiateShutdown.Enabled = false;
            this.grpbxInitiateShutdown.Location = new System.Drawing.Point(25, 242);
            this.grpbxInitiateShutdown.Name = "grpbxInitiateShutdown";
            this.grpbxInitiateShutdown.Size = new System.Drawing.Size(461, 210);
            this.grpbxInitiateShutdown.TabIndex = 5;
            this.grpbxInitiateShutdown.TabStop = false;
            this.grpbxInitiateShutdown.Text = "InitiateShutdown Parameters and Flags";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(11, 74);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(430, 10);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // chkSHUTDOWN_RESTARTAPPS
            // 
            this.chkSHUTDOWN_RESTARTAPPS.AutoSize = true;
            this.chkSHUTDOWN_RESTARTAPPS.Location = new System.Drawing.Point(276, 162);
            this.chkSHUTDOWN_RESTARTAPPS.Name = "chkSHUTDOWN_RESTARTAPPS";
            this.chkSHUTDOWN_RESTARTAPPS.Size = new System.Drawing.Size(176, 17);
            this.chkSHUTDOWN_RESTARTAPPS.TabIndex = 26;
            this.chkSHUTDOWN_RESTARTAPPS.Tag = "80";
            this.chkSHUTDOWN_RESTARTAPPS.Text = "SHUTDOWN_RESTARTAPPS";
            this.chkSHUTDOWN_RESTARTAPPS.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_RESTART
            // 
            this.chkSHUTDOWN_RESTART.AutoSize = true;
            this.chkSHUTDOWN_RESTART.Location = new System.Drawing.Point(276, 139);
            this.chkSHUTDOWN_RESTART.Name = "chkSHUTDOWN_RESTART";
            this.chkSHUTDOWN_RESTART.Size = new System.Drawing.Size(148, 17);
            this.chkSHUTDOWN_RESTART.TabIndex = 24;
            this.chkSHUTDOWN_RESTART.Tag = "4";
            this.chkSHUTDOWN_RESTART.Text = "SHUTDOWN_RESTART";
            this.chkSHUTDOWN_RESTART.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_POWEROFF
            // 
            this.chkSHUTDOWN_POWEROFF.AutoSize = true;
            this.chkSHUTDOWN_POWEROFF.Location = new System.Drawing.Point(276, 116);
            this.chkSHUTDOWN_POWEROFF.Name = "chkSHUTDOWN_POWEROFF";
            this.chkSHUTDOWN_POWEROFF.Size = new System.Drawing.Size(158, 17);
            this.chkSHUTDOWN_POWEROFF.TabIndex = 21;
            this.chkSHUTDOWN_POWEROFF.Tag = "8";
            this.chkSHUTDOWN_POWEROFF.Text = "SHUTDOWN_POWEROFF";
            this.chkSHUTDOWN_POWEROFF.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_NOREBOOT
            // 
            this.chkSHUTDOWN_NOREBOOT.AutoSize = true;
            this.chkSHUTDOWN_NOREBOOT.Location = new System.Drawing.Point(276, 93);
            this.chkSHUTDOWN_NOREBOOT.Name = "chkSHUTDOWN_NOREBOOT";
            this.chkSHUTDOWN_NOREBOOT.Size = new System.Drawing.Size(158, 17);
            this.chkSHUTDOWN_NOREBOOT.TabIndex = 19;
            this.chkSHUTDOWN_NOREBOOT.Tag = "10";
            this.chkSHUTDOWN_NOREBOOT.Text = "SHUTDOWN_NOREBOOT";
            this.chkSHUTDOWN_NOREBOOT.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_HYBRID
            // 
            this.chkSHUTDOWN_HYBRID.AutoSize = true;
            this.chkSHUTDOWN_HYBRID.Location = new System.Drawing.Point(15, 159);
            this.chkSHUTDOWN_HYBRID.Name = "chkSHUTDOWN_HYBRID";
            this.chkSHUTDOWN_HYBRID.Size = new System.Drawing.Size(200, 17);
            this.chkSHUTDOWN_HYBRID.TabIndex = 25;
            this.chkSHUTDOWN_HYBRID.Tag = "200";
            this.chkSHUTDOWN_HYBRID.Text = "SHUTDOWN_HYBRID (Windows 8)";
            this.chkSHUTDOWN_HYBRID.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_INSTALL_UPDATES
            // 
            this.chkSHUTDOWN_INSTALL_UPDATES.AutoSize = true;
            this.chkSHUTDOWN_INSTALL_UPDATES.Location = new System.Drawing.Point(15, 181);
            this.chkSHUTDOWN_INSTALL_UPDATES.Name = "chkSHUTDOWN_INSTALL_UPDATES";
            this.chkSHUTDOWN_INSTALL_UPDATES.Size = new System.Drawing.Size(198, 17);
            this.chkSHUTDOWN_INSTALL_UPDATES.TabIndex = 27;
            this.chkSHUTDOWN_INSTALL_UPDATES.Tag = "40";
            this.chkSHUTDOWN_INSTALL_UPDATES.Text = "SHUTDOWN_INSTALL_UPDATES";
            this.chkSHUTDOWN_INSTALL_UPDATES.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_GRACE_OVERRIDE
            // 
            this.chkSHUTDOWN_GRACE_OVERRIDE.AutoSize = true;
            this.chkSHUTDOWN_GRACE_OVERRIDE.Location = new System.Drawing.Point(15, 137);
            this.chkSHUTDOWN_GRACE_OVERRIDE.Name = "chkSHUTDOWN_GRACE_OVERRIDE";
            this.chkSHUTDOWN_GRACE_OVERRIDE.Size = new System.Drawing.Size(196, 17);
            this.chkSHUTDOWN_GRACE_OVERRIDE.TabIndex = 23;
            this.chkSHUTDOWN_GRACE_OVERRIDE.Tag = "20";
            this.chkSHUTDOWN_GRACE_OVERRIDE.Text = "SHUTDOWN_GRACE_OVERRIDE";
            this.chkSHUTDOWN_GRACE_OVERRIDE.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_FORCE_SELF
            // 
            this.chkSHUTDOWN_FORCE_SELF.AutoSize = true;
            this.chkSHUTDOWN_FORCE_SELF.Location = new System.Drawing.Point(15, 115);
            this.chkSHUTDOWN_FORCE_SELF.Name = "chkSHUTDOWN_FORCE_SELF";
            this.chkSHUTDOWN_FORCE_SELF.Size = new System.Drawing.Size(165, 17);
            this.chkSHUTDOWN_FORCE_SELF.TabIndex = 20;
            this.chkSHUTDOWN_FORCE_SELF.Tag = "2";
            this.chkSHUTDOWN_FORCE_SELF.Text = "SHUTDOWN_FORCE_SELF";
            this.chkSHUTDOWN_FORCE_SELF.UseVisualStyleBackColor = true;
            // 
            // chkSHUTDOWN_FORCE_OTHERS
            // 
            this.chkSHUTDOWN_FORCE_OTHERS.AutoSize = true;
            this.chkSHUTDOWN_FORCE_OTHERS.Location = new System.Drawing.Point(15, 93);
            this.chkSHUTDOWN_FORCE_OTHERS.Name = "chkSHUTDOWN_FORCE_OTHERS";
            this.chkSHUTDOWN_FORCE_OTHERS.Size = new System.Drawing.Size(184, 17);
            this.chkSHUTDOWN_FORCE_OTHERS.TabIndex = 18;
            this.chkSHUTDOWN_FORCE_OTHERS.Tag = "1";
            this.chkSHUTDOWN_FORCE_OTHERS.Text = "SHUTDOWN_FORCE_OTHERS";
            this.chkSHUTDOWN_FORCE_OTHERS.UseVisualStyleBackColor = true;
            // 
            // lnkShutDownReason
            // 
            this.lnkShutDownReason.AutoSize = true;
            this.lnkShutDownReason.Location = new System.Drawing.Point(244, 51);
            this.lnkShutDownReason.Name = "lnkShutDownReason";
            this.lnkShutDownReason.Size = new System.Drawing.Size(47, 13);
            this.lnkShutDownReason.TabIndex = 10;
            this.lnkShutDownReason.TabStop = true;
            this.lnkShutDownReason.Text = "Reason:";
            this.lnkShutDownReason.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShutDownReason_LinkClicked);
            // 
            // txtReasonIS
            // 
            this.txtReasonIS.Location = new System.Drawing.Point(320, 48);
            this.txtReasonIS.Name = "txtReasonIS";
            this.txtReasonIS.Size = new System.Drawing.Size(126, 20);
            this.txtReasonIS.TabIndex = 17;
            this.txtReasonIS.Text = "30000";
            // 
            // txtGracePeriodIS
            // 
            this.txtGracePeriodIS.Location = new System.Drawing.Point(320, 23);
            this.txtGracePeriodIS.Name = "txtGracePeriodIS";
            this.txtGracePeriodIS.Size = new System.Drawing.Size(126, 20);
            this.txtGracePeriodIS.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grace Period:";
            // 
            // txtMessageIS
            // 
            this.txtMessageIS.Location = new System.Drawing.Point(87, 48);
            this.txtMessageIS.Name = "txtMessageIS";
            this.txtMessageIS.Size = new System.Drawing.Size(148, 20);
            this.txtMessageIS.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message:";
            // 
            // txtMachineNameIS
            // 
            this.txtMachineNameIS.Location = new System.Drawing.Point(87, 23);
            this.txtMachineNameIS.Name = "txtMachineNameIS";
            this.txtMachineNameIS.Size = new System.Drawing.Size(148, 20);
            this.txtMachineNameIS.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Name:";
            // 
            // grpbxInitiateSystemShutdownEx
            // 
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.chkRebootAfterShutdown);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.chkForceAppsClosed);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.linkLabel1);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.txtReasonISSE);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.txtTimeOutISSE);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.label4);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.txtMessageISSE);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.label5);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.txtMachineNameISSE);
            this.grpbxInitiateSystemShutdownEx.Controls.Add(this.label6);
            this.grpbxInitiateSystemShutdownEx.Enabled = false;
            this.grpbxInitiateSystemShutdownEx.Location = new System.Drawing.Point(25, 481);
            this.grpbxInitiateSystemShutdownEx.Name = "grpbxInitiateSystemShutdownEx";
            this.grpbxInitiateSystemShutdownEx.Size = new System.Drawing.Size(461, 98);
            this.grpbxInitiateSystemShutdownEx.TabIndex = 6;
            this.grpbxInitiateSystemShutdownEx.TabStop = false;
            this.grpbxInitiateSystemShutdownEx.Text = "InitiateSystemShutdownEx";
            // 
            // chkRebootAfterShutdown
            // 
            this.chkRebootAfterShutdown.AutoSize = true;
            this.chkRebootAfterShutdown.Location = new System.Drawing.Point(247, 47);
            this.chkRebootAfterShutdown.Name = "chkRebootAfterShutdown";
            this.chkRebootAfterShutdown.Size = new System.Drawing.Size(167, 17);
            this.chkRebootAfterShutdown.TabIndex = 33;
            this.chkRebootAfterShutdown.Text = "Force Reboot After Shutdown";
            this.chkRebootAfterShutdown.UseVisualStyleBackColor = true;
            // 
            // chkForceAppsClosed
            // 
            this.chkForceAppsClosed.AutoSize = true;
            this.chkForceAppsClosed.Location = new System.Drawing.Point(11, 70);
            this.chkForceAppsClosed.Name = "chkForceAppsClosed";
            this.chkForceAppsClosed.Size = new System.Drawing.Size(115, 17);
            this.chkForceAppsClosed.TabIndex = 34;
            this.chkForceAppsClosed.Text = "Force Apps Closed";
            this.chkForceAppsClosed.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(244, 70);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 13);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Reason:";
            // 
            // txtReasonISSE
            // 
            this.txtReasonISSE.Location = new System.Drawing.Point(320, 67);
            this.txtReasonISSE.Name = "txtReasonISSE";
            this.txtReasonISSE.Size = new System.Drawing.Size(126, 20);
            this.txtReasonISSE.TabIndex = 36;
            this.txtReasonISSE.Text = "30000";
            // 
            // txtTimeOutISSE
            // 
            this.txtTimeOutISSE.Location = new System.Drawing.Point(320, 19);
            this.txtTimeOutISSE.Name = "txtTimeOutISSE";
            this.txtTimeOutISSE.Size = new System.Drawing.Size(126, 20);
            this.txtTimeOutISSE.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Timeout:";
            // 
            // txtMessageISSE
            // 
            this.txtMessageISSE.Location = new System.Drawing.Point(87, 44);
            this.txtMessageISSE.Name = "txtMessageISSE";
            this.txtMessageISSE.Size = new System.Drawing.Size(148, 20);
            this.txtMessageISSE.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Message:";
            // 
            // txtMachineNameISSE
            // 
            this.txtMachineNameISSE.Location = new System.Drawing.Point(87, 19);
            this.txtMachineNameISSE.Name = "txtMachineNameISSE";
            this.txtMachineNameISSE.Size = new System.Drawing.Size(148, 20);
            this.txtMachineNameISSE.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Machine Name:";
            // 
            // lnkDocumentationExitWindowEx
            // 
            this.lnkDocumentationExitWindowEx.AutoSize = true;
            this.lnkDocumentationExitWindowEx.Location = new System.Drawing.Point(159, 25);
            this.lnkDocumentationExitWindowEx.Name = "lnkDocumentationExitWindowEx";
            this.lnkDocumentationExitWindowEx.Size = new System.Drawing.Size(79, 13);
            this.lnkDocumentationExitWindowEx.TabIndex = 1;
            this.lnkDocumentationExitWindowEx.TabStop = true;
            this.lnkDocumentationExitWindowEx.Text = "Documentation";
            this.lnkDocumentationExitWindowEx.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocumentationExitWindowEx_LinkClicked);
            // 
            // lnkDocInitiateShutdown
            // 
            this.lnkDocInitiateShutdown.AutoSize = true;
            this.lnkDocInitiateShutdown.Location = new System.Drawing.Point(158, 221);
            this.lnkDocInitiateShutdown.Name = "lnkDocInitiateShutdown";
            this.lnkDocInitiateShutdown.Size = new System.Drawing.Size(79, 13);
            this.lnkDocInitiateShutdown.TabIndex = 13;
            this.lnkDocInitiateShutdown.TabStop = true;
            this.lnkDocInitiateShutdown.Text = "Documentation";
            this.lnkDocInitiateShutdown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocInitiateShutdown_LinkClicked);
            // 
            // lnkDocInitiateSystemShutdownEx
            // 
            this.lnkDocInitiateSystemShutdownEx.AutoSize = true;
            this.lnkDocInitiateSystemShutdownEx.Location = new System.Drawing.Point(206, 460);
            this.lnkDocInitiateSystemShutdownEx.Name = "lnkDocInitiateSystemShutdownEx";
            this.lnkDocInitiateSystemShutdownEx.Size = new System.Drawing.Size(79, 13);
            this.lnkDocInitiateSystemShutdownEx.TabIndex = 29;
            this.lnkDocInitiateSystemShutdownEx.TabStop = true;
            this.lnkDocInitiateSystemShutdownEx.Text = "Documentation";
            this.lnkDocInitiateSystemShutdownEx.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocInitiateSystemShutdownEx_LinkClicked);
            // 
            // lnkDocAbortSystemShutdown
            // 
            this.lnkDocAbortSystemShutdown.AutoSize = true;
            this.lnkDocAbortSystemShutdown.Location = new System.Drawing.Point(206, 593);
            this.lnkDocAbortSystemShutdown.Name = "lnkDocAbortSystemShutdown";
            this.lnkDocAbortSystemShutdown.Size = new System.Drawing.Size(79, 13);
            this.lnkDocAbortSystemShutdown.TabIndex = 38;
            this.lnkDocAbortSystemShutdown.TabStop = true;
            this.lnkDocAbortSystemShutdown.Text = "Documentation";
            this.lnkDocAbortSystemShutdown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocAbortSystemShutdown_LinkClicked);
            // 
            // txtMachineNameASS
            // 
            this.txtMachineNameASS.Location = new System.Drawing.Point(96, 17);
            this.txtMachineNameASS.Name = "txtMachineNameASS";
            this.txtMachineNameASS.Size = new System.Drawing.Size(148, 20);
            this.txtMachineNameASS.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 634);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Machine Name:";
            // 
            // grpbxAbortSystemShutdown
            // 
            this.grpbxAbortSystemShutdown.Controls.Add(this.txtMachineNameASS);
            this.grpbxAbortSystemShutdown.Enabled = false;
            this.grpbxAbortSystemShutdown.Location = new System.Drawing.Point(25, 614);
            this.grpbxAbortSystemShutdown.Name = "grpbxAbortSystemShutdown";
            this.grpbxAbortSystemShutdown.Size = new System.Drawing.Size(461, 50);
            this.grpbxAbortSystemShutdown.TabIndex = 23;
            this.grpbxAbortSystemShutdown.TabStop = false;
            this.grpbxAbortSystemShutdown.Text = "AbortSystemShutdown Params";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(503, 46);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(10, 617);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(529, 325);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 40;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lnkPInvokeEWE
            // 
            this.lnkPInvokeEWE.AutoSize = true;
            this.lnkPInvokeEWE.Location = new System.Drawing.Point(243, 25);
            this.lnkPInvokeEWE.Name = "lnkPInvokeEWE";
            this.lnkPInvokeEWE.Size = new System.Drawing.Size(70, 13);
            this.lnkPInvokeEWE.TabIndex = 41;
            this.lnkPInvokeEWE.TabStop = true;
            this.lnkPInvokeEWE.Text = "PInvoke Link";
            this.lnkPInvokeEWE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPInvokeEWE_LinkClicked);
            // 
            // lnkPInvokeLinkISSE
            // 
            this.lnkPInvokeLinkISSE.AutoSize = true;
            this.lnkPInvokeLinkISSE.Location = new System.Drawing.Point(291, 460);
            this.lnkPInvokeLinkISSE.Name = "lnkPInvokeLinkISSE";
            this.lnkPInvokeLinkISSE.Size = new System.Drawing.Size(70, 13);
            this.lnkPInvokeLinkISSE.TabIndex = 42;
            this.lnkPInvokeLinkISSE.TabStop = true;
            this.lnkPInvokeLinkISSE.Text = "PInvoke Link";
            this.lnkPInvokeLinkISSE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPInvokeLinkISSE_LinkClicked);
            // 
            // lnkPInvokeLinkASS
            // 
            this.lnkPInvokeLinkASS.AutoSize = true;
            this.lnkPInvokeLinkASS.Location = new System.Drawing.Point(291, 593);
            this.lnkPInvokeLinkASS.Name = "lnkPInvokeLinkASS";
            this.lnkPInvokeLinkASS.Size = new System.Drawing.Size(70, 13);
            this.lnkPInvokeLinkASS.TabIndex = 43;
            this.lnkPInvokeLinkASS.TabStop = true;
            this.lnkPInvokeLinkASS.Text = "PInvoke Link";
            this.lnkPInvokeLinkASS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPInvokeLinkASS_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 672);
            this.Controls.Add(this.lnkPInvokeLinkASS);
            this.Controls.Add(this.lnkPInvokeLinkISSE);
            this.Controls.Add(this.lnkPInvokeEWE);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.lnkDocAbortSystemShutdown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lnkDocInitiateSystemShutdownEx);
            this.Controls.Add(this.lnkDocInitiateShutdown);
            this.Controls.Add(this.lnkDocumentationExitWindowEx);
            this.Controls.Add(this.grpbxInitiateSystemShutdownEx);
            this.Controls.Add(this.grpbxInitiateShutdown);
            this.Controls.Add(this.radAbortSystemShutdown);
            this.Controls.Add(this.radInitiateSystemShutdownEx);
            this.Controls.Add(this.radInitiateShutdown);
            this.Controls.Add(this.radExitWindowEx);
            this.Controls.Add(this.grpbxExitWindowEx);
            this.Controls.Add(this.grpbxAbortSystemShutdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shutdown Windows via .Net Code";
            this.grpbxExitWindowEx.ResumeLayout(false);
            this.grpbxExitWindowEx.PerformLayout();
            this.grpbxInitiateShutdown.ResumeLayout(false);
            this.grpbxInitiateShutdown.PerformLayout();
            this.grpbxInitiateSystemShutdownEx.ResumeLayout(false);
            this.grpbxInitiateSystemShutdownEx.PerformLayout();
            this.grpbxAbortSystemShutdown.ResumeLayout(false);
            this.grpbxAbortSystemShutdown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radExitWindowEx;
        private System.Windows.Forms.RadioButton radInitiateShutdown;
        private System.Windows.Forms.RadioButton radInitiateSystemShutdownEx;
        private System.Windows.Forms.RadioButton radAbortSystemShutdown;
        private System.Windows.Forms.GroupBox grpbxExitWindowEx;
        private System.Windows.Forms.CheckBox chkEWX_HYBRID_SHUTDOWN;
        private System.Windows.Forms.CheckBox chkEWX_RESTARTAPPS;
        private System.Windows.Forms.CheckBox chkEWX_SHUTDOWN;
        private System.Windows.Forms.CheckBox chkEWX_REBOOT;
        private System.Windows.Forms.CheckBox chkEWX_POWEROFF;
        private System.Windows.Forms.CheckBox chkEWX_LOGOFF;
        private System.Windows.Forms.CheckBox chkEWX_FORCEIFHUNG;
        private System.Windows.Forms.CheckBox chkEWX_FORCE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpbxInitiateShutdown;
        private System.Windows.Forms.TextBox txtMachineNameIS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessageIS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGracePeriodIS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReasonIS;
        private System.Windows.Forms.LinkLabel lnkShutDownReason;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_POWEROFF;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_NOREBOOT;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_HYBRID;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_INSTALL_UPDATES;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_GRACE_OVERRIDE;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_FORCE_SELF;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_FORCE_OTHERS;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_RESTART;
        private System.Windows.Forms.CheckBox chkSHUTDOWN_RESTARTAPPS;
        private System.Windows.Forms.GroupBox grpbxInitiateSystemShutdownEx;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtReasonISSE;
        private System.Windows.Forms.TextBox txtTimeOutISSE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMessageISSE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMachineNameISSE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lnkDocumentationExitWindowEx;
        private System.Windows.Forms.LinkLabel lnkDocInitiateShutdown;
        private System.Windows.Forms.LinkLabel lnkDocInitiateSystemShutdownEx;
        private System.Windows.Forms.CheckBox chkForceAppsClosed;
        private System.Windows.Forms.CheckBox chkRebootAfterShutdown;
        private System.Windows.Forms.LinkLabel lnkDocAbortSystemShutdown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtReasonEWE;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtMachineNameASS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpbxAbortSystemShutdown;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.LinkLabel lnkPInvokeEWE;
        private System.Windows.Forms.LinkLabel lnkPInvokeLinkISSE;
        private System.Windows.Forms.LinkLabel lnkPInvokeLinkASS;
    }
}

