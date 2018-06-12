<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnUpdateDesignerRegion = New System.Windows.Forms.Button
        Me.btnShowAnimation = New System.Windows.Forms.Button
        Me.btnShowProgressBar = New System.Windows.Forms.Button
        Me.btnReadFeedback = New System.Windows.Forms.Button
        Me.btnWriteFeedback = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnUpdateDesignerRegion
        '
        Me.btnUpdateDesignerRegion.Location = New System.Drawing.Point(46, 180)
        Me.btnUpdateDesignerRegion.Name = "btnUpdateDesignerRegion"
        Me.btnUpdateDesignerRegion.Size = New System.Drawing.Size(309, 23)
        Me.btnUpdateDesignerRegion.TabIndex = 9
        Me.btnUpdateDesignerRegion.Text = "Update Designer Region"
        Me.btnUpdateDesignerRegion.UseVisualStyleBackColor = True
        '
        'btnShowAnimation
        '
        Me.btnShowAnimation.Location = New System.Drawing.Point(46, 150)
        Me.btnShowAnimation.Name = "btnShowAnimation"
        Me.btnShowAnimation.Size = New System.Drawing.Size(309, 23)
        Me.btnShowAnimation.TabIndex = 8
        Me.btnShowAnimation.Text = "Show Animation in Status Bar"
        Me.btnShowAnimation.UseVisualStyleBackColor = True
        '
        'btnShowProgressBar
        '
        Me.btnShowProgressBar.Location = New System.Drawing.Point(46, 120)
        Me.btnShowProgressBar.Name = "btnShowProgressBar"
        Me.btnShowProgressBar.Size = New System.Drawing.Size(309, 23)
        Me.btnShowProgressBar.TabIndex = 7
        Me.btnShowProgressBar.Text = "Show Progress Bar"
        Me.btnShowProgressBar.UseVisualStyleBackColor = True
        '
        'btnReadFeedback
        '
        Me.btnReadFeedback.Location = New System.Drawing.Point(46, 90)
        Me.btnReadFeedback.Name = "btnReadFeedback"
        Me.btnReadFeedback.Size = New System.Drawing.Size(309, 23)
        Me.btnReadFeedback.TabIndex = 6
        Me.btnReadFeedback.Text = "Read Feedback in Status Bar"
        Me.btnReadFeedback.UseVisualStyleBackColor = True
        '
        'btnWriteFeedback
        '
        Me.btnWriteFeedback.Location = New System.Drawing.Point(46, 60)
        Me.btnWriteFeedback.Name = "btnWriteFeedback"
        Me.btnWriteFeedback.Size = New System.Drawing.Size(309, 23)
        Me.btnWriteFeedback.TabIndex = 5
        Me.btnWriteFeedback.Text = "Write Feedback in Status Bar"
        Me.btnWriteFeedback.UseVisualStyleBackColor = True
        '
        'MyControl
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.btnUpdateDesignerRegion)
        Me.Controls.Add(Me.btnShowAnimation)
        Me.Controls.Add(Me.btnShowProgressBar)
        Me.Controls.Add(Me.btnReadFeedback)
        Me.Controls.Add(Me.btnWriteFeedback)
        Me.Name = "MyControl"
        Me.Size = New System.Drawing.Size(400, 263)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnUpdateDesignerRegion As System.Windows.Forms.Button
    Private WithEvents btnShowAnimation As System.Windows.Forms.Button
    Private WithEvents btnShowProgressBar As System.Windows.Forms.Button
    Private WithEvents btnReadFeedback As System.Windows.Forms.Button
    Private WithEvents btnWriteFeedback As System.Windows.Forms.Button

End Class