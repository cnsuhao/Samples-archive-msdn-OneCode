# How to insert images in Word2013 using Javascript with OOXML way
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* insert image
* Word2013
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:51:56
## Description

<h1>How to insert an image <span style="">to Word by using JavaScript with</span> OOXML (<span class="SpellE">JSInsertOnlineImageToWord</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This demonstration shows how to insert an image into Word by using JavaScript with OOXML. Apps for Office enable a new extensibility model for supported Microsoft Office 2013 client applications. This new model enables webpages to be
 hosted inside an Office client application. The <a href="http://msdn.microsoft.com/en-us/library/office/apps/fp142185(v=office.15)">
JavaScript API for Office</a> is used in Apps for Office created for the Office 2013 versions of Microsoft Word, Excel, and Project Professional. You can use the
<a href="http://msdn.microsoft.com/en-us/library/office/apps/fp142145(v=office.15)">
<span class="SpellE">setSelectedDataAsync</span></a> method with OOXML to insert an image into Word.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Install Office 2013 RTM and Install Visual Studio 2012 RTM</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA">Download</a> and Install Microsoft Office Developer Tools for Visual Studio 2012-Preview 2</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1.Open JSInsertOnlineImageToWord.sln to open the solution. Press &quot;F5&quot; on the keyboard to run the project<span style="">. The form resembles the following:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84731/1/image.png" alt="" width="576" height="430" align="middle">
</span></p>
<p class="MsoNormal">Step 2.Input an Online Picture Address<span style="">.</span> If you do not input a correct address and then you click the &quot;Preview Picture&quot; button, you will receive a &quot;<span style="color:red">Please input online picture
 URL</span>&quot; error message. If you input an address that is not picture type, you will also receive an &quot;<span style="color:red">Image type must be one of gif<span class="GramE">,jpeg,jpg,png</span></span>&quot; error message.</p>
<p class="MsoNormal">Step 3.Make sure that the URL is valid and the picture exists when you input the picture address, and preview the picture.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84732/1/image.png" alt="" width="576" height="431" align="middle">
</span></p>
<p class="MsoNormal">Step 4.After you successfully preview the picture, the &quot;Insert Image&quot; button will appear and you can click the image to insert the valid image into Word by using OOXML. If the operation is successful, the picture will resemble
 the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84733/1/image.png" alt="" width="576" height="429" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create an App for Office 2013 project by using Visual Studio 2012.</p>
<p class="MsoNormal">Step 2. Design the UI of the Task Pane by using the following HTML code snippet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;body&gt;
    &lt;label&gt;Online Picture Address: &lt;/label&gt;
    &lt;input id=&quot;imgTxt&quot; type=&quot;text&quot;/&gt;
    &lt;input type=&quot;button&quot; id=&quot;preViewBtn&quot; value=&quot;Preview Picture&quot;/&gt;
     <br>
        <img id="prePic" src="" style="width:100%; height:100%">  
    &lt;input type=&quot;button&quot; value=&quot;Insert Image&quot; id=&quot;insertImageBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;/&gt;
     <br>
        <span>Results: </span><div id="results"></div>
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;label&gt;Online Picture Address: &lt;/label&gt;
    &lt;input id=&quot;imgTxt&quot; type=&quot;text&quot;/&gt;
    &lt;input type=&quot;button&quot; id=&quot;preViewBtn&quot; value=&quot;Preview Picture&quot;/&gt;
     <br>
        <img id="prePic" src="" style="width:100%; height:100%">  
    &lt;input type=&quot;button&quot; value=&quot;Insert Image&quot; id=&quot;insertImageBtn&quot; style=&quot;margin-top: 10px; padding: 0px; width: 100px;&quot;/&gt;
     <br>
        <span>Results: </span><div id="results"></div>
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 3. Add an Xml file that is named as &quot;Image.xml&quot; by using the following XML code snippet<span style="">, the XML represents an image.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; standalone=&quot;yes&quot;?&gt;
&lt;?mso-application progid=&quot;Word.Document&quot;?&gt;
&lt;pkg:package xmlns:pkg=&quot;http://schemas.microsoft.com/office/2006/xmlPackage&quot;&gt;
  &lt;pkg:part pkg:name=&quot;/_rels/.rels&quot; pkg:contentType=&quot;application/vnd.openxmlformats-package.relationships&#43;xml&quot; pkg:padding=&quot;512&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;Relationships xmlns=&quot;http://schemas.openxmlformats.org/package/2006/relationships&quot;&gt;
        &lt;Relationship Id=&quot;rId1&quot; Type=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument&quot; Target=&quot;word/document.xml&quot;/&gt;
      &lt;/Relationships&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
  &lt;pkg:part pkg:name=&quot;/word/_rels/document.xml.rels&quot; 
            pkg:contentType=&quot;application/vnd.openxmlformats-package.relationships&#43;xml&quot; pkg:padding=&quot;256&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;Relationships xmlns=&quot;http://schemas.openxmlformats.org/package/2006/relationships&quot;&gt;
        &lt;Relationship Id=&quot;rId4&quot; Type=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships/image&quot; 
                 Target=&quot;http://i.msdn.microsoft.com/fp123580.AppHome2(en-us,MSDN.10).png&quot; TargetMode=&quot;External&quot;/&gt;
      &lt;/Relationships&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
  &lt;pkg:part pkg:name=&quot;/word/document.xml&quot; pkg:contentType=&quot;application/vnd.openxmlformats-officedocument.wordprocessingml.document.main&#43;xml&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;w:document mc:Ignorable=&quot;w14 w15 wp14&quot; 
                  xmlns:wpc=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas&quot;
                  xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot; 
                  xmlns:o=&quot;urn:schemas-microsoft-com:office:office&quot; 
                  xmlns:r=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships&quot; 
                  xmlns:m=&quot;http://schemas.openxmlformats.org/officeDocument/2006/math&quot; 
                  xmlns:v=&quot;urn:schemas-microsoft-com:vml&quot; 
                  xmlns:wp14=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing&quot;
                  xmlns:wp=&quot;http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing&quot; 
                  xmlns:w10=&quot;urn:schemas-microsoft-com:office:word&quot; 
                  xmlns:w=&quot;http://schemas.openxmlformats.org/wordprocessingml/2006/main&quot; 
                  xmlns:w14=&quot;http://schemas.microsoft.com/office/word/2010/wordml&quot; 
                  xmlns:w15=&quot;http://schemas.microsoft.com/office/word/2012/wordml&quot; 
                  xmlns:wpg=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingGroup&quot; 
                  xmlns:wpi=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingInk&quot; 
                  xmlns:wne=&quot;http://schemas.microsoft.com/office/word/2006/wordml&quot; 
                  xmlns:wps=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingShape&quot;&gt;
        &lt;w:body&gt;
          &lt;w:p w:rsidR=&quot;00000000&quot; w:rsidRDefault=&quot;0010050F&quot; w:rsidP=&quot;0010050F&quot;&gt;
            &lt;w:r&gt;
              &lt;w:rPr&gt;
                &lt;w:noProof/&gt;
                &lt;w:lang w:eastAsia=&quot;zh-CN&quot;/&gt;
              &lt;/w:rPr&gt;
              &lt;w:drawing&gt;
                &lt;wp:inline distT=&quot;0&quot; distB=&quot;0&quot; distL=&quot;0&quot; distR=&quot;0&quot;&gt;
                  &lt;wp:extent cx=&quot;4591050&quot; cy=&quot;2009775&quot;/&gt;
                  &lt;wp:effectExtent l=&quot;0&quot; t=&quot;0&quot; r=&quot;0&quot; b=&quot;9525&quot;/&gt;
                  &lt;wp:docPr id=&quot;2&quot; name=&quot;Picture 2&quot;/&gt;
                  &lt;wp:cNvGraphicFramePr&gt;
                    
                  &lt;/wp:cNvGraphicFramePr&gt;
                  
                    
                      &lt;pic:pic xmlns:pic=&quot;http://schemas.openxmlformats.org/drawingml/2006/picture&quot;&gt;
                        &lt;pic:nvPicPr&gt;
                          &lt;pic:cNvPr id=&quot;2&quot; name=&quot;fp123580.AppHome2(en-us,MSDN.10)[1].png&quot;/&gt;
                          &lt;pic:cNvPicPr/&gt;
                        &lt;/pic:nvPicPr&gt;
                        &lt;pic:blipFill&gt;
                          
                            
                              
                                &lt;a14:useLocalDpi val=&quot;0&quot; xmlns:a14=&quot;http://schemas.microsoft.com/office/drawing/2010/main&quot;/&gt;
                              
                            
                          
                          
                            
                          
                        &lt;/pic:blipFill&gt;
                        &lt;pic:spPr&gt;
                          
                            
                            
                          
                          
                            
                          
                        &lt;/pic:spPr&gt;
                      &lt;/pic:pic&gt;
                    
                  
                &lt;/wp:inline&gt;
              &lt;/w:drawing&gt;
            &lt;/w:r&gt;
          &lt;/w:p&gt;
          &lt;w:sectPr w:rsidR=&quot;00000000&quot;&gt;
            &lt;w:pgSz w:w=&quot;12240&quot; w:h=&quot;15840&quot;/&gt;
            &lt;w:pgMar w:top=&quot;1440&quot; w:right=&quot;1800&quot; w:bottom=&quot;1440&quot; w:left=&quot;1800&quot; w:header=&quot;720&quot; w:footer=&quot;720&quot; w:gutter=&quot;0&quot;/&gt;
            &lt;w:cols w:space=&quot;720&quot;/&gt;
          &lt;/w:sectPr&gt;
        &lt;/w:body&gt;
      &lt;/w:document&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
&lt;/pkg:package&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; standalone=&quot;yes&quot;?&gt;
&lt;?mso-application progid=&quot;Word.Document&quot;?&gt;
&lt;pkg:package xmlns:pkg=&quot;http://schemas.microsoft.com/office/2006/xmlPackage&quot;&gt;
  &lt;pkg:part pkg:name=&quot;/_rels/.rels&quot; pkg:contentType=&quot;application/vnd.openxmlformats-package.relationships&#43;xml&quot; pkg:padding=&quot;512&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;Relationships xmlns=&quot;http://schemas.openxmlformats.org/package/2006/relationships&quot;&gt;
        &lt;Relationship Id=&quot;rId1&quot; Type=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument&quot; Target=&quot;word/document.xml&quot;/&gt;
      &lt;/Relationships&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
  &lt;pkg:part pkg:name=&quot;/word/_rels/document.xml.rels&quot; 
            pkg:contentType=&quot;application/vnd.openxmlformats-package.relationships&#43;xml&quot; pkg:padding=&quot;256&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;Relationships xmlns=&quot;http://schemas.openxmlformats.org/package/2006/relationships&quot;&gt;
        &lt;Relationship Id=&quot;rId4&quot; Type=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships/image&quot; 
                 Target=&quot;http://i.msdn.microsoft.com/fp123580.AppHome2(en-us,MSDN.10).png&quot; TargetMode=&quot;External&quot;/&gt;
      &lt;/Relationships&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
  &lt;pkg:part pkg:name=&quot;/word/document.xml&quot; pkg:contentType=&quot;application/vnd.openxmlformats-officedocument.wordprocessingml.document.main&#43;xml&quot;&gt;
    &lt;pkg:xmlData&gt;
      &lt;w:document mc:Ignorable=&quot;w14 w15 wp14&quot; 
                  xmlns:wpc=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas&quot;
                  xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot; 
                  xmlns:o=&quot;urn:schemas-microsoft-com:office:office&quot; 
                  xmlns:r=&quot;http://schemas.openxmlformats.org/officeDocument/2006/relationships&quot; 
                  xmlns:m=&quot;http://schemas.openxmlformats.org/officeDocument/2006/math&quot; 
                  xmlns:v=&quot;urn:schemas-microsoft-com:vml&quot; 
                  xmlns:wp14=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing&quot;
                  xmlns:wp=&quot;http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing&quot; 
                  xmlns:w10=&quot;urn:schemas-microsoft-com:office:word&quot; 
                  xmlns:w=&quot;http://schemas.openxmlformats.org/wordprocessingml/2006/main&quot; 
                  xmlns:w14=&quot;http://schemas.microsoft.com/office/word/2010/wordml&quot; 
                  xmlns:w15=&quot;http://schemas.microsoft.com/office/word/2012/wordml&quot; 
                  xmlns:wpg=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingGroup&quot; 
                  xmlns:wpi=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingInk&quot; 
                  xmlns:wne=&quot;http://schemas.microsoft.com/office/word/2006/wordml&quot; 
                  xmlns:wps=&quot;http://schemas.microsoft.com/office/word/2010/wordprocessingShape&quot;&gt;
        &lt;w:body&gt;
          &lt;w:p w:rsidR=&quot;00000000&quot; w:rsidRDefault=&quot;0010050F&quot; w:rsidP=&quot;0010050F&quot;&gt;
            &lt;w:r&gt;
              &lt;w:rPr&gt;
                &lt;w:noProof/&gt;
                &lt;w:lang w:eastAsia=&quot;zh-CN&quot;/&gt;
              &lt;/w:rPr&gt;
              &lt;w:drawing&gt;
                &lt;wp:inline distT=&quot;0&quot; distB=&quot;0&quot; distL=&quot;0&quot; distR=&quot;0&quot;&gt;
                  &lt;wp:extent cx=&quot;4591050&quot; cy=&quot;2009775&quot;/&gt;
                  &lt;wp:effectExtent l=&quot;0&quot; t=&quot;0&quot; r=&quot;0&quot; b=&quot;9525&quot;/&gt;
                  &lt;wp:docPr id=&quot;2&quot; name=&quot;Picture 2&quot;/&gt;
                  &lt;wp:cNvGraphicFramePr&gt;
                    
                  &lt;/wp:cNvGraphicFramePr&gt;
                  
                    
                      &lt;pic:pic xmlns:pic=&quot;http://schemas.openxmlformats.org/drawingml/2006/picture&quot;&gt;
                        &lt;pic:nvPicPr&gt;
                          &lt;pic:cNvPr id=&quot;2&quot; name=&quot;fp123580.AppHome2(en-us,MSDN.10)[1].png&quot;/&gt;
                          &lt;pic:cNvPicPr/&gt;
                        &lt;/pic:nvPicPr&gt;
                        &lt;pic:blipFill&gt;
                          
                            
                              
                                &lt;a14:useLocalDpi val=&quot;0&quot; xmlns:a14=&quot;http://schemas.microsoft.com/office/drawing/2010/main&quot;/&gt;
                              
                            
                          
                          
                            
                          
                        &lt;/pic:blipFill&gt;
                        &lt;pic:spPr&gt;
                          
                            
                            
                          
                          
                            
                          
                        &lt;/pic:spPr&gt;
                      &lt;/pic:pic&gt;
                    
                  
                &lt;/wp:inline&gt;
              &lt;/w:drawing&gt;
            &lt;/w:r&gt;
          &lt;/w:p&gt;
          &lt;w:sectPr w:rsidR=&quot;00000000&quot;&gt;
            &lt;w:pgSz w:w=&quot;12240&quot; w:h=&quot;15840&quot;/&gt;
            &lt;w:pgMar w:top=&quot;1440&quot; w:right=&quot;1800&quot; w:bottom=&quot;1440&quot; w:left=&quot;1800&quot; w:header=&quot;720&quot; w:footer=&quot;720&quot; w:gutter=&quot;0&quot;/&gt;
            &lt;w:cols w:space=&quot;720&quot;/&gt;
          &lt;/w:sectPr&gt;
        &lt;/w:body&gt;
      &lt;/w:document&gt;
    &lt;/pkg:xmlData&gt;
  &lt;/pkg:part&gt;
&lt;/pkg:package&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Step 4.Insert the event handle by using the following JavaScript code snippet:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
Office.initialize = function (reason)
{
    $(document).ready(function () {
        // hide insert Image button
        $('#insertImageBtn').hide();


        var picUrl = $('#imgTxt');
        // click event fire when users click &quot;Preview Picture&quot; button
        $('#preViewBtn').click(function () {
            // show &quot;insert image&quot; button if the picture Url is correct.
            if (validatePic(picUrl)) {      
                // show the insert image button
                $('#insertImageBtn').show();
            }
            else {
                // hide the insert image if the picture Url is incorrect
                $('#insertImageBtn').hide();
            }
        });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#insertImageBtn').click(function () {


                var imgOOXML;
                // Get a string of ooxml that represents an image
                $.ajax({
                    type: &quot;Get&quot;,
                    url: &quot;../Image.xml&quot;,
                    dataType: &quot;text&quot;,
                    async: false,
                    success: function (text) {
                        var sourcetext = &quot;http://i.msdn.microsoft.com/fp123580.AppHome2(en-us,MSDN.10).png&quot;;
                        var imgUrl = $('#imgTxt').val();
                        imgOOXML = text.replace(sourcetext, imgUrl);
                    }
                });


                setOOXMLImage(imgOOXML);
            });
        }
    });
};


