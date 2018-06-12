# Use Task Based programming technology in Service Bus
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-06-03 12:25:13
## Description

<p class="MsoNormal">This sample shows the new feature in Windows Azure Service Bus Client SDK 2.0.</p>
<p class="MsoNormal">The SDK APIs have improved to offer System.Threading.Tasks.Task based versions of all asynchronous APIs.</p>
<p class="MsoNormal">This means that you can write asynchronous code that mere mortals can read.</p>
<p class="MsoNormal">This sample requires WindowsAuzre.ServiceBus API. Right-click on the project node or References node and select 'Manage NuGet Packages&hellip;' Make sure that you have selected Include Prerelease (the default is Stable only). Then search
 for service bus. Select Windows Azure Service Bus and click on Install.</p>
<p class="MsoNormal"><span><img src="/site/view/file/83222/1/image.png" alt="" width="576" height="384" align="middle">
</span></p>
<p class="MsoNormal"><span lang="EN">From the Package Manager Console, you can install the package by typing in:
</span></p>
<p class="MsoNormal"><span lang="EN">Install-Package -Id WindowsAzure.ServiceBus &ndash;IncludePrerelease
</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Before the running, you need to change the Microsoft.ServiceBus.ConnectingString in your APP.Config.</p>
<p class="MsoNormal">Get the Access Key from you Azure portal-&gt; Service bus tab-&gt;&lt;Your service bus namespace name&gt;-&gt;Access Key.</p>
<p class="MsoNormal"><span><img src="/site/view/file/83223/1/image.png" alt="" width="500" height="433" align="middle">
</span></p>
<p class="MsoNormal">This Microsoft.ServiceBus.ConnectingString is something like:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;add key=&quot;Microsoft.ServiceBus.ConnectionString&quot; value=&quot;Endpoint=sb://&lt; YOUR NAME SPACE&gt;.servicebus.windows.net/;SharedSecretIssuer=&lt;DEFAULT ISSUER&gt;;SharedSecretValue=DEFAULT KEY&quot; /&gt;

</pre>
<pre id="codePreview" class="xml">&lt;add key=&quot;Microsoft.ServiceBus.ConnectionString&quot; value=&quot;Endpoint=sb://&lt; YOUR NAME SPACE&gt;.servicebus.windows.net/;SharedSecretIssuer=&lt;DEFAULT ISSUER&gt;;SharedSecretValue=DEFAULT KEY&quot; /&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">You can copy the Connection String's value and paste into this appsetting's value.</p>
<p class="MsoNormal">Step 1: Create a new WPF project named CSAzureTaskBasedServiceBus.</p>
<p class="MsoNormal">Step 2: In MainWIndows.xaml, add several controls to the main page.</p>
<p class="MsoNormal"><span><img src="/site/view/file/83224/1/image.png" alt="" width="577" height="422" align="middle">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;CSAuzreTaskBasedServiceBus.MainWindow&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Title=&quot;Task Based Service Bus sample&quot; Width=&quot;1094&quot; Height=&quot;800&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid Margin=&quot;0,0,0,0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ListBox Height=&quot;330&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0,225,70,0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=&quot;lstQueues&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;254&quot; Grid.Column=&quot;1&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Send Message&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;170,192,0,0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=&quot;btnSendMessage&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;95&quot; Click=&quot;btnSendMessage_Click&quot;&nbsp; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox HorizontalAlignment=&quot;Left&quot; Name=&quot;cbxChooseSendMessageQueue&quot; Margin=&quot;28,151,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot; Height=&quot;22&quot; SelectedIndex=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Send Message&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;28,94,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;86&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Service Bus Queues&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;98,10,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;113&quot; Grid.Column=&quot;1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Choose Queue&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;28,115,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;88&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox x:Name=&quot;txtSendMessage&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;23&quot; Margin=&quot;28,192,0,0&quot; TextWrapping=&quot;Wrap&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Queue list&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;38,189,0,0&quot; VerticalAlignment=&quot;Top&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Create Queue&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;38,115,0,0&quot; VerticalAlignment=&quot;Top&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox&nbsp; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;23&quot; Margin=&quot;38,151,0,0&quot; TextWrapping=&quot;Wrap&quot; Name=&quot;txtCreateQueue&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Name=&quot;btnCreateNewQueue&quot; Content=&quot;Create&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;188,151,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; Click=&quot;btnCreateNewQueue_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox Name=&quot;cbxChooseRetrieveMessageQueue&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;21,149,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot; SelectedIndex=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Name=&quot;btnRetrieveMessage&quot;&nbsp; Content=&quot;Retrieve&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;166,149,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; Height=&quot;22&quot; Click=&quot;btnRetrieveMessage_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox x:Name=&quot;txtDetails&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;330&quot; Margin=&quot;21,225,0,0&quot; TextWrapping=&quot;Wrap&quot;&nbsp; VerticalAlignment=&quot;Top&quot; Width=&quot;316&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Choose Queue&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,115,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;88&quot; Grid.Column=&quot;2&quot;/&gt;




