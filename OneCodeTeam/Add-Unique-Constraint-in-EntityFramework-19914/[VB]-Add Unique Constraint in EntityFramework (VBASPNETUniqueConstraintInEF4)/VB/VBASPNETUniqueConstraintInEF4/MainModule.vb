'***************************** Module Header ******************************\
' Module Name:    MainModule.vb
' Project:        VBASPNETUniqueConstraintInEF4
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to add unique constraint in Entity Framework. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************


Imports System.Linq
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Reflection
Imports System.ComponentModel.DataAnnotations


'''<summary>
'''A unique attribute
'''</summary>
<AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)> _
Public Class UniqueKeyAttribute
    Inherits Attribute
End Class

''' <summary>
'''  Try to analyze the ModelEntity by reflecting them one by one and fetch the properties
'''  with "unique" attribute and then call Sql statement to create database.
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class MyDbGenerator(Of T As DbContext)
    Implements IDatabaseInitializer(Of T)
    Sub InitializeDatabase(context As T) Implements System.Data.Entity.IDatabaseInitializer(Of T).InitializeDatabase
        context.Database.Delete()
        context.Database.Create()

        ' Fetch all the parent class's public properties
        Dim fatherPropertyNames = GetType(DbContext).GetProperties().[Select](Function(pi) pi.Name).ToList()

        ' Loop each dbset's T
        For Each item As PropertyInfo In GetType(T).GetProperties().Where(Function(p) fatherPropertyNames.IndexOf(p.Name) < 0).[Select](Function(p) p)

            ' Fetch the type of "T"
            Dim entityModelType As Type = item.PropertyType.GetGenericArguments()(0)
            Dim allfieldNames = From prop In entityModelType.GetProperties() Where prop.GetCustomAttributes(GetType(UniqueKeyAttribute), True).Count() > 0 Select prop.Name
            For Each s As String In allfieldNames
                context.Database.ExecuteSqlCommand("alter table " & entityModelType.Name & " add unique(" & s & ")")
            Next
        Next
    End Sub
End Class

''' <summary>
''' Category Class
''' </summary>
Public Class Category
    <Key()> _
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Private _id As Integer
    ' Unique Key
    <UniqueKey()> _
    Public Property IdentifyCode() As Integer
        Get
            Return _identifyCode
        End Get
        Set(value As Integer)
            _identifyCode = value
        End Set
    End Property
    Private _identifyCode As Integer
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _name As String
End Class

Public Class DbG
    Inherits DbContext
    ''' <summary>
    ''' This method is called when the model for a derived context has been initialized, but 
    ''' before the model has been locked down and used to initialize the context. 
    ''' </summary>
    ''' <param name="modelBuilder">It is used to map CLR classes to a database schema. </param>
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        '  Disable the default PluralizingTableNameConvention
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
    End Sub

    Public Property Categories() As DbSet(Of Category)
        Get
            Return _categories
        End Get
        Set(value As DbSet(Of Category))
            _categories = value
        End Set
    End Property
    Private _categories As DbSet(Of Category)
End Class

Module MainModule
    Sub Main()
        ' Get or set the database initialization strategy.
        Database.SetInitializer(Of DbG)(New MyDbGenerator(Of DbG)())

        Using g As New DbG()
            g.Categories.Add(New Category() With { _
              .Id = 1, _
              .Name = "Category" _
            })
            g.Categories.Add(New Category() With { _
              .Id = 2, _
              .IdentifyCode = 2, _
              .Name = "Category" _
            })

            ' Save all changes
            g.SaveChanges()

            Console.WriteLine("OK")
        End Using
    End Sub
End Module

