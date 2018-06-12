# TFS Data Warehouse Adapter (CSTFSDataWarehouseAdapter)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* TFS
## Topics
* TFS
* TFS warehouse adapter
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:22:31
## Description

<p style="font-family:Courier New"></p>
<h2>C# TFS: CSTFSDataWarehouseAdapter Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use: </h3>
<p style="font-family:Courier New"><br>
This C# sample works for Team Foundation Server 2008. &nbsp;It demostrates how to
<br>
create a TFS warehouse adapter and populates data into the custom fact. <br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create a new Windows Console application named &quot;CSTFSDataWarehouseAdapter&quot;.<br>
<br>
2. Add reference to Microsoft.TeamFoundation.dll, <br>
&nbsp; Microsoft.TeamFoundation.Client.dll and Microsoft.TeamFoundation.Common.dll.<br>
&nbsp; They are located in GAC at computers where Team Explorer is installed. &nbsp;
<br>
&nbsp; <br>
3. Copy the content in the CreatedFactDemo.cs in the sample to your project.<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
1. Compile the project. <br>
<br>
2. Copy the genetated CSTFSDataWarehouseAdapter.dll into <br>
&nbsp; &quot;Web Services\Warehouse\bin\Plugins&quot; in the installation folder of TFS on the
<br>
&nbsp; application tier. <br>
<br>
3. Restart IIS by running &quot;iisreset&quot; from command prompt. <br>
<br>
4. On the application tier, navigate to <br>
&nbsp; <a target="_blank" href="&lt;a target=" href="http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run">
http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run</a>'&gt;<a target="_blank" href="http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run">http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run</a> and
<br>
&nbsp; click Invoke.<br>
<br>
</p>
<h3>Debug: </h3>
<p style="font-family:Courier New"><br>
The adpater is loadded in worker process of TFS web site. To debug the adapter,<br>
you need to attache to the worker process with Visual Studio.<br>
<br>
Additionally, TFS writes error messages related to the warehouse adapters to <br>
Windows Event Log. You can check the logged errors there in case your adapter is<br>
not executed during warehare synchronization. <br>
<br>
When Visual Studio is installed on the application tier, you can debug with the <br>
below steps:<br>
<br>
1. Open the project with Visual Studio in the application tier and set break points.
<br>
<br>
2. Navigate to <a target="_blank" href="http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx.">
http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx.</a> This<br>
&nbsp; step ensure the work process of the TFS web site is tarted. <br>
&nbsp; <br>
3. In Visual Studio, click Tools-&gt;Attache to Process.<br>
<br>
4. Check &quot;Show processes from all sessions&quot;. <br>
<br>
5. Double click the w3wp.exe process which runs under the TFSSERVICE account.<br>
<br>
6. Navigate to <a target="_blank" href="&lt;a target=" href="http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run">
http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run</a>'&gt;<a target="_blank" href="http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run">http://localhost:8080/Warehouse/v1.0/warehousecontroller.asmx?op=Run</a>
<br>
&nbsp; and click Invoke.<br>
<br>
<br>
If Visual Studio is not installed on the application tier, you can setup the remote<br>
debugger on it, then debug the adapter from another machine. The remote debugger <br>
enables us to attach to remote process. Please follow the link in the references to<br>
configure remote debugger.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. Remote Debugging Setup<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/y7f5zaaa.aspx">
http://msdn.microsoft.com/en-us/library/y7f5zaaa.aspx</a><br>
<br>
2. How to: Create an Adapter<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb286956.aspx">
http://msdn.microsoft.com/en-us/library/bb286956.aspx</a><br>
<br>
<br>
&nbsp; <br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
