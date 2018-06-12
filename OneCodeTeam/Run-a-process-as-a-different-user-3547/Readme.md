# Run a process as a different user (VBRunProcessAsUser)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* Runas
* Credential
## IsPublished
* True
## ModifiedDate
* 2011-06-19 02:40:20
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Windows APPLICATION: VBRunProcessAsUser Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates how to run a process as a different user. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build this project in Visual Studio 2010. <br>
<br>
Step2. Run VBRunProcessAsUser.exe.<br>
<br>
Step3. Fill out the User Name, Domain (if it is an Active Directory user account), and
<br>
&nbsp; &nbsp; &nbsp; Password textboxes for the user that you want to run as. &nbsp;Alternatively, you can
<br>
&nbsp; &nbsp; &nbsp; click the &quot;...&quot; button next to the User Name textbox. It will prompt a standard
<br>
&nbsp; &nbsp; &nbsp; user credential collection dialog. &nbsp;You can fill out the user name and password
<br>
&nbsp; &nbsp; &nbsp; in it too.<br>
&nbsp; &nbsp; &nbsp; <br>
Step4. Click the &quot;Command...&quot; button and select the program that you want to run as the
<br>
&nbsp; &nbsp; &nbsp; specified user in Step 3.<br>
<br>
Step5. Click the &quot;Run Command&quot; button to run the program as the specified user. &nbsp;When
<br>
&nbsp; &nbsp; &nbsp; the process is started successfully, you will see a message box saying &quot;the
<br>
&nbsp; &nbsp; &nbsp; process xxx started&quot;. &nbsp;You can verify that the process is run as the specified
<br>
&nbsp; &nbsp; &nbsp; user in Task Manager. &nbsp;When you exit the new process, you will see another
<br>
&nbsp; &nbsp; &nbsp; message box saying &quot;the process xxx exited&quot;.</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. The sample uses the &quot;Process.Start&quot; function to implement running programs with
<br>
&nbsp; different users. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If (Not String.IsNullOrEmpty(tbUserName.Text)) AndAlso _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(Not String.IsNullOrEmpty(tbPassword.Text)) AndAlso _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(Not String.IsNullOrEmpty(tbCommand.Text)) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim password As SecureString = StringToSecureString(Me.tbPassword.Text.ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim proc As Process = Process.Start(tbCommand.Text.ToString(), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbUserName.Text.ToString(), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;password, _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbDomain.Text.ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessStarted(proc.Id)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;proc.EnableRaisingEvents = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler proc.Exited, AddressOf ProcessExited<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Please fill in the user name, password and command&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch w32e As System.ComponentModel.Win32Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessStartFailed(w32e.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; <br>
2. The sample uses the C&#43;&#43;/CLI library &quot;Kerr.Credentials&quot; that wraps the call of the
<br>
&nbsp; native API CredUIPromptForCredentials to gather the user credential. The <br>
&nbsp; Kerr.Credentials library provided by Kenny Kerr is downloaded from this MSDN
<br>
&nbsp; article: <a href="&lt;a target=" target="_blank">http://www.microsoft.com/indonesia/msdn/credmgmt.aspx</a>.'&gt;<a href="http://www.microsoft.com/indonesia/msdn/credmgmt.aspx" target="_blank">http://www.microsoft.com/indonesia/msdn/credmgmt.aspx</a>.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using dialog As New Kerr.PromptForCredential()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.Title = &quot;Please Specify the user&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.DoNotPersist = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.ShowSaveCheckBox = False<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.TargetName = Environment.MachineName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.ExpectConfirmation = True<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If DialogResult.OK = dialog.ShowDialog(Me) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbPassword.Text = SecureStringToString(dialog.Password)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strSplit() As String = dialog.UserName.Split(&quot;\&quot;c)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If (strSplit.Length = 2) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.tbUserName.Text = strSplit(1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.tbDomain.Text = strSplit(0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.tbUserName.Text = dialog.UserName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(ex.ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
<br>
3. After the new process is started, we register its Exited event so that we can be
<br>
&nbsp; notified when the process exits.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;proc.EnableRaisingEvents = True<br>
&nbsp; &nbsp; &nbsp; &nbsp;AddHandler proc.Exited, AddressOf ProcessExited<br>
<br>
&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Triggered when the target process is exited.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub ProcessExited(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim proc As Process = TryCast(sender, Process)<br>
&nbsp; &nbsp; &nbsp; &nbsp;If proc IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Process &quot; &amp; proc.Id.ToString() &amp; &quot; exited&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Process.Start<br>
<a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.process.start.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.diagnostics.process.start.aspx</a><br>
<br>
Credential Management with the .NET Framework 2.0<br>
<a href="http://www.microsoft.com/indonesia/msdn/credmgmt.aspx" target="_blank">http://www.microsoft.com/indonesia/msdn/credmgmt.aspx</a><br>
<br>
</p>
<p style="font-family:Courier New">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
