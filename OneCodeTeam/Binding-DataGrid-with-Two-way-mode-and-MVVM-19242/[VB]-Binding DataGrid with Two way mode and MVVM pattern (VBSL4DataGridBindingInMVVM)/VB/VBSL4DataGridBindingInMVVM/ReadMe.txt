========================================================================
                VBSL4DataGridBindingInMVVM Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to bind data source with using two way mode with
frequent changed data, the clients can be notified when properties has been 
changed. The sample designed by MVVM pattern, the lightly pattern provides a 
flexible way for improving code re-use, simply maintenance and testing.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBSL4DataGridBindingInMVVM.sln.

Step 2: Expand the VBSL4DataGridBindingInMVVM web application and right click 
        the VBSL4DataGridBindingInMVVM project and select "View in Browser".

Step 3: You can find the page contains person's basic information, such as name,
        age, etc. you can click the Display button to observe real time Person 
		messages.

Step 4: The Person messages can be edited in relative TextBox controls, or 
        changed by code via click "Change Model By Code". 

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBSL4DataGridBindingInMVVM".

Step 2. Add four class files in the root directory of application, named them 
        as "ChangeModelCommand.vb", "PersonCommand.vb", "PersonModel.vb",
		"PersonViewModel.vb".

Step 3. The ChangeModelCommand class can change the Model instance by code. The
        PersonCommmand class can get the data and display them. The PersonModel
	    class is a simple person entity class, contains basic information of
	    person. The PersonViewModel class is used by binding data with TextBox 
		controls in MainPage, validate user input messages and calling Command
		class instances when users request them. 

Step 4. Design your MainPage.xaml page, add the Silverlight controls as this 
        application, you do not need write any data binding code in 
		MainPage.xaml.vb file with MVVM pattern. 
		
Step 5  The PersonModel class is used to define person's basic properties, here we
        define four fields: name, age, telephone and comment. We need implement 
		INotifyPropertyChanged interface, the code as shown below:
		[code]
    Public Class PersonModel
    Implements INotifyPropertyChanged

    Private m_name As String
    Private m_age As Integer
    Private m_telephone As String
    Private m_comment As String
    Private regexInt As New Regex("^-?\d*$")
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)
        Me.m_name = name
        Me.m_age = age
        Me.m_telephone = telephone
        Me.m_comment = comment
    End Sub

    Public Sub Changed(ByVal newValue As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(newValue))
    End Sub

    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Name can not be empty.")
            End If
            m_name = value
            Changed("Name")
        End Set
    End Property

    Public Property Age() As Integer
        Get
            Return m_age
        End Get
        Set(ByVal value As Integer)
            Dim outPut As Integer
            If Integer.TryParse(value.ToString(), outPut) Then
                If outPut < 0 Then
                    Throw New Exception("Age must be greater than zero.")
                End If
                m_age = outPut
                'outPut.ToString();
                Changed("Age")
            Else
                Throw New Exception("Age must be an integer number.")
            End If
        End Set
    End Property

    Public Property Telephone() As String
        Get
            Return m_telephone
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Telephone can not be empty.")
            End If
            If Not regexInt.IsMatch(value) Then
                Throw New Exception("Telephone number must be comprised of numbers.")
            End If
            m_telephone = value
            Changed("Telephone")
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return m_comment
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Comment can not be empty.")
            End If
            m_comment = value
            Changed("Comment")
        End Set
    End Property
    End Class
	    [/code]

Step 5. The PersonViewModel class contains a Person entity instance that use to
        bind them with MainPage. It also include several method for providing
		return ICommand for button controls of MainPage.xaml. The code as shown below:
		[code]
    Public Property person As PersonModel
    Public Sub New()
        Me.person = New PersonModel("John", 1, "13745654587", "Hello")
    End Sub

    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)
        Me.person = New PersonModel(name, age, telephone, comment)
    End Sub

    Public ReadOnly Property GetInformation() As ICommand
        Get
            Return New PersonCommand(Me)
        End Get
    End Property

    Public ReadOnly Property SetInformation() As ICommand
        Get
            Return New ChangeModelCommand(Me)
        End Get
    End Property

    Public Sub UpdatePerson(ByVal entity As PersonModel)
        MessageBox.Show([String].Format("Name: {0} " & vbCr & vbLf & " Age: {1} " & vbCr & vbLf & " 
		Telephone: {2} " & vbCr & vbLf & " Comment: {3}", person.Name, person.Age, person.Telephone,
		 person.Comment), "Display Message", MessageBoxButton.OK)
    End Sub
		[/code]

Step 6. The Command class files are used to respond button command property
        and execute relative methods. 
		The PersonCommand class code:
		[code]
    Implements ICommand
    Public viewModel As PersonViewModel
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Private appSetting As IsolatedStorageSettings
    Public Sub New(ByVal view As PersonViewModel)
        Me.viewModel = view
        appSetting = IsolatedStorageSettings.ApplicationSettings
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Dim validateFlag As Boolean = False
        If appSetting.Contains("validateFlag") Then
            validateFlag = CBool(appSetting("validateFlag"))
        End If
        If validateFlag Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        viewModel.UpdatePerson(viewModel.person)
    End Sub
		[/code]
        
		The ChangeModelCommand class code:
		[code]
    ''' <summary>
    ''' This class is used to change model instance via code, and view layer will update 
    ''' when background data source has been changed.
    ''' </summary>
    Private viewModel As PersonViewModel
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Sub New(ByVal viewModel As PersonViewModel)
        Me.viewModel = viewModel
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        If parameter.ToString() <> String.Empty Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Change Model instance by Execute method.
    ''' </summary>
    ''' <param name="parameter"></param>
    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        Dim model As PersonModel
        model = viewModel.person
        model.Name = "Default Name"
        model.Age = 0
        model.Telephone = "11111111111"
        model.Comment = "Default Comment"
    End Sub
		[/code]

Step 7. In MainPage.xaml.cs class file, we need create a method for handling 
        BindingValidationError event, and store validate signal variable in 
		IsolatedStorageSettings.
		[code]
    Private flag As Boolean = True
    Private appSetting As IsolatedStorageSettings

    Public Sub New()
        InitializeComponent()
        appSetting = IsolatedStorageSettings.ApplicationSettings
        If Not appSetting.Contains("validateFlag") Then
            appSetting.Add("validateFlag", Me.flag)
        End If

    End Sub

    ''' <summary>
    ''' The method is used for catching binding exceptions.
    ''' We can also store validate variable with IsolatedStorageSettings.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub tbValidate(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
        If e.Action = ValidationErrorEventAction.Added Then
            TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.Yellow)
            flag = False
        End If
        If e.Action = ValidationErrorEventAction.Removed Then
            TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.White)
            flag = True
        End If
        appSetting("validateFlag") = flag
    End Sub
		[/code]

Step 6. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Binding Mode Property
http://msdn.microsoft.com/en-us/library/system.windows.data.binding.mode.aspx

MSDN: Getting Started with the MVVM Pattern in Silverlight Applications
http://weblogs.asp.net/dwahlin/archive/2009/12/08/getting-started-with-the-mvvm-pattern-in-silverlight-applications.aspx

MSDN: INotifyPropertyChanged Interface
http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx

MSDN: ICommand Interface
http://msdn.microsoft.com/en-us/library/system.windows.input.icommand.aspx

MSDN: FrameworkElement.BindingValidationError Event
http://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.bindingvalidationerror(VS.95).aspx

MSDN: IsolatedStorageSettings Class
http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragesettings(v=VS.95).aspx
/////////////////////////////////////////////////////////////////////////////