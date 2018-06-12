# How to Import vCard Files in Office 365 Exchange Online
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* multiple
* O365
* vCard files
## IsPublished
* True
## ModifiedDate
* 2014-05-04 11:49:22
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Import vCard Files</span><span style="font-weight:bold; font-size:14pt"> in Office 365 Exchange Online
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The vCard file format is supported by many email clients and emai</span><span style="font-size:11pt">l services. Now Outlook Web App
</span><span style="font-size:11pt">supports import </span><span style="font-size:11pt">of</span><span style="font-size:11pt"> single .CSV file</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> only. In this application, we will demonstrate
 how to import multiple vCard files in Office 365 Exchange Online.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Get a single file or all the vCard files in the folder;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Read the contact information from the vCard file;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Create a new contact and set the properties;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">4. Save the contact</span><span style="font-size:11pt">;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">5. Process 2-4 steps for all the vCard files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample,
</span><span style="font-size:11pt">you will get the following </span><span style="font-size:11pt">result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we use our account to connect
</span><span style="font-size:11pt">to </span><span style="font-size:11pt">the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114028/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then, we need to input a file path or a folder path.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114029/1/image.png" alt="" width="379" height="53" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After that, we will create the contacts for the vCard files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114030/1/image.png" alt="" width="395" height="39" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">1. Read information from vCard files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Before creating the new contact, we need to read and store the contact information from the vCard file. For different entries, we store them in different names.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
if (keyName.StartsWith(&quot;Names&quot;))
{
    String[] names = keyValue.Split(';');
    if (names.Length &gt;= 2)
    {
        contactInfo.Add(ContactSchemaProperties.Surname, names[0]);
        contactInfo.Add(ContactSchemaProperties.GivenName, names[1]);
    }
}
else if (keyName.StartsWith(&quot;FN&quot;))
{
    contactInfo.Add(ContactSchemaProperties.DisplayName, keyValue);
}
else if (keyName.StartsWith(&quot;ORG&quot;))
{
    String[] comDep = keyValue.Split(';');
    contactInfo.Add(ContactSchemaProperties.CompanyName, comDep[0]);
    contactInfo.Add(ContactSchemaProperties.Companies, comDep[0]);
    contactInfo.Add(ContactSchemaProperties.Department, comDep[1]);
}
else if (keyName.StartsWith(&quot;TITLE&quot;))
{
    contactInfo.Add(ContactSchemaProperties.JobTitle, keyValue);
}
else if (keyName.StartsWith(&quot;PHOTO&quot;))
{
    ImportContactDetails.ImportPhoto(contactInfo, keyName, reader);
}
else if (keyName.StartsWith(&quot;TEL&quot;))
{
    ImportContactDetails.ImportTelephone(contactInfo, keyName, keyValue);
}
else if (keyName.StartsWith(&quot;ADR&quot;))
{
    ImportContactDetails.ImportAddress(contactInfo, keyName, keyValue);
}
else if (keyName.StartsWith(&quot;EMAIL&quot;))
{
    ImportContactDetails.ImportEmail(contactInfo, keyName, keyValue);
}
</pre>
<pre class="hidden">
If keyName.StartsWith(&quot;Names&quot;) Then
    Dim names() As String = keyValue.Split(&quot;;&quot;c)
    If names.Length &gt;= 2 Then
        contactInfo.Add(ContactSchemaProperties.Surname, names(0))
        contactInfo.Add(ContactSchemaProperties.GivenName, names(1))
    End If
ElseIf keyName.StartsWith(&quot;FN&quot;) Then
    contactInfo.Add(ContactSchemaProperties.DisplayName, keyValue)
ElseIf keyName.StartsWith(&quot;ORG&quot;) Then
    Dim comDep() As String = keyValue.Split(&quot;;&quot;c)
    contactInfo.Add(ContactSchemaProperties.CompanyName, comDep(0))
    contactInfo.Add(ContactSchemaProperties.Companies, comDep(0))
    contactInfo.Add(ContactSchemaProperties.Department, comDep(1))
ElseIf keyName.StartsWith(&quot;TITLE&quot;) Then
    contactInfo.Add(ContactSchemaProperties.JobTitle, keyValue)
