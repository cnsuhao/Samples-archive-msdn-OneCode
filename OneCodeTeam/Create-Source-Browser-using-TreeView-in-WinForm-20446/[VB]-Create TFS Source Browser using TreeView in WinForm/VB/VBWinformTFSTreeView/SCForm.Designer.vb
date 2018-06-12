'***************************** Module Header *******************************\
' Module Name:  TFSContext.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' TFS Context class to deal with tfs connection, tfs operations.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCForm))
        Me.gpbConnectToTFS = New System.Windows.Forms.GroupBox()
        Me.tlpConnectToTFS = New System.Windows.Forms.TableLayoutPanel()
        Me.lbTFSName = New System.Windows.Forms.Label()
        Me.tbTFSUri = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.tvwSourceBrowser = New System.Windows.Forms.TreeView()
        Me.gpbConnectToTFS.SuspendLayout()
        Me.tlpConnectToTFS.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbConnectToTFS
        '
        resources.ApplyResources(Me.gpbConnectToTFS, "gpbConnectToTFS")
        Me.gpbConnectToTFS.Controls.Add(Me.tlpConnectToTFS)
        Me.gpbConnectToTFS.Name = "gpbConnectToTFS"
        Me.gpbConnectToTFS.TabStop = False
        '
        'tlpConnectToTFS
        '
        resources.ApplyResources(Me.tlpConnectToTFS, "tlpConnectToTFS")
        Me.tlpConnectToTFS.Controls.Add(Me.lbTFSName, 0, 0)
        Me.tlpConnectToTFS.Controls.Add(Me.tbTFSUri, 1, 0)
        Me.tlpConnectToTFS.Controls.Add(Me.btnConnect, 0, 1)
        Me.tlpConnectToTFS.Name = "tlpConnectToTFS"
        '
        'lbTFSName
        '
        resources.ApplyResources(Me.lbTFSName, "lbTFSName")
        Me.lbTFSName.Name = "lbTFSName"
        '
        'tbTFSUri
        '
        Me.tbTFSUri.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.VBWinformTFSTreeView.My.MySettings.Default, "DefaultServerUri", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tbTFSUri, "tbTFSUri")
        Me.tbTFSUri.Name = "tbTFSUri"
        Me.tbTFSUri.ReadOnly = True
        Me.tbTFSUri.Text = Global.VBWinformTFSTreeView.My.MySettings.Default.DefaultServerUri
        '
        'btnConnect
        '
        resources.ApplyResources(Me.btnConnect, "btnConnect")
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        resources.ApplyResources(Me.imageList, "imageList")
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'tvwSourceBrowser
        '
        resources.ApplyResources(Me.tvwSourceBrowser, "tvwSourceBrowser")
        Me.tvwSourceBrowser.Name = "tvwSourceBrowser"
        '
        'SCForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gpbConnectToTFS)
        Me.Controls.Add(Me.tvwSourceBrowser)
        Me.Name = "SCForm"
        Me.gpbConnectToTFS.ResumeLayout(False)
        Me.tlpConnectToTFS.ResumeLayout(False)
        Me.tlpConnectToTFS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gpbConnectToTFS As System.Windows.Forms.GroupBox
    Private WithEvents tlpConnectToTFS As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lbTFSName As System.Windows.Forms.Label
    Private WithEvents tbTFSUri As System.Windows.Forms.TextBox
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Private WithEvents tvwSourceBrowser As System.Windows.Forms.TreeView

End Class
