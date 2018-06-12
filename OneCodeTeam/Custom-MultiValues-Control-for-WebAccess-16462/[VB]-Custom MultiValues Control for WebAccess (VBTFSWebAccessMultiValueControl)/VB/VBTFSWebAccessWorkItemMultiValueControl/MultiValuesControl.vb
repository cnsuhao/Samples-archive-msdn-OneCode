'************************** Module Header ******************************'
' Module Name:   MultiValuesControl.vb
' Project:       VBTFSWebAccessWorkItemMultiValueControl
' Copyright (c) Microsoft Corporation.
' 
' This class inherits the BaseWITControl and it uses a list of check boxes to 
' represent a workitem field.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Microsoft.TeamFoundation.WebAccess.WorkItemTracking.Controls
Imports Microsoft.TeamFoundation.WebAccess.Controls

' Defines the metadata attribute that enables an embedded resource in an assembly.
<Assembly: WebResource("VBTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js",
"application/x-javascript")> 

''' <summary>
''' This class inherits BaseWorkItemWebControl which implements most methods of the 
''' IWorkItemWebControl interface.
''' </summary>
<ToolboxData("<{0}:MultiValuesControl runat=server></{0}:MultiValuesControl>")>
Public Class MultiValuesControl
    Inherits BaseWorkItemWebControl

    ' This char is used to split the options.
    Private Const splitCharactor As Char = ";"c

    ' A list of CheckBoxes which represent the options.
    Private lstOptions As CheckBoxList

    Public Sub New()
        MyBase.New(HtmlTextWriterTag.Div)
    End Sub

#Region "IWorkItemWebControl"

    ''' <summary>
    ''' Clear the value in the checkboxes.
    ''' </summary>
    Public Overrides Sub Clear()
        Me.EnsureChildControls()
        For i As Integer = 0 To Me.lstOptions.Items.Count - 1
            Me.lstOptions.Items(i).Selected = False
        Next i
    End Sub

    ''' <summary>
    ''' Control is requested to flush any data to workitem object. 
    ''' Combine the selected options to a string, and then set it as the 
    ''' field value.
    ''' </summary>
    Public Overrides Sub FlushToDatasource()
        Me.EnsureChildControls()

        Dim value As New StringBuilder()
        For i As Integer = 0 To Me.lstOptions.Items.Count - 1
            If Me.lstOptions.Items(i).Selected Then
                value.AppendFormat("{0}{1}", Me.lstOptions.Items(i), splitCharactor)
            End If
        Next i
        Me.SetFieldValue(value.ToString())
    End Sub

    '''<summary>
    ''' Asks control to invalidate the contents and redraw.
    ''' </summary>
    Public Overrides Sub InvalidateDatasource()
        Me.EnsureChildControls()
        Me.Clear()

        Me.lstOptions.BackColor = Color.White

        For i As Integer = 0 To Me.lstOptions.Items.Count - 1
            Dim checkedState As Boolean = (TryCast(Me.Field.Value, String)).Contains(String.Format("{0}{1}", Me.lstOptions.Items(i).Text, splitCharactor))
            Me.lstOptions.Items(i).Selected = checkedState
        Next i
    End Sub
#End Region

#Region " Overrides methods"

    ''' <summary>
    ''' Create the child controls.
    ''' </summary>
    Protected Overrides Sub CreateChildControls()
        Me.Controls.Clear()
        Me.lstOptions = New CheckBoxList()
        Me.lstOptions.ID = "val"
        If Me.HasValidField AndAlso Me.Field.HasAllowedValuesList Then
            For Each value In Me.Field.AllowedValues

                Dim item As ListItem = New ListItem With {
                    .Text = TryCast(value, String),
                    .Value = TryCast(value, String)}

                item.Attributes.Add("title", TryCast(value, String))

                Me.lstOptions.Items.Add(item)
            Next value
        End If
        Me.Controls.Add(Me.lstOptions)
    End Sub

    ''' <summary>
    ''' Initialize this control.
    ''' </summary>
    Public Overrides Sub InitializeControl()
        MyBase.InitializeControl()
        Me.EnsureChildControls()
    End Sub

    ''' <summary>
    ''' Register the client script.
    ''' 1. VBTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
    ''' 2. Use multiValuesControl method in VBTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
    '''    to generate a client object.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)
        ScriptManager.RegisterClientScriptResource(
            Me,
            GetType(MultiValuesControl),
            "VBTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js")

        Dim clientID As String = Me.lstOptions.ClientID

        ScriptHelper.RegisterObjectScript(
            Me,
            "multiValuesControl",
            New Object() {
                MyBase.ClientEditorObjectId,
                MyBase.WorkItemFieldName,
                MyBase.ControlId,
                clientID,
                MyBase.ReadOnly})
    End Sub
#End Region
End Class

