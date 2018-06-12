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
        Me.picDisplay = New System.Windows.Forms.PictureBox
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDisplay
        '
        Me.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picDisplay.Location = New System.Drawing.Point(0, 0)
        Me.picDisplay.Name = "picDisplay"
        Me.picDisplay.Size = New System.Drawing.Size(342, 419)
        Me.picDisplay.TabIndex = 0
        Me.picDisplay.TabStop = False
        '
        'MyControl
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.picDisplay)
        Me.Name = "MyControl"
        Me.Size = New System.Drawing.Size(342, 419)
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picDisplay As System.Windows.Forms.PictureBox

End Class