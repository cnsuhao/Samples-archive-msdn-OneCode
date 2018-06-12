# Create a custom asynchronous code activity
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Workflow
* .NET Development
## Topics
* Async Code Activity
## IsPublished
* True
## ModifiedDate
* 2013-08-05 12:44:38
## Description

<h1>WF4 Async Http Get Activity(CSWF4AsyncHttpGetActivity)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This&nbsp;sample&nbsp;is&nbsp;created&nbsp;for&nbsp;two&nbsp;purposes.&nbsp;</p>
<p class="MsoNormal">1.&nbsp;Demostrate&nbsp;how&nbsp;to&nbsp;create&nbsp;an&nbsp;asynchronous&nbsp;WF4&nbsp;activity&nbsp;and&nbsp;use&nbsp;it&nbsp;in&nbsp;workflow.&nbsp;<br>
2.&nbsp;provide&nbsp;a&nbsp;usable&nbsp;Http&nbsp;Get&nbsp;Activity.&nbsp;so&nbsp;that&nbsp;you&nbsp;can&nbsp;use&nbsp;it&nbsp;directly&nbsp;in&nbsp;your&nbsp;project.&nbsp;</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1.&nbsp;Open&nbsp;CSWF4ServiceHostFactory.sln&nbsp;with&nbsp;Visual&nbsp;Studio&nbsp;2012<br>
2.&nbsp;Press&nbsp;Ctrl&#43;F5.<span style=""> </span></p>
<p class="MsoNormal"><span style="">You will see that the custom code activity get the html text as shown in the following screen shot.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93813/1/image.png" alt="" width="576" height="376" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1.&nbsp;Create&nbsp;a&nbsp;new&nbsp;Workflow&nbsp;Console&nbsp;Application&nbsp;project&nbsp;named&nbsp;CSWF4AsyncHttpGetActivity.&nbsp;<br>
2.&nbsp;Create&nbsp;a&nbsp;new&nbsp;code&nbsp;file&nbsp;named&nbsp;AsyncHttpGet.cs.&nbsp;<br>
3.&nbsp;Fill&nbsp;the&nbsp;AsyncHttpGet.cs&nbsp;file&nbsp;with&nbsp;the&nbsp;following&nbsp;code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System.Activities;
using System;
using System.Net;
using System.IO;


namespace CSWF4AsyncHttpGetActivity {
    public class AsyncHttpGetActivity:AsyncCodeActivity&lt;string&gt; {
        public InArgument&lt;string&gt; Uri { get; set; }
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, 
                                                     AsyncCallback            callback, 
                                                     object                   state) {
            WebRequest request = HttpWebRequest.Create(this.Uri.Get(context));
            context.UserState = request;
            return request.BeginGetResponse(callback, state);    
        }


        protected override string EndExecute(AsyncCodeActivityContext context, 
                                             IAsyncResult             result) {
            WebRequest request = context.UserState as WebRequest;
            using (WebResponse response = request.EndGetResponse(result)) {
                using (StreamReader reader = 
                    new StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
using System.Activities;
using System;
using System.Net;
using System.IO;


namespace CSWF4AsyncHttpGetActivity {
    public class AsyncHttpGetActivity:AsyncCodeActivity&lt;string&gt; {
        public InArgument&lt;string&gt; Uri { get; set; }
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, 
                                                     AsyncCallback            callback, 
                                                     object                   state) {
            WebRequest request = HttpWebRequest.Create(this.Uri.Get(context));
            context.UserState = request;
            return request.BeginGetResponse(callback, state);    
        }


        protected override string EndExecute(AsyncCodeActivityContext context, 
                                             IAsyncResult             result) {
            WebRequest request = context.UserState as WebRequest;
            using (WebResponse response = request.EndGetResponse(result)) {
                using (StreamReader reader = 
                    new StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">4. Build the project.<br>
5<span style="">.</span> Open the default created Workflow1.xaml and create<span style="">s</span> workflow as shown in Workflow1.xaml.<span style="">
</span></p>
<p class="MsoNormal" style=""><span style=""><img src="/site/view/file/93814/1/image.png" alt="" width="305" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style=""><span style="">6. Click <span class="SpellE">AsyncHttpGetActivity</span> and change its URI properties as shown in the following picture.<br>
</span><span style=""><img src="/site/view/file/93815/1/image.png" alt="" width="458" height="29" align="middle">
</span><br>
<span style="">7</span>. Press Ctrl&#43;F5 to run the sample. <span style=""></span></p>
<p class="MsoNormal"><span style="">For more information about <span class="SpellE">
AsyncCodeActivity</span> Class please see also<span class="GramE">:</span><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.activities.asynccodeactivity.aspx">http://msdn.microsoft.com/en-us/library/system.activities.asynccodeactivity.aspx</a><span style="">
</span></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
