namespace CSOutLookContactsExportImport
{
    partial class OutlookContacts
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbxImportExcel = new System.Windows.Forms.TextBox();
            this.btnBrowseImp = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please select Excel spreadsheet to import：";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 61);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbxImportExcel
            // 
            this.tbxImportExcel.Location = new System.Drawing.Point(15, 147);
            this.tbxImportExcel.Name = "tbxImportExcel";
            this.tbxImportExcel.Size = new System.Drawing.Size(136, 20);
            this.tbxImportExcel.TabIndex = 5;
            // 
            // btnBrowseImp
            // 
            this.btnBrowseImp.Location = new System.Drawing.Point(157, 147);
            this.btnBrowseImp.Name = "btnBrowseImp";
            this.btnBrowseImp.Size = new System.Drawing.Size(58, 23);
            this.btnBrowseImp.TabIndex = 6;
            this.btnBrowseImp.Text = "Browse";
            this.btnBrowseImp.UseVisualStyleBackColor = true;
            this.btnBrowseImp.Click += new System.EventHandler(this.btnBrowseImp_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(15, 173);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(58, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Click Export button to export outlook contacts：";
            // 
            // OutlookContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 227);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowseImp);
            this.Controls.Add(this.tbxImportExcel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Name = "OutlookContacts";
            this.Text = "ContactsExportImport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbxImportExcel;
        private System.Windows.Forms.Button btnBrowseImp;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
    }
}

