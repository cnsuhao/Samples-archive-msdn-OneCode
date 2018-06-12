# Data binding in Silverlight 3 (CSSL3DataBinding)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:06:31
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3DataBinding Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to work with Data Binding Silverlight 3.<br>
It includes the following general scenarios:<br>
<br>
How to use onetime/oneway/twoway Data Binding.<br>
What is IValueConverter and how to use it.<br>
How to handle data validation in Data Binding.<br>
How to use Element Data Binding to bind to the property of other controls.<br>
What is ObservableCollection.<br>
General problems you may encounter with when using Data Binding.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Chained Installer<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. How to use onetime/oneway/twoway Data Binding.<br>
<br>
Please run the project and following instruction to edit TextBox. You'll notice what's the<br>
difference among binding modes.<br>
<br>
By specifying Mode like below you can control the Binding Mode.<br>
<br>
&lt;TextBlock HorizontalAlignment=&quot;Left&quot; Margin=&quot;20,0&quot; FontSize=&quot;11&quot; TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Name, Mode=OneTime}&quot;/&gt;<br>
&lt;TextBlock HorizontalAlignment=&quot;Left&quot; Margin=&quot;20,0&quot; FontSize=&quot;11&quot; TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Name, Mode=OneWay}&quot;/&gt;<br>
&lt;TextBox HorizontalAlignment=&quot;Left&quot; Margin=&quot;20,0,0,0&quot; FontSize=&quot;11&quot;
<br>
TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Name, Mode=TwoWay,ValidatesOnExceptions=true, NotifyOnValidationError=true}&quot;/&gt; &nbsp;
<br>
<br>
For two way databinding to work property, the source class must implement INotifyPropertyChanged.<br>
Please refer to Customer class in DAL.cs to learn how to implement this interface.<br>
<br>
2. What is IValueConverter and how to use it.<br>
<br>
By specifying the Converter of a Binding we can use our custom ValueConverter class that implements IValueConverter.<br>
Converters can change data from one type to another, translate data based on cultural information,
<br>
or modify other aspects of the presentation. Core code logic is like below:<br>
<br>
&lt;UserControl.Resources&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;local:MyConverter x:Key=&quot;myconverter&quot;&gt;&lt;/local:MyConverter&gt;<br>
&lt;/UserControl.Resources&gt;<br>
&nbsp; &nbsp;...<br>
&lt;StackPanel Background=&quot;{Binding ID,Converter={StaticResource myconverter}}&quot;&gt;<br>
<br>
<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// This is a custom ValueConverter class. It converts int to Brush.
<br>
&nbsp; &nbsp;/// If ID is larger than 1 a redbrush will be returned.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public class MyConverter : IValueConverter<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;Brush redbrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));<br>
&nbsp; &nbsp; &nbsp; &nbsp;public object Convert(object value,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type targetType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;object parameter,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Globalization.CultureInfo culture)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value is int)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return (int)value&gt;1?redbrush:null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return null; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public object ConvertBack(object value,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type targetType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;object parameter,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Globalization.CultureInfo culture)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new NotImplementedException();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
3. How to handle data validation in Data Binding.<br>
<br>
In two way binding scenario validation is always needed.<br>
<br>
The validation will be done when exception is thrown during update of source objects,<br>
as long as you've set ValidatesOnExceptions to ture. <br>
<br>
If you set NotifyOnValidationError to ture as well you can notify contol by triggering<br>
BindingValidationError event. You don't have to write code to manually do so. <br>
All Controls have this feature.<br>
<br>
To set ValidatesOnExceptions and BindingValidationErrorin XAML, please use the following code:<br>
<br>
&lt;TextBox HorizontalAlignment=&quot;Left&quot; Margin=&quot;20,0,0,0&quot; FontSize=&quot;11&quot;
<br>
TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Name, Mode=TwoWay,ValidatesOnExceptions=true, NotifyOnValidationError=true}&quot;/&gt;<br>
<br>
In paticular, we can use Attributes in System.ComponentModel.DataAnnotations<br>
namespace to help us define restrictions of the value passed to a property pending update<br>
and throw exception when it's invalid. <br>
<br>
To do that,in binding source property's set accessor, add following code. MemberName is the property name.<br>
<br>
Validator.ValidateProperty(value,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; new ValidationContext(this, null, null) { MemberName = &quot;Name&quot; });<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
In most cases the built-in Attributes is enough for use.<br>
<br>
For advanced scenarios we may need custom validation means. To do this we can attach CustomValidationAttribute,<br>
to that property, like below. The first parameter is the type of the custom validation class. The<br>
second parameter is the validate method in the custom validation class:<br>
<br>
[CustomValidation(typeof(MyValidation),&quot;Validate&quot;)]<br>
public int ID{...}<br>
...<br>
<br>
public static class MyValidation<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static ValidationResult Validate(object property,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ValidationContext context)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// You can get Property name from context.MemberName. It's not used here for simplicity.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int customerid;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// For the simplicity, the change is invalid if new ID equals 11.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (Int32.TryParse(property.ToString(),out customerid) && customerid == 11)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ValidationResult validationResult = new ValidationResult(&quot;Custom Validation Failed. ID cannot be 11&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return validationResult;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return ValidationResult.Success;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
4. How to use Element Data Binding to bind to the property of other controls.<br>
<br>
To use Element binding, we need to specify the ElementName for Binding and set binding source<br>
crrectly. The following code in the sample binds the Text property of the TextBlock to the Name<br>
property of the SelectedItem of the DataGrid. In this sample, SelectedItem is a Customer object so we<br>
can set SelectedItem.Name as binding source.<br>
<br>
&lt;TextBlock Text=&quot;{Binding SelectedItem.Name, ElementName=ConverterScenarioDataGrid}&quot;&gt;&lt;/TextBlock&gt;<br>
<br>
5. What is ObservableCollection.<br>
<br>
To notify collection elements' change (add or remove), collection class should implement
<br>
INotifyCollectionChanged interface. ObservableCollection&lt;T&gt; has already implemented it so it's<br>
always recommended to use it as your collection class.<br>
<br>
<br>
6. General problems you may encounter with when using Data Binding.<br>
<br>
Please run the project and click GeneralProblems tab for more details.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Data Binding<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc278072(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc278072(VS.95).aspx</a><br>
<br>
Dependency Properties Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc221408(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc221408(VS.95).aspx</a><br>
<br>
Using Data Annotations to Customize Data Classes<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd901590(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd901590(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
