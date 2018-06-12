<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CourseQueryPane
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cboName = New System.Windows.Forms.ComboBox()
        Me.cmdQuery = New System.Windows.Forms.Button()
        Me.SchoolDataSet = New VBVstoExcelWorkbook.SchoolDataSet()
        Me.StudentListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StudentListTableAdapter = New VBVstoExcelWorkbook.SchoolDataSetTableAdapters.StudentListTableAdapter()
        CType(Me.SchoolDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StudentListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(103, 17)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Query Courses"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(0, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(49, 17)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'cboName
        '
        Me.cboName.DataSource = Me.StudentListBindingSource
        Me.cboName.DisplayMember = "StuName"
        Me.cboName.FormattingEnabled = True
        Me.cboName.Location = New System.Drawing.Point(70, 30)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(121, 24)
        Me.cboName.TabIndex = 1
        Me.cboName.ValueMember = "StuName"
        '
        'cmdQuery
        '
        Me.cmdQuery.Location = New System.Drawing.Point(90, 60)
        Me.cmdQuery.Name = "cmdQuery"
        Me.cmdQuery.Size = New System.Drawing.Size(75, 23)
        Me.cmdQuery.TabIndex = 2
        Me.cmdQuery.Text = "Query"
        Me.cmdQuery.UseVisualStyleBackColor = True
        '
        'SchoolDataSet
        '
        Me.SchoolDataSet.DataSetName = "SchoolDataSet"
        Me.SchoolDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StudentListBindingSource
        '
        Me.StudentListBindingSource.DataMember = "StudentList"
        Me.StudentListBindingSource.DataSource = Me.SchoolDataSet
        '
        'StudentListTableAdapter
        '
        Me.StudentListTableAdapter.ClearBeforeFill = True
        '
        'CourseQueryPane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdQuery)
        Me.Controls.Add(Me.cboName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "CourseQueryPane"
        Me.Size = New System.Drawing.Size(218, 104)
        CType(Me.SchoolDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StudentListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdQuery As System.Windows.Forms.Button
    Friend WithEvents StudentListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolDataSet As VBVstoExcelWorkbook.SchoolDataSet
    Friend WithEvents StudentListTableAdapter As VBVstoExcelWorkbook.SchoolDataSetTableAdapters.StudentListTableAdapter

End Class
