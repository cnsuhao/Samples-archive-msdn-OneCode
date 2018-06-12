Namespace VBEFDeepCloneObject

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeDetails
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
            Me.cbxSex = New System.Windows.Forms.ComboBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.tbxState = New System.Windows.Forms.TextBox()
            Me.lblState = New System.Windows.Forms.Label()
            Me.tbxCity = New System.Windows.Forms.TextBox()
            Me.lblCity = New System.Windows.Forms.Label()
            Me.tbxAddress = New System.Windows.Forms.TextBox()
            Me.lblAddressLN1 = New System.Windows.Forms.Label()
            Me.lblSex = New System.Windows.Forms.Label()
            Me.tbxAge = New System.Windows.Forms.TextBox()
            Me.lblAge = New System.Windows.Forms.Label()
            Me.tbxLastName = New System.Windows.Forms.TextBox()
            Me.lblLastName = New System.Windows.Forms.Label()
            Me.tbxFirstName = New System.Windows.Forms.TextBox()
            Me.lblFirstName = New System.Windows.Forms.Label()
            Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cbxSex
            '
            Me.cbxSex.FormattingEnabled = True
            Me.cbxSex.Items.AddRange(New Object() {"Male", "Female"})
            Me.cbxSex.Location = New System.Drawing.Point(117, 78)
            Me.cbxSex.Name = "cbxSex"
            Me.cbxSex.Size = New System.Drawing.Size(100, 21)
            Me.cbxSex.TabIndex = 36
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(44, 198)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 35
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'tbxState
            '
            Me.tbxState.Location = New System.Drawing.Point(348, 126)
            Me.tbxState.Name = "tbxState"
            Me.tbxState.Size = New System.Drawing.Size(100, 20)
            Me.tbxState.TabIndex = 34
            '
            'lblState
            '
            Me.lblState.AutoSize = True
            Me.lblState.Location = New System.Drawing.Point(275, 126)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(32, 13)
            Me.lblState.TabIndex = 33
            Me.lblState.Text = "State"
            '
            'tbxCity
            '
            Me.tbxCity.Location = New System.Drawing.Point(117, 161)
            Me.tbxCity.Name = "tbxCity"
            Me.tbxCity.Size = New System.Drawing.Size(100, 20)
            Me.tbxCity.TabIndex = 32
            '
            'lblCity
            '
            Me.lblCity.AutoSize = True
            Me.lblCity.Location = New System.Drawing.Point(41, 161)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(24, 13)
            Me.lblCity.TabIndex = 31
            Me.lblCity.Text = "City"
            '
            'tbxAddress
            '
            Me.tbxAddress.Location = New System.Drawing.Point(117, 126)
            Me.tbxAddress.Name = "tbxAddress"
            Me.tbxAddress.Size = New System.Drawing.Size(100, 20)
            Me.tbxAddress.TabIndex = 30
            '
            'lblAddressLN1
            '
            Me.lblAddressLN1.AutoSize = True
            Me.lblAddressLN1.Location = New System.Drawing.Point(41, 126)
            Me.lblAddressLN1.Name = "lblAddressLN1"
            Me.lblAddressLN1.Size = New System.Drawing.Size(45, 13)
            Me.lblAddressLN1.TabIndex = 29
            Me.lblAddressLN1.Text = "Address"
            '
            'lblSex
            '
            Me.lblSex.AutoSize = True
            Me.lblSex.Location = New System.Drawing.Point(41, 78)
            Me.lblSex.Name = "lblSex"
            Me.lblSex.Size = New System.Drawing.Size(25, 13)
            Me.lblSex.TabIndex = 28
            Me.lblSex.Text = "Sex"
            '
            'tbxAge
            '
            Me.tbxAge.Location = New System.Drawing.Point(348, 77)
            Me.tbxAge.Name = "tbxAge"
            Me.tbxAge.Size = New System.Drawing.Size(100, 20)
            Me.tbxAge.TabIndex = 27
            '
            'lblAge
            '
            Me.lblAge.AutoSize = True
            Me.lblAge.Location = New System.Drawing.Point(275, 78)
            Me.lblAge.Name = "lblAge"
            Me.lblAge.Size = New System.Drawing.Size(26, 13)
            Me.lblAge.TabIndex = 26
            Me.lblAge.Text = "Age"
            '
            'tbxLastName
            '
            Me.tbxLastName.Location = New System.Drawing.Point(348, 35)
            Me.tbxLastName.Name = "tbxLastName"
            Me.tbxLastName.Size = New System.Drawing.Size(100, 20)
            Me.tbxLastName.TabIndex = 25
            '
            'lblLastName
            '
            Me.lblLastName.AutoSize = True
            Me.lblLastName.Location = New System.Drawing.Point(275, 38)
            Me.lblLastName.Name = "lblLastName"
            Me.lblLastName.Size = New System.Drawing.Size(55, 13)
            Me.lblLastName.TabIndex = 24
            Me.lblLastName.Text = "LastName"
            '
            'tbxFirstName
            '
            Me.tbxFirstName.Location = New System.Drawing.Point(117, 38)
            Me.tbxFirstName.Name = "tbxFirstName"
            Me.tbxFirstName.Size = New System.Drawing.Size(100, 20)
            Me.tbxFirstName.TabIndex = 23
            '
            'lblFirstName
            '
            Me.lblFirstName.AutoSize = True
            Me.lblFirstName.Location = New System.Drawing.Point(41, 38)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(54, 13)
            Me.lblFirstName.TabIndex = 22
            Me.lblFirstName.Text = "FirstName"
            '
            'errorProvider
            '
            Me.errorProvider.ContainerControl = Me
            '
            'EmployeeDetails
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(489, 256)
            Me.Controls.Add(Me.cbxSex)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.tbxState)
            Me.Controls.Add(Me.lblState)
            Me.Controls.Add(Me.tbxCity)
            Me.Controls.Add(Me.lblCity)
            Me.Controls.Add(Me.tbxAddress)
            Me.Controls.Add(Me.lblAddressLN1)
            Me.Controls.Add(Me.lblSex)
            Me.Controls.Add(Me.tbxAge)
            Me.Controls.Add(Me.lblAge)
            Me.Controls.Add(Me.tbxLastName)
            Me.Controls.Add(Me.lblLastName)
            Me.Controls.Add(Me.tbxFirstName)
            Me.Controls.Add(Me.lblFirstName)
            Me.Name = "EmployeeDetails"
            Me.Text = "Employee"
            CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents cbxSex As System.Windows.Forms.ComboBox
        Private WithEvents btnSave As System.Windows.Forms.Button
        Private WithEvents tbxState As System.Windows.Forms.TextBox
        Private WithEvents lblState As System.Windows.Forms.Label
        Private WithEvents tbxCity As System.Windows.Forms.TextBox
        Private WithEvents lblCity As System.Windows.Forms.Label
        Private WithEvents tbxAddress As System.Windows.Forms.TextBox
        Private WithEvents lblAddressLN1 As System.Windows.Forms.Label
        Private WithEvents lblSex As System.Windows.Forms.Label
        Private WithEvents tbxAge As System.Windows.Forms.TextBox
        Private WithEvents lblAge As System.Windows.Forms.Label
        Private WithEvents tbxLastName As System.Windows.Forms.TextBox
        Private WithEvents lblLastName As System.Windows.Forms.Label
        Private WithEvents tbxFirstName As System.Windows.Forms.TextBox
        Private WithEvents lblFirstName As System.Windows.Forms.Label
        Private WithEvents errorProvider As System.Windows.Forms.ErrorProvider

    End Class

End Namespace


