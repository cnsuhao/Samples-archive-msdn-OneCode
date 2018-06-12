# Add element under head tag (CSSharePointAddElementToHeadTag)
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
* 2012-07-22 07:45:29
## Description

<h1>How to add element under head Tag (<span class="SpellE">CSSharePointAddElementToHeadTag</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The CSSharePointAddElementToHeadTag sample demonstrates how to add or modify element of the html head Tag. In the use of master pages, some users may want to customize title, Meta, or other head tags for each page. After walking through this
 simple demonstration, you can operate the other tags easily. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.</span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 1: Open the CSSharePointAddElementToHeadTag.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the solution then run &quot;Deploy&quot;. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: Under the &quot;Site Setting&quot; node of your site, you may find a new setting group named &quot;Custom Site Administration&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62018/1/image.png" alt="" width="326" height="107" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: Click the &quot;Set Meta&quot; link. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62019/1/image.png" alt="" width="303" height="288" align="middle">
</span><span style=""><span style="">&nbsp;</span><br>
Step 5: Enter keywords and description for your site or specified page. Then click the &quot;Set Meta&quot; button or &quot;Set Default Meta&quot; button to save.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62020/1/image.png" alt="" width="276" height="138" align="middle">
<img src="/site/view/file/62021/1/image.png" alt="" width="283" height="111" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 6: Open any page to view source. <span style=""></span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For the </span><span style="">specified page (e.g. test1.aspx), you will see:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62022/1/image.png" alt="" width="748" height="92" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For the </span><span style="">common page (e.g. Home.aspx), you will see:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62023/1/image.png" alt="" width="725" height="62" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Click the &quot;Clear Custom Meta&quot; page link. After clicking the button, then open any page to view source again (e.g. test1.aspx).
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/62024/1/image.png" alt="" width="541" height="81" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Empty SharePoint Project&quot; in Visual Studio 2010. Name it as &quot;CSSharePointAddElementToHeadTag&quot;. In the SharePoint Customization Wizard, choose Deploy as a farm solution. Click Finish.
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
<span style="">Step 3: Add two &quot;Empty Element&quot; name them as &quot;<span class="SpellE">SiteSettingsPageLinks</span>&quot; and &quot;Controls&quot;. SiteSettingsPageLinks is used to custom Ribbon.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal">Step 4: Right-click the &quot;ControlTemplates&quot; folder then add a new folder named &quot;AddElementToHeadTag&quot;, then add a User Control named &quot;HeadInTag.ascx&quot;. The User Control is used to render the custom Meta information.<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected override void Render(HtmlTextWriter writer)
       {
           //The default keyword
           string keyword = SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaKey&quot;) as string;
           //The default description
           string description = SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaDescription&quot;) as string;
           //Get current page.
           SPFile file = SPContext.Current.File;


           //If the page does not exist or no special settings, use the default settings.
           //If the page exists and the existence of the specified configuration, using the specified configuration
           if (file != null)
           {
               if (file.Exists)
               {
                   string fileName = file.Name;
                   string strCurrentPageKeyword = SPContext.Current.Web.GetProperty(fileName &#43; &quot;-CustomMetaKey&quot;) as string;
                   string strCurrentPageDescription = SPContext.Current.Web.GetProperty(fileName &#43; &quot;-CustomMetaDescription&quot;) as string;


                   if (!string.IsNullOrEmpty(strCurrentPageKeyword))
                   {
                       keyword = strCurrentPageKeyword;
                   }
                   if (!string.IsNullOrEmpty(strCurrentPageDescription))
                   {
                       description = strCurrentPageDescription;
                   }
               }
           }


           //Output the value
           writer.Write(String.Format(CultureInfo.CurrentCulture, &quot;&lt;Meta name=\&quot;description\&quot; content=\&quot;{0}\&quot; /&gt;&quot;, description));
           writer.Write(String.Format(CultureInfo.CurrentCulture, &quot;&lt;Meta name=\&quot;keywords\&quot; content=\&quot;{0}\&quot; /&gt;&quot;, keyword));
       }

</pre>
<pre id="codePreview" class="csharp">
protected override void Render(HtmlTextWriter writer)
       {
           //The default keyword
           string keyword = SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaKey&quot;) as string;
           //The default description
           string description = SPContext.Current.Web.GetProperty(&quot;Default-CustomMetaDescription&quot;) as string;
           //Get current page.
           SPFile file = SPContext.Current.File;


           //If the page does not exist or no special settings, use the default settings.
           //If the page exists and the existence of the specified configuration, using the specified configuration
           if (file != null)
           {
               if (file.Exists)
               {
                   string fileName = file.Name;
                   string strCurrentPageKeyword = SPContext.Current.Web.GetProperty(fileName &#43; &quot;-CustomMetaKey&quot;) as string;
                   string strCurrentPageDescription = SPContext.Current.Web.GetProperty(fileName &#43; &quot;-CustomMetaDescription&quot;) as string;


                   if (!string.IsNullOrEmpty(strCurrentPageKeyword))
                   {
                       keyword = strCurrentPageKeyword;
                   }
                   if (!string.IsNullOrEmpty(strCurrentPageDescription))
                   {
                       description = strCurrentPageDescription;
                   }
               }
           }


           //Output the value
           writer.Write(String.Format(CultureInfo.CurrentCulture, &quot;&lt;Meta name=\&quot;description\&quot; content=\&quot;{0}\&quot; /&gt;&quot;, description));
           writer.Write(String.Format(CultureInfo.CurrentCulture, &quot;&lt;Meta name=\&quot;keywords\&quot; content=\&quot;{0}\&quot; /&gt;&quot;, keyword));
       }

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Current web
       SPWeb myWeb = SPContext.Current.Web;
       //keyword
       string strCustomMetaKey = string.Empty;
       //description
       string strCustomMetaDescription = string.Empty;


       //Set the Meta for the specified page
       protected void cmdAddMeta_Click(object sender, EventArgs e)
       {            
           string strPage = tbPageName.Text.Trim();
           SPFile file = myWeb.GetFile(&quot;/SitePages/&quot; &#43; strPage &#43; &quot;&quot;);
           if (file.Exists)
           {
               strCustomMetaKey = strPage &#43; &quot;-CustomMetaKey&quot;;
               strCustomMetaDescription = strPage &#43; &quot;-CustomMetaDescription&quot;;


               //Custom Meta
               SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text);


               myWeb.Update();


               SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
                this.Context);
           }
           else
           {
               ltrMsg.Text = &quot;No Such file Exists&quot;;
           }         
       }


       //Set the Default Meta
       protected void cmdAddDefaultMeta_Click(object sender, EventArgs e)
       {
           strCustomMetaKey = &quot;Default-CustomMetaKey&quot;;
           strCustomMetaDescription = &quot;Default-CustomMetaDescription&quot;;


           SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text);


           myWeb.Update();


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
            this.Context);
       }


       /// &lt;summary&gt;
       /// Use the value to add or modify the Meta information in AllProperties.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;strKey&quot;&gt;New keyword&lt;/param&gt;
       /// &lt;param name=&quot;strDescription&quot;&gt;New description&lt;/param&gt;
       private void SetOrModifyCustomMeta(string strKey, string strDescription)
       {
           //Add or modify the keyword
           if (string.IsNullOrEmpty(SPContext.Current.Web.GetProperty(strCustomMetaKey) as string))
           {
               myWeb.AllProperties.Add(strCustomMetaKey, strKey);
           }
           else
           {
               myWeb.AllProperties[strCustomMetaKey] = strKey;
           }


           //Add or modify the description
           if (string.IsNullOrEmpty(myWeb.GetProperty(strCustomMetaDescription) as string))
           {
               myWeb.AllProperties.Add(strCustomMetaDescription, strDescription);
           }
           else
           {
               myWeb.AllProperties[strCustomMetaDescription] = strDescription;
           }
       }

