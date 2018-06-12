'****************************** Module Header ******************************\
'Module Name:  MessageBoxCore.vb
'Project:      VBASPNETIntelligentErrorPage
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to create a MessageBox in asp.net, usually we
'often use JavaScript functions "alert()" or "confirm()" to show simple messages
'and make a simple choice with customers, but these dialog boxes is very simple,
'we can not add any different and complicate controls, images or styles. As we know,
'good web sites always have their own web styles, such as typeface and colors, 
'and in this situation, JavaScript dialog boxes looks not very well. So this sample
'shows how to make an Asp.net MessageBox.
'
'The MessageBox class includes basic properties and events. The Show() method generates
'all html code by class   properties.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class MessageBox
    Public Property MessageText() As String
        Get
            Return m_MessageText
        End Get
        Set(ByVal value As String)
            m_MessageText = value
        End Set
    End Property
    Private m_MessageText As String

    Public Property MessageTitle() As String
        Get
            Return m_MessageTitle
        End Get
        Set(ByVal value As String)
            m_MessageTitle = value
        End Set
    End Property
    Private m_MessageTitle As String

    Public Property MessageIcons() As MessageBoxIcons
        Get
            Return m_MessageIcons
        End Get
        Set(ByVal value As MessageBoxIcons)
            m_MessageIcons = value
        End Set
    End Property
    Private m_MessageIcons As MessageBoxIcons

    Public Property MessageButtons() As MessageBoxButtons
        Get
            Return m_MessageButtons
        End Get
        Set(ByVal value As MessageBoxButtons)
            m_MessageButtons = value
        End Set
    End Property
    Private m_MessageButtons As MessageBoxButtons

    Public Property MessageStyles() As MessageBoxStyle
        Get
            Return m_MessageStyles
        End Get
        Set(ByVal value As MessageBoxStyle)
            m_MessageStyles = value
        End Set
    End Property
    Private m_MessageStyles As MessageBoxStyle

    Public SuccessEvent As New List(Of String)()

    Public FailedEvent As New List(Of String)()

    ''' <summary>
    ''' Define an Asp.net MessageBox instance.
    ''' </summary>
    Public Sub New()
        Me.MessageIcons = MessageBoxIcons.System
        Me.MessageButtons = MessageBoxButtons.Ok
        Me.MessageStyles = MessageBoxStyle.StyleA
    End Sub

    ''' <summary>
    ''' Define an Asp.net MessageBox instance.
    ''' </summary>
    ''' <param name="text">Message Box text property.</param>
    Public Sub New(ByVal text As String)
        Me.MessageText = text
        Me.MessageIcons = MessageBoxIcons.System
        Me.MessageButtons = MessageBoxButtons.Ok
        Me.MessageStyles = MessageBoxStyle.StyleA
    End Sub

    ''' <summary>
    ''' Define an Asp.net MessageBox instance.
    ''' </summary>
    ''' <param name="text">MessageBox text property.</param>
    ''' <param name="title">MessageBox title property.</param>
    Public Sub New(ByVal text As String, ByVal title As String)
        Me.MessageText = text
        Me.MessageTitle = title
        Me.MessageIcons = MessageBoxIcons.System
        Me.MessageButtons = MessageBoxButtons.Ok
        Me.MessageStyles = MessageBoxStyle.StyleA
    End Sub

    ''' <summary>
    ''' Define an Asp.net MessageBox instance.
    ''' </summary>  
    ''' <param name="text">MessageBox text property.</param>
    ''' <param name="title">MessageBox title property.</param>
    ''' <param name="icons">MessageBox icon property.</param>
    ''' <param name="buttons">MessageBox button style.</param>
    Public Sub New(ByVal text As String, ByVal title As String, ByVal icons As MessageBoxIcons, ByVal buttons As MessageBoxButtons, ByVal styles As MessageBoxStyle)
        Me.MessageText = text
        Me.MessageTitle = title
        Me.MessageIcons = icons
        Me.MessageButtons = buttons
        Me.MessageStyles = styles
    End Sub

    Public Function Show(ByVal sender As Object) As String
        Dim iconUrl As String = String.Empty
        Dim buttonStyle As String = String.Empty
        Dim buttonHTML As String = String.Empty
        Dim scriptHTML As String = String.Empty
        Dim coreHTML As String = String.Empty
        Dim builder As New StringBuilder()
        Select Case Me.MessageIcons
            Case MessageBoxIcons.None
                iconUrl = String.Empty
                Exit Select
            Case MessageBoxIcons.Warnning
                iconUrl = "<img src ='../Images/1.jpg' />"
                Exit Select
            Case MessageBoxIcons.[Error]
                iconUrl = "<img src ='../Images/2.jpg' />"
                Exit Select
            Case MessageBoxIcons.Question
                iconUrl = "<img src ='../Images/3.jpg' />"
                Exit Select
            Case MessageBoxIcons.System
                iconUrl = "<img src ='../Images/4.jpg' />"
                Exit Select
        End Select
        Select Case Me.MessageStyles
            Case MessageBoxStyle.StyleA
                buttonStyle = "button_classA"
                Exit Select
            Case MessageBoxStyle.StyleB
                buttonStyle = "button_classB"
                Exit Select
        End Select
        Select Case Me.MessageButtons
            Case MessageBoxButtons.Ok
                buttonHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonHTML = [String].Format(buttonHTML, "OK", buttonStyle, "Yes();")
                builder.Append(buttonHTML)
                Exit Select
            Case MessageBoxButtons.OKCancel
                Dim buttonOKHTML As String = String.Empty
                Dim buttonCancelHTML As String = String.Empty
                buttonOKHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonOKHTML = [String].Format(buttonOKHTML, "OK", buttonStyle, "Yes();")
                builder.Append(buttonOKHTML)
                builder.Append("&nbsp;&nbsp;&nbsp;")
                buttonCancelHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonCancelHTML = [String].Format(buttonCancelHTML, "Cancel", buttonStyle, "No();")
                builder.Append(buttonCancelHTML)
                Exit Select
            Case MessageBoxButtons.YesOrNo
                Dim buttonYesHTML As String = String.Empty
                Dim buttonNoHTML As String = String.Empty
                buttonYesHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonYesHTML = [String].Format(buttonYesHTML, "Yes", buttonStyle, "Yes();")
                builder.Append(buttonYesHTML)
                builder.Append("&nbsp;&nbsp;&nbsp;")
                buttonNoHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonNoHTML = [String].Format(buttonNoHTML, "No", buttonStyle, "No();")
                builder.Append(buttonNoHTML)
                Exit Select
            Case MessageBoxButtons.YesNoCancel
                Dim buttonYesCHTML As String = String.Empty
                Dim buttonNoCHTML As String = String.Empty
                Dim buttonCancelCHTML As String = String.Empty
                buttonYesCHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonYesCHTML = [String].Format(buttonYesCHTML, "Yes", buttonStyle, "Yes();")
                builder.Append(buttonYesCHTML)
                builder.Append("&nbsp;&nbsp;&nbsp;")
                buttonNoCHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonNoCHTML = [String].Format(buttonNoCHTML, "No", buttonStyle, "No();")
                builder.Append(buttonNoCHTML)
                builder.Append("&nbsp;&nbsp;&nbsp;")
                buttonCancelCHTML = MessageBoxCore.MessageBoxButtonHtml
                buttonCancelCHTML = [String].Format(buttonCancelCHTML, "Cancel", buttonStyle, "No();")
                builder.Append(buttonCancelCHTML)
                Exit Select
        End Select
        Dim successName As String = String.Empty
        Dim failedName As String = "1"
        Dim successBuilder As New StringBuilder()
        Dim failedBuilder As New StringBuilder()
        If SuccessEvent IsNot Nothing AndAlso SuccessEvent.Count <> 0 Then
            Dim eventCounts As Integer = SuccessEvent.Count
            For i As Integer = 0 To eventCounts - 1
                successBuilder.Append("PageMethods.")
                successBuilder.Append(SuccessEvent(i).ToString())
                successBuilder.Append("(null,null,Success, Failed);")
            Next
            successName = successBuilder.ToString()
        End If
        If FailedEvent IsNot Nothing AndAlso FailedEvent.Count <> 0 Then
            Dim eventCounts As Integer = FailedEvent.Count
            For i As Integer = 0 To eventCounts - 1
                failedBuilder.Append("PageMethods.")
                failedBuilder.Append(FailedEvent(i).ToString())
                failedBuilder.Append("(null,null,Success, Failed);")
            Next
            failedName = failedBuilder.ToString()
        End If
        scriptHTML = MessageBoxCore.MessageBoxScript
        scriptHTML = [String].Format(scriptHTML, successName, failedName)
        coreHTML = MessageBoxCore.MessageBoxHTML
        coreHTML = [String].Format(coreHTML, Me.MessageTitle, iconUrl, Me.MessageText, builder.ToString())
        TryCast(sender, Page).ClientScript.RegisterClientScriptBlock(sender.[GetType](), "_arg", scriptHTML, True)
        Return coreHTML
    End Function

    Public Enum MessageBoxButtons
        Ok
        OKCancel
        YesOrNo
        YesNoCancel
    End Enum

    Public Enum MessageBoxIcons
        None
        Warnning
        Question
        System
        [Error]
    End Enum

    Public Enum MessageBoxStyle
        StyleA
        StyleB
    End Enum
End Class