&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&lt;/Window&gt;

</pre>
<pre id="codePreview" class="xaml">&lt;Window x:Class=&quot;CSAuzreTaskBasedServiceBus.MainWindow&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Title=&quot;Task Based Service Bus sample&quot; Width=&quot;1094&quot; Height=&quot;800&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid Margin=&quot;0,0,0,0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;350*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ListBox Height=&quot;330&quot; HorizontalAlignment=&quot;Right&quot; Margin=&quot;0,225,70,0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=&quot;lstQueues&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;254&quot; Grid.Column=&quot;1&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Content=&quot;Send Message&quot; Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;170,192,0,0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=&quot;btnSendMessage&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;95&quot; Click=&quot;btnSendMessage_Click&quot;&nbsp; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox HorizontalAlignment=&quot;Left&quot; Name=&quot;cbxChooseSendMessageQueue&quot; Margin=&quot;28,151,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot; Height=&quot;22&quot; SelectedIndex=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Send Message&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;28,94,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;86&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Service Bus Queues&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;98,10,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;113&quot; Grid.Column=&quot;1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Choose Queue&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;28,115,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;88&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox x:Name=&quot;txtSendMessage&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;23&quot; Margin=&quot;28,192,0,0&quot; TextWrapping=&quot;Wrap&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Queue list&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;38,189,0,0&quot; VerticalAlignment=&quot;Top&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Create Queue&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;38,115,0,0&quot; VerticalAlignment=&quot;Top&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox&nbsp; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;23&quot; Margin=&quot;38,151,0,0&quot; TextWrapping=&quot;Wrap&quot; Name=&quot;txtCreateQueue&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Name=&quot;btnCreateNewQueue&quot; Content=&quot;Create&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;188,151,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; Click=&quot;btnCreateNewQueue_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox Name=&quot;cbxChooseRetrieveMessageQueue&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;21,149,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot; SelectedIndex=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Name=&quot;btnRetrieveMessage&quot;&nbsp; Content=&quot;Retrieve&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;166,149,0,0&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;75&quot; Height=&quot;22&quot; Click=&quot;btnRetrieveMessage_Click&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox x:Name=&quot;txtDetails&quot; Grid.Column=&quot;2&quot; HorizontalAlignment=&quot;Left&quot; Height=&quot;330&quot; Margin=&quot;21,225,0,0&quot; TextWrapping=&quot;Wrap&quot;&nbsp; VerticalAlignment=&quot;Top&quot; Width=&quot;316&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Label Content=&quot;Choose Queue&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,115,0,0&quot; VerticalAlignment=&quot;Top&quot; Height=&quot;26&quot; Width=&quot;88&quot; Grid.Column=&quot;2&quot;/&gt;




