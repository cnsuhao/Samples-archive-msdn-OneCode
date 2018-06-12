# WPF ListBox Validation (CSWPFListBoxValidation)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* Controls
* Validation
* ListBox
## IsPublished
* True
## ModifiedDate
* 2011-09-30 09:01:02
## Description

<h1>WPF APPLICATION: CSWPFListBoxValidation</h1>
<h2>Summary</h2>
<p>The sample demonstrates how to add validation to a ListBox, overriding the control to contain a ValidationListener property, which can be bound to provide validation using built in validation UI features in WPF.</p>
<h2>Demo</h2>
<p>To run the sample, simply open in Visual Studio 2010 and run it.</p>
<p>It contains a ListBox, which was overridden to include a property called ValidationListener, which is used to bind the ListBox to a property used for validation, and a validation rule.&nbsp; The validation property is simply a text field added to the Window,
 in which error text is written if the ListBox is found having no selected items.&nbsp; Of course the rule could be more complex as necessary, but this demonstrates the approach.</p>
<p>When the form first displays, no items are selected, so it is not valid.&nbsp; Validation UI displays a red outline around it, and another label control is also validated using the same criteria, and is outlined in red as well, and displays the validation
 error message.</p>
<p>Selecting any items validates the control.&nbsp; Removing all selections will again invalidate the control.</p>
<h2>Implementation</h2>
<p>The built in validation in WPF does not have a default means of performing validation on collection-valued sources, and was designed for scalar-valued properties.&nbsp; To put another way, validation listens to PropertyChanged events, but not to CollectionChanged
 events.&nbsp; In order to achieve this, a scalar-valued property is required for validation to listen to.&nbsp; This implementation simply creates that property (the Validation property defined in the Window), and then detects that in the ValidationRule for
 the ValidationListener property of the ValidatingListBox, to which it is bound.&nbsp; Whenever that property changes, WPF detects it because the rule is marked as ValidatesOnTargetUpdated, and runs the defined validation logic.</p>
<h2>References</h2>
<p>How to: Implement Binding Validation<br>
<a href="http://msdn.microsoft.com/en-us/library/ms753962.aspx">http://msdn.microsoft.com/en-us/library/ms753962.aspx</a></p>
<p>Hook Up and Display Validation in WPF <br>
<a href="http://msdn.microsoft.com/en-us/vbasic/cc788743.aspx">http://msdn.microsoft.com/en-us/vbasic/cc788743.aspx</a></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
