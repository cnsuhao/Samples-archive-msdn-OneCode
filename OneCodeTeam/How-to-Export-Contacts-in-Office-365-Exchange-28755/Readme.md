# How to Export Contacts in Office 365 Exchange Online
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* CSV
* O365
* export contacts
## IsPublished
* True
## ModifiedDate
* 2014-05-21 03:03:11
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span>How to Export Contacts in Office 365 Exchange Online
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span>Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Outlook Web App (OWA) allows us to import multiple contacts in a very simple way. However, it does not allow</span><span> us</span><span> to export contacts. In this application, we will demonstrate how to export contacts
 from Office 365 Exchange Online.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>1. Get all the contacts from Office 365 Exchange Online.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>2. Write the head title to the CSV file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>3. Write the contacts into the CSV file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span>Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Press F5 to run the sample, </span><span>we will get
</span><span>the following result.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>First, we use our account to login the Exchange Online.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114996/1/image.png" alt="" width="407" height="57" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Then, we need to input </span><span>the</span><span> path of</span><span> the</span><span> folder that</span><span> will be used to</span><span> store the CSV file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114997/1/image.png" alt="" width="479" height="26" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>After that, we will create the file that contains the contacts.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114998/1/image.png" alt="" width="479" height="25" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Now you can find the file contacts.csv under the folder:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114999/1/image.png" alt="" width="479" height="175" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Then </span><span>you can import the file into</span><span> other accounts.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span>Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>1. Get the contact properties tha</span><span>t</span><span> you want to write into</span><span> a</span><span> CSV file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>The name of property is different </span><span>from</span><span> the column title of the file, so we store the property definitions and the column titles in the Dictionary. The key of the dictionary is the property definition,
 and the value is the column title of the CSV file.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public static Dictionary&lt;PropertyDefinitionBase, String&gt; GetSchemaList()
{
    Dictionary&lt;PropertyDefinitionBase, String&gt; schemaList = 
        new Dictionary&lt;PropertyDefinitionBase, string&gt;();
    schemaList.Add(ContactSchema.Surname, &quot;Last Name&quot;);
    schemaList.Add(ContactSchema.GivenName, &quot;First Name&quot;);
    schemaList.Add(ContactSchema.CompanyName, &quot;Company&quot;);
    schemaList.Add(ContactSchema.Department, &quot;Department&quot;);
    schemaList.Add(ContactSchema.JobTitle, &quot;Job Title&quot;);
    schemaList.Add(ContactSchema.BusinessPhone, &quot;Business Phone&quot;);
    schemaList.Add(ContactSchema.HomePhone, &quot;Home Phone&quot;);
    schemaList.Add(ContactSchema.MobilePhone, &quot;Mobile Phone&quot;);
    schemaList.Add(ContactSchema.BusinessAddressStreet, &quot;Business Street&quot;);
    schemaList.Add(ContactSchema.BusinessAddressCity, &quot;Business City&quot;);
    schemaList.Add(ContactSchema.BusinessAddressState, &quot;Business State&quot;);
    schemaList.Add(ContactSchema.BusinessAddressPostalCode, &quot;Business Postal Code&quot;);
    schemaList.Add(ContactSchema.BusinessAddressCountryOrRegion, &quot;Business Country/Region&quot;);
    schemaList.Add(ContactSchema.HomeAddressStreet, &quot;Home Street&quot;);
    schemaList.Add(ContactSchema.HomeAddressCity, &quot;Home City&quot;);
    schemaList.Add(ContactSchema.HomeAddressState, &quot;Home State&quot;);
    schemaList.Add(ContactSchema.HomeAddressPostalCode, &quot;Home Postal Code&quot;);
    schemaList.Add(ContactSchema.HomeAddressCountryOrRegion, &quot;Home Country/Region&quot;);
    schemaList.Add(ContactSchema.EmailAddress1, &quot;Email Address&quot;);
    return schemaList;
}
</pre>
<pre class="hidden">Public Shared Function GetSchemaList() As Dictionary(Of PropertyDefinitionBase, String)
    Dim schemaList As New Dictionary(Of PropertyDefinitionBase, String)()
    schemaList.Add(ContactSchema.Surname, &quot;Last Name&quot;)
    schemaList.Add(ContactSchema.GivenName, &quot;First Name&quot;)
    schemaList.Add(ContactSchema.CompanyName, &quot;Company&quot;)
    schemaList.Add(ContactSchema.Department, &quot;Department&quot;)
    schemaList.Add(ContactSchema.JobTitle, &quot;Job Title&quot;)
    schemaList.Add(ContactSchema.BusinessPhone, &quot;Business Phone&quot;)
    schemaList.Add(ContactSchema.HomePhone, &quot;Home Phone&quot;)
    schemaList.Add(ContactSchema.MobilePhone, &quot;Mobile Phone&quot;)
    schemaList.Add(ContactSchema.BusinessAddressStreet, &quot;Business Street&quot;)
    schemaList.Add(ContactSchema.BusinessAddressCity, &quot;Business City&quot;)
    schemaList.Add(ContactSchema.BusinessAddressState, &quot;Business State&quot;)
    schemaList.Add(ContactSchema.BusinessAddressPostalCode, &quot;Business Postal Code&quot;)
    schemaList.Add(ContactSchema.BusinessAddressCountryOrRegion, &quot;Business Country/Region&quot;)
    schemaList.Add(ContactSchema.HomeAddressStreet, &quot;Home Street&quot;)
    schemaList.Add(ContactSchema.HomeAddressCity, &quot;Home City&quot;)
    schemaList.Add(ContactSchema.HomeAddressState, &quot;Home State&quot;)
    schemaList.Add(ContactSchema.HomeAddressPostalCode, &quot;Home Postal Code&quot;)
    schemaList.Add(ContactSchema.HomeAddressCountryOrRegion, &quot;Home Country/Region&quot;)
    schemaList.Add(ContactSchema.EmailAddress1, &quot;Email Address&quot;)
    Return schemaList
