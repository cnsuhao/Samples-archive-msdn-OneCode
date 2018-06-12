# AspNet EF4 (CodeFirst) CRUD in GridView with DetailsView
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Entity Framework
* GridView
## IsPublished
* True
## ModifiedDate
* 2013-06-05 02:15:29
## Description
=====================================================================================<br>
ASP.NET APPLICATION : VBASPNETCodeFirstCRUDInGridViewWithDetailsView Project Overview<br>
=====================================================================================<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
&nbsp;The project shows up several new feature appearing in CodeFirst RTM<br>
&nbsp;<br>
&nbsp;Pre-conditions when to run the program：<br>
<br>
&nbsp;1) Double click the solution to open the sample code.<br>
<br>
&nbsp;2) We should install &quot;NuGet&quot; in the Extension Manage under the &quot;Tools&quot;=&gt;&quot;Extension Manager&quot;<br>
&nbsp;,then press &quot;Nuget&quot; and choose &quot;Online Gallery&quot; on the left,<br>
&nbsp;then you can see &quot;Nuget&quot;,just download and it will be installed soon.<br>
&nbsp;After finishing this step, you should restart your VS.<br>
<br>
&nbsp;3) let's go to the &quot;Tools&quot;=&gt;&quot;Library Package Manager&quot;,please just type this below after &quot;PM&gt;&quot;<br>
<br>
&nbsp;Install-Package EntityFramework<br>
&nbsp;<br>
&nbsp;This will import all the dll files into your current project and you can start with EF4.1 RTM!<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
&nbsp;Open the sample project and run the application, you can see the a Default.aspx page
<br>
&nbsp;that will guide you to three pages: Students, Courses and CoursesChoice. Click any link<br>
&nbsp;you can go to the mapping page——<br>
<br>
&nbsp;1) Students: You can create,delete or update a student's info.<br>
&nbsp;2) Courses: You can edit,create a class in the DetailsView with GridView.<br>
&nbsp;3) CoursesChoice: You can create,update or delete an existing choice info.<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
Step1. Open your Visual Studio 2000 Ultimate/Express or other related version <br>
to create a VB Web application by choosing &quot;File&quot; -&gt; &quot;New&quot; -&gt; &quot;Project...&quot;, <br>
expand the &quot;Visual Basic&quot; tag and select &quot;Web&quot;, then choose &quot;ASP.NET Web Application&quot;.<br>
Please name it as &quot;CSASPNETCodeFirstCRUDInGridViewWithDetailsView&quot; and switch &quot;Solution&quot;
<br>
dropdownlist to &quot;Create new solution&quot;, in the end check the checkbox &quot;Create<br>
directory for solution&quot; and press OK button to create the solution.<br>
<br>
[ NOTE: You can also download the free Visual studio 2010 Express ISO package and install Visual C#<br>
http://download.microsoft.com/download/1/E/5/1E5F1C0A-0D5B-426A-A603-1798B951DDAE/VS2010Express1.iso]<br>
<br>
Step2. Delete the following default folders and files created automatically <br>
by Visual Studio,and right click the project to create a Global.asax file, then import<br>
the CodeFirst necessary dll libraries as what we do in &quot;Summary&quot; section.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Account folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;Script folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;Style folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;About.aspx file<br>
&nbsp;&nbsp;&nbsp;&nbsp;Global.asax file<br>
&nbsp;&nbsp;&nbsp;&nbsp;Default.aspx file<br>
<br>
Step3. Create a Default.aspx and write down the codes below to create a content page:<br>
<br>
&lt;%@ Page Language=&quot;vb&quot; AutoEventWireup=&quot;false&quot; CodeBehind=&quot;Default.aspx.vb&quot; Inherits=&quot;VBASPNETCodeFirstCRUDInGridViewWithDetailsView._Default&quot; %&gt;<br>
<br>
&lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;<br>
<br>
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;<br>
&lt;head id=&quot;Head1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;School Management System&lt;/title&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;
<div><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<p align="center"><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h3>School Management System (using CodeFirst) Sample</h3>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="Students.aspx" target="_self">Go To Students page</a><br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="Courses.aspx" target="_self">Go To Courses page</a><br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="CourseChoice.aspx" target="_self">Go To Course Choice pages</a><br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
<p></p>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;</div>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
<br>
<br>
Step4. Create a model file called &quot;DataBaseModel.vb&quot;, in which we can just construct what<br>
tables we need, here's snippet of codes:<br>
<br>
&nbsp; ''' &lt;summary&gt;<br>
''' This is a student table<br>
''' &lt;/summary&gt;<br>
Public Class Student<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' Point out this is a Primary Key and it's auto-generated.<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Key()&gt; _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)&gt; _<br>
&nbsp;&nbsp;&nbsp;&nbsp;Public Property StudentId() As Integer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return _studentId<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set(ByVal value As Integer)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_studentId = value<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Set<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Property<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private _studentId As Integer<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' Point out this field is not null and it has the number
<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' of character to int.MaxValue<br>
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Required()&gt; _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;MaxLength(Integer.MaxValue)&gt; _<br>
&nbsp;&nbsp;&nbsp;&nbsp;Public Property StudentName() As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return _studentName<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set(ByVal value As String)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_studentName = value<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Set<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Property<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private _studentName As String<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Public Overridable Property Courses() As ICollection(Of Student_Course)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return _courses<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Get<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set(ByVal value As ICollection(Of Student_Course))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_courses = value<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Set<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Property<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private _courses As ICollection(Of Student_Course)<br>
End Class<br>
<br>
<br>
Step5. Create a file called &quot;DBCreator.vb&quot;, which is used for auto-generating<br>
db with tables from the model classes. See the complete codes in the file.<br>
<br>
<br>
Step6. Create a file called &quot;DBObjectDataSource.vb&quot;, this file offers different<br>
CRUD ways for Students.aspx, Courses.aspx and CoursesChoice.aspx page as the datasources<br>
for the ObjectDataSources bound to data presentation controls, as you can see in the<br>
sample code.<br>
<br>
Step7. Create the Students.aspx page and add a GridView there, then bind it to &quot;StudentDataSource&quot;<br>
to get all the existing students in the db with CRUD methods.<br>
And drag and drop a textbox for inputting a new student's name with the required <br>
validation control. See the codes in Students.aspx.<br>
<br>
Step8. Create the Courses.aspx page and add a GridView there, then bind it to &quot;CourseDataSource&quot;<br>
to get all the existing courses. Make the GridView selectable by clicking the right<br>
corner's arrow and choose &quot;Enable Selection&quot;.<br>
And drag and drop a detailsview, bind it to &quot;CourseDetailsDataSource&quot; with CRUD methods<br>
from DBObjectDataSource.vb and click the right arrow, and check &quot;Enable Editing&quot;,&quot;Enable<br>
Inserting&quot;. Then convert them into Template fields, and them in the EditTemplateField<br>
and InsertTemplate, please add a required validation control there.<br>
<br>
Step9. Create the CourseChoice.aspx page and add a Dropdownlist called &quot;ddrStudents&quot;, then bind it<br>
to &quot;StudentDataSource&quot; to fetch all of the existing students in the db, and drag and drop<br>
a GridView inside, bind it to &quot;Student_CourseDataSource&quot; with CRUD methods, add another dropdownlist<br>
named &quot;ddrRestCourses&quot; should be bound with the third ObjectDataSource called &quot;RestCourseDataSource&quot;.<br>
In the end, add a textbox and name it as &quot;tbScore&quot; with a required validation,regular expression<br>
validation and add a button for creating a new course choice record.<br>
<br>
Step10. In the global.asax page in order to create a whole db with test data contents, we can temporarily<br>
set &quot;RecreateDB&quot; to &quot;true&quot;in the Web.config, for further usage, we set it to false：<br>
<br>
&nbsp;&lt;appSettings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key=&quot;RecreateDB&quot; value=&quot;true&quot;/&gt;<br>
&nbsp;&lt;/appSettings&gt;<br>
<br>
And now we call the method like this——<br>
<br>
''' &lt;summary&gt;<br>
''' To decide whether to create data contents once the Server starts.<br>
''' &lt;/summary&gt;<br>
Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DBCreator.DBAutoCreator(Convert.ToBoolean(ConfigurationManager.AppSettings(&quot;RecreateDB&quot;)))<br>
End Sub<br>
<br>
Step11. Create a Web.sitemap and drag and drop Navigator control to each of the page.<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Reference：<br>
<br>
Entity Framework Preview: code first, ObjectSet and DbContext<br>
http://msdn.microsoft.com/en-us/magazine/gg232765.aspx<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
