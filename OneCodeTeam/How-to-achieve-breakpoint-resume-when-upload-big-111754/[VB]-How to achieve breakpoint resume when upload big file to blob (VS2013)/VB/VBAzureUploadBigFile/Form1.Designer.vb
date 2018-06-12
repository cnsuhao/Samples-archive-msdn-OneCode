<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.browseFile = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.uploadBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(30, 53)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.[ReadOnly] = True
        Me.textBox1.Size = New System.Drawing.Size(301, 20)
        Me.textBox1.TabIndex = 0
        ' 
        ' browseFile
        ' 
        Me.browseFile.Location = New System.Drawing.Point(354, 51)
        Me.browseFile.Name = "browseFile"
        Me.browseFile.Size = New System.Drawing.Size(75, 23)
        Me.browseFile.TabIndex = 1
        Me.browseFile.Text = "Browse"
        Me.browseFile.UseVisualStyleBackColor = True
        AddHandler Me.browseFile.Click, New System.EventHandler(AddressOf Me.browseFile_Click)
        ' 
        ' btnStart
        ' 
        Me.btnStart.Location = New System.Drawing.Point(59, 119)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        AddHandler Me.btnStart.Click, New System.EventHandler(AddressOf Me.btnStart_Click)
        ' 
        ' btnEnd
        ' 
        Me.btnEnd.Location = New System.Drawing.Point(233, 118)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(75, 23)
        Me.btnEnd.TabIndex = 3
        Me.btnEnd.Text = "End"
        Me.btnEnd.UseVisualStyleBackColor = True
        AddHandler Me.btnEnd.Click, New System.EventHandler(AddressOf Me.btnEnd_Click)
        ' 
        ' openFileDialog1
        ' 
        Me.openFileDialog1.FileName = "openFileDialog1"
        ' 
        ' uploadBackgroundWorker
        ' 
        Me.uploadBackgroundWorker.WorkerReportsProgress = True
        Me.uploadBackgroundWorker.WorkerSupportsCancellation = True
        AddHandler Me.uploadBackgroundWorker.DoWork, New System.ComponentModel.DoWorkEventHandler(AddressOf Me.uploadBackgroundWorker_DoWork)
        AddHandler Me.uploadBackgroundWorker.ProgressChanged, New System.ComponentModel.ProgressChangedEventHandler(AddressOf Me.uploadBackgroundWorker_ProgressChanged)
        AddHandler Me.uploadBackgroundWorker.RunWorkerCompleted, New System.ComponentModel.RunWorkerCompletedEventHandler(AddressOf Me.uploadBackgroundWorker_RunWorkerCompleted)
        ' 
        ' progressBar1
        ' 
        Me.progressBar1.Location = New System.Drawing.Point(59, 176)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(249, 23)
        Me.progressBar1.TabIndex = 4
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 261)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.browseFile)
        Me.Controls.Add(Me.textBox1)
        Me.Name = "Form1"
        Me.Text = "Put Lock Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private textBox1 As System.Windows.Forms.TextBox
    Private browseFile As System.Windows.Forms.Button
    Private btnStart As System.Windows.Forms.Button
    Private btnEnd As System.Windows.Forms.Button
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private uploadBackgroundWorker As System.ComponentModel.BackgroundWorker
    Private progressBar1 As System.Windows.Forms.ProgressBar

End Class
