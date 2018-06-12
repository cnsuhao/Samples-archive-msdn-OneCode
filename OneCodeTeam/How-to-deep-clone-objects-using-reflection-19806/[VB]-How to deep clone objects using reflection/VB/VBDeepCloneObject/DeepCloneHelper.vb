'**************************** Module Header ******************************\
' Module Name:  DeepCloneHelper.vb
' Project:      VBDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' The class contains the methods that implement deep clone using reflection.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Reflection
Imports System

Namespace VBDeepCloneObject
    Friend Class DeepCloneHelper
        ''' <summary>
        ''' Get the deep clone of an object.
        ''' </summary>
        ''' <typeparam name="T">The type of the obj.</typeparam>
        ''' <param name="obj">It is the object used to deep clone.</param>
        ''' <returns>Return the deep clone.</returns>
        Public Shared Function DeepClone(Of T)(ByVal obj As T) As T
            If obj Is Nothing Then
                Throw New ArgumentNullException("Object is null")
            End If
            Return CType(CloneProcedure(obj), T)
        End Function

        ''' <summary>
        ''' This method implements deep clone using reflection.
        ''' </summary>
        ''' <param name="obj">It is the object used to deep clone.</param>
        ''' <returns>Return the deep clone.</returns>
        Private Shared Function CloneProcedure(ByVal obj As Object) As Object
            If obj Is Nothing Then
                Return Nothing
            End If

            Dim type As System.Type = obj.GetType()

            ' If the type of object is the value type, we will always get a new object when 
            ' the original object is assigned to another variable. So if the type of the 
            ' object is the value type, we just return the object. 
            ' If the string variables contain the same chars, they always refer to the same 
            ' string in the heap. So if the type of the object is string, we also return the 
            ' object.
            If type.IsValueType OrElse type Is GetType(String) Then
                Return obj
                ' If the type of the object is the Array, we use the CreateInstance method to get
                ' a new instance of the array. We also process recursively this method in the 
                ' elements of the original array because the type of the element may be the reference 
                ' type.
            ElseIf type.IsArray Then
                Dim typeElement As System.Type = type.GetType(type.FullName.Replace("[]", String.Empty))
                Dim array = TryCast(obj, System.Array)
                Dim copiedArray As System.Array = System.Array.CreateInstance(typeElement, array.Length)
                For i As Integer = 0 To array.Length - 1
                    ' Get the deep clone of the element in the original array and assign the 
                    ' clone to the new array.
                    copiedArray.SetValue(CloneProcedure(array.GetValue(i)), i)

                Next i
                Return copiedArray
                ' If the type of the object is class, it may contain the reference fields,so we use  
                ' reflection and process recursively this method in the fields of the object to get 
                ' the deep clone of the object. 
            ElseIf type.IsClass Then
                Dim copiedObject As Object = Activator.CreateInstance(obj.GetType())
                ' Get all FieldInfo.
                Dim fields() As FieldInfo = type.GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
                For Each field As FieldInfo In fields
                    Dim fieldValue As Object = field.GetValue(obj)
                    If fieldValue IsNot Nothing Then
                        ' Get the deep clone of the field in the original object and assign the 
                        ' clone to the field in the new object.
                        field.SetValue(copiedObject, CloneProcedure(fieldValue))
                    End If

                Next field
                Return copiedObject
            Else
                Throw New ArgumentException("The object is unknown type")
            End If
        End Function

    End Class
End Namespace
