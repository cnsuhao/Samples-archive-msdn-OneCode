# Custom RadioButton grouping in Windows Forms (CSWinFormGroupRadioButtons)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2012-09-27 10:17:36
## Description

<h1>How to group the RadioButtons in the different containers (CSWinFormGroupRadioButtons)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to group the RadioButtons in the different containers.<span style="">&nbsp;
</span>When you check one of the 4 RadioButtons the checked one will auto unchecked. In other words, the 4 RadioButtons are grouped together even they are in the different containers.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Let the 4 Radiobuttons in different containers use the radioButton_CheckedChanged method to deal with their CheckedChanged event in the MainForm.Designer.cs file.</p>
<p class="MsoNormal">2. Use the radTmp Radiobutton to store the old RadioButton. First, set a RadioButton checked and point the radTmp to this RadioButton.</p>
<p class="MsoNormal">3. Uncheck the old one, and point the radTmp to the new checked RadioButton when each
<span class="SpellE">CheckedChanged</span> event occurs.<span style=""> </span>
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/67303/1/image.png" alt="" width="312" height="319" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // uncheck the old one
            radTmp.Checked = false;
            radTmp = (RadioButton)sender;
            
            // find out the checked one
            if (radTmp.Checked)
            {
                this.lb.Text = radTmp.Name &#43; &quot; has been selected&quot;;
            }
        }

</pre>
<pre id="codePreview" class="csharp">
private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // uncheck the old one
            radTmp.Checked = false;
            radTmp = (RadioButton)sender;
            
            // find out the checked one
            if (radTmp.Checked)
            {
                this.lb.Text = radTmp.Name &#43; &quot; has been selected&quot;;
            }
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">1. Windows Forms General FAQ.</p>
<p class="MsoNormal"><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a></p>
<p class="MsoNormal">2. Windows Forms RadioButton control</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/f5h102xz.aspx">http://msdn.microsoft.com/en-us/library/f5h102xz.aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
