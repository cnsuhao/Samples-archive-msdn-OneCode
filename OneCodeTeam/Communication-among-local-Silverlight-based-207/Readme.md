# Communication among local Silverlight-based applications (CSSL3LocalMessage)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Local Message
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:12:10
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3LocalMessage Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project create a whiteboard application demonstrating how to use local message<br>
in silverlight 3. To test this local messaging sample, open TestPage.html in two<br>
browsers, draw on one of the application, another one would keep synchronous.<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. How does this sample working?<br>
&nbsp; &nbsp;1. When starting application, use localmessagereceiver and localmessagesender<br>
&nbsp; &nbsp; &nbsp; to create a duplex communication channel.<br>
&nbsp; &nbsp;2. When drawing a stroke, serialize stroke object to a string, use localmessagesender<br>
&nbsp; &nbsp; &nbsp; send string to another applciation.<br>
&nbsp; &nbsp;3. When localmessagereceiver received stroke string, deserialize to stroke object,<br>
&nbsp; &nbsp; &nbsp; add to InkPresenter.<br>
<br>
2. How to establish duplex communication channel between two application?<br>
&nbsp; &nbsp;1. Preassign two names as LocalMessageReceiver name.<br>
&nbsp; &nbsp;2. Use one of its name to create LocalMessageReeciver, register messagereceived event,<br>
&nbsp; &nbsp; &nbsp; start listening by calling LocalMessageRecevier.Listen(). if got exception, it means
<br>
&nbsp; &nbsp; &nbsp; another application with same name in domain has started listening already, try use
<br>
&nbsp; &nbsp; &nbsp; another preset name to create receiver.<br>
&nbsp; &nbsp;3. When initializing LocalMessageReceiver successful, create LocalMessageSender targeting<br>
&nbsp; &nbsp; &nbsp; to another application's recever. Register messagesended event, handling the message send<br>
&nbsp; &nbsp; &nbsp; state and response message there. <br>
<br>
3. How to serialize/deserialize object for transfering by local message?<br>
&nbsp; &nbsp;Local message only accept text format message, to transfer object, we could use Xml or JSON<br>
&nbsp; &nbsp;Serializer. This sample use DataContractJsonSerializer to serialize/deserialize object.<br>
&nbsp; &nbsp;To serialize Stroke object to json string:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Serialize stroke object to string.<br>
&nbsp; &nbsp; &nbsp; &nbsp;var stream = new MemoryStream();<br>
&nbsp; &nbsp; &nbsp; &nbsp;_jsonserializer.WriteObject(stream, _newStroke);<br>
&nbsp; &nbsp; &nbsp; &nbsp;stream.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;stream.Position = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp;var obstring = new StreamReader(stream).ReadToEnd();<br>
&nbsp; &nbsp; &nbsp; &nbsp;stream.Close();<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;To deserialize string to Stroke object:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Deserialize json string to stroke object.<br>
&nbsp; &nbsp; &nbsp; &nbsp;var stream = new MemoryStream();<br>
&nbsp; &nbsp; &nbsp; &nbsp;var streamwriter = new StreamWriter(stream);<br>
&nbsp; &nbsp; &nbsp; &nbsp;streamwriter.Write(e.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;streamwriter.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;var receivedstroke = _jsonserializer.ReadObject(stream) as Stroke;<br>
&nbsp; &nbsp; &nbsp; &nbsp;stream.Close();<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;For details about DataContractJsonSerializer, please check msdn article<br>
&nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer(VS.95).aspx</a><br>
&nbsp; &nbsp;<br>
4. How to use implement drawing function?<br>
&nbsp; &nbsp;The drawing function is implemented by using InkPresenter.<br>
&nbsp; &nbsp;1. When mouseleftbuttondown, create new Stroke as currentstroke, add to InkPresenter.<br>
&nbsp; &nbsp;2. While mousemoving, if currentstroke is not null, add current position as new StylusPoints<br>
&nbsp; &nbsp; &nbsp; to currentstroke.<br>
&nbsp; &nbsp;3. When mouseleftbuttondown, set currentstroke to null.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;For creating more complex drawing function with inkprsenter, you could check &nbsp;<br>
&nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc721604.aspx">http://msdn.microsoft.com/en-us/magazine/cc721604.aspx</a><br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Communication Between Local Silverlight-Based Applications<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd833063(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd833063(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
