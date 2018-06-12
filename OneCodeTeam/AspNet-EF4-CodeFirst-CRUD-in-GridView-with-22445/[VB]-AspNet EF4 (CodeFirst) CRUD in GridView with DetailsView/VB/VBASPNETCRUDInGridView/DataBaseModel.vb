'***************************** Module Header ******************************\
'* Module Name:    DataBaseModel.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The whole file defines several model classes for code-first to generate
'* the related databases.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

''' <summary>
''' This is a student table
''' </summary>
Public Class Student
    ''' <summary>
    ''' Point out this is a Primary Key and it's auto-generated.
    ''' </summary>
    <Key()> _
    <DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)> _
    Public Property StudentId() As Integer
        Get
            Return _studentId
        End Get
        Set(ByVal value As Integer)
            _studentId = value
        End Set
    End Property
    Private _studentId As Integer

    ''' <summary>
    ''' Point out this field is not null and it has the number 
    ''' of character to int.MaxValue
    ''' </summary>
    <Required()> _
    <MaxLength(Integer.MaxValue)> _
    Public Property StudentName() As String
        Get
            Return _studentName
        End Get
        Set(ByVal value As String)
            _studentName = value
        End Set
    End Property
    Private _studentName As String

    Public Overridable Property Courses() As ICollection(Of Student_Course)
        Get
            Return _courses
        End Get
        Set(ByVal value As ICollection(Of Student_Course))
            _courses = value
        End Set
    End Property
    Private _courses As ICollection(Of Student_Course)
End Class

''' <summary>
''' Course Table
''' </summary>
Public Class Course
    <Key()> _
    <DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)> _
    Public Property CourseId() As Integer
        Get
            Return _courseId
        End Get
        Set(ByVal value As Integer)
            _courseId = value
        End Set
    End Property
    Private _courseId As Integer

    <Required()> _
    <MaxLength(Integer.MaxValue)> _
    Public Property CourseName() As String
        Get
            Return _courseName
        End Get
        Set(ByVal value As String)
            _courseName = value
        End Set
    End Property
    Private _courseName As String

    Public Overridable Property Students() As ICollection(Of Student_Course)
        Get
            Return _students
        End Get
        Set(ByVal value As ICollection(Of Student_Course))
            _students = value
        End Set
    End Property
    Private _students As ICollection(Of Student_Course)

End Class

''' <summary>
''' This table links the "Student" and "Course" tables together for searching.
''' </summary>
Public Class Student_Course
    <Key()> _
    <DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)> _
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _id As Integer
    Public Property Sid() As Integer
        Get
            Return _sid
        End Get
        Set(ByVal value As Integer)
            _sid = value
        End Set
    End Property
    Private _sid As Integer
    Public Property Cid() As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value
        End Set
    End Property
    Private _cid As Integer
    <Required()> _
    Public Property Score() As Double
        Get
            Return _score
        End Get
        Set(ByVal value As Double)
            _score = value
        End Set
    End Property
    Private _score As Double

    ''' <summary>
    ''' This points out that Cid is the foreign Key to Course's CourseId,
    ''' and it's Cascading Deleting by default.
    ''' </summary>
    <ForeignKey("Sid")> _
    Public Overridable Property Student() As Student
        Get
            Return _student
        End Get
        Set(ByVal value As Student)
            _student = value
        End Set
    End Property
    Private _student As Student
    <ForeignKey("Cid")> _
    Public Overridable Property Course() As Course
        Get
            Return _course
        End Get
        Set(ByVal value As Course)
            _course = value
        End Set
    End Property
    Private _course As Course
End Class

''' <summary>
''' This is a nested class that will show the relationship
''' between Students and Courses
''' </summary>
Public Class TempStudentCourse
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _id As Integer
    Public Property CourseName() As String
        Get
            Return _courseName
        End Get
        Set(ByVal value As String)
            _courseName = value
        End Set
    End Property
    Private _courseName As String
    Public Property Sid() As Integer
        Get
            Return _sid
        End Get
        Set(ByVal value As Integer)
            _sid = value
        End Set
    End Property
    Private _sid As Integer
    Public Property Cid() As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value
        End Set
    End Property
    Private _cid As Integer
    Public Property Score() As Double
        Get
            Return _score
        End Get
        Set(ByVal value As Double)
            _score = value
        End Set
    End Property
    Private _score As Double
End Class
