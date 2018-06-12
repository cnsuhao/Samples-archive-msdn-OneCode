<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaneControl
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
        Me.btnInsertCC = New System.Windows.Forms.Button
        Me.btnInsertBuiltIn = New System.Windows.Forms.Button
        Me.btnCCXMLMapping = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnInsertCC
        '
        Me.btnInsertCC.Location = New System.Drawing.Point(0, 0)
        Me.btnInsertCC.Name = "btnInsertCC"
        Me.btnInsertCC.Size = New System.Drawing.Size(140, 23)
        Me.btnInsertCC.TabIndex = 0
        Me.btnInsertCC.Text = "Insert ContentControls"
        Me.btnInsertCC.UseVisualStyleBackColor = True
        '
        'btnInsertBuiltIn
        '
        Me.btnInsertBuiltIn.Location = New System.Drawing.Point(0, 29)
        Me.btnInsertBuiltIn.Name = "btnInsertBuiltIn"
        Me.btnInsertBuiltIn.Size = New System.Drawing.Size(140, 23)
        Me.btnInsertBuiltIn.TabIndex = 0
        Me.btnInsertBuiltIn.Text = "Insert Building Blocks"
        Me.btnInsertBuiltIn.UseVisualStyleBackColor = True
        '
        'btnCCXMLMapping
        '
        Me.btnCCXMLMapping.Location = New System.Drawing.Point(0, 58)
        Me.btnCCXMLMapping.Name = "btnCCXMLMapping"
        Me.btnCCXMLMapping.Size = New System.Drawing.Size(140, 47)
        Me.btnCCXMLMapping.TabIndex = 0
        Me.btnCCXMLMapping.Text = "Content Control XMLMapping "
        Me.btnCCXMLMapping.UseVisualStyleBackColor = True
        '
        'PaneControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCCXMLMapping)
        Me.Controls.Add(Me.btnInsertBuiltIn)
        Me.Controls.Add(Me.btnInsertCC)
        Me.Name = "PaneControl"
        Me.Size = New System.Drawing.Size(140, 119)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnInsertCC As System.Windows.Forms.Button
    Friend WithEvents btnInsertBuiltIn As System.Windows.Forms.Button
    Friend WithEvents btnCCXMLMapping As System.Windows.Forms.Button

End Class
