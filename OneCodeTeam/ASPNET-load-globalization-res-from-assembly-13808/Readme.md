# ASP.NET load globalization res from assembly (VBASPNETGloablizationInAssembly)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Globalization
* Resources
## IsPublished
* True
## ModifiedDate
* 2011-10-30 08:40:49
## Description

<h1>VBASPNETGloablizationInAssembly Overview</h1>
<h2><span>Summary</span></h2>
<div>The code sample demonstrates loading embeded resources in an assembly based on the culture information, and use it to globalize the entire ASP.NET website.&nbsp; You will learn how to access resource files that has compiled in class library or dll file
 in ASP.NET. We give an effective way to get specific resources from compiled file and then apply resource value in whole application.</div>
<h2>Demo</h2>
<div>Step 1: Open the VBASPNETGloablizationInAssembly.sln.</div>
<div>Step 2: Expand the VBASPNETGloablizationInAssembly web application and press Ctrl &#43; F5 to show the Default.aspx.</div>
<div>Step 3: You can see a normal web page in browser, the content of page depend on the current request culture.</div>
<div>Step 4: At the end of default page, there is a DropDownList control. You can select the specific language you want.</div>
<h2>Implementation</h2>
<div>Step 1. Create a&nbsp;VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;VBASPNETGloablizationInAssembly&quot;.</div>
<div>Step 2. Add one web form in the root directory, name them as &quot;Default.aspx&quot;.</div>
<div>Step 3. Create a class library project in solution, the new class library is used to provide resource files for web application. Name it as &quot;VBASPNETGloablizationInAssemblyResource&quot;.</div>
<div>Step 4. Add some resource files in VBASPNETGloablizationInAssemblyResource. such as LanguageResource.resx, LanguageResource.fr-fr.resx. The language code need embed in resource name.
<br>
Step 5&nbsp; Please add the fields and values in resource files, such as Title, Author, Content, Link, etc. Remember put different languages&nbsp; content in related resource file.<br>
&nbsp; [Note]<br>
&nbsp; Please refer to sample's resource files for customizing your resources.<br>
&nbsp; [/Note]</div>
<div>Step 6. In default web page, you must get the information of resource files, and display them. The code as shown below:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    ''' &lt;summary&gt;
    ''' This project class is used to access resource files from class 
    ''' library, and render the correct content with current culture.
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Public Class _Default
    Inherits System.Web.UI.Page
    Public strContent As String = String.Empty
    Public strUrl As String = String.Empty
    Public strLink As String = String.Empty
    Const strBaseName As String = &quot;VBASPNETGloablizationInAssemblyResource.LanguageResource&quot;

    ' Get ResourceManager instance by assembly resource type.
    Private manager As New ResourceManager(strBaseName, GetType(LanguageResource).Assembly)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim culture As New CultureInfo(Context.Request.UserLanguages(0))

            Dim strTitle As String = manager.GetString(&quot;Title&quot;, culture)
            Dim strAuthor As String = manager.GetString(&quot;Author&quot;, culture)
            Me.strContent = manager.GetString(&quot;Content&quot;, culture)
            Me.strUrl = manager.GetString(&quot;Url&quot;, culture)
            Me.strLink = manager.GetString(&quot;Link&quot;, culture)
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
    ''' &lt;summary&gt;
    ''' Add built-in language items of DropDownList control.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        ddlLanguage.Items.Add(New ListItem(&quot;United State&quot;, &quot;en-us&quot;))
        ddlLanguage.Items.Add(New ListItem(&quot;France&quot;, &quot;fr-fr&quot;))
        ddlLanguage.Items.Add(New ListItem(&quot;中国&quot;, &quot;zh-cn&quot;))
    End Sub

    ''' &lt;summary&gt;
    ''' Change page culture and content by DropDownList SelectedValue.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Protected Sub ddlLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim languageCode As String = ddlLanguage.SelectedValue
        Dim currentCulture As CultureInfo = Me.GetLanguageSpecifically(languageCode)
        lbTitle.Text = manager.GetString(&quot;Title&quot;, currentCulture)
        lbAuthor.Text = manager.GetString(&quot;Author&quot;, currentCulture)
        Me.strContent = manager.GetString(&quot;Content&quot;, currentCulture)
        Me.strLink = manager.GetString(&quot;Link&quot;, currentCulture)
        Me.strUrl = manager.GetString(&quot;Url&quot;, currentCulture)
    End Sub

    Public Function GetLanguageSpecifically(ByVal languageCode As String) As CultureInfo
        Dim culture As New CultureInfo(languageCode)
        Return culture
    End Function

    End Class</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;project&nbsp;class&nbsp;is&nbsp;used&nbsp;to&nbsp;access&nbsp;resource&nbsp;files&nbsp;from&nbsp;class&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;library,&nbsp;and&nbsp;render&nbsp;the&nbsp;correct&nbsp;content&nbsp;with&nbsp;current&nbsp;culture.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;_Default&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;strContent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;strUrl&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;strLink&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;strBaseName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;VBASPNETGloablizationInAssemblyResource.LanguageResource&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Get&nbsp;ResourceManager&nbsp;instance&nbsp;by&nbsp;assembly&nbsp;resource&nbsp;type.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;manager&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ResourceManager(strBaseName,&nbsp;<span class="visualBasic__keyword">GetType</span>(LanguageResource).Assembly)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Page_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Page.IsPostBack&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;culture&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CultureInfo(Context.Request.UserLanguages(<span class="visualBasic__number">0</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strTitle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Title&quot;</span>,&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strAuthor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Author&quot;</span>,&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strContent&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Content&quot;</span>,&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strUrl&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Url&quot;</span>,&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strLink&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Link&quot;</span>,&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbTitle.Text&nbsp;=&nbsp;strTitle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbAuthor.Text&nbsp;=&nbsp;strAuthor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;ddlLanguage.Items.Count&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ddlLanguage.Items(i).Value&nbsp;=&nbsp;culture.Name.ToLower()&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.SelectedValue&nbsp;=&nbsp;culture.Name.ToLower()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.SelectedIndex&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Add&nbsp;built-in&nbsp;language&nbsp;items&nbsp;of&nbsp;DropDownList&nbsp;control.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnInit(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnInit(e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="visualBasic__keyword">New</span>&nbsp;ListItem(<span class="visualBasic__string">&quot;United&nbsp;State&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;en-us&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="visualBasic__keyword">New</span>&nbsp;ListItem(<span class="visualBasic__string">&quot;France&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;fr-fr&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="visualBasic__keyword">New</span>&nbsp;ListItem(<span class="visualBasic__string">&quot;中国&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;zh-cn&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Change&nbsp;page&nbsp;culture&nbsp;and&nbsp;content&nbsp;by&nbsp;DropDownList&nbsp;SelectedValue.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ddlLanguage_SelectedIndexChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;languageCode&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;ddlLanguage.SelectedValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;currentCulture&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;CultureInfo&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.GetLanguageSpecifically(languageCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbTitle.Text&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Title&quot;</span>,&nbsp;currentCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbAuthor.Text&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Author&quot;</span>,&nbsp;currentCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strContent&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Content&quot;</span>,&nbsp;currentCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strLink&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Link&quot;</span>,&nbsp;currentCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.strUrl&nbsp;=&nbsp;manager.GetString(<span class="visualBasic__string">&quot;Url&quot;</span>,&nbsp;currentCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetLanguageSpecifically(<span class="visualBasic__keyword">ByVal</span>&nbsp;languageCode&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;CultureInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;culture&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CultureInfo(languageCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;culture&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</div>
<div>Step 7. Build the application and you can debug it.</div>
<div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">References</h2>
<div class="endscriptcode">
<p>MSDN: ResourceManager Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx">http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx</a></p>
<p>MSDN: Assembly Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx">http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx</a></p>
<p>MSDN: CultureInfo Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx">http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx</a></p>
</div>
<div class="endscriptcode"><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
</div>
