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
        Me.label1 = New System.Windows.Forms.Label()
        Me.txbExcelPath = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.grbCompareCol = New System.Windows.Forms.GroupBox()
        Me.btnCompareCol = New System.Windows.Forms.Button()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txbTargetCol = New System.Windows.Forms.TextBox()
        Me.txbSourceCol = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.grbCompareSheets = New System.Windows.Forms.GroupBox()
        Me.btnCompareSheet = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txbTargetSheet = New System.Windows.Forms.TextBox()
        Me.txbSourceSheet = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.grbCompareCol.SuspendLayout()
        Me.grbCompareSheets.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(18, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Source Excel File:"
        '
        'txbExcelPath
        '
        Me.txbExcelPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbExcelPath.Location = New System.Drawing.Point(116, 12)
        Me.txbExcelPath.Name = "txbExcelPath"
        Me.txbExcelPath.Size = New System.Drawing.Size(475, 20)
        Me.txbExcelPath.TabIndex = 2
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(597, 9)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 3
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'grbCompareCol
        '
        Me.grbCompareCol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grbCompareCol.Controls.Add(Me.btnCompareCol)
        Me.grbCompareCol.Controls.Add(Me.label5)
        Me.grbCompareCol.Controls.Add(Me.txbTargetCol)
        Me.grbCompareCol.Controls.Add(Me.txbSourceCol)
        Me.grbCompareCol.Controls.Add(Me.label4)
        Me.grbCompareCol.Location = New System.Drawing.Point(12, 49)
        Me.grbCompareCol.Name = "grbCompareCol"
        Me.grbCompareCol.Size = New System.Drawing.Size(321, 128)
        Me.grbCompareCol.TabIndex = 5
        Me.grbCompareCol.TabStop = False
        Me.grbCompareCol.Text = "Comprare Columns"
        '
        'btnCompareCol
        '
        Me.btnCompareCol.Location = New System.Drawing.Point(9, 58)
        Me.btnCompareCol.Name = "btnCompareCol"
        Me.btnCompareCol.Size = New System.Drawing.Size(145, 23)
        Me.btnCompareCol.TabIndex = 5
        Me.btnCompareCol.Text = "Compare Columns"
        Me.btnCompareCol.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(160, 28)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(79, 13)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Target Column:"
        '
        'txbTargetCol
        '
        Me.txbTargetCol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbTargetCol.Location = New System.Drawing.Point(245, 25)
        Me.txbTargetCol.Name = "txbTargetCol"
        Me.txbTargetCol.Size = New System.Drawing.Size(60, 20)
        Me.txbTargetCol.TabIndex = 3
        '
        'txbSourceCol
        '
        Me.txbSourceCol.Location = New System.Drawing.Point(94, 25)
        Me.txbSourceCol.Name = "txbSourceCol"
        Me.txbSourceCol.Size = New System.Drawing.Size(60, 20)
        Me.txbSourceCol.TabIndex = 2
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 28)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(82, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Source Column:"
        '
        'grbCompareSheets
        '
        Me.grbCompareSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCompareSheets.Controls.Add(Me.btnCompareSheet)
        Me.grbCompareSheets.Controls.Add(Me.label2)
        Me.grbCompareSheets.Controls.Add(Me.txbTargetSheet)
        Me.grbCompareSheets.Controls.Add(Me.txbSourceSheet)
        Me.grbCompareSheets.Controls.Add(Me.label3)
        Me.grbCompareSheets.Location = New System.Drawing.Point(339, 49)
        Me.grbCompareSheets.Name = "grbCompareSheets"
        Me.grbCompareSheets.Size = New System.Drawing.Size(333, 128)
        Me.grbCompareSheets.TabIndex = 6
        Me.grbCompareSheets.TabStop = False
        Me.grbCompareSheets.Text = "Comprare Sheets"
        '
        'btnCompareSheet
        '
        Me.btnCompareSheet.Location = New System.Drawing.Point(9, 58)
        Me.btnCompareSheet.Name = "btnCompareSheet"
        Me.btnCompareSheet.Size = New System.Drawing.Size(138, 23)
        Me.btnCompareSheet.TabIndex = 5
        Me.btnCompareSheet.Text = "Compare Sheets"
        Me.btnCompareSheet.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(153, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Target Sheet:"
        '
        'txbTargetSheet
        '
        Me.txbTargetSheet.Location = New System.Drawing.Point(231, 25)
        Me.txbTargetSheet.Name = "txbTargetSheet"
        Me.txbTargetSheet.Size = New System.Drawing.Size(56, 20)
        Me.txbTargetSheet.TabIndex = 3
        '
        'txbSourceSheet
        '
        Me.txbSourceSheet.Location = New System.Drawing.Point(87, 25)
        Me.txbSourceSheet.Name = "txbSourceSheet"
        Me.txbSourceSheet.Size = New System.Drawing.Size(60, 20)
        Me.txbSourceSheet.TabIndex = 2
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 28)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(75, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Source Sheet:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 189)
        Me.Controls.Add(Me.grbCompareSheets)
        Me.Controls.Add(Me.grbCompareCol)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txbExcelPath)
        Me.Controls.Add(Me.label1)
        Me.MinimumSize = New System.Drawing.Size(670, 190)
        Me.Name = "MainForm"
        Me.Text = "Compare Cells"
        Me.grbCompareCol.ResumeLayout(False)
        Me.grbCompareCol.PerformLayout()
        Me.grbCompareSheets.ResumeLayout(False)
        Me.grbCompareSheets.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txbExcelPath As System.Windows.Forms.TextBox
    Private WithEvents btnSelect As System.Windows.Forms.Button
    Private WithEvents grbCompareCol As System.Windows.Forms.GroupBox
    Private WithEvents btnCompareCol As System.Windows.Forms.Button
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txbTargetCol As System.Windows.Forms.TextBox
    Private WithEvents txbSourceCol As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents grbCompareSheets As System.Windows.Forms.GroupBox
    Private WithEvents btnCompareSheet As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txbTargetSheet As System.Windows.Forms.TextBox
    Private WithEvents txbSourceSheet As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label

End Class
