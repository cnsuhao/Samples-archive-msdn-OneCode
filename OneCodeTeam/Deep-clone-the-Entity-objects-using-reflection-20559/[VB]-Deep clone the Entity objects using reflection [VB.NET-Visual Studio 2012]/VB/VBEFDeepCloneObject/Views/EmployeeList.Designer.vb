Namespace VBEFDeepCloneObject

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeList
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
            Me.btnClone = New System.Windows.Forms.Button()
            Me.dsInfoGridView = New System.Windows.Forms.DataGridView()
            Me.lblDsInfo = New System.Windows.Forms.Label()
            Me.bsInfoGridView = New System.Windows.Forms.DataGridView()
            Me.lblBasicSalesInfo = New System.Windows.Forms.Label()
            Me.btnSales = New System.Windows.Forms.Button()
            Me.empAddressGridView = New System.Windows.Forms.DataGridView()
            Me.lblEmpAddress = New System.Windows.Forms.Label()
            Me.lblEmployee = New System.Windows.Forms.Label()
            Me.btnCreate = New System.Windows.Forms.Button()
            Me.employeeGridView = New System.Windows.Forms.DataGridView()
            CType(Me.dsInfoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInfoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.empAddressGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.employeeGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClone
            '
            Me.btnClone.Location = New System.Drawing.Point(253, 172)
            Me.btnClone.Name = "btnClone"
            Me.btnClone.Size = New System.Drawing.Size(75, 23)
            Me.btnClone.TabIndex = 22
            Me.btnClone.Text = "Clone"
            Me.btnClone.UseVisualStyleBackColor = True
            '
            'dsInfoGridView
            '
            Me.dsInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dsInfoGridView.Location = New System.Drawing.Point(34, 468)
            Me.dsInfoGridView.Name = "dsInfoGridView"
            Me.dsInfoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dsInfoGridView.Size = New System.Drawing.Size(554, 146)
            Me.dsInfoGridView.TabIndex = 21
            '
            'lblDsInfo
            '
            Me.lblDsInfo.AutoSize = True
            Me.lblDsInfo.Location = New System.Drawing.Point(31, 452)
            Me.lblDsInfo.Name = "lblDsInfo"
            Me.lblDsInfo.Size = New System.Drawing.Size(78, 13)
            Me.lblDsInfo.TabIndex = 20
            Me.lblDsInfo.Text = "DetailSalesInfo"
            '
            'bsInfoGridView
            '
            Me.bsInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.bsInfoGridView.Location = New System.Drawing.Point(34, 339)
            Me.bsInfoGridView.Name = "bsInfoGridView"
            Me.bsInfoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.bsInfoGridView.Size = New System.Drawing.Size(554, 110)
            Me.bsInfoGridView.TabIndex = 19
            '
            'lblBasicSalesInfo
            '
            Me.lblBasicSalesInfo.AutoSize = True
            Me.lblBasicSalesInfo.Location = New System.Drawing.Point(31, 323)
            Me.lblBasicSalesInfo.Name = "lblBasicSalesInfo"
            Me.lblBasicSalesInfo.Size = New System.Drawing.Size(77, 13)
            Me.lblBasicSalesInfo.TabIndex = 18
            Me.lblBasicSalesInfo.Text = "BasicSalesInfo"
            '
            'btnSales
            '
            Me.btnSales.Location = New System.Drawing.Point(129, 172)
            Me.btnSales.Name = "btnSales"
            Me.btnSales.Size = New System.Drawing.Size(102, 23)
            Me.btnSales.TabIndex = 17
            Me.btnSales.Text = "CreateSalesInfo"
            Me.btnSales.UseVisualStyleBackColor = True
            '
            'empAddressGridView
            '
            Me.empAddressGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.empAddressGridView.Location = New System.Drawing.Point(34, 214)
            Me.empAddressGridView.Name = "empAddressGridView"
            Me.empAddressGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.empAddressGridView.Size = New System.Drawing.Size(554, 106)
            Me.empAddressGridView.TabIndex = 16
            '
            'lblEmpAddress
            '
            Me.lblEmpAddress.AutoSize = True
            Me.lblEmpAddress.Location = New System.Drawing.Point(31, 198)
            Me.lblEmpAddress.Name = "lblEmpAddress"
            Me.lblEmpAddress.Size = New System.Drawing.Size(66, 13)
            Me.lblEmpAddress.TabIndex = 15
            Me.lblEmpAddress.Text = "EmpAddress"
            '
            'lblEmployee
            '
            Me.lblEmployee.AutoSize = True
            Me.lblEmployee.Location = New System.Drawing.Point(31, 9)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(53, 13)
            Me.lblEmployee.TabIndex = 14
            Me.lblEmployee.Text = "Employee"
            '
            'btnCreate
            '
            Me.btnCreate.Location = New System.Drawing.Point(33, 172)
            Me.btnCreate.Name = "btnCreate"
            Me.btnCreate.Size = New System.Drawing.Size(75, 23)
            Me.btnCreate.TabIndex = 13
            Me.btnCreate.Text = "Create"
            Me.btnCreate.UseVisualStyleBackColor = True
            '
            'employeeGridView
            '
            Me.employeeGridView.AllowDrop = True
            Me.employeeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.employeeGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
            Me.employeeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.employeeGridView.Location = New System.Drawing.Point(34, 25)
            Me.employeeGridView.MultiSelect = False
            Me.employeeGridView.Name = "employeeGridView"
            Me.employeeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.employeeGridView.Size = New System.Drawing.Size(554, 141)
            Me.employeeGridView.TabIndex = 12
            '
            'EmployeeList
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(619, 623)
            Me.Controls.Add(Me.btnClone)
            Me.Controls.Add(Me.dsInfoGridView)
            Me.Controls.Add(Me.lblDsInfo)
            Me.Controls.Add(Me.bsInfoGridView)
            Me.Controls.Add(Me.lblBasicSalesInfo)
            Me.Controls.Add(Me.btnSales)
            Me.Controls.Add(Me.empAddressGridView)
            Me.Controls.Add(Me.lblEmpAddress)
            Me.Controls.Add(Me.lblEmployee)
            Me.Controls.Add(Me.btnCreate)
            Me.Controls.Add(Me.employeeGridView)
            Me.Name = "EmployeeList"
            Me.Text = "EmployeeList"
            CType(Me.dsInfoGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInfoGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.empAddressGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.employeeGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents btnClone As System.Windows.Forms.Button
        Private WithEvents dsInfoGridView As System.Windows.Forms.DataGridView
        Private WithEvents lblDsInfo As System.Windows.Forms.Label
        Private WithEvents bsInfoGridView As System.Windows.Forms.DataGridView
        Private WithEvents lblBasicSalesInfo As System.Windows.Forms.Label
        Private WithEvents btnSales As System.Windows.Forms.Button
        Private WithEvents empAddressGridView As System.Windows.Forms.DataGridView
        Private WithEvents lblEmpAddress As System.Windows.Forms.Label
        Private WithEvents lblEmployee As System.Windows.Forms.Label
        Private WithEvents btnCreate As System.Windows.Forms.Button
        Private WithEvents employeeGridView As System.Windows.Forms.DataGridView
    End Class

End Namespace
