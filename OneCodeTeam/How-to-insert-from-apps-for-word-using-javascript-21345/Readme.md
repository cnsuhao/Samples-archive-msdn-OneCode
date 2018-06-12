# How to insert images from apps for word using javascript
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* insert image
* apps for word
## IsPublished
* True
## ModifiedDate
* 2013-03-22 05:25:28
## Description

<h1>How to insert an image from apps to Word by using JavaScript (<span class="SpellE">JSWordInsertImage</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The demonstration shows how to insert an image from apps to Word by using JavaScript. Apps for Office enable a new extensibility model for supported Microsoft Office 2013 client applications. This new model enables webpages to be hosted
 inside an Office client application. The <a href="http://msdn.microsoft.com/en-us/library/office/apps/fp142185(v=office.15)">
JavaScript API for Office</a> is used in apps for Office created for the Office 2013 versions of Word, Excel, and Project Professional. We can use the
<a href="http://msdn.microsoft.com/en-us/library/office/apps/fp142145(v=office.15)">
<span class="SpellE">setSelectedDataAsync</span></a> method to insert an image into Word.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Install Office 2013 RTM and Install Visual Studio 2012 RTM</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA">Download</a> and Install Microsoft Office Developer Tools for Visual Studio 2012-Preview 2</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1. Open JSWordInsertImage.sln to open the solution and press &quot;F5&quot; on the keyboard to run project,
<span class="GramE">The</span> form resembles the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/78761/1/image.png" alt="" width="576" height="356" align="middle">
</span></p>
<p class="MsoNormal">Step 2. First, input the Online Picture. If you do not input the address and then click &quot;Preview Picture&quot; button, you will receive a &quot;<span style="color:red">Please input online picture URL</span>&quot; error message. If
 you input an address that is not picture file, you will receive an &quot;<span style="color:red">Image type must be one of
<span class="SpellE">gif<span class="GramE">,jpeg,jpg,png</span></span></span>&quot; error message.</p>
<p class="MsoNormal"><span class="GramE">Step 3.</span> If you input the correct picture address, and then click &quot;Preview Picture&quot; button to preview the image make sure that the URL is valid and the picture exists.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/78762/1/image.png" alt="" width="966" height="630" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">Step 4. If the picture preview is successful, click &quot;Insert Image&quot; button to insert the valid image into Word document by using the JavaScript API for Office. If the operation is successful, the picture in Word document will
 resemble the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/78763/1/image.png" alt="" width="963" height="628" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create an App for Office 2013 project by using visual Studio 2012.</p>
<p class="MsoNormal">Step 2. Design the UI of the Task Pane by using the following HTML code snippet:</p>
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
        &lt;label&gt;Online Picture Address: &lt;/label&gt;
        &lt;input id=&quot;Text1&quot; type=&quot;text&quot; /&gt;
        &lt;input type=&quot;button&quot; id=&quot;preViewBtn&quot; value=&quot;Preview Picture&quot;/&gt;
        <br>
        <br>
        <img id="prePic" src="">  
        </div>
    <div> 
        &lt;input type=&quot;Button&quot; value=&quot;Insert Image&quot; id=&quot;insertImageBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;  disabled=&quot;disabled&quot; /&gt; 
        <br>
        <span>Results: </span><div id="results"></div>


    </div>
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
        &lt;label&gt;Online Picture Address: &lt;/label&gt;
        &lt;input id=&quot;Text1&quot; type=&quot;text&quot; /&gt;
        &lt;input type=&quot;button&quot; id=&quot;preViewBtn&quot; value=&quot;Preview Picture&quot;/&gt;
        <br>
        <br>
        <img id="prePic" src="">  
        </div>
    <div> 
        &lt;input type=&quot;Button&quot; value=&quot;Insert Image&quot; id=&quot;insertImageBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;  disabled=&quot;disabled&quot; /&gt; 
        <br>
        <span>Results: </span><div id="results"></div>


    </div>
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 3. Code the event handle by using the following JavaScript code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
Office.initialize = function (reason)
{
    $(document).ready(function ()
    {
        var picUrl = $('#Text1');
        $('#preViewBtn').click(function ()
        {     
            if (validatePic(picUrl))
            {
                preViewPic();
                $('#insertImageBtn').removeAttr(&quot;disabled&quot;);
            }
        });
       
        $('#Text1').change(function () {
            $('#insertImageBtn').attr(&quot;disabled&quot;, &quot;disabled&quot;);
        });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync)
        {       
            $('#insertImageBtn').click(function () {
                var imgHtml = &quot;<img>&quot;;
                setHTMLImage(imgHtml);
            });
        }   
    });
};


