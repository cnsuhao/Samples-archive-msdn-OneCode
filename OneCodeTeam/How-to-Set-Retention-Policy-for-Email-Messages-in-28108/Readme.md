# How to Set Retention Policy for Email Messages in Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Office 365
* Retention Policy
## IsPublished
* True
## ModifiedDate
* 2014-04-10 02:30:31
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Set Retention Policy for Email Messages in Office 365 Exchange Online</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Currently, you can easily set email messages with
</span><span style="font-size:11pt">Retention P</span><span style="font-size:11pt">olicy enabled in Outlook and Outlook Web App. But you
</span><span style="font-size:11pt">will </span><span style="font-size:11pt">find</span><span style="font-size:11pt"> that</span><span style="font-size:11pt"> it</span><span style="font-size:11pt"> is not very convenient to set
</span><span style="">r</span><span style="font-size:11pt">etention </span><span style="font-size:11pt">p</span><span style="font-size:11pt">olic</span><span style="font-size:11pt">ies</span><span style="font-size:11pt"> for email messages in a specific time
 range. </span><span style="font-size:11pt">In this application, we will demonstrate how to set retention polic</span><span style="font-size:11pt">ies</span><span style="font-size:11pt"> for email messages in office 365:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="_GoBack"></a><span style="font-size:11pt">1. Select the email messages you want to set the retention policy</span><span style="font-size:11pt"> for</span><span style="font-size:11pt">;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Choose the retention policy you want to set for the email messages;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Set the retention policy for the email messages.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, you can use your account to connect
