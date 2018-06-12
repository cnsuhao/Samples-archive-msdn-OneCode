Namespace VBEFDeepCloneObject

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SalesInfo
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
            Me.cbxEmpId = New System.Windows.Forms.ComboBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.cbxYear = New System.Windows.Forms.ComboBox()
            Me.lblYear = New System.Windows.Forms.Label()
            Me.tbxSales = New System.Windows.Forms.TextBox()
            Me.lblSales = New System.Windows.Forms.Label()
            Me.lblEmpId = New System.Windows.Forms.Label()
            Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cbxEmpId
            '
            Me.cbxEmpId.FormattingEnabled = True
            Me.cbxEmpId.Location = New System.Drawing.Point(50, 32)
            Me.cbxEmpId.Name = "cbxEmpId"
            Me.cbxEmpId.Size = New System.Drawing.Size(121, 21)
            Me.cbxEmpId.TabIndex = 14
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(15, 162)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 13
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'cbxYear
            '
            Me.cbxYear.FormattingEnabled = True
            Me.cbxYear.Location = New System.Drawing.Point(50, 112)
            Me.cbxYear.Name = "cbxYear"
            Me.cbxYear.Size = New System.Drawing.Size(121, 21)
            Me.cbxYear.TabIndex = 12
            '
            'lblYear
            '
            Me.lblYear.AutoSize = True
            Me.lblYear.Location = New System.Drawing.Point(12, 115)
            Me.lblYear.Name = "lblYear"
            Me.lblYear.Size = New System.Drawing.Size(29, 13)
            Me.lblYear.TabIndex = 11
            Me.lblYear.Text = "Year"
            '
            'tbxSales
            '
            Me.tbxSales.Location = New System.Drawing.Point(50, 76)
            Me.tbxSales.Name = "tbxSales"
            Me.tbxSales.Size = New System.Drawing.Size(100, 20)
            Me.tbxSales.TabIndex = 10
            '
            'lblSales
            '
            Me.lblSales.AutoSize = True
            Me.lblSales.Location = New System.Drawing.Point(12, 76)
            Me.lblSales.Name = "lblSales"
            Me.lblSales.Size = New System.Drawing.Size(33, 13)
            Me.lblSales.TabIndex = 9
            Me.lblSales.Text = "Sales"
            '
            'lblEmpId
            '
            Me.lblEmpId.AutoSize = True
            Me.lblEmpId.Location = New System.Drawing.Point(12, 32)
            Me.lblEmpId.Name = "lblEmpId"
            Me.lblEmpId.Size = New System.Drawing.Size(37, 13)
            Me.lblEmpId.TabIndex = 8
            Me.lblEmpId.Text = "EmpId"
            '
            'errorProvider
            '
            Me.errorProvider.ContainerControl = Me
            '
            'SalesInfo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(359, 197)
            Me.Controls.Add(Me.cbxEmpId)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.cbxYear)
            Me.Controls.Add(Me.lblYear)
            Me.Controls.Add(Me.tbxSales)
            Me.Controls.Add(Me.lblSales)
            Me.Controls.Add(Me.lblEmpId)
            Me.Name = "SalesInfo"
            Me.Text = "SalesInfo"
            CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents cbxEmpId As System.Windows.Forms.ComboBox
        Private WithEvents btnSave As System.Windows.Forms.Button
        Private WithEvents cbxYear As System.Windows.Forms.ComboBox
        Private WithEvents lblYear As System.Windows.Forms.Label
        Private WithEvents tbxSales As System.Windows.Forms.TextBox
        Private WithEvents lblSales As System.Windows.Forms.Label
        Private WithEvents lblEmpId As System.Windows.Forms.Label
        Private WithEvents errorProvider As System.Windows.Forms.ErrorProvider
    End Class

End Namespace

