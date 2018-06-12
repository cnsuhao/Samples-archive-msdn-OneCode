# Use  PerformanceCounter to get CPU Usage
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* WMI
* System Administration
* Windows Desktop App Development
## Topics
* CPU
* PerformanceCounter
## IsPublished
* True
## ModifiedDate
* 2013-07-22 03:15:01
## Description

<h1>How to use PerformanceCounter to get the CPU Usage (<span style="font-family:新宋体">CSCpuUsage</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to use PerformanceCounter to get the CPU Usage with following features
</span></h2>
<p class="MsoNormal"></p>
<p class="MsoNormal">Prerequisite </p>
<p class="MsoNormal">Microsoft Chart Controls for Microsoft .NET Framework 3.5 </p>
<p class="MsoNormal"><a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422">http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=14422</a>
</p>
<h2>Running the Sample </h2>
<p class="MsoNormal">Step1. Open this project in Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Build the project and run CSCpuUsage.exe.</p>
<p class="MsoNormal">Step3. Check &quot;Display total CPU Usage&quot; and &quot;Display the CPU Usage of a process&quot;. Click the ComboBox and select a process (i.e. taskmgr, if Task Manager is running.) to monitor.</p>
<p class="MsoNormal">You will see 2 charts on this application that display the CPU usage history.</p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal">Step1. Design the CpuUsageMonitorBase class that supplies basic fields/events/functions/interfaces of the monitors, such as Timer, PerformanceCounter and IDisposable interface.</p>
<p class="MsoNormal">This is an abstract class, so CpuUsageMonitorBase class cannot be instantiated. When the<span style="">&nbsp;
</span>child classes are instantiated, they have to pass the categoryName, counterName and instanceName to the constructor of CpuUsageMonitorBase class to initialize the performance counter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
this.cpuPerformanceCounter =
               new PerformanceCounter(categoryName, counterName, instanceName);

</pre>
<pre id="codePreview" class="csharp">
this.cpuPerformanceCounter =
               new PerformanceCounter(categoryName, counterName, instanceName);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The timer is used to get the performance counter value every few seconds, and raise the CpuUsageValueArrayChanged event. If there is any exception while reading the performance counter value, the ErrorOccurred event will be raised.</p>
<p class="MsoNormal">Step2. Design the TotalCpuUsageMonitor class that is used to monitor the total CPU usage. It inherits the CpuUsageMonitorBase class, and defines 3 constants:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
const string categoryName = &quot;Processor&quot;;
        const string counterName = &quot;% Processor Time&quot;;
        const string instanceName = &quot;_Total&quot;;

</pre>
<pre id="codePreview" class="csharp">
const string categoryName = &quot;Processor&quot;;
        const string counterName = &quot;% Processor Time&quot;;
        const string instanceName = &quot;_Total&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">To get the total CPU usage, we can use above constants to initialize a performance counter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public TotalCpuUsageMonitor(int timerPeriod, int valueArrayCapacity)
            : base(timerPeriod, valueArrayCapacity, categoryName, counterName, instanceName)
        { }

</pre>
<pre id="codePreview" class="csharp">
public TotalCpuUsageMonitor(int timerPeriod, int valueArrayCapacity)
            : base(timerPeriod, valueArrayCapacity, categoryName, counterName, instanceName)
        { }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Design the ProcessCpuUsageMonitor class that is used to monitor the CPU usage of a specified process. It also inherits the CpuUsageMonitorBase class, and defines 2 constants:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
const string categoryName = &quot;Process&quot;;
        const string counterName = &quot;% Processor Time&quot;;

</pre>
<pre id="codePreview" class="csharp">
const string categoryName = &quot;Process&quot;;
        const string counterName = &quot;% Processor Time&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">To initialize a performance counter, we still need the instance name (a process name). So this class also supplies a method to get available processes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static PerformanceCounterCategory category;
        public static PerformanceCounterCategory Category
        {
            get
            {
                if (category == null)
                {
                    category = new PerformanceCounterCategory(categoryName);
                }
                return category;
            }
        }


        public static string[] GetAvailableProcesses()
        {          
            return Category.GetInstanceNames().OrderBy(name =&gt; name).ToArray();
        }

</pre>
<pre id="codePreview" class="csharp">
static PerformanceCounterCategory category;
        public static PerformanceCounterCategory Category
        {
            get
            {
                if (category == null)
                {
                    category = new PerformanceCounterCategory(categoryName);
                }
                return category;
            }
        }


        public static string[] GetAvailableProcesses()
        {          
            return Category.GetInstanceNames().OrderBy(name =&gt; name).ToArray();
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Design the MainForm that initializes the totalCpuUsageMonitor and processCpuUsageMonitor, registers the CpuUsageValueArrayChanged and display the CPU usage history in the charts.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
      /// Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
      /// the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
      /// &lt;/summary&gt;
      void processCpuUsageMonitor_CpuUsageValueArrayChanged(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(
              processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);
      }


      void processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender,
          CpuUsageValueArrayChangedEventArg e)
      {
          var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];
          var values = e.Values;


          // Display the process CPU usage in the chart.
          processCpuUsageSeries.Points.DataBindY(e.Values);


      }




      /// &lt;summary&gt;
      /// Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
      /// the CpuUsageValueArrayChanged event of totalCpuUsageMonitor.
      /// &lt;/summary&gt;
      void totalCpuUsageMonitor_CpuUsageValueArrayChanged(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(
              totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);
      }
      void totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          var totalCpuUsageSeries = chartTotalCpuUsage.Series[&quot;TotalCpuUsageSeries&quot;];
          var values = e.Values;


          // Display the total CPU usage in the chart.
          totalCpuUsageSeries.Points.DataBindY(e.Values);


      }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
      /// Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
      /// the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
      /// &lt;/summary&gt;
      void processCpuUsageMonitor_CpuUsageValueArrayChanged(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(
              processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);
      }


      void processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender,
          CpuUsageValueArrayChangedEventArg e)
      {
          var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];
          var values = e.Values;


          // Display the process CPU usage in the chart.
          processCpuUsageSeries.Points.DataBindY(e.Values);


      }




      /// &lt;summary&gt;
      /// Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
      /// the CpuUsageValueArrayChanged event of totalCpuUsageMonitor.
      /// &lt;/summary&gt;
      void totalCpuUsageMonitor_CpuUsageValueArrayChanged(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(
              totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);
      }
      void totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender, 
          CpuUsageValueArrayChangedEventArg e)
      {
          var totalCpuUsageSeries = chartTotalCpuUsage.Series[&quot;TotalCpuUsageSeries&quot;];
          var values = e.Values;


          // Display the total CPU usage in the chart.
          totalCpuUsageSeries.Points.DataBindY(e.Values);


      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">If there is any error while reading the performance counter value, the UI will also handle this event.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
        /// Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle
        /// the ErrorOccurred event of processCpuUsageMonitor.
        /// &lt;/summary&gt;
        void processCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)
        {
            this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(
                processCpuUsageMonitor_ErrorOccurredHandler), sender, e);
        }


        void processCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)
        {
            if (processCpuUsageMonitor != null)
            {
                processCpuUsageMonitor.Dispose();
                processCpuUsageMonitor = null;
                var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];
                processCpuUsageSeries.Points.Clear();
            }
            MessageBox.Show(e.Error.Message);
        }       


        /// &lt;summary&gt;
        /// Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle
        /// the ErrorOccurred event of totalCpuUsageMonitor.
        /// &lt;/summary&gt;
        void totalCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)
        {
            this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(
                totalCpuUsageMonitor_ErrorOccurredHandler),sender,e);
        }


        void totalCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)
        {
            if (totalCpuUsageMonitor != null)
            {
                totalCpuUsageMonitor.Dispose();
                totalCpuUsageMonitor = null;
            }
            MessageBox.Show(e.Error.Message);
        }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
        /// Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle
        /// the ErrorOccurred event of processCpuUsageMonitor.
        /// &lt;/summary&gt;
        void processCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)
        {
            this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(
                processCpuUsageMonitor_ErrorOccurredHandler), sender, e);
        }


        void processCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)
        {
            if (processCpuUsageMonitor != null)
            {
                processCpuUsageMonitor.Dispose();
                processCpuUsageMonitor = null;
                var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];
                processCpuUsageSeries.Points.Clear();
            }
            MessageBox.Show(e.Error.Message);
        }       


        /// &lt;summary&gt;
        /// Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle
        /// the ErrorOccurred event of totalCpuUsageMonitor.
        /// &lt;/summary&gt;
        void totalCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)
        {
            this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(
                totalCpuUsageMonitor_ErrorOccurredHandler),sender,e);
        }


        void totalCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)
        {
            if (totalCpuUsageMonitor != null)
            {
                totalCpuUsageMonitor.Dispose();
                totalCpuUsageMonitor = null;
            }
            MessageBox.Show(e.Error.Message);
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2><span class="SpellE"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">PerformanceCounter</span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
 Class </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx">http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx</a>
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Chart Class
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx</a>
</span></h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
