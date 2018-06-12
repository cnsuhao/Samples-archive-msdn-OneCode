# Run a process as a different user (CSRunProcessAsUser)
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
* 2011-06-19 02:46:07
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Windows APPLICATION: CSRunProcessAsUser Overview</h2>
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
Step2. Run CSRunProcessAsUser.exe.<br>
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
&nbsp; &nbsp; &nbsp; message box saying &quot;the process xxx exited&quot;.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1. The sample uses the &quot;Process.Start&quot; function to implement running programs with
<br>
&nbsp; different users. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Check the parameters.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!string.IsNullOrEmpty(tbUserName.Text) &amp;&amp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!string.IsNullOrEmpty(tbPassword.Text) &amp;&amp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!string.IsNullOrEmpty(tbCommand.Text))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SecureString password = StringToSecureString(tbPassword.Text);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Process proc = Process.Start(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbCommand.Text,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbUserName.Text,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;password,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbDomain.Text);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessStarted(proc.Id);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;proc.EnableRaisingEvents = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;proc.Exited &#43;= new EventHandler(ProcessExited);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Please fill in the user name, password and command&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Win32Exception w32e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessStartFailed(w32e.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; <br>
2. The sample uses the C&#43;&#43;/CLI library &quot;Kerr.Credentials&quot; that wraps the call of the
<br>
&nbsp; native API CredUIPromptForCredentials to gather the user credential. The <br>
&nbsp; Kerr.Credentials library provided by Kenny Kerr is downloaded from this MSDN
<br>
&nbsp; article: <a href="&lt;a target=" target="_blank">http://www.microsoft.com/indonesia/msdn/credmgmt.aspx</a>.'&gt;<a href="http://www.microsoft.com/indonesia/msdn/credmgmt.aspx" target="_blank">http://www.microsoft.com/indonesia/msdn/credmgmt.aspx</a>.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;using (Kerr.PromptForCredential dialog = new Kerr.PromptForCredential())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.Title = &quot;Please specify the user&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.DoNotPersist = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.ShowSaveCheckBox = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.TargetName = Environment.MachineName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dialog.ExpectConfirmation = true;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (DialogResult.OK == dialog.ShowDialog(this))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbPassword.Text = SecureStringToString(dialog.Password);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string[] strSplit = dialog.UserName.Split('\\');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strSplit.Length == 2)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbUserName.Text = strSplit[1];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbDomain.Text = strSplit[0];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbUserName.Text = dialog.UserName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(ex.ToString(), &quot;Error&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
3. After the new process is started, we register its Exited event so that we can be
<br>
&nbsp; notified when the process exits.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;proc.EnableRaisingEvents = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp;proc.Exited &#43;= new EventHandler(ProcessExited);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Triggered when the target process is exited.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ProcessExited(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Process proc = sender as Process;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (proc != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Process &quot; &#43; proc.Id.ToString() &#43; &quot; exited&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
</p>
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
