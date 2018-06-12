<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.cboSearch = New System.Windows.Forms.ComboBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMatchWholeWord = New System.Windows.Forms.CheckBox()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panelColor = New System.Windows.Forms.Panel()
        Me.btnSearchAndHighlight = New System.Windows.Forms.Button()
        Me.rtbSource = New VBWinFormSearchAndHighlightText.CustomRichTextBox(Me.components)
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSearch
        '
        resources.ApplyResources(Me.lblSearch, "lblSearch")
        Me.lblSearch.Name = "lblSearch"
        '
        'cboSearch
        '
        resources.ApplyResources(Me.cboSearch, "cboSearch")
        Me.cboSearch.FormattingEnabled = True
        Me.cboSearch.Name = "cboSearch"
        '
        'groupBox1
        '
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Controls.Add(Me.chkMatchWholeWord)
        Me.groupBox1.Controls.Add(Me.chkMatchCase)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'chkMatchWholeWord
        '
        resources.ApplyResources(Me.chkMatchWholeWord, "chkMatchWholeWord")
        Me.chkMatchWholeWord.Name = "chkMatchWholeWord"
        Me.chkMatchWholeWord.UseVisualStyleBackColor = True
        '
        'chkMatchCase
        '
        resources.ApplyResources(Me.chkMatchCase, "chkMatchCase")
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.UseVisualStyleBackColor = True
        '
        'label1
        '
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        '
        'panelColor
        '
        resources.ApplyResources(Me.panelColor, "panelColor")
        Me.panelColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.panelColor.Name = "panelColor"
        '
        'btnSearchAndHighlight
        '
        resources.ApplyResources(Me.btnSearchAndHighlight, "btnSearchAndHighlight")
        Me.btnSearchAndHighlight.Name = "btnSearchAndHighlight"
        Me.btnSearchAndHighlight.UseVisualStyleBackColor = True
        '
        'rtbSource
        '
        resources.ApplyResources(Me.rtbSource, "rtbSource")
        Me.rtbSource.Name = "rtbSource"
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSearchAndHighlight)
        Me.Controls.Add(Me.panelColor)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.cboSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.rtbSource)
        Me.Name = "MainForm"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbSource As VBWinFormSearchAndHighlightText.CustomRichTextBox
    Private WithEvents lblSearch As System.Windows.Forms.Label
    Private WithEvents cboSearch As System.Windows.Forms.ComboBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents chkMatchWholeWord As System.Windows.Forms.CheckBox
    Private WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents panelColor As System.Windows.Forms.Panel
    Private WithEvents btnSearchAndHighlight As System.Windows.Forms.Button

End Class
