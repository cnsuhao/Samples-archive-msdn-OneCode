# Get VSTO wrapper object (CSVstoGetWrapperObject)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* VSTO
## IsPublished
* True
## ModifiedDate
* 2012-12-06 11:16:24
## Description

<h1><span class="SpellE">VSTO</span> (<span class="SpellE">CSVstoGetWrapperObject</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span class="SpellE">CSVstoGetWrapperObject</span> project demonstrates how to get a VSTO wrapper<span style="">
</span>object from an existing Office COM object.This feature requires Visual Studio Tools for Office 3.0 SP1 (included in Visual Studio 2008 SP1) for both design-time and runtime support.On Excel Ribbon -&gt; VSTO Samples, click Get VSTO Wrapper (<span style="">C#</span>)
 button.<span style="">&nbsp; </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><b style=""><span style=""><img src="/site/view/file/72145/1/image.png" alt="" width="379" height="176" align="middle">
</span></b><b style=""><span style=""></span></b></p>
<p class="MsoNormal"><b style=""><span style=""><img src="/site/view/file/72146/1/image.png" alt="" width="816" height="645" align="middle">
</span></b><b style=""><span style=""></span></b></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">The click event handler as follows: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnAddListObject_Click(object sender, EventArgs e)
{
    // This is Microsoft.Office.Interop.Excel.Worksheet (COM)
    Excel.Worksheet ws = (Excel.Worksheet)cboWorksheets.SelectedItem;
    ws.Activate();


    // This is Microsoft.Office.Tools.Excel.Worksheet (VSTO wrapper)
    Worksheet vstoWs = Worksheet.GetVstoObject(ws);


    try
    {
        // Now we have the VSTO wrapper, add some VSTO objects to it...
        // First a ListObject
        ListObject lo = vstoWs.Controls.AddListObject(vstoWs.Range[&quot;A3&quot;, Type.Missing], &quot;myTable&quot;);
        // Try bind some data to the ListObject
        lo.DataSource = GetDemoData();
        lo.DataMember = &quot;DemoTable&quot;;


        // Now add a button.
        Button btnVsto = vstoWs.Controls.AddButton(vstoWs.Range[&quot;A1&quot;, Type.Missing], &quot;btnVSTO&quot;);
        btnVsto.Text = &quot;VSTO Button&quot;;
        btnVsto.Width = 100;
        btnVsto.Height = 23;
        // Setup the button Click event handler.
        btnVsto.Click &#43;= delegate(object s, EventArgs args)
        {
            MessageBox.Show(&quot;VSTO button clicked.&quot;, &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
    }
    catch (RuntimeException rtEx)
    {
        MessageBox.Show(rtEx.ToString(), &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

</pre>
<pre id="codePreview" class="csharp">
private void btnAddListObject_Click(object sender, EventArgs e)
{
    // This is Microsoft.Office.Interop.Excel.Worksheet (COM)
    Excel.Worksheet ws = (Excel.Worksheet)cboWorksheets.SelectedItem;
    ws.Activate();


    // This is Microsoft.Office.Tools.Excel.Worksheet (VSTO wrapper)
    Worksheet vstoWs = Worksheet.GetVstoObject(ws);


    try
    {
        // Now we have the VSTO wrapper, add some VSTO objects to it...
        // First a ListObject
        ListObject lo = vstoWs.Controls.AddListObject(vstoWs.Range[&quot;A3&quot;, Type.Missing], &quot;myTable&quot;);
        // Try bind some data to the ListObject
        lo.DataSource = GetDemoData();
        lo.DataMember = &quot;DemoTable&quot;;


        // Now add a button.
        Button btnVsto = vstoWs.Controls.AddButton(vstoWs.Range[&quot;A1&quot;, Type.Missing], &quot;btnVSTO&quot;);
        btnVsto.Text = &quot;VSTO Button&quot;;
        btnVsto.Width = 100;
        btnVsto.Height = 23;
        // Setup the button Click event handler.
        btnVsto.Click &#43;= delegate(object s, EventArgs args)
        {
            MessageBox.Show(&quot;VSTO button clicked.&quot;, &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
    }
    catch (RuntimeException rtEx)
    {
        MessageBox.Show(rtEx.ToString(), &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style="">Extending Word Documents and Excel Workbooks in Application-Level Add-ins at Run Time
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/cc442981.aspx">http://msdn.microsoft.com/en-us/library/cc442981.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">How to: Customize the Ribbon </span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-US/library/aa942954(v=VS.80).aspx">http://msdn.microsoft.com/en-US/library/aa942954(v=VS.80).aspx</a>
</span></p>
<p class="MsoNormal"><span style="">Working with Datasets in Visual Studio </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/8bw9ksd6.aspx">http://msdn.microsoft.com/en-us/library/8bw9ksd6.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">How to: Open a Dataset in the Dataset Designer
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/7973zb70.aspx">http://msdn.microsoft.com/en-us/library/7973zb70.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">Office for developers </span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/office/">http://msdn.microsoft.com/en-us/office/</a>
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
