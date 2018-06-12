# Add element under head tag (VBSharePointAddElementToHeadTag)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Head
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:45:13
## Description

<h1>How to add element under head Tag (VBSharePointAddElementToHeadTag)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The VBSharePointAddElementToHeadTag sample demonstrates how to add or modify element of the html head Tag. In the use of master pages, some users may want to customize title, Meta, or other head tags for each page. After walking through this
 simple demonstration, you can operate the other tags easily. </span></p>
<h2>Running the Sample </h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 1: Open the VBSharePointAddElementToHeadTag.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the solution then run &quot;Deploy&quot;. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: Under the &quot;Site Setting&quot; node of your site, you may find a new setting group named &quot;Custom Site Administration&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62011/1/image.png" alt="" width="326" height="107" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: Click the &quot;Set Meta&quot; link. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62012/1/image.png" alt="" width="303" height="288" align="middle">
</span><span style=""><span style="">&nbsp;</span><br>
Step 5: Enter keywords and description for your site's or specified page. Then click the &quot;Set Meta&quot; button or &quot;Set Default Meta&quot; button to save.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62013/1/image.png" alt="" width="276" height="138" align="middle">
<img src="/site/view/file/62014/1/image.png" alt="" width="283" height="111" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 6: Open any page to view source. <span style=""></span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For the </span><span style="">specified page (e.g. test1.aspx), you will see:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62015/1/image.png" alt="" width="748" height="92" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For the </span><span style="">common page (e.g. Home.aspx), you will:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62016/1/image.png" alt="" width="726" height="62" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Click the &quot;Clear Custom Meta&quot; page link. After clicking the button, then open any page to view source again (e.g. test1.aspx).
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62017/1/image.png" alt="" width="541" height="81" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010. Name it as &quot;VBSharePointAddElementToHeadTag&quot;. In the SharePoint Customization Wizard, choose Deploy as a farm solution. Click Finish.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the project to add the desired folder. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&quot;Add SharePoint Mapped Folder&quot; &gt;&gt; &quot;TEMPLATE&quot; &gt;&gt;&quot;ControlTemplates&quot;. Then add &quot;SharePoint Layouts Mapped Folder&quot;.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add two &quot;Empty Element&quot; name them to &quot;SiteSettingsPageLinks&quot; and &quot;Controls&quot;. SiteSettingsPageLinks is used to custom Ribbon.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Right-click the &quot;ControlTemplates&quot; folder then add a new folder named &quot;AddElementToHeadTag&quot;, then add a User Control named &quot;HeadInTag.ascx&quot;. The User Control is
</span>used to render the custom Meta information.<span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub Render(writer As HtmlTextWriter)
           'The default keyword
           Dim keyword As String = TryCast(SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaKey&quot;), String)
           'The default description
           Dim description As String = TryCast(SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaDescription&quot;), String)
           'Get current page.
           Dim file As SPFile = SPContext.Current.File


           'If the page does not exist or no special settings, use the default settings.
           'If the page exists and the existence of the specified configuration, using the specified configuration
           If file IsNot Nothing Then
               If file.Exists Then
                   Dim fileName As String = file.Name
                   Dim strCurrentPageKeyword As String = TryCast(SPContext.Current.Web.GetProperty(fileName & &quot;-CustomMetaKey&quot;), String)
                   Dim strCurrentPageDescription As String = TryCast(SPContext.Current.Web.GetProperty(fileName & &quot;-CustomMetaDescription&quot;), String)


                   If Not String.IsNullOrEmpty(strCurrentPageKeyword) Then
                       keyword = strCurrentPageKeyword
                   End If
                   If Not String.IsNullOrEmpty(strCurrentPageDescription) Then
                       description = strCurrentPageDescription
                   End If
               End If
           End If


           'Output the value
           writer.Write([String].Format(CultureInfo.CurrentCulture, &quot;&lt;meta name=&quot;&quot;description&quot;&quot; content=&quot;&quot;{0}&quot;&quot; /&gt;&quot;, description))
           writer.Write([String].Format(CultureInfo.CurrentCulture, &quot;&lt;meta name=&quot;&quot;keywords&quot;&quot; content=&quot;&quot;{0}&quot;&quot; /&gt;&quot;, keyword))
       End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub Render(writer As HtmlTextWriter)
           'The default keyword
           Dim keyword As String = TryCast(SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaKey&quot;), String)
           'The default description
           Dim description As String = TryCast(SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaDescription&quot;), String)
           'Get current page.
           Dim file As SPFile = SPContext.Current.File


           'If the page does not exist or no special settings, use the default settings.
           'If the page exists and the existence of the specified configuration, using the specified configuration
           If file IsNot Nothing Then
               If file.Exists Then
                   Dim fileName As String = file.Name
                   Dim strCurrentPageKeyword As String = TryCast(SPContext.Current.Web.GetProperty(fileName & &quot;-CustomMetaKey&quot;), String)
                   Dim strCurrentPageDescription As String = TryCast(SPContext.Current.Web.GetProperty(fileName & &quot;-CustomMetaDescription&quot;), String)


                   If Not String.IsNullOrEmpty(strCurrentPageKeyword) Then
                       keyword = strCurrentPageKeyword
                   End If
                   If Not String.IsNullOrEmpty(strCurrentPageDescription) Then
                       description = strCurrentPageDescription
                   End If
               End If
           End If


           'Output the value
           writer.Write([String].Format(CultureInfo.CurrentCulture, &quot;&lt;meta name=&quot;&quot;description&quot;&quot; content=&quot;&quot;{0}&quot;&quot; /&gt;&quot;, description))
           writer.Write([String].Format(CultureInfo.CurrentCulture, &quot;&lt;meta name=&quot;&quot;keywords&quot;&quot; content=&quot;&quot;{0}&quot;&quot; /&gt;&quot;, keyword))
       End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 5: Right-click the &quot;Layouts&quot; folder then add a new folder named &quot;AddElementToHeadTag&quot;, then add a new Page named &quot;SetMeta.aspx&quot;. The page is used to set the Meta value.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'Current web
        Private myWeb As SPWeb = SPContext.Current.Web
        'keyword
        Private strCustomMetaKey As String = String.Empty
        'description
        Private strCustomMetaDescription As String = String.Empty


        'Set the Meta for the specified page
        Protected Sub cmdAddMeta_Click(sender As Object, e As EventArgs)
            Dim strPage As String = tbPageName.Text.Trim()
            Dim file As SPFile = myWeb.GetFile(&quot;/SitePages/&quot; & strPage & &quot;&quot;)
            If file.Exists Then
                strCustomMetaKey = strPage & &quot;-CustomMetaKey&quot;
                strCustomMetaDescription = strPage & &quot;-CustomMetaDescription&quot;


                'Custom Meta
                SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text)


                myWeb.Update()


                SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
            Else
                ltrMsg.Text = &quot;No Such file Exists&quot;
            End If
        End Sub


        'Set the Default Meta
        Protected Sub cmdAddDefaultMeta_Click(sender As Object, e As EventArgs)
            strCustomMetaKey = &quot;Default-CustomMetaKey&quot;
            strCustomMetaDescription = &quot;Default-CustomMetaDescription&quot;


            SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text)


            myWeb.Update()


            SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
        End Sub


        ''' &lt;summary&gt;
        ''' Use the value to add or modify the Meta information in AllProperties.
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;strKey&quot;&gt;New keyword&lt;/param&gt;
        ''' &lt;param name=&quot;strDescription&quot;&gt;New description&lt;/param&gt;
        Private Sub SetOrModifyCustomMeta(strKey As String, strDescription As String)
            'Add or modify the keyword
            If String.IsNullOrEmpty(TryCast(SPContext.Current.Web.GetProperty(strCustomMetaKey), String)) Then
                myWeb.AllProperties.Add(strCustomMetaKey, strKey)
            Else
                myWeb.AllProperties(strCustomMetaKey) = strKey
            End If


            'Add or modify the description
            If String.IsNullOrEmpty(TryCast(myWeb.GetProperty(strCustomMetaDescription), String)) Then
                myWeb.AllProperties.Add(strCustomMetaDescription, strDescription)
            Else
                myWeb.AllProperties(strCustomMetaDescription) = strDescription
            End If
        End Sub

</pre>
<pre id="codePreview" class="vb">
'Current web
        Private myWeb As SPWeb = SPContext.Current.Web
        'keyword
        Private strCustomMetaKey As String = String.Empty
        'description
        Private strCustomMetaDescription As String = String.Empty


        'Set the Meta for the specified page
        Protected Sub cmdAddMeta_Click(sender As Object, e As EventArgs)
            Dim strPage As String = tbPageName.Text.Trim()
            Dim file As SPFile = myWeb.GetFile(&quot;/SitePages/&quot; & strPage & &quot;&quot;)
            If file.Exists Then
                strCustomMetaKey = strPage & &quot;-CustomMetaKey&quot;
                strCustomMetaDescription = strPage & &quot;-CustomMetaDescription&quot;


                'Custom Meta
                SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text)


                myWeb.Update()


                SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
            Else
                ltrMsg.Text = &quot;No Such file Exists&quot;
            End If
        End Sub


        'Set the Default Meta
        Protected Sub cmdAddDefaultMeta_Click(sender As Object, e As EventArgs)
            strCustomMetaKey = &quot;Default-CustomMetaKey&quot;
            strCustomMetaDescription = &quot;Default-CustomMetaDescription&quot;


            SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text)


            myWeb.Update()


            SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
        End Sub


        ''' &lt;summary&gt;
        ''' Use the value to add or modify the Meta information in AllProperties.
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;strKey&quot;&gt;New keyword&lt;/param&gt;
        ''' &lt;param name=&quot;strDescription&quot;&gt;New description&lt;/param&gt;
        Private Sub SetOrModifyCustomMeta(strKey As String, strDescription As String)
            'Add or modify the keyword
            If String.IsNullOrEmpty(TryCast(SPContext.Current.Web.GetProperty(strCustomMetaKey), String)) Then
                myWeb.AllProperties.Add(strCustomMetaKey, strKey)
            Else
                myWeb.AllProperties(strCustomMetaKey) = strKey
            End If


            'Add or modify the description
            If String.IsNullOrEmpty(TryCast(myWeb.GetProperty(strCustomMetaDescription), String)) Then
                myWeb.AllProperties.Add(strCustomMetaDescription, strDescription)
            Else
                myWeb.AllProperties(strCustomMetaDescription) = strDescription
            End If
        End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Then add a new Page named &quot;ClearCustomMeta.aspx&quot;. The page is used to clear the Meta value.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private myWeb As SPWeb = SPContext.Current.Web


       Protected Sub cmdClearMeta_Click(sender As Object, e As EventArgs)
           'A List to store the Meta which need to remove.
           Dim listKey As New List(Of String)()


           'Loop AllProperties to identify the item need to remove
           For Each objDE As System.Collections.DictionaryEntry In myWeb.AllProperties
               If objDE.Key.ToString().Contains(&quot;-CustomMeta&quot;) Then
                   listKey.Add(objDE.Key.ToString())
               End If
           Next


           'Remove the custom Meta
           For i As Integer = 0 To listKey.Count - 1
               myWeb.AllProperties.Remove(listKey(i))
           Next


           myWeb.Update()


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)


       End Sub

