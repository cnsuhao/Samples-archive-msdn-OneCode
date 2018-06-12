
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
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.lbKey = New Label()
        Me.tbHotKey = New TextBox()
        Me.btnRegister = New Button()
        Me.btnUnregister = New Button()
        Me.lbNotice = New Label()
        Me.SuspendLayout()
        ' 
        ' lbKey
        ' 
        Me.lbKey.AutoSize = True
        Me.lbKey.Location = New Point(13, 33)
        Me.lbKey.Name = "lbKey"
        Me.lbKey.Size = New Size(89, 13)
        Me.lbKey.TabIndex = 0
        Me.lbKey.Text = "Press the HotKey"
        ' 
        ' tbHotKey
        ' 
        Me.tbHotKey.ImeMode = ImeMode.Disable
        Me.tbHotKey.Location = New Point(109, 29)
        Me.tbHotKey.Name = "tbHotKey"
        Me.tbHotKey.Size = New Size(339, 20)
        Me.tbHotKey.TabIndex = 1
        '			Me.tbHotKey.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.tbHotKey_KeyDown)
        ' 
        ' btnRegister
        ' 
        Me.btnRegister.Enabled = False
        Me.btnRegister.Location = New Point(467, 28)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New Size(75, 23)
        Me.btnRegister.TabIndex = 2
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '			Me.btnRegister.Click += New System.EventHandler(Me.btnRegister_Click)
        ' 
        ' btnUnregister
        ' 
        Me.btnUnregister.Enabled = False
        Me.btnUnregister.Location = New Point(549, 28)
        Me.btnUnregister.Name = "btnUnregister"
        Me.btnUnregister.Size = New Size(75, 23)
        Me.btnUnregister.TabIndex = 3
        Me.btnUnregister.Text = "Unregister"
        Me.btnUnregister.UseVisualStyleBackColor = True
        '			Me.btnUnregister.Click += New System.EventHandler(Me.btnUnregister_Click)
        ' 
        ' lbNotice
        ' 
        Me.lbNotice.AutoSize = True
        Me.lbNotice.Location = New Point(13, 59)
        Me.lbNotice.Name = "lbNotice"
        Me.lbNotice.Size = New Size(571, 26)
        Me.lbNotice.TabIndex = 4
        Me.lbNotice.Text = "Please click the textbox and press the keys.  The keys that must be pressed in co" & "mbination with the key Ctrl, Shift or Alt." & vbCrLf & "Like Ctrl+Alt+T "
        ' 
        ' MainForm
        ' 
        Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(717, 96)
        Me.Controls.Add(Me.lbNotice)
        Me.Controls.Add(Me.btnUnregister)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.tbHotKey)
        Me.Controls.Add(Me.lbKey)
        Me.Name = "MainForm"
        Me.Text = "RegisterHotkey"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private lbKey As Label
    Private WithEvents tbHotKey As TextBox
    Private WithEvents btnRegister As Button
    Private WithEvents btnUnregister As Button
    Private lbNotice As Label
End Class

