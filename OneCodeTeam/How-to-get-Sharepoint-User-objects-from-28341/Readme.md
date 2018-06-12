# How to get Sharepoint User objects from AssignedTo field by CSOM
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* SharePoint
* SharePoint 2013
* SharePoint Development
## Topics
* CSOM
* get user
## IsPublished
* True
## ModifiedDate
* 2014-04-24 02:46:50
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to get Share</span><span style="font-weight:bold; font-size:14pt">P</span><span style="font-weight:bold; font-size:14pt">oint User objects from AssignedTo field
 by CSOM</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet will</span><span style="font-size:11pt"> show</span><span style="font-size:11pt"> you how to get SharePoint User objects from AssignedTo field by CSOM.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt"><span style="">&bull;&nbsp;</span><span style="font-size:11pt">Create an instance of ClientContext</span><span style="">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Load web object from the context.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get Task list.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get item from the list.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get the AssignedTo field of the item.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get User object from the AssignedTo field.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
public static User GetUserFromAssignedToField(string siteUrl)
        {
            // create site context
            ClientContext ctx = new ClientContext(siteUrl);
            // create web object
            Web web = ctx.Web;
            ctx.Load(web);
            // get Tasks list
            List list = ctx.Web.Lists.GetByTitle(&quot;CustomTasks&quot;);
            ctx.Load(list);
            // get list item using Id e.g. updating first item in the list
            ListItem targetListItem = list.GetItemById(1);
            // Load only the assigned to field from the list item
            ctx.Load(targetListItem,
                             item =&gt; item[&quot;AssignedTo&quot;]);
            ctx.ExecuteQuery();
            // create and cast the FieldUserValue from the value
            FieldUserValue[] fuv = (FieldUserValue[])targetListItem[&quot;AssignedTo&quot;];
            User user = null;
            for (int i = 0; i &lt; fuv.Length; i&#43;&#43;)
            {
                Console.WriteLine(&quot;Retrieved user Id is: {0}&quot;, fuv[i].LookupId);
                Console.WriteLine(&quot;Retrieved login name is: {0}&quot;, fuv[i].LookupValue);
                user = ctx.Web.EnsureUser(fuv[i].LookupValue);
                ctx.Load(user);
                ctx.ExecuteQuery();
            }
            return user;
        }
</pre>
<pre class="hidden">
Public Shared Function GetUserFromAssignedToField(siteUrl As String) As User
 ' create site context
 Dim ctx As New ClientContext(siteUrl)
 ' create web object
 Dim web As Web = ctx.Web
 ctx.Load(web)
 ' get Tasks list
 Dim list As List = ctx.Web.Lists.GetByTitle(&quot;CustomTasks&quot;)
 ctx.Load(list)
 ' get list item using Id e.g. updating first item in the list
 Dim targetListItem As ListItem = list.GetItemById(1)
 ' Load only the assigned to field from the list item
 ctx.Load(targetListItem, Function(item) item(&quot;AssignedTo&quot;))
 ctx.ExecuteQuery()
 ' create and cast the FieldUserValue from the value
 Dim fuv As FieldUserValue() = DirectCast(targetListItem(&quot;AssignedTo&quot;), FieldUserValue())
 Dim user As User = Nothing
 For i As Integer = 0 To fuv.Length - 1
  Console.WriteLine(&quot;Retrieved user Id is: {0}&quot;, fuv(i).LookupId)
  Console.WriteLine(&quot;Retrieved login name is: {0}&quot;, fuv(i).LookupValue)
  user = ctx.Web.EnsureUser(fuv(i).LookupValue)
  ctx.Load(user)
  ctx.ExecuteQuery()
 Next
 Return user
End Function
</pre>
<pre id="codePreview" class="csharp">
public static User GetUserFromAssignedToField(string siteUrl)
        {
            // create site context
            ClientContext ctx = new ClientContext(siteUrl);
            // create web object
            Web web = ctx.Web;
            ctx.Load(web);
            // get Tasks list
            List list = ctx.Web.Lists.GetByTitle(&quot;CustomTasks&quot;);
            ctx.Load(list);
            // get list item using Id e.g. updating first item in the list
            ListItem targetListItem = list.GetItemById(1);
            // Load only the assigned to field from the list item
            ctx.Load(targetListItem,
                             item =&gt; item[&quot;AssignedTo&quot;]);
            ctx.ExecuteQuery();
            // create and cast the FieldUserValue from the value
            FieldUserValue[] fuv = (FieldUserValue[])targetListItem[&quot;AssignedTo&quot;];
            User user = null;
            for (int i = 0; i &lt; fuv.Length; i&#43;&#43;)
            {
                Console.WriteLine(&quot;Retrieved user Id is: {0}&quot;, fuv[i].LookupId);
                Console.WriteLine(&quot;Retrieved login name is: {0}&quot;, fuv[i].LookupValue);
                user = ctx.Web.EnsureUser(fuv[i].LookupValue);
                ctx.Load(user);
                ctx.ExecuteQuery();
            }
            return user;
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
string strUrl=&quot;http://&quot; &#43; Environment.MachineName;
GetUserFromAssignedToField(strUrl); 
</pre>
<pre class="hidden">
Dim strUrl As String = &quot;http://&quot; &#43; Environment.MachineName
GetUserFromAssignedToField(strUrl)
</pre>
<pre id="codePreview" class="csharp">
string strUrl=&quot;http://&quot; &#43; Environment.MachineName;
GetUserFromAssignedToField(strUrl); 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Note: </span><span style="">The strUrl need</span><span style="">s</span><span style=""> to be replaced with the actual URL.</span><a name="_GoBack"></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ClientContext class</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext(v=office.15).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ListCollection.GetByTitle method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listcollection.getbytitle.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listcollection.getbytitle.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ClientContext methods</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext_methods(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext_methods(v=office.15).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ClientContext.ExecuteQuery method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext.executequery(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.clientcontext.executequery(v=office.15).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">SPWeb.EnsureUser method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spweb.ensureuser(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spweb.ensureuser(v=office.15).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">FieldUserValue class</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.fielduservalue.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.fielduservalue.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">ListItem class</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listitem.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listitem.aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
