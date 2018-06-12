# Serializable JSON data sample in ASP.NET (VBASPNETSerializeJsonString)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* JSON
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:46:11
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETSerializeJsonString Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;This project illustrates how to serialize Json string. we use jQuery at client
<br>
side and manipulate XML data at server side.<br>
<br>
&nbsp;It demonstrates how to use the serializable json data through an autocomplete
<br>
example. <br>
<br>
<br>
Demo the Sample. <br>
<br>
Open the VBASPNETSerializeJsonString.sln directly, expand the web application <br>
node and press F5 to test the application.<br>
<br>
Step 1. &nbsp;View default.aspx in browser<br>
<br>
Step 2. &nbsp;By default, we could see &nbsp;a search input textbox at the top of the page,
<br>
&nbsp;&nbsp;&nbsp;&nbsp; you can enter a character, for example &quot;m&quot;, you will see an autocomplete
<br>
&nbsp;&nbsp;&nbsp;&nbsp; list under that input, move mouse to select one book name, then you'll
<br>
&nbsp;&nbsp;&nbsp;&nbsp; find this book's related information was display in the result area.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a VB ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step 2. &nbsp;Add a VB class file which named 'Book' in Visual Studio 2010, declare<br>
&nbsp;&nbsp;&nbsp;&nbsp; the class members: id,lable,value,author,genre,price,publish_date,description.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; this class is used to store the book's information<br>
<br>
Step 3. &nbsp;Add a VB ashx file which named 'AutoComplete' in Visual Studio 2010.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; write code in method 'ProcessRequest', the logic as below:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; 1, load a flat XML dataset and filter dataset records<br>
&nbsp;&nbsp;&nbsp;&nbsp; 2, assign corresponding fields to the class Book' members<br>
&nbsp;&nbsp;&nbsp;&nbsp; 3, initializes a new instance of the 'Collection&lt;Book&gt;' class, add<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;new elements into 'Collection&lt;Book&gt;'<br>
&nbsp;&nbsp;&nbsp;&nbsp; 4, serialize the object 'Collection&lt;Book&gt;' &nbsp; &nbsp;
<br>
<br>
<br>
Step 4. &nbsp;Create a new directory, &quot;Scripts&quot;. Right-click the directory and click<br>
&nbsp; &nbsp; &nbsp; &nbsp; Add -&gt; New Item -&gt; JScript File. We need to reference jquery javascript
<br>
&nbsp;&nbsp;&nbsp;&nbsp; library files to support AutoComplete effect.<br>
&nbsp;&nbsp;&nbsp;&nbsp; files in this sample: jquery.min.js,jquery-ui.min.js<br>
<br>
<br>
Step 5. &nbsp;Create a new directory, &quot;Styles&quot;. Right-click the directory and click<br>
&nbsp; &nbsp; &nbsp; &nbsp; Add -&gt; New Item -&gt; Style Sheet File. reference jquery UI style files called
<br>
&nbsp;&nbsp;&nbsp;&nbsp; jquery-ui.css. To make the sample looks better, there refers one other UI
<br>
&nbsp;&nbsp;&nbsp;&nbsp; markups called site.css.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
<br>
Step 6. &nbsp;Open the Default.aspx,(If there is no Default.aspx, create one.)<br>
&nbsp; &nbsp; &nbsp; &nbsp; In the Head block, add javascript and style references like below.<br>
&nbsp;&nbsp;&nbsp;&nbsp; [CODE]<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;link rel=&quot;stylesheet&quot; href=&quot;Styles/jquery-ui.css&quot; type=&quot;text/css&quot; media=&quot;all&quot; /&gt;<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;link rel=&quot;stylesheet&quot; href=&quot;Styles/site.css&quot; type=&quot;text/css&quot; /&gt;<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;script type=&quot;text/javascript&quot; src=&quot;Scripts/jquery.min.js&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;script type=&quot;text/javascript&quot; src=&quot;Scripts/jquery-ui.min.js&quot;&gt;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; [/CODE]<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; write the autocomplete javascript as below.<br>
&nbsp;&nbsp;&nbsp;&nbsp; [CODE]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; $(function () {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$('#&lt;%= tbBookName.ClientID %&gt;').autocomplete({<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;source: &quot;AutoComplete.ashx&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;select: function (event, ui) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;.author&quot;).text(ui.item.Author);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;.genre&quot;).text(ui.item.Genre);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;.price&quot;).text(ui.item.Price);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;.publish_date&quot;).text(ui.item.Publish_date);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;.description&quot;).text(ui.item.Description);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp; });<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; [CODE]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; For more details, please refer to the Default.aspx in this sample.<br>
<br>
Step 7. &nbsp;Everything is ready, test the application and hope you can succeed.
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx">http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
