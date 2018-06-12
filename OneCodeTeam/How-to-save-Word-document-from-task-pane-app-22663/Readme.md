# How to save Word document from task pane app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Task Pane App
* Save word
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:43:43
## Description

<h1>How to save Word document from task pane App (JSO15SaveWordDocument)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This demonstration shows how to save a Word document from the task pane App by using JavaScript. The JavaScript API for Office provide
<a href="http://msdn.microsoft.com/en-us/library/jj715284.aspx">Document.getFileAsync</a> method to receive the Word document as a byte array or retrieve the text of the Word document as a string. Then you can call WCF Service to save Word document on client
 computer.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Install Office 2013 RTM and Install Visual Studio 2012 RTM</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA">Download</a> and Install Microsoft Office Developer Tools for Visual Studio 2012-Preview 2</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Open JSO15SaveWordDocument.sln to open the solution. Press &quot;F5&quot; on the keyboard to run the project. The form resembles the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84659/1/image.png" alt="" width="576" height="467" align="middle">
</span></p>
<p class="MsoNormal">Step2. Edit the Word document. After you have finished editing the document, click the &quot;Save All Content&quot; button to save the Word document on client computer. When the document is successfully saved, you will receive a &quot;Save
<span class="GramE">All</span> content of Word document successfully! The Save Path is:&quot; message.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84660/1/image.png" alt="" width="576" height="428" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create an App for Office 2013 project by using Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Design the UI of the Task Pane by using the following HTML code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
      
         &lt;input type=&quot;button&quot; value=&quot;Save All Content&quot; id=&quot;saveAllBtn&quot; style=&quot;margin-right: 20px; padding: 0px; width: 150px;&quot; /&gt;
        <br>
        <br>
       <span>Results: </span><div id="results"></div>
    </div>
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
      
         &lt;input type=&quot;button&quot; value=&quot;Save All Content&quot; id=&quot;saveAllBtn&quot; style=&quot;margin-right: 20px; padding: 0px; width: 150px;&quot; /&gt;
        <br>
        <br>
       <span>Results: </span><div id="results"></div>
    </div>
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step2. Create a WCF Service by using the following code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace JsSaveWordWeb
{
    // NOTE: You can use the &quot;Rename&quot; command on the &quot;Refactor&quot; menu to change the class name &quot;SaveWordService&quot; in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaveWordService.svc or SaveWordService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SaveWordService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string SaveAllContent(string bytestring)
        {
            string[] bytestrings = bytestring.Split(',');
            int length = bytestrings.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i &lt; length; i&#43;&#43;)
            {
                buffer[i] = Convert.ToByte(bytestrings[i]);
            }


            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &#43; &quot;\\Copy.docx&quot;;
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }


            using (FileStream savestream = new FileStream(savePath, FileMode.Create))
            {
                savestream.Write(buffer, 0, length);
            }


            return savePath;
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace JsSaveWordWeb
{
    // NOTE: You can use the &quot;Rename&quot; command on the &quot;Refactor&quot; menu to change the class name &quot;SaveWordService&quot; in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaveWordService.svc or SaveWordService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SaveWordService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string SaveAllContent(string bytestring)
        {
            string[] bytestrings = bytestring.Split(',');
            int length = bytestrings.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i &lt; length; i&#43;&#43;)
            {
                buffer[i] = Convert.ToByte(bytestrings[i]);
            }


            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &#43; &quot;\\Copy.docx&quot;;
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }


            using (FileStream savestream = new FileStream(savePath, FileMode.Create))
            {
                savestream.Write(buffer, 0, length);
            }


            return savePath;
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Configure the configuration file according to the following XML code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;configuration&gt;
  &lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
  &lt;/system.web&gt;


  &lt;system.serviceModel&gt;
    &lt;bindings&gt;
      &lt;webHttpBinding&gt;
        &lt;binding name=&quot;webBinding&quot; maxReceivedMessageSize=&quot;4194304&quot;&gt;
        &lt;/binding&gt;
      &lt;/webHttpBinding&gt;
    &lt;/bindings&gt;
    &lt;behaviors&gt;
      &lt;serviceBehaviors&gt;
        &lt;behavior name=&quot;svc1&quot;&gt;
          &lt;serviceMetadata httpGetEnabled=&quot;true&quot; /&gt;
          &lt;serviceDebug includeExceptionDetailInFaults=&quot;false&quot; /&gt;
        &lt;/behavior&gt;
      &lt;/serviceBehaviors&gt;
      &lt;endpointBehaviors&gt;
        &lt;behavior name=&quot;SaveBehavior&quot;&gt;
          &lt;enableWebScript/&gt;
        &lt;/behavior&gt;
      &lt;/endpointBehaviors&gt;
    &lt;/behaviors&gt;
 
    &lt;services&gt;
      &lt;service name=&quot;JSO15SaveWordDocumentWeb.SaveWordService&quot; behaviorConfiguration=&quot;svc1&quot; &gt;
        &lt;endpoint address=&quot;&quot; behaviorConfiguration=&quot;SaveBehavior&quot; binding=&quot;webHttpBinding&quot; 
bindingConfiguration=&quot;webBinding&quot; contract=&quot;JSO15SaveWordDocumentWeb.SaveWordService&quot;&gt;
        &lt;/endpoint&gt;
      &lt;/service&gt;
    &lt;/services&gt;
  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;configuration&gt;
  &lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
  &lt;/system.web&gt;


  &lt;system.serviceModel&gt;
    &lt;bindings&gt;
      &lt;webHttpBinding&gt;
        &lt;binding name=&quot;webBinding&quot; maxReceivedMessageSize=&quot;4194304&quot;&gt;
        &lt;/binding&gt;
      &lt;/webHttpBinding&gt;
    &lt;/bindings&gt;
    &lt;behaviors&gt;
      &lt;serviceBehaviors&gt;
        &lt;behavior name=&quot;svc1&quot;&gt;
          &lt;serviceMetadata httpGetEnabled=&quot;true&quot; /&gt;
          &lt;serviceDebug includeExceptionDetailInFaults=&quot;false&quot; /&gt;
        &lt;/behavior&gt;
      &lt;/serviceBehaviors&gt;
      &lt;endpointBehaviors&gt;
        &lt;behavior name=&quot;SaveBehavior&quot;&gt;
          &lt;enableWebScript/&gt;
        &lt;/behavior&gt;
      &lt;/endpointBehaviors&gt;
    &lt;/behaviors&gt;
 
    &lt;services&gt;
      &lt;service name=&quot;JSO15SaveWordDocumentWeb.SaveWordService&quot; behaviorConfiguration=&quot;svc1&quot; &gt;
        &lt;endpoint address=&quot;&quot; behaviorConfiguration=&quot;SaveBehavior&quot; binding=&quot;webHttpBinding&quot; 
bindingConfiguration=&quot;webBinding&quot; contract=&quot;JSO15SaveWordDocumentWeb.SaveWordService&quot;&gt;
        &lt;/endpoint&gt;
      &lt;/service&gt;
    &lt;/services&gt;
  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Code the event handle by using the following JavaScript code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
Office.initialize = function (reason) {
    $(document).ready(function () {
        // Save All Word document on client by using JS
        $('#saveAllBtn').click(function () {
            // Clear message
            writeToPage(&quot;&quot;);
            saveAllDocument();
        });
    });
};


// Get All content in word document and save as word document
function saveAllDocument() {
    var i = 0;
    var slices = 0;
    var myFile;


    // Office.FileType.Compressed returns the entire document as a byte array(word or powerpoint)
    Office.context.document.getFileAsync(Office.FileType.Compressed, function (result) {
        if (result.status == &quot;succeeded&quot;) {
            // If the getFileAsync call succeeded, then
            // result.value will return a valid File Object.
            myFile = result.value;
            slices = myFile.sliceCount;


            // Iterate over the file slices.
            for (i = 0; i &lt; slices; i&#43;&#43;) {
                var slice = myFile.getSliceAsync(i, function (result) {
                    if (result.status == &quot;succeeded&quot;) {
                        saveAllContent(result.value.data.toString());
                    }
                    else {
                        writeToPage(&quot;Error: &quot; &#43; result.error.message);
                    }
                });
            }
            myFile.closeAsync();
        }
        else {
            writeToPage(&quot;Error: &quot; &#43; result.error.message);
        }
    });
}


// Call WCF Service to save All Content of Word document
function saveAllContent(content) {
    $.ajax({  
        type: 'post',
        url: '/SaveWordService.svc/SaveAllContent',
        contentType: 'text/json',
        data: '{&quot;bytestring&quot;:&quot;' &#43; content &#43; '&quot;}',
        success: function (result) {
            writeToPage(&quot;Save All content of Word document successfully!The Save Path is: &quot; &#43; String(result.d));
        },
        error: function (XMLHttpRequest, textStatus) {
            writeToPage(&quot;Error: &quot; &#43; XMLHttpRequest.statusText);
        }
    });
}


// Write Message
function writeToPage(text) {
    $('#results')[0].innerText = text;
    $('#results').css(&quot;color&quot;, &quot;red&quot;);
}

</pre>
<pre id="codePreview" class="js">
Office.initialize = function (reason) {
    $(document).ready(function () {
        // Save All Word document on client by using JS
        $('#saveAllBtn').click(function () {
            // Clear message
            writeToPage(&quot;&quot;);
            saveAllDocument();
        });
    });
};


// Get All content in word document and save as word document
function saveAllDocument() {
    var i = 0;
    var slices = 0;
    var myFile;


    // Office.FileType.Compressed returns the entire document as a byte array(word or powerpoint)
    Office.context.document.getFileAsync(Office.FileType.Compressed, function (result) {
        if (result.status == &quot;succeeded&quot;) {
            // If the getFileAsync call succeeded, then
            // result.value will return a valid File Object.
            myFile = result.value;
            slices = myFile.sliceCount;


            // Iterate over the file slices.
            for (i = 0; i &lt; slices; i&#43;&#43;) {
                var slice = myFile.getSliceAsync(i, function (result) {
                    if (result.status == &quot;succeeded&quot;) {
                        saveAllContent(result.value.data.toString());
                    }
                    else {
                        writeToPage(&quot;Error: &quot; &#43; result.error.message);
                    }
                });
            }
            myFile.closeAsync();
        }
        else {
            writeToPage(&quot;Error: &quot; &#43; result.error.message);
        }
    });
}


// Call WCF Service to save All Content of Word document
function saveAllContent(content) {
    $.ajax({  
        type: 'post',
        url: '/SaveWordService.svc/SaveAllContent',
        contentType: 'text/json',
        data: '{&quot;bytestring&quot;:&quot;' &#43; content &#43; '&quot;}',
        success: function (result) {
            writeToPage(&quot;Save All content of Word document successfully!The Save Path is: &quot; &#43; String(result.d));
        },
        error: function (XMLHttpRequest, textStatus) {
            writeToPage(&quot;Error: &quot; &#43; XMLHttpRequest.statusText);
        }
    });
}


// Write Message
function writeToPage(text) {
    $('#results')[0].innerText = text;
    $('#results').css(&quot;color&quot;, &quot;red&quot;);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">Document.getFileAsync method (apps for Office)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/jj715284.aspx">http://msdn.microsoft.com/en-us/library/jj715284.aspx</a>
</p>
<p class="MsoNormal" style="line-height:12.75pt"><span style="color:black">Use the REST Endpoint with Ajax and<span class="apple-converted-space">&nbsp;</span>JScript<span class="apple-converted-space">&nbsp;</span>Web Resources
</span></p>
<p class="MsoNormal" style="line-height:12.75pt"><span style="color:black"><a href="http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad">http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad</a>
</span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
