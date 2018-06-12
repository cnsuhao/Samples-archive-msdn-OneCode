# How to use SPPageStatusSetter to set SharePoint page status
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* SharePoint
* SharePoint 2013
## Topics
* SPPageStatusSetter
## IsPublished
* True
## ModifiedDate
* 2014-06-23 02:52:48
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to use SPPageStatusSetter to set SharePoint page status</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample demonstrates how to use SPPageStatusSetter to
</span><span style="font-size:11pt">in</span><span style="font-size:11pt">sert page status for SharePoint.
</span><span style="">The sample include</span><span style="">s</span><span style=""> two scenarios</span><span style="">: 1</span><span style="">) add page status for an application page. 2)
</span><span style="">Add</span><span style=""> page status from a list event receiver.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Deploy the demo project.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Suppose we have the following list:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117320/1/image.png" alt="" width="383" height="283" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Click the new item link to add a new item and
</span><span style="">t</span><span style="font-size:11pt">hen you will see the page as shown below</span><span style="font-size:11pt">:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117321/1/image.png" alt="" width="542" height="258" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Select one of the list item and m</span><span style="font-size:11pt">odify it. Then you will</span><span style="font-size:11pt"> see the page
</span><span style="font-size:11pt">as</span><span style="font-size:11pt"> shown below:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117322/1/image.png" alt="" width="575" height="258" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Validation is finished</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Start </span>
<span style="font-weight:bold">Visual Studio</span><span style="font-size:11pt">.&nbsp;
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">On the </span>
<span style="font-weight:bold">File </span><span style="font-size:11pt">menu, click
</span><span style="font-weight:bold">New</span><span style="font-size:11pt">, and then click
</span><span style="font-weight:bold">Project</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">In </span>
<span style="font-size:11pt">the Installed Templates section</span><span style="font-size:11pt"> of
</span><span style="font-size:11pt">the </span><span style="font-weight:bold">New Project
</span><span style="font-size:11pt">dialog box, expand either Visual Basic or Visual C#, expand
</span><span style="font-weight:bold">SharePoint</span><span style="font-size:11pt">, and then click
</span><span style="font-weight:bold">Empty SharePoint Project</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Right-click the project to add the desired folder</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">&quot;</span><span style="font-weight:bold">Add</span><span style="font-size:11pt">&quot; &gt;&gt;&quot;</span><span style="font-weight:bold">SharePoint Layouts Mapped Folder</span><span style="font-size:11pt">&quot;.&nbsp;&nbsp;
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Right-click the &quot;</span><span style="font-weight:bold">Layouts</span><span style="font-size:11pt">&quot; folder then add a new folder named &quot;</span><span style="font-size:11pt"> SharePointSetPageStatus</span><span style="font-size:11pt">&quot;,
 then add a new Page named &quot;Test.aspx&quot;.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">The Test page is used to demo how to add page status to an application page.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Next, we will begin to demo how to add page status from a list event receiver.
</span><span style="font-size:11pt">We realize this purpose</span><span style="font-size:11pt"> through the following actions</span><span style="font-size:11pt">:</span><span style="font-size:11pt"> create a web part with
</span><span style="font-weight:bold">SPPageStatusSetter</span><span style="font-size:11pt"> control</span><span style="font-size:11pt"> in it</span><span style="font-size:11pt">
</span><span style="font-size:11pt">and then add the</span><span style="font-size:11pt"> web part to list view page from an event receiver along with status message</span><span style="font-size:11pt"> dynamically.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Add a web part to the project. In the web part, we will add a
</span><span style="font-weight:bold">SPPageStatusSetter</span><span style="font-size:11pt"> control to it and define a custom Message property. The Message property is used to store the status bar message received from Event Receiver. The code resembles the
 following: </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
[ToolboxItemAttribute(false)]
   public class StatusBarWebPart : WebPart
   {
       SPPageStatusSetter statusBar;
       string strMessage;
       public StatusBarWebPart()
       {
           this.Message = string.Empty;
       }
       [Category(&quot;Custom Properties&quot;)]
       [Browsable(false)]
       public string Message
       {
           get
           {
               return strMessage;
           }
           set
           {
               strMessage = value;
           }
       }
       protected override void CreateChildControls()
       {
           statusBar = new SPPageStatusSetter();
           statusBar.AddStatus(&quot;Action&quot;, Message, SPPageStatusColor.Blue);          
                   
           if (!string.IsNullOrEmpty(Message))
           {
               Controls.Add(statusBar);
           }
       }
       protected override void RenderContents(HtmlTextWriter writer)
       {
           writer.Write(&quot;Status Bar demo&quot;);
           RenderChildren(writer);
       }
   }