// invalidate Picture Url
function validatePic(picUrl)
{
    if (picUrl.val().length == 0)
    {
        writeError(&quot;Please input online picture URL&quot;);
        return false;
    }


    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf(&quot;.&quot;), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != &quot;.jpg&quot;) && (picextension != &quot;.gif&quot;) && (picextension != &quot;.jpeg&quot;) && (picextension != &quot;.png&quot;) && (picextension != &quot;.bmp&quot;))
    {
        writeError(&quot;Image type must be one of gif,jpeg,jpg,png&quot;);
        picUrl.focus();


        // Clear Picture Url
        picUrl.select();
        document.selection.clear();
        return false;
    }


    $('#results')[0].innerText = &quot;&quot;;
    return true;
}


// Preview Picture to make sure that url is valid
function preViewPic()
{
    var picaddress = $('#Text1').val();
    $('#prePic').prop(&quot;src&quot;, picaddress);
}


// Insert image 
function setHTMLImage(imgHTML)
{
    Office.context.document.setSelectedDataAsync(
        imgHTML,
        { coercionType: &quot;html&quot; },
        function (asyncResult) {
            if (asyncResult.status == &quot;failed&quot;) {
                writeError('Error: ' &#43; asyncResult.error.message);
            }
        });
}


// Print Error Message
function writeError(text)
{
    $('#results')[0].innerText = text;
    $('#results').css(&quot;color&quot;, &quot;red&quot;);
}

</pre>
<pre id="codePreview" class="js">
Office.initialize = function (reason)
{
    $(document).ready(function ()
    {
        var picUrl = $('#Text1');
        $('#preViewBtn').click(function ()
        {     
            if (validatePic(picUrl))
            {
                preViewPic();
                $('#insertImageBtn').removeAttr(&quot;disabled&quot;);
            }
        });
       
        $('#Text1').change(function () {
            $('#insertImageBtn').attr(&quot;disabled&quot;, &quot;disabled&quot;);
        });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync)
        {       
            $('#insertImageBtn').click(function () {
                var imgHtml = &quot;<img>&quot;;
                setHTMLImage(imgHtml);
            });
        }   
    });
};


// invalidate Picture Url
function validatePic(picUrl)
{
    if (picUrl.val().length == 0)
    {
        writeError(&quot;Please input online picture URL&quot;);
        return false;
    }


    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf(&quot;.&quot;), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != &quot;.jpg&quot;) && (picextension != &quot;.gif&quot;) && (picextension != &quot;.jpeg&quot;) && (picextension != &quot;.png&quot;) && (picextension != &quot;.bmp&quot;))
    {
        writeError(&quot;Image type must be one of gif,jpeg,jpg,png&quot;);
        picUrl.focus();


        // Clear Picture Url
        picUrl.select();
        document.selection.clear();
        return false;
    }


    $('#results')[0].innerText = &quot;&quot;;
    return true;
}


// Preview Picture to make sure that url is valid
function preViewPic()
{
    var picaddress = $('#Text1').val();
    $('#prePic').prop(&quot;src&quot;, picaddress);
}


// Insert image 
function setHTMLImage(imgHTML)
{
    Office.context.document.setSelectedDataAsync(
        imgHTML,
        { coercionType: &quot;html&quot; },
        function (asyncResult) {
            if (asyncResult.status == &quot;failed&quot;) {
                writeError('Error: ' &#43; asyncResult.error.message);
            }
        });
}


// Print Error Message
function writeError(text)
{
    $('#results')[0].innerText = text;
    $('#results').css(&quot;color&quot;, &quot;red&quot;);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>setSelectedDataAsync method:
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/office/apps/fp142145(v=office.15)">http://msdn.microsoft.com/en-us/library/office/apps/fp142145(v=office.15)</a></p>
<p class="MsoNormal">CoercionType enumeration:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/office/apps/fp161141">http://msdn.microsoft.com/en-us/library/office/apps/fp161141</a></p>
<p class="MsoNormal">What's new for Office 2013 developers</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/library/office/jj229830(v=office.15)">http://msdn.microsoft.com/library/office/jj229830(v=office.15)</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
