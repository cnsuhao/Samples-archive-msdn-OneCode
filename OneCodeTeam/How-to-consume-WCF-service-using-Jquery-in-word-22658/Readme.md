# How to consume WCF service using Jquery in word 2013
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* WCF Service
* Word 2013
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:39:04
## Description

<h1>How to consume a WCF Service by using jQuery in Word 2013 (JsCallWCFInWord2013)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The demonstration shows how to consume a WCF Service by using jQuery in Word 2013. This code was created by using the WCF Service together with an add function that receives two arguments and returns double type. The WCF Service is called
 by using the ajax function of jQuery.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Install Office 2013 RTM and Install Visual Studio 2012 RTM</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA">Download</a> and Install Microsoft Office Developer Tools for Visual Studio 2012-Preview 2.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Open JsCallWCFInWord2013.sln to open the solution and press &quot;F5&quot; on the keyboard to run the project. The form resembles the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84572/1/image.png" alt="" width="576" height="427" align="middle">
</span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step2. Input two numbers in the text box. If you do not input a number and then click the &quot;=&quot; button, you will receive a &quot;<span style="color:red">left number or right number can not be null</span>&quot; error message. If
 you do not input a number, you will receive a &quot;<span style="color:red">please input number</span>&quot; error message.</p>
<p class="MsoNormal">Step3. If you input the correct number in the text box, and then click the &quot;=' button, you will receive the sum of the two numbers.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84573/1/image.png" alt="" width="576" height="427" align="middle">
</span></p>
<p class="MsoNormal">Step4. If you successfully receive the returned result from the WCF service, click the &quot;Set Data&quot; button to write the result to the current selection in the document.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84574/1/image.png" alt="" width="576" height="429" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create an App for Office 2013 project by using Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Create WCF Service by using the following code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace jQueryWCF
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFservice
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public double Add(double left, double right)
        {
            return left &#43; right;
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;


namespace jQueryWCF
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFservice
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public double Add(double left, double right)
        {
            return left &#43; right;
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Configure the configuration file by using the following xml code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot;?&gt;
&lt;configuration&gt;
  &lt;appSettings/&gt;
  &lt;connectionStrings/&gt;
  &lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot;&gt;
    &lt;/compilation&gt;
  &lt;/system.web&gt;
  &lt;system.serviceModel&gt;
    &lt;behaviors&gt;
      &lt;endpointBehaviors&gt;
        &lt;behavior name=&quot;AllenBehavior&quot;&gt;
          &lt;enableWebScript /&gt;
        &lt;/behavior&gt;
      &lt;/endpointBehaviors&gt;
    &lt;/behaviors&gt;
    &lt;serviceHostingEnvironment aspNetCompatibilityEnabled=&quot;true&quot; /&gt;
    &lt;services&gt;
      &lt;service name=&quot;jQueryWCF.WCFservice&quot;&gt;
        &lt;endpoint address=&quot;&quot; behaviorConfiguration=&quot;AllenBehavior&quot; binding=&quot;webHttpBinding&quot; contract=&quot;jQueryWCF.WCFservice&quot; /&gt;
      &lt;/service&gt;
    &lt;/services&gt;
  &lt;/system.serviceModel&gt;
 &lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot;?&gt;
&lt;configuration&gt;
  &lt;appSettings/&gt;
  &lt;connectionStrings/&gt;
  &lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot;&gt;
    &lt;/compilation&gt;
  &lt;/system.web&gt;
  &lt;system.serviceModel&gt;
    &lt;behaviors&gt;
      &lt;endpointBehaviors&gt;
        &lt;behavior name=&quot;AllenBehavior&quot;&gt;
          &lt;enableWebScript /&gt;
        &lt;/behavior&gt;
      &lt;/endpointBehaviors&gt;
    &lt;/behaviors&gt;
    &lt;serviceHostingEnvironment aspNetCompatibilityEnabled=&quot;true&quot; /&gt;
    &lt;services&gt;
      &lt;service name=&quot;jQueryWCF.WCFservice&quot;&gt;
        &lt;endpoint address=&quot;&quot; behaviorConfiguration=&quot;AllenBehavior&quot; binding=&quot;webHttpBinding&quot; contract=&quot;jQueryWCF.WCFservice&quot; /&gt;
      &lt;/service&gt;
    &lt;/services&gt;
  &lt;/system.serviceModel&gt;
 &lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Design the UI of the Task Pane by using the following HTML code snippet:</p>
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
       
        &lt;input type=&quot;text&quot; id=&quot;leftTxt&quot; style=&quot;margin-right: 0px; padding: 0px;width:100px&quot; /&gt;&#43;
        &lt;input type=&quot;text&quot; id=&quot;rightTxt&quot; style=&quot;padding: 0px; width:100px;&quot; /&gt;
       <div id="error"></div>
        &lt;input  type=&quot;button&quot; value=&quot;=&quot; id=&quot;getSumBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;/&gt;
        &lt;label&gt;
        <br>
        The results for addition of two numbers:&lt;/label&gt;
        &lt;input type=&quot;text&quot; id=&quot;resultTxt&quot; style=&quot;margin-top:auto; width: 210px; display:block&quot; /&gt;
        &lt;input type =&quot;button&quot; value=&quot;Set Data&quot; id=&quot;setDataBtn&quot; disabled=&quot;disabled&quot; style=&quot;margin-top: 5px; padding: 0px; width: 100px;&quot;/&gt;
    </div>
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
       
        &lt;input type=&quot;text&quot; id=&quot;leftTxt&quot; style=&quot;margin-right: 0px; padding: 0px;width:100px&quot; /&gt;&#43;
        &lt;input type=&quot;text&quot; id=&quot;rightTxt&quot; style=&quot;padding: 0px; width:100px;&quot; /&gt;
       <div id="error"></div>
        &lt;input  type=&quot;button&quot; value=&quot;=&quot; id=&quot;getSumBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;/&gt;
        &lt;label&gt;
        <br>
        The results for addition of two numbers:&lt;/label&gt;
        &lt;input type=&quot;text&quot; id=&quot;resultTxt&quot; style=&quot;margin-top:auto; width: 210px; display:block&quot; /&gt;
        &lt;input type =&quot;button&quot; value=&quot;Set Data&quot; id=&quot;setDataBtn&quot; disabled=&quot;disabled&quot; style=&quot;margin-top: 5px; padding: 0px; width: 100px;&quot;/&gt;
    </div>
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Code the event handle by using the following JavaScript code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
// This function is run when the app is ready to start interacting with the host application
// It ensures the DOM is ready before adding click handlers to buttons
Office.initialize = function (reason) {
    $(document).ready(function () {
        $('#getSumBtn').click(function () { callServer(); });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#setDataBtn').click(function () { setData('#resultTxt'); });
        }
        else {
            $('#setDataBtn').remove();
        }
    });
};


// Use $.ajax function to call WCF Service
function callServer() {
    var $left = $(&quot;#leftTxt&quot;).val();
    var $right = $(&quot;#rightTxt&quot;).val()
    if ($.trim($(&quot;#rightTxt&quot;).val()) == &quot;&quot; || $.trim($(&quot;#leftTxt&quot;).val()) == &quot;&quot;) {
        writeError(&quot;Error: left number or right number can not be null&quot;);
        return;
    }


    var left = Number($.trim($left));
    var right = Number($.trim($right));
    if (isNaN(left) || isNaN(right)) {
        $(&quot;#leftTxt&quot;).val(&quot;&quot;);
        $(&quot;#rightTxt&quot;).val(&quot;&quot;);
        writeError(&quot;Error: please input number&quot;);
        return;
    }


    $.ajax({
        type: 'post',
        url: '/WCFService.svc/Add',
        contentType: 'text/json',
        data: '{&quot;left&quot;:' &#43; left &#43; ',&quot;right&quot;:' &#43; right&#43;'}', // post data 
        success: function (result) {
            GetResult(String(result.d));


            // set &quot;Set Data&quot; button enable
            $(&quot;#setDataBtn&quot;).removeAttr(&quot;disabled&quot;);
        }
    });
}


// Get return data from WCF method and displays it in a textbox 
function GetResult(text) {
    $(&quot;#resultTxt&quot;).val(text);
}


// Print error message
function writeError(text)
{
    $(&quot;#error&quot;)[0].innerText = text;
    $(&quot;#error&quot;).css(&quot;color&quot;, &quot;red&quot;);
}


// Writes data from textbox to the current selection in the document
function setData(elementId) {
    Office.context.document.setSelectedDataAsync($(elementId).val());
}

</pre>
<pre id="codePreview" class="js">
// This function is run when the app is ready to start interacting with the host application
// It ensures the DOM is ready before adding click handlers to buttons
Office.initialize = function (reason) {
    $(document).ready(function () {
        $('#getSumBtn').click(function () { callServer(); });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#setDataBtn').click(function () { setData('#resultTxt'); });
        }
        else {
            $('#setDataBtn').remove();
        }
    });
};


// Use $.ajax function to call WCF Service
function callServer() {
    var $left = $(&quot;#leftTxt&quot;).val();
    var $right = $(&quot;#rightTxt&quot;).val()
    if ($.trim($(&quot;#rightTxt&quot;).val()) == &quot;&quot; || $.trim($(&quot;#leftTxt&quot;).val()) == &quot;&quot;) {
        writeError(&quot;Error: left number or right number can not be null&quot;);
        return;
    }


    var left = Number($.trim($left));
    var right = Number($.trim($right));
    if (isNaN(left) || isNaN(right)) {
        $(&quot;#leftTxt&quot;).val(&quot;&quot;);
        $(&quot;#rightTxt&quot;).val(&quot;&quot;);
        writeError(&quot;Error: please input number&quot;);
        return;
    }


    $.ajax({
        type: 'post',
        url: '/WCFService.svc/Add',
        contentType: 'text/json',
        data: '{&quot;left&quot;:' &#43; left &#43; ',&quot;right&quot;:' &#43; right&#43;'}', // post data 
        success: function (result) {
            GetResult(String(result.d));


            // set &quot;Set Data&quot; button enable
            $(&quot;#setDataBtn&quot;).removeAttr(&quot;disabled&quot;);
        }
    });
}


// Get return data from WCF method and displays it in a textbox 
function GetResult(text) {
    $(&quot;#resultTxt&quot;).val(text);
}


// Print error message
function writeError(text)
{
    $(&quot;#error&quot;)[0].innerText = text;
    $(&quot;#error&quot;).css(&quot;color&quot;, &quot;red&quot;);
}


// Writes data from textbox to the current selection in the document
function setData(elementId) {
    Office.context.document.setSelectedDataAsync($(elementId).val());
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">JavaScript API for Office</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/fp142185(v=office.15).aspx">http://msdn.microsoft.com/en-us/library/fp142185(v=office.15).aspx</a>
</p>
<p class="MsoNormal">Use the REST Endpoint with Ajax and JScript Web Resources </p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad">http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