ElseIf keyName.StartsWith(&quot;PHOTO&quot;) Then
    ImportContactDetails.ImportPhoto(contactInfo, keyName, reader)
ElseIf keyName.StartsWith(&quot;TEL&quot;) Then
    ImportContactDetails.ImportTelephone(contactInfo, keyName, keyValue)
ElseIf keyName.StartsWith(&quot;ADR&quot;) Then
    ImportContactDetails.ImportAddress(contactInfo, keyName, keyValue)
ElseIf keyName.StartsWith(&quot;EMAIL&quot;) Then
    ImportContactDetails.ImportEmail(contactInfo, keyName, keyValue)
End If
</pre>
<pre id="codePreview" class="csharp">
if (keyName.StartsWith(&quot;Names&quot;))
{
    String[] names = keyValue.Split(';');
    if (names.Length &gt;= 2)
    {
        contactInfo.Add(ContactSchemaProperties.Surname, names[0]);
        contactInfo.Add(ContactSchemaProperties.GivenName, names[1]);
    }
}
else if (keyName.StartsWith(&quot;FN&quot;))
{
    contactInfo.Add(ContactSchemaProperties.DisplayName, keyValue);
}
else if (keyName.StartsWith(&quot;ORG&quot;))
{
    String[] comDep = keyValue.Split(';');
    contactInfo.Add(ContactSchemaProperties.CompanyName, comDep[0]);
    contactInfo.Add(ContactSchemaProperties.Companies, comDep[0]);
    contactInfo.Add(ContactSchemaProperties.Department, comDep[1]);
}
else if (keyName.StartsWith(&quot;TITLE&quot;))
{
    contactInfo.Add(ContactSchemaProperties.JobTitle, keyValue);
}
else if (keyName.StartsWith(&quot;PHOTO&quot;))
{
    ImportContactDetails.ImportPhoto(contactInfo, keyName, reader);
}
else if (keyName.StartsWith(&quot;TEL&quot;))
{
    ImportContactDetails.ImportTelephone(contactInfo, keyName, keyValue);
}
else if (keyName.StartsWith(&quot;ADR&quot;))
{
    ImportContactDetails.ImportAddress(contactInfo, keyName, keyValue);
}
else if (keyName.StartsWith(&quot;EMAIL&quot;))
{
    ImportContactDetails.ImportEmail(contactInfo, keyName, keyValue);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">For </span><a name="_GoBack"></a><span style="font-size:11pt">complex information, we&rsquo;ll use more steps to get the details, such as the Address.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
String addrType = keyName.Split(';')[1];
switch (addrType)
{
    case &quot;WORK&quot;:
        {
            String[] bussinessAdr = keyValue.Split(';');
            if (bussinessAdr.Length &gt;= 1)
            {
                contactInfo.Add(ContactSchemaProperties.OfficeLocation, bussinessAdr[1]);
            }
            ContactSchemaProperties[] properties = 
            { 
            ContactSchemaProperties.BusinessAddressStreet,
            ContactSchemaProperties.BusinessAddressCity,
            ContactSchemaProperties.BusinessAddressState,
            ContactSchemaProperties.BusinessAddressPostalCode,
            ContactSchemaProperties.BusinessAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; bussinessAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], bussinessAdr[i]);
            }
        }
        break;
    case &quot;HOME&quot;:
        {
            String[] homeAdr = keyValue.Split(';');
            ContactSchemaProperties[] properties = { 
                    ContactSchemaProperties.HomeAddressStreet,
                    ContactSchemaProperties.HomeAddressCity,
                    ContactSchemaProperties.HomeAddressState,
                    ContactSchemaProperties.HomeAddressPostalCode,
                    ContactSchemaProperties.HomeAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; homeAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], homeAdr[i]);
            }
        }
        break;
    case &quot;POSTAL&quot;:
        {
            String[] postalAdr = keyValue.Split(';');
            ContactSchemaProperties[] properties = { 
                    ContactSchemaProperties.OtherAddressStreet,
                    ContactSchemaProperties.OtherAddressCity,
                    ContactSchemaProperties.OtherAddressState,
                    ContactSchemaProperties.OtherAddressPostalCode,
                    ContactSchemaProperties.OtherAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; postalAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], postalAdr[i]);
            }
        }
        break;
    default: break;
}
</pre>
<pre class="hidden">
Select Case addrType
    Case &quot;WORK&quot;
        Dim bussinessAdr() As String = keyValue.Split(&quot;;&quot;c)
        If bussinessAdr.Length &gt;= 1 Then
            contactInfo.Add(ContactSchemaProperties.OfficeLocation, bussinessAdr(1))
        End If
        Dim properties() As ContactSchemaProperties = {
            ContactSchemaProperties.BusinessAddressStreet,
            ContactSchemaProperties.BusinessAddressCity,
            ContactSchemaProperties.BusinessAddressState,
            ContactSchemaProperties.BusinessAddressPostalCode,
            ContactSchemaProperties.BusinessAddressCountryOrRegion}
        For i As Int32 = 2 To bussinessAdr.Length - 1
            contactInfo.Add(properties(i - 2), bussinessAdr(i))
        Next i
    Case &quot;HOME&quot;
        Dim homeAdr() As String = keyValue.Split(&quot;;&quot;c)
        Dim properties() As ContactSchemaProperties = {
            ContactSchemaProperties.HomeAddressStreet,
            ContactSchemaProperties.HomeAddressCity,
            ContactSchemaProperties.HomeAddressState,
            ContactSchemaProperties.HomeAddressPostalCode,
            ContactSchemaProperties.HomeAddressCountryOrRegion}
        For i As Int32 = 2 To homeAdr.Length - 1
            contactInfo.Add(properties(i - 2), homeAdr(i))
        Next i
    Case &quot;POSTAL&quot;
        Dim postalAdr() As String = keyValue.Split(&quot;;&quot;c)
        Dim properties() As ContactSchemaProperties = {
            ContactSchemaProperties.OtherAddressStreet,
            ContactSchemaProperties.OtherAddressCity,
            ContactSchemaProperties.OtherAddressState,
            ContactSchemaProperties.OtherAddressPostalCode,
            ContactSchemaProperties.OtherAddressCountryOrRegion}
        For i As Int32 = 2 To postalAdr.Length - 1
            contactInfo.Add(properties(i - 2), postalAdr(i))
        Next i
    Case Else