// Validate Picture Url
function validatePic(picUrl) {
    if (picUrl.val().length == 0) {


        // Clear text and pircture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());


        writeError(&quot;Please input online picture URL&quot;);
        return false;
    }


    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf(&quot;.&quot;), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != &quot;.jpg&quot;) && (picextension != &quot;.gif&quot;) && (picextension != &quot;.jpeg&quot;) && (picextension != &quot;.png&quot;) && (picextension != &quot;.bmp&quot;)) {
        writeError(&quot;Image type must be one of gif,jpeg,jpg,png&quot;);
        picUrl.focus();


        // Clear text and Picture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());
        return false;
    }


    $('#results')[0].innerText = &quot;&quot;;
    loadImageFile(picUrl.val());
    return true;
}


// Load imge to make sure the URL is valid
function loadImageFile(text)
{
    $('#prePic').prop(&quot;src&quot;, text);
}


// Insert Image by using OOXML way
function setOOXMLImage(imgOOXML) {
    if (Office.CoercionType.Ooxml) {
        Office.context.document.setSelectedDataAsync(
            imgOOXML,
            { coercionType: &quot;ooxml&quot; },
            function (asyncResult) {
                if (asyncResult.status == &quot;failed&quot;) {
                    writeError('Error: ' &#43; asyncResult.error.message);
                }
            });
    }
    else {
        writeError(&quot;Setting data as Open XML is not supported &quot;);
    }
}


// Print Error Message
function writeError(text) {
    $('#results')[0].innerText = text;
    $('#results').css(&quot;color&quot;, &quot;red&quot;);
}

</pre>
<pre id="codePreview" class="js">
Office.initialize = function (reason)
{
    $(document).ready(function () {
        // hide insert Image button
        $('#insertImageBtn').hide();


        var picUrl = $('#imgTxt');
        // click event fire when users click &quot;Preview Picture&quot; button
        $('#preViewBtn').click(function () {
            // show &quot;insert image&quot; button if the picture Url is correct.
            if (validatePic(picUrl)) {      
                // show the insert image button
                $('#insertImageBtn').show();
            }
            else {
                // hide the insert image if the picture Url is incorrect
                $('#insertImageBtn').hide();
            }
        });


        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#insertImageBtn').click(function () {


                var imgOOXML;
                // Get a string of ooxml that represents an image
                $.ajax({
                    type: &quot;Get&quot;,
                    url: &quot;../Image.xml&quot;,
                    dataType: &quot;text&quot;,
                    async: false,
                    success: function (text) {
                        var sourcetext = &quot;http://i.msdn.microsoft.com/fp123580.AppHome2(en-us,MSDN.10).png&quot;;
                        var imgUrl = $('#imgTxt').val();
                        imgOOXML = text.replace(sourcetext, imgUrl);
                    }
                });


                setOOXMLImage(imgOOXML);
            });
        }
    });
};


