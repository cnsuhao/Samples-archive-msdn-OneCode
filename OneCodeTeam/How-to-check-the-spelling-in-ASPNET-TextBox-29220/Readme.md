# How to check the spelling in ASP.NET TextBox
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Spell Checking
## IsPublished
* True
## ModifiedDate
* 2014-06-11 08:28:23
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to check the spelling in ASP.NET Text Box
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold"></span><span style="font-size:11pt">The project illustrates how to check
</span><span style="font-size:11pt">if </span><span style="font-size:11pt">the spelling in
</span><span style="font-weight:bold">Text Box</span><span style="font-weight:bold">
</span><span style="font-size:11pt">is correct or not. This sample code check</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> the user's input words</span><span style="font-weight:bold">
</span><span style="font-size:11pt">via MS Word </span><span style="font-weight:bold">Check Spelling</span><span style="font-size:11pt"> component.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:11pt"></span><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Please follow the demonstration steps below.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 1: Open the project.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 2: Expand the CS/VBASPNETCheckSpellingWritten web application and press Ctrl &#43; F5 to show the Default.aspx.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 3: We will see a Text Box control on the
</span><span style="font-size:11pt">page. You can press the &quot;Check&quot; </span><span style="font-size:11pt">Button to check
</span><span style="font-size:11pt">misspelled</span><span style="font-size:11pt"> words
</span><span style="font-size:11pt">in a</span><span style="font-size:11pt"> Text Box directly or
</span><span style="font-size:11pt">you can also input </span><span style="font-size:11pt">some other words</span><span style="font-size:11pt"> and then click &ldquo;Check&rdquo;.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 4: The code-sample will show a dialo</span><span style="font-size:11pt">g of your text, please choose</span><span style="font-size:11pt">
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">correct word from the recommended wor</span><span style="font-size:11pt">d list or input a word</span><span style="font-size:11pt"> by yourself</span><span style="font-size:11pt"> instead.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 5: If everything is fine, close the dia</span><span style="font-size:11pt">log and you will find your text
</span><span style="font-size:11pt">ha</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> been modified.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step 6: Validation finished.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Add the</span><span style="font-size:11pt"> code as shown</span><span style="font-size:11pt"> below in button's Click event.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
if (applicationWord != null) 
              {
                  return; 
              } 
              applicationWord = new Microsoft.Office.Interop.Word.Application(); 
              int errors = 0; 
              if (tbInput.Text.Length &gt; 0) 
              {     
                  object template = Missing.Value; 
                  object newTemplate = Missing.Value; 
                  object documentType = Missing.Value; 
                  object visible = true; 
                  // Define a MS Word Document, then we use this document to calculate the quantity of errors and 
                  // invoke the document's CheckSpelling method. 
                  Microsoft.Office.Interop.Word._Document documentCheck = applicationWord.Documents.Add(ref template, 
                    ref newTemplate, ref documentType, ref visible); 
                  applicationWord.Visible = false; 
                  documentCheck.Words.First.InsertBefore(tbInput.Text); 
                  Microsoft.Office.Interop.Word.ProofreadingErrors spellErrorsColl = documentCheck.SpellingErrors; 
                  errors = spellErrorsColl.Count; 
                  object optional = Missing.Value; 
                  documentCheck.Activate(); 
                  documentCheck.CheckSpelling(ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, 
                      ref optional, ref optional, ref optional, ref optional, ref optional, ref optional); 
                  documentCheck.LanguageDetected = true;  
                  // When users close the dialog, the error messages will be displayed. 
                  if (errors == 0) 
                  { 
                      lbMessage.Text = &quot;No errors&quot;; 
                  } 
                  else 
                  { 
                      lbMessage.Text = &quot;Total errors num:&quot; &#43; errors; 
                  } 
                  // Replace misspelled words in the TextBox. 
                  object first = 0; 
                  object last = documentCheck.Characters.Count - 1; 
                  tbInput.Text = documentCheck.Range(ref first, ref last).Text; 
              } 
              object saveChanges = false; 
              object originalFormat = Missing.Value; 
              object routeDocument = Missing.Value; 
              ((_Application)applicationWord).Quit(ref saveChanges, ref originalFormat, ref routeDocument);
              applicationWord = null;
