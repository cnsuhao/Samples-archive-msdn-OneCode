# Get VSTO wrapper object (VBVstoGetWrapperObject)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Office
## Topics
* VSTO
## IsPublished
* True
## ModifiedDate
* 2012-12-06 11:16:09
## Description

<h1>VSTO (VBVstoGetWrapperObject)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The VBVstoGetWrapperObject project demonstrates how to get a VSTO wrapper<span style="">
</span>object from an existing Office COM object.This feature requires Visual Studio Tools for Office 3.0 SP1 (included in Visual Studio 2008 SP1) for both design-time and runtime support.On Excel Ribbon -&gt; VSTO Samples, click Get VSTO Wrapper (VB) button.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><b style=""><span style=""><img src="/site/view/file/72142/1/image.png" alt="" width="379" height="176" align="middle">
</span></b><b style=""><span style=""></span></b></p>
<p class="MsoNormal"><b style=""><span style=""><img src="/site/view/file/72143/1/image.png" alt="" width="682" height="592" align="middle">
</span></b><b style=""><span style=""></span></b></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">The click event handler as follows: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
  ''' &lt;summary&gt;
  ''' Adds
  ''' &lt;/summary&gt;
  Private Sub btnAddListObject_Click(sender As Object, e As EventArgs) Handles btnAddListObject.Click


      '' This is Microsoft.Office.Interop.Excel.Worksheet (COM)
      Dim ws As Excel.Worksheet = CType(cboWorksheets.SelectedItem, Excel.Worksheet)
      ws.Activate()


      '' This is Microsoft.Office.Tools.Excel.Worksheet (VSTO wrapper)
      Dim vstoWs As Worksheet = Globals.Factory.GetVstoObject(ws)


      Try


          '' Now we have the VSTO wrapper, add some VSTO objects to it...
          '' First a ListObject
          Dim lo As ListObject = vstoWs.Controls.AddListObject(vstoWs.Range(&quot;A3&quot;), &quot;myTable&quot;)
          '' Try bind some data to the ListObject
          lo.DataSource = GetDemoData()
          lo.DataMember = &quot;DemoTable&quot;


          '' Now add a button.
          Dim btnVsto As Button = vstoWs.Controls.AddButton(vstoWs.Range(&quot;A1&quot;), &quot;btnVSTO&quot;)
          btnVsto.Text = &quot;VSTO Button&quot;
          btnVsto.Width = 100
          btnVsto.Height = 23
          '' Setup the button Click event handler.
          AddHandler btnVsto.Click, AddressOf btnVsto_Click




      Catch rtEx As RuntimeException
          MessageBox.Show(rtEx.ToString(), &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
  End Sub

</pre>
<pre id="codePreview" class="vb">
  ''' &lt;summary&gt;
  ''' Adds
  ''' &lt;/summary&gt;
  Private Sub btnAddListObject_Click(sender As Object, e As EventArgs) Handles btnAddListObject.Click


      '' This is Microsoft.Office.Interop.Excel.Worksheet (COM)
      Dim ws As Excel.Worksheet = CType(cboWorksheets.SelectedItem, Excel.Worksheet)
      ws.Activate()


      '' This is Microsoft.Office.Tools.Excel.Worksheet (VSTO wrapper)
      Dim vstoWs As Worksheet = Globals.Factory.GetVstoObject(ws)


      Try


          '' Now we have the VSTO wrapper, add some VSTO objects to it...
          '' First a ListObject
          Dim lo As ListObject = vstoWs.Controls.AddListObject(vstoWs.Range(&quot;A3&quot;), &quot;myTable&quot;)
          '' Try bind some data to the ListObject
          lo.DataSource = GetDemoData()
          lo.DataMember = &quot;DemoTable&quot;


          '' Now add a button.
          Dim btnVsto As Button = vstoWs.Controls.AddButton(vstoWs.Range(&quot;A1&quot;), &quot;btnVSTO&quot;)
          btnVsto.Text = &quot;VSTO Button&quot;
          btnVsto.Width = 100
          btnVsto.Height = 23
          '' Setup the button Click event handler.
          AddHandler btnVsto.Click, AddressOf btnVsto_Click




      Catch rtEx As RuntimeException
          MessageBox.Show(rtEx.ToString(), &quot;GetVstoObject demo&quot;, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
  End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style="">Extending Word Documents and Excel Workbooks in Application-Level Add-ins at Run Time
</span></p>
<p class="MsoNormal">&nbsp;<span style=""><a href="http://msdn.microsoft.com/en-us/library/cc442981.aspx">http://msdn.microsoft.com/en-us/library/cc442981.aspx</a>
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
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
