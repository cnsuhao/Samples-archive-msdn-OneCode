# Customize Outlook UI with Ribbon XML (VBOutlookRibbonXml)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* VSTO
* Ribbon
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:08:27
## Description

<h1>OFFICE ADD-IN (<span style="">VB</span>OutlookRibbonXml)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span style="">VB</span>OutlookRibbonXml provides the examples on how to customize Office UI using the Ribbon XML. This sample also shows a way on how to keep &amp; track the same control's property status (e.g. Checked) in different
 inspectors.<span style=""> </span></p>
<h2><span style="">Building the sample </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">You must install office 2010 in your Operation System.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>This project references the <span style="">P</span>rimary <span style="">
I</span>nterop <span style="">A</span>ssembly <span style="">(PIA )</span>for Microsoft Office Outlook 20<span style="">10.</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Be sure that your Outlook2010 is not running when building sample.
</span></p>
<h2><span style=""></span></h2>
<h2><span style="">Running the Code </span></h2>
<p class="MsoNormal"><span style="">When you run the code, an Outlook was launched. Click ��New E-mail�� in ��Home�� tab. A new e-mail window shows out with ��Sample Tab�� tab.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53688/1/image.png" alt="" width="720" height="305" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. We need to create an XML file containing description of our customized Ribbon contents.
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
&lt;customUI onLoad=&quot;Ribbon_Load&quot; loadImage=&quot;LoadImage&quot; xmlns=&quot;http://schemas.microsoft.com/office/2006/01/customui&quot;&gt;
  &lt;ribbon&gt;
    &lt;tabs&gt;
      &lt;tab idMso=&quot;TabAddIns&quot; label=&quot;Sample Tab&quot; keytip=&quot;FT&quot;&gt;
        &lt;group id=&quot;grpOne&quot; label=&quot;Group One&quot;&gt;
          &lt;button id=&quot;btnWeb&quot; onAction=&quot;btnWeb_OnAction&quot; label=&quot;Project Home&quot; size=&quot;large&quot; image=&quot;Globe&quot; /&gt;
          &lt;separator id=&quot;separator1&quot; /&gt;
          &lt;comboBox id=&quot;cboMyList&quot; imageMso=&quot;FormControlComboBox&quot; supertip=&quot;This is a ComboBox&#xD;&#xA;Drop down and Edit are both enabled.&quot; label=&quot;ComboBox:&quot;&gt;
            &lt;item id=&quot;__id2&quot; label=&quot;Item0&quot; /&gt;
            &lt;item id=&quot;__id3&quot; label=&quot;Item1&quot; /&gt;
            &lt;item id=&quot;__id4&quot; label=&quot;Item2&quot; /&gt;
          &lt;/comboBox&gt;
          &lt;toggleButton id=&quot;tbSecondTab&quot; imageMso=&quot;ControlTabControl&quot; onAction=&quot;tbSecondTab_OnAction&quot; getPressed=&quot;tbSecondTab_GetPressed&quot; label=&quot;Second Tab&quot; /&gt;
          &lt;checkBox id=&quot;chkShowGroup&quot; onAction=&quot;chkShowGroup_OnAction&quot; getPressed=&quot;chkShowGroup_GetPressed&quot; label=&quot;Group Three&quot; /&gt;
          &lt;dialogBoxLauncher&gt;
            &lt;button id=&quot;grpOneDlgLauncher&quot; onAction=&quot;grpOneDlgLauncher_OnAction&quot; /&gt;
          &lt;/dialogBoxLauncher&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpTwo&quot; label=&quot;Group Two&quot;&gt;
          &lt;splitButton id=&quot;splitButton&quot;&gt;
            &lt;button id=&quot;splitButton__btn&quot; imageMso=&quot;AlignLeft&quot; label=&quot;SplitButton&quot; onAction=&quot;splitButton_Click&quot; /&gt;
            &lt;menu id=&quot;splitButton__mnu&quot;&gt;
              &lt;button id=&quot;btnAlignLeft&quot; imageMso=&quot;AlignLeft&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Left&quot; /&gt;
              &lt;button id=&quot;btnAlignCenter&quot; imageMso=&quot;AlignCenter&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Center&quot; /&gt;
              &lt;button id=&quot;btnAlignRight&quot; imageMso=&quot;AlignRight&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Right&quot; /&gt;
            &lt;/menu&gt;
          &lt;/splitButton&gt;
          &lt;editBox id=&quot;txtEdit&quot; imageMso=&quot;ActiveXTextBox&quot; onChange=&quot;txtEdit_OnChange&quot; label=&quot;Edit Box:&quot; /&gt;
          &lt;labelControl id=&quot;lblSample&quot; getLabel=&quot;lblSample_GetLabel&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpThree&quot; label=&quot;Group Three&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;buttonGroup id=&quot;buttonGroup1&quot;&gt;
            &lt;button id=&quot;btnOne&quot; label=&quot;One&quot; showImage=&quot;false&quot; /&gt;
            &lt;button id=&quot;btnTwo&quot; label=&quot;Two&quot; showImage=&quot;false&quot; /&gt;
            &lt;button id=&quot;button10&quot; label=&quot;Three&quot; showImage=&quot;false&quot; /&gt;
          &lt;/buttonGroup&gt;
          &lt;dynamicMenu id=&quot;mnuSample&quot; imageMso=&quot;HappyFace&quot; label=&quot;Menu Sample&quot; getContent=&quot;Ribbon_GetContent&quot; /&gt;
          &lt;separator id=&quot;separator3&quot; /&gt;
          &lt;gallery id=&quot;glrCd&quot; label=&quot;Disk Gallery&quot; size=&quot;large&quot; image=&quot;BlankCD&quot;&gt;
            &lt;item id=&quot;glrAudioCD&quot; label=&quot;Audio CD&quot; image=&quot;AudioCD&quot; /&gt;
            &lt;item id=&quot;glrAudioCDPlus&quot; label=&quot;Audio CD Plus&quot; image=&quot;AudioCDPlus&quot; /&gt;
            &lt;item id=&quot;glrAudioDVD&quot; label=&quot;Audio DVD&quot; image=&quot;AudioDVD&quot; /&gt;
            &lt;item id=&quot;glrBDMovie&quot; label=&quot;BD Movie Disk&quot; image=&quot;BDMovie&quot; /&gt;
            &lt;item id=&quot;glrBlankCD&quot; label=&quot;Blank CD&quot; image=&quot;BlankCD&quot; /&gt;
            &lt;item id=&quot;glrVCD&quot; label=&quot;VCD&quot; image=&quot;VCD&quot; /&gt;
            &lt;button id=&quot;btnBurnDisk&quot; label=&quot;Burn Disk&quot; image=&quot;BurnCD&quot; /&gt;
          &lt;/gallery&gt;
        &lt;/group&gt;
      &lt;/tab&gt;
      &lt;tab id=&quot;mySecondTab&quot; label=&quot;Second Sample Tab&quot; getVisible=&quot;GetVisible&quot;&gt;
        &lt;group id=&quot;grpMail&quot; label=&quot;Mail Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;lblMailMode&quot; getLabel=&quot;lblMainMode_GetLabel&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpAppointmentItem&quot; label=&quot;Appointment Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label1&quot; label=&quot;This is an Appointment Item&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpTaskItem&quot; label=&quot;Task Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label2&quot; label=&quot;This is a Task Item&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpContactItem&quot; label=&quot;Contact Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label3&quot; label=&quot;This is a Contact Item&quot; /&gt;
        &lt;/group&gt;
      &lt;/tab&gt;
    &lt;/tabs&gt;
  &lt;/ribbon&gt;
