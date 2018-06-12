# ASP.NET FormView control demo (VBASPNETFormViewUpload)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:29:51
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETFormViewUpload Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This VBASPNETFormViewUpload sample demonstrates how to display and upload <br>
images in an ASP.NET FormView control and how to implement Insert, Edit, <br>
Update, Delete and Paging functions in the control. <br>
<br>
This project includes two pages: Default and Image.<br>
<br>
Default populates a FormView control with data from a SQL Server database <br>
and provides UI for data manipulation.<br>
<br>
Image is used to retrieve the image from a SQL Server database and display <br>
it in the Web page.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a VB ASP.NET Web Application named VBASPNETFormViewUpload in <br>
Visual Studio 2008 / Visual Web Developer.<br>
<br>
<br>
Step2. Drag a FormView control into the Default page.<br>
<br>
&nbsp; &nbsp;(1) Rename the FormView to fvPerson.<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp;(2) In the Source view, copy and paste the markup of following three
<br>
&nbsp; &nbsp;templates from the sample:<br>
<br>
&nbsp; &nbsp;ItemTemplate: render the particular record displayed in the FormView.<br>
&nbsp; &nbsp;EditItemTemplate: customize the editing interface for the FormView.<br>
&nbsp; &nbsp;InsertItemTemplate: customize the inserting interface for the FormView.
<br>
<br>
&nbsp; &nbsp;Related references:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;ASP.NET: Using the FormView's Templates&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;MSDN: FormView Class<br>
&nbsp; &nbsp;MSDN: Image Class<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;<br>
Step3. Copy the following methods from the sample,and paste them in the <br>
code-behind of Default page:<br>
<br>
&nbsp; &nbsp;Page_Load Method:<br>
&nbsp; &nbsp;Initialize underlying objects, when the Page is accessed <br>
&nbsp; &nbsp;for the first time.<br>
<br>
&nbsp; &nbsp;BindFormView Method:<br>
&nbsp; &nbsp;Bind the FormView control with data from a SQL Server table.<br>
<br>
&nbsp; &nbsp;Related reference:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;MSDN: Using Statement (Visual Basic)<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;<br>
Step4. Navigate to the Property panel of fvPerson and then switch to Event. <br>
Double-click on the following events to generate the Event handlers. <br>
After that, fill the generated methods with the sample code.<br>
<br>
&nbsp; &nbsp;(1)&nbsp;&nbsp;&nbsp;&nbsp;ModeChanging Event: Occurs when the FormView control switches
<br>
&nbsp; &nbsp;between edit, insert, and read-only mode, but before the mode changes.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;In this event, we need to switch FormView control to the new mode and
<br>
&nbsp; &nbsp;then rebind the FormView control to show data in new mode.&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;fvPerson.ChangeMode(e.NewMode)<br>
&nbsp; &nbsp;BindFormView()<br>
&nbsp; &nbsp;</p>
<h3></h3>
<p style="font-family:Courier New">&nbsp; &nbsp;Related reference:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;MSDN: FormView.ModeChanging&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp;(2)&nbsp;&nbsp;&nbsp;&nbsp;PageIndexChanging Event: Occurs when a pager button within the
<br>
&nbsp; &nbsp;control is clicked.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;In order to show data in the new page, we need to set the index of new
<br>
&nbsp; &nbsp;page and then rebind the FormView control. &nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp;//////////////////////////////////////////////////////////////// &nbsp; &nbsp;<br>
&nbsp; &nbsp;fvPerson.PageIndex = e.NewPageIndex<br>
&nbsp; &nbsp;BindFormView()<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;Related reference:&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;MSDN: FormView.PageIndexChanging Event<br>
<br>
<br>
&nbsp; &nbsp;(3)&nbsp;&nbsp;&nbsp;&nbsp;ItemInserting Event: Occurs when an Insert button within a FormView
<br>
&nbsp; &nbsp;control is clicked, but before the insert operation.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;After clicking Insert button, we need to get the first name, last name
<br>
&nbsp; &nbsp;and specified image file (bytes) from the &nbsp;&nbsp;&nbsp;&nbsp;InsertItemTemplate of the
<br>
&nbsp; &nbsp;FormView control.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;Dim strLastName As String = DirectCast(fvPerson.Row.FindControl(&quot;tbLastName&quot;), TextBox).Text<br>
&nbsp; &nbsp;Dim strFirstName As String = DirectCast(fvPerson.Row.FindControl(&quot;tbFirstName&quot;), TextBox).Text<br>
<br>
&nbsp; &nbsp;cmd.Parameters.Add(&quot;@LastName&quot;, SqlDbType.NVarChar, 50).Value = strLastName<br>
&nbsp; &nbsp;cmd.Parameters.Add(&quot;@FirstName&quot;, SqlDbType.NVarChar, 50).Value = strFirstName<br>
<br>
&nbsp; &nbsp;Dim uploadPicture As FileUpload = DirectCast(fvPerson.FindControl(&quot;uploadPicture&quot;), FileUpload)<br>
<br>
&nbsp; &nbsp;If uploadPicture.HasFile Then<br>
&nbsp; &nbsp; &nbsp; &nbsp;cmd.Parameters.Add(&quot;@Picture&quot;, SqlDbType.VarBinary).Value = uploadPicture.FileBytes<br>
&nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp;cmd.Parameters.Add(&quot;@Picture&quot;, SqlDbType.VarBinary).Value = DBNull.Value<br>
&nbsp; &nbsp;End If<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp;Related reference:&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;MSDN: FormView.ItemInserting Event&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp;(4)&nbsp;&nbsp;&nbsp;&nbsp;ItemUpdating Event: Occurs when an Update button within a FormView
<br>
&nbsp; &nbsp;control is clicked, but before the update operation.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;After clicking Update button, we need to get and pass the person ID,
<br>
&nbsp; &nbsp;first name, last name and specified image file (bytes) from the <br>
&nbsp; &nbsp;EditItemTemplate of the FormView control.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp; &nbsp;//////////////////////////////////////////////////////////////// <br>
&nbsp; &nbsp;Dim strPersonID As String = DirectCast(fvPerson.Row.FindControl(&quot;lblPersonID&quot;), Label).Text<br>
&nbsp; &nbsp;</p>
<h3></h3>
<p style="font-family:Courier New">&nbsp; &nbsp;Related reference:&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;MSDN: FormView.ItemUpdating Event<br>
<br>
&nbsp; &nbsp;(5)&nbsp;&nbsp;&nbsp;&nbsp;ItemDeletingEvent: Occurs when a Delete button within a FormView
<br>
&nbsp; &nbsp;control is clicked, but before the delete operation.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;We get the PersonID from the ItemTemplate of the FormView control and
<br>
&nbsp; &nbsp;then delete the person record in the database based on the PersonID.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;Dim strPersonID As String = DirectCast(fvPerson.Row.FindControl(&quot;lblPersonID&quot;), Label).Text<br>
&nbsp; &nbsp;////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;Related reference:&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;MSDN: FormView.ItemDeleting Event<br>
<br>
<br>
Step5. Create a new Web page named Image in the project. Copy the Page_Load <br>
method from the sample, and paste it in code-behind of Image page:<br>
<br>
In this page, we retrieve the image data from the database, convert it to a <br>
bytes array and then write the array to the HTTP output stream <br>
to display the image.<br>
<br>
&nbsp; &nbsp;//////////////////////////////////////////////////////////////// <br>
&nbsp; &nbsp;Dim bytes As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())<br>
<br>
&nbsp; &nbsp;If bytes IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.ContentType = &quot;image/jpeg&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.BinaryWrite(bytes)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.End()<br>
&nbsp; &nbsp;End If<br>
&nbsp; &nbsp;//////////////////////////////////////////////////////////////// <br>
<br>
Related references:<br>
<br>
MSDN: Request Object<br>
MSDN: Response Object<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET: Using the FormView's Templates<br>
<a target="_blank" href="http://www.asp.net/learn/data-access/tutorial-14-vb.aspx">http://www.asp.net/learn/data-access/tutorial-14-vb.aspx</a><br>
<br>
MSDN: Image Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.image.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.image.aspx</a><br>
<br>
MSDN: FormView Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.aspx</a><br>
<br>
MSDN: Using Statement (Visual Basic)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/htd05whh.aspx">http://msdn.microsoft.com/en-us/library/htd05whh.aspx</a><br>
<br>
MSDN: FormView.ModeChanging<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.modechanging.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.modechanging.aspx</a><br>
<br>
MSDN: FormView.PageIndexChanging Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.pageindexchanging.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.pageindexchanging.aspx</a><br>
<br>
MSDN: FormView.ItemInserting Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.iteminserting.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.iteminserting.aspx</a><br>
<br>
MSDN: FormView.ItemUpdating Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.itemupdating.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.itemupdating.aspx</a><br>
<br>
MSDN: FormView.ItemDeleting Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.itemdeleting.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.itemdeleting.aspx</a><br>
<br>
MSDN: Request Object<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms524948.aspx">http://msdn.microsoft.com/en-us/library/ms524948.aspx</a><br>
<br>
MSDN: Response Object<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms525405.aspx">http://msdn.microsoft.com/en-us/library/ms525405.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
