# WPF multithreading demo (CSWPFThreading)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* threading
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:52:04
## Description

<h1><span style="">WPF multithreading demo (CSWPFThreading) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
The CSWPFThreading sample project illustrates two WPF threading models. The first one divides a long-running process into many snippets of workitems. Then the dispather of WPF will pick up the workitems one by one from the queue by their priority. The background
 workitem does not affect the UI operation, so it just looks like the background workitem is processed by another thread. But actually, all of them are executed in the same thread. This trick is very useful if you want single threaded GUI application, and also
 want to keep the GUI responsive when doing expensive operations in<span style="">��
</span>the UI thread. <br>
The second model is similar to the traditional WinForm threading model. The background work item is executed in another thread and it calls the Dispatcher. BeginInvoke method to update the UI.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54162/1/image.png" alt="" width="460" height="261" align="middle">
<img src="/site/view/file/54163/1/image.png" alt="" width="462" height="262" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"></p>
<p class="MsoNormal"><b style="">Long-Running Calculation in UI Thread (Tab1): </b>
</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When the start button is firstly clicked, the continueCalculating is false, so the codes call Dispatcher. BeginInvoke to execute a first workitem for the CheckNextNumber.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In the CheckNextNumber function, it judge if the current number is a prime number. If yes, it updates the UI directly. If not, it calls BeginInvoke to execute the CheckNextNumber again for the next odd number.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public void CheckNextNumber()
{
��� // Reset flag.
��� fNotAPrime = false;


��� for (long i = 3; i &lt;= Math.Sqrt(num); i&#43;&#43;)
��� {
������� if (num % i == 0)
������� {
����������� // Set not-a-prime flag to true.
����������� fNotAPrime = true;
����������� break;
������� }
��� }


��� // If a prime number.
��� if (!fNotAPrime)
��� {
������� tbPrime.Text = num.ToString();
��� }


��� num &#43;= 2;
��� if (continueCalculating)
��� {
������� btnPrimeNumber.Dispatcher.BeginInvoke(
����������� System.Windows.Threading.DispatcherPriority.SystemIdle,
����������� new NextPrimeDelegate(this.CheckNextNumber));
��� }
}

</pre>
<pre id="codePreview" class="csharp">
public void CheckNextNumber()
{
��� // Reset flag.
��� fNotAPrime = false;


��� for (long i = 3; i &lt;= Math.Sqrt(num); i&#43;&#43;)
��� {
������� if (num % i == 0)
������� {
����������� // Set not-a-prime flag to true.
����������� fNotAPrime = true;
����������� break;
������� }
��� }


��� // If a prime number.
��� if (!fNotAPrime)
��� {
������� tbPrime.Text = num.ToString();
��� }


��� num &#43;= 2;
��� if (continueCalculating)
��� {
������� btnPrimeNumber.Dispatcher.BeginInvoke(
����������� System.Windows.Threading.DispatcherPriority.SystemIdle,
����������� new NextPrimeDelegate(this.CheckNextNumber));
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In the CheckNextNumber function, because the first parameter passed into BeginInvoke is DispatcherPriority.SystemIdle, all of the CheckNextNumber workitem will not break the UI operation.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When the calculation goes on, we can draw in the UI's InkCanvas, this proves that the UI thread is not affected by the &quot;background&quot; long calculation.
</span></p>
<p class="MsoNormal" style=""><b style=""><span style="">Blocked Operation in Worker Thread (Tab2)
</span></b></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When the Retrieve Data from Server button is clicked, the click handle retrieveData function is called.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnRetrieveData_Click(object sender, RoutedEventArgs e)
{
��� this.btnRetrieveData.IsEnabled = false;
��� this.btnRetrieveData.Content = &quot;Contacting Server&quot;;


��� NoArgDelegate fetcher = new NoArgDelegate(
������� this.RetrieveDataFromServer);
��� fetcher.BeginInvoke(null, null);
}

</pre>
<pre id="codePreview" class="csharp">
private void btnRetrieveData_Click(object sender, RoutedEventArgs e)
{
��� this.btnRetrieveData.IsEnabled = false;
��� this.btnRetrieveData.Content = &quot;Contacting Server&quot;;


��� NoArgDelegate fetcher = new NoArgDelegate(
������� this.RetrieveDataFromServer);
��� fetcher.BeginInvoke(null, null);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Then our codes use delegate.BeginInvoke to start a thread from the thread pool. This thread is used to perform the long operation of retrieving data.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Retrieve data in a worker thread.
/// &lt;/summary&gt;
private void RetrieveDataFromServer()
{
��� // Simulate the delay from network access.
��� Thread.Sleep(5000);


��� // Generate random data to be displayed.
��� Random rand = new Random();
��� Int32[] data = {
���������������������� rand.Next(1000), rand.Next(1000), 
�����������������������rand.Next(1000), rand.Next(1000) 
�������������������};


��� // Schedule the update function in the UI thread.
��� this.Dispatcher.BeginInvoke(
������� System.Windows.Threading.DispatcherPriority.Normal,
������� new OneArgDelegate(UpdateUserInterface),
������� data);
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Retrieve data in a worker thread.
/// &lt;/summary&gt;
private void RetrieveDataFromServer()
{
��� // Simulate the delay from network access.
��� Thread.Sleep(5000);


��� // Generate random data to be displayed.
��� Random rand = new Random();
��� Int32[] data = {
���������������������� rand.Next(1000), rand.Next(1000), 
�����������������������rand.Next(1000), rand.Next(1000) 
�������������������};


��� // Schedule the update function in the UI thread.
��� this.Dispatcher.BeginInvoke(
������� System.Windows.Threading.DispatcherPriority.Normal,
������� new OneArgDelegate(UpdateUserInterface),
������� data);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">We use Thread.Sleep(5000) to simulate a 5 seconds delay here.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">The codes generate 4 random numbers as data and update them to the UI by calling the Dispatcher.BeginInvoke().
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Since the retrieving operation is executed in another thread, we can draw in the InkCanvas normally.
</span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx">WPF Threading Model</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
