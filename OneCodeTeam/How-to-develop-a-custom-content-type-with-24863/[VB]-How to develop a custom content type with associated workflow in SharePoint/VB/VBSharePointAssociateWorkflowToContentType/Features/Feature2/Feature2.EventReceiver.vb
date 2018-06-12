'*****************************' Module Header ******************************\
' Module Name:    Feature2.EventReceiver.vb
' Project:        VBSharePointAssociateWorkflowToContentType
' Copyright (c) Microsoft Corporation
'
' This sample would let developers know what's happening in the background
' when they associate a workflow to a content type.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Option Explicit On
Option Strict On

Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Security
Imports Microsoft.SharePoint.Workflow

''' <summary>
''' This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
''' </summary>
''' <remarks>
''' The GUID attached to this class may be used during packaging and should not be modified.
''' </remarks>

<GuidAttribute("7b48cd67-5602-4d71-a6fb-004cbd46665c")> _
Public Class Feature2EventReceiver
    Inherits SPFeatureReceiver
    ' Your site
    Private siteName As String = "http://win-2ed380lbo8e:7947/"
    ' Workflow Name
    Private WorkflowName As String = "WorkflowForContentType"
    ' ContentType Name
    Private ContentTypeName As String = "MyContentType"

    ' Uncomment the method below to handle the event raised after a feature has been activated.

    Public Overrides Sub FeatureActivated(ByVal properties As SPFeatureReceiverProperties)
        UpdateWorkflowAssociation(1)
    End Sub


    ' Uncomment the method below to handle the event raised before a feature is deactivated.

    Public Overrides Sub FeatureDeactivating(ByVal properties As SPFeatureReceiverProperties)
        UpdateWorkflowAssociation(0)
    End Sub


    ' Uncomment the method below to handle the event raised after a feature has been installed.

    'Public Overrides Sub FeatureInstalled(ByVal properties As SPFeatureReceiverProperties)
    'End Sub


    ' Uncomment the method below to handle the event raised before a feature is uninstalled.

    'Public Overrides Sub FeatureUninstalling(ByVal properties As SPFeatureReceiverProperties)
    'End Sub

    ' Uncomment the method below to handle the event raised when a feature is upgrading.

    'Public Overrides Sub FeatureUpgrading(ByVal properties As Microsoft.SharePoint.SPFeatureReceiverProperties, ByVal upgradeActionName As String, ByVal parameters As System.Collections.Generic.IDictionary(Of String, String))
    'End Sub

    ''' <summary>
    ''' Set the associated between workflow and Content Type.
    ''' </summary>
    ''' <param name="type">0: Remove; 1: Add or update</param>
    ''' <remarks></remarks>
    Private Sub UpdateWorkflowAssociation(ByVal type As Integer)
        ' Connect to Sharepoint Site
        Using site = New SPSite(siteName)

            ' Open Sharepoint Site
            Using Web = site.OpenWeb()
                ' Get the ContentType by Specific Name
                Dim theCT As SPContentType = Web.ContentTypes(ContentTypeName)
                ' Workflow Template
                Dim theWF As SPWorkflowTemplate = Nothing

                ' Fetch the collection of Workflow Template to get the specific one
                For Each tpl As SPWorkflowTemplate In Web.WorkflowTemplates
                    If tpl.Name = WorkflowName Then
                        theWF = tpl
                    End If
                Next

                ' Represents the association of the workflow template
                Dim wfAssociation As SPWorkflowAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, Web.Locale)

                ' If it has associated, remove the association. 
                If wfAssociation IsNot Nothing Then
                    theCT.WorkflowAssociations.Remove(wfAssociation)
                End If

                '  Update Workflow Associations
                theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)

                '
                If type > 0 Then
                    ' Create web ContentType association to the workflow template
                    wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, "Tasks", "Workflow History")

                    ' If it hasn't associated then to add a association. Or updates the association.
                    If theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, Web.Locale) Is Nothing Then
                        theCT.WorkflowAssociations.Add(wfAssociation)
                    Else
                        theCT.WorkflowAssociations.Update(wfAssociation)
                    End If

                    '  Update Workflow Associations
                    theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)
                End If

            End Using
        End Using

    End Sub


End Class
