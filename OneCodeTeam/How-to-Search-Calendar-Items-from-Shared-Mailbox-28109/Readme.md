# How to Search Calendar Items from Shared Mailbox in Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Search
* O365
* shared mailbox
## IsPublished
* True
## ModifiedDate
* 2014-04-10 01:53:35
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Search for Calendar Items
</span><span style="font-weight:bold; font-size:14pt">in</span><span style="font-weight:bold; font-size:14pt"> a Shared Mailbox in Office 365 Exchange Online</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Currently, Outlook Web App doesn't allow you to search for calendar items in a shared mailbox. But some of you require this feature for some reasons. In this sample, we will demonstrate how to search
</span><span style="font-size:11pt">for </span><span style="font-size:11pt">calendar items
</span><span style="font-size:11pt">in</span><span style="font-size:11pt"> </span>
<span style="font-size:11pt">a </span><span style="font-size:11pt">shared mailbox:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">1. Get the shared mailbox that users input</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">2. Get the search filter, such as the start date, end date, subject.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">3. Set the
</span><span style="font-size:12pt">ImpersonatedUserId</span><span style="font-size:12pt"> property if the login account has the impersonation permission.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">4. Search
</span><span style="font-size:12pt">for </span><span style="font-size:12pt">the items in the shared mailbox.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112566/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If you want to search </span>
<span style="font-size:11pt">a</span><span style="font-size:11pt"> shared mailbox, you should have impersonation permission.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, you should input the shared mailbox which you want to search.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112567/1/image.png" alt="" width="574" height="30" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then you can define th</span><span style="font-size:11pt">e duration you want to search for</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112568/1/image.png" alt="" width="575" height="45" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">At last, you can define the subject you want to search</span><span style="font-size:11pt"> for</span><span style="font-size:11pt">, or you can just press Enter to get all the items.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112569/1/image.png" alt="" width="575" height="31" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The r</span><span style="font-size:11pt">esult will
</span><span style="font-size:11pt">be shown </span><span style="font-size:11pt">as follo</span><span style="font-size:11pt">ws</span><span style="font-size:11pt">:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112570/1/image.png" alt="" width="575" height="93" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we have impersonation permission, we can
</span><span style="font-size:11pt">search</span><span style="font-size:11pt"> for</span><span style="font-size:11pt"> items in
</span><span style="font-size:11pt">a </span><span style="font-size:11pt">shared mailbox</span><span style="font-size:11pt"> by set</span><span style="font-size:11pt">ting</span><span style="font-size:11pt"> ImpersonatedUserId property.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
// If the shared mailbox identity is valid, we will set it as the ImpersonatedUserId.
NameResolutionCollection nameResolutions =
    service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, false);
if (nameResolutions.Count != 1)
{
    Console.WriteLine(&quot;{0} is invalid Shared Mailbox identity.&quot;, identity);
    Console.WriteLine();
}
else
{
    String emailAddress = nameResolutions[0].Mailbox.Address;
    Console.WriteLine();
    Console.WriteLine(&quot;Please input the start date(15 days before today is the defined date.):&quot;);
    String startDate = Console.ReadLine();
    Console.WriteLine(&quot;Please input the end dateI(30 days after start date is the defined date.):&quot;);
    String endDate = Console.ReadLine();
    Console.WriteLine(&quot;Please input the subject that you want to search(Press Enter directly to get all the itmes):&quot;);
    String searchSubject = Console.ReadLine();
    Console.WriteLine();
    service.ImpersonatedUserId =
        new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
    GetSharedMailboxCalendarItems(service, emailAddress, searchSubject, 
        startDate, endDate);
}
</pre>
<pre class="hidden">
' If the shared mailbox identity is valid, we will set it as the ImpersonatedUserId.
Dim nameResolutions As NameResolutionCollection =
    service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, False)
If nameResolutions.Count &lt;&gt; 1 Then
    Console.WriteLine(&quot;{0} is invalid Shared Mailbox identity.&quot;, identity)
    Console.WriteLine()
Else
    Dim emailAddress As String = nameResolutions(0).Mailbox.Address
    Console.WriteLine()
    Console.WriteLine(&quot;Please input the start date(15 days before today is the defined date.):&quot;)
    Dim startDate As String = Console.ReadLine()
    Console.WriteLine(&quot;Please input the end dateI(30 days after start date is the defined date.):&quot;)
    Dim endDate As String = Console.ReadLine()
    Console.WriteLine(&quot;Please input the subject that you want to search(Press Enter directly to get all the itmes):&quot;)
    Dim searchSubject As String = Console.ReadLine()
    Console.WriteLine()
    service.ImpersonatedUserId =
        New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
    GetSharedMailboxCalendarItems(service, emailAddress, searchSubject,
                                  startDate, endDate)
</pre>
<pre id="codePreview" class="csharp">
// If the shared mailbox identity is valid, we will set it as the ImpersonatedUserId.
NameResolutionCollection nameResolutions =
    service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, false);
