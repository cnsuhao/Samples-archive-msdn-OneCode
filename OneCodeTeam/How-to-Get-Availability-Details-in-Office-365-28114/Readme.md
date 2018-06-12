# How to Get Availability Details in Office 365
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* availability details
## IsPublished
* True
## ModifiedDate
* 2014-04-10 02:12:46
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Get Availability Details in Office 365</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">Currently, Outlook Web App (OWA) allows you to check the availability by using Schedule Assistant. But you may want to have a list of events to track the availability of meeting rooms. In this application,
 we will demonstrate how to </span></span><span style="font-size:13pt"><span style="font-size:11pt">get
</span><span style="font-size:11pt">availability details in Office 365.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">1. You need input the email addresses and the duration
</span></span><span style="font-size:13pt"><span style="font-size:11pt">from which</span><span style="font-size:11pt"> you want to get the availability details.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">2. The application will check the addresses and the date.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. At last the application will show the result of the availability details.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, </span><span style="font-size:11pt">use your account to connect the Exchange Online.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112607/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then you can input the identities and the duration
</span><span style="font-size:11pt">f</span><span style="font-size:11pt">or which</span><span style="font-size:11pt">
</span><span style="font-size:11pt">you want to get the availability details.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112608/1/image.png" alt="" width="575" height="71" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">At last, the results of availability will be
</span><span>shown</span><span style="font-size:11pt"> as follows</span><a name="_GoBack"></a><span style="font-size:11pt">:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112609/1/image.png" alt="" width="575" height="119" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Get the identities</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">String[] identities = inputInfo.Split(',');
List&lt;String&gt; emailAddresses = new List&lt;String&gt;();
foreach (String identity in identities)
{
    NameResolutionCollection nameResolutions =
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
    if (nameResolutions.Count != 1)
    {
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
    }
    else
    {
        String emailAddress = nameResolutions[0].Mailbox.Address;
        emailAddresses.Add(emailAddress);
    }
}
if (emailAddresses.Count &gt; 0)
{
    GetAvailabilityDetails(service, startDate, endDate, emailAddresses.ToArray());
}
</pre>
<pre class="hidden">Dim identities() As String = inputInfo.Split(&quot;,&quot;c)
 Dim emailAddresses As New List(Of String)()
 For Each identity As String In identities
     Dim nameResolutions As NameResolutionCollection =
         service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
     If nameResolutions.Count &lt;&gt; 1 Then
         Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity)
     Else
         Dim emailAddress As String = nameResolutions(0).Mailbox.Address
         emailAddresses.Add(emailAddress)
     End If
 Next identity
 If emailAddresses.Count &gt; 0 Then
     GetAvailabilityDetails(service, startDate, endDate, emailAddresses.ToArray())
 End If
</pre>
<pre id="codePreview" class="csharp">String[] identities = inputInfo.Split(',');
List&lt;String&gt; emailAddresses = new List&lt;String&gt;();
foreach (String identity in identities)
{
    NameResolutionCollection nameResolutions =
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
    if (nameResolutions.Count != 1)
    {
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
    }
    else
    {
        String emailAddress = nameResolutions[0].Mailbox.Address;
        emailAddresses.Add(emailAddress);
    }
}
if (emailAddresses.Count &gt; 0)
{
    GetAvailabilityDetails(service, startDate, endDate, emailAddresses.ToArray());
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Set the duration and the attendees</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// If the date is invaild, we will set today as the start date.
DateTime startMeetingDate;
startMeetingDate=
    DateTime.TryParse(startDate, out startMeetingDate)?startMeetingDate:DateTime.Now;
// If the date is invaild, we will set two days after the start date as the end date.
DateTime endMeetingDate;
endMeetingDate = 
    DateTime.TryParse(endDate, out endMeetingDate)&amp;&amp;endMeetingDate&gt;=startMeetingDate ? 
    endMeetingDate : startMeetingDate.AddDays(2);
List&lt;AttendeeInfo&gt; attendees = new List&lt;AttendeeInfo&gt;();
foreach (String emailAddress in emailAddresses)
{
    AttendeeInfo attendee = new AttendeeInfo(emailAddress);
    attendees.Add(attendee);
}
TimeWindow timeWindow = new TimeWindow(startMeetingDate,endMeetingDate);
AvailabilityOptions availabilityOptions = new AvailabilityOptions();
availabilityOptions.MeetingDuration = 60;
</pre>
<pre class="hidden">' If the date is invaild, we will set today as the start date.
Dim startMeetingDate As Date
startMeetingDate = If(Date.TryParse(startDate, startMeetingDate), startMeetingDate, Date.Now)
' If the date is invaild, we will set two days after the start date as the end date.
Dim endMeetingDate As Date
endMeetingDate = If(Date.TryParse(endDate, endMeetingDate) AndAlso
                    endMeetingDate &gt;= startMeetingDate, endMeetingDate,
                    startMeetingDate.AddDays(2))
Dim attendees As New List(Of AttendeeInfo)()
For Each emailAddress As String In emailAddresses
    Dim attendee As New AttendeeInfo(emailAddress)
    attendees.Add(attendee)
Next emailAddress
Dim timeWindow As New TimeWindow(startMeetingDate, endMeetingDate)
Dim availabilityOptions As New AvailabilityOptions()
availabilityOptions.MeetingDuration = 60
</pre>
<pre id="codePreview" class="csharp">// If the date is invaild, we will set today as the start date.
DateTime startMeetingDate;
startMeetingDate=
    DateTime.TryParse(startDate, out startMeetingDate)?startMeetingDate:DateTime.Now;
// If the date is invaild, we will set two days after the start date as the end date.
DateTime endMeetingDate;
endMeetingDate = 
    DateTime.TryParse(endDate, out endMeetingDate)&amp;&amp;endMeetingDate&gt;=startMeetingDate ? 
    endMeetingDate : startMeetingDate.AddDays(2);
List&lt;AttendeeInfo&gt; attendees = new List&lt;AttendeeInfo&gt;();
foreach (String emailAddress in emailAddresses)
{
    AttendeeInfo attendee = new AttendeeInfo(emailAddress);
    attendees.Add(attendee);
}
TimeWindow timeWindow = new TimeWindow(startMeetingDate,endMeetingDate);
AvailabilityOptions availabilityOptions = new AvailabilityOptions();
availabilityOptions.MeetingDuration = 60;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Get the availability results and display them</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">GetUserAvailabilityResults userAvailabilityResults = service.GetUserAvailability(attendees, 
    timeWindow, AvailabilityData.FreeBusyAndSuggestions, availabilityOptions);
Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;, &quot;FreeBusyStatus&quot;, 
    &quot;StartTime&quot;, &quot;EndTime&quot;, &quot;Subject&quot;, &quot;Location&quot;, &quot;IsMeeting&quot;);
