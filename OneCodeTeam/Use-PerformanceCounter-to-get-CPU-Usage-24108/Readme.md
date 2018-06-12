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
* 2013-07-30 06:51:31
## Description

<h1>How to use PerformanceCounter to get the CPU Usage (VBCpuUsage)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to use PerformanceCounter to get the CPU Usage with following features
</span></h2>
<p class="MsoNormal"></p>
<h2>Prerequisite</h2>
<p class="MsoNormal">Microsoft Chart Controls for Microsoft .NET Framework 3.5</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422">http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=14422</a>
</p>
<h2>Running the Sample </h2>
<p class="MsoNormal">Step1. Open this project in Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Build the project and run VBCpuUsage.exe.</p>
<p class="MsoNormal">Step3. Check &quot;Display total CPU Usage&quot; and &quot;Display the CPU Usage of a process&quot;. Click the ComboBox and select a process (i.e. taskmgr, if Task Manager is running.) to monitor.</p>
<p class="MsoNormal">You will see 2 charts on this application that display the CPU usage history.</p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal">Step1. Design the CpuUsageMonitorBase class that supplies basic fields/events/functions/interfaces of the monitors, such as Timer, PerformanceCounter and IDisposable interface.</p>
<p class="MsoNormal">This is an abstract class, so CpuUsageMonitorBase class cannot be instantiated. When the<span style="">&nbsp;
</span>child classes are instantiated, they have to pass the categoryName, counterName and instanceName to the constructor of CpuUsageMonitorBase class to initialize the performance counter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Me._cpuPerformanceCounter =
            New PerformanceCounter(categoryName, counterName, instanceName)

</pre>
<pre id="codePreview" class="vb">
Me._cpuPerformanceCounter =
            New PerformanceCounter(categoryName, counterName, instanceName)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The timer is used to get the performance counter value every few seconds, and raise the CpuUsageValueArrayChanged event. If there is any exception while reading the performance counter value, the ErrorOccurred event will be raised.</p>
<p class="MsoNormal">Step2. Design the TotalCpuUsageMonitor class that is used to monitor the total CPU usage. It inherits the CpuUsageMonitorBase class, and defines 3 constants:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Const _categoryName As String = &quot;Processor&quot;
        Private Const _counterName As String = &quot;% Processor Time&quot;
        Private Const _instanceName As String = &quot;_Total&quot;

</pre>
<pre id="codePreview" class="vb">
Private Const _categoryName As String = &quot;Processor&quot;
        Private Const _counterName As String = &quot;% Processor Time&quot;
        Private Const _instanceName As String = &quot;_Total&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">To get the total CPU usage, we can use above constants to initialize a performance counter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Sub New(ByVal timerPeriod As Integer, ByVal valueArrayCapacity As Integer)
           MyBase.New(timerPeriod, valueArrayCapacity, _categoryName,
                      _counterName, _instanceName)
       End Sub

</pre>
<pre id="codePreview" class="vb">
Public Sub New(ByVal timerPeriod As Integer, ByVal valueArrayCapacity As Integer)
           MyBase.New(timerPeriod, valueArrayCapacity, _categoryName,
                      _counterName, _instanceName)
       End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Design the ProcessCpuUsageMonitor class that is used to monitor the CPU usage of a specified process. It also inherits the CpuUsageMonitorBase class, and defines 2 constants:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Const _categoryName As String = &quot;Process&quot;
        Private Const _counterName As String = &quot;% Processor Time&quot;

</pre>
<pre id="codePreview" class="vb">
Private Const _categoryName As String = &quot;Process&quot;
        Private Const _counterName As String = &quot;% Processor Time&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">To initialize a performance counter, we still need the instance name (a process name). So this class also supplies a method to get available processes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Shared _category As PerformanceCounterCategory
        Public Shared ReadOnly Property Category() As PerformanceCounterCategory
            Get
                If _category Is Nothing Then
                    _category = New PerformanceCounterCategory(_categoryName)
                End If
                Return _category
            End Get
        End Property
               
        Public Shared Function GetAvailableProcesses() As String()
            Return Category.GetInstanceNames().OrderBy(Function(name) name).ToArray()
        End Function