if (nameResolutions.Count != 1)
{
    Console.WriteLine(&quot;{0} is invalid Shared Mailbox identity.&quot;, identity);
    Console.WriteLine();
}
else
{
    String emailAddress = nameResolutions[0].Mailbox.Address;
    Console.WriteLine();
    Console.WriteLine(&quot;Please input the start date(15 days before today is the defined date.):&quot;);
    String startDate = Console.ReadLine();
    Console.WriteLine(&quot;Please input the end dateI(30 days after start date is the defined date.):&quot;);
    String endDate = Console.ReadLine();
    Console.WriteLine(&quot;Please input the subject that you want to search(Press Enter directly to get all the itmes):&quot;);
    String searchSubject = Console.ReadLine();
    Console.WriteLine();
    service.ImpersonatedUserId =
        new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
    GetSharedMailboxCalendarItems(service, emailAddress, searchSubject, 
        startDate, endDate);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We search </span><span style="font-size:11pt">for
</span><a name="_GoBack"></a><span style="font-size:11pt">items in the specified shared mailbox.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
static void GetSharedMailboxCalendarItems(ExchangeService service, String emailAddress, 
    String searchSubject, String startDate, String endDate)
{
    // If the date is invaild, we will set 15 days before today as the start date.
    DateTime startSearchDate;
    startSearchDate =
        DateTime.TryParse(startDate, out startSearchDate) ? startSearchDate : DateTime.Now.AddDays(-15);
    // If the date is invaild, we will set 30 days after the start date as the end date.
    DateTime endSearchDate;
    endSearchDate =
        DateTime.TryParse(endDate, out endSearchDate) && endSearchDate &gt;= startSearchDate ?
        endSearchDate : startSearchDate.AddDays(30);
    FolderId folderId = new FolderId(WellKnownFolderName.Calendar);
    SearchFilter.SearchFilterCollection searchFilterCollection = 
        new SearchFilter.SearchFilterCollection();
    searchFilterCollection.LogicalOperator = LogicalOperator.And;
    // If you want search the specified subject, you can define the filter; or you will get all
    // the items that contain the Subject schema.
    if (String.IsNullOrWhiteSpace(searchSubject))
    {
        SearchFilter searchFilter = new SearchFilter.Exists(AppointmentSchema.Subject);
        searchFilterCollection.Add(searchFilter);
    }
    else
    {
        SearchFilter searchFilter = 
            new SearchFilter.ContainsSubstring(AppointmentSchema.Subject, searchSubject);
        searchFilterCollection.Add(searchFilter);
    }
    SearchFilter startDateFilter = 
        new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.DateTimeCreated, startSearchDate);
    SearchFilter endDateFilter = 
        new SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.DateTimeCreated, endSearchDate);
    searchFilterCollection.Add(startDateFilter);
    searchFilterCollection.Add(endDateFilter);
    ItemView itemView = new ItemView(100);
    itemView.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
    FindItemsResults&lt;Item&gt; findItems=null;
    Console.WriteLine(&quot;{0,-20}{1,-25}{2,-25}{3,-10}&quot;,&quot;Subject&quot;,&quot;Start&quot;,&quot;End&quot;,&quot;Duration&quot;);
    do
    {
        findItems=service.FindItems(folderId,searchFilterCollection,itemView);
        foreach (Item item in findItems)
        {
            Console.Write(
                &quot;{0,-20}&quot;,item.Subject.Length&gt;18?item.Subject.Substring(0,15)&#43;&quot;...&quot;:item.Subject);
            
            if (item is Appointment)
            {
                Appointment appointment = item as Appointment;
                Console.Write(&quot;{0,-25}&quot;, appointment.Start);
                Console.Write(&quot;{0,-25}&quot;, appointment.End);
                Console.Write(&quot;{0,-10}&quot;, appointment.Duration);
            }
            Console.WriteLine();
        }
    }while(findItems.MoreAvailable);
    Console.WriteLine();
}
</pre>
<pre class="hidden">
Private Shared Sub GetSharedMailboxCalendarItems(ByVal service As ExchangeService,
                                                 ByVal emailAddress As String,
                                                 ByVal searchSubject As String,
                                                 ByVal startDate As String,
                                                 ByVal endDate As String)
    ' If the date is invaild, we will set 15 days before today as the start date.
    Dim startSearchDate As Date
    startSearchDate = If(Date.TryParse(startDate, startSearchDate), startSearchDate,
                         Date.Now.AddDays(-15))
    ' If the date is invaild, we will set 30 days after the start date as the end date.
    Dim endSearchDate As Date
    endSearchDate = If(Date.TryParse(endDate, endSearchDate) AndAlso
                       endSearchDate &gt;= startSearchDate, endSearchDate,
                       startSearchDate.AddDays(30))
    Dim folderId As New FolderId(WellKnownFolderName.Calendar)
    Dim searchFilterCollection As New SearchFilter.SearchFilterCollection()
    searchFilterCollection.LogicalOperator = LogicalOperator.And
    ' If you want search the specified subject, you can define the filter; or you will get all
    ' the items that contain the Subject schema.
    If String.IsNullOrWhiteSpace(searchSubject) Then
        Dim searchFilter As SearchFilter = New SearchFilter.Exists(AppointmentSchema.Subject)
        searchFilterCollection.Add(searchFilter)
    Else
        Dim searchFilter As SearchFilter =
            New SearchFilter.ContainsSubstring(AppointmentSchema.Subject, searchSubject)
        searchFilterCollection.Add(searchFilter)
    End If
    Dim startDateFilter As SearchFilter =
        New SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.DateTimeCreated, startSearchDate)
    Dim endDateFilter As SearchFilter =
        New SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.DateTimeCreated, endSearchDate)
    searchFilterCollection.Add(startDateFilter)
    searchFilterCollection.Add(endDateFilter)
    Dim itemView As New ItemView(100)
    itemView.PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)
    Dim findItems As FindItemsResults(Of Item) = Nothing
    Console.WriteLine(&quot;{0,-20}{1,-25}{2,-25}{3,-10}&quot;, &quot;Subject&quot;, &quot;Start&quot;, &quot;End&quot;, &quot;Duration&quot;)
    Do
        findItems = service.FindItems(folderId, searchFilterCollection, itemView)
        For Each item As Item In findItems
            Console.Write(&quot;{0,-20}&quot;, If(item.Subject.Length &gt; 18, item.Subject.Substring(0, 15) & &quot;...&quot;, item.Subject))
            If TypeOf item Is Appointment Then
                Dim appointment As Appointment = TryCast(item, Appointment)
                Console.Write(&quot;{0,-25}&quot;, appointment.Start)
                Console.Write(&quot;{0,-25}&quot;, appointment.End)
                Console.Write(&quot;{0,-10}&quot;, appointment.Duration)
            End If
            Console.WriteLine()
        Next item
    Loop While findItems.MoreAvailable
    Console.WriteLine()
