# Custom date label in ASP.NET Calendar (CSASPNETDisplayAddtionalTextInCalendar)
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
* 2011-08-08 07:38:32
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CSASPNETDisplayAddtionalTextInCalendar Overview</h2>
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
Step 1: Open the CSASPNETDisplayAddtionalTextInCalendar.sln.<br>
<br>
Step 2: Expand the CSASPNETDisplayAddtionalTextInCalendar web application and press
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
Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETDisplayAddtionalTextInCalendar&quot;.<br>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Define a list of DateTime to store selected date.<br>
&nbsp; &nbsp; &nbsp; &nbsp;List&lt;DateTime&gt; SelectDates = new List&lt;DateTime&gt;();<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// The selected dates is stored in ViewState.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;DateTime&gt; GetDateTimeList<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ViewState[&quot;SelectDate&quot;] == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;List&lt;DateTime&gt; selectdates = new List&lt;DateTime&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectdates.Add(DateTime.MaxValue);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState[&quot;SelectDate&quot;] = selectdates;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return (List&lt;DateTime&gt;)ViewState[&quot;SelectDate&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState[&quot;SelectDate&quot;] = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
Step 5 &nbsp;Add Calendar SelectionChanged, PreRender, DayRender event to add<br>
&nbsp; &nbsp; &nbsp; &nbsp;date time in selected date list or remove date from it.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Calendar SelectionChanged event, add new date in SelectedDate and
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// remove the same date.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void myCalendar_SelectionChanged(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DateTime dateSeletion = myCalendar.SelectedDate;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (SelectDates.Contains(dateSeletion))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SelectDates.Remove(dateSeletion);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SelectDates.Add(dateSeletion);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Clear selected dates.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void myCalendar_PreRender(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;myCalendar.SelectedDates.Clear();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Add your customize text in Calendar control.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void myCalendar_DayRender(object sender, DayRenderEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (DateTime time in SelectDates)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;myCalendar.SelectedDates.Add(time);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.Day.Date == time)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.BorderWidth = 1;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.BackColor = Color.SlateBlue;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Cell.Controls.Add(new LiteralControl(&quot;&lt;br /&gt;your text&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
<br>
Step 6. Add button's click event, the button will display the selected dates<br>
&nbsp; &nbsp; &nbsp; &nbsp;on default page, actually we may store them in database or xml files.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Here we only output them. <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// render selected dates.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void btnCheck_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (DateTime date in SelectDates)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (date != DateTime.MaxValue)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(date.ToShortDateString());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;&lt;br /&gt;&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
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