</pre>
<pre id="codePreview" class="vb">
Private Shared _category As PerformanceCounterCategory
        Public Shared ReadOnly Property Category() As PerformanceCounterCategory
            Get
                If _category Is Nothing Then
                    _category = New PerformanceCounterCategory(_categoryName)
                End If
                Return _category
            End Get
        End Property
               
        Public Shared Function GetAvailableProcesses() As String()
            Return Category.GetInstanceNames().OrderBy(Function(name) name).ToArray()
        End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Design the MainForm that initializes the totalCpuUsageMonitor and processCpuUsageMonitor, registers the CpuUsageValueArrayChanged and display the CPU usage history in the charts.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
        ''' Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
        ''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub processCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,
                                                                     ByVal e As CpuUsageValueArrayChangedEventArg)
            Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(
                      AddressOf processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)
        End Sub
        
        Private Sub processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,
                                                                            ByVal e As CpuUsageValueArrayChangedEventArg)
            Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)
            Dim values = e.Values
        
            ' Display the process CPU usage in the chart.
            processCpuUsageSeries.Points.DataBindY(e.Values)
        
        End Sub
             
        
        ''' &lt;summary&gt;
        ''' Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
        ''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,
                                                                   ByVal e As CpuUsageValueArrayChangedEventArg)
            Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(
                      AddressOf totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)
        End Sub
        Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,
                                                                          ByVal e As CpuUsageValueArrayChangedEventArg)
            Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)
            Dim values = e.Values
        
            ' Display the total CPU usage in the chart.
            totalCpuUsageSeries.Points.DataBindY(e.Values)
        
        End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
        ''' Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
        ''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub processCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,
                                                                     ByVal e As CpuUsageValueArrayChangedEventArg)
            Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(
                      AddressOf processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)
        End Sub
        
        Private Sub processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,
                                                                            ByVal e As CpuUsageValueArrayChangedEventArg)
            Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)
            Dim values = e.Values
        
            ' Display the process CPU usage in the chart.
            processCpuUsageSeries.Points.DataBindY(e.Values)
        
        End Sub
             
        
        ''' &lt;summary&gt;
        ''' Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle
        ''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,
                                                                   ByVal e As CpuUsageValueArrayChangedEventArg)
            Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(
                      AddressOf totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)
        End Sub
        Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,
                                                                          ByVal e As CpuUsageValueArrayChangedEventArg)
            Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)
            Dim values = e.Values
        
            ' Display the total CPU usage in the chart.
            totalCpuUsageSeries.Points.DataBindY(e.Values)
        
        End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">If there is any error while reading the performance counter value, the UI will also handle this event.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
        ''' Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle
        ''' the ErrorOccurred event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub processCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,
                                                         ByVal e As ErrorEventArgs)
            Me.Invoke(New EventHandler(Of ErrorEventArgs)(
                      AddressOf processCpuUsageMonitor_ErrorOccurredHandler), sender, e)
        End Sub
        
        Private Sub processCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,
                                                                ByVal e As ErrorEventArgs)
            If _processCpuUsageMonitor IsNot Nothing Then
                _processCpuUsageMonitor.Dispose()
                _processCpuUsageMonitor = Nothing
        
                Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)
                processCpuUsageSeries.Points.Clear()
            End If
            MessageBox.Show(e.Error.Message)
        End Sub


         ''' &lt;summary&gt;
        ''' Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle
        ''' the ErrorOccurred event of totalCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub totalCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,
                                                       ByVal e As ErrorEventArgs)
            Me.Invoke(New EventHandler(Of ErrorEventArgs)(
                      AddressOf totalCpuUsageMonitor_ErrorOccurredHandler), sender, e)
        End Sub
        
        Private Sub totalCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,
                                                              ByVal e As ErrorEventArgs)
            If _totalCpuUsageMonitor IsNot Nothing Then
                _totalCpuUsageMonitor.Dispose()
                _totalCpuUsageMonitor = Nothing
        
                Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)
                totalCpuUsageSeries.Points.Clear()
            End If
            MessageBox.Show(e.Error.Message)
        End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
        ''' Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle
        ''' the ErrorOccurred event of processCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub processCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,
                                                         ByVal e As ErrorEventArgs)
            Me.Invoke(New EventHandler(Of ErrorEventArgs)(
                      AddressOf processCpuUsageMonitor_ErrorOccurredHandler), sender, e)
        End Sub
        
        Private Sub processCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,
                                                                ByVal e As ErrorEventArgs)
            If _processCpuUsageMonitor IsNot Nothing Then
                _processCpuUsageMonitor.Dispose()
                _processCpuUsageMonitor = Nothing
        
                Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)
                processCpuUsageSeries.Points.Clear()
            End If
            MessageBox.Show(e.Error.Message)
        End Sub


         ''' &lt;summary&gt;
        ''' Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle
        ''' the ErrorOccurred event of totalCpuUsageMonitor.
        ''' &lt;/summary&gt;
        Private Sub totalCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,
                                                       ByVal e As ErrorEventArgs)
            Me.Invoke(New EventHandler(Of ErrorEventArgs)(
                      AddressOf totalCpuUsageMonitor_ErrorOccurredHandler), sender, e)
        End Sub
        
        Private Sub totalCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,
                                                              ByVal e As ErrorEventArgs)
            If _totalCpuUsageMonitor IsNot Nothing Then
                _totalCpuUsageMonitor.Dispose()
                _totalCpuUsageMonitor = Nothing
        
                Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)
                totalCpuUsageSeries.Points.Clear()
            End If
            MessageBox.Show(e.Error.Message)
        End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">PerformanceCounter Class
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx">http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx</a>
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Chart Class
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx</a>
</span></h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
