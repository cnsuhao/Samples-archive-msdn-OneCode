
Partial Public Class ProcessSelector
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

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.lstProcess = New ListBox()
        Me.btnOK = New Button()
        Me.btnCancel = New Button()
        Me.btnRefresh = New Button()
        Me.radLaunchApplication = New RadioButton()
        Me.tbApplicationPath = New TextBox()
        Me.btnBrowse = New Button()
        Me.radDebugRunningProcess = New RadioButton()
        Me.lbNote = New Label()
        Me.SuspendLayout()
        ' 
        ' lstProcess
        ' 
        Me.lstProcess.DisplayMember = "ProcessName"
        Me.lstProcess.FormattingEnabled = True
        Me.lstProcess.Location = New Point(42, 103)
        Me.lstProcess.Name = "lstProcess"
        Me.lstProcess.Size = New Size(483, 277)
        Me.lstProcess.TabIndex = 3
        ' 
        ' btnOK
        ' 
        Me.btnOK.Location = New Point(450, 400)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click)
        ' 
        ' btnCancel
        ' 
        Me.btnCancel.Location = New Point(532, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
        ' 
        ' btnRefresh
        ' 
        Me.btnRefresh.Location = New Point(532, 103)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New Size(75, 23)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '			Me.btnRefresh.Click += New System.EventHandler(Me.btnRefresh_Click)
        ' 
        ' radLaunchApplication
        ' 
        Me.radLaunchApplication.AutoSize = True
        Me.radLaunchApplication.Checked = True
        Me.radLaunchApplication.Location = New Point(23, 13)
        Me.radLaunchApplication.Name = "radLaunchApplication"
        Me.radLaunchApplication.Size = New Size(175, 17)
        Me.radLaunchApplication.TabIndex = 6
        Me.radLaunchApplication.TabStop = True
        Me.radLaunchApplication.Text = "Launch an application to debug"
        Me.radLaunchApplication.UseVisualStyleBackColor = True
        ' 
        ' tbApplicationPath
        ' 
        Me.tbApplicationPath.Location = New Point(42, 37)
        Me.tbApplicationPath.Name = "tbApplicationPath"
        Me.tbApplicationPath.ReadOnly = True
        Me.tbApplicationPath.Size = New Size(483, 20)
        Me.tbApplicationPath.TabIndex = 7
        ' 
        ' btnBrowse
        ' 
        Me.btnBrowse.Location = New Point(532, 34)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New Size(75, 23)
        Me.btnBrowse.TabIndex = 8
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '			Me.btnBrowse.Click += New System.EventHandler(Me.btnBrowse_Click)
        ' 
        ' radDebugRunningProcess
        ' 
        Me.radDebugRunningProcess.AutoSize = True
        Me.radDebugRunningProcess.Location = New Point(23, 80)
        Me.radDebugRunningProcess.Name = "radDebugRunningProcess"
        Me.radDebugRunningProcess.Size = New Size(144, 17)
        Me.radDebugRunningProcess.TabIndex = 6
        Me.radDebugRunningProcess.TabStop = True
        Me.radDebugRunningProcess.Text = "Debug a running process"
        Me.radDebugRunningProcess.UseVisualStyleBackColor = True
        ' 
        ' lbNote
        ' 
        Me.lbNote.AutoSize = True
        Me.lbNote.Location = New Point(39, 397)
        Me.lbNote.Name = "lbNote"
        Me.lbNote.Size = New Size(307, 26)
        Me.lbNote.TabIndex = 9
        Me.lbNote.Text = "NOTE:" & vbCrLf & "Make sure that the application has symbol file and source code."
        ' 
        ' ProcessSelector
        ' 
        Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(610, 435)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbNote)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbApplicationPath)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.radDebugRunningProcess)
        Me.Controls.Add(Me.radLaunchApplication)
        Me.Controls.Add(Me.lstProcess)
        Me.Name = "ProcessSelector"
        Me.Text = "ProcessSelector"
        '			Me.Load += New System.EventHandler(Me.ProcessSelector_Load)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private lstProcess As ListBox
    Private WithEvents btnOK As Button
    Private WithEvents btnCancel As Button
    Private WithEvents btnRefresh As Button
    Private radLaunchApplication As RadioButton
    Private tbApplicationPath As TextBox
    Private WithEvents btnBrowse As Button
    Private radDebugRunningProcess As RadioButton
    Private lbNote As Label
End Class