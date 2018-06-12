# Binding DataGrid with Two way mode and MVVM pattern (CSSL4DataGridBindingInMVVM)
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
* 2012-10-25 02:02:15
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CSSL4DataGridBindingInMVVM Overview<br>
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
Step 1: Open the CSSL4DataGridBindingInMVVM.sln.<br>
<br>
Step 2: Expand the CSSL4DataGridBindingInMVVM web application and right click <br>
&nbsp; &nbsp; &nbsp; &nbsp;the CSSL4DataGridBindingInMVVM project and select &quot;View in Browser&quot;.<br>
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
Step 1. Create a C# &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSSL4DataGridBindingInMVVM&quot;.<br>
<br>
Step 2. Add four class files in the root directory of application, named them <br>
&nbsp; &nbsp; &nbsp; &nbsp;as &quot;ChangeModelCommand.cs&quot;, &quot;PersonCommand.cs&quot;, &quot;PersonModel.cs&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;PersonViewModel.cs&quot;.<br>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MainPage.xaml.cs file with MVVM pattern.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 5 &nbsp;The PersonModel class is used to define person's basic properties, here we<br>
&nbsp; &nbsp; &nbsp; &nbsp;define four fields: name, age, telephone and comment. We need implement
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INotifyPropertyChanged interface, the code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// Person Modal class, contains name, age, telephone and comment properties.<br>
&nbsp; &nbsp;/// The Model implement INotifyPropertyChanged interface for notifying clients<br>
&nbsp; &nbsp;/// that properties has been changed.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public class PersonModel : INotifyPropertyChanged<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string name;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private int age;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string comment;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private Regex regexInt = new Regex(@&quot;^-?\d*$&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event PropertyChangedEventHandler PropertyChanged;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonModel(string name, int age, string telephone, string comment)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.name = name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.age = age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.telephone = telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.comment = comment;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Changed(string newValue)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (PropertyChanged != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PropertyChanged(this, new PropertyChangedEventArgs(newValue));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Name<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value == string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Name can not be empty.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;name = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Name&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int Age<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int outPut;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (int.TryParse(value.ToString(), out outPut))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (outPut &lt; 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Age must be greater than zero.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;age = outPut;//outPut.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Age&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Age must be an integer number.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Telephone<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value == string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Telephone can not be empty.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!regexInt.IsMatch(value))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Telephone number must be comprised of numbers.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;telephone = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Telephone&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Comment<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return comment;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value == string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Comment can not be empty.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;comment = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Changed(&quot;Comment&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 5. The PersonViewModel class contains a Person entity instance that use to<br>
&nbsp; &nbsp; &nbsp; &nbsp;bind them with MainPage. It also include several method for providing<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return ICommand for button controls of MainPage.xaml. The code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// The MainPage.xaml page bind this class with Grid control, PersonViewModel<br>
&nbsp; &nbsp;/// class is the ViewModel layer in MVVM pattern design, this class contains
<br>
&nbsp; &nbsp;/// a model instances and invoke Command class.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public class PersonViewModel<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonModel person<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonViewModel()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.person = new PersonModel(&quot;John&quot;, 1, &quot;13745654587&quot;, &quot;Hello&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonViewModel(string name, int age, string telephone, string comment)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.person = new PersonModel(name, age, telephone, comment);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ICommand GetInformation<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return new PersonCommand(this);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ICommand SetInformation<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return new ChangeModelCommand(this);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void UpdatePerson(PersonModel entity)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(String.Format(&quot;Name: {0} \r\n Age: {1} \r\n Telephone: {2} \r\n Comment: {3}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;person.Name,person.Age,person.Telephone,person.Comment),&quot;Display Message&quot;, MessageBoxButton.OK);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. The Command class files are used to respond button command property<br>
&nbsp; &nbsp; &nbsp; &nbsp;and execute relative methods. <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The PersonCommand class code:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// The class implements ICommand interface and displays a dialog box<br>
&nbsp; &nbsp;/// to show data.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public class PersonCommand : ICommand<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonViewModel viewModel;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler CanExecuteChanged;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private IsolatedStorageSettings appSetting; <br>
&nbsp; &nbsp; &nbsp; &nbsp;public PersonCommand(PersonViewModel view)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.viewModel = view;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSetting = IsolatedStorageSettings.ApplicationSettings;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public bool CanExecute(object parameter)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool validateFlag = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (appSetting.Contains(&quot;validateFlag&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;validateFlag = (bool)appSetting[&quot;validateFlag&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (validateFlag)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;} &nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Execute(object parameter)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;viewModel.UpdatePerson(viewModel.person); &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The ChangeModelCommand class code:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;public class ChangeModelCommand:ICommand<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This class is used to change model instance via code, and view layer will update
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// when background data source has been changed.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private PersonViewModel viewModel;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler CanExecuteChanged;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ChangeModelCommand(PersonViewModel viewModel)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.viewModel = viewModel;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public bool CanExecute(object parameter)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (parameter.ToString() != string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Change Model instance by Execute method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;parameter&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Execute(object parameter)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PersonModel model;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;model = viewModel.person;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;model.Name = &quot;Default Name&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;model.Age = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;model.Telephone = &quot;11111111111&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;model.Comment = &quot;Default Comment&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. In MainPage.xaml.cs class file, we need create a method for handling <br>
&nbsp; &nbsp; &nbsp; &nbsp;BindingValidationError event, and store validate signal variable in
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsolatedStorageSettings.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private bool flag = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private IsolatedStorageSettings appSetting;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public MainPage()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSetting = IsolatedStorageSettings.ApplicationSettings;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!appSetting.Contains(&quot;validateFlag&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSetting.Add(&quot;validateFlag&quot;, this.flag);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// The method is used for catching binding exceptions.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// We can also store validate variable with IsolatedStorageSettings.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void tbValidate(object sender, ValidationErrorEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.Action == ValidationErrorEventAction.Added)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(e.OriginalSource as Control).Background = new SolidColorBrush(Colors.Yellow);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;flag = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.Action == ValidationErrorEventAction.Removed)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(e.OriginalSource as Control).Background = new SolidColorBrush(Colors.White);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;flag = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSetting[&quot;validateFlag&quot;] = flag;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
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