</span><span style="font-size:11pt">to </span><span style="font-size:11pt">the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112651/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then the emails</span><span style="font-size:11pt"> in recent 30 days</span><span style="font-size:11pt"> will be displayed in the screen.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112652/1/image.png" alt="" width="575" height="67" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After that, you need to choose the retention policy that you want to set.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112653/1/image.png" alt="" width="575" height="177" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can press a number to choose the policy</span><span style="font-size:11pt"> and the application will set it for the email messages</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112654/1/image.png" alt="" width="575" height="51" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">At last, you can view the result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112655/1/image.png" alt="" width="575" height="69" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Search the Email Messages</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Before setting retention policy, you need to get the email messages</span><span style="font-size:11pt"> first</span><span style="font-size:11pt">.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private static List&lt;Item&gt; SearchEmailMessages(ExchangeService service,String subject,
    DateTime startDate,DateTime endDate,String from,String displayTo,String displayCc)
{
    PropertySet itemPropertySet = 
        new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.PolicyTag);
    SearchFilter.SearchFilterCollection searchFilterCollection = 
        new SearchFilter.SearchFilterCollection(LogicalOperator.And);
    SearchFilter startDateFilter = 
        new SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate);
    SearchFilter endDateFilter = 
        new SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated,endDate);
    // Just select the email message items.
    SearchFilter itemClassFilter = 
        new SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, &quot;IPM.Note&quot;);
    searchFilterCollection.Add(startDateFilter);
    searchFilterCollection.Add(endDateFilter);
    searchFilterCollection.Add(itemClassFilter);
    if (!String.IsNullOrWhiteSpace(subject))
    {
        SearchFilter subjectFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, subject);
        searchFilterCollection.Add(subjectFilter);
    }
    if (!String.IsNullOrWhiteSpace(from))
    {
        SearchFilter fromFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.From, from);
        searchFilterCollection.Add(fromFilter);
    }
    if (!String.IsNullOrWhiteSpace(displayTo))
    {
        SearchFilter displayToFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayTo, displayTo);
        searchFilterCollection.Add(displayToFilter);
    }
    if (!String.IsNullOrWhiteSpace(displayCc))
    {
        SearchFilter displayCcFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayCc, displayCc);
        searchFilterCollection.Add(displayCcFilter);
    }
    List&lt;Item&gt; items = GetItems(service, searchFilterCollection, WellKnownFolderName.Inbox, itemPropertySet);
    Console.WriteLine(&quot;{0,-30}{1}&quot;, &quot;Subject&quot;, &quot;PolicyTag&quot;);
    foreach (Item item in items)
    {
        Console.WriteLine(&quot;{0,-30}{1}&quot;, item.Subject, item.PolicyTag);
    }
    Console.WriteLine();
    return items;
}
</pre>
<pre class="hidden">
Private Shared Function SearchEmailMessages(ByVal service As ExchangeService,
                                            ByVal subject As String, ByVal startDate As Date,
                                            ByVal endDate As Date, ByVal [from] As String,
                                            ByVal displayTo As String, ByVal displayCc As String) As List(Of Item)
    Dim itemPropertySet As New PropertySet(BasePropertySet.FirstClassProperties,
                                           EmailMessageSchema.PolicyTag)
    Dim searchFilterCollection As New SearchFilter.SearchFilterCollection(LogicalOperator.And)
    Dim startDateFilter As SearchFilter =
        New SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate)
    Dim endDateFilter As SearchFilter =
        New SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated, endDate)
    ' Just select the email message items.
    Dim itemClassFilter As SearchFilter =
        New SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, &quot;IPM.Note&quot;)
    searchFilterCollection.Add(startDateFilter)
    searchFilterCollection.Add(endDateFilter)
    searchFilterCollection.Add(itemClassFilter)
    If Not String.IsNullOrWhiteSpace(subject) Then
        Dim subjectFilter As SearchFilter =
            New SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, subject)
        searchFilterCollection.Add(subjectFilter)
    End If
    If Not String.IsNullOrWhiteSpace([from]) Then
        Dim fromFilter As SearchFilter =
            New SearchFilter.ContainsSubstring(EmailMessageSchema.From, [from])
        searchFilterCollection.Add(fromFilter)
    End If
    If Not String.IsNullOrWhiteSpace(displayTo) Then
        Dim displayToFilter As SearchFilter =
            New SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayTo, displayTo)
        searchFilterCollection.Add(displayToFilter)
    End If
    If Not String.IsNullOrWhiteSpace(displayCc) Then
        Dim displayCcFilter As SearchFilter =
            New SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayCc, displayCc)
        searchFilterCollection.Add(displayCcFilter)
    End If
    Dim items As List(Of Item) =
        GetItems(service, searchFilterCollection, WellKnownFolderName.Inbox, itemPropertySet)
    Console.WriteLine(&quot;{0,-30}{1}&quot;, &quot;Subject&quot;, &quot;PolicyTag&quot;)
    For Each item As Item In items
        Console.WriteLine(&quot;{0,-30}{1}&quot;, item.Subject, item.PolicyTag)
    Next item
    Console.WriteLine()
    Return items
