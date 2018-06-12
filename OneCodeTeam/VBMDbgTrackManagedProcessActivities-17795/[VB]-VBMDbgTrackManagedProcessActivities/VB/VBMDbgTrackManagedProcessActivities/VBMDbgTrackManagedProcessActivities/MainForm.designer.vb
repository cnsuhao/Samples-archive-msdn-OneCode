
Partial Public Class MainForm
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
        If disposing AndAlso (Me._managedProcess IsNot Nothing) Then
            Dim thread = MTAThreadHelper.RunInMTAThread(AddressOf _managedProcess.Dispose)
            thread.Join()
        End If
        MyBase.Dispose(disposing)
    End Sub



#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.lbApplicationToDebug = New Label()
        Me.lbProcess = New Label()
        Me.pnlOperation = New Panel()
        Me.btnDetach = New Button()
        Me.pnlThreads = New Panel()
        Me.tbActivities = New TextBox()
        Me.pnlOperation.SuspendLayout()
        Me.pnlThreads.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' lbApplicationToDebug
        ' 
        Me.lbApplicationToDebug.AutoSize = True
        Me.lbApplicationToDebug.Location = New Point(12, 9)
        Me.lbApplicationToDebug.Name = "lbApplicationToDebug"
        Me.lbApplicationToDebug.Size = New Size(113, 13)
        Me.lbApplicationToDebug.TabIndex = 0
        Me.lbApplicationToDebug.Text = "Application To Debug:"
        ' 
        ' lbProcess
        ' 
        Me.lbProcess.AutoSize = True
        Me.lbProcess.Location = New Point(150, 9)
        Me.lbProcess.Name = "lbProcess"
        Me.lbProcess.Size = New Size(0, 13)
        Me.lbProcess.TabIndex = 1
        ' 
        ' pnlOperation
        ' 
        Me.pnlOperation.Controls.Add(Me.btnDetach)
        Me.pnlOperation.Controls.Add(Me.lbApplicationToDebug)
        Me.pnlOperation.Controls.Add(Me.lbProcess)
        Me.pnlOperation.Dock = DockStyle.Top
        Me.pnlOperation.Location = New Point(0, 0)
        Me.pnlOperation.Name = "pnlOperation"
        Me.pnlOperation.Size = New Size(749, 34)
        Me.pnlOperation.TabIndex = 3
        ' 
        ' btnDetach
        ' 
        Me.btnDetach.Location = New Point(637, 4)
        Me.btnDetach.Name = "btnDetach"
        Me.btnDetach.Size = New Size(75, 23)
        Me.btnDetach.TabIndex = 3
        Me.btnDetach.Text = "Detach"
        Me.btnDetach.UseVisualStyleBackColor = True
        '			Me.btnDetach.Click += New System.EventHandler(Me.btnDetach_Click)
        ' 
        ' pnlThreads
        ' 
        Me.pnlThreads.Controls.Add(Me.tbActivities)
        Me.pnlThreads.Dock = DockStyle.Fill
        Me.pnlThreads.Location = New Point(0, 34)
        Me.pnlThreads.Name = "pnlThreads"
        Me.pnlThreads.Size = New Size(749, 570)
        Me.pnlThreads.TabIndex = 5
        ' 
        ' tbActivities
        ' 
        Me.tbActivities.Dock = DockStyle.Fill
        Me.tbActivities.Location = New Point(0, 0)
        Me.tbActivities.Multiline = True
        Me.tbActivities.Name = "tbActivities"
        Me.tbActivities.ScrollBars = ScrollBars.Both
        Me.tbActivities.Size = New Size(749, 570)
        Me.tbActivities.TabIndex = 0
        ' 
        ' MainForm
        ' 
        Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(749, 604)
        Me.Controls.Add(Me.pnlThreads)
        Me.Controls.Add(Me.pnlOperation)
        Me.Name = "MainForm"
        Me.Text = "VBMDbgTrackManagedProcessActivities"
        '			Me.Load += New System.EventHandler(Me.MainForm_Load)
        Me.pnlOperation.ResumeLayout(False)
        Me.pnlOperation.PerformLayout()
        Me.pnlThreads.ResumeLayout(False)
        Me.pnlThreads.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private lbApplicationToDebug As Label
    Private lbProcess As Label
    Private pnlOperation As Panel
    Private pnlThreads As Panel
    Private WithEvents btnDetach As Button
    Private tbActivities As TextBox
End Class


