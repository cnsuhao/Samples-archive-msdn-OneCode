<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OutlookContacts
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBrowseImp = New System.Windows.Forms.Button()
        Me.tbxImportExcel = New System.Windows.Forms.TextBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Click Export button to export outlook contacts："
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(12, 61)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(58, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Please select Excel spreadsheet to import："
        '
        'btnBrowseImp
        '
        Me.btnBrowseImp.Location = New System.Drawing.Point(157, 147)
        Me.btnBrowseImp.Name = "btnBrowseImp"
        Me.btnBrowseImp.Size = New System.Drawing.Size(58, 23)
        Me.btnBrowseImp.TabIndex = 5
        Me.btnBrowseImp.Text = "Browse"
        Me.btnBrowseImp.UseVisualStyleBackColor = True
        '
        'tbxImportExcel
        '
        Me.tbxImportExcel.Location = New System.Drawing.Point(15, 147)
        Me.tbxImportExcel.Name = "tbxImportExcel"
        Me.tbxImportExcel.Size = New System.Drawing.Size(136, 20)
        Me.tbxImportExcel.TabIndex = 4
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(15, 173)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(58, 23)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'OutlookContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 227)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.tbxImportExcel)
        Me.Controls.Add(Me.btnBrowseImp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "OutlookContacts"
        Me.Text = "ContactsExportImport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents btnExport As System.Windows.Forms.Button
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents btnBrowseImp As System.Windows.Forms.Button
    Private WithEvents tbxImportExcel As System.Windows.Forms.TextBox
    Private WithEvents btnImport As System.Windows.Forms.Button

End Class
