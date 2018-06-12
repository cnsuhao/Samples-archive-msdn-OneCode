# Windows Phone Background Agents
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone Development
## Topics
* Background Agent
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:37:09
## Description

<h1>Scheduled Task Agent (VBWP8ScheduledTaskAgent)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This code sample demonstrates how to use Scheduled Task in Windows Phone.<span style="">&nbsp;
</span>It covers three parts:</p>
<p class="MsoNormal">1.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>How to create a scheduled task.<br>
2.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>How to catch the various errors thrown by scheduled task.<br>
3.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>How to set the process safe by class Mutex.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Prerequisite: <b style="">Visual Studio 2012</b> with <b style="">
Windows Phone SDK 8.0</b>.</p>
<p class="MsoNormal">You can download Visual Studio 2012 from here:<br>
<a href="http://www.microsoft.com/visualstudio/eng/downloads">http://www.microsoft.com/visualstudio/eng/downloads</a><br>
You can download Windows Phone SDK 8.0 from here:<br>
<a href="https://dev.windowsphone.com/en-us/downloadsdk">https://dev.windowsphone.com/en-us/downloadsdk</a><br>
You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open &quot;VBWP8ScheduledTaskAgent&quot;in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91677/1/image.png" alt="" width="280" height="193" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the button to open or turn off the task.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press the back button and wait for the background task show:<br>
<span style=""><img src="/site/view/file/91678/1/image.png" alt="" width="294" height="204" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new &quot;Windows Phone Scheduled Task Agent&quot; project in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">OnInvoke</b> method resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub OnInvoke(Task As ScheduledTask)
 
