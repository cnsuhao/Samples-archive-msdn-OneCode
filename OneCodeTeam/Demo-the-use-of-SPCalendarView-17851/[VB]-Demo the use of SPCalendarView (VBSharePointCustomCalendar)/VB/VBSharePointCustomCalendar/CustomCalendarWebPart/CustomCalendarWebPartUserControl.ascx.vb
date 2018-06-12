'****************************** Module Header ******************************\
' Module Name:    CustomCalendarWebPartUserControl.ascx.cs
' Project:        VBSharePointCustomCalendar
' Copyright (c) Microsoft Corporation
'
' This sample demonstrates how to use SPCalendarView to develop a custom calendar
' in a visual web part. This is the WebPart. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint
Imports System.Text
Imports System.Data

Partial Public Class CustomCalendarWebPartUserControl
    Inherits UserControl

    ' Specifies the calendar for the add event. 
    Shared strListName As String = "calendar"

    Protected Overrides Sub CreateChildControls()
        MyBase.CreateChildControls()
        ' Current web
        Using web As SPWeb = SPContext.Current.Web
            ' List data
            Dim results As DataTable = GetQueryData(web)

            ' Calendar Item Collection
            Dim items As SPCalendarItemCollection = GetCalendarItems(web, results)

            spCalendarView.EnableViewState = True

            ' Calendar Type
            If Not String.IsNullOrEmpty(Page.Request("CalendarPeriod")) Then
                spCalendarView.ViewType = GetCalendarType(Page.Request("CalendarPeriod"))
            End If

            ' Bind the datasource to the SPCalendarView
            spCalendarView.DataSource = items
            spCalendarView.DataBind()

            ' Execute the specified method with Full Control rights even if the user does not have Full Control.
            SPSecurity.RunWithElevatedPrivileges(AddressOf ElevatedSaveCache)
        End Using
    End Sub

    ''' <summary>
    ''' Check if current user can add events and render content.
    ''' </summary>
    ''' <remarks></remarks>
    Sub ElevatedSaveCache()
        ' The flag whether the current user has AddListItems permissions.
        Dim blnCanAddEvents As Boolean = False

        Using web As SPWeb = SPContext.Current.Web
            Try
                Dim isHavePermissions As Boolean = web.DoesUserHavePermissions(SPBasePermissions.AddListItems)

                If isHavePermissions Then
                    blnCanAddEvents = True
                End If

            Catch
            End Try
        End Using

        ' Render header firstly:
        Dim sbHeader As New StringBuilder()
        sbHeader.AppendLine("<table align='center' width='100%' border='1' cellpadding='2' cellspacing='2'>")
        sbHeader.AppendLine("<tr><th align='center'>")
        sbHeader.AppendLine("<font color='#05C4D8' size='4'>My VB Custom Calendar</font>")
        sbHeader.AppendLine("</th></table>")
        Controls.Add(New LiteralControl(sbHeader.ToString()))

        ' Render calendar secondly:     
        Controls.Add(spCalendarView)

        ' Append Operation legend:
        Dim sbLegend As New StringBuilder()
        sbLegend.AppendLine("<table align='center' width='100%' border='0'>")
        sbLegend.AppendLine("<td width='50%' align='left' valign='top'>")
        sbLegend.AppendLine("<b><u>Operation:</u></b><br /><br />")
        If blnCanAddEvents Then
            sbLegend.AppendLine([String].Format("<li><a href=""/Lists/{0}/NewForm.aspx"">Add New Event</a></li>", strListName))
        End If
        sbLegend.AppendLine([String].Format("<li><a href=""/Lists/{0}/"">View the Full Calendar</a></li>", strListName))
        sbLegend.AppendLine("</td></table>")

        Controls.Add(New LiteralControl(sbLegend.ToString()))
    End Sub

    ''' <summary>
    ''' Gets the type of the calendar view.
    ''' </summary>
    ''' <param name="type">The type to be checked.</param>
    ''' <returns>Correct view type of calendar.</returns>
    Protected Shared Function GetCalendarType(ByVal type As String) As String
        If type Is Nothing Then
            type = String.Empty
        End If
        Select Case type.ToLower()
            Case "day"
                Return "day"
            Case "week"
                Return "week"
            Case "timeline"
                Return "timeline"
            Case Else
                Return "month"
        End Select
    End Function

    ''' <summary>
    ''' Executes the query against the web and returns 
    ''' results as DataTable.
    ''' </summary>
    ''' <param name="web">The web that is queried.</param>
    ''' <returns>Query results as DataTable.</returns>
    Private Function GetQueryData(ByVal web As SPWeb) As DataTable
        Dim query = New SPSiteDataQuery()

        query.Lists = "<Lists>" _
            & vbCr & vbLf & "<List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' />" _
            & vbCr & vbLf & "List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' />" _
            & vbCr & vbLf & "</Lists>"


        query.Query = "<Where>" _
            & vbCr & vbLf & "<Gt>" _
            & vbCr & vbLf & "<FieldRef Name='ID' />" _
            & vbCr & vbLf & "<Value Type='Number'>0</Value>" _
            & vbCr & vbLf & "</Gt>" _
            & vbCr & vbLf & "</Where>"

        query.Webs = "<Webs Scope='SiteCollection' />"
        query.ViewFields = "<FieldRef Name='Title' />"
        query.ViewFields += "<FieldRef Name='ID' />"
        query.ViewFields += "<FieldRef Name='EventDate' />"
        query.ViewFields += "<FieldRef Name='EndDate' />"
        query.ViewFields += "<FieldRef Name='Location' />"
        query.ViewFields += "<FieldRef Name='Description' />"
        query.ViewFields += "<FieldRef Name='fAllDayEvent' />"
        query.ViewFields += "<FieldRef Name='fRecurrence' />"
        query.RowLimit = 100

        Return web.GetSiteData(query)
    End Function

    ''' <summary> 
    ''' Gets the collection of calendar items based on site 
    ''' data query results.
    ''' </summary>
    ''' <param name="web">The web that was queried.</param>
    ''' <param name="results">The results of query.</param>
    ''' <returns>Collection of calendar items accepted by 
    ''' calendar component</returns>        
    Private Function GetCalendarItems(ByVal web As SPWeb, ByVal results As DataTable) As SPCalendarItemCollection
        ' Create a new collection for the calendar items
        Dim items = New SPCalendarItemCollection()

        ' SPCalendar Item
        Dim item As SPCalendarItem = Nothing

        ' Loop results to get Calendar Item Information
        For Each row As DataRow In results.Rows
            ' List Guid
            Dim listGuid = New Guid(TryCast(row("ListId"), String))
            ' List
            Dim list = web.Lists(listGuid)

            item = New SPCalendarItem()

            For Each form As SPForm In list.Forms
                ' Display Form Url
                If form.Type = PAGETYPE.PAGE_DISPLAYFORM Then
                    item.DisplayFormUrl = form.ServerRelativeUrl
                    Exit For
                End If
            Next

            item.ItemID = TryCast(row("ID"), String)
            item.StartDate = DateTime.Parse(TryCast(row("EventDate"), String))
            item.EndDate = DateTime.Parse(TryCast(row("EndDate"), String))
            item.hasEndDate = True
            item.Title = TryCast(row("Title"), String)
            item.Location = TryCast(row("Location"), String)
            item.Description = TryCast(row("Description"), String)
            item.IsAllDayEvent = (Integer.Parse(TryCast(row("fAllDayEvent"), String)) <> 0)
            item.IsRecurrence = (Integer.Parse(TryCast(row("fRecurrence"), String)) <> 0)
            item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)

            items.Add(item)
        Next

        ' This is an item with a start and end date. 
        ' Add the first dummy item
        item = New SPCalendarItem()

        item.ItemID = "Select"
        item.Title = "First calendar item"
        item.StartDate = DateTime.Now
        item.EndDate = DateTime.Now.AddHours(1)
        item.hasEndDate = True
        item.DisplayFormUrl = "/News"
        item.Location = "USA"
        item.Description = "This is the first test item in the calendar rollup"
        item.IsAllDayEvent = False
        item.IsRecurrence = False
        item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
        items.Add(item)

        ' Add the second item. This is an all day event.
        item = New SPCalendarItem()

        item.StartDate = DateTime.Now.AddDays(-1)
        item.hasEndDate = True
        item.Title = "Second calendar item"
        item.DisplayFormUrl = "/News"
        item.Location = "India"
        item.Description = "This is the second test item in the calendar rollup"
        item.IsAllDayEvent = True
        item.IsRecurrence = False
        item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
        items.Add(item)

        Return items
    End Function

End Class