End Function
</pre>
<pre id="codePreview" class="csharp">
private static List&lt;Item&gt; SearchEmailMessages(ExchangeService service,String subject,
    DateTime startDate,DateTime endDate,String from,String displayTo,String displayCc)
{
    PropertySet itemPropertySet = 
        new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.PolicyTag);
    SearchFilter.SearchFilterCollection searchFilterCollection = 
        new SearchFilter.SearchFilterCollection(LogicalOperator.And);
    SearchFilter startDateFilter = 
        new SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate);
    SearchFilter endDateFilter = 
        new SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated,endDate);
    // Just select the email message items.
    SearchFilter itemClassFilter = 
        new SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, &quot;IPM.Note&quot;);
    searchFilterCollection.Add(startDateFilter);
    searchFilterCollection.Add(endDateFilter);
    searchFilterCollection.Add(itemClassFilter);
    if (!String.IsNullOrWhiteSpace(subject))
    {
        SearchFilter subjectFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, subject);
        searchFilterCollection.Add(subjectFilter);
    }
    if (!String.IsNullOrWhiteSpace(from))
    {
        SearchFilter fromFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.From, from);
        searchFilterCollection.Add(fromFilter);
    }
    if (!String.IsNullOrWhiteSpace(displayTo))
    {
        SearchFilter displayToFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayTo, displayTo);
        searchFilterCollection.Add(displayToFilter);
    }
    if (!String.IsNullOrWhiteSpace(displayCc))
    {
        SearchFilter displayCcFilter = 
            new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayCc, displayCc);
        searchFilterCollection.Add(displayCcFilter);
    }
    List&lt;Item&gt; items = GetItems(service, searchFilterCollection, WellKnownFolderName.Inbox, itemPropertySet);
    Console.WriteLine(&quot;{0,-30}{1}&quot;, &quot;Subject&quot;, &quot;PolicyTag&quot;);
    foreach (Item item in items)
    {
        Console.WriteLine(&quot;{0,-30}{1}&quot;, item.Subject, item.PolicyTag);
    }
    Console.WriteLine();
    return items;
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Get Retention Policy</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In Office 365 Exchange Online, there&rsquo;re many retention policies. You can use one of them in
</span><span style="font-size:11pt">subsequent</span><span style="font-size:11pt"> email messages.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private static RetentionPolicyTag GetRetentionPolicyTag(ExchangeService service, String userAddress)
{
    service.GetPasswordExpirationDate(userAddress);
    if (service.ServerInfo.MajorVersion &lt; 15)
    {
        Console.WriteLine(&quot;This version of Exchange don't support PolicyTag.&quot;);
        return null;
    }
    GetUserRetentionPolicyTagsResponse getUserRetentionPolicyTagsResponse = 
        service.GetUserRetentionPolicyTags();
    if (getUserRetentionPolicyTagsResponse.ErrorCode != ServiceError.NoError)
    {
        Console.WriteLine(&quot;Error:{0}&quot;, getUserRetentionPolicyTagsResponse.ErrorMessage);
        return null;
    }
    RetentionPolicyTag[] retentionPolicyTags=
        getUserRetentionPolicyTagsResponse.RetentionPolicyTags;
    do
    {
        Int32 policyTagsCount = -1;
        foreach (RetentionPolicyTag retentionPolicyTag in retentionPolicyTags)
        {
            policyTagsCount&#43;&#43;;
            Console.WriteLine(&quot;{0,-3}: {1}&quot;, policyTagsCount, retentionPolicyTag.DisplayName);
        }
        Console.Write(&quot;Please choose the Retention Policy Tag you want to set for the email messages(0-{0}):&quot;, 
            policyTagsCount);
        String selectedPolicyTag = Console.ReadLine();
        Int32 selectedPolicyTagNum = -1;
        if (Int32.TryParse(selectedPolicyTag, out selectedPolicyTagNum) && 
            selectedPolicyTagNum &gt;= 0 && selectedPolicyTagNum &lt;= policyTagsCount)
        {
            return retentionPolicyTags[selectedPolicyTagNum];
        }
    } while (true);
}
</pre>
<pre class="hidden">
Private Shared Function GetRetentionPolicyTag(ByVal service As ExchangeService,
                                              ByVal userAddress As String) As RetentionPolicyTag
    service.GetPasswordExpirationDate(userAddress)
    If service.ServerInfo.MajorVersion &lt; 15 Then
        Console.WriteLine(&quot;This version of Exchange don't support PolicyTag.&quot;)
        Return Nothing
    End If
    Dim getUserRetentionPolicyTagsResponse As GetUserRetentionPolicyTagsResponse =
        service.GetUserRetentionPolicyTags()
    If getUserRetentionPolicyTagsResponse.ErrorCode &lt;&gt; ServiceError.NoError Then
        Console.WriteLine(&quot;Error:{0}&quot;, getUserRetentionPolicyTagsResponse.ErrorMessage)
        Return Nothing
    End If
    Dim retentionPolicyTags() As RetentionPolicyTag =
        getUserRetentionPolicyTagsResponse.RetentionPolicyTags
    Do
        Dim policyTagsCount As Int32 = -1
        For Each retentionPolicyTag As RetentionPolicyTag In retentionPolicyTags
            policyTagsCount &#43;= 1
            Console.WriteLine(&quot;{0,-3}: {1}&quot;, policyTagsCount, retentionPolicyTag.DisplayName)
        Next retentionPolicyTag
        Console.Write(&quot;Please choose the Retention Policy Tag you want to set for the email messages(0-{0}):&quot;, policyTagsCount)
        Dim selectedPolicyTag As String = Console.ReadLine()
        Dim selectedPolicyTagNum As Int32 = -1
        If Int32.TryParse(selectedPolicyTag, selectedPolicyTagNum) AndAlso
            selectedPolicyTagNum &gt;= 0 AndAlso selectedPolicyTagNum &lt;= policyTagsCount Then
            Return retentionPolicyTags(selectedPolicyTagNum)
        End If
    Loop While True
End Function
</pre>
<pre id="codePreview" class="csharp">
private static RetentionPolicyTag GetRetentionPolicyTag(ExchangeService service, String userAddress)
{
    service.GetPasswordExpirationDate(userAddress);
    if (service.ServerInfo.MajorVersion &lt; 15)
    {
        Console.WriteLine(&quot;This version of Exchange don't support PolicyTag.&quot;);
        return null;
    }
    GetUserRetentionPolicyTagsResponse getUserRetentionPolicyTagsResponse = 
        service.GetUserRetentionPolicyTags();
    if (getUserRetentionPolicyTagsResponse.ErrorCode != ServiceError.NoError)
    {
        Console.WriteLine(&quot;Error:{0}&quot;, getUserRetentionPolicyTagsResponse.ErrorMessage);
        return null;
    }
    RetentionPolicyTag[] retentionPolicyTags=
        getUserRetentionPolicyTagsResponse.RetentionPolicyTags;
    do
    {
        Int32 policyTagsCount = -1;
        foreach (RetentionPolicyTag retentionPolicyTag in retentionPolicyTags)
        {
            policyTagsCount&#43;&#43;;
            Console.WriteLine(&quot;{0,-3}: {1}&quot;, policyTagsCount, retentionPolicyTag.DisplayName);
        }
        Console.Write(&quot;Please choose the Retention Policy Tag you want to set for the email messages(0-{0}):&quot;, 
            policyTagsCount);
        String selectedPolicyTag = Console.ReadLine();
        Int32 selectedPolicyTagNum = -1;
        if (Int32.TryParse(selectedPolicyTag, out selectedPolicyTagNum) && 
            selectedPolicyTagNum &gt;= 0 && selectedPolicyTagNum &lt;= policyTagsCount)
        {
            return retentionPolicyTags[selectedPolicyTagNum];
        }
    } while (true);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Set Retention Polic</span><span style="font-size:11pt">ies</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After getting the email messages and
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">retention policy, the application will set the specified retention policy in the email messages.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
if (retentionPolicyTag != null)
{
    Console.WriteLine(&quot;Setting the Retention Policy...&quot;);
    PolicyTag policyTag = new PolicyTag(true, retentionPolicyTag.RetentionId);
    foreach (Item item in items)
    {
        item.PolicyTag = policyTag;
        item.Update(ConflictResolutionMode.AlwaysOverwrite);
    }
}
</pre>
<pre class="hidden">
If retentionPolicyTag IsNot Nothing Then
    Console.WriteLine(&quot;Setting the Retention Policy...&quot;)
    Dim policyTag As New PolicyTag(True, retentionPolicyTag.RetentionId)
    For Each item As Item In items
        item.PolicyTag = policyTag
        item.Update(ConflictResolutionMode.AlwaysOverwrite)
    Next item
</pre>
<pre id="codePreview" class="csharp">
if (retentionPolicyTag != null)
{
    Console.WriteLine(&quot;Setting the Retention Policy...&quot;);
    PolicyTag policyTag = new PolicyTag(true, retentionPolicyTag.RetentionId);
    foreach (Item item in items)
    {
        item.PolicyTag = policyTag;
        item.Update(ConflictResolutionMode.AlwaysOverwrite);
    }
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
<span style="font-size:11pt"><a href="http://technet.microsoft.com/en-us/library/dd315326.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Windows PowerShell Advanced Function</span></a><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/exchange/microsoft.exchange.webservices.data.retentionpolicytag%28v=exchg.80%29.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">RetentionPolicyTag class</span></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
