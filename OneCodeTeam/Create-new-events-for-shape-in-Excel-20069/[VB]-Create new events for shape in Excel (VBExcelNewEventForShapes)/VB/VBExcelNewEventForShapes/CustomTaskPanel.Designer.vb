<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomTaskPanel
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
        Me.lstMessage = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstMessage
        '
        Me.lstMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMessage.FormattingEnabled = True
        Me.lstMessage.Location = New System.Drawing.Point(0, 0)
        Me.lstMessage.Margin = New System.Windows.Forms.Padding(0)
        Me.lstMessage.Name = "lstMessage"
        Me.lstMessage.ScrollAlwaysVisible = True
        Me.lstMessage.Size = New System.Drawing.Size(450, 498)
        Me.lstMessage.TabIndex = 0
        '
        'CustomTaskPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstMessage)
        Me.Name = "CustomTaskPanel"
        Me.Size = New System.Drawing.Size(450, 500)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstMessage As System.Windows.Forms.ListBox

End Class