&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&lt;/Window&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 3: Create an Async method to get data from Service Bus, and initialize controls asynchronously.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public async void initializeControls()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseRetrieveMessageQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NamespaceManager manager=NamespaceManager.Create();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List&lt;string&gt; queueNameList = new List&lt;string&gt;();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var Queues=await manager.GetQueuesAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lstQueues.Items.Clear();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (var queue in Queues)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; queueNameList.Add(queue.Path);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lstQueues.Items.Add(string.Format(&quot;{0}\t\t\tlength={1}&quot;,queue.Path,queue.MessageCount));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.ItemsSource = queueNameList;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxChooseRetrieveMessageQueue.ItemsSource = queueNameList;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxChooseRetrieveMessageQueue.IsEnabled = true;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">public async void initializeControls()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseRetrieveMessageQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NamespaceManager manager=NamespaceManager.Create();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List&lt;string&gt; queueNameList = new List&lt;string&gt;();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var Queues=await manager.GetQueuesAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lstQueues.Items.Clear();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (var queue in Queues)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; queueNameList.Add(queue.Path);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lstQueues.Items.Add(string.Format(&quot;{0}\t\t\tlength={1}&quot;,queue.Path,queue.MessageCount));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.ItemsSource = queueNameList;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxChooseRetrieveMessageQueue.ItemsSource = queueNameList;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cbxChooseSendMessageQueue.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxChooseRetrieveMessageQueue.IsEnabled = true;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step 4: Create button click event for each buttons, and make them asynchronously.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private async void btnCreateNewQueue_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCreateNewQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NamespaceManager manager = NamespaceManager.Create();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (txtCreateQueue.Text != &quot;&quot; &amp;&amp; (!await (manager.QueueExistsAsync(txtCreateQueue.Text))))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await manager.CreateQueueAsync(txtCreateQueue.Text);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCreateNewQueue.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtCreateQueue.Text = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">private async void btnCreateNewQueue_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCreateNewQueue.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NamespaceManager manager = NamespaceManager.Create();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (txtCreateQueue.Text != &quot;&quot; &amp;&amp; (!await (manager.QueueExistsAsync(txtCreateQueue.Text))))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await manager.CreateQueueAsync(txtCreateQueue.Text);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCreateNewQueue.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtCreateQueue.Text = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

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
<pre class="hidden">private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnSendMessage.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;QueueClient client = QueueClient.Create(cbxChooseSendMessageQueue.SelectedValue.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (txtSendMessage.Text!=null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await client.SendAsync(new BrokeredMessage(txtSendMessage.Text));


&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnSendMessage.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnSendMessage.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;QueueClient client = QueueClient.Create(cbxChooseSendMessageQueue.SelectedValue.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (txtSendMessage.Text!=null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await client.SendAsync(new BrokeredMessage(txtSendMessage.Text));


&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnSendMessage.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private async void btnRetrieveMessage_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnRetrieveMessage.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QueueClient client = QueueClient.Create(cbxChooseRetrieveMessageQueue.SelectedValue.ToString(),ReceiveMode.ReceiveAndDelete);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BrokeredMessage receivedMessage = await client.ReceiveAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (receivedMessage!=null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtDetails.Text=string.Format(&quot;Message Content:\n{0}\n\n&quot;,receivedMessage.GetBody&lt;string&gt;());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtDetails.Text &#43;=(&quot;BrokeredMessage Properties\n&quot;&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;Size\t{0}\n&quot;,receivedMessage.Size)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;MessageId\t{0}\n&quot;,receivedMessage.MessageId)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;TimeToLive\t{0}\n&quot;,receivedMessage.TimeToLive)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;EnqueuedTimeUtc\t{0}\n&quot;,receivedMessage.EnqueuedTimeUtc)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;ExpiresAtUtc\t{0}\n&quot;,receivedMessage.ExpiresAtUtc));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnRetrieveMessage.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">private async void btnRetrieveMessage_Click(object sender, RoutedEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnRetrieveMessage.IsEnabled = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QueueClient client = QueueClient.Create(cbxChooseRetrieveMessageQueue.SelectedValue.ToString(),ReceiveMode.ReceiveAndDelete);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BrokeredMessage receivedMessage = await client.ReceiveAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (receivedMessage!=null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtDetails.Text=string.Format(&quot;Message Content:\n{0}\n\n&quot;,receivedMessage.GetBody&lt;string&gt;());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtDetails.Text &#43;=(&quot;BrokeredMessage Properties\n&quot;&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;Size\t{0}\n&quot;,receivedMessage.Size)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;MessageId\t{0}\n&quot;,receivedMessage.MessageId)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;TimeToLive\t{0}\n&quot;,receivedMessage.TimeToLive)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;EnqueuedTimeUtc\t{0}\n&quot;,receivedMessage.EnqueuedTimeUtc)&#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string.Format(&quot;ExpiresAtUtc\t{0}\n&quot;,receivedMessage.ExpiresAtUtc));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnRetrieveMessage.IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step 5: Add initializeControls method to your MainWindow().</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainWindow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</pre>
<pre id="codePreview" class="csharp">public MainWindow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; initializeControls();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><a href="http://blogs.msdn.com/b/windowsazure/archive/2013/04/11/task-based-apis-for-service-bus.aspx">http://blogs.msdn.com/b/windowsazure/archive/2013/04/11/task-based-apis-for-service-bus.aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
