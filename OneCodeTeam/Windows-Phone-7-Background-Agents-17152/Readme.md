# Windows Phone 7 Background Agents (CSWP7ScheduledTaskAgent)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone 7
* Windows Phone 7.5
## Topics
* Background Agent
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:50:02
## Description

<h1>Windows Phone 7 Scheduled Task Agent (CSWP7ScheduledTaskAgent)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This code sample demonstrates how to use Scheduled Task in Windows Phone 7.
<span>&nbsp;</span>It covers three parts:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to create a scheduled task.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to catch the various errors thrown by scheduled task.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to set the process safe by class Mutex.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">This sample should be opened with Windows phone Emulator, please download the latest version of
<a href="http://www.microsoft.com/download/en/details.aspx?id=27570">Windows Phone SDK 7.1</a>.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the CSWP7ScheduledTaskAgent.sln file with Visual Studio.</p>
<p class="MsoNormal">2. Press Ctrl&#43;F5 to run the sample.<span>&nbsp; </span>You will find a Windows phone 7 Application on the page:</p>
<p class="MsoNormal"><span><img src="/site/view/file/59439/1/image.png" alt="" width="339" height="508" align="middle">
</span></p>
<p class="MsoNormal">3. Click the button to open or turn off the task.</p>
<p class="MsoNormal">4. Press the back button and wait for the background task show:</p>
<p class="MsoNormal"><span><img src="/site/view/file/59440/1/image.png" alt="" width="93" height="85" align="middle">
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/59441/1/image.png" alt="" width="317" height="182" align="middle">
</span></p>
<p class="MsoNormal">&nbsp;</p>
<h2>Using the Code</h2>
<p class="MsoNormal"><strong>1. </strong>Create a Windows Phone Scheduled Task Agent project:</p>
<p class="MsoNormal"><span><img src="/site/view/file/59442/1/image.png" alt="" width="665" height="263" align="middle">
</span></p>
<p class="MsoNormal"><strong>2. </strong>Add the code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected override void OnInvoke(ScheduledTask task)
{
    //TODO: Add code to perform your task in background
    if (task.Name == &quot;PeriodicTaskDemo&quot;)
    {   
        ShellToast toast = new ShellToast();
        Mutex mutex = new Mutex(true, &quot;ScheduledAgentData&quot;);
        mutex.WaitOne();
        IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
        toast.Title = setting[&quot;ScheduledAgentData&quot;].ToString();
        mutex.ReleaseMutex();
        toast.Content = &quot;Task Running&quot;;
        toast.Show();
    }
    ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(3));
    NotifyComplete();
}

</pre>
<pre id="codePreview" class="csharp">protected override void OnInvoke(ScheduledTask task)
{
    //TODO: Add code to perform your task in background
    if (task.Name == &quot;PeriodicTaskDemo&quot;)
    {   
        ShellToast toast = new ShellToast();
        Mutex mutex = new Mutex(true, &quot;ScheduledAgentData&quot;);
        mutex.WaitOne();
        IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
        toast.Title = setting[&quot;ScheduledAgentData&quot;].ToString();
        mutex.ReleaseMutex();
        toast.Content = &quot;Task Running&quot;;
        toast.Show();
    }
    ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(3));
    NotifyComplete();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">ScheduledActionService provides the <a href="http://msdn.microsoft.com/en-us/library/microsoft.phone.scheduler.scheduledactionservice.launchfortest(v=vs.92).aspx">
LaunchForTest</a> method. <span>&nbsp;</span>Use this method during application development to test your background agent implementation. Background agents are launched by the operating system according to the type of agent and the current state of the system.
 This scheduling logic is described in Background Agents Overview for Windows Phone. You can use this method to launch an agent more frequently from your foreground application or from the agent itself in order to test the agent execution. This method should
 only be used during development. You should remove calls to this method from your production application.</p>
<p class="MsoNormal"><strong>3. </strong>Add the two button to open and turn off the task:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;StackPanel Orientation=&quot;Vertical&quot; x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
    &lt;Button Content=&quot;Open Task&quot; Height=&quot;72&quot; Name=&quot;StartTask&quot; Width=&quot;200&quot; Click=&quot;StartPeriodicTask_Click&quot;/&gt;
    &lt;Button Content=&quot;Turn Off Task&quot; Height=&quot;72&quot; Name=&quot;StopTask&quot; Width=&quot;200&quot; Click=&quot;StopPeriodicTask_Click&quot;/&gt;
&lt;/StackPanel&gt;

</pre>
<pre id="codePreview" class="xaml">&lt;StackPanel Orientation=&quot;Vertical&quot; x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
    &lt;Button Content=&quot;Open Task&quot; Height=&quot;72&quot; Name=&quot;StartTask&quot; Width=&quot;200&quot; Click=&quot;StartPeriodicTask_Click&quot;/&gt;
    &lt;Button Content=&quot;Turn Off Task&quot; Height=&quot;72&quot; Name=&quot;StopTask&quot; Width=&quot;200&quot; Click=&quot;StopPeriodicTask_Click&quot;/&gt;
