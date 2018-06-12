namespace CSWinformTFSTreeView
{
    partial class SCForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.gpbConnectToTFS = new System.Windows.Forms.GroupBox();
            this.tlpConnectToTFS = new System.Windows.Forms.TableLayoutPanel();
            this.lbTFSUri = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tvwSourceBrowser = new System.Windows.Forms.TreeView();
            this.lbTfsUriText = new System.Windows.Forms.Label();
            this.gpbConnectToTFS.SuspendLayout();
            this.tlpConnectToTFS.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList, "imageList");
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gpbConnectToTFS
            // 
            resources.ApplyResources(this.gpbConnectToTFS, "gpbConnectToTFS");
            this.gpbConnectToTFS.Controls.Add(this.tlpConnectToTFS);
            this.gpbConnectToTFS.Name = "gpbConnectToTFS";
            this.gpbConnectToTFS.TabStop = false;
            // 
            // tlpConnectToTFS
            // 
            resources.ApplyResources(this.tlpConnectToTFS, "tlpConnectToTFS");
            this.tlpConnectToTFS.Controls.Add(this.lbTFSUri, 0, 0);
            this.tlpConnectToTFS.Controls.Add(this.lbTfsUriText, 1, 0);
            this.tlpConnectToTFS.Controls.Add(this.btnConnect, 0, 1);
            this.tlpConnectToTFS.Name = "tlpConnectToTFS";
            // 
            // lbTFSUri
            // 
            resources.ApplyResources(this.lbTFSUri, "lbTFSUri");
            this.lbTFSUri.Name = "lbTFSUri";
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // tvwSourceBrowser
            // 
            resources.ApplyResources(this.tvwSourceBrowser, "tvwSourceBrowser");
            this.tvwSourceBrowser.Name = "tvwSourceBrowser";
            this.tvwSourceBrowser.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvwSourceBrowserBeforeExpand);
            // 
            // lbTfsUriText
            // 
            resources.ApplyResources(this.lbTfsUriText, "lbTfsUriText");
            this.lbTfsUriText.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CSWinformTFSTreeView.Properties.Settings.Default, "DefaultServerUri", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbTfsUriText.Name = "lbTfsUriText";
            this.lbTfsUriText.Text = global::CSWinformTFSTreeView.Properties.Settings.Default.DefaultServerUri;
            // 
            // SCForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tvwSourceBrowser);
            this.Controls.Add(this.gpbConnectToTFS);
            this.Name = "SCForm";
            this.gpbConnectToTFS.ResumeLayout(false);
            this.tlpConnectToTFS.ResumeLayout(false);
            this.tlpConnectToTFS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox gpbConnectToTFS;
        private System.Windows.Forms.TableLayoutPanel tlpConnectToTFS;
        private System.Windows.Forms.Label lbTFSUri;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TreeView tvwSourceBrowser;
        private System.Windows.Forms.Label lbTfsUriText;
    }
}

