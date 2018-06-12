# Binding DataGrid with Two way mode and MVVM pattern (VBSL4DataGridBindingInMVVM)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Data Binding
* MVVM
## IsPublished
* True
## ModifiedDate
* 2012-10-25 02:01:59
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBSL4DataGridBindingInMVVM Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The project illustrates how to bind data source with using two way mode with<br>
frequent changed data, the clients can be notified when properties has been <br>
changed. The sample designed by MVVM pattern, the lightly pattern provides a <br>
flexible way for improving code re-use, simply maintenance and testing.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBSL4DataGridBindingInMVVM.sln.<br>
<br>
Step 2: Expand the VBSL4DataGridBindingInMVVM web application and right click <br>
&nbsp; &nbsp; &nbsp; &nbsp;the VBSL4DataGridBindingInMVVM project and select &quot;View in Browser&quot;.<br>
<br>
Step 3: You can find the page contains person's basic information, such as name,<br>
&nbsp; &nbsp; &nbsp; &nbsp;age, etc. you can click the Display button to observe real time Person
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;messages.<br>
<br>
Step 4: The Person messages can be edited in relative TextBox controls, or <br>
&nbsp; &nbsp; &nbsp; &nbsp;changed by code via click &quot;Change Model By Code&quot;. <br>
<br>
Step 5: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a VB &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBSL4DataGridBindingInMVVM&quot;.<br>
<br>
Step 2. Add four class files in the root directory of application, named them <br>
&nbsp; &nbsp; &nbsp; &nbsp;as &quot;ChangeModelCommand.vb&quot;, &quot;PersonCommand.vb&quot;, &quot;PersonModel.vb&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;PersonViewModel.vb&quot;.<br>
<br>
Step 3. The ChangeModelCommand class can change the Model instance by code. The<br>
&nbsp; &nbsp; &nbsp; &nbsp;PersonCommmand class can get the data and display them. The PersonModel<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;class is a simple person entity class, contains basic information of<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;person. The PersonViewModel class is used by binding data with TextBox
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;controls in MainPage, validate user input messages and calling Command<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;class instances when users request them.
<br>
<br>
Step 4. Design your MainPage.xaml page, add the Silverlight controls as this <br>
&nbsp; &nbsp; &nbsp; &nbsp;application, you do not need write any data binding code in
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MainPage.xaml.vb file with MVVM pattern.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 5 &nbsp;The PersonModel class is used to define person's basic properties, here we<br>
&nbsp; &nbsp; &nbsp; &nbsp;define four fields: name, age, telephone and comment. We need implement
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INotifyPropertyChanged interface, the code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Public Class PersonModel<br>
&nbsp; &nbsp;Implements INotifyPropertyChanged<br>
<br>
&nbsp; &nbsp;Private m_name As String<br>
&nbsp; &nbsp;Private m_age As Integer<br>
&nbsp; &nbsp;Private m_telephone As String<br>
&nbsp; &nbsp;Private m_comment As String<br>
&nbsp; &nbsp;Private regexInt As New Regex(&quot;^-?\d*$&quot;)<br>
&nbsp; &nbsp;Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged<br>
&nbsp; &nbsp;Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.m_name = name<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.m_age = age<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.m_telephone = telephone<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.m_comment = comment<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Sub Changed(ByVal newValue As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(newValue))<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Property Name() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return m_name<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If value = String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Name can not be empty.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_name = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Name&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;Public Property Age() As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return m_age<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As Integer)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim outPut As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Integer.TryParse(value.ToString(), outPut) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If outPut &lt; 0 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Age must be greater than zero.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_age = outPut<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'outPut.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Age&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Age must be an integer number.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;Public Property Telephone() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return m_telephone<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If value = String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Telephone can not be empty.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not regexInt.IsMatch(value) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Telephone number must be comprised of numbers.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_telephone = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Telephone&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;Public Property Comment() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return m_comment<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If value = String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New Exception(&quot;Comment can not be empty.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_comment = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Comment&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
&nbsp; &nbsp;End Class<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 5. The PersonViewModel class contains a Person entity instance that use to<br>
&nbsp; &nbsp; &nbsp; &nbsp;bind them with MainPage. It also include several method for providing<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return ICommand for button controls of MainPage.xaml. The code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Public Property person As PersonModel<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.person = New PersonModel(&quot;John&quot;, 1, &quot;13745654587&quot;, &quot;Hello&quot;)<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.person = New PersonModel(name, age, telephone, comment)<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public ReadOnly Property GetInformation() As ICommand<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return New PersonCommand(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;Public ReadOnly Property SetInformation() As ICommand<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return New ChangeModelCommand(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;Public Sub UpdatePerson(ByVal entity As PersonModel)<br>
&nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show([String].Format(&quot;Name: {0} &quot; & vbCr & vbLf & &quot; Age: {1} &quot; & vbCr & vbLf & &quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Telephone: {2} &quot; & vbCr & vbLf & &quot; Comment: {3}&quot;, person.Name, person.Age, person.Telephone,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; person.Comment), &quot;Display Message&quot;, MessageBoxButton.OK)<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. The Command class files are used to respond button command property<br>
&nbsp; &nbsp; &nbsp; &nbsp;and execute relative methods. <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The PersonCommand class code:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Implements ICommand<br>
&nbsp; &nbsp;Public viewModel As PersonViewModel<br>
&nbsp; &nbsp;Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged<br>
&nbsp; &nbsp;Private appSetting As IsolatedStorageSettings<br>
&nbsp; &nbsp;Public Sub New(ByVal view As PersonViewModel)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.viewModel = view<br>
&nbsp; &nbsp; &nbsp; &nbsp;appSetting = IsolatedStorageSettings.ApplicationSettings<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim validateFlag As Boolean = False<br>
&nbsp; &nbsp; &nbsp; &nbsp;If appSetting.Contains(&quot;validateFlag&quot;) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;validateFlag = CBool(appSetting(&quot;validateFlag&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If validateFlag Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return True<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return False<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute<br>
&nbsp; &nbsp; &nbsp; &nbsp;viewModel.UpdatePerson(viewModel.person)<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The ChangeModelCommand class code:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' This class is used to change model instance via code, and view layer will update
<br>
&nbsp; &nbsp;''' when background data source has been changed.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private viewModel As PersonViewModel<br>
&nbsp; &nbsp;Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged<br>
&nbsp; &nbsp;Public Sub New(ByVal viewModel As PersonViewModel)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.viewModel = viewModel<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp;If parameter.ToString() &lt;&gt; String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return True<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return False<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Change Model instance by Execute method.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;parameter&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim model As PersonModel<br>
&nbsp; &nbsp; &nbsp; &nbsp;model = viewModel.person<br>
&nbsp; &nbsp; &nbsp; &nbsp;model.Name = &quot;Default Name&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;model.Age = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp;model.Telephone = &quot;11111111111&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;model.Comment = &quot;Default Comment&quot;<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. In MainPage.xaml.cs class file, we need create a method for handling <br>
&nbsp; &nbsp; &nbsp; &nbsp;BindingValidationError event, and store validate signal variable in
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsolatedStorageSettings.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Private flag As Boolean = True<br>
&nbsp; &nbsp;Private appSetting As IsolatedStorageSettings<br>
<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent()<br>
&nbsp; &nbsp; &nbsp; &nbsp;appSetting = IsolatedStorageSettings.ApplicationSettings<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not appSetting.Contains(&quot;validateFlag&quot;) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSetting.Add(&quot;validateFlag&quot;, Me.flag)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' The method is used for catching binding exceptions.<br>
&nbsp; &nbsp;''' We can also store validate variable with IsolatedStorageSettings.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Public Sub tbValidate(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;If e.Action = ValidationErrorEventAction.Added Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.Yellow)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;flag = False<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;If e.Action = ValidationErrorEventAction.Removed Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.White)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;flag = True<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;appSetting(&quot;validateFlag&quot;) = flag<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: Binding Mode Property<br>
http://msdn.microsoft.com/en-us/library/system.windows.data.binding.mode.aspx<br>
<br>
MSDN: Getting Started with the MVVM Pattern in Silverlight Applications<br>
http://weblogs.asp.net/dwahlin/archive/2009/12/08/getting-started-with-the-mvvm-pattern-in-silverlight-applications.aspx<br>
<br>
MSDN: INotifyPropertyChanged Interface<br>
http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx<br>
<br>
MSDN: ICommand Interface<br>
http://msdn.microsoft.com/en-us/library/system.windows.input.icommand.aspx<br>
<br>
MSDN: FrameworkElement.BindingValidationError Event<br>
http://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.bindingvalidationerror(VS.95).aspx<br>
<br>
MSDN: IsolatedStorageSettings Class<br>
http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragesettings(v=VS.95).aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
