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
        Me.grbPowerPoint = New System.Windows.Forms.GroupBox()
        Me.btnOpenPPt = New System.Windows.Forms.Button()
        Me.txbPPtPath = New System.Windows.Forms.TextBox()
        Me.lblSourcePpt = New System.Windows.Forms.Label()
        Me.grbImage = New System.Windows.Forms.GroupBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnSelectImg = New System.Windows.Forms.Button()
        Me.txbImagePath = New System.Windows.Forms.TextBox()
        Me.lblSourceImg = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.grbPowerPoint.SuspendLayout()
        Me.grbImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPowerPoint
        '
        Me.grbPowerPoint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPowerPoint.Controls.Add(Me.btnOpenPPt)
        Me.grbPowerPoint.Controls.Add(Me.txbPPtPath)
        Me.grbPowerPoint.Controls.Add(Me.lblSourcePpt)
        Me.grbPowerPoint.Location = New System.Drawing.Point(13, 13)
        Me.grbPowerPoint.Name = "grbPowerPoint"
        Me.grbPowerPoint.Size = New System.Drawing.Size(432, 71)
        Me.grbPowerPoint.TabIndex = 0
        Me.grbPowerPoint.TabStop = False
        Me.grbPowerPoint.Text = "Source PowerPoint File"
        '
        'btnOpenPPt
        '
        Me.btnOpenPPt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenPPt.Location = New System.Drawing.Point(361, 23)
        Me.btnOpenPPt.Name = "btnOpenPPt"
        Me.btnOpenPPt.Size = New System.Drawing.Size(65, 23)
        Me.btnOpenPPt.TabIndex = 2
        Me.btnOpenPPt.Text = "Open"
        Me.btnOpenPPt.UseVisualStyleBackColor = True
        '
        'txbPPtPath
        '
        Me.txbPPtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbPPtPath.Location = New System.Drawing.Point(126, 26)
        Me.txbPPtPath.Name = "txbPPtPath"
        Me.txbPPtPath.Size = New System.Drawing.Size(229, 20)
        Me.txbPPtPath.TabIndex = 1
        '
        'lblSourcePpt
        '
        Me.lblSourcePpt.AutoSize = True
        Me.lblSourcePpt.Location = New System.Drawing.Point(7, 30)
        Me.lblSourcePpt.Name = "lblSourcePpt"
        Me.lblSourcePpt.Size = New System.Drawing.Size(115, 13)
        Me.lblSourcePpt.TabIndex = 0
        Me.lblSourcePpt.Text = "PPTX Document Path:"
        '
        'grbImage
        '
        Me.grbImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbImage.Controls.Add(Me.btnInsert)
        Me.grbImage.Controls.Add(Me.btnSelectImg)
        Me.grbImage.Controls.Add(Me.txbImagePath)
        Me.grbImage.Controls.Add(Me.lblSourceImg)
        Me.grbImage.Controls.Add(Me.label2)
        Me.grbImage.Location = New System.Drawing.Point(13, 102)
        Me.grbImage.Name = "grbImage"
        Me.grbImage.Size = New System.Drawing.Size(432, 103)
        Me.grbImage.TabIndex = 1
        Me.grbImage.TabStop = False
        Me.grbImage.Text = "Source Image"
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Location = New System.Drawing.Point(10, 66)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(64, 23)
        Me.btnInsert.TabIndex = 4
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnSelectImg
        '
        Me.btnSelectImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectImg.Location = New System.Drawing.Point(361, 30)
        Me.btnSelectImg.Name = "btnSelectImg"
        Me.btnSelectImg.Size = New System.Drawing.Size(64, 23)
        Me.btnSelectImg.TabIndex = 3
        Me.btnSelectImg.Text = "Select"
        Me.btnSelectImg.UseVisualStyleBackColor = True
        '
        'txbImagePath
        '
        Me.txbImagePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbImagePath.Location = New System.Drawing.Point(122, 32)
        Me.txbImagePath.Name = "txbImagePath"
        Me.txbImagePath.Size = New System.Drawing.Size(233, 20)
        Me.txbImagePath.TabIndex = 2
        '
        'lblSourceImg
        '
        Me.lblSourceImg.AutoSize = True
        Me.lblSourceImg.Location = New System.Drawing.Point(7, 35)
        Me.lblSourceImg.Name = "lblSourceImg"
        Me.lblSourceImg.Size = New System.Drawing.Size(109, 13)
        Me.lblSourceImg.TabIndex = 1
        Me.lblSourceImg.Text = "Inserted Picture Path:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 35)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(0, 13)
        Me.label2.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 240)
        Me.Controls.Add(Me.grbImage)
        Me.Controls.Add(Me.grbPowerPoint)
        Me.MinimumSize = New System.Drawing.Size(400, 260)
        Me.Name = "MainForm"
        Me.Text = "Insert Image into PowerPoint Form"
        Me.grbPowerPoint.ResumeLayout(False)
        Me.grbPowerPoint.PerformLayout()
        Me.grbImage.ResumeLayout(False)
        Me.grbImage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private grbPowerPoint As System.Windows.Forms.GroupBox
    Private WithEvents btnOpenPPt As System.Windows.Forms.Button
    Private txbPPtPath As System.Windows.Forms.TextBox
    Private lblSourcePpt As System.Windows.Forms.Label
    Private grbImage As System.Windows.Forms.GroupBox
    Private WithEvents btnInsert As System.Windows.Forms.Button
    Private WithEvents btnSelectImg As System.Windows.Forms.Button
    Private txbImagePath As System.Windows.Forms.TextBox
    Private lblSourceImg As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label

End Class