</pre>
<pre id="codePreview" class="csharp">
//Current web
       SPWeb myWeb = SPContext.Current.Web;
       //keyword
       string strCustomMetaKey = string.Empty;
       //description
       string strCustomMetaDescription = string.Empty;


       //Set the Meta for the specified page
       protected void cmdAddMeta_Click(object sender, EventArgs e)
       {            
           string strPage = tbPageName.Text.Trim();
           SPFile file = myWeb.GetFile(&quot;/SitePages/&quot; &#43; strPage &#43; &quot;&quot;);
           if (file.Exists)
           {
               strCustomMetaKey = strPage &#43; &quot;-CustomMetaKey&quot;;
               strCustomMetaDescription = strPage &#43; &quot;-CustomMetaDescription&quot;;


               //Custom Meta
               SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text);


               myWeb.Update();


               SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
                this.Context);
           }
           else
           {
               ltrMsg.Text = &quot;No Such file Exists&quot;;
           }         
       }


       //Set the Default Meta
       protected void cmdAddDefaultMeta_Click(object sender, EventArgs e)
       {
           strCustomMetaKey = &quot;Default-CustomMetaKey&quot;;
           strCustomMetaDescription = &quot;Default-CustomMetaDescription&quot;;


           SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text);


           myWeb.Update();


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
            this.Context);
       }


       /// &lt;summary&gt;
       /// Use the value to add or modify the Meta information in AllProperties.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;strKey&quot;&gt;New keyword&lt;/param&gt;
       /// &lt;param name=&quot;strDescription&quot;&gt;New description&lt;/param&gt;
       private void SetOrModifyCustomMeta(string strKey, string strDescription)
       {
           //Add or modify the keyword
           if (string.IsNullOrEmpty(SPContext.Current.Web.GetProperty(strCustomMetaKey) as string))
           {
               myWeb.AllProperties.Add(strCustomMetaKey, strKey);
           }
           else
           {
               myWeb.AllProperties[strCustomMetaKey] = strKey;
           }


           //Add or modify the description
           if (string.IsNullOrEmpty(myWeb.GetProperty(strCustomMetaDescription) as string))
           {
               myWeb.AllProperties.Add(strCustomMetaDescription, strDescription);
           }
           else
           {
               myWeb.AllProperties[strCustomMetaDescription] = strDescription;
           }
       }

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SPWeb myWeb = SPContext.Current.Web;


       protected void cmdClearMeta_Click(object sender, EventArgs e)
       {
           //A List to store the Meta which need to remove.
           List&lt;string&gt; listKey = new List&lt;string&gt;();


           //Loop AllProperties to identify the item need to remove
           foreach (System.Collections.DictionaryEntry objDE in myWeb.AllProperties)
           {
               if (objDE.Key.ToString().Contains(&quot;-CustomMeta&quot;))
               {
                   listKey.Add(objDE.Key.ToString());
               }
           }


           //Remove the custom Meta
           for (int i = 0; i &lt; listKey.Count; i&#43;&#43;)
           {
               myWeb.AllProperties.Remove(listKey[i]);
           }


           myWeb.Update();


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
            this.Context);


       }

</pre>
<pre id="codePreview" class="csharp">
SPWeb myWeb = SPContext.Current.Web;


       protected void cmdClearMeta_Click(object sender, EventArgs e)
       {
           //A List to store the Meta which need to remove.
           List&lt;string&gt; listKey = new List&lt;string&gt;();


           //Loop AllProperties to identify the item need to remove
           foreach (System.Collections.DictionaryEntry objDE in myWeb.AllProperties)
           {
               if (objDE.Key.ToString().Contains(&quot;-CustomMeta&quot;))
               {
                   listKey.Add(objDE.Key.ToString());
               }
           }


           //Remove the custom Meta
           for (int i = 0; i &lt; listKey.Count; i&#43;&#43;)
           {
               myWeb.AllProperties.Remove(listKey[i]);
           }


           myWeb.Update();


           SPUtility.Redirect(&quot;settings.aspx&quot;, SPRedirectFlags.RelativeToLayoutsPage,
            this.Context);


       }

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
<span class="SpellE"><span style="">SPWeb.AllProperties</span></span><span style=""> Property
</span></p>
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
