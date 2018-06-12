'****************************** Module Header ******************************\
' Module Name:    WorkflowAssociationForm.aspx.vb
' Project:        VBSharePointReplicatorActivity
' Copyright (c) Microsoft Corporation
'
' This page is used to set Workflow Association Data
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Web
Imports System.Web.UI
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Workflow


Namespace Layouts.VBSharePointReplicatorActivity

    Partial Public Class WorkflowAssociationForm
        Inherits LayoutsPageBase

        Private Const CreateListTryCount As Integer = 100
        Private historyListDescription As String = "Custom History List"
        Private taskListDescription As String = "Custom Task List"
        Private listCreationFailed As String = "Failed to create list {0} as a list with same name already exists"
        Private workflowAssociationFailed As String = "Error occured while associating Workflow template. {0}"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            InitializeParams()
        End Sub

        Private Sub PopulateFormFields(ByVal existingAssociation As SPWorkflowAssociation)
            ' initilize controls on association form if there is association data
            If existingAssociation Is Nothing Then
            Else
                Dim serializer As New XmlSerializer(GetType(AssociationData))
                Dim reader As New XmlTextReader(New StringReader(existingAssociation.AssociationData))
                Dim wfData As AssociationData = DirectCast(serializer.Deserialize(reader), AssociationData)

                pickerApprover.CommaSeparatedAccounts = wfData.Partners.ContactList.ToString()

                txtInstructions.Text = wfData.Description
            End If
        End Sub

        ' This method is called when the user clicks the button to associate the workflow.
        Private Function GetAssociationData() As String

            Dim wfData As New AssociationData()

            For Each pe As PickerEntity In pickerApprover.ResolvedEntities
                wfData.AddContact(pe.Key)
            Next

            wfData.Description = txtInstructions.Text

            Using stream As New MemoryStream()
                Dim serializer As New XmlSerializer(GetType(AssociationData))
                serializer.Serialize(stream, wfData)
                stream.Position = 0
                Dim bytes As Byte() = New Byte(stream.Length - 1) {}
                stream.Read(bytes, 0, bytes.Length)
                Dim WorkflowData As String = Encoding.UTF8.GetString(bytes)
                Return WorkflowData
            End Using

        End Function

        Protected Sub AssociateWorkflow_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Optionally, add code here to perform additional steps before associating your workflow
            Try
                CreateTaskList()
                CreateHistoryList()
                HandleAssociateWorkflow()
                SPUtility.Redirect("WrkSetng.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current, Page.ClientQueryString)
            Catch ex As Exception
                SPUtility.TransferToErrorPage([String].Format(CultureInfo.CurrentCulture, workflowAssociationFailed, ex.Message))
            End Try
        End Sub

        Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            SPUtility.Redirect("WrkSetng.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current, Page.ClientQueryString)
        End Sub

#Region "Workflow Association Code - Typically, the following code should not be changed"
        <Serializable()> _
        Private Enum WorkflowAssociationType
            ListAssociation
            WebAssociation
            ListContentTypeAssociation
            SiteContentTypeAssociation
        End Enum

        <Serializable()> _
        Private Structure AssociationParams
            Public AssociationName As String
            Public BaseTemplate As String
            Public AutoStartCreate As Boolean
            Public AutoStartChange As Boolean
            Public AllowManual As Boolean
            Public RequireManagedListPermisions As Boolean
            Public SetDefaultApprovalWorkflow As Boolean
            Public LockItem As Boolean
            Public AssociationGuid As Guid
            Public AssociationType As WorkflowAssociationType
            Public TargetListGuid As Guid
            Public TaskListGuid As Guid
            Public TaskListName As String
            Public HistoryListGuid As Guid
            Public HistoryListName As String
            Public ContentTypeId As SPContentTypeId
            Public ContentTypePushDown As Boolean
        End Structure

        Private MyAssociationParams As AssociationParams

        Private Sub InitializeParams()
            ' Check if the page is loaded for first time
            If ViewState("associationParams") Is Nothing Then
                InitializeAssociationParams()
                ViewState("associationParams") = Me.MyAssociationParams
                Dim existingAssociation As SPWorkflowAssociation = GetExistingAssociation()
                PopulateFormFields(existingAssociation)
            Else
                Me.MyAssociationParams = CType(ViewState("associationParams"), AssociationParams)
            End If
        End Sub

        Private Sub InitializeAssociationParams()
            Me.MyAssociationParams = New AssociationParams()
            Me.MyAssociationParams.AssociationName = Request.Params("WorkflowName")
            Me.MyAssociationParams.BaseTemplate = Request.Params("WorkflowDefinition")
            Me.MyAssociationParams.AutoStartCreate = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("AutoStartCreate"), "ON") = 0)
            Me.MyAssociationParams.AutoStartChange = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("AutoStartChange"), "ON") = 0)
            Me.MyAssociationParams.AllowManual = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("AllowManual"), "ON") = 0)
            Me.MyAssociationParams.RequireManagedListPermisions = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("ManualPermManageListRequired"), "ON") = 0)
            Me.MyAssociationParams.SetDefaultApprovalWorkflow = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("SetDefault"), "ON") = 0)
            Me.MyAssociationParams.LockItem = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("AllowEdits"), "FALSE") = 0)
            Me.MyAssociationParams.ContentTypePushDown = (StringComparer.OrdinalIgnoreCase.Compare(Request.Params("UpdateLists"), "TRUE") = 0)

            Dim associationGuid As String = Request.Params("GuidAssoc")
            If Not [String].IsNullOrEmpty(associationGuid) Then
                Me.MyAssociationParams.AssociationGuid = New Guid(associationGuid)
            End If

            InitializeAssociationTypeParams()
            InitializeTaskListParams()
            InitializeHistoryListParams()
        End Sub

        Private Sub InitializeAssociationTypeParams()
            Dim listGuid As String = Request.QueryString("List")
            Dim contentTypeId As String = Request.QueryString("ctype")

            If Not [String].IsNullOrEmpty(contentTypeId) Then
                If Not [String].IsNullOrEmpty(listGuid) Then
                    Me.MyAssociationParams.AssociationType = WorkflowAssociationType.ListContentTypeAssociation
                    Me.MyAssociationParams.TargetListGuid = New Guid(listGuid)
                Else
                    Me.MyAssociationParams.AssociationType = WorkflowAssociationType.SiteContentTypeAssociation
                End If
                Me.MyAssociationParams.ContentTypeId = New SPContentTypeId(contentTypeId)
            Else
                If Not [String].IsNullOrEmpty(listGuid) Then
                    Me.MyAssociationParams.AssociationType = WorkflowAssociationType.ListAssociation
                    Me.MyAssociationParams.TargetListGuid = New Guid(listGuid)
                Else
                    Me.MyAssociationParams.AssociationType = WorkflowAssociationType.WebAssociation
                End If
            End If
        End Sub

        Private Sub InitializeTaskListParams()
            Dim taskListParam As String = Request.Params("TaskList")

            If Me.MyAssociationParams.AssociationType = WorkflowAssociationType.SiteContentTypeAssociation Then
                Me.MyAssociationParams.TaskListName = taskListParam
            Else

                If taskListParam.StartsWith("z") Then
                    ' Create a new list if the value starts with 'z'
                    Me.MyAssociationParams.TaskListName = taskListParam.Substring(1)
                Else
                    ' Use existing list
                    Me.MyAssociationParams.TaskListGuid = New Guid(taskListParam)
                End If
            End If
        End Sub

        Private Sub InitializeHistoryListParams()
            Dim historyListParam As String = Request.Params("HistoryList")

            If Me.MyAssociationParams.AssociationType = WorkflowAssociationType.SiteContentTypeAssociation Then
                Me.MyAssociationParams.HistoryListName = historyListParam
            Else
                If historyListParam.StartsWith("z") Then
                    ' Create a new list if the value starts with 'z'
                    Me.MyAssociationParams.HistoryListName = historyListParam.Substring(1)
                Else
                    ' Use existing list
                    Me.MyAssociationParams.HistoryListGuid = New Guid(historyListParam)
                End If
            End If
        End Sub

        Private Function GetExistingAssociation() As SPWorkflowAssociation
            If Me.MyAssociationParams.AssociationGuid <> Guid.Empty Then
                Dim workflowAssociationCollection As SPWorkflowAssociationCollection
                Select Case Me.MyAssociationParams.AssociationType
                    Case WorkflowAssociationType.ListAssociation
                        workflowAssociationCollection = Web.Lists(Me.MyAssociationParams.TargetListGuid).WorkflowAssociations
                        Exit Select
                    Case WorkflowAssociationType.ListContentTypeAssociation
                        workflowAssociationCollection = Web.Lists(Me.MyAssociationParams.TargetListGuid).ContentTypes(Me.MyAssociationParams.ContentTypeId).WorkflowAssociations
                        Exit Select
                    Case WorkflowAssociationType.SiteContentTypeAssociation
                        workflowAssociationCollection = Web.ContentTypes(Me.MyAssociationParams.ContentTypeId).WorkflowAssociations
                        Exit Select
                    Case Else
                        workflowAssociationCollection = Web.WorkflowAssociations
                        Exit Select
                End Select
                Return workflowAssociationCollection(Me.MyAssociationParams.AssociationGuid)
            End If
            Return Nothing
        End Function

        Private Sub CreateTaskList()
            If Me.MyAssociationParams.TaskListGuid = Guid.Empty AndAlso Me.MyAssociationParams.AssociationType <> WorkflowAssociationType.SiteContentTypeAssociation Then
                Me.MyAssociationParams.TaskListGuid = CreateList(Me.MyAssociationParams.TaskListName, taskListDescription, SPListTemplateType.Tasks)
            End If
        End Sub

        Private Sub CreateHistoryList()
            If Me.MyAssociationParams.HistoryListGuid = Guid.Empty AndAlso Me.MyAssociationParams.AssociationType <> WorkflowAssociationType.SiteContentTypeAssociation Then
                Me.MyAssociationParams.HistoryListGuid = CreateList(Me.MyAssociationParams.HistoryListName, historyListDescription, SPListTemplateType.WorkflowHistory)
            End If
        End Sub

        Private Function CreateList(ByVal name As String, ByVal description As String, ByVal type As SPListTemplateType) As Guid
            Dim listName As String = name
            For i As Integer = 0 To CreateListTryCount
                If Web.Lists.TryGetList(listName) Is Nothing Then
                    Return Web.Lists.Add(listName, description, type)
                End If
                listName = [String].Concat(name, i.ToString(CultureInfo.InvariantCulture))
            Next
            Throw New Exception([String].Format(CultureInfo.CurrentCulture, listCreationFailed, name))
        End Function

        Private Sub HandleAssociateWorkflow()
            Select Case Me.MyAssociationParams.AssociationType
                Case WorkflowAssociationType.ListAssociation
                    AssociateListWorkflow()
                    Exit Select
                Case WorkflowAssociationType.WebAssociation
                    AssociateSiteWorkflow()
                    Exit Select
                Case WorkflowAssociationType.ListContentTypeAssociation
                    AssociateListContentTypeWorkflow()
                    Exit Select
                Case WorkflowAssociationType.SiteContentTypeAssociation
                    AssociateSiteContentTypeWorkflow()
                    Exit Select
            End Select
        End Sub

        Private Sub AssociateSiteContentTypeWorkflow()
            Dim contentType As SPContentType = Web.ContentTypes(Me.MyAssociationParams.ContentTypeId)
            Dim association As SPWorkflowAssociation
            If Me.MyAssociationParams.AssociationGuid = Guid.Empty Then
                association = SPWorkflowAssociation.CreateWebContentTypeAssociation(Web.WorkflowTemplates(New Guid(Me.MyAssociationParams.BaseTemplate)), Me.MyAssociationParams.AssociationName, Me.MyAssociationParams.TaskListName, Me.MyAssociationParams.HistoryListName)
                PopulateAssociationParams(association)
                contentType.WorkflowAssociations.Add(association)
            Else
                association = contentType.WorkflowAssociations(Me.MyAssociationParams.AssociationGuid)
                association.TaskListTitle = Me.MyAssociationParams.TaskListName
                association.HistoryListTitle = Me.MyAssociationParams.HistoryListName
                PopulateAssociationParams(association)
                contentType.WorkflowAssociations.Update(association)
            End If

            If Me.MyAssociationParams.ContentTypePushDown Then
                contentType.UpdateWorkflowAssociationsOnChildren(False)
            End If
        End Sub

        Private Sub AssociateListContentTypeWorkflow()
            Dim contentType As SPContentType = Web.Lists(Me.MyAssociationParams.TargetListGuid).ContentTypes(Me.MyAssociationParams.ContentTypeId)
            Dim association As SPWorkflowAssociation
            If Me.MyAssociationParams.AssociationGuid = Guid.Empty Then
                association = SPWorkflowAssociation.CreateListContentTypeAssociation(Web.WorkflowTemplates(New Guid(Me.MyAssociationParams.BaseTemplate)), Me.MyAssociationParams.AssociationName, Web.Lists(Me.MyAssociationParams.TaskListGuid), Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                contentType.WorkflowAssociations.Add(association)
            Else
                association = contentType.WorkflowAssociations(Me.MyAssociationParams.AssociationGuid)
                association.SetTaskList(Web.Lists(Me.MyAssociationParams.TaskListGuid))
                association.SetHistoryList(Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                contentType.WorkflowAssociations.Update(association)
            End If

            If Me.MyAssociationParams.ContentTypePushDown Then
                contentType.UpdateWorkflowAssociationsOnChildren(False)
            End If
        End Sub

        Private Sub AssociateListWorkflow()
            Dim targetList As SPList = Web.Lists(Me.MyAssociationParams.TargetListGuid)
            Dim association As SPWorkflowAssociation
            If Me.MyAssociationParams.AssociationGuid = Guid.Empty Then
                association = SPWorkflowAssociation.CreateListAssociation(Web.WorkflowTemplates(New Guid(Me.MyAssociationParams.BaseTemplate)), Me.MyAssociationParams.AssociationName, Web.Lists(Me.MyAssociationParams.TaskListGuid), Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                targetList.WorkflowAssociations.Add(association)
            Else
                association = targetList.WorkflowAssociations(Me.MyAssociationParams.AssociationGuid)
                association.SetTaskList(Web.Lists(Me.MyAssociationParams.TaskListGuid))
                association.SetHistoryList(Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                targetList.WorkflowAssociations.Update(association)
            End If

            SetDefaultContentApprovalWorkflow(targetList, association)
        End Sub

        Private Sub SetDefaultContentApprovalWorkflow(ByVal targetList As SPList, ByVal association As SPWorkflowAssociation)
            If targetList.EnableMinorVersions Then
                If targetList.DefaultContentApprovalWorkflowId <> association.Id AndAlso Me.MyAssociationParams.SetDefaultApprovalWorkflow Then
                    If Not targetList.EnableModeration Then
                        targetList.EnableModeration = True
                        targetList.DraftVersionVisibility = DraftVisibilityType.Approver
                    End If
                    targetList.DefaultContentApprovalWorkflowId = association.Id
                    targetList.Update()
                ElseIf targetList.DefaultContentApprovalWorkflowId = association.Id AndAlso Not Me.MyAssociationParams.SetDefaultApprovalWorkflow Then
                    targetList.DefaultContentApprovalWorkflowId = Guid.Empty
                    targetList.Update()
                End If
            End If
        End Sub

        Private Sub AssociateSiteWorkflow()
            If Me.MyAssociationParams.AssociationGuid = Guid.Empty Then
                Dim association As SPWorkflowAssociation = SPWorkflowAssociation.CreateWebAssociation(Web.WorkflowTemplates(New Guid(Me.MyAssociationParams.BaseTemplate)), Me.MyAssociationParams.AssociationName, Web.Lists(Me.MyAssociationParams.TaskListGuid), Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                Web.WorkflowAssociations.Add(association)
            Else
                Dim association As SPWorkflowAssociation = Web.WorkflowAssociations(Me.MyAssociationParams.AssociationGuid)
                association.SetTaskList(Web.Lists(Me.MyAssociationParams.TaskListGuid))
                association.SetHistoryList(Web.Lists(Me.MyAssociationParams.HistoryListGuid))
                PopulateAssociationParams(association)
                Web.WorkflowAssociations.Update(association)
            End If
        End Sub

        Private Sub PopulateAssociationParams(ByVal association As SPWorkflowAssociation)
            association.Name = Me.MyAssociationParams.AssociationName
            association.AutoStartCreate = Me.MyAssociationParams.AutoStartCreate
            association.AutoStartChange = Me.MyAssociationParams.AutoStartChange
            association.AllowManual = Me.MyAssociationParams.AllowManual
            association.LockItem = Me.MyAssociationParams.LockItem
            association.ContentTypePushDown = Me.MyAssociationParams.ContentTypePushDown

            If association.AllowManual Then
                association.PermissionsManual = SPBasePermissions.EmptyMask
                If Me.MyAssociationParams.RequireManagedListPermisions Then
                    association.PermissionsManual = association.PermissionsManual Or If((Me.MyAssociationParams.TargetListGuid <> Guid.Empty), SPBasePermissions.ManageLists, SPBasePermissions.ManageWeb)
                End If
            End If
            association.AssociationData = GetAssociationData()
        End Sub
#End Region

    End Class

End Namespace
