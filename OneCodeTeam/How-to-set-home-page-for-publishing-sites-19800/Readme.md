# How to set home page for publishing sites (VBSharePointSetHomepageForSite)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* HomePage
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:13:47
## Description

<h1><a name="OLE_LINK8"></a><a name="OLE_LINK9"><span style=""><span style="">Programmatically set home page for publishing sites
</span>(</span></a><span style=""><span style=""><span style="">VBSharePointSetHomepageForSite</span>)</span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal">This sample will demo how to set home page for publishing sites programmatically. According to the specified URL to get a web object and then we will check the SPWeb object to verify whether it is a PublishingWeb object. If it is, set
 the new Welcome page for this PublishingWeb object.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBSharePointSetHomepageForSite.sln file. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the <span class="SpellE">MainModule.vb</span> file to modify the strPublishingWebUrl and the strWelcomePageUrl to your own&#39;s. The strPublishingWebUrl is the URL of SharePoint Site which you want to verify whether it is a PublishingWeb
 object. The strWelcomePageUrl is the URL of the new WelcomePage. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">In this sample, the original welcomepage's URL is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/Pages/default.aspx"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/Pages/default.aspx</span></a>&quot;. The new WelcomePage's
 URL is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx</span></a>&quot; and the PublishingWeb'Url is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/</span></a>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The welcomePage of my test web as shown below: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/71828/1/image.png" alt="" width="904" height="375" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">After that you can press &quot;Ctrl&#43;F5&quot; to run the sample. Re-visit &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/">http://win-2ed380lbo8e:1234/sites/Wiki/</a>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
<span style=""><img src="/site/view/file/71829/1/image.png" alt="" width="794" height="348" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The <span class="SpellE">WelcomePage</span> has been changed. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a VB &quot;Console Application&quot; in Visual Studio 2010 and named it as &quot;VBSharePointSetHomepageForSite&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2:<span style="">&nbsp; </span>Add the following assembly reference:<br>
<span style="">&nbsp;</span><span style="color:black">Project-&gt; References -&gt;…</span>
<span style="color:black">Microsoft.</span>SharePoint.dll<br>
<span style="color:black"><span style="">&nbsp;</span>Project-&gt; References -&gt;…</span> Microsoft.SharePoint.Publishing.dll
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the following namespace in Program.cs. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Microsoft.SharePoint

</pre>
<pre id="codePreview" class="vb">
Imports Microsoft.SharePoint

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Specify the strPublishingWebUrl and the strWelcomePageUrl.
<br style="">
<br style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Url of the PublishingWeb
       Dim strPublishingWebUrl As String = &quot;http://win-2ed380lbo8e:1234/sites/Wiki/&quot;
       ' Url of the new WelcomePage
       Dim strWelcomePageUrl As String = &quot; http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx&quot;

</pre>
<pre id="codePreview" class="vb">
' Url of the PublishingWeb
       Dim strPublishingWebUrl As String = &quot;http://win-2ed380lbo8e:1234/sites/Wiki/&quot;
       ' Url of the new WelcomePage
       Dim strWelcomePageUrl As String = &quot; http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Connect to SharePoint Site
        Using oSite = New SPSite(strPublishingWebUrl)
            ' Open SharePoint Site
            Using oWeb = oSite.OpenWeb()
                ' Checks the SPWeb object to verify whether it is a PublishingWeb object.
                If Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb) Then
                    ' Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                    Dim oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb)


                    Try
                        ' Get the new WelcomePage File by the url.
                        Dim oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl)
                        ' Sets the Welcome page for this PublishingWeb object.
                        oPublishingWeb.DefaultPage = oWelcomePageFile
                        ' Saves changes to the PublishingWeb object
                        oPublishingWeb.Update()
                    Catch oException As Exception
                        'handle the exception
                        Console.WriteLine(oException.Message)
                    Finally
                        ' prevent memory leaks by closing the Publishing web
                        oPublishingWeb.Close()
                    End Try
                End If
            End Using
        End Using

</pre>
<pre id="codePreview" class="vb">
' Connect to SharePoint Site
        Using oSite = New SPSite(strPublishingWebUrl)
            ' Open SharePoint Site
            Using oWeb = oSite.OpenWeb()
                ' Checks the SPWeb object to verify whether it is a PublishingWeb object.
                If Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb) Then
                    ' Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                    Dim oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb)


                    Try
                        ' Get the new WelcomePage File by the url.
                        Dim oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl)
                        ' Sets the Welcome page for this PublishingWeb object.
                        oPublishingWeb.DefaultPage = oWelcomePageFile
                        ' Saves changes to the PublishingWeb object
                        oPublishingWeb.Update()
                    Catch oException As Exception
                        'handle the exception
                        Console.WriteLine(oException.Message)
                    Finally
                        ' prevent memory leaks by closing the Publishing web
                        oPublishingWeb.Close()
                    End Try
                End If
            End Using
        End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 6: You can debug and test it.
</span></p>
<h2>More Information</h2>
<p class="MsoNormal">PublishingWeb<span>.</span>IsPublishingWeb Method<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.ispublishingweb.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.ispublishingweb.aspx</a><br>
</span>PublishingWeb<span>.</span>GetPublishingWeb Method<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/ms497306.aspx">http://msdn.microsoft.com/en-us/library/ms497306.aspx</a></span><br>
PublishingWeb<span>.</span>DefaultPage Property<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.defaultpage.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.defaultpage.aspx</a><br>
</span>PublishingWeb.Close Method<span style=""> <br>
</span><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.close(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.publishingweb.close(v=office.12).aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
