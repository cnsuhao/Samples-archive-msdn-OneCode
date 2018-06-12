========================================================================
               VBASPNETGloablizationInAssembly Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to access resource files that has compiled in 
class library or dll file. So we can not use GetGlobalResourceObject function
to get it, here we give an effective way to get specific resources from
compiled file and then apply resource value in whole application.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBASPNETGloablizationInAssembly.sln.

Step 2: Expand the VBASPNETGloablizationInAssembly web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You can see a normal web page in browser, the content of page depend
        on the current request culture.

Step 4: At the end of default page, there is a DropDownList control. You can
        select the specific language you want.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBASPNETGloablizationInAssembly".

Step 2. Add one web form in the root directory, name them as "Default.aspx".

Step 3. Create a class library project in solution, the new class library is
        used to provide resource files for web application. Name it as 
		"VBASPNETGloablizationInAssemblyResource".

Step 4. Add some resource files in VBASPNETGloablizationInAssemblyResource.
        such as LanguageResource.resx, LanguageResource.fr-fr.resx. The language
		code need embed in resource name.
		
Step 5  Please add the fields and values in resource files, such as Title, Author,
        Content, Link, etc. Remember put different languages content in related 
		resource file.
        [Note]
		Please refer to sample's resource files for customizing your resources.
		[/Note]

Step 6. In default web page, you must get the information of resource files, and
        display them. The code as shown below:
		[code]
    ''' <summary>
    ''' This project class is used to access resource files from class 
    ''' library, and render the correct content with current culture.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class _Default
    Inherits System.Web.UI.Page
    Public strContent As String = String.Empty
    Public strUrl As String = String.Empty
    Public strLink As String = String.Empty
    Const strBaseName As String = "VBASPNETGloablizationInAssemblyResource.LanguageResource"

    ' Get ResourceManager instance by assembly resource type.
    Private manager As New ResourceManager(strBaseName, GetType(LanguageResource).Assembly)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim culture As New CultureInfo(Context.Request.UserLanguages(0))

            Dim strTitle As String = manager.GetString("Title", culture)
            Dim strAuthor As String = manager.GetString("Author", culture)
            Me.strContent = manager.GetString("Content", culture)
            Me.strUrl = manager.GetString("Url", culture)
            Me.strLink = manager.GetString("Link", culture)
            lbTitle.Text = strTitle
            lbAuthor.Text = strAuthor
            Dim flag As Boolean = False
            For i As Integer = 0 To ddlLanguage.Items.Count - 1
                If ddlLanguage.Items(i).Value = culture.Name.ToLower() Then
                    flag = True
                End If
            Next
            If flag Then
                ddlLanguage.SelectedValue = culture.Name.ToLower()
            Else
                ddlLanguage.SelectedIndex = 0
            End If

        End If

    End Sub
    ''' <summary>
    ''' Add built-in language items of DropDownList control.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        ddlLanguage.Items.Add(New ListItem("United State", "en-us"))
        ddlLanguage.Items.Add(New ListItem("France", "fr-fr"))
        ddlLanguage.Items.Add(New ListItem("中国", "zh-cn"))
    End Sub

    ''' <summary>
    ''' Change page culture and content by DropDownList SelectedValue.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ddlLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim languageCode As String = ddlLanguage.SelectedValue
        Dim currentCulture As CultureInfo = Me.GetLanguageSpecifically(languageCode)
        lbTitle.Text = manager.GetString("Title", currentCulture)
        lbAuthor.Text = manager.GetString("Author", currentCulture)
        Me.strContent = manager.GetString("Content", currentCulture)
        Me.strLink = manager.GetString("Link", currentCulture)
        Me.strUrl = manager.GetString("Url", currentCulture)
    End Sub

    Public Function GetLanguageSpecifically(ByVal languageCode As String) As CultureInfo
        Dim culture As New CultureInfo(languageCode)
        Return culture
    End Function

    End Class
		[/code]

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ResourceManager Class
http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx

MSDN: Assembly Class
http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx

MSDN: CultureInfo Class
http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx
/////////////////////////////////////////////////////////////////////////////