End Select
</pre>
<pre id="codePreview" class="csharp">
String addrType = keyName.Split(';')[1];
switch (addrType)
{
    case &quot;WORK&quot;:
        {
            String[] bussinessAdr = keyValue.Split(';');
            if (bussinessAdr.Length &gt;= 1)
            {
                contactInfo.Add(ContactSchemaProperties.OfficeLocation, bussinessAdr[1]);
            }
            ContactSchemaProperties[] properties = 
            { 
            ContactSchemaProperties.BusinessAddressStreet,
            ContactSchemaProperties.BusinessAddressCity,
            ContactSchemaProperties.BusinessAddressState,
            ContactSchemaProperties.BusinessAddressPostalCode,
            ContactSchemaProperties.BusinessAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; bussinessAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], bussinessAdr[i]);
            }
        }
        break;
    case &quot;HOME&quot;:
        {
            String[] homeAdr = keyValue.Split(';');
            ContactSchemaProperties[] properties = { 
                    ContactSchemaProperties.HomeAddressStreet,
                    ContactSchemaProperties.HomeAddressCity,
                    ContactSchemaProperties.HomeAddressState,
                    ContactSchemaProperties.HomeAddressPostalCode,
                    ContactSchemaProperties.HomeAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; homeAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], homeAdr[i]);
            }
        }
        break;
    case &quot;POSTAL&quot;:
        {
            String[] postalAdr = keyValue.Split(';');
            ContactSchemaProperties[] properties = { 
                    ContactSchemaProperties.OtherAddressStreet,
                    ContactSchemaProperties.OtherAddressCity,
                    ContactSchemaProperties.OtherAddressState,
                    ContactSchemaProperties.OtherAddressPostalCode,
                    ContactSchemaProperties.OtherAddressCountryOrRegion};
            for (Int32 i = 2; i &lt; postalAdr.Length; i&#43;&#43;)
            {
                contactInfo.Add(properties[i - 2], postalAdr[i]);
            }
        }
        break;
    default: break;
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">2. Create a new contact.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After getting the contact information, we&rsquo;ll create a new contact and save it.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
foreach (ContactSchemaProperties key in contactInfo.Keys)
{
    switch (key)
    {
        case ContactSchemaProperties.Surname:
            newContact.Surname = contactInfo[key];
            break;
        case ContactSchemaProperties.GivenName:
            newContact.GivenName = contactInfo[key];
            break;
        case ContactSchemaProperties.DisplayName:
            newContact.DisplayName = contactInfo[key];
            break;
        case ContactSchemaProperties.JobTitle:
            newContact.JobTitle = contactInfo[key];
            break;
        case ContactSchemaProperties.Birthday:
            {
                DateTime birthday;
                newContact.Birthday = DateTime.TryParse(contactInfo[key], out birthday) ? (DateTime?)birthday : null;
            }
            break;
        case ContactSchemaProperties.CompanyName:
            newContact.CompanyName = contactInfo[key];
            break;
        case ContactSchemaProperties.Companies:
            {
                StringList stringList = new StringList();
                stringList.Add(contactInfo[key]);
                newContact.Companies = stringList;
            }
            break;
        case ContactSchemaProperties.Department:
            newContact.Department = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress1:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress1] = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress2:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress2] = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress3:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress3] = contactInfo[key];
            break;
        case ContactSchemaProperties.BusinessAddressStreet:
        case ContactSchemaProperties.BusinessAddressCity:
        case ContactSchemaProperties.BusinessAddressState:
        case ContactSchemaProperties.BusinessAddressPostalCode:
        case ContactSchemaProperties.BusinessAddressCountryOrRegion:
            {
                if (businessAddressEntry == null)
                {
                    businessAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], businessAddressEntry);
            }
            break;
        case ContactSchemaProperties.HomeAddressStreet:
        case ContactSchemaProperties.HomeAddressCity:
        case ContactSchemaProperties.HomeAddressState:
        case ContactSchemaProperties.HomeAddressPostalCode:
        case ContactSchemaProperties.HomeAddressCountryOrRegion:
            {
                if (homeAddressEntry == null)
                {
                    homeAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], homeAddressEntry);
            }
            break;
        case ContactSchemaProperties.OtherAddressStreet:
        case ContactSchemaProperties.OtherAddressCity:
        case ContactSchemaProperties.OtherAddressState:
        case ContactSchemaProperties.OtherAddressPostalCode:
        case ContactSchemaProperties.OtherAddressCountryOrRegion:
            {
                if (otherAddressEntry == null)
                {
                    otherAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], otherAddressEntry);
            }
            break;
        case ContactSchemaProperties.BusinessPhone:
            newContact.PhoneNumbers[PhoneNumberKey.BusinessPhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.BusinessPhone2:
            newContact.PhoneNumbers[PhoneNumberKey.BusinessPhone2] = contactInfo[key];
            break;
        case ContactSchemaProperties.HomePhone:
            newContact.PhoneNumbers[PhoneNumberKey.HomePhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.HomePhone2:
            newContact.PhoneNumbers[PhoneNumberKey.HomePhone2] = contactInfo[key];
            break;
        case ContactSchemaProperties.MobilePhone:
            newContact.PhoneNumbers[PhoneNumberKey.MobilePhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.Photo:
            {
                Byte[] picture = Convert.FromBase64String(contactInfo[key]);
                newContact.SetContactPicture(picture);
            }
            break;
        default:
            break;
    }
}
</pre>
<pre class="hidden">
For Each key As ContactSchemaProperties In contactInfo.Keys
    Select Case key
        Case ContactSchemaProperties.Surname
            newContact.Surname = contactInfo(key)
        Case ContactSchemaProperties.GivenName
            newContact.GivenName = contactInfo(key)
        Case ContactSchemaProperties.DisplayName
            newContact.DisplayName = contactInfo(key)
        Case ContactSchemaProperties.JobTitle
            newContact.JobTitle = contactInfo(key)
        Case ContactSchemaProperties.Birthday
            Dim birthday As Date
            newContact.Birthday =
                IIf(Date.TryParse(contactInfo(key), birthday), birthday, Nothing)
        Case ContactSchemaProperties.CompanyName
            newContact.CompanyName = contactInfo(key)
        Case ContactSchemaProperties.Companies
            Dim stringList As New StringList()
            stringList.Add(contactInfo(key))
            newContact.Companies = stringList
        Case ContactSchemaProperties.Department
            newContact.Department = contactInfo(key)
        Case ContactSchemaProperties.EmailAddress1
            newContact.EmailAddresses(EmailAddressKey.EmailAddress1) = contactInfo(key)
        Case ContactSchemaProperties.EmailAddress2
            newContact.EmailAddresses(EmailAddressKey.EmailAddress2) = contactInfo(key)
        Case ContactSchemaProperties.EmailAddress3
            newContact.EmailAddresses(EmailAddressKey.EmailAddress3) = contactInfo(key)
        Case ContactSchemaProperties.BusinessAddressStreet,
            ContactSchemaProperties.BusinessAddressCity,
            ContactSchemaProperties.BusinessAddressState,
            ContactSchemaProperties.BusinessAddressPostalCode,
            ContactSchemaProperties.BusinessAddressCountryOrRegion
            If businessAddressEntry Is Nothing Then
                businessAddressEntry = New PhysicalAddressEntry()
            End If
            SetContactDetails.SetAddress(key, contactInfo(key), businessAddressEntry)
        Case ContactSchemaProperties.HomeAddressStreet,
            ContactSchemaProperties.HomeAddressCity,
            ContactSchemaProperties.HomeAddressState,
            ContactSchemaProperties.HomeAddressPostalCode,
            ContactSchemaProperties.HomeAddressCountryOrRegion
            If homeAddressEntry Is Nothing Then
                homeAddressEntry = New PhysicalAddressEntry()
            End If
            SetContactDetails.SetAddress(key, contactInfo(key), homeAddressEntry)
        Case ContactSchemaProperties.OtherAddressStreet,
            ContactSchemaProperties.OtherAddressCity,
            ContactSchemaProperties.OtherAddressState,
            ContactSchemaProperties.OtherAddressPostalCode,
            ContactSchemaProperties.OtherAddressCountryOrRegion
            If otherAddressEntry Is Nothing Then
                otherAddressEntry = New PhysicalAddressEntry()
            End If
            SetContactDetails.SetAddress(key, contactInfo(key), otherAddressEntry)
        Case ContactSchemaProperties.BusinessPhone
            newContact.PhoneNumbers(PhoneNumberKey.BusinessPhone) = contactInfo(key)
        Case ContactSchemaProperties.BusinessPhone2
            newContact.PhoneNumbers(PhoneNumberKey.BusinessPhone2) = contactInfo(key)
        Case ContactSchemaProperties.HomePhone
            newContact.PhoneNumbers(PhoneNumberKey.HomePhone) = contactInfo(key)
        Case ContactSchemaProperties.HomePhone2
            newContact.PhoneNumbers(PhoneNumberKey.HomePhone2) = contactInfo(key)
        Case ContactSchemaProperties.MobilePhone
            newContact.PhoneNumbers(PhoneNumberKey.MobilePhone) = contactInfo(key)
        Case ContactSchemaProperties.Photo
            Dim picture() As Byte = Convert.FromBase64String(contactInfo(key))
            newContact.SetContactPicture(picture)
        Case Else
    End Select
Next key
</pre>
<pre id="codePreview" class="csharp">
foreach (ContactSchemaProperties key in contactInfo.Keys)
{
    switch (key)
    {
        case ContactSchemaProperties.Surname:
            newContact.Surname = contactInfo[key];
            break;
        case ContactSchemaProperties.GivenName:
            newContact.GivenName = contactInfo[key];
            break;
        case ContactSchemaProperties.DisplayName:
            newContact.DisplayName = contactInfo[key];
            break;
        case ContactSchemaProperties.JobTitle:
            newContact.JobTitle = contactInfo[key];
            break;
        case ContactSchemaProperties.Birthday:
            {
                DateTime birthday;
                newContact.Birthday = DateTime.TryParse(contactInfo[key], out birthday) ? (DateTime?)birthday : null;
            }
            break;
        case ContactSchemaProperties.CompanyName:
            newContact.CompanyName = contactInfo[key];
            break;
        case ContactSchemaProperties.Companies:
            {
                StringList stringList = new StringList();
                stringList.Add(contactInfo[key]);
                newContact.Companies = stringList;
            }
            break;
        case ContactSchemaProperties.Department:
            newContact.Department = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress1:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress1] = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress2:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress2] = contactInfo[key];
            break;
        case ContactSchemaProperties.EmailAddress3:
            newContact.EmailAddresses[EmailAddressKey.EmailAddress3] = contactInfo[key];
            break;
        case ContactSchemaProperties.BusinessAddressStreet:
        case ContactSchemaProperties.BusinessAddressCity:
        case ContactSchemaProperties.BusinessAddressState:
        case ContactSchemaProperties.BusinessAddressPostalCode:
        case ContactSchemaProperties.BusinessAddressCountryOrRegion:
            {
                if (businessAddressEntry == null)
                {
                    businessAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], businessAddressEntry);
            }
            break;
        case ContactSchemaProperties.HomeAddressStreet:
        case ContactSchemaProperties.HomeAddressCity:
        case ContactSchemaProperties.HomeAddressState:
        case ContactSchemaProperties.HomeAddressPostalCode:
        case ContactSchemaProperties.HomeAddressCountryOrRegion:
            {
                if (homeAddressEntry == null)
                {
                    homeAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], homeAddressEntry);
            }
            break;
        case ContactSchemaProperties.OtherAddressStreet:
        case ContactSchemaProperties.OtherAddressCity:
        case ContactSchemaProperties.OtherAddressState:
        case ContactSchemaProperties.OtherAddressPostalCode:
        case ContactSchemaProperties.OtherAddressCountryOrRegion:
            {
                if (otherAddressEntry == null)
                {
                    otherAddressEntry = new PhysicalAddressEntry();
                }
                SetContactDetails.SetAddress(key, contactInfo[key], otherAddressEntry);
            }
            break;
        case ContactSchemaProperties.BusinessPhone:
            newContact.PhoneNumbers[PhoneNumberKey.BusinessPhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.BusinessPhone2:
            newContact.PhoneNumbers[PhoneNumberKey.BusinessPhone2] = contactInfo[key];
            break;
        case ContactSchemaProperties.HomePhone:
            newContact.PhoneNumbers[PhoneNumberKey.HomePhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.HomePhone2:
            newContact.PhoneNumbers[PhoneNumberKey.HomePhone2] = contactInfo[key];
            break;
        case ContactSchemaProperties.MobilePhone:
            newContact.PhoneNumbers[PhoneNumberKey.MobilePhone] = contactInfo[key];
            break;
        case ContactSchemaProperties.Photo:
            {
                Byte[] picture = Convert.FromBase64String(contactInfo[key]);
                newContact.SetContactPicture(picture);
            }
            break;
        default:
            break;
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">At last we&rsquo;ll add the address entry into the contact and save it.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
if (businessAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Business] = businessAddressEntry;
}
if (homeAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Home] = homeAddressEntry;
}
if (otherAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Other] = otherAddressEntry;
}
newContact.FileAsMapping = FileAsMapping.GivenNameSpaceSurname;
newContact.Save(WellKnownFolderName.Contacts);
</pre>
<pre class="hidden">
If businessAddressEntry IsNot Nothing Then
    newContact.PhysicalAddresses(PhysicalAddressKey.Business) = businessAddressEntry
End If
If homeAddressEntry IsNot Nothing Then
    newContact.PhysicalAddresses(PhysicalAddressKey.Home) = homeAddressEntry
End If
If otherAddressEntry IsNot Nothing Then
    newContact.PhysicalAddresses(PhysicalAddressKey.Other) = otherAddressEntry
End If
newContact.FileAsMapping = FileAsMapping.GivenNameSpaceSurname
newContact.Save(WellKnownFolderName.Contacts)
</pre>
<pre id="codePreview" class="csharp">
if (businessAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Business] = businessAddressEntry;
}
if (homeAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Home] = homeAddressEntry;
}
if (otherAddressEntry != null)
{
    newContact.PhysicalAddresses[PhysicalAddressKey.Other] = otherAddressEntry;
}
newContact.FileAsMapping = FileAsMapping.GivenNameSpaceSurname;
newContact.Save(WellKnownFolderName.Contacts);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; color:windowtext"></span><a href="http://msdn.microsoft.com/en-us/library/exchange/microsoft.exchange.webservices.data.contact(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Contact
 class</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
