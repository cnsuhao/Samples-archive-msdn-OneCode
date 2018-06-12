# Silverlight - Sharepoint integration (CSSharePointSilverlightIntegration)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
* SharePoint
## Topics
* webpart
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:49:13
## Description

<h1><span style="">How to use Silverlight along-with SharePoint </span>(<span style="">VBSharePointSilverlightIntegration</span>)</h1>
<h2>Introduction </h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The project shows how to use Silverlight along-with SharePoint.</span>
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
A Silverlight application can be hosted inside a SharePoint site and it is called as a Silverlight WebPart.<br>
<br>
</span>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBSharePointSilverlightIntegration.sln then right click the SharePoint project to edit the &quot;Site Url&quot; to your own.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;VBSharePointSilverlightIntegration&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Open the SharePoint site in the browser and select &quot;Page&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/61519/1/image.png" alt="" width="993" height="409" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: </span>Select Edit.<br>
<span style=""><img src="/site/view/file/61520/1/image.png" alt="" width="965" height="384" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: </span>Having done that Select &quot;Insert&quot; tab and click &quot;Web Part&quot;.<br>
<span style=""><img src="/site/view/file/61521/1/image.png" alt="" width="991" height="353" align="middle">
</span><br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: </span>In &quot;Categories&quot;, select &quot;Media and content&quot; and correspondingly in &quot;Web Parts&quot; column, Select &quot;Silverlight Web Part&quot; Having Selected the &quot;Silverlight Web Part&quot;, click on &quot;Add&quot;
 button that appears on the right side.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/61522/1/image.png" alt="" width="825" height="429" align="middle">
</span><span style=""><br>
<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: </span>After clicking add, a small pop-up will appear asking for the URL of the Silverlight content(.xap) file. Enter the URL in the following format as:<br>
<span style="">&nbsp;</span><a href="http://YourPointSite/DemoModule/SilverlightWebpart.xap">http://YourPointSite/DemoModule/SilverlightWebpart.xap</a><br>
<span style=""><img src="/site/view/file/61523/1/image.png" alt="" width="1158" height="606" align="middle">
</span><span style="">&nbsp;</span><br>
<span style="">Step 8: </span>Then click OK and then you can see your Silverlight web part appear in the SharePoint site as:<br>
<span style=""><img src="/site/view/file/61524/1/image.png" alt="" width="892" height="477" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<br>
<span style="">Step 9: </span>As you can see the blue border is the boundary of the Silverlight web part and the Silverlight application has a button in it. When you click the button, it acts like a normal Silverlight application and responds to the user interaction
 and a Message Box is popped, for which we wrote code in &quot;MainPage.xaml.cs&quot;.<br>
<span style=""><img src="/site/view/file/61525/1/image.png" alt="" width="1014" height="445" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <br>
<b style="">[Prerequisites]</b></span> <a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=5970">
Microsoft SharePoint Foundation 2010 </a><span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step1: Create a VB </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;VBSharePointSilverlightIntegration&quot;.
</span></p>
<img src="/site/view/file/61526/1/image.png" alt="" width="605" height="479" align="middle">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;UserControl x:Class=&quot;SilverlightWebpart.MainPage&quot;
       xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
       xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
       xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
       xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
       mc:Ignorable=&quot;d&quot;
       d:DesignHeight=&quot;300&quot; d:DesignWidth=&quot;400&quot;&gt;


       &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt;
           &lt;Button Name=&quot;btnClk&quot; Height=&quot;20&quot; Width=&quot;50&quot; Content=&quot;Click !!&quot; Click=&quot;btnClk_Click&quot;&gt;&lt;/Button&gt;
       &lt;/Grid&gt;
   &lt;/UserControl&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;UserControl x:Class=&quot;SilverlightWebpart.MainPage&quot;
       xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
       xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
       xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
       xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
       mc:Ignorable=&quot;d&quot;
       d:DesignHeight=&quot;300&quot; d:DesignWidth=&quot;400&quot;&gt;


       &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt;
           &lt;Button Name=&quot;btnClk&quot; Height=&quot;20&quot; Width=&quot;50&quot; Content=&quot;Click !!&quot; Click=&quot;btnClk_Click&quot;&gt;&lt;/Button&gt;
       &lt;/Grid&gt;
   &lt;/UserControl&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Net;
   using System.Windows;
   using System.Windows.Controls;
   using System.Windows.Documents;
   using System.Windows.Input;
   using System.Windows.Media;
   using System.Windows.Media.Animation;
   using System.Windows.Shapes;


   namespace SilverlightWebpart
   {
       public partial class MainPage : UserControl
       {
           public MainPage()
           {
               InitializeComponent();
           }


           private void btnClk_Click(object sender, RoutedEventArgs e)
           {
               MessageBox.Show(&quot;Hello from Silverlight within SharePoint !!&quot;);
           }


       }
   }

