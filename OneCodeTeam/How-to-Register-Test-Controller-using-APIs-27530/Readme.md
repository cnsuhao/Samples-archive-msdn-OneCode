# How to Register Test Controller using TFS APIs
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* .NET Framework 4.5
* .NET Development
## Topics
* TFS
## IsPublished
* True
## ModifiedDate
* 2014-04-10 01:33:52
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to register Test controller with team project collection using TFS APIs</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We can programmatically register the test controller with TFS using APIs.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Just build the solution with V</span><span style="font-size:11pt">isual
</span><span style="font-size:11pt">S</span><span style="font-size:11pt">tudio </span>
<span style="font-size:11pt">2012</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Run the sample and provide the collection name.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Note: if you don't provide the collection name, you'll see a message</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><span style="color:#A31515; font-size:11pt">&quot;Usage: RegisterTestController &lt;collectionUrl&gt;&quot;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Select the option for register</span><span style="font-size:11pt">ing</span><span style="font-size:11pt"> the controller.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">It will then register the controller.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Following code snippet shows how to register</span><span style="font-size:11pt"> test controller with TFS using APIs.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static void Main(string[] args)
{
    if (args.Length != 1)
    {
        Console.Error.WriteLine(&quot;Usage: FindTestControllers &lt;collectionUrl&gt;&quot;);
        Environment.Exit(-1);
    }
    string tfsUri = args[0];
    int i = 0;
    try
    {
        listController = new string[256];
        using (TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri(tfsUri)))
        {
            testManagementService = collection.GetService&lt;ITestManagementService&gt;();
            testControllers = testManagementService.TestControllers.Query();
            foreach (var testController in testControllers)
            {
                i = i &#43; 1;
                Console.Out.Write(i);
                Console.Out.Write(&quot;   &quot;);
                Console.Out.Write(testController.Name);
                Console.Out.WriteLine();
                listController[i - 1] = testController.Name;
            }
            // Select the controller which you want to manipulate
            // So from the list, select the number 1, 2, or..
            Console.Out.WriteLine(&quot;Select the controller you want to manipulate properties for..(select the number above)&quot;);
            selectedController = Int32.Parse(Console.ReadLine());
            Console.Out.WriteLine(listController[selectedController - 1]);
            Console.Out.WriteLine(&quot;Select any of the below for manipulating the selected controller&quot;);
            Console.Out.WriteLine(&quot;1    Register&quot;);
            Console.Out.WriteLine(&quot;2    Unregister&quot;);
            Console.Out.WriteLine(&quot;3    Update&quot;);
            int propertyManipulate = Int32.Parse(Console.ReadLine());
            switch (propertyManipulate)
            {
                case 2:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 3:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 1:
                    string controllerName = Console.ReadLine();
                    ITestManagementService testManagementService1;
                    ITestController testControllers2;
                    using (TfsTeamProjectCollection collection1 = new TfsTeamProjectCollection(new Uri(tfsUri)))
                    {
                        testManagementService1 = collection1.GetService&lt;ITestManagementService&gt;();
                        //testControllers1 = testManagementService1.TestControllers.Query();
                        testControllers2 = testManagementService1.TestControllers.Create();
                        testControllers2.Name = controllerName;
                        List&lt;ITestController&gt; icollection = new List&lt;ITestController&gt;();
                        icollection.Add(testControllers2);
                        testManagementService1.TestControllers.Register(icollection);
                    }
                    break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error while performing the operation: &quot; &#43; e.Message);
    }
}
</pre>
<pre id="codePreview" class="csharp">
static void Main(string[] args)
{
    if (args.Length != 1)
    {
        Console.Error.WriteLine(&quot;Usage: FindTestControllers &lt;collectionUrl&gt;&quot;);
        Environment.Exit(-1);
    }
    string tfsUri = args[0];
    int i = 0;
    try
    {
        listController = new string[256];
        using (TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri(tfsUri)))
        {
            testManagementService = collection.GetService&lt;ITestManagementService&gt;();
            testControllers = testManagementService.TestControllers.Query();
            foreach (var testController in testControllers)
            {
                i = i &#43; 1;
                Console.Out.Write(i);
                Console.Out.Write(&quot;   &quot;);
                Console.Out.Write(testController.Name);
                Console.Out.WriteLine();
                listController[i - 1] = testController.Name;
            }
            // Select the controller which you want to manipulate
            // So from the list, select the number 1, 2, or..
            Console.Out.WriteLine(&quot;Select the controller you want to manipulate properties for..(select the number above)&quot;);
            selectedController = Int32.Parse(Console.ReadLine());
            Console.Out.WriteLine(listController[selectedController - 1]);
            Console.Out.WriteLine(&quot;Select any of the below for manipulating the selected controller&quot;);
            Console.Out.WriteLine(&quot;1    Register&quot;);
            Console.Out.WriteLine(&quot;2    Unregister&quot;);
            Console.Out.WriteLine(&quot;3    Update&quot;);
            int propertyManipulate = Int32.Parse(Console.ReadLine());
            switch (propertyManipulate)
            {
                case 2:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 3:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 1:
                    string controllerName = Console.ReadLine();
                    ITestManagementService testManagementService1;
                    ITestController testControllers2;
                    using (TfsTeamProjectCollection collection1 = new TfsTeamProjectCollection(new Uri(tfsUri)))
                    {
                        testManagementService1 = collection1.GetService&lt;ITestManagementService&gt;();
                        //testControllers1 = testManagementService1.TestControllers.Query();
                        testControllers2 = testManagementService1.TestControllers.Create();
                        testControllers2.Name = controllerName;
                        List&lt;ITestController&gt; icollection = new List&lt;ITestController&gt;();
                        icollection.Add(testControllers2);
                        testManagementService1.TestControllers.Register(icollection);
                    }
                    break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error while performing the operation: &quot; &#43; e.Message);
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Managing Test Controllers and Test Agents with Visual Studio
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd695837.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/dd695837.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold; font-size:11pt">ITestManagementService</span><span style="font-size:11pt"> Interface</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold; font-size:11pt">TfsTeamProjectCollection
</span><span style="font-size:11pt">Class </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollection.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollection.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
