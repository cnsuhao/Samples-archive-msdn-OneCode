# How to set home page for publishing sites (CSSharePointSetHomepageForSite)
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
* 2012-12-03 11:17:47
## Description

<h1><a name="OLE_LINK9"></a><a name="OLE_LINK8"><span style=""><span style="">Programmatically set home page for publishing sites
</span>(</span></a><span style=""><span style=""><span style="">CSSharePointSetHomepageForSite</span>)</span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal"><span style="">This sample will demo how to set home page for publishing sites programmatically. According to the specified URL to get a web object and then we will check the SPWeb object to verify whether it is a PublishingWeb object.
 If it is, set the new Welcome page for this PublishingWeb object. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointSetHomepageForSite.sln file. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the Program.cs file to modify the strPublishingWebUrl and the strWelcomePageUrl to your own&#39;s. The strPublishingWebUrl is the URL of SharePoint Site which you want to verify whether it is a PublishingWeb object. The strWelcomePageUrl
 is the URL of the new WelcomePage. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">In this sample, the original welcomepage's URL is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/Pages/default.aspx"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/Pages/default.aspx</span></a>&quot;. The new WelcomePage's
 URL is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx</span></a>&quot; and the PublishingWeb'Url is &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/"><span style="color:windowtext">http://win-2ed380lbo8e:1234/sites/Wiki/</span></a>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The welcomePage of my test web as shown below: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/71856/1/image.png" alt="" width="904" height="375" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">After that you can press &quot;Ctrl&#43;F5&quot; to run the sample. Re-visit &quot;<a href="http://win-2ed380lbo8e:1234/sites/Wiki/">http://win-2ed380lbo8e:1234/sites/Wiki/</a>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
<span style=""><img src="/site/view/file/71857/1/image.png" alt="" width="794" height="348" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The WelcomePage has been changed. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Console Application&quot; in Visual Studio 2010 and named it as &quot;CSSharePointSetHomepageForSite&quot;.
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using Microsoft.SharePoint;

</pre>
<pre id="codePreview" class="csharp">
using Microsoft.SharePoint;

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Url of the PublishingWeb
            string strPublishingWebUrl = &quot;http://win-2ed380lbo8e:1234/sites/Wiki/&quot;;
            // Url of the new WelcomePage
            string strWelcomePageUrl = &quot; http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx&quot;;

</pre>
<pre id="codePreview" class="csharp">
// Url of the PublishingWeb
            string strPublishingWebUrl = &quot;http://win-2ed380lbo8e:1234/sites/Wiki/&quot;;
            // Url of the new WelcomePage
            string strWelcomePageUrl = &quot; http://win-2ed380lbo8e:1234/sites/Wiki/Pages/newHome.aspx&quot;;

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Connect to SharePoint Site
            using (var oSite = new SPSite(strPublishingWebUrl))
            {
                // Open SharePoint Site
                using (var oWeb = oSite.OpenWeb())
                {
                    // Checks the SPWeb object to verify whether it is a PublishingWeb object.
                    if (Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb))
                    {
                        // Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                        var oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb);


                        try
                        {
                            // Get the new WelcomePage File by the url.
                            var oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl);
                            // Sets the Welcome page for this PublishingWeb object.
                            oPublishingWeb.DefaultPage 
= oWelcomePageFile;
                            // Saves changes to the PublishingWeb object
                            oPublishingWeb.Update();
                        }
                        catch (Exception oException)
                        {
                            //handle the exception
                            Console.WriteLine(oException.Message);
                        }
                        finally
                        {
                            // prevent memory leaks by closing the Publishing web
                            oPublishingWeb.Close();
                        }
                    }
                }
            }

</pre>
<pre id="codePreview" class="csharp">
// Connect to SharePoint Site
            using (var oSite = new SPSite(strPublishingWebUrl))
            {
                // Open SharePoint Site
                using (var oWeb = oSite.OpenWeb())
                {
                    // Checks the SPWeb object to verify whether it is a PublishingWeb object.
                    if (Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb))
                    {
                        // Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                        var oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb);


                        try
                        {
                            // Get the new WelcomePage File by the url.
                            var oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl);
                            // Sets the Welcome page for this PublishingWeb object.
                            oPublishingWeb.DefaultPage 
= oWelcomePageFile;
                            // Saves changes to the PublishingWeb object
                            oPublishingWeb.Update();
                        }
                        catch (Exception oException)
                        {
                            //handle the exception
                            Console.WriteLine(oException.Message);
                        }
                        finally
                        {
                            // prevent memory leaks by closing the Publishing web
                            oPublishingWeb.Close();
                        }
                    }
                }
            }

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