</pre>
<pre class="hidden">
' Prevent multiple checker window. 
               If applicationWord IsNot Nothing Then 
                   Return 
               End If 
 
               applicationWord = New Microsoft.Office.Interop.Word.Application() 
               Dim errors As Integer = 0 
               If tbInput.Text.Length &gt; 0 Then 
                   Dim template As Object = Missing.Value 
                   Dim newTemplate As Object = Missing.Value 
                   Dim documentType As Object = Missing.Value 
                   Dim visible As Object = True 
 
                   ' Define a MS Word Document, we use this document to calculate the quantity of errors and 
                   ' invoke the document's CheckSpelling method. 
                   Dim documentCheck As Microsoft.Office.Interop.Word._Document =  
                      applicationWord.Documents.Add(template, newTemplate, documentType, visible) 
                   applicationWord.Visible = False 
                   documentCheck.Words.First.InsertBefore(tbInput.Text) 
                   Dim spellErrorsColl As Microsoft.Office.Interop.Word.ProofreadingErrors = documentCheck.SpellingErrors 
                   errors = spellErrorsColl.Count 
 
                   Dim [optional] As Object = Missing.Value 
                   documentCheck.Activate() 
                   documentCheck.CheckSpelling([optional], [optional], [optional], [optional], [optional], [optional], _ 
                       [optional], [optional], [optional], [optional], [optional], [optional]) 
                   documentCheck.LanguageDetected = True 
 
 
                  ' When users close the dialog, the error messages will be displayed. 
                  If errors = 0 Then 
                      lbMessage.Text = &quot;No errors&quot; 
                  Else 
                      lbMessage.Text = &quot;Total errors num:&quot; & errors 
                  End If 
 
                  ' Replace error words of TextBox. 
                  Dim first As Object = 0 
                  Dim last As Object = documentCheck.Characters.Count - 1 
                  tbInput.Text = documentCheck.Range(first, last).Text 
              End If 
 
              Dim saveChanges As Object = False 
              Dim originalFormat As Object = Missing.Value 
              Dim routeDocument As Object = Missing.Value 
              DirectCast(applicationWord, _Application).Quit(saveChanges, originalFormat, routeDocument) 
              applicationWord = Nothing 
</pre>
<pre id="codePreview" class="csharp">
if (applicationWord != null) 
              {
                  return; 
              } 
              applicationWord = new Microsoft.Office.Interop.Word.Application(); 
              int errors = 0; 
              if (tbInput.Text.Length &gt; 0) 
              {     
                  object template = Missing.Value; 
                  object newTemplate = Missing.Value; 
                  object documentType = Missing.Value; 
                  object visible = true; 
                  // Define a MS Word Document, then we use this document to calculate the quantity of errors and 
                  // invoke the document's CheckSpelling method. 
                  Microsoft.Office.Interop.Word._Document documentCheck = applicationWord.Documents.Add(ref template, 
                    ref newTemplate, ref documentType, ref visible); 
                  applicationWord.Visible = false; 
                  documentCheck.Words.First.InsertBefore(tbInput.Text); 
                  Microsoft.Office.Interop.Word.ProofreadingErrors spellErrorsColl = documentCheck.SpellingErrors; 
                  errors = spellErrorsColl.Count; 
                  object optional = Missing.Value; 
                  documentCheck.Activate(); 
                  documentCheck.CheckSpelling(ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, 
                      ref optional, ref optional, ref optional, ref optional, ref optional, ref optional); 
                  documentCheck.LanguageDetected = true;  
                  // When users close the dialog, the error messages will be displayed. 
                  if (errors == 0) 
                  { 
                      lbMessage.Text = &quot;No errors&quot;; 
                  } 
                  else 
                  { 
                      lbMessage.Text = &quot;Total errors num:&quot; &#43; errors; 
                  } 
                  // Replace misspelled words in the TextBox. 
                  object first = 0; 
                  object last = documentCheck.Characters.Count - 1; 
                  tbInput.Text = documentCheck.Range(ref first, ref last).Text; 
              } 
              object saveChanges = false; 
              object originalFormat = Missing.Value; 
              object routeDocument = Missing.Value; 
              ((_Application)applicationWord).Quit(ref saveChanges, ref originalFormat, ref routeDocument);
              applicationWord = null;
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
<span style="font-size:11pt"><span style="font-size:11pt">MSDN: </span><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word(office.11).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Microsoft.Office.Interop.Word</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">MSDN: </span><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.application(office.11).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Application
 Interface</span></a><span style="font-size:11pt"> </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">MSDN: </span><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.document(office.11).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Document
 Interface</span></a></span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
