========================================================================
              VBASPNETDisplayDataStreamResource Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to display the data stream from Internet resource
and site resource in a web page. Customers want to know how to display the 
title, content or other information of web pages. Thus, the sample can search
the target web page which you input url address in TextBox control and get all
relative link resources of it. 

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBASPNETDisplayDataStreamResource.sln.

Step 2: Expand the VBASPNETDisplayDataStreamResource web application and press 
        Ctrl + F5 to show the DisplayResource.aspx.

Step 3: You will see a TextBox and a Button on SearchEngine.aspx page. The TextBox
        is used to input target page's url address and find the link resources of
		web page.

Step 4: If the url links like "#", the application replace it as source page url, 
        and url routing links, such as "/duty/", web application can combine source 
		page url and url routing name to a complete url automatically.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "ASP.NET Empty Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBASPNETDisplayDataStreamResource".

Step 2. Add an ASP.NET folder named "App_Code", and this folder is used to store class
        files. In this sample code, we create two class files in it, one of them is 
		"RegexMethod", the other is "WebPageEntity".

Step 3. Add a web form page named "DisplayResource.aspx", this page is used to retrieve
        page resource and find relative page by key words. The main VB code will be
		like this:
		[code]
    Private webResources As WebPageEntity
    Public publicTable As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

 ''' <summary>
    ''' The method is used to load resource by specific web pages.
    ''' </summary>
    Public Sub LoadLink(ByVal url As String)
        Dim method As New RegexMethod()
        webResources = New WebPageEntity()
        SyncLock Me
            Dim result As String = Me.LoadResource(url)
            Dim webEntity As New WebPageEntity()
            webEntity.Name = Path.GetFileName(url)
            webEntity.Link = method.GetLinks(result, url)
            webEntity.Content = result
            webResources = webEntity
        End SyncLock
        Dim builder As New StringBuilder()
        builder.Append("<table>")
        For i As Integer = 0 To webResources.Link.Count - 1
            builder.Append("<tr><td><a href='" & webResources.Link(i).ToString() & "'>")
            builder.Append(webResources.Link(i).ToString())
            builder.Append("</a></td></tr>")
        Next
        builder.Append("</table>")
        publicTable = builder.ToString()
    End Sub

    ''' <summary>
    ''' Use HttpWebRequest, HttpWebResponse, StreamReader for retrieving
    ''' information of pages, and calling Regex methods to get useful 
    ''' information.
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    Public Function LoadResource(ByVal url As String) As String
        Dim webResponse As HttpWebResponse = Nothing
        Dim reader As StreamReader = Nothing
        Try
            Dim webRequest__1 As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            webRequest__1.Timeout = 30000
            webResponse = DirectCast(webRequest__1.GetResponse(), HttpWebResponse)
            Dim resource As String = [String].Empty
            If webResponse Is Nothing Then
                Return String.Empty
            ElseIf webResponse.StatusCode <> HttpStatusCode.OK Then
                Return String.Empty
            Else
                reader = New StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"))
                resource = reader.ReadToEnd()
                Return resource
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            If webResponse IsNot Nothing Then
                webResponse.Close()
            End If
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' The search button click event is used to compare key words and 
    ''' page resources for selecting relative pages. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnSearchPage_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tbKeyWord.Text.Trim() <> String.Empty Then
            If RegexMethod.IsUrl(tbKeyWord.Text.Trim()) Then
                Me.LoadLink(tbKeyWord.Text.Trim())
            Else
                Response.Write("Url address is not valid")
            End If
        Else
            Response.Write("Url address can not be null.")
        End If
	   [/code]

Step 5. The RegexMethod class provides two methods to extract specific information
        from pages.
	   [code]
        Dim links As New List(Of String)()
        Dim strRegexLink As String = "(?is)<a .*?>"
        Dim matchList As MatchCollection = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase)
        Dim strbLinkList As New StringBuilder()

        For Each matchSingleLink As Match In matchList
            Dim matchLink As String = "<a[^>]*?href=(['""\s]?)([^'""\s]+)\1[^>]*?>"
            Dim match As Match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase)
            If match.Groups(2).Value = "#" Then
                links.Add(url)
            ElseIf Not match.Groups(2).Value.ToLower().Contains("http://") Then
                links.Add(url + match.Groups(2).Value)
            Else
                links.Add(match.Groups(2).Value)
            End If
        Next
        Return links
    End Function

    Public Shared Function IsUrl(ByVal source As String) As Boolean

        Return Regex.IsMatch(source, "^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|
		(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))
		(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase)
    End Function
       [/code]  

Step 6. The WebPageEntity class file is used to store web page resource, 
        and binding them as the data source of GridView control.
	   [code]
    <Serializable()> _
    Public Class WebPageEntity
        ''' <summary>
        ''' web page entity class, contain page's basic information,
        ''' such as name, content, link, title, body text.
        ''' </summary>
        Public Property Name As String
        Public Property Content As String
        Public Property Link As List(Of String)
    End Class
	   [/code]

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: HttpWebRequest Class
http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx

MSDN: HttpWebResponse Class
http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse.aspx

MSDN: .NET Framework Regular Expressions
http://msdn.microsoft.com/en-us/library/hs600312.aspx

MSDN: StreamReader Class
http://msdn.microsoft.com/en-us/library/system.io.streamreader.aspx

MSDN: List<T>.Contains Method 
http://msdn.microsoft.com/en-us/library/bhkz42b3.aspx
/////////////////////////////////////////////////////////////////////////////