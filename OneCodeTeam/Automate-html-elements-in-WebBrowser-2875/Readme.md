# Automate html elements in WebBrowser (VBWebBrowserAutomation)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
* Internet Explorer
## Topics
* Automation
* WebBrowser
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:36:53
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBWebBrowserAutomation Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to create a WebBrowser which supplies following features<br>
1. Manipulate the html elements and login a website automatically.<br>
2. Block specified sites.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open the project in VS2010, replace the stored UserName and Password in <br>
&nbsp; &nbsp; &nbsp;StoredSites\www.codeplex.com.xml with your username and password for
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<a target="_blank" href="http://www.codeplex.com">http://www.codeplex.com</a> first.<br>
<br>
Step2. Build this project in VS2010. <br>
<br>
Step3. Run VBWebBrowserAutomation.exe. The button &quot;Auto Complete&quot; is disabled by default.<br>
<br>
Step4. Type https://www.codeplex.com/site/login?RedirectUrl=https%3a%2f%2fwww.codeplex.com%2fsite%2fusers%2fupdate<br>
&nbsp; &nbsp; &nbsp; in the Url textbox and press Enter.<br>
<br>
&nbsp; &nbsp; &nbsp; This url is the login page of www.codeplex.com. The RedirectUrl means that the<br>
&nbsp; &nbsp; &nbsp; page will be redirected to the url if you login the site successfully.<br>
<br>
Step5. After the web page is loaded completed, the button &quot;Auto Complete&quot; is enabled. Click<br>
&nbsp; &nbsp; &nbsp; the button and the web page will be be redirected to <br>
&nbsp; &nbsp; &nbsp; https://www.codeplex.com/site/users/update.<br>
<br>
Step6. After the new web page is loaded, click the button &quot;Auto Complete&quot; again, and the
<br>
&nbsp; &nbsp; &nbsp; &quot;New email address&quot; field in the web page will be filled.<br>
<br>
Step7. Type <a target="_blank" href="http://www.contoso.com">http://www.contoso.com</a> &nbsp;in the urltext box and press Enter. You will view a
<br>
&nbsp; &nbsp; &nbsp; page that show you a message &quot;Sorry, this site is blocked.&quot;<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Design a class XMLSerialization that can serialize an object to an XML file or
<br>
&nbsp; deserialize an XML file to an object.<br>
<br>
2. Design classes HtmlCheckBox, HtmlPassword, HtmlSubmit and HtmlText that represent the<br>
&nbsp; checkbox, password text box, submit button and normal text box. All the classes inherit<br>
&nbsp; HtmlInputElement that represents an HtmlElement with the tag &quot;input&quot;. The class
<br>
&nbsp; HtmlInputElementFactory is used to get an HtmlInputElement from an HtmlElement in the
<br>
&nbsp; web page. <br>
<br>
3. Design a class StoredSite that represents a site whose html elements are stored. A site<br>
&nbsp; is stored as an XML file under StoredSites folder, and can be deserialized.<br>
<br>
&nbsp; This class also supplies a method FillWebPage to complete the web page automatically.<br>
&nbsp; If a submit button could be found, then the button will also be clicked automatically.<br>
<br>
4. Design a class BlockSites which contains that blocked sites list. The file <br>
&nbsp; \Resource\BlockList.xml can be deserialized to a BlockSites instance.<br>
<br>
5. Design a class WebBrowserEx that inherits class System.Windows.Forms.WebBrowser.
<br>
<br>
&nbsp; Override the OnNavigating method to check whether the url is included in the block list.<br>
&nbsp; If so, navigate the build-in Block.htm.<br>
<br>
&nbsp; Override the OnDocumentCompleted method to check whether the loaded page could be completed<br>
&nbsp; automatically. If the site and url are stored, then the method AutoComplete can be used.<br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New">References:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx">http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx</a><br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