End Function
</pre>
<pre class="csharp" id="codePreview">public static Dictionary&lt;PropertyDefinitionBase, String&gt; GetSchemaList()
{
    Dictionary&lt;PropertyDefinitionBase, String&gt; schemaList = 
        new Dictionary&lt;PropertyDefinitionBase, string&gt;();
    schemaList.Add(ContactSchema.Surname, &quot;Last Name&quot;);
    schemaList.Add(ContactSchema.GivenName, &quot;First Name&quot;);
    schemaList.Add(ContactSchema.CompanyName, &quot;Company&quot;);
    schemaList.Add(ContactSchema.Department, &quot;Department&quot;);
    schemaList.Add(ContactSchema.JobTitle, &quot;Job Title&quot;);
    schemaList.Add(ContactSchema.BusinessPhone, &quot;Business Phone&quot;);
    schemaList.Add(ContactSchema.HomePhone, &quot;Home Phone&quot;);
    schemaList.Add(ContactSchema.MobilePhone, &quot;Mobile Phone&quot;);
    schemaList.Add(ContactSchema.BusinessAddressStreet, &quot;Business Street&quot;);
    schemaList.Add(ContactSchema.BusinessAddressCity, &quot;Business City&quot;);
    schemaList.Add(ContactSchema.BusinessAddressState, &quot;Business State&quot;);
    schemaList.Add(ContactSchema.BusinessAddressPostalCode, &quot;Business Postal Code&quot;);
    schemaList.Add(ContactSchema.BusinessAddressCountryOrRegion, &quot;Business Country/Region&quot;);
    schemaList.Add(ContactSchema.HomeAddressStreet, &quot;Home Street&quot;);
    schemaList.Add(ContactSchema.HomeAddressCity, &quot;Home City&quot;);
    schemaList.Add(ContactSchema.HomeAddressState, &quot;Home State&quot;);
    schemaList.Add(ContactSchema.HomeAddressPostalCode, &quot;Home Postal Code&quot;);
    schemaList.Add(ContactSchema.HomeAddressCountryOrRegion, &quot;Home Country/Region&quot;);
    schemaList.Add(ContactSchema.EmailAddress1, &quot;Email Address&quot;);
    return schemaList;
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>2. After getting all the contacts from Office 365 Exchange Online, we need to input the path of
</span><span>the </span><span>folder that</span><span> will be used to </span><span>store</span><a name="_GoBack"></a><span> the CSV file.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private static String GetFolderPath()
{
    do
    {
        Console.Write(&quot;Please input the floder path:&quot;);
        String path = Console.ReadLine();
        List&lt;String&gt; files = new List&lt;String&gt;();
        if (Directory.Exists(path))
        {
            return path;
        }
        Console.WriteLine(&quot;The path is invaild.&quot;);
    } while (true);
}
</pre>
<pre class="hidden">Private Shared Function GetFolderPath() As String
    Do
        Console.Write(&quot;Please input the floder path:&quot;)
        Dim path As String = Console.ReadLine()
        Dim files As New List(Of String)()
        If Directory.Exists(path) Then
            Return path
        End If
        Console.WriteLine(&quot;The path is invaild.&quot;)
    Loop While True
    Return Nothing
End Function
</pre>
<pre class="csharp" id="codePreview">private static String GetFolderPath()
{
    do
    {
        Console.Write(&quot;Please input the floder path:&quot;);
        String path = Console.ReadLine();
        List&lt;String&gt; files = new List&lt;String&gt;();
        if (Directory.Exists(path))
        {
            return path;
        }
        Console.WriteLine(&quot;The path is invaild.&quot;);
    } while (true);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>3. Then we write the contacts into the file.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public static void WriteContacts(StreamWriter writer, PropertyDefinitionBase proerty, Contact contact)
  {
      if (proerty.Equals(ContactSchema.Surname))
      {
          if (!String.IsNullOrWhiteSpace(contact.Surname))
          {
              writer.Write(&quot;\&quot;{0}\&quot;&quot;, contact.Surname);
          }
      }
      else if (proerty.Equals(ContactSchema.GivenName))
      {
          if (!String.IsNullOrWhiteSpace(contact.GivenName))
          {
              writer.Write(&quot;\&quot;{0}\&quot;&quot;, contact.GivenName);
          }
      }
      else if (proerty.Equals(ContactSchema.CompanyName))
.............................
  }
</pre>
<pre class="hidden">Public Shared Sub WriteContacts(ByVal writer As StreamWriter,
                                ByVal proerty As PropertyDefinitionBase,
                                ByVal contact As Contact)
    If proerty.Equals(ContactSchema.Surname) Then
        If Not String.IsNullOrWhiteSpace(contact.Surname) Then
            writer.Write(&quot;&quot;&quot;{0}&quot;&quot;&quot;, contact.Surname)
        End If
    ElseIf proerty.Equals(ContactSchema.GivenName) Then
        If Not String.IsNullOrWhiteSpace(contact.GivenName) Then
            writer.Write(&quot;&quot;&quot;{0}&quot;&quot;&quot;, contact.GivenName)
        End If
    ElseIf proerty.Equals(ContactSchema.CompanyName) Then
.......................................................
    End If
End Sub
</pre>
<pre class="csharp" id="codePreview">public static void WriteContacts(StreamWriter writer, PropertyDefinitionBase proerty, Contact contact)
  {
      if (proerty.Equals(ContactSchema.Surname))
      {
          if (!String.IsNullOrWhiteSpace(contact.Surname))
          {
              writer.Write(&quot;\&quot;{0}\&quot;&quot;, contact.Surname);
          }
      }
      else if (proerty.Equals(ContactSchema.GivenName))
      {
          if (!String.IsNullOrWhiteSpace(contact.GivenName))
          {
              writer.Write(&quot;\&quot;{0}\&quot;&quot;, contact.GivenName);
          }
      }
      else if (proerty.Equals(ContactSchema.CompanyName))
.............................
  }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span>More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">EWS Managed API 2.0</span></a><span>
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/exchange/microsoft.exchange.webservices.data.contact(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Contact class</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
