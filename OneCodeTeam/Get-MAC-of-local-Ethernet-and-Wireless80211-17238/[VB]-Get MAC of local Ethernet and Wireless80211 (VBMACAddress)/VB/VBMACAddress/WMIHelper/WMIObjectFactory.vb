'************************** Module Header ******************************'
' Module Name:  WMIObjectFactory.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
'
' The class is used to initialize a .NET class object from a WMI object.
' 
' The .NET class must have the WMIClassAttribute which has the same ClassName
' as the WMI object. Then get the properties of the WMI object and use reflection 
' to set the value of the .NET class object properties.
' 
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Linq
Imports System.Management

Namespace WMIHelper
    Friend Class WMIObjectFactory

        ''' <summary>
        ''' Initialize a .NET class object from a ManagementObject
        ''' </summary>
        ''' <param name="t">
        ''' The .NET type.
        ''' </param>
        ''' <param name="scope">
        ''' The scope contains the ConnectionOptions, which includes the credential.
        ''' </param>
        ''' <returns></returns>
        Public Shared Function GetInstance(ByVal wmiObject As ManagementBaseObject,
                                           ByVal t As Type, ByVal scope As ManagementScope) As Object
            Dim instance As Object = Nothing

            Try

                ' The .NET type must have the WMIClassAttribute.
                If t.GetCustomAttributes(GetType(WMIClassAttribute), True).Count() > 0 Then
                    Dim classAttribute As WMIClassAttribute =
                        TryCast(t.GetCustomAttributes(GetType(WMIClassAttribute), True).First(), WMIClassAttribute)

                    ' Check whether the ClassName property of the WMIClassAttribute is the 
                    ' same as the WMI object.
                    If classAttribute.ClassName.Equals(wmiObject.ClassPath.ClassName) Then

                        ' Get the default constructor of the .NET type.
                        Dim ctor = t.GetConstructor(Type.EmptyTypes)

                        ' Invoke the constructor to create an instance. 
                        instance = ctor.Invoke(Nothing)

                        If instance IsNot Nothing Then

                            ' Use reflection to set the value of the .NET type object
                            ' properties. 
                            SetInstancePropertiesValue(t, instance, wmiObject, scope)

                        End If
                    End If
                End If
                Return instance
            Catch
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Use reflection to set the value of the .NET class object properties.
        ''' </summary>
        ''' <param name="t">The .NET type.</param>
        ''' <param name="instance">The .NET object.</param>
        ''' <param name="wmiObject">The WMI object.</param>
        ''' <param name="scope">
        ''' The scope contains the ConnectionOptions, which includes the credential.
        ''' In sometime, the WMI object may refer to another WMI object, and we have 
        ''' to use the scope to get the referred object.
        ''' </param>
        Private Shared Sub SetInstancePropertiesValue(ByVal t As Type, ByVal instance As Object,
                                                      ByVal wmiObject As ManagementBaseObject,
                                                      ByVal scope As ManagementScope)
            For Each prop In t.GetProperties()

                ' The property must have the WMIPropertyAttribute.
                If prop.GetCustomAttributes(GetType(WMIPropertyAttribute), True).Count() > 0 Then
                    Dim wmiPropertyAttribute As WMIPropertyAttribute =
                        TryCast(prop.GetCustomAttributes(
                                GetType(WMIPropertyAttribute), True).First(), 
                            WMIPropertyAttribute)

                    ' Get the related property name of the WMI object.
                    Dim propertyName As String = If(String.IsNullOrEmpty(wmiPropertyAttribute.PropertyName),
                                                    prop.Name, wmiPropertyAttribute.PropertyName)

                    ' Get the property value of the WMI object.
                    ' The type of the WMI object property value may be not the same as the 
                    ' .NET type. For example, date time or the referred WMI object.
                    Dim value As Object = wmiObject.Properties(propertyName).Value

                    If value Is Nothing Then
                        If Not prop.PropertyType.IsValueType Then
                            prop.SetValue(instance, Nothing, Nothing)
                        End If
                        Continue For
                    End If

                    ' Convert the type of the the property value of the WMI object.
                    Dim propertyValue As Object = Nothing

                    Select Case wmiPropertyAttribute.PropertyType

                        ' The WMI object refers to another WMI object.
                        ' It may refer to the object directly, or just contain the path
                        ' of another object.
                        Case WMIPropertyType.WMIObject

                            If TypeOf value Is ManagementBaseObject Then
                                propertyValue =
                                    GetInstance(TryCast(value, ManagementBaseObject),
                                                wmiPropertyAttribute.AssociatedWMIClass, scope)
                            ElseIf TypeOf value Is String Then
                                Dim obj As ManagementBaseObject = Nothing
                                Try
                                    Dim path As New ManagementPath(TryCast(value, String))

                                    If scope IsNot Nothing Then
                                        obj = New ManagementObject(scope, path, New ObjectGetOptions())
                                    Else
                                        obj = New ManagementObject(path)
                                    End If
                                    propertyValue = GetInstance(obj, wmiPropertyAttribute.AssociatedWMIClass, scope)
                                Catch
                                    propertyValue = Nothing
                                Finally
                                    If obj IsNot Nothing Then
                                        obj.Dispose()
                                    End If
                                End Try
                            Else
                                propertyValue = Nothing
                            End If
                        Case WMIPropertyType.DateTime
                            If TypeOf value Is String Then
                                propertyValue = ManagementDateTimeConverter.ToDateTime(TryCast(value, String))
                            End If
                        Case Else
                            propertyValue = value
                    End Select

                    If propertyValue IsNot Nothing Then
                        prop.SetValue(instance, propertyValue, Nothing)
                    End If
                End If
            Next prop
        End Sub
    End Class
End Namespace
