# Custom date label in ASP.NET Calendar (VBASPNETDisplayAddtionalTextInCalendar)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Calendar
* Control
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:39:01
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>VBASPNETDisplayAddtionalTextInCalendar Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to display additional text in a calendar control.<br>
As we know, people may want to add different customize text when date of <br>
Calendar has been selected. Here we give an easy way to set Calendar's specified<br>
text, background color, border properties and make Calendar looks better.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETDisplayAddtionalTextInCalendar.sln.<br>
<br>
Step 2: Expand the VBASPNETDisplayAddtionalTextInCalendar web application and press
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You can find a Calendar control on the Default.aspx page. Please Click<br>
&nbsp; &nbsp; &nbsp; &nbsp;to select one of dates.<br>
<br>
Step 4: You will see &quot;your text&quot; in the bottom of every selected date.<br>
<br>
Step 5: Validation finished.</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETDisplayAddtionalTextInCalendar&quot;.<br>
<br>
Step 2. Add one web form in the root directory, name it as &quot;Default.aspx&quot;.<br>
<br>
Step 3. Add a Calendar control and a button on default page, The calendar control<br>
&nbsp; &nbsp; &nbsp; &nbsp;display the selected dates and additional text, The Button is use to output<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;all selected dates.<br>
<br>
Step 4. Define a list of DateTime instances for storing selected dates.<br>
&nbsp; &nbsp; &nbsp; &nbsp;The List&lt;DateTime&gt; variable store in ViewState.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;' Define a list of DateTime to store selected date.<br>
&nbsp; &nbsp;Dim SelectDates As New List(Of DateTime)()<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' The selected dates is stored in ViewState.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Property GetDateTimeList() As List(Of DateTime)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If ViewState(&quot;SelectDate&quot;) Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim selectdates As New List(Of DateTime)()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectdates.Add(DateTime.MaxValue)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState(&quot;SelectDate&quot;) = selectdates<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return DirectCast(ViewState(&quot;SelectDate&quot;), List(Of DateTime))<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As List(Of DateTime))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState(&quot;SelectDate&quot;) = value<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
Step 5 &nbsp;Add Calendar SelectionChanged, PreRender, DayRender event to add<br>
&nbsp; &nbsp; &nbsp; &nbsp;date time in selected date list or remove date from it.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Calendar SelectionChanged event, add new date in SelectedDate and
<br>
&nbsp; &nbsp;''' remove the same date.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Protected Sub myCalendar_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim dateSeletion As DateTime = myCalendar.SelectedDate<br>
&nbsp; &nbsp; &nbsp; &nbsp;If SelectDates.Contains(dateSeletion) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SelectDates.Remove(dateSeletion)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SelectDates.Add(dateSeletion)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Clear selected dates.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Protected Sub myCalendar_PreRender(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;myCalendar.SelectedDates.Clear()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Add your customize text in Calendar control.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Protected Sub myCalendar_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;For Each time As DateTime In SelectDates<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;myCalendar.SelectedDates.Add(time)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If e.Day.[Date] = time Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.BorderWidth = 1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.BackColor = Color.SlateBlue<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.Controls.Add(New LiteralControl(&quot;&lt;br /&gt;your text&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
<br>
Step 6. Add button's click event, the button will display the selected dates<br>
&nbsp; &nbsp; &nbsp; &nbsp;on default page, actually we may store them in database or xml files.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Here we only output them. <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' render selected dates.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Protected Sub btnCheck_Click(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;For Each [date] As DateTime In SelectDates<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If [date] &lt;&gt; DateTime.MaxValue Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write([date].ToShortDateString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;&lt;br /&gt;&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Build the application and you can debug it.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Calendar Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar(VS.80).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar(VS.80).aspx</a><br>
<br>
MSDN: Calendar.SelectionChanged Event<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar.selectionchanged.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar.selectionchanged.aspx</a><br>
<br>
MSDN: Control.PreRender Event<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.prerender.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.web.ui.control.prerender.aspx</a><br>
<br>
MSDN: Calendar.DayRender Event<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar.dayrender.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar.dayrender.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
