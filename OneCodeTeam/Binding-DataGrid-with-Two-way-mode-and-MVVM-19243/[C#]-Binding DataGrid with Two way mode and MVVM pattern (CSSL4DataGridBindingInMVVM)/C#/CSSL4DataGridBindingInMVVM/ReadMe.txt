========================================================================
                CSSL4DataGridBindingInMVVM Overview
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

Step 1: Open the CSSL4DataGridBindingInMVVM.sln.

Step 2: Expand the CSSL4DataGridBindingInMVVM web application and right click 
        the CSSL4DataGridBindingInMVVM project and select "View in Browser".

Step 3: You can find the page contains person's basic information, such as name,
        age, etc. you can click the Display button to observe real time Person 
		messages.

Step 4: The Person messages can be edited in relative TextBox controls, or 
        changed by code via click "Change Model By Code". 

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSSL4DataGridBindingInMVVM".

Step 2. Add four class files in the root directory of application, named them 
        as "ChangeModelCommand.cs", "PersonCommand.cs", "PersonModel.cs",
		"PersonViewModel.cs".

Step 3. The ChangeModelCommand class can change the Model instance by code. The
        PersonCommmand class can get the data and display them. The PersonModel
	    class is a simple person entity class, contains basic information of
	    person. The PersonViewModel class is used by binding data with TextBox 
		controls in MainPage, validate user input messages and calling Command
		class instances when users request them. 

Step 4. Design your MainPage.xaml page, add the Silverlight controls as this 
        application, you do not need write any data binding code in 
		MainPage.xaml.cs file with MVVM pattern. 
		
Step 5  The PersonModel class is used to define person's basic properties, here we
        define four fields: name, age, telephone and comment. We need implement 
		INotifyPropertyChanged interface, the code as shown below:
		[code]
    /// <summary>
    /// Person Modal class, contains name, age, telephone and comment properties.
    /// The Model implement INotifyPropertyChanged interface for notifying clients
    /// that properties has been changed.
    /// </summary>
    public class PersonModel : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private string telephone;
        private string comment;
        private Regex regexInt = new Regex(@"^-?\d*$");
        public event PropertyChangedEventHandler PropertyChanged;
        public PersonModel(string name, int age, string telephone, string comment)
        {
            this.name = name;
            this.age = age;
            this.telephone = telephone;
            this.comment = comment;
        }

        public void Changed(string newValue)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newValue));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Name can not be empty.");
                name = value;
                Changed("Name");
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                int outPut;
                if (int.TryParse(value.ToString(), out outPut))
                {
                    if (outPut < 0)
                        throw new Exception("Age must be greater than zero.");
                    age = outPut;//outPut.ToString();
                    Changed("Age");
                }
                else
                {
                    throw new Exception("Age must be an integer number.");
                }
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Telephone can not be empty.");
                if (!regexInt.IsMatch(value))
                    throw new Exception("Telephone number must be comprised of numbers.");
                telephone = value;
                Changed("Telephone");
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Comment can not be empty.");
                comment = value;
                Changed("Comment");
            }
        }
    }
	    [/code]

Step 5. The PersonViewModel class contains a Person entity instance that use to
        bind them with MainPage. It also include several method for providing
		return ICommand for button controls of MainPage.xaml. The code as shown below:
		[code]
    /// <summary>
    /// The MainPage.xaml page bind this class with Grid control, PersonViewModel
    /// class is the ViewModel layer in MVVM pattern design, this class contains 
    /// a model instances and invoke Command class.
    /// </summary>
    public class PersonViewModel
    {
        public PersonModel person
        {
            get; 
            set;
        }

        public PersonViewModel()
        {
            this.person = new PersonModel("John", 1, "13745654587", "Hello");
        }

        public PersonViewModel(string name, int age, string telephone, string comment)
        {
            this.person = new PersonModel(name, age, telephone, comment);
        }

        public ICommand GetInformation
        {
            get
            {
                return new PersonCommand(this);
            }
        }

        public ICommand SetInformation
        {
            get
            {
                return new ChangeModelCommand(this);
            }
        }

        public void UpdatePerson(PersonModel entity)
        {
            MessageBox.Show(String.Format("Name: {0} \r\n Age: {1} \r\n Telephone: {2} \r\n Comment: {3}",
                person.Name,person.Age,person.Telephone,person.Comment),"Display Message", MessageBoxButton.OK);
        }


    }
		[/code]

Step 6. The Command class files are used to respond button command property
        and execute relative methods. 
		The PersonCommand class code:
		[code]
    /// <summary>
    /// The class implements ICommand interface and displays a dialog box
    /// to show data.
    /// </summary>
    public class PersonCommand : ICommand
    {
        public PersonViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        private IsolatedStorageSettings appSetting; 
        public PersonCommand(PersonViewModel view)
        {
            this.viewModel = view;
            appSetting = IsolatedStorageSettings.ApplicationSettings;
        }

        public bool CanExecute(object parameter)
        {
            bool validateFlag = false;
            if (appSetting.Contains("validateFlag"))
            {
                validateFlag = (bool)appSetting["validateFlag"];
            }
            if (validateFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        public void Execute(object parameter)
        {
            viewModel.UpdatePerson(viewModel.person);        
        }
    }
		[/code]
        
		The ChangeModelCommand class code:
		[code]
    public class ChangeModelCommand:ICommand
    {
        /// <summary>
        /// This class is used to change model instance via code, and view layer will update 
        /// when background data source has been changed.
        /// </summary>
        private PersonViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        public ChangeModelCommand(PersonViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter.ToString() != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change Model instance by Execute method.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            PersonModel model;
            model = viewModel.person;
            model.Name = "Default Name";
            model.Age = 0;
            model.Telephone = "11111111111";
            model.Comment = "Default Comment";
        }
    }
		[/code]

Step 7. In MainPage.xaml.cs class file, we need create a method for handling 
        BindingValidationError event, and store validate signal variable in 
		IsolatedStorageSettings.
		[code]
		private bool flag = true;
        private IsolatedStorageSettings appSetting;
        public MainPage()
        {
            InitializeComponent();
            appSetting = IsolatedStorageSettings.ApplicationSettings;
            if (!appSetting.Contains("validateFlag"))
            {
                appSetting.Add("validateFlag", this.flag);
            }
        }

        /// <summary>
        /// The method is used for catching binding exceptions.
        /// We can also store validate variable with IsolatedStorageSettings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tbValidate(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                (e.OriginalSource as Control).Background = new SolidColorBrush(Colors.Yellow);
                flag = false;
            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                (e.OriginalSource as Control).Background = new SolidColorBrush(Colors.White);
                flag = true;
            }
            appSetting["validateFlag"] = flag;
        }
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