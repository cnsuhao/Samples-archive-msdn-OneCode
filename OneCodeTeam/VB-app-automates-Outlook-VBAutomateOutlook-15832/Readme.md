# VB app automates Outlook (VBAutomateOutlook)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* Outlook
* Automation
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:28:38
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">VBAutomateOutlook</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The VBAutomateOutlook example demonstrates the use of Visual Basic.NET codes to automate Microsoft Outlook to enumerate contacts, send a mail, close the Microsoft Outlook application and then clean up unmanaged COM resources.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">The following steps walk through a demonstration of the Outlook automation sample that starts a Microsoft Outlook instance, logs on with your profile, enumerates the contact items, creates and sends a new mail item, logs off and quits
 the Microsoft Outlook application cleanly.</p>
<p class="MsoNormal">Step1. After you successfully build the sample project in Visual Studio 2010, you will get the application: VBAutomateOutlook.exe.</p>
<p class="MsoNormal">Step2. Open Windows Task Manager (Ctrl&#43;Shift&#43;Esc) to confirm that no outlook.exe is running.
</p>
<p class="MsoNormal">Step3. Run the application. It should print the following content in the console window if no error is thrown.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53063/1/image.png" alt="" width="576" height="256" align="middle">
</span></p>
<p class="MsoNormal">Outlook would ask you to input your profile and password. When Outlook is ready, press ENTER in the console window of VBAutomateOutlook. The application will then enumerate your contacts and print the contacts:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53064/1/image.png" alt="" width="576" height="594" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Next, VBAutomateOutlook automates Outlook to create and display or send a new mail item.
</p>
<p class="MsoNormal">In the new mail item, the <span style="">��</span>To<span style="">��</span> line is set as codefxf@microsoft.com, which is the feedback channel of All-In-One Code Framework. The<span style=""> ��</span>Subject<span style="">��</span>
 is set to &quot;Feedback of All-In-One Code Framework&quot; and the email body shows &quot;Feedback:&quot; in bold.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53065/1/image.png" alt="" width="576" height="378" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">After you input your feedback and click the Send button, the mail item is sent and VBAutomateOutlook automates Outlook to log off the current profile and quit itself.</p>
<p class="MsoNormal">Step4. In Windows Task Manager, confirm that the outlook.exe process does not exist, i.e. the Microsoft Outlook intance was closed and cleaned up properly.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a Console application and reference the Outlook Primary Interop Assembly (PIA). To reference the Outlook PIA, right-click the project file<span style="">
</span>and click the &quot;Add Reference...&quot; button. In the Add Reference dialog, navigate to the .NET tab, find Microsoft.Office.Interop.Outlook 12.0.0.0 and click OK.</p>
<p class="MsoNormal">Step2. Import and rename the Outlook interop namepace:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Outlook = Microsoft.Office.Interop.Outlook

</pre>
<pre id="codePreview" class="vb">
Imports Outlook = Microsoft.Office.Interop.Outlook

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Initialize the current thread as STA</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;STAThread()&gt; _
Sub Main()


End Sub

</pre>
<pre id="codePreview" class="vb">
&lt;STAThread()&gt; _
Sub Main()


End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Start up an Outlook application by creating an Outlook.Application object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oOutlook = New Outlook.Application()

</pre>
<pre id="codePreview" class="vb">
oOutlook = New Outlook.Application()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In Vista with UAC enabled, if the automation client is run as administrator, the application may throw the error 0x80010001. Akash well explained the problem in the blog:</p>
<p class="MsoNormal"><a href="http://blogs.msdn.com/akashb/archive/2008/11/03/unable-to-instantiate-outlook-object-from-visual-studio-2008-on-vista-with-uac-on.aspx">http://blogs.msdn.com/akashb/archive/2008/11/03/unable-to-instantiate-outlook-object-from-visual-studio-2008-on-vista-with-uac-on.aspx</a></p>
<p class="MsoNormal">Step5. Get the namespace and the logon.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Get the namespace and the logon.
oNS = oOutlook.GetNamespace(&quot;MAPI&quot;)


' Log on by using a dialog box to choose the profile.
oNS.Logon(missing, missing, True, True)


' Alternative logon method that uses a specific profile.
' If you use this logon method, change the profile name to an 
' appropriate value. The second parameter of Logon is the password 
' (if any) associated with the profile. This parameter exists only 
' for backwards compatibility and for security reasons, and it is 
' not recommended for use.
'oNS.Logon(&quot;YourValidProfile&quot;, missing, False, True)

</pre>
<pre id="codePreview" class="vb">
' Get the namespace and the logon.
oNS = oOutlook.GetNamespace(&quot;MAPI&quot;)


' Log on by using a dialog box to choose the profile.
oNS.Logon(missing, missing, True, True)


' Alternative logon method that uses a specific profile.
' If you use this logon method, change the profile name to an 
' appropriate value. The second parameter of Logon is the password 
' (if any) associated with the profile. This parameter exists only 
' for backwards compatibility and for security reasons, and it is 
' not recommended for use.
'oNS.Logon(&quot;YourValidProfile&quot;, missing, False, True)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Enumerate the contact items.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oCtFolder = oNS.GetDefaultFolder( _
    Outlook.OlDefaultFolders.olFolderContacts)
    oCts = oCtFolder.Items


    ' Enumerate the contact items. 
    For i As Integer = 1 To oCts.Count
        Dim oItem As Object = oCts(i)


        If (TypeOf oItem Is Outlook.ContactItem) Then
            Dim oCt As Outlook.ContactItem = oItem
            Console.WriteLine(oCt.Email1Address)
            ' Do not need to Marshal.ReleaseComObject oCt because 
            ' Dim oCt As Outlook.ContactItem = oItem is a simple .NET 
            ' type casting, instead of a COM QueryInterface.
        ElseIf (TypeOf oItem Is Outlook.DistListItem) Then
            Dim oDl As Outlook.DistListItem = oItem
            Console.WriteLine(oDl.DLName)
            ' Do not need to Marshal.ReleaseComObject oDl because 
            ' Dim oDl As Outlook.DistListItem = oItem is a simple .NET 
            ' type casting, instead of a COM QueryInterface.
        End If


        ' Release the COM object of the Outlook item.
        Marshal.FinalReleaseComObject(oItem)
        oItem = Nothing
    Next