foreach (AttendeeAvailability userAvailabilityResult in 
    userAvailabilityResults.AttendeesAvailability)
{
    if (userAvailabilityResult.ErrorCode.CompareTo(ServiceError.NoError) == 0)
    {
        foreach (CalendarEvent calendarEvent in userAvailabilityResult.CalendarEvents)
        {
            Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;, 
                calendarEvent.FreeBusyStatus, 
                calendarEvent.StartTime.ToShortDateString() &#43; &quot; &quot; &#43; 
                calendarEvent.StartTime.ToShortTimeString(), 
                calendarEvent.EndTime.ToShortTimeString(), 
                calendarEvent.Details.Subject, 
                calendarEvent.Details.Location, 
                calendarEvent.Details.IsMeeting);
        }
    }
}
</pre>
<pre class="hidden">Dim userAvailabilityResults As GetUserAvailabilityResults =
    service.GetUserAvailability(attendees, timeWindow,
                                AvailabilityData.FreeBusyAndSuggestions, availabilityOptions)
Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;,
                &quot;FreeBusyStatus&quot;, &quot;StartTime&quot;, &quot;EndTime&quot;, &quot;Subject&quot;, &quot;Location&quot;, &quot;IsMeeting&quot;)
For Each userAvailabilityResult As AttendeeAvailability In
    userAvailabilityResults.AttendeesAvailability
    If userAvailabilityResult.ErrorCode.CompareTo(ServiceError.NoError) = 0 Then
        For Each calendarEvent As CalendarEvent In userAvailabilityResult.CalendarEvents
            Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;,
                              calendarEvent.FreeBusyStatus,
                              calendarEvent.StartTime.ToShortDateString() &amp; &quot; &quot; &amp;
                              calendarEvent.StartTime.ToShortTimeString(),
                              calendarEvent.EndTime.ToShortTimeString(),
                              calendarEvent.Details.Subject,
                              calendarEvent.Details.Location,
                              calendarEvent.Details.IsMeeting)
        Next calendarEvent
    End If
Next userAvailabilityResult
</pre>
<pre id="codePreview" class="csharp">GetUserAvailabilityResults userAvailabilityResults = service.GetUserAvailability(attendees, 
    timeWindow, AvailabilityData.FreeBusyAndSuggestions, availabilityOptions);
Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;, &quot;FreeBusyStatus&quot;, 
    &quot;StartTime&quot;, &quot;EndTime&quot;, &quot;Subject&quot;, &quot;Location&quot;, &quot;IsMeeting&quot;);
foreach (AttendeeAvailability userAvailabilityResult in 
    userAvailabilityResults.AttendeesAvailability)
{
    if (userAvailabilityResult.ErrorCode.CompareTo(ServiceError.NoError) == 0)
    {
        foreach (CalendarEvent calendarEvent in userAvailabilityResult.CalendarEvents)
        {
            Console.WriteLine(&quot;{0,-15}{1,-21}{2,-11}{3,-14}{4,-10}{5,-9}&quot;, 
                calendarEvent.FreeBusyStatus, 
                calendarEvent.StartTime.ToShortDateString() &#43; &quot; &quot; &#43; 
                calendarEvent.StartTime.ToShortTimeString(), 
                calendarEvent.EndTime.ToShortTimeString(), 
                calendarEvent.Details.Subject, 
                calendarEvent.Details.Location, 
                calendarEvent.Details.IsMeeting);
        }
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">EWS Managed API 2.0</span></a></span><span style="font-size:13pt"><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><a href="http://msdn.microsoft.com/en-us/library/hh532567%28v=exchg.80%29.aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">Getting user free/busy information by using the
 EWS Managed API</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
