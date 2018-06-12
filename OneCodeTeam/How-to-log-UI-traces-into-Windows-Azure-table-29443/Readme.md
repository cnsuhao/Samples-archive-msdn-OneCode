# How to log UI traces into Windows Azure table storage
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Azure
* Cloud
## Topics
* Microsoft Azure
* Web
* Logging
* Table Storage
## IsPublished
* True
## ModifiedDate
* 2014-06-23 10:03:43
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to log UI traces into Windows Azure table storage
</span><span style="font-weight:bold; font-size:14pt">(</span><span style="font-weight:bold; font-size:14pt">VBAzureJSLogging</span><span style="font-weight:bold; font-size:14pt">)</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">This sample shows how to add Web UI traces into Azure table storage.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Azure now support</span><span style="font-size:11pt">s CORS.</span><span style="font-size:11pt">
</span><span style="font-size:11pt">It&rsquo;s</span><span style="font-size:11pt"> easy to use JavaScript</span><span style="font-size:11pt"> to</span><span style="font-size:11pt"> create a JS logging Framework based on Azure table storage.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample will demonstrate how to use JavaScript
</span><span style="font-size:11pt">to </span><span style="font-size:11pt">add log to Azure table storage.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You need rebuild this sample first,</span><span style="font-size:11pt"> then</span><span style="font-size:11pt"> the project will download necessary libraries.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You need to open the solution, find AzureClient.cs/vb file, and change the parameters to your Azure storage account and Azure storage account key first.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then you can run the sample directly.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You will see the images below:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117428/1/image.png" alt="" width="575" height="227" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can add </span><span style="font-size:11pt">some message into the text box.</span><span style="font-size:11pt">
</span><span style="font-size:11pt">T</span><span style="font-size:11pt">he text will
</span><span style="font-size:11pt">be </span><span style="font-size:11pt">upload</span><span style="font-size:11pt">ed</span><span style="font-size:11pt"> to your Azure storage account logs table.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code</span><span style="font-size:11pt"> snippet</span><a name="_GoBack"></a><span style="font-size:11pt"> shows how to enable table storage CORS feature.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">/// &lt;summary&gt;
        /// Adds CORS rule to the service properties.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;serviceProperties&quot;&gt;ServiceProperties&lt;/param&gt;
        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List&lt;string&gt;() { &quot;*&quot; },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List&lt;string&gt;() { &quot;*&quot; },
                ExposedHeaders = new List&lt;string&gt;() { &quot;*&quot; },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }
</pre>
<pre class="hidden">''' &lt;summary&gt;
   ''' Adds CORS rule to the service properties.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;serviceProperties&quot;&gt;ServiceProperties&lt;/param&gt;
   Private Shared Sub ConfigureCors(serviceProperties As ServiceProperties)
       serviceProperties.Cors = New CorsProperties()
       ' 30 minutes
       serviceProperties.Cors.CorsRules.Add(New CorsRule() With { _
            .AllowedHeaders = New List(Of String)() From { _
               &quot;*&quot; _
           }, _
            .AllowedMethods = CorsHttpMethods.Put Or CorsHttpMethods.[Get] Or CorsHttpMethods.Head Or CorsHttpMethods.Post, _
            .AllowedOrigins = New List(Of String)() From { _
               &quot;*&quot; _
           }, _
            .ExposedHeaders = New List(Of String)() From { _
               &quot;*&quot; _
           }, _
            .MaxAgeInSeconds = 1800 _
       })
   End Sub
</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
        /// Adds CORS rule to the service properties.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;serviceProperties&quot;&gt;ServiceProperties&lt;/param&gt;
        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List&lt;string&gt;() { &quot;*&quot; },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List&lt;string&gt;() { &quot;*&quot; },
                ExposedHeaders = new List&lt;string&gt;() { &quot;*&quot; },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code</span><span style="font-size:11pt"> snippet</span><span style="font-size:11pt"> show</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> how to request a SAS URL, then
 use this URL upload log message to Azure table storage.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">&lt;script type=&quot;text/javascript&quot;&gt;