</pre>
<pre id="codePreview" class="vb">
using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Net;
   using System.Windows;
   using System.Windows.Controls;
   using System.Windows.Documents;
   using System.Windows.Input;
   using System.Windows.Media;
   using System.Windows.Media.Animation;
   using System.Windows.Shapes;


   namespace SilverlightWebpart
   {
       public partial class MainPage : UserControl
       {
           public MainPage()
           {
               InitializeComponent();
           }


           private void btnClk_Click(object sender, RoutedEventArgs e)
           {
               MessageBox.Show(&quot;Hello from Silverlight within SharePoint !!&quot;);
           }


       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
copy &quot;$(TargetDir)SilverlightWebpart.xap&quot; &quot;$(SolutionDir)VBSharePointSilverlightIntegration\DemoModule

</pre>
<pre id="codePreview" class="vb">
copy &quot;$(TargetDir)SilverlightWebpart.xap&quot; &quot;$(SolutionDir)VBSharePointSilverlightIntegration\DemoModule

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<img src="/site/view/file/61527/1/image.png" alt="" width="1334" height="565" align="middle">
<p class="MsoNormal" style=""><span style=""><img src="/site/view/file/61528/1/image.png" alt="" width="537" height="345" align="middle">
</span></p>
<p class="MsoNormal" style=""><span style="">Step11: Build </span>the entire solution and then try to deploy the &quot;VBSharePointSilverlightIntegration&quot; project to the SharePoint site. Then you can test it.</p>
<p class="MsoNormal" style=""><b style="">Why brings Silverlight and SharePoint together?</b><br>
&#8226;Users are expecting rich, compelling interfaces. <br>
Silverlight is a perfect technology to create Web 2.0 applications in SharePoint<br>
&#8226;Limit page post backs. <br>
Silverlight applications do their processing on the client, eliminating page post backs.<br>
&#8226;Silverlight applications offload processing to the client. <br>
Processing on the client reduces the load on the SharePoint server farm.<br>
&#8226;Silverlight isolates processing on the client<br>
&#8226;Separation of design and code. <br>
You can use the MVVM pattern to separate the presentation from the processing later. This makes it easy to change the look and feel of Silverlight applications.<br>
&#8226;Common .NET development techniques. <br>
Silverlight applications are based on the .NET framework which makes it easy for .NET developers to create them. The client object model may be used to access SharePoint resources from a Silverlight application.<br>
&#8226;Overcome Sandbox limitations. <br>
Silverlight applications may be used to overcome sandboxed limitations such as the ability to call an external service, or use parts of the .NET framework which are not permitted to run in a sandboxed solution.<br>
&#8226;Ease of deployment. <br>
Silverlight applications are very easy to deploy. Anyone with the ability to upload a document to a document library can deploy a Silverlight application to a SharePoint site. Additionally, the Silverlight Web Part makes it very easy to place Silverlight applications
 on SharePoint web pages.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
