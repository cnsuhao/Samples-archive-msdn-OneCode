'*****************************' Module Header ******************************\
' Module Name:    Program.vb
' Project:        VBSharePointRemovePermissionLevel
' Copyright (c) Microsoft Corporation
'
' This sample code demonstrates how to programmatically remove specific 
' permission level from group in SharePoint 2010. Generally, we can remove 
' a specific permission level by removing the group’s role assignments from 
' the target web, list, or item.  Also, this sample also shows you how to 
' assign specific permission level to the group.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Microsoft.SharePoint

Public Class Program

    Shared Sub Main()
        ' Connect to SharePoint Site
        Dim siteUrl As String = "http://win-2ed380lbo8e/"

        ' Group Title
        Dim groupTitle As String = "test123"

        ' Remove a specific permission level from a group.
        SetPermissionsToGroup(siteUrl, groupTitle)
    End Sub

    ''' <summary>
    ''' To remove a specific permission level, you have to remove the role assignments from a group.
    ''' The various definitions, such as Contribute and Full Control 
    ''' can be fetched from the [SPWeb].RoleDefinitions collection. Example:
    ''' Administrator>>Full  Control WebDesigner>>Design  Contributor>>Contribute
    ''' Reader>>Read  Guest>>Limited Access  None>>View Only
    ''' </summary>
    ''' <param name="siteUrl">Site Url</param>
    ''' <param name="groupTitle">Group title</param>
    ''' <remarks></remarks>
    Shared Sub SetPermissionsToGroup(ByVal siteUrl As String, ByVal groupTitle As String)

        Using site = New SPSite(siteUrl)
            ' Connect to SharePoint Site
            Using web = site.OpenWeb()

                ' Get group and group roles 
                Dim group = web.SiteGroups(groupTitle)
                Dim roles = web.RoleAssignments.GetAssignmentByPrincipal(group)

                ' method 1. 

                ' Remove contribute role
                ' Get the SPRoleDefinition
                Dim sprd As SPRoleDefinition = web.RoleDefinitions.GetByType(SPRoleType.Contributor)

                ' Remove the SPRoleDefinition
                roles.RoleDefinitionBindings.Remove(sprd)

                ' Updates the Role Assignment
                roles.Update()

                ''Add contribute role 
                'roles.RoleDefinitionBindings.Add(web.RoleDefinitions("Contribute"))
                'roles.Update()

                ' [-or-]

                ' method 2. 

                ''Remove Read role 
                'roles.RoleDefinitionBindings.Remove(web.RoleDefinitions("Read"))
                'roles.Update()

                ''Add Read role 
                'roles.RoleDefinitionBindings.Add(web.RoleDefinitions.GetByType(SPRoleType.Reader))
                'roles.Update()

            End Using
        End Using

    End Sub

End Class