function addTableEntity(jsonString, tableSasUrl) {
    $.ajax({
        type: 'POST',
        datatype: &quot;json&quot;,
        data: jsonString,
        url: tableSasUrl,
        beforeSend: setHeader,
        success: function (data, status, xhr) {
            alert(&quot;upload to Azure table storage success!&quot;);
        },
        error: function (data, status, xhr) {
            alert(&quot;upload to Azure table storage failed!&quot;);
        }
    });
}
function setHeader(xhr) {
    xhr.setRequestHeader('x-ms-version', '2013-08-15');
    xhr.setRequestHeader('MaxDataServiceVersion', '3.0');
    xhr.setRequestHeader('Accept', 'application/json;odata=nometadata');
    xhr.setRequestHeader('Content-Type', 'application/json;odata=nometadata');
}
function addLogtoTableStorage() {
    var tableSasApiUrl = '@Url.RouteUrl(&quot;DefaultApi&quot;, New With {.httproute = &quot;&quot;, .controller = &quot;tablesas&quot;})';
    var entity = {
        PartitionKey: 'default',
        RowKey: (new Date()).getTime().toString(),
        log: $(&quot;#txtLogItem&quot;).val()
    };
    alert(tableSasApiUrl);
    $.ajax({
        type: 'GET',
        url: tableSasApiUrl,
        dataType:'json',
        success: function (data, states, xhr) {
            if (xhr.responseText != &quot;&quot;) {
                alert(data.SASTokenUrl)
                addTableEntity(JSON.stringify(entity), data.SASTokenUrl);
            }
            return xhr.responseText;
        },
        error: function (data, status, xhr) {
            alert(&quot;can't get SAS for table&quot;);
        }
    })
}
&lt;/script&gt;
</pre>
<pre id="codePreview" class="js">&lt;script type=&quot;text/javascript&quot;&gt;
function addTableEntity(jsonString, tableSasUrl) {
    $.ajax({
        type: 'POST',
        datatype: &quot;json&quot;,
        data: jsonString,
        url: tableSasUrl,
        beforeSend: setHeader,
        success: function (data, status, xhr) {
            alert(&quot;upload to Azure table storage success!&quot;);
        },
        error: function (data, status, xhr) {
            alert(&quot;upload to Azure table storage failed!&quot;);
        }
    });
}
function setHeader(xhr) {
    xhr.setRequestHeader('x-ms-version', '2013-08-15');
    xhr.setRequestHeader('MaxDataServiceVersion', '3.0');
    xhr.setRequestHeader('Accept', 'application/json;odata=nometadata');
    xhr.setRequestHeader('Content-Type', 'application/json;odata=nometadata');
}
function addLogtoTableStorage() {
    var tableSasApiUrl = '@Url.RouteUrl(&quot;DefaultApi&quot;, New With {.httproute = &quot;&quot;, .controller = &quot;tablesas&quot;})';
    var entity = {
        PartitionKey: 'default',
        RowKey: (new Date()).getTime().toString(),
        log: $(&quot;#txtLogItem&quot;).val()
    };
    alert(tableSasApiUrl);
    $.ajax({
        type: 'GET',
        url: tableSasApiUrl,
        dataType:'json',
        success: function (data, states, xhr) {
            if (xhr.responseText != &quot;&quot;) {
                alert(data.SASTokenUrl)
                addTableEntity(JSON.stringify(entity), data.SASTokenUrl);
            }
            return xhr.responseText;
        },
        error: function (data, status, xhr) {
            alert(&quot;can't get SAS for table&quot;);
        }
    })
}
&lt;/script&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><a href="http://blogs.msdn.com/b/windowsazurestorage/archive/2014/02/03/windows-azure-storage-introducing-cors.aspx" target="_blank">http://blogs.msdn.com/b/windowsazurestorage/archive/2014/02/03/windows-azure-storage-introducing-cors.aspx</a></span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