// Validate Picture Url
function validatePic(picUrl) {
    if (picUrl.val().length == 0) {


        // Clear text and pircture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());


        writeError(&quot;Please input online picture URL&quot;);
        return false;
    }


    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf(&quot;.&quot;), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != &quot;.jpg&quot;) && (picextension != &quot;.gif&quot;) && (picextension != &quot;.jpeg&quot;) && (picextension != &quot;.png&quot;) && (picextension != &quot;.bmp&quot;)) {
        writeError(&quot;Image type must be one of gif,jpeg,jpg,png&quot;);
        picUrl.focus();


        // Clear text and Picture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());
        return false;
    }


    $('#results')[0].innerText = &quot;&quot;;
    loadImageFile(picUrl.val());
    return true;
}


// Load imge to make sure the URL is valid
function loadImageFile(text)
{
    $('#prePic').prop(&quot;src&quot;, text);
}


// Insert Image by using OOXML way
function setOOXMLImage(imgOOXML) {
    if (Office.CoercionType.Ooxml) {
        Office.context.document.setSelectedDataAsync(
            imgOOXML,
            { coercionType: &quot;ooxml&quot; },
            function (asyncResult) {
                if (asyncResult.status == &quot;failed&quot;) {
                    writeError('Error: ' &#43; asyncResult.error.message);
                }
            });
    }
    else {
        writeError(&quot;Setting data as Open XML is not supported &quot;);
    }
}


// Print Error Message
function writeError(text) {
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
<p class="MsoNormal">Use the REST Endpoint with Ajax and JScript Web Resources </p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad">http://msdn.microsoft.com/en-us/library/1bb82714-1bd6-4ea4-8faf-93bf29cabaad</a><span style="">&nbsp;
</span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
