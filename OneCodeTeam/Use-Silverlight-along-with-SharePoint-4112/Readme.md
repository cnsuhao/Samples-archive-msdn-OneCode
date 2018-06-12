# Use Silverlight along with SharePoint (CSSharePointSilverlightIntegration)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
* SharePoint
## Topics
* Silverlight Webpart
## IsPublished
* True
## ModifiedDate
* 2011-08-07 08:06:01
## Description

<h1>CSSharePointSilverlightIntegration Project Overview</h1>
<h2>What is Silverlight ?</h2>
<p>Silverlight is a powerful development platform for creating engaging, interactive user experiences for Web, desktop, and mobile applications when online or offline.</p>
<h2>What is SharePoint?</h2>
<p>Microsoft SharePoint 2010 makes it easier for people to work together. Using SharePoint 2010, your people can set up Web sites to share information with others, manage documents from start to finish, and publish reports to help everyone make better decisions</p>
<h2>What brings Silverlight and SharePoint together?</h2>
<ul>
<li>Users are expecting rich, compelling interfaces.
<p>Silverlight is a perfect technology to create Web 2.0 applications in SharePoint</p>
</li><li>Limit page post backs.
<p>Silverlight applications do their processing on the client, eliminating page post backs.</p>
</li><li>Silverlight applications offload processing to the client.
<p>Processing on the client reduces the load on the SharePoint server farm.</p>
</li><li>Silverlight isolates processing on the client </li><li>Separation of design and code.
<p>You can use the MVVM pattern to separate the presentation from the processing later. This makes it easy to change the look and feel of Silverlight applications.</p>
</li><li>Common .NET development techniques.
<p>Silverlight applications are based on the .NET framework which makes it easy for .NET developers to create them. The client object model may be used to access SharePoint resources from a Silverlight application.</p>
</li><li>Overcome Sandbox limitations.
<p>Silverlight applications may be used to overcome sandboxed limitations such as the ability to call an external service, or use parts of the .NET framework which are not permitted to run in a sandboxed solution.</p>
</li><li>Ease of deployment.
<p>Silverlight applications are very easy to deploy. Anyone with the ability to upload a document to a document library can deploy a Silverlight application to a SharePoint site. Additionally, the Silverlight Web Part makes it very easy to place Silverlight
 applications on SharePoint web pages.</p>
