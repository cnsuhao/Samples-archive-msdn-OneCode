# C++ app uses ADO to access database (CppUseADO)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* ADO
## Topics
* Data Platform
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:32:59
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">CppUseADO</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The CppUseADO sample demonstrates the Microsoft ActiveX Data Objects (ADO) technology to access databases using #import and Visual C&#43;&#43;. It shows the basic structure of connecting to a data source, issuing SQL commands, using the Recordset
 object and performing the cleanup.<span style="">&nbsp; </span><span style=""></span></p>
<h2><span style="">Compiling the sample </span></h2>
<p class="MsoListParagraph" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">First you need to append data file
</span></b></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>You just append the *.MDF to your database server.<b style=""> </b></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">There are two methods to connect to the database</span></b><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:54.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use Integrated security to connect the database</p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:36.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">You needn��t to config username and password in your database server. Just comment code like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Define the connection string. (The data source is created in the 
// sample SQLServer2005DB)


// Method 1: Use Integrated security to connect the database. 
_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Integrated Security=SSPI;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
// Open the connection
hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
hr = spConn-&gt;Open(bstrConn, &quot;&quot;,&quot;&quot;, NULL);


//// Method 2: Don't use Integrated security connect the database.
//_bstr_t bstrUserID(&quot;HelloWorld&quot;);
//_bstr_t bstrPassword(&quot;111111&quot;);
//_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
//// Open the connection
//hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
//hr = spConn-&gt;Open(bstrConn, bstrUserID, bstrPassword, NULL);

</pre>
<pre id="codePreview" class="cplusplus">
// Define the connection string. (The data source is created in the 
// sample SQLServer2005DB)


// Method 1: Use Integrated security to connect the database. 
_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Integrated Security=SSPI;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
// Open the connection
hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
hr = spConn-&gt;Open(bstrConn, &quot;&quot;,&quot;&quot;, NULL);


//// Method 2: Don't use Integrated security connect the database.
//_bstr_t bstrUserID(&quot;HelloWorld&quot;);
//_bstr_t bstrPassword(&quot;111111&quot;);
//_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
//// Open the connection
//hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
//hr = spConn-&gt;Open(bstrConn, bstrUserID, bstrPassword, NULL);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:36.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;</span> </span></p>
<p class="MsoListParagraph" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:54.0pt; margin-bottom:.0001pt; text-indent:-18.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use username and password to connect the database</p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:36.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">You need to add a new user<span class="GramE"> ��</span>HelloWord�� and set the password as ��111111�� in your database server. Then comment code like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
//// Method 1: Use Integrated security to connect the database. 
//_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Integrated Security=SSPI;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
//// Open the connection
//hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
//hr = spConn-&gt;Open(bstrConn, &quot;&quot;,&quot;&quot;, NULL);


// Method 2: Don't use Integrated security connect the database.
_bstr_t bstrUserID(&quot;HelloWorld&quot;);
_bstr_t bstrPassword(&quot;111111&quot;);
_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
// Open the connection
hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
hr = spConn-&gt;Open(bstrConn, bstrUserID, bstrPassword, NULL);

</pre>
<pre id="codePreview" class="cplusplus">
//// Method 1: Use Integrated security to connect the database. 
//_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Integrated Security=SSPI;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
//// Open the connection
//hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
//hr = spConn-&gt;Open(bstrConn, &quot;&quot;,&quot;&quot;, NULL);


// Method 2: Don't use Integrated security connect the database.
_bstr_t bstrUserID(&quot;HelloWorld&quot;);
_bstr_t bstrPassword(&quot;111111&quot;);
_bstr_t bstrConn(&quot;Provider=SQLOLEDB.1;Data Source=localhost\\SQLEXPRESS;Initial Catalog=SQLServer2005DB;&quot;);
// Open the connection
hr = spConn.CreateInstance(__uuidof(ADODB::Connection));
hr = spConn-&gt;Open(bstrConn, bstrUserID, bstrPassword, NULL);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53125/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<h2>Using the Code</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">1. Connect to the data source. (ADODB::Connection15::Open)
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">2. Build and execute an ADO command. (ADODB::Command15::Execute)
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The command can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">procedure call.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">3. Use the Recordset object. (ADODB::Recordset15::Open / MoveFirst / MoveNext / Fields / Update / UpdateBatch)
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Recordset represents the entire set of records from a base table or the results of an executed command. It facilitates the enumeration, insertion, update,
 deletion of records. At any time, the Recordset object refers to only a single record within the set as the current record.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">4. Clean up objects before exit. (ADODB::Recordset15::Close, ADODB::Connection15::Close)
</span></h2>
<h2>More Information<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<a href="http://support.microsoft.com/kb/229088">SAMPLE: Vcspnp.exe Demonstrates Passing SQL NULL Parameters and Reading NULL Values with ADO</a>
<a href="http://www.w3schools.com/ADO/ado_datatypes.asp">ADO Data Types<span style="">
</span>(The table below shows the ADO Data Type mapping between Access, SQL Server)</a>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
