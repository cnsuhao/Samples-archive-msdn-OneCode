# C# Excel Automation addin (CSExcelAutomationAddIn)
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
* 2012-03-01 11:23:49
## Description

<h1><span style="font-family:������">OFFICE ADD-IN</span> (<span style="font-family:������">CSExcelAutomationAddIn</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The CSExcelAutomationAddIn project is a class library project written in C#.<span style="">
</span>It illustrates how to write a managed COM component which can be used as an
</p>
<p class="MsoNormal">Automation AddIn in Excel. The Automation AddIn can provide user defined functions for Excel.<span style="">
</span></p>
<h2><span style="">Building the sample </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Run your Visual Studio as administrator. </span>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Build the solution. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a Visual C# class library project. </p>
<p class="MsoNormal">Step2. Import the following namepaces: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using Microsoft.Win32;
using System.Runtime.InteropServices;

</pre>
<pre id="codePreview" class="csharp">
using Microsoft.Win32;
using System.Runtime.InteropServices;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Use the following three attributes to decorate your class
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[Guid(&quot;7127696E-AB87-427a-BC85-AB3CBA301CF3&quot;)]
[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]

</pre>
<pre id="codePreview" class="csharp">
[Guid(&quot;7127696E-AB87-427a-BC85-AB3CBA301CF3&quot;)]
[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">You can generate an Guid using the integrated tool from Tools-&gt;Create GUID
</p>
<p class="MsoNormal">Step4. Write public functions that will be exported as user defined functions (UDFs) in Excel. For example,
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       public double AddNumbers(double num1, [Optional] object num2, 
           [Optional] object num3)
       {
           double result = num1;


           if (!(num2 is System.Reflection.Missing))
           {
               Excel.Range r2 = num2 as Excel.Range;
               result &#43;= Convert.ToDouble(r2.Value2);
           }


           if (!(num3 is System.Reflection.Missing))
           {
               Excel.Range r3 = num3 as Excel.Range;
               result &#43;= Convert.ToDouble(r3.Value2);
           }


           return result;
       }


       public double NumberOfCells(object range)
       {
           Excel.Range r = range as Excel.Range;
           return r.Cells.Count;
       }

</pre>
<pre id="codePreview" class="csharp">
       public double AddNumbers(double num1, [Optional] object num2, 
           [Optional] object num3)
       {
           double result = num1;


           if (!(num2 is System.Reflection.Missing))
           {
               Excel.Range r2 = num2 as Excel.Range;
               result &#43;= Convert.ToDouble(r2.Value2);
           }


           if (!(num3 is System.Reflection.Missing))
           {
               Excel.Range r3 = num3 as Excel.Range;
               result &#43;= Convert.ToDouble(r3.Value2);
           }


           return result;
       }


       public double NumberOfCells(object range)
       {
           Excel.Range r = range as Excel.Range;
           return r.Cells.Count;
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Write two functions decorated with these attributes respectively
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ComRegisterFunctionAttribute]
[ComUnregisterFunctionAttribute]

</pre>
<pre id="codePreview" class="csharp">
[ComRegisterFunctionAttribute]
[ComUnregisterFunctionAttribute]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In the two functions, write registry keys that register / unregister the assembly as Excel automation add-in.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       [ComRegisterFunction]
       public static void RegisterFunction(Type type)
       {
           // Add the &quot;Programmable&quot; registry key under CLSID
           Registry.ClassesRoot.CreateSubKey(
               GetCLSIDSubKeyName(type, &quot;Programmable&quot;));


           // Register the full path to mscoree.dll which makes Excel happier.
           RegistryKey key = Registry.ClassesRoot.OpenSubKey(
               GetCLSIDSubKeyName(type, &quot;InprocServer32&quot;), true);
           key.SetValue(&quot;&quot;, 
               System.Environment.SystemDirectory &#43; @&quot;\mscoree.dll&quot;,
               RegistryValueKind.String);
       }


       [ComUnregisterFunction]
       public static void UnregisterFunction(Type type)
       {
           // Remove the &quot;Programmable&quot; registry key under CLSID
           Registry.ClassesRoot.DeleteSubKey(
               GetCLSIDSubKeyName(type, &quot;Programmable&quot;), false);
       }

</pre>
<pre id="codePreview" class="csharp">
       [ComRegisterFunction]
       public static void RegisterFunction(Type type)
       {
           // Add the &quot;Programmable&quot; registry key under CLSID
           Registry.ClassesRoot.CreateSubKey(
               GetCLSIDSubKeyName(type, &quot;Programmable&quot;));


           // Register the full path to mscoree.dll which makes Excel happier.
           RegistryKey key = Registry.ClassesRoot.OpenSubKey(
               GetCLSIDSubKeyName(type, &quot;InprocServer32&quot;), true);
           key.SetValue(&quot;&quot;, 
               System.Environment.SystemDirectory &#43; @&quot;\mscoree.dll&quot;,
               RegistryValueKind.String);
       }


       [ComUnregisterFunction]
       public static void UnregisterFunction(Type type)
       {
           // Remove the &quot;Programmable&quot; registry key under CLSID
           Registry.ClassesRoot.DeleteSubKey(
               GetCLSIDSubKeyName(type, &quot;Programmable&quot;), false);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Register the output assembly as COM component. </p>
<p class="MsoNormal">To do this, click Project-&gt;Project Properties... button. And in the projectproperties page, navigate to Build tab and check the box &quot;Register for COM<span style="">
</span>interop&quot;. </p>
<p class="MsoNormal">Step7. Build your solution. </p>
<p class="MsoNormal">Step8. Open Excel, click the Office button-&gt;Excel Options. In the Excel<span style="">
</span>Options dialog, navigate to Add-Ins tab, and choose the Excel Add-ins in the<span style="">
</span>comboBox, click Go. </p>
<p class="MsoNormal">Step9. In Add-Ins dialog, click Automation button. In the Automation Servers<span style="">
</span>dialog, find CSExcelAutomationAddIn.MyFunctions. Select it and click OK for<span style="">
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