&lt;/StackPanel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void StartPeriodicTask()
{
    PeriodicTask periodicTask = new PeriodicTask(&quot;PeriodicTaskDemo&quot;);
    periodicTask.Description = &quot;Are presenting a periodic task&quot;;
    try
    {
        ScheduledActionService.Add(periodicTask);
        ScheduledActionService.LaunchForTest(&quot;PeriodicTaskDemo&quot;, TimeSpan.FromSeconds(3));
        MessageBox.Show(&quot;Open the background agent success&quot;);
    }
    catch (InvalidOperationException exception)
    {
        if (exception.Message.Contains(&quot;exists already&quot;))
        {
            MessageBox.Show(&quot;Since then the background agent success is already running&quot;);
        }
        if (exception.Message.Contains(&quot;BNS Error: The action is disabled&quot;))
        {
            MessageBox.Show(&quot;Background processes for this application has been prohibited&quot;);
        }
        if (exception.Message.Contains(&quot;BNS Error: The maximum number of ScheduledActions of this type have already been added.&quot;))
        {
            MessageBox.Show(&quot;You open the daemon has exceeded the hardware limitations&quot;);
        }
    }
    catch (SchedulerServiceException)
    {
 
    }
}
private void StopPeriodicTask()
{
    try
    {
        ScheduledActionService.Remove(&quot;PeriodicTaskDemo&quot;);
        MessageBox.Show(&quot;Turn off the background agent successfully&quot;);
    }
    catch (InvalidOperationException exception)
    {
        if (exception.Message.Contains(&quot;doesn't exist&quot;))
        {
            MessageBox.Show(&quot;Since then the background agent success is not running&quot;);
        }
    }
    catch (SchedulerServiceException)
    {
         
    } 
}
private void StartPeriodicTask_Click(object sender, RoutedEventArgs e)
{
    StartPeriodicTask();
    SetData();
}
private void StopPeriodicTask_Click(object sender, RoutedEventArgs e)
{
    StopPeriodicTask();
}
public void SetData()
{
    Mutex mutex = new Mutex(false, &quot;ScheduledAgentData&quot;);
    mutex.WaitOne();
    IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
    if(!setting.Contains(&quot;ScheduledAgentData&quot;))
        setting.Add(&quot;ScheduledAgentData&quot;, &quot;Foreground data&quot;);
    mutex.ReleaseMutex();
}

</pre>
<pre id="codePreview" class="csharp">private void StartPeriodicTask()
{
    PeriodicTask periodicTask = new PeriodicTask(&quot;PeriodicTaskDemo&quot;);
    periodicTask.Description = &quot;Are presenting a periodic task&quot;;
    try
    {
        ScheduledActionService.Add(periodicTask);
        ScheduledActionService.LaunchForTest(&quot;PeriodicTaskDemo&quot;, TimeSpan.FromSeconds(3));
        MessageBox.Show(&quot;Open the background agent success&quot;);
    }
    catch (InvalidOperationException exception)
    {
        if (exception.Message.Contains(&quot;exists already&quot;))
        {
            MessageBox.Show(&quot;Since then the background agent success is already running&quot;);
        }
        if (exception.Message.Contains(&quot;BNS Error: The action is disabled&quot;))
        {
            MessageBox.Show(&quot;Background processes for this application has been prohibited&quot;);
        }
        if (exception.Message.Contains(&quot;BNS Error: The maximum number of ScheduledActions of this type have already been added.&quot;))
        {
            MessageBox.Show(&quot;You open the daemon has exceeded the hardware limitations&quot;);
        }
    }
    catch (SchedulerServiceException)
    {
 
    }
}
private void StopPeriodicTask()
{
    try
    {
        ScheduledActionService.Remove(&quot;PeriodicTaskDemo&quot;);
        MessageBox.Show(&quot;Turn off the background agent successfully&quot;);
    }
    catch (InvalidOperationException exception)
    {
        if (exception.Message.Contains(&quot;doesn't exist&quot;))
        {
            MessageBox.Show(&quot;Since then the background agent success is not running&quot;);
        }
    }
    catch (SchedulerServiceException)
    {
         
    } 
}
private void StartPeriodicTask_Click(object sender, RoutedEventArgs e)
{
    StartPeriodicTask();
    SetData();
}
private void StopPeriodicTask_Click(object sender, RoutedEventArgs e)
{
    StopPeriodicTask();
}
public void SetData()
{
    Mutex mutex = new Mutex(false, &quot;ScheduledAgentData&quot;);
    mutex.WaitOne();
    IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
    if(!setting.Contains(&quot;ScheduledAgentData&quot;))
        setting.Add(&quot;ScheduledAgentData&quot;, &quot;Foreground data&quot;);
    mutex.ReleaseMutex();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/hh202942%28v=VS.92%29.aspx">Background Agents Overview for Windows Phone</a>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/hh202944(v=vs.92).aspx">Background Agent Best Practices for Windows Phone</a>
</span></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