</li></ul>
<p>Let's see a simple project that helps us to understand how to use Silverlight along-with SharePoint.</p>
<p>A Silverlight application can be hosted inside a SharePoint site and it is called as a Silverlight WebPart.</p>
<h2>Prerequisites:</h2>
<p><a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=5970">Microsoft SharePoint Foundation 2010
</a></p>
<h2>Here are some steps to upload a Silverlight XAP to the SharePoint site:</h2>
<ol>
<li>In Visual Studio 2010, Go to File menu -&gt; New -&gt; Project -&gt; under Installed Templates -&gt; select Visual C# -&gt; under SharePoint section-&gt; 2010 -&gt; select EMPTY SHAREPOINT PROJECT.
</li><li>For example,in this case , lets name our SharePoint project as &quot;CSSharePointSilverlightIntegration&quot; .
</li><li>Then you will be asked for the URL of your SharePoint site. Enter the URL and Select the &quot;Deploy as sandboxed solution&quot; option in the dialog and click Finish.
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26277/1/2.jpg" alt="" width="606" height="482">&nbsp;</p>
</li><li>Hence, you can see the project created as in the Solution explorer of Visual Studio 2010
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26278/1/3.jpg" alt="" width="411" height="557">&nbsp;</p>
</li><li>Since our goal is to integrate Silverlight within SharePoint , let's add a Silverlight application without a website hosting it. Let's name our Silverlight application/project as &quot;SilverlightWebpart&quot;. Then our solution looks as following :
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26279/1/4.jpg" alt="" width="292" height="505">&nbsp;</p>
</li><li>Let's add the following code to &quot;MainPage.xaml&quot; file in the Silverlight project :-
<pre>     &lt;UserControl x:Class=&quot;SilverlightWebpart.MainPage&quot;
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
</li><li>Also add the following code to &quot;MainPage.xaml.cs&quot; file :-
<pre>     using System;
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
</li><li>Let's just SAVE ALL for now (and not Build). </li><li>Now, Add a Module to the SharePoint site. Right click the &quot;CSSharePointSilverlightIntegration&quot; SharePoint project and go to ADD NEW ITEM and in the dialog Select &quot;Module &quot; under installed templates for SharePoint -&gt; 2010 .
</li><li>Name the Module as &quot;DemoModule&quot;.
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26280/1/5.jpg" alt="">&nbsp;</p>
</li><li>After we add the Module it would contain two files under it by default:-
<ul>
<li>Elements.xml </li><li>Sample.txt </li></ul>
</li><li>It's ok if you delete the Sample.txt file. </li><li>Again lets do SAVE ALL . </li><li>Let's jump to our Silverlight project &quot;SilverlightWebpart&quot; and right click it in the solution explorer window and select Properties.
</li><li>Go to the &quot;Build Events&quot; tab and click the &quot;Edit Post-build&hellip;&quot; button and enter the following line in the dialog that appears :- copy &quot;$(TargetDir)SilverlightWebpart.xap&quot; &quot;$(SolutionDir)CSSharePointSilverlightIntegration\DemoModule&quot;
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26281/1/6.jpg" alt="" width="1017" height="383">&nbsp;</p>
</li><li>Click OK and Save it. </li><li>Adding the above content in the post-build events ensures that the visual studio adds the latest build of the XAP file generated from the &quot;SilverlightWebpart&quot; application to the &quot;DemoModule&quot; section of the &quot;CSSharePointSilverlightIntegration&quot; project.
</li><li>So now if we build the Silverlight project, we would find the &quot;SilverlightWebpart.xap&quot; file under the &quot;DemoModule&quot;.
</li><li>Make sure the XAP file is included in the Module as following :
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26283/1/16.jpg" alt="" width="444" height="383">&nbsp;</p>
</li><li>Now lets build the entire solution and then try to deploy the &quot;CSSharePointSilverlightIntegration&quot; project to the SharePoint site.
</li><li>To achieve this, right-click the &quot;CSSharePointSilverlightIntegration&quot; project and click &quot;Deploy&quot;
</li><li>Now the &quot;CSSharePointSilverlightIntegration&quot; project is deployed in the SharePoint site.
</li><li>Let's open the SharePoint site in the browser and select &quot;Page&quot;
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26284/1/11.jpg" alt="" width="1242" height="790">&nbsp;</p>
</li><li>Select Edit.
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26285/1/12.jpg" alt="" width="1256" height="790">&nbsp;</p>
</li><li>Having done that Select &quot;Insert&quot; tab and click &quot;Web Part&quot; .
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26286/1/13.jpg" alt="" width="1259" height="642">&nbsp;</p>
</li><li>In &quot;Categories&quot;, select &quot;Media and content&quot; and correspondingly in &quot;Web Parts&quot; column, Select &quot;Silverlight Web Part&quot; Having Selected the &quot;Silverlight Web Part&quot; , click on &quot;Add&quot; button that appears on the right side.
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26287/1/14.jpg" alt="" width="1324" height="761">&nbsp;</p>
</li><li>After clicking add, a small pop-up will appear asking for the URL of the Silverlight content(.xap) file. Enter the URL in the following format as :0
<a href="http://MySharePointSite/DemoModule/SilverlightWebpart.xap">http://MySharePointSite/DemoModule/SilverlightWebpart.xap</a>
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26288/1/15.jpg" alt="" width="700">&nbsp;</p>
</li><li>Then click OK and then you can see your Silverlight web part appear in the SharePoint site as :
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26289/1/17.jpg" alt="" width="1298" height="558">&nbsp;</p>
</li><li>As you can see the blue border is the boundary of the Silverlight web part and the Silverlight application has a button in it. When you click the button, it acts like a normal Silverlight application and responds to the user interaction and a Message Box
 is popped, for which we wrote code in &quot;MainPage.xaml.cs&quot;.
<p><img src="http://i1.code.msdn.s-msft.com/cssharepointsilverlightinte-88fd7b56/image/file/26290/1/18.jpg" alt=""></p>
<p>&nbsp;</p>
</li></ol>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
