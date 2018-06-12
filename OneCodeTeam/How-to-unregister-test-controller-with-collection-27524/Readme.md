# How to unregister test controller with team project collection using TFS APIs
## Requires
* Visual Studio 2012
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
* 2014-03-03 11:01:00
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to unregister test controller
</span><span style="font-weight:bold; font-size:14pt">from </span><span style="font-weight:bold; font-size:14pt">team project collection using TFS APIs</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample demonstrate</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> how</span><span style="font-size:11pt"> to</span><span style="font-size:11pt">
</span><span style="font-size:11pt">un</span><span style="font-size:11pt">register Test Controller from team project collection using TFS APIs.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Run the sample code from command prompt.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Provide the team project collection as an argument
</span><span style="">for</span><span style="font-size:11pt"> the exe.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then it will display the already registered test controllers with the team project collection.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Select the number against the controller which you want to unregister.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then select number </span>
<span style="font-size:11pt">'</span><span style="font-size:11pt">2</span><span style="font-size:11pt">'</span><span style="font-size:11pt"> which is for unregister operation.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">TfsTeamProjectCollection Class</span><span style="font-size:11pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
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
            Console.Out.WriteLine(&quot;2    UnRegister&quot;);
            Console.Out.WriteLine(&quot;3    Update&quot;);
            int propertyManipulate = Int32.Parse(Console.ReadLine());
            switch (propertyManipulate)
            {
                case 2:
                    selectedController = selectedController - 1;
                    int j = 0;
                    foreach (var testController in testControllers)
                    {
                        if (j == selectedController)
                        {
                            testController.Unregister();
                            break;
                        }
                        j = j &#43; 1;
                    }
                    break;
                case 3:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 1:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error while performing the operation: &quot; &#43; e.Message);
    }
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
            Console.Out.WriteLine(&quot;2    UnRegister&quot;);
            Console.Out.WriteLine(&quot;3    Update&quot;);
            int propertyManipulate = Int32.Parse(Console.ReadLine());
            switch (propertyManipulate)
            {
                case 2:
                    selectedController = selectedController - 1;
                    int j = 0;
                    foreach (var testController in testControllers)
                    {
                        if (j == selectedController)
                        {
                            testController.Unregister();
                            break;
                        }
                        j = j &#43; 1;
                    }
                    break;
                case 3:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
                case 1:
                    Console.WriteLine(&quot;Sorry..Not in the scope of current sample, will be implemented later&quot;);
                    break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error while performing the operation: &quot; &#43; e.Message);
    }
}
    }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">TfsTeamProjectCollection Class</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollection.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollection.aspx</span></a><span style="">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ITestManagementService Interface</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.aspx</span></a><span style="">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ITestController Interface</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestcontroller.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestcontroller.aspx</span></a><span style="">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Application Lifecycle Management with Visual S</span><span style="font-size:11pt">tudio Team Foundation Server</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/library/vstudio/fda2bad5" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/library/vstudio/fda2bad5</span></a><span style="font-size:11pt">
</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">ITestManagementService</span><span style="font-size:11pt">.</span><span style="font-size:11pt">TestControllers Property
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.testcontrollers.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.testmanagement.client.itestmanagementservice.testcontrollers.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