&nbsp;&nbsp;&nbsp;&nbsp;If Task.Name = &quot;PeriodicTaskDemo&quot; Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim toast As New ShellToast()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim mutex As New System.Threading.Mutex(True, &quot;ScheduledAgentData&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mutex.WaitOne()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Title = setting(&quot;ScheduledAgentData&quot;).ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mutex.ReleaseMutex()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Content = &quot;Task Running&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Show()
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; ScheduledActionService.LaunchForTest(Task.Name, TimeSpan.FromSeconds(3))
&nbsp;&nbsp;&nbsp; NotifyComplete()
 
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub OnInvoke(Task As ScheduledTask)
 
&nbsp;&nbsp;&nbsp;&nbsp;If Task.Name = &quot;PeriodicTaskDemo&quot; Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim toast As New ShellToast()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim mutex As New System.Threading.Mutex(True, &quot;ScheduledAgentData&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mutex.WaitOne()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Title = setting(&quot;ScheduledAgentData&quot;).ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mutex.ReleaseMutex()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Content = &quot;Task Running&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; toast.Show()
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; ScheduledActionService.LaunchForTest(Task.Name, TimeSpan.FromSeconds(3))
&nbsp;&nbsp;&nbsp; NotifyComplete()
 
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style="">ScheduledActionService</b> provides the
<b style="">LaunchForTest</b> method.<span style="">&nbsp; </span>Use this method during application development to test your background agent implementation. Background agents are launched by the operating system according to the type of agent and the current state
 of the system. This scheduling logic is described in Background Agents Overview for Windows Phone. You can use this method to launch an agent more frequently from your foreground application or from the agent itself in order to test the agent execution. This
 method should only be used during development. You should remove calls to this method from your production application.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add two buttons to open and turn off the task , the Grid named &quot;<b style="">LayoutRoot</b>&quot; in the
<b style="">MainPage.xaml</b> file will resemble the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;StackPanel Orientation=&quot;Vertical&quot; x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Open Task&quot; Height=&quot;72&quot; Name=&quot;StartTask&quot; Width=&quot;200&quot; Click=&quot;StartPeriodicTask_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Turn Off Task&quot; Height=&quot;72&quot; Name=&quot;StopTask&quot; Width=&quot;200&quot; Click=&quot;StopPeriodicTask_Click&quot;/&gt;
&lt;/StackPanel&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;StackPanel Orientation=&quot;Vertical&quot; x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Open Task&quot; Height=&quot;72&quot; Name=&quot;StartTask&quot; Width=&quot;200&quot; Click=&quot;StartPeriodicTask_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Turn Off Task&quot; Height=&quot;72&quot; Name=&quot;StopTask&quot; Width=&quot;200&quot; Click=&quot;StopPeriodicTask_Click&quot;/&gt;
&lt;/StackPanel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open <b style="">MainPage.xaml.vb</b> file, add the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub StartPeriodicTask()
&nbsp;&nbsp;&nbsp; Dim periodicTask As New PeriodicTask(&quot;PeriodicTaskDemo&quot;)
&nbsp;&nbsp;&nbsp; periodicTask.Description = &quot;Are presenting a periodic task&quot;
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.Add(periodicTask)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.LaunchForTest(&quot;PeriodicTaskDemo&quot;, TimeSpan.FromSeconds(3))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Open the background agent success&quot;)
&nbsp;&nbsp;&nbsp; Catch exception As InvalidOperationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;exists already&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Since then the background agent success is already running&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;BNS Error: The action is disabled&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Background processes for this application has been prohibited&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;BNS Error: The maximum number of ScheduledActions of this type have already been added.&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;You open the daemon has exceeded the hardware limitations&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 
&nbsp;&nbsp;&nbsp;&nbsp;Catch generatedExceptionName As SchedulerServiceException
&nbsp;&nbsp;&nbsp; End Try
End Sub
Private Sub StopPeriodicTask()
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.Remove(&quot;PeriodicTaskDemo&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Turn off the background agent successfully&quot;)
&nbsp;&nbsp;&nbsp; Catch exception As InvalidOperationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;doesn't exist&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Since then the background agent success is not running&quot;)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If
 
&nbsp;&nbsp;&nbsp;&nbsp;Catch generatedExceptionName As SchedulerServiceException
&nbsp;&nbsp;&nbsp; End Try
End Sub
Private Sub StartPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp; StartPeriodicTask()
&nbsp;&nbsp;&nbsp; SetData()
End Sub
Private Sub StopPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp; StopPeriodicTask()
End Sub
Public Sub SetData()
&nbsp;&nbsp;&nbsp; Dim mutex As New System.Threading.Mutex(False, &quot;ScheduledAgentData&quot;)
&nbsp;&nbsp;&nbsp; mutex.WaitOne()
&nbsp;&nbsp;&nbsp; Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
&nbsp;&nbsp;&nbsp; If Not setting.Contains(&quot;ScheduledAgentData&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; setting.Add(&quot;ScheduledAgentData&quot;, &quot;Foreground data&quot;)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; mutex.ReleaseMutex()
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub StartPeriodicTask()
&nbsp;&nbsp;&nbsp; Dim periodicTask As New PeriodicTask(&quot;PeriodicTaskDemo&quot;)
&nbsp;&nbsp;&nbsp; periodicTask.Description = &quot;Are presenting a periodic task&quot;
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.Add(periodicTask)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.LaunchForTest(&quot;PeriodicTaskDemo&quot;, TimeSpan.FromSeconds(3))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Open the background agent success&quot;)
&nbsp;&nbsp;&nbsp; Catch exception As InvalidOperationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;exists already&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Since then the background agent success is already running&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;BNS Error: The action is disabled&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Background processes for this application has been prohibited&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;BNS Error: The maximum number of ScheduledActions of this type have already been added.&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;You open the daemon has exceeded the hardware limitations&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 
&nbsp;&nbsp;&nbsp;&nbsp;Catch generatedExceptionName As SchedulerServiceException
&nbsp;&nbsp;&nbsp; End Try
End Sub
Private Sub StopPeriodicTask()
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScheduledActionService.Remove(&quot;PeriodicTaskDemo&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Turn off the background agent successfully&quot;)
&nbsp;&nbsp;&nbsp; Catch exception As InvalidOperationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If exception.Message.Contains(&quot;doesn't exist&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(&quot;Since then the background agent success is not running&quot;)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If
 
&nbsp;&nbsp;&nbsp;&nbsp;Catch generatedExceptionName As SchedulerServiceException
&nbsp;&nbsp;&nbsp; End Try
End Sub
Private Sub StartPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp; StartPeriodicTask()
&nbsp;&nbsp;&nbsp; SetData()
End Sub
Private Sub StopPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp; StopPeriodicTask()
End Sub
Public Sub SetData()
&nbsp;&nbsp;&nbsp; Dim mutex As New System.Threading.Mutex(False, &quot;ScheduledAgentData&quot;)
&nbsp;&nbsp;&nbsp; mutex.WaitOne()
&nbsp;&nbsp;&nbsp; Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
&nbsp;&nbsp;&nbsp; If Not setting.Contains(&quot;ScheduledAgentData&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; setting.Add(&quot;ScheduledAgentData&quot;, &quot;Foreground data&quot;)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; mutex.ReleaseMutex()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">Background Agents Overview for Windows Phone<br>
<a href="http://msdn.microsoft.com/en-us/library/hh202942%28v=VS.92%29.aspx">http://msdn.microsoft.com/en-us/library/hh202942%28v=VS.92%29.aspx</a><br>
Background Agent Best Practices for Windows Phone<br>
<a href="http://msdn.microsoft.com/en-us/library/hh202944(v=vs.92).aspx">http://msdn.microsoft.com/en-us/library/hh202944(v=vs.92).aspx</a><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