&lt;/customUI&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
&lt;customUI onLoad=&quot;Ribbon_Load&quot; loadImage=&quot;LoadImage&quot; xmlns=&quot;http://schemas.microsoft.com/office/2006/01/customui&quot;&gt;
  &lt;ribbon&gt;
    &lt;tabs&gt;
      &lt;tab idMso=&quot;TabAddIns&quot; label=&quot;Sample Tab&quot; keytip=&quot;FT&quot;&gt;
        &lt;group id=&quot;grpOne&quot; label=&quot;Group One&quot;&gt;
          &lt;button id=&quot;btnWeb&quot; onAction=&quot;btnWeb_OnAction&quot; label=&quot;Project Home&quot; size=&quot;large&quot; image=&quot;Globe&quot; /&gt;
          &lt;separator id=&quot;separator1&quot; /&gt;
          &lt;comboBox id=&quot;cboMyList&quot; imageMso=&quot;FormControlComboBox&quot; supertip=&quot;This is a ComboBox&#xD;&#xA;Drop down and Edit are both enabled.&quot; label=&quot;ComboBox:&quot;&gt;
            &lt;item id=&quot;__id2&quot; label=&quot;Item0&quot; /&gt;
            &lt;item id=&quot;__id3&quot; label=&quot;Item1&quot; /&gt;
            &lt;item id=&quot;__id4&quot; label=&quot;Item2&quot; /&gt;
          &lt;/comboBox&gt;
          &lt;toggleButton id=&quot;tbSecondTab&quot; imageMso=&quot;ControlTabControl&quot; onAction=&quot;tbSecondTab_OnAction&quot; getPressed=&quot;tbSecondTab_GetPressed&quot; label=&quot;Second Tab&quot; /&gt;
          &lt;checkBox id=&quot;chkShowGroup&quot; onAction=&quot;chkShowGroup_OnAction&quot; getPressed=&quot;chkShowGroup_GetPressed&quot; label=&quot;Group Three&quot; /&gt;
          &lt;dialogBoxLauncher&gt;
            &lt;button id=&quot;grpOneDlgLauncher&quot; onAction=&quot;grpOneDlgLauncher_OnAction&quot; /&gt;
          &lt;/dialogBoxLauncher&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpTwo&quot; label=&quot;Group Two&quot;&gt;
          &lt;splitButton id=&quot;splitButton&quot;&gt;
            &lt;button id=&quot;splitButton__btn&quot; imageMso=&quot;AlignLeft&quot; label=&quot;SplitButton&quot; onAction=&quot;splitButton_Click&quot; /&gt;
            &lt;menu id=&quot;splitButton__mnu&quot;&gt;
              &lt;button id=&quot;btnAlignLeft&quot; imageMso=&quot;AlignLeft&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Left&quot; /&gt;
              &lt;button id=&quot;btnAlignCenter&quot; imageMso=&quot;AlignCenter&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Center&quot; /&gt;
              &lt;button id=&quot;btnAlignRight&quot; imageMso=&quot;AlignRight&quot; onAction=&quot;btnAlign_Click&quot; label=&quot;Right&quot; /&gt;
            &lt;/menu&gt;
          &lt;/splitButton&gt;
          &lt;editBox id=&quot;txtEdit&quot; imageMso=&quot;ActiveXTextBox&quot; onChange=&quot;txtEdit_OnChange&quot; label=&quot;Edit Box:&quot; /&gt;
          &lt;labelControl id=&quot;lblSample&quot; getLabel=&quot;lblSample_GetLabel&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpThree&quot; label=&quot;Group Three&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;buttonGroup id=&quot;buttonGroup1&quot;&gt;
            &lt;button id=&quot;btnOne&quot; label=&quot;One&quot; showImage=&quot;false&quot; /&gt;
            &lt;button id=&quot;btnTwo&quot; label=&quot;Two&quot; showImage=&quot;false&quot; /&gt;
            &lt;button id=&quot;button10&quot; label=&quot;Three&quot; showImage=&quot;false&quot; /&gt;
          &lt;/buttonGroup&gt;
          &lt;dynamicMenu id=&quot;mnuSample&quot; imageMso=&quot;HappyFace&quot; label=&quot;Menu Sample&quot; getContent=&quot;Ribbon_GetContent&quot; /&gt;
          &lt;separator id=&quot;separator3&quot; /&gt;
          &lt;gallery id=&quot;glrCd&quot; label=&quot;Disk Gallery&quot; size=&quot;large&quot; image=&quot;BlankCD&quot;&gt;
            &lt;item id=&quot;glrAudioCD&quot; label=&quot;Audio CD&quot; image=&quot;AudioCD&quot; /&gt;
            &lt;item id=&quot;glrAudioCDPlus&quot; label=&quot;Audio CD Plus&quot; image=&quot;AudioCDPlus&quot; /&gt;
            &lt;item id=&quot;glrAudioDVD&quot; label=&quot;Audio DVD&quot; image=&quot;AudioDVD&quot; /&gt;
            &lt;item id=&quot;glrBDMovie&quot; label=&quot;BD Movie Disk&quot; image=&quot;BDMovie&quot; /&gt;
            &lt;item id=&quot;glrBlankCD&quot; label=&quot;Blank CD&quot; image=&quot;BlankCD&quot; /&gt;
            &lt;item id=&quot;glrVCD&quot; label=&quot;VCD&quot; image=&quot;VCD&quot; /&gt;
            &lt;button id=&quot;btnBurnDisk&quot; label=&quot;Burn Disk&quot; image=&quot;BurnCD&quot; /&gt;
          &lt;/gallery&gt;
        &lt;/group&gt;
      &lt;/tab&gt;
      &lt;tab id=&quot;mySecondTab&quot; label=&quot;Second Sample Tab&quot; getVisible=&quot;GetVisible&quot;&gt;
        &lt;group id=&quot;grpMail&quot; label=&quot;Mail Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;lblMailMode&quot; getLabel=&quot;lblMainMode_GetLabel&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpAppointmentItem&quot; label=&quot;Appointment Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label1&quot; label=&quot;This is an Appointment Item&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpTaskItem&quot; label=&quot;Task Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label2&quot; label=&quot;This is a Task Item&quot; /&gt;
        &lt;/group&gt;
        &lt;group id=&quot;grpContactItem&quot; label=&quot;Contact Item&quot; getVisible=&quot;GetVisible&quot;&gt;
          &lt;labelControl id=&quot;label3&quot; label=&quot;This is a Contact Item&quot; /&gt;
        &lt;/group&gt;
      &lt;/tab&gt;
    &lt;/tabs&gt;
  &lt;/ribbon&gt;