</pre>
<pre class="hidden">
&lt;ToolboxItemAttribute(false)&gt; _
Public Class StatusBarWebPart
    Inherits WebPart
    Private statusBar As SPPageStatusSetter
    Private strMessage As String
    Public Sub New()
        Me.Message = String.Empty
    End Sub
    &lt;Category(&quot;Custom Properties&quot;)&gt; _
    &lt;Browsable(False)&gt; _
    Public Property Message() As String
        Get
            Return strMessage
        End Get
        Set(value As String)
            strMessage = value
        End Set
    End Property
    Protected Overrides Sub CreateChildControls()
        statusBar = New SPPageStatusSetter()
        statusBar.AddStatus(&quot;Action&quot;, Message, SPPageStatusColor.Blue)
        If Not String.IsNullOrEmpty(Message) Then
            Controls.Add(statusBar)
        End If
    End Sub
    Protected Overrides Sub RenderContents(writer As HtmlTextWriter)
        writer.Write(&quot;Status Bar demo&quot;)
        RenderChildren(writer)
    End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">
[ToolboxItemAttribute(false)]
   public class StatusBarWebPart : WebPart
   {
       SPPageStatusSetter statusBar;
       string strMessage;
       public StatusBarWebPart()
       {
           this.Message = string.Empty;
       }
       [Category(&quot;Custom Properties&quot;)]
       [Browsable(false)]
       public string Message
       {
           get
           {
               return strMessage;
           }
           set
           {
               strMessage = value;
           }
       }
       protected override void CreateChildControls()
       {
           statusBar = new SPPageStatusSetter();
           statusBar.AddStatus(&quot;Action&quot;, Message, SPPageStatusColor.Blue);          
                   
           if (!string.IsNullOrEmpty(Message))
           {
               Controls.Add(statusBar);
           }
       }
       protected override void RenderContents(HtmlTextWriter writer)
       {
           writer.Write(&quot;Status Bar demo&quot;);
           RenderChildren(writer);
       }
   }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Add an event receiver to the project. For demo purpose, we will handle
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">list item&rsquo;s ItemAdded event and ItemUpdated event. Create an instance of the web part, then we will set custom status bar message to the Message property and then add (or update)
 the web part to the list page. </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
/// &lt;summary&gt;
   /// List Item Events.
   /// &lt;/summary&gt;
   public class PageStatusEventReceiver : SPItemEventReceiver
   {
       StatusBarWebPart.StatusBarWebPart statusBarWebPart;
       /// &lt;summary&gt;
       /// An item was added.
       /// &lt;/summary&gt;
       public override void ItemAdded(SPItemEventProperties properties)
       {
           base.ItemAdded(properties);
           SPWeb web = properties.Web;
           string oUrl = properties.List.DefaultViewUrl;
           Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
           if (coll.WebParts.Count &gt; 1)
           {
               statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
               if (statusBarWebPart != null)
               {
                   statusBarWebPart.Message = &quot;Item Added&quot;;
                   coll.SaveChanges(statusBarWebPart);               
               }
           }
           else
           {
               statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
               statusBarWebPart.Message = &quot;Item Added&quot;;
               statusBarWebPart.Hidden = true;
               coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1); 
               coll.SaveChanges(statusBarWebPart);
           }           
       }
      
       /// &lt;summary&gt;
       /// An item was updated.
       /// &lt;/summary&gt;
       public override void ItemUpdated(SPItemEventProperties properties)
       {
           base.ItemUpdated(properties);
           SPWeb web = properties.Web;
           string oUrl = properties.List.DefaultViewUrl;
           Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
           if (coll.WebParts.Count &gt; 1)
           {
               statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
               if (statusBarWebPart != null)
               {
                   statusBarWebPart.Message = &quot;Item Updated&quot;;
                   coll.SaveChanges(statusBarWebPart);               
               }
           }
           else
           {
               statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
               statusBarWebPart.Message = &quot;Item Updated&quot;;
               statusBarWebPart.Hidden = true;
               coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1);
               coll.SaveChanges(statusBarWebPart);            
           }           
       }
   }
