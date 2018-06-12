namespace CSCustomizeSysMenu
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
            this.btnAddToFormSysMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMenuCaption = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddToFormSysMenu
            // 
            this.btnAddToFormSysMenu.Location = new System.Drawing.Point(72, 62);
            this.btnAddToFormSysMenu.Name = "btnAddToFormSysMenu";
            this.btnAddToFormSysMenu.Size = new System.Drawing.Size(173, 23);
            this.btnAddToFormSysMenu.TabIndex = 0;
            this.btnAddToFormSysMenu.Text = "Add To System Menu";
            this.btnAddToFormSysMenu.UseVisualStyleBackColor = true;
            this.btnAddToFormSysMenu.Click += new System.EventHandler(this.btnAddToFormSystemMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu Caption:";
            // 
            // txtMenuCaption
            // 
            this.txtMenuCaption.Location = new System.Drawing.Point(97, 22);
            this.txtMenuCaption.Name = "txtMenuCaption";
            this.txtMenuCaption.Size = new System.Drawing.Size(207, 20);
            this.txtMenuCaption.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 93);
            this.Controls.Add(this.txtMenuCaption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddToFormSysMenu);
            this.Name = "Form1";
            this.Text = "Customize System Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddToFormSysMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMenuCaption;
    }
}