</pre>
<pre id="codePreview" class="vb">
Private myWeb As SPWeb = SPContext.Current.Web


       Protected Sub cmdClearMeta_Click(sender As Object, e As EventArgs)
           'A List to store the Meta which need to remove.
           Dim listKey As New List(Of String)()


           'Loop AllProperties to identify the item need to remove
           For Each objDE As System.Collections.DictionaryEntry In myWeb.AllProperties
               If objDE.Key.ToString().Contains(&quot;-CustomMeta&quot;) Then
                   listKey.Add(objDE.Key.ToString())
               End If
           Next


           'Remove the custom Meta
           For i As Integer = 0 To listKey.Count - 1
               myWeb.AllProperties.Remove(listKey(i))
           Next


           myWeb.Update()


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage, Me.Context)


       End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 6: Modify Elements.xml files as follows. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Elements.xml of SiteSettingsPageLinks </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;


    &lt;CustomActionGroup
      Id=&quot;CustomAdministration&quot;
      Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
      Title=&quot;Custom Site Administration&quot;
      Sequence=&quot;61&quot;
      Description=&quot;&quot;
      ImageUrl=&quot;/_layouts/images/AddElementToHeadTag/SectionIcon.gif&quot; /&gt;


    &lt;CustomAction
        Id=&quot;CustomSetMeta&quot;
        GroupId=&quot;CustomAdministration&quot;
        Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
        Rights=&quot;ManageWeb&quot;
        Sequence=&quot;2&quot;
        Title=&quot;Set Custom Meta&quot;
        Description=&quot;Use this page to configure the meta&quot; &gt;
        &lt;UrlAction Url=&quot;~site/_layouts/AddElementToHeadTag/SetMeta.aspx&quot; /&gt;
    &lt;/CustomAction&gt;


    &lt;CustomAction
       Id=&quot;ClearCustomSetMeta&quot;
       GroupId=&quot;CustomAdministration&quot;
       Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
       Rights=&quot;ManageWeb&quot;
       Sequence=&quot;2&quot;
       Title=&quot;Clear Custom Meta&quot;
       Description=&quot;Use this page to Clear the custom meta&quot; &gt;
        &lt;UrlAction Url=&quot;~site/_layouts/AddElementToHeadTag/ClearCustomMeta.aspx&quot; /&gt;
    &lt;/CustomAction&gt;


&lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;


    &lt;CustomActionGroup
      Id=&quot;CustomAdministration&quot;
      Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
      Title=&quot;Custom Site Administration&quot;
      Sequence=&quot;61&quot;
      Description=&quot;&quot;
      ImageUrl=&quot;/_layouts/images/AddElementToHeadTag/SectionIcon.gif&quot; /&gt;


    &lt;CustomAction
        Id=&quot;CustomSetMeta&quot;
        GroupId=&quot;CustomAdministration&quot;
        Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
        Rights=&quot;ManageWeb&quot;
        Sequence=&quot;2&quot;
        Title=&quot;Set Custom Meta&quot;
        Description=&quot;Use this page to configure the meta&quot; &gt;
        &lt;UrlAction Url=&quot;~site/_layouts/AddElementToHeadTag/SetMeta.aspx&quot; /&gt;
    &lt;/CustomAction&gt;


    &lt;CustomAction
       Id=&quot;ClearCustomSetMeta&quot;
       GroupId=&quot;CustomAdministration&quot;
       Location=&quot;Microsoft.SharePoint.SiteSettings&quot;
       Rights=&quot;ManageWeb&quot;
       Sequence=&quot;2&quot;
       Title=&quot;Clear Custom Meta&quot;
       Description=&quot;Use this page to Clear the custom meta&quot; &gt;
        &lt;UrlAction Url=&quot;~site/_layouts/AddElementToHeadTag/ClearCustomMeta.aspx&quot; /&gt;
    &lt;/CustomAction&gt;


&lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Elements.xml of Controls </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;Control Id=&quot;AdditionalPageHead&quot; ControlSrc=&quot;~/_controltemplates/AddElementToHeadTag/HeadInTag.ascx&quot; Sequence=&quot;10011&quot; /&gt;
&lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;Control Id=&quot;AdditionalPageHead&quot; ControlSrc=&quot;~/_controltemplates/AddElementToHeadTag/HeadInTag.ascx&quot; Sequence=&quot;10011&quot; /&gt;
&lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 7: Deploy the feature and you can test it. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">SPWeb.AllProperties Property </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.allproperties.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.allproperties.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span style="">Delegate Control (Control Templatization)<br>
<a href="http://msdn.microsoft.com/en-us/library/ms463169.aspx">http://msdn.microsoft.com/en-us/library/ms463169.aspx</a><br>
HttpRequest.ServerVariables Property<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.httprequest.servervariables.aspx">http://msdn.microsoft.com/en-us/library/system.web.httprequest.servervariables.aspx</a><br>
How to: Customize a Delegate Control<br>
<a href="http://msdn.microsoft.com/en-us/library/ms470880.aspx">http://msdn.microsoft.com/en-us/library/ms470880.aspx</a></span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas"><br style="">
<br style="">
</span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