</pre>
<pre id="codePreview" class="vb">
oCtFolder = oNS.GetDefaultFolder( _
    Outlook.OlDefaultFolders.olFolderContacts)
    oCts = oCtFolder.Items


    ' Enumerate the contact items. 
    For i As Integer = 1 To oCts.Count
        Dim oItem As Object = oCts(i)


        If (TypeOf oItem Is Outlook.ContactItem) Then
            Dim oCt As Outlook.ContactItem = oItem
            Console.WriteLine(oCt.Email1Address)
            ' Do not need to Marshal.ReleaseComObject oCt because 
            ' Dim oCt As Outlook.ContactItem = oItem is a simple .NET 
            ' type casting, instead of a COM QueryInterface.
        ElseIf (TypeOf oItem Is Outlook.DistListItem) Then
            Dim oDl As Outlook.DistListItem = oItem
            Console.WriteLine(oDl.DLName)
            ' Do not need to Marshal.ReleaseComObject oDl because 
            ' Dim oDl As Outlook.DistListItem = oItem is a simple .NET 
            ' type casting, instead of a COM QueryInterface.
        End If


        ' Release the COM object of the Outlook item.
        Marshal.FinalReleaseComObject(oItem)
        oItem = Nothing
    Next

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Be careful with foreach loops. See: http://tiny.cc/uXw8S.</p>
<p class="MsoNormal">Step7. Create and send a new mail item.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oMail = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
oMail.Display(True)
' [-or-]
'oMail.Send()

</pre>
<pre id="codePreview" class="vb">
oMail = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
oMail.Display(True)
' [-or-]
'oMail.Send()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step8. User logs off and quits Outlook.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oNS.Logoff()
oOutlook.Quit()

</pre>
<pre id="codePreview" class="vb">
oNS.Logoff()
oOutlook.Quit()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step9. Clean up the unmanaged COM resources. To get Outlook terminated rightly, we need to call Marshal.FinalReleaseComObject() on each COM object we used. We can either explicitly call Marshal.FinalReleaseComObject on all accessor objects:<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    If Not oMail Is Nothing Then
        Marshal.FinalReleaseComObject(oMail)
        oMail = Nothing
    End If
    If Not oCts Is Nothing Then
        Marshal.FinalReleaseComObject(oCts)
        oCts = Nothing
    End If
    If Not oCtFolder Is Nothing Then
        Marshal.FinalReleaseComObject(oCtFolder)
        oCtFolder = Nothing
    End If
    If Not oNS Is Nothing Then
        Marshal.FinalReleaseComObject(oNS)
        oNS = Nothing
    End If
    If Not oOutlook Is Nothing Then
        Marshal.FinalReleaseComObject(oOutlook)
        oOutlook = Nothing
    End If

</pre>
<pre id="codePreview" class="vb">
    If Not oMail Is Nothing Then
        Marshal.FinalReleaseComObject(oMail)
        oMail = Nothing
    End If
    If Not oCts Is Nothing Then
        Marshal.FinalReleaseComObject(oCts)
        oCts = Nothing
    End If
    If Not oCtFolder Is Nothing Then
        Marshal.FinalReleaseComObject(oCtFolder)
        oCtFolder = Nothing
    End If
    If Not oNS Is Nothing Then
        Marshal.FinalReleaseComObject(oNS)
        oNS = Nothing
    End If
    If Not oOutlook Is Nothing Then
        Marshal.FinalReleaseComObject(oOutlook)
        oOutlook = Nothing
    End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    ' Force a garbage collection as soon as the calling function is off 
    ' the stack (at which point these objects are no longer rooted) and 
    ' then call GC.WaitForPendingFinalizers.
    GC.Collect()
    GC.WaitForPendingFinalizers()
    ' GC needs to be called twice in order to get the Finalizers called 
    ' - the first time in, it simply makes a list of what is to be 
    ' finalized, the second time in, it actually is finalizing. Only 
    ' then will the object do its automatic ReleaseComObject.
    GC.Collect()
    GC.WaitForPendingFinalizers()

</pre>
<pre id="codePreview" class="vb">
    ' Force a garbage collection as soon as the calling function is off 
    ' the stack (at which point these objects are no longer rooted) and 
    ' then call GC.WaitForPendingFinalizers.
    GC.Collect()
    GC.WaitForPendingFinalizers()
    ' GC needs to be called twice in order to get the Finalizers called 
    ' - the first time in, it simply makes a list of what is to be 
    ' finalized, the second time in, it actually is finalizing. Only 
    ' then will the object do its automatic ReleaseComObject.
    GC.Collect()
    GC.WaitForPendingFinalizers()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/bb177050.aspx">MSDN: Outlook 2007 Developer Reference</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://support.microsoft.com/kb/313787">How to use the Microsoft Outlook Object Library to create an Outlook contact in Visual Basic .NET</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://support.microsoft.com/kb/313793">How to use the Microsoft Outlook Object Library to force a Send/Receive action by using Visual Basic .NET</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://support.microsoft.com/kb/313800">Programming samples that can reference items and folders in Outlook by using Visual Basic .NET</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://www.outlookcode.com/article.aspx?ID=43">Writing .NET Code for Outlook</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
