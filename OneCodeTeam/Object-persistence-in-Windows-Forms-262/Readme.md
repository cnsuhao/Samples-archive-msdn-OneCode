# Object persistence in Windows Forms (CSWinFormObjPersistence)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Serialization
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:03:42
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : CSWinFormObjPersistence Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The Object Persistance sample demonstrates how to persist an object's data <br>
between instances, so that the data can be restored the next time the object <br>
is instantiated. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Build the solution and run.<br>
2. Enter some value to Name, Age, Address field<br>
3. Close the form. <br>
4. Run the app again. You can see these value keeps in the field.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
This sample uses a binaray file &quot;Customer.bin&quot; to store the information.<br>
<br>
1. Create a class names Customer with some properties, and make the whole class<br>
&nbsp; as serializable by adding the Serializable attribute on top of the class <br>
&nbsp; definition. <br>
&nbsp; If you do not want to persist a field, mark it as NonSerialized. <br>
<br>
2. In the Form.Load event,check if the Customer.bin file exists, it the file <br>
&nbsp; exists, use BinaryFormatter.Deserialize method to retrieve the data stored
<br>
&nbsp; in it, otherwise create a new instance of Customer class.<br>
&nbsp; <br>
3. In the Form.FormClosing event,use BinaryFormatter.Serialize method to <br>
&nbsp; serialize the customer information to the Customer.bin file.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New">&nbsp; <br>
1. Walkthrough: Persisting an Object in Visual Basic .NET<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa984468(VS.71).aspx">
http://msdn.microsoft.com/en-us/library/aa984468(VS.71).aspx</a><br>
&nbsp; <br>
2. Windows Forms General FAQ.<br>
&nbsp; <a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">
http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
