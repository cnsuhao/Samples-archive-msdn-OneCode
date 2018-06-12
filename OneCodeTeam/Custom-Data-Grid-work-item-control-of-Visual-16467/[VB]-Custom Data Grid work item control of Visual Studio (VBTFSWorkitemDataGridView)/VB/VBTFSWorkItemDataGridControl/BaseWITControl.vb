'************************** Module Header ******************************'
' Module Name:   BaseWITControl.vb
' Project:       VBTFSWorkItemDataGridControl
' Copyright (c) Microsoft Corporation.
' 
' This class implements the basic logic of a custom workitem control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.Collections.Specialized
Imports Microsoft.TeamFoundation.WorkItemTracking.Client
Imports Microsoft.TeamFoundation.WorkItemTracking.Controls

Public MustInherit Class BaseWITControl
    Inherits UserControl
    Implements IWorkItemControl
#Region "Fields and properties"

    Private Shared _eventBeforeUpdateDatasource As New Object()
    Private Shared _eventAfterUpdateDatasource As New Object()

    Private _properties As StringDictionary
    Private _readOnly As Boolean = False

    Private _serviceProvider As IServiceProvider

    ''' <summary>
    ''' From this service provider, we can get the services of Visual Studio.
    ''' </summary>
    Protected ReadOnly Property ServiceProvider() As IServiceProvider
        Get
            Return _serviceProvider
        End Get
    End Property

    Private _workItem As WorkItem
    Private _fieldName As String

    Protected ReadOnly Property HasValidField() As Boolean
        Get
            Return (Me.Field IsNot Nothing)
        End Get
    End Property

    Private _fieldCache As Field = Nothing
    Protected Overridable Property Field() As Field
        Get
            If (Me._fieldCache Is Nothing) AndAlso _
                ((Me._workItem IsNot Nothing) AndAlso _
                 (Not String.IsNullOrEmpty(Me._fieldName))) Then
                Try
                    Me._fieldCache = Me._workItem.Fields(Me._fieldName)
                Catch
                    Me._fieldCache = Nothing
                End Try
            End If
            Return Me._fieldCache
        End Get
        Set(ByVal value As Field)
            Me._fieldCache = value
        End Set
    End Property

#End Region

#Region "IWorkItemControl interface"

    ''' <summary>
    ''' Raise this event after updating WorkItem object with values.
    ''' When value is changed by a control, work item form asks all controls (except
    ''' current control) to refresh their display values (by calling 
    ''' InvalidateDatasource) in case if affects other controls 
    ''' </summary>
    Public Custom Event AfterUpdateDatasource As EventHandler _
        Implements IWorkItemControl.AfterUpdateDatasource

        AddHandler(ByVal value As EventHandler)
            Events.AddHandler(_eventAfterUpdateDatasource, value)
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            Events.RemoveHandler(_eventAfterUpdateDatasource, value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
        End RaiseEvent
    End Event

    ''' <summary>
    ''' Raise this events before updating WorkItem object with values.
    ''' When value is changed by a control, work item form asks all controls (except
    ''' current control) to refresh their display values (by calling 
    ''' InvalidateDatasource) in case if affects other controls 
    ''' </summary>
    Public Custom Event BeforeUpdateDatasource As EventHandler _
        Implements IWorkItemControl.BeforeUpdateDatasource

        AddHandler(ByVal value As EventHandler)
            Events.AddHandler(_eventBeforeUpdateDatasource, value)
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            Events.RemoveHandler(_eventBeforeUpdateDatasource, value)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
        End RaiseEvent

    End Event

    ''' <summary>
    ''' Control is asked to clear its contents
    ''' </summary>
    Public MustOverride Sub Clear() Implements IWorkItemControl.Clear

    ''' <summary>
    ''' Control is requested to flush any data to workitem object. 
    ''' </summary>
    Public MustOverride Sub FlushToDatasource() _
        Implements IWorkItemControl.FlushToDatasource

    '''<summary>
    ''' Asks control to invalidate the contents and redraw.
    ''' </summary>
    Public MustOverride Sub InvalidateDatasource() _
        Implements IWorkItemControl.InvalidateDatasource


    '''<summary>
    ''' All attributes specified in work item type definition file for this 
    ''' control, including custom attributes.
    ''' </summary>
    Public Overridable Property Properties() As StringDictionary _
        Implements IWorkItemControl.Properties

        Get
            Return _properties
        End Get
        Set(ByVal value As StringDictionary)
            _properties = value
        End Set
    End Property

    ''' <summary>
    ''' Whether the control is readonly.
    ''' </summary>
    Public Overridable Property [ReadOnly]() As Boolean _
        Implements IWorkItemControl.ReadOnly

        Get
            Return Me._readOnly
        End Get
        Set(ByVal value As Boolean)
            Me.SetReadOnly(value)
        End Set

    End Property

    ''' <summary>
    ''' We can use the serviceProvider to get Visual Studio services.
    ''' </summary>
    ''' <param name="serviceProvider"></param>
    Public Overridable Sub SetSite(ByVal serviceProvider As IServiceProvider) _
        Implements IWorkItemControl.SetSite

        Me._serviceProvider = serviceProvider

    End Sub

    ''' <summary>
    ''' WorkItemDatasource refers to current work item object. 
    ''' </summary>
    Public Overridable Property WorkItemDatasource() As Object _
        Implements IWorkItemControl.WorkItemDatasource

        Get
            Return _workItem
        End Get
        Set(ByVal value As Object)
            _workItem = CType(value, WorkItem)
        End Set
    End Property

    ''' <summary>
    ''' The field name which the control is associated with in work item type
    ''' definition.
    '''</summary>
    Public Overridable Property WorkItemFieldName() As String _
        Implements IWorkItemControl.WorkItemFieldName

        Get
            Return _fieldName
        End Get
        Set(ByVal value As String)
            _fieldName = value
        End Set
    End Property

#End Region

#Region "Common Methods"

    ''' <summary>
    ''' Set value to current field.
    ''' </summary>
    Protected Overridable Sub SetFieldValue(ByVal value As Object)
        If Me.HasValidField AndAlso Me.Field.IsEditable Then
            Me.OnBeforeUpdateDatasource(EventArgs.Empty)
            Me.Field.Value = value
            Me.OnAfterUpdateDatasource(EventArgs.Empty)
        End If
    End Sub

    ''' <summary>
    ''' Set current control as readonly.
    ''' </summary>
    ''' <param name="readOnly"></param>
    Protected Overridable Sub SetReadOnly(ByVal [readOnly] As Boolean)
        Me._readOnly = [readOnly]
    End Sub

    Protected Overridable Sub OnAfterUpdateDatasource(ByVal e As EventArgs)
        Dim handler As EventHandler = CType(MyBase.Events(_eventAfterUpdateDatasource), EventHandler)
        If handler IsNot Nothing Then
            handler(Me, e)
        End If
    End Sub
    Protected Overridable Sub OnBeforeUpdateDatasource(ByVal e As EventArgs)
        Dim handler As EventHandler = CType(MyBase.Events(_eventBeforeUpdateDatasource), EventHandler)
        If handler IsNot Nothing Then
            handler(Me, e)
        End If
    End Sub

#End Region
End Class