</pre>
<pre class="hidden">
Public Class PageStatusEventReceiver
    Inherits SPItemEventReceiver
    Private statusBarWebPart As StatusBarWebPart
    ''' &lt;summary&gt;
    ''' An item was added.
    ''' &lt;/summary&gt;
    Public Overrides Sub ItemAdded(properties As SPItemEventProperties)
        MyBase.ItemAdded(properties)
        Dim web As SPWeb = properties.Web
        Dim oUrl As String = properties.List.DefaultViewUrl
        Dim coll As Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.[Shared])
        If coll.WebParts.Count &gt; 1 Then
            statusBarWebPart = DirectCast(coll.WebParts(1), StatusBarWebPart)
            If statusBarWebPart IsNot Nothing Then
                statusBarWebPart.Message = &quot;Item Added-vb&quot;
                coll.SaveChanges(statusBarWebPart)
            End If
        Else
            statusBarWebPart = New StatusBarWebPart()
            statusBarWebPart.Message = &quot;Item Added-vb&quot;
            statusBarWebPart.Hidden = True
            coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1)
            coll.SaveChanges(statusBarWebPart)
        End If
    End Sub
    ''' &lt;summary&gt;
    ''' An item was updated.
    ''' &lt;/summary&gt;
    Public Overrides Sub ItemUpdated(properties As SPItemEventProperties)
        MyBase.ItemUpdated(properties)
        Dim web As SPWeb = properties.Web
        Dim oUrl As String = properties.List.DefaultViewUrl
        Dim coll As Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.[Shared])
        If coll.WebParts.Count &gt; 1 Then
            statusBarWebPart = DirectCast(coll.WebParts(1), StatusBarWebPart)
            If statusBarWebPart IsNot Nothing Then
                statusBarWebPart.Message = &quot;Item Updated-vb&quot;
                coll.SaveChanges(statusBarWebPart)
            End If
        Else
            statusBarWebPart = New StatusBarWebPart()
            statusBarWebPart.Message = &quot;Item Updated-vb&quot;
            statusBarWebPart.Hidden = True
            coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1)
            coll.SaveChanges(statusBarWebPart)
        End If
    End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
   /// List Item Events.
   /// &lt;/summary&gt;
   public class PageStatusEventReceiver : SPItemEventReceiver
   {
       StatusBarWebPart.StatusBarWebPart statusBarWebPart;
       /// &lt;summary&gt;
       /// An item was added.
       /// &lt;/summary&gt;
       public override void ItemAdded(SPItemEventProperties properties)
       {
           base.ItemAdded(properties);
           SPWeb web = properties.Web;
           string oUrl = properties.List.DefaultViewUrl;
           Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
           if (coll.WebParts.Count &gt; 1)
           {
               statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
               if (statusBarWebPart != null)
               {
                   statusBarWebPart.Message = &quot;Item Added&quot;;
                   coll.SaveChanges(statusBarWebPart);               
               }
           }
           else
           {
               statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
               statusBarWebPart.Message = &quot;Item Added&quot;;
               statusBarWebPart.Hidden = true;
               coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1); 
               coll.SaveChanges(statusBarWebPart);
           }           
       }
      
       /// &lt;summary&gt;
       /// An item was updated.
       /// &lt;/summary&gt;
       public override void ItemUpdated(SPItemEventProperties properties)
       {
           base.ItemUpdated(properties);
           SPWeb web = properties.Web;
           string oUrl = properties.List.DefaultViewUrl;
           Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
           if (coll.WebParts.Count &gt; 1)
           {
               statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
               if (statusBarWebPart != null)
               {
                   statusBarWebPart.Message = &quot;Item Updated&quot;;
                   coll.SaveChanges(statusBarWebPart);               
               }
           }
           else
           {
               statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
               statusBarWebPart.Message = &quot;Item Updated&quot;;
               statusBarWebPart.Hidden = true;
               coll.AddWebPart(statusBarWebPart, &quot;Left&quot;, 1);
               coll.SaveChanges(statusBarWebPart);            
           }           
       }
   }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt"></span><span style="font-size:11pt">Now y</span><a name="_GoBack"></a><span style="font-size:11pt">ou can build and debug it.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">SPPageStatusSetter class</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.webcontrols.sppagestatussetter(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.webcontrols.sppagestatussetter(v=office.15).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">SPLimitedWebPartManager class</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.webpartpages.splimitedwebpartmanager(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.webpartpages.splimitedwebpartmanager(v=office.15).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">SPItemEventReceiver class</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spitemeventreceiver(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spitemeventreceiver(v=office.15).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">Using SPPageStatusSetter to Show Status SharePoint 2010</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://www.learningsharepoint.com/2010/10/03/using-sppagestatussetter-to-show-status-sharepoint-2010/" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://www.learningsharepoint.com/2010/10/03/using-sppagestatussetter-to-show-status-sharepoint-2010/</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><br clear="all">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
