=====================================================================================
 ASP.NET APPLICATION : CSASPNETCodeFirstCRUDInGridViewWithDetailsView Project Overview
=====================================================================================

//////////////////////////////////////////////////////////////////////////////////////
Summary:

  The project shows up several new feature appearing in CodeFirst RTM
  
  Pre-conditions when to run the program：

  1) Double click the solution to open the sample code.

  2) We should install "NuGet" in the Extension Manage under the "Tools"=>"Extension Manager"
  ,then press "Nuget" and choose "Online Gallery" on the left,
  then you can see "Nuget",just download and it will be installed soon.
  After finishing this step, you should restart your VS.

  3) let's go to the "Tools"=>"Library Package Manager",please just type this below after "PM>"

  Install-Package EntityFramework
  
  This will import all the dll files into your current project and you can start with EF4.1 RTM!


//////////////////////////////////////////////////////////////////////////////////////
Demo:

  Open the sample project and run the application, you can see the a Default.aspx page 
  that will guide you to three pages: Students, Courses and CoursesChoice. Click any link
  you can go to the mapping page——

  1) Students: You can create,delete or update a student's info.
  2) Courses: You can edit,create a class in the DetailsView with GridView.
  3) CoursesChoice: You can create,update or delete an existing choice info.


//////////////////////////////////////////////////////////////////////////////////////
Code Logic:

Step1. Open your Visual Studio 2000 Ultimate/Express or other related version 
to create a C sharp Web application by choosing "File" -> "New" -> "Project...", 
expand the "Visual C#" tag and select "Web", then choose "ASP.NET Web Application".
Please name it as "CSASPNETCodeFirstCRUDInGridViewWithDetailsView" and switch "Solution" 
dropdownlist to "Create new solution", in the end check the checkbox "Create
directory for solution" and press OK button to create the solution.

[ NOTE: You can also download the free Visual studio 2010 Express ISO package and install Visual C#
 http://download.microsoft.com/download/1/E/5/1E5F1C0A-0D5B-426A-A603-1798B951DDAE/VS2010Express1.iso]
 
Step2. Delete the following default folders and files created automatically 
by Visual Studio,and right click the project to create a Global.asax file, then import
the CodeFirst necessary dll libraries as what we do in "Summary" section.

    Account folder
    Script folder
    Style folder
    About.aspx file
    Global.asax file
    Default.aspx file

Step3. Create a Default.aspx and write down the codes below to create a content page:

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNETCodeFirstCRUDInGridView.Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>School Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p ALIGN="center">
        <H3>School Management System (using CodeFirst) Sample</H3>
       <a href="Students.aspx" target="_self">Go To Students page</a>
       <br />
       <br />
       <a href="Courses.aspx" target="_self">Go To Courses page</a>
       <br />
       <br />
       <a href="CourseChoice.aspx" target="_self">Go To Course Choice pages</a>
       </p>
       <br />
    </div>
    </form>
</body>
</html>


Step4. Create a model file called "DataBaseModel.cs", in which we can just construct what
tables we need, here's snippet of codes:

    /// <summary>
    /// This is a student table
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Point out this is a Primary Key and it's auto-generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        /// <summary>
        /// Point out this field is not null and it has the number 
        /// of character to int.MaxValue
        /// </summary>
        [Required]
        [MaxLength(int.MaxValue)]
        public string StudentName { get; set; }

        public virtual ICollection<Student_Course> Courses { get; set; }
    }


Step5. Create a file called "DBCreator.cs", which is used for auto-generating
db with tables from the model classes. See the complete codes in the file.

Step6. Create a file called "DBObjectDataSource.cs", this file offers different
CRUD ways for Students.aspx, Courses.aspx and CoursesChoice.aspx page as the datasources
for the ObjectDataSources bound to data presentation controls, as you can see in the
sample code.

Step7. Create the Students.aspx page and add a GridView there, then bind it to "StudentDataSource"
to get all the existing students in the db with CRUD methods.
And add a textbox for inputting a new student's name with the required 
validation control. 

Step8. Create the Courses.aspx page and add a GridView there, then bind it to "CourseDataSource"
to get all the existing courses. Make the GridView selectable by clicking the right
corner's arrow and choose "Enable Selection".
And drag and drop a detailsview, bind it to "CourseDetailsDataSource" with CRUD methods
from DBObjectDataSource.cs and click the right arrow, and check "Enable Editing","Enable
Inserting". Then convert them into Template fields, and them in the EditTemplateField
and InsertTemplate, please add a required validation control there.

Step9. Create the CourseChoice.aspx page and add a Dropdownlist called "ddrStudents", then bind it
to "StudentDataSource" to fetch all of the existing students in the db, and drag and drop
a GridView inside, bind it to "Student_CourseDataSource" with CRUD methods, add another dropdownlist
named "ddrRestCourses" should be bound with the third ObjectDataSource called "RestCourseDataSource".
In the end, add a textbox and name it as "tbScore" with a required validation,regular expression
validation and add a button for creating a new course choice record. 

Step10. In the global.asax page in order to create a whole db with test data contents, we can temporarily
set "RecreateDB" to "true"in the Web.config, for further usage, we set it to false：

  <appSettings>
    <add key="RecreateDB" value="true"/>
  </appSettings>

And now we call the method like this——

/// <summary>
/// To decide whether to create data contents once the Server starts.
/// </summary>
protected void Application_Start(object sender, EventArgs e)
{
DBCreator.DBAutoCreator(Convert.ToBoolean(ConfigurationManager.AppSettings["RecreateDB"]));
}

Step11. Create a Web.sitemap and drag and drop Navigator control to each of the page.


//////////////////////////////////////////////////////////////////////////////////////
Reference：

Entity Framework Preview: code first, ObjectSet and DbContext
http://msdn.microsoft.com/en-us/magazine/gg232765.aspx

//////////////////////////////////////////////////////////////////////////////////////