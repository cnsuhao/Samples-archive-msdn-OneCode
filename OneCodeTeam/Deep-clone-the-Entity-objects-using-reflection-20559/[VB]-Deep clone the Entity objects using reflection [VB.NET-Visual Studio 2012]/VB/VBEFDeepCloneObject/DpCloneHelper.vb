'******************************** Module Header **********************************\
' Module Name:	DpCloneHelper.vb
' Project:		VBEFDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement deep clone/duplicate entity objects 
' using serialization and reflection.
' This module defines some extension methods to implement the deep clone.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************/

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Data.Objects.DataClasses
Imports System.Runtime.Serialization
Imports System.IO

Namespace VBEFDeepCloneObject

    Module DpCloneHelper
        ''' <summary>
        '''  The Extension method will be used to clear the entity of object and all related child objects 
        ''' </summary>
        ''' <param name="source">Entity Object need to be cleared</param>
        ''' <param name="bcheckHierarchy">This parameter is used to define whether to clear all the child object</param>
        ''' <returns></returns>
        Private Function ClearEntityObject(Of T As Class)(ByVal source As T, ByVal bCheckHierarchy As Boolean) As T
            If (source Is Nothing) Then
                Throw New Exception("Null Object cannot be cloned")
            End If
            Dim tObj As Type = source.GetType
            If (Not tObj.GetProperty("EntityKey") Is Nothing) Then
                tObj.GetProperty("EntityKey").SetValue(source, Nothing, Nothing)
            End If
            If bCheckHierarchy Then
                Dim PropertyList As List(Of PropertyInfo) = Enumerable.ToList(Of PropertyInfo)((From a In source.GetType.GetProperties
                    Where a.PropertyType.Name.Equals("ENTITYCOLLECTION`1", StringComparison.OrdinalIgnoreCase)
                    Select a))
                Dim prop As PropertyInfo
                For Each prop In PropertyList
                    Dim keys As IEnumerable = DirectCast(tObj.GetProperty(prop.Name).GetValue(source, Nothing), IEnumerable)
                    Dim key As Object
                    For Each key In keys
                        Dim childProp As EntityReference = Enumerable.SingleOrDefault(Of PropertyInfo)((From a In key.GetType.GetProperties
                        Where (a.PropertyType.Name.Equals("EntityReference`1", StringComparison.OrdinalIgnoreCase))
                            Select a)).GetValue(key, Nothing)

                        ClearEntityObject(childProp, False)
                        ClearEntityObject(key, True)
                    Next
                Next
            End If
            Return source
        End Function

        ''' <summary>
        '''  Clear the entity of object and all related child objects 
        ''' </summary>
        ''' <param name="source">Entity Object need to be cleared</param>
        ''' <param name="bcheckHierarchy">This parameter is used to determine whether to clear all the child object</param>
        ''' <returns></returns>
        <Extension()> _
        Public Function ClearEntityReference(ByVal source As EntityObject, ByVal bCheckHierarchy As Boolean) As EntityObject
            Return ClearEntityObject(source, bCheckHierarchy)
        End Function

        ''' <summary>
        ''' Extension method to Enitity Object. 
        ''' Deeply clone the Object.
        ''' </summary>
        ''' <param name="source">Entity Object need to be cloned </param>
        ''' <returns>The cloned object</returns>
        <Extension()> _
        Public Function Clone(Of T As EntityObject)(ByVal source As T) As T
            Dim ser As New DataContractSerializer(GetType(T))
            Using stream As MemoryStream = New MemoryStream
                ser.WriteObject(stream, source)
                stream.Seek(0, SeekOrigin.Begin)
                Return DirectCast(ser.ReadObject(stream), T)
            End Using
        End Function
    End Module

End Namespace
