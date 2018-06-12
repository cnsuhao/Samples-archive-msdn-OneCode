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
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGetPlainText = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.tbxFile = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.rtbText = New System.Windows.Forms.RichTextBox()
        Me.btnSaveas = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.btnGetPlainText)
        Me.groupBox1.Controls.Add(Me.btnOpen)
        Me.groupBox1.Controls.Add(Me.tbxFile)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(13, 13)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(467, 100)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Microsoft Word Docx File"
        '
        'btnGetPlainText
        '
        Me.btnGetPlainText.Location = New System.Drawing.Point(14, 64)
        Me.btnGetPlainText.Name = "btnGetPlainText"
        Me.btnGetPlainText.Size = New System.Drawing.Size(117, 23)
        Me.btnGetPlainText.TabIndex = 3
        Me.btnGetPlainText.Text = "Get Plain Text"
        Me.btnGetPlainText.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(379, 35)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'tbxFile
        '
        Me.tbxFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxFile.Location = New System.Drawing.Point(14, 37)
        Me.tbxFile.Name = "tbxFile"
        Me.tbxFile.Size = New System.Drawing.Size(359, 20)
        Me.tbxFile.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Docx file:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(24, 132)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(102, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Plain text in Word："
        '
        'rtbText
        '
        Me.rtbText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbText.BackColor = System.Drawing.SystemColors.Window
        Me.rtbText.Location = New System.Drawing.Point(13, 152)
        Me.rtbText.Name = "rtbText"
        Me.rtbText.ReadOnly = True
        Me.rtbText.Size = New System.Drawing.Size(467, 169)
        Me.rtbText.TabIndex = 3
        Me.rtbText.Text = ""
        '
        'btnSaveas
        '
        Me.btnSaveas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveas.Location = New System.Drawing.Point(12, 327)
        Me.btnSaveas.Name = "btnSaveas"
        Me.btnSaveas.Size = New System.Drawing.Size(94, 23)
        Me.btnSaveas.TabIndex = 5
        Me.btnSaveas.Text = "Save as Text"
        Me.btnSaveas.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.btnSaveas)
        Me.Controls.Add(Me.rtbText)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.groupBox1)
        Me.MinimumSize = New System.Drawing.Size(350, 300)
        Me.Name = "MainForm"
        Me.Text = "GetPlainTextFromWord"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnGetPlainText As System.Windows.Forms.Button
    Private WithEvents btnOpen As System.Windows.Forms.Button
    Private WithEvents tbxFile As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents rtbText As System.Windows.Forms.RichTextBox
    Private WithEvents btnSaveas As System.Windows.Forms.Button

End Class
