'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFStoreXmlFiles
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to import/export the XML into/from database using 
' Code First in EF.
' We implement two ways in the sample:
' 1. Using LinqToXml to import/export the XML files;
' 2. Using the XmlColumn to store the Xml files.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports System.Text
Imports System.Data.Entity

Namespace VBEFStoreXmlFiles
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Database.SetInitializer(New DropCreateDatabaseAlways(Of MySchoolContext)())

            Dim document As XDocument = XDocument.Load("Courses-2012.xml")

            ImportCourses(document)
            Console.WriteLine("Imported the Courses-2012.xml file by LinqToXml")
            Console.WriteLine()

            ExportCourses()
            Console.WriteLine("Exported the CoursesByLinqToXml.xml by LinqToXml")
            Console.WriteLine()

            ImportYearCourses(document)
            Console.WriteLine("Imported the Courses-2012.xml file into the XmlColumn")
            Console.WriteLine()

            ExportYearCourses()
            Console.WriteLine("Exported the CoursesFromXmlColumn.xml from XmlColumn")
            Console.WriteLine()

            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Use LinqToXml to import information in the xml file into the database
        ''' </summary>
        ''' <param name="document">the Xml file that we import into the database</param>
        Private Shared Sub ImportCourses(ByVal document As XDocument)
            Using school As New MySchoolContext()
                ' Get the Course information from the Xml document
                Dim courses As IEnumerable(Of Course) =
                    From c In document.Descendants("Course")
                Select New Course With
                {
                    .CourseID = If(c.Element("CourseId") Is Nothing, Guid.NewGuid().ToString(),
                                   c.Element("CourseId").Value),
                    .Title = If(c.Element("Title") Is Nothing, Nothing, c.Element("Title").Value),
                    .Credits = If(c.Element("Credits") Is Nothing, -1, Int32.Parse(c.Element("Credits").Value)),
                    .Department = If(c.Element("Department") Is Nothing, Nothing, c.Element("Department").Value)
                }

                For Each course As Course In courses
                    school.Courses.Add(course)
                Next course

                school.SaveChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Use LinqToXml to export the information into a Xml file from the database 
        ''' </summary>
        Private Shared Sub ExportCourses()
            Using school As New MySchoolContext()
                Dim ns As XNamespace = "http://VBEFStoreXmlFiles"
                Dim coursesXml As New XElement(ns + "Courses",
                    From c In school.Courses.Take(5).AsEnumerable()
                    Select New XElement(ns + "Course",
                    If(c.CourseID Is Nothing, Nothing, New XElement(ns + "CourseID", c.CourseID)),
                    If(c.Title Is Nothing, Nothing, New XElement(ns + "Title", c.Title)),
                    If(c.Credits Is Nothing, Nothing, New XElement(ns + "Credits", c.Credits)),
                    If(c.Department Is Nothing, Nothing, New XElement(ns + "Department", c.Department))))

                coursesXml.Save("CoursesByLinqToXml.xml")
            End Using
        End Sub

        ''' <summary>
        ''' Use XmlColumn to store the Xml file in the database
        ''' </summary>
        ''' <param name="document">the Xml file we need to store in the datase</param>
        Private Shared Sub ImportYearCourses(ByVal document As XDocument)
            Using school As New MySchoolContext()
                ' Set the value of Courses property with the Xml document to store the Xml file.
                Dim yearCourse As YearCourse = New YearCourse With {.Year = 2012, .Courses = document}

                school.YearCourses.Add(yearCourse)

                school.SaveChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Export the Xml file from the XmlColumn of the database
        ''' </summary>
        Private Shared Sub ExportYearCourses()
            Using school As New MySchoolContext()
                Dim coursesList As IQueryable(Of YearCourse) = From yc In school.YearCourses
                                                               Select yc

                For Each courses As YearCourse In coursesList
                    ' Set the Xml file name
                    Dim fileName As String = New StringBuilder().AppendFormat(
                        "CoursesFromXmlColumn-{0}.xml", courses.Year).ToString()
                    courses.Courses.Save(fileName)

                    ' After get the Xml document from the XmlColumn, we can use the LinqToXml 
                    ' to get the information of the Course.
                    Dim courseList As IEnumerable(Of Course) =
                    From c In courses.Courses.Descendants("Course")
                    Select New Course With
                    {
                    .CourseID = If(c.Element("CourseId") Is Nothing, Guid.NewGuid().ToString(),
                                    c.Element("CourseId").Value),
                    .Title = If(c.Element("Title") Is Nothing, Nothing, c.Element("Title").Value),
                    .Credits = If(c.Element("Credits") Is Nothing, -1, Int32.Parse(c.Element("Credits").Value)),
                    .Department = If(c.Element("Department") Is Nothing, Nothing, c.Element("Department").Value)
                    }

                    Console.WriteLine("{0}'s Courses:", courses.Year)
                    For Each course As Course In courseList
                        Console.WriteLine("CourseID:{0,-10} Title:{1,-15} Credits:{2,-5} Department:{3}",
                                          course.CourseID, course.Title, course.Credits, course.Department)
                    Next course
                Next courses
            End Using
        End Sub
    End Class
End Namespace
