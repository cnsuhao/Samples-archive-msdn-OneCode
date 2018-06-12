# VB Excel Automation addin (VBExcelAutomationAddIn)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* Automation Add-ins
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:23:18
## Description

<h1><span style="font-family:������">CLASS LIBRARY APPLICATION</span> (<span style="font-family:������">VBExcelAutomationAddIn</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span style="">VB</span>ExcelAutomationAddIn project is a class library project written in
<span style="">VB.NET. <span style="">&nbsp;</span></span>It illustrates how to write a managed COM component which can be used as an</p>
<p class="MsoNormal">Automation AddIn in Excel. The Automation AddIn can provide user defined functions for Excel.<span style="">
</span></p>
<h2><span style="">Building the sample </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Run your Visual Studio as administrator. </span>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Build the solution. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a Visual <span style="">VB.NET</span> class library project.</p>
<p class="MsoNormal">Step2. Import the following namepaces:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32

</pre>
<pre id="codePreview" class="vb">
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Use the following three attributes to decorate your class</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ComVisible(True), _
ClassInterface(ClassInterfaceType.AutoDual), _
Guid(&quot;83111578-8F0D-4821-835A-714DD2AACE3B&quot;)&gt; _

</pre>
<pre id="codePreview" class="vb">
&lt;ComVisible(True), _
ClassInterface(ClassInterfaceType.AutoDual), _
Guid(&quot;83111578-8F0D-4821-835A-714DD2AACE3B&quot;)&gt; _

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">You can generate an Guid using the integrated tool from Tools-&gt;Create GUID</p>
<p class="MsoNormal">Step4. Write public functions that will be exported as user defined functions (UDFs) in Excel. For example,
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function MinusNumbers(ByVal num1 As Double, _
                              Optional ByVal num2 As Object = Nothing, _
                              Optional ByVal num3 As Object = Nothing) _
                              As Double


       Dim result As Double = num1
       If Not TypeOf num2 Is Missing And Not num2 Is Nothing Then
           Dim r2 As Excel.Range = TryCast(num2, Excel.Range)
           result = (result - Convert.ToDouble(r2.get_Value2))
       End If
       If Not TypeOf num3 Is Missing And Not num3 Is Nothing Then
           Dim r3 As Excel.Range = TryCast(num3, Excel.Range)
           result = (result - Convert.ToDouble(r3.get_Value2))
       End If
       Return result


   End Function


   Public Function NumberOfCells(ByVal range As Object) As Double
       Dim r As Excel.Range = TryCast(range, Excel.Range)
       Return CDbl(r.get_Cells.get_Count)
   End Function

</pre>
<pre id="codePreview" class="vb">
Public Function MinusNumbers(ByVal num1 As Double, _
                              Optional ByVal num2 As Object = Nothing, _
                              Optional ByVal num3 As Object = Nothing) _
                              As Double


       Dim result As Double = num1
       If Not TypeOf num2 Is Missing And Not num2 Is Nothing Then
           Dim r2 As Excel.Range = TryCast(num2, Excel.Range)
           result = (result - Convert.ToDouble(r2.get_Value2))
       End If
       If Not TypeOf num3 Is Missing And Not num3 Is Nothing Then
           Dim r3 As Excel.Range = TryCast(num3, Excel.Range)
           result = (result - Convert.ToDouble(r3.get_Value2))
       End If
       Return result


   End Function


   Public Function NumberOfCells(ByVal range As Object) As Double
       Dim r As Excel.Range = TryCast(range, Excel.Range)
       Return CDbl(r.get_Cells.get_Count)
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Write two functions decorated with these attributes respectively</p>
<p class="MsoNormal">In the two functions, write registry keys that register / unregister the assembly as Excel automation add-in.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' This is function which is called when we register the dll
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;type&quot;&gt;&lt;/param&gt;
   ''' &lt;remarks&gt;&lt;/remarks&gt;
   &lt;ComRegisterFunction()&gt; _
   Public Shared Sub RegisterFunction(ByVal type As Type)


       ' Add the &quot;Programmable&quot; registry key under CLSID
       Registry.ClassesRoot.CreateSubKey(GetCLSIDSubKeyName( _
                                         type, &quot;Programmable&quot;))


       ' Register the full path to mscoree.dll which makes Excel happier.
       Dim key As RegistryKey = Registry.ClassesRoot.OpenSubKey( _
       GetCLSIDSubKeyName(type, &quot;InprocServer32&quot;), True)
       key.SetValue(&quot;&quot;, (Environment.SystemDirectory & &quot;\mscoree.dll&quot;), _
                    RegistryValueKind.String)


   End Sub


   ''' &lt;summary&gt;
   ''' This is function which is called when we unregister the dll
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;type&quot;&gt;&lt;/param&gt;
   ''' &lt;remarks&gt;&lt;/remarks&gt;
   &lt;ComUnregisterFunction()&gt; _
   Public Shared Sub UnregisterFunction(ByVal type As Type)


       ' Remove the &quot;Programmable&quot; registry key under CLSID
       Registry.ClassesRoot.DeleteSubKey( _
       GetCLSIDSubKeyName(type, &quot;Programmable&quot;), False)


   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' This is function which is called when we register the dll
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;type&quot;&gt;&lt;/param&gt;
   ''' &lt;remarks&gt;&lt;/remarks&gt;
   &lt;ComRegisterFunction()&gt; _
   Public Shared Sub RegisterFunction(ByVal type As Type)


       ' Add the &quot;Programmable&quot; registry key under CLSID
       Registry.ClassesRoot.CreateSubKey(GetCLSIDSubKeyName( _
                                         type, &quot;Programmable&quot;))


       ' Register the full path to mscoree.dll which makes Excel happier.
       Dim key As RegistryKey = Registry.ClassesRoot.OpenSubKey( _
       GetCLSIDSubKeyName(type, &quot;InprocServer32&quot;), True)
       key.SetValue(&quot;&quot;, (Environment.SystemDirectory & &quot;\mscoree.dll&quot;), _
                    RegistryValueKind.String)


   End Sub


   ''' &lt;summary&gt;
   ''' This is function which is called when we unregister the dll
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;type&quot;&gt;&lt;/param&gt;
   ''' &lt;remarks&gt;&lt;/remarks&gt;
   &lt;ComUnregisterFunction()&gt; _
   Public Shared Sub UnregisterFunction(ByVal type As Type)


       ' Remove the &quot;Programmable&quot; registry key under CLSID
       Registry.ClassesRoot.DeleteSubKey( _
       GetCLSIDSubKeyName(type, &quot;Programmable&quot;), False)


   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Register the output assembly as COM component.</p>
<p class="MsoNormal">To do this, click Project-&gt;Project Properties... button. And in the projectproperties page, navigate to Build tab and check the box &quot;Register for COM<span style="">
</span>interop&quot;.</p>
<p class="MsoNormal">Step7. Build your solution.</p>
<p class="MsoNormal">Step8. Open Excel, click the Office button-&gt;Excel Options. In the Excel<span style="">
</span>Options dialog, navigate to Add-Ins tab, and choose the Excel Add-ins in the<span style="">
</span>comboBox, click Go.</p>
<p class="MsoNormal">Step9. In Add-Ins dialog, click Automation button. In the Automation Servers<span style="">
</span>dialog, find VBExcelAutomationAddIn.MyFunctions. Select it and click OK for<span style="">
</span>twice. </p>
<p class="MsoNormal">Step10. Use the UDFs in the Excel workbook. <b><span style=""></span></b></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://support.microsoft.com/kb/291392">Excel COM add-ins and Automation add-ins</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://blogs.msdn.com/eric_carter/archive/2004/12/01/273127.aspx">Writing user defined functions for Excel in .NET</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://www.codeproject.com/KB/COM/excelnetauto.aspx">Create an Automation Add-In for Excel using .NET</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
