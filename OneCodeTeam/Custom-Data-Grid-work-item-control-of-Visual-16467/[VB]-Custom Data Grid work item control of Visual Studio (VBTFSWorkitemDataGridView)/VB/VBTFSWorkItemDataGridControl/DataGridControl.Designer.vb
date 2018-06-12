
Partial Public Class DataGridControl
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.gvData = New DataGridView()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' gvData
        ' 
        Me.gvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvData.Dock = DockStyle.Fill
        Me.gvData.Location = New Point(0, 0)
        Me.gvData.Name = "gvData"
        Me.gvData.Size = New Size(679, 224)
        Me.gvData.TabIndex = 0
        '			Me.gvData.CellValueChanged += New System.Windows.Forms.DataGridViewCellEventHandler(Me.gvData_CellValueChanged)
        '			Me.gvData.UserDeletedRow += New System.Windows.Forms.DataGridViewRowEventHandler(Me.gvData_UserDeletedRow)
        ' 
        ' DataGridControl
        ' 
        Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.Controls.Add(Me.gvData)
        Me.Name = "DataGridControl"
        Me.Size = New Size(679, 224)
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents gvData As DataGridView
End Class