End Sub
</pre>
<pre id="codePreview" class="csharp">
static void GetSharedMailboxCalendarItems(ExchangeService service, String emailAddress, 
    String searchSubject, String startDate, String endDate)
{
    // If the date is invaild, we will set 15 days before today as the start date.
    DateTime startSearchDate;
    startSearchDate =
        DateTime.TryParse(startDate, out startSearchDate) ? startSearchDate : DateTime.Now.AddDays(-15);
    // If the date is invaild, we will set 30 days after the start date as the end date.
    DateTime endSearchDate;
    endSearchDate =
        DateTime.TryParse(endDate, out endSearchDate) && endSearchDate &gt;= startSearchDate ?
        endSearchDate : startSearchDate.AddDays(30);
    FolderId folderId = new FolderId(WellKnownFolderName.Calendar);
    SearchFilter.SearchFilterCollection searchFilterCollection = 
        new SearchFilter.SearchFilterCollection();
    searchFilterCollection.LogicalOperator = LogicalOperator.And;
    // If you want search the specified subject, you can define the filter; or you will get all
    // the items that contain the Subject schema.
    if (String.IsNullOrWhiteSpace(searchSubject))
    {
        SearchFilter searchFilter = new SearchFilter.Exists(AppointmentSchema.Subject);
        searchFilterCollection.Add(searchFilter);
    }
    else
    {
        SearchFilter searchFilter = 
            new SearchFilter.ContainsSubstring(AppointmentSchema.Subject, searchSubject);
        searchFilterCollection.Add(searchFilter);
    }
    SearchFilter startDateFilter = 
        new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.DateTimeCreated, startSearchDate);
    SearchFilter endDateFilter = 
        new SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.DateTimeCreated, endSearchDate);
    searchFilterCollection.Add(startDateFilter);
    searchFilterCollection.Add(endDateFilter);
    ItemView itemView = new ItemView(100);
    itemView.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
    FindItemsResults&lt;Item&gt; findItems=null;
    Console.WriteLine(&quot;{0,-20}{1,-25}{2,-25}{3,-10}&quot;,&quot;Subject&quot;,&quot;Start&quot;,&quot;End&quot;,&quot;Duration&quot;);
    do
    {
        findItems=service.FindItems(folderId,searchFilterCollection,itemView);
        foreach (Item item in findItems)
        {
            Console.Write(
                &quot;{0,-20}&quot;,item.Subject.Length&gt;18?item.Subject.Substring(0,15)&#43;&quot;...&quot;:item.Subject);
            
            if (item is Appointment)
            {
                Appointment appointment = item as Appointment;
                Console.Write(&quot;{0,-25}&quot;, appointment.Start);
                Console.Write(&quot;{0,-25}&quot;, appointment.End);
                Console.Write(&quot;{0,-10}&quot;, appointment.Duration);
            }
            Console.WriteLine();
        }
    }while(findItems.MoreAvailable);
    Console.WriteLine();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633680(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Working with impersonation by using the EWS Managed API</span></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