&lt;/customUI&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Create a class that implements the Microsoft.Office.Core.IRibbonExtensibility class.
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Runtime.InteropServices.ComVisible(True)&gt; _
Public Class Ribbon
    Implements Office.IRibbonExtensibility

</pre>
<pre id="codePreview" class="vb">
&lt;Runtime.InteropServices.ComVisible(True)&gt; _
Public Class Ribbon
    Implements Office.IRibbonExtensibility

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. In Ribbon.vb, implement the GetCustomUI (memeber of IRibbonExtensibility) method. In this method, we return Ribbon XML according to the RibbonID passed in.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
       ' We will show our customized Ribbon on the following types of
       ' inspectors
       If ribbonID = &quot;Microsoft.Word.Document&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Mail.Read&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Mail.Compose&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.MeetingRequest.Read&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.MeetingRequest.Send&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Appointment&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Contact&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Task&quot; Then


           Return GetResourceText(&quot;VBOutlookRibbonXml.Ribbon.xml&quot;)


       Else
           Return Nothing
       End If
   End Function

</pre>
<pre id="codePreview" class="vb">
Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
       ' We will show our customized Ribbon on the following types of
       ' inspectors
       If ribbonID = &quot;Microsoft.Word.Document&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Mail.Read&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Mail.Compose&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.MeetingRequest.Read&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.MeetingRequest.Send&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Appointment&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Contact&quot; Or _
           ribbonID = &quot;Microsoft.Outlook.Task&quot; Then


           Return GetResourceText(&quot;VBOutlookRibbonXml.Ribbon.xml&quot;)


       Else
           Return Nothing
       End If
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. In Ribbon.vb, implement the callback methods<b><span style="">
</span></b></p>
<h2>More Information</h2>
<p class="MsoListParagraph" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb226712.aspx">Customizing the Ribbon in Outlook 2007</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
