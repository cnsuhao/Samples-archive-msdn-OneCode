# Windows Phone 7 Live Whiteboard (CSWP7LivePainter)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Phone 7
* Windows Phone 7.5
## Topics
* Windows Phone 7
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:52:23
## Description

<h1>Windows Phone 7 Sample: CSWP7LivePainter &amp; CSASPNETWP7LivePainterServer</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample, demo a real live white board for windows phone 7, includes two parts: Windows Phone part and ASP.NET server part.</p>
<p class="MsoNormal">Server part(CSASPNETWP7LivePainterServer): there will be 3 httphandlers. Register handler will keep listening the coming phone request and register the online phone; Remove handler will remove phone from the server; Relay handler will
 receive the whiteboard points info and send to target phones by Notification service.</p>
<p class="MsoNormal">Windows Phone part(CSWP7LivePainter): When app start, Windows Phone will send a http request to tell server this is an online phone. When drawing is done (lose mouse focus event). Windows Phone will send the points info to server. At
 the same time, when any points info comes from server (notification push). Lines will be drawn in Inkpresenter control.</p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Building the Sample
</span></strong></p>
<p class="MsoNormal">Prerequisite: <br>
Visual Studio 2010 with Windows phone SDK 7.1. You can get start by checking this link:
<br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the CSWP7LivePainter solution in Visual Studio 2010<br>
2. Deploy CSASPNETWP7LivePainterServer project. This is just an ASP.NET site. you can deploy it into IIS7, or just right click the Default.aspx page and click ��View In Browser�� to initialize a ASP.NET local server.
<br>
3. Run CSWP7LivePainter Project. Input the server address and press ��OK�� button:</p>
<p class="MsoNormal"><span><img src="/site/view/file/57880/1/image.png" alt="" width="326" height="54" align="middle">
</span></p>
<p class="MsoNormal">4. If you deploy asp.net server correctly, you will see two dialogs, one shows the notification channel uri</p>
<p class="MsoNormal"><span><img src="/site/view/file/57881/1/image.png" alt="" width="349" height="256" align="middle">
</span></p>
<p class="MsoNormal">And device registration status</p>
<p class="MsoNormal"><span><img src="/site/view/file/57882/1/image.png" alt="" width="312" height="99" align="middle">
</span></p>
<p class="MsoNormal">5. Draw something in the first while panel.</p>
<p class="MsoNormal"><span><img src="/site/view/file/57883/1/image.png" alt="" width="380" height="707" align="middle">
</span></p>
<p class="MsoNormal">6. If you have another phone or phone simulate, you can also input the same server address and the two phones can passing the strokes around. It is live white board.</p>
<h2>Using the Code</h2>
<h3>Part 1 Build the server side</h3>
<p class="MsoNormal">1. Create a new ASP.NET project<br>
2. Create three httpHandlers</p>
<p class="MsoNormal">SubScribePhone.cs</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;




public class SubscribePhone :IHttpHandler,IRequiresSessionState {


    public bool IsReusable {
        get { return true; }
    }


    public void ProcessRequest(HttpContext context) {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channelsDict is existed.
        if (context.Application[&quot;channelsDict&quot;] == null) {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict =context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid,Uri&gt;;


        //Get post parameters
        if (context.Request.Form.Count &lt;= 0) {
            context.Response.StatusCode = 400;//bad request
            return;
        }


        NameValueCollection items = context.Request.Form;


        string guidString = items[&quot;id&quot;].ToString();
        Guid id = new Guid(guidString);
        string channelUri = items[&quot;channelUri&quot;].ToString();


        //Add channelUri to server devices dictionary.so that Relay handle
        //can send stroke info back to this device. 
        channelsDict.Add(id,new Uri(channelUri));
        context.Application[&quot;channelsDict&quot;] = channelsDict;
    }
}

</pre>
<pre id="codePreview" class="csharp">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;




public class SubscribePhone :IHttpHandler,IRequiresSessionState {


    public bool IsReusable {
        get { return true; }
    }


    public void ProcessRequest(HttpContext context) {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channelsDict is existed.
        if (context.Application[&quot;channelsDict&quot;] == null) {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict =context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid,Uri&gt;;


        //Get post parameters
        if (context.Request.Form.Count &lt;= 0) {
            context.Response.StatusCode = 400;//bad request
            return;
        }


        NameValueCollection items = context.Request.Form;


        string guidString = items[&quot;id&quot;].ToString();
        Guid id = new Guid(guidString);
        string channelUri = items[&quot;channelUri&quot;].ToString();


        //Add channelUri to server devices dictionary.so that Relay handle
        //can send stroke info back to this device. 
        channelsDict.Add(id,new Uri(channelUri));
        context.Application[&quot;channelsDict&quot;] = channelsDict;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Relay.cs</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;


/// &lt;summary&gt;
/// The class functions as stroke relay,receive troke info and broadcast 
/// stroke info to all other registered devices.
/// &lt;/summary&gt;
public class Relay : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }
    
    /// &lt;summary&gt;
    /// Handle the relay http request. 
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
    public void ProcessRequest(HttpContext context)
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channels dictionlary object is existed.
        if (context.Application[&quot;channelsDict&quot;] == null)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict = context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid, Uri&gt;;


        //Get http post parameters.
        if (context.Request.Form.Count &lt;= 0)
        {
            context.Response.StatusCode = 400;//bad request
            return;
        }


        NameValueCollection items = context.Request.Form;


        string senderId = items[&quot;id&quot;].ToString();
        string strokeString = items[&quot;strokeString&quot;].ToString();


        if (channelsDict.Count == 0) return;


        //Broadcast stroke info to all other devices.
        var keys = channelsDict.Keys;
        foreach (var key in keys)
        {
            SendStringToDevice(channelsDict[key], strokeString);
        }
    }


    /// &lt;summary&gt;
    /// This method will actually send stroke information back to deives.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;deviceUri&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;content&quot;&gt;&lt;/param&gt;
    private void SendStringToDevice(Uri deviceUri,string content)
    {
        int contentLength = content.Length;
        HttpWebRequest sendNotificationRequest=(HttpWebRequest)WebRequest.Create(deviceUri);
        sendNotificationRequest.Method = &quot;POST&quot;;
        System.Text.UTF8Encoding encoder = new UTF8Encoding();
        byte[] notificationMessage = encoder.GetBytes(content);


        sendNotificationRequest.ContentLength = notificationMessage.Length;
        sendNotificationRequest.ContentType = &quot;text/plain&quot;;
        sendNotificationRequest.Headers.Add(&quot;X-NotificationClass&quot;, &quot;3&quot;);


        using (Stream requestStream = sendNotificationRequest.GetRequestStream())
        {
            requestStream.Write(notificationMessage, 0, notificationMessage.Length);
        }
        
        sendNotificationRequest.GetResponse();
    }
}

</pre>
<pre id="codePreview" class="csharp">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;


/// &lt;summary&gt;
/// The class functions as stroke relay,receive troke info and broadcast 
/// stroke info to all other registered devices.
/// &lt;/summary&gt;
public class Relay : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }
    
    /// &lt;summary&gt;
    /// Handle the relay http request. 
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
    public void ProcessRequest(HttpContext context)
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channels dictionlary object is existed.
        if (context.Application[&quot;channelsDict&quot;] == null)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict = context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid, Uri&gt;;


        //Get http post parameters.
        if (context.Request.Form.Count &lt;= 0)
        {
            context.Response.StatusCode = 400;//bad request
            return;
        }


        NameValueCollection items = context.Request.Form;


        string senderId = items[&quot;id&quot;].ToString();
        string strokeString = items[&quot;strokeString&quot;].ToString();


        if (channelsDict.Count == 0) return;


        //Broadcast stroke info to all other devices.
        var keys = channelsDict.Keys;
        foreach (var key in keys)
        {
            SendStringToDevice(channelsDict[key], strokeString);
        }
    }


    /// &lt;summary&gt;
    /// This method will actually send stroke information back to deives.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;deviceUri&quot;&gt;&lt;/param&gt;
    /// &lt;param name=&quot;content&quot;&gt;&lt;/param&gt;
    private void SendStringToDevice(Uri deviceUri,string content)
    {
        int contentLength = content.Length;
        HttpWebRequest sendNotificationRequest=(HttpWebRequest)WebRequest.Create(deviceUri);
        sendNotificationRequest.Method = &quot;POST&quot;;
        System.Text.UTF8Encoding encoder = new UTF8Encoding();
        byte[] notificationMessage = encoder.GetBytes(content);


        sendNotificationRequest.ContentLength = notificationMessage.Length;
        sendNotificationRequest.ContentType = &quot;text/plain&quot;;
        sendNotificationRequest.Headers.Add(&quot;X-NotificationClass&quot;, &quot;3&quot;);


        using (Stream requestStream = sendNotificationRequest.GetRequestStream())
        {
            requestStream.Write(notificationMessage, 0, notificationMessage.Length);
        }
        
        sendNotificationRequest.GetResponse();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
UnregisterPhone.cs</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;


public class UnregisterPhone : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }


    public void ProcessRequest(HttpContext context)
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channelsDict is existed.
        if (context.Application[&quot;channelsDict&quot;] == null)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict = context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid, Uri&gt;;


        //Get post parameters
        if (context.Request.Form.Count &lt;= 0)
        {
            context.Response.StatusCode = 400;//bad request
            //context.Response.Write(&quot;no parameter&quot;);
            return;
        }


        NameValueCollection items = context.Request.Form;


        string guidString = items[&quot;id&quot;].ToString();
        Guid id = new Guid(guidString);


        //Remove the closed device channel uri from the channels dictionary
        //so that Relay handle will no long broadcast stroke to this device.
        channelsDict.Remove(id);
        context.Application[&quot;channelsDict&quot;] = channelsDict;
    }
}

</pre>
<pre id="codePreview" class="csharp">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;


public class UnregisterPhone : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }


    public void ProcessRequest(HttpContext context)
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        //Make sure that channelsDict is existed.
        if (context.Application[&quot;channelsDict&quot;] == null)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            context.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
        channelsDict = context.Application[&quot;channelsDict&quot;] as Dictionary&lt;Guid, Uri&gt;;


        //Get post parameters
        if (context.Request.Form.Count &lt;= 0)
        {
            context.Response.StatusCode = 400;//bad request
            //context.Response.Write(&quot;no parameter&quot;);
            return;
        }


        NameValueCollection items = context.Request.Form;


        string guidString = items[&quot;id&quot;].ToString();
        Guid id = new Guid(guidString);


        //Remove the closed device channel uri from the channels dictionary
        //so that Relay handle will no long broadcast stroke to this device.
        channelsDict.Remove(id);
        context.Application[&quot;channelsDict&quot;] = channelsDict;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
3. Create a channels dictionary in Global.acax file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public class Global : System.Web.HttpApplication
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        void Application_Start(object sender, EventArgs e)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            this.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
    }

</pre>
<pre id="codePreview" class="csharp">    public class Global : System.Web.HttpApplication
    {
        Dictionary&lt;Guid, Uri&gt; channelsDict = null;
        void Application_Start(object sender, EventArgs e)
        {
            channelsDict = new Dictionary&lt;Guid, Uri&gt;();
            this.Application.Add(&quot;channelsDict&quot;, channelsDict);
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
4. Add http handlers to Web.config file</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.webServer&gt;
   &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot;/&gt;
   &lt;handlers&gt;
      &lt;add name=&quot;SubscribePhoneHandler&quot; verb=&quot;*&quot; path=&quot;AddPhone.srv&quot; type=&quot;SubscribePhone&quot;/&gt;
      &lt;add name=&quot;RemovePhoneHandler&quot; verb=&quot;*&quot; path=&quot;RemovePhone.srv&quot; type=&quot;UnregisterPhone&quot;/&gt;
      &lt;add name=&quot;RelayHandler&quot; verb=&quot;*&quot; path=&quot;Relay.srv&quot; type=&quot;Relay&quot;/&gt;
   &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
<pre id="codePreview" class="xml">&lt;system.webServer&gt;
   &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot;/&gt;
   &lt;handlers&gt;
      &lt;add name=&quot;SubscribePhoneHandler&quot; verb=&quot;*&quot; path=&quot;AddPhone.srv&quot; type=&quot;SubscribePhone&quot;/&gt;
      &lt;add name=&quot;RemovePhoneHandler&quot; verb=&quot;*&quot; path=&quot;RemovePhone.srv&quot; type=&quot;UnregisterPhone&quot;/&gt;
      &lt;add name=&quot;RelayHandler&quot; verb=&quot;*&quot; path=&quot;Relay.srv&quot; type=&quot;Relay&quot;/&gt;
   &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Please note that if you run the asp.net site in Local Development Server, you also need add handlers under &lt;system.web&gt;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;/system.web&gt;   
  &lt;httpHandlers&gt;
    &lt;add  verb=&quot;*&quot; path=&quot;AddPhone.srv&quot; type=&quot;SubscribePhone&quot;/&gt;
    &lt;add  verb=&quot;*&quot; path=&quot;RemovePhone.srv&quot; type=&quot;UnregisterPhone&quot;/&gt;
    &lt;add verb=&quot;*&quot; path=&quot;Relay.srv&quot; type=&quot;Relay&quot;/&gt;
  &lt;/httpHandlers&gt;
&lt;/system.web&gt;

</pre>
<pre id="codePreview" class="xml">&lt;/system.web&gt;   
  &lt;httpHandlers&gt;
    &lt;add  verb=&quot;*&quot; path=&quot;AddPhone.srv&quot; type=&quot;SubscribePhone&quot;/&gt;
    &lt;add  verb=&quot;*&quot; path=&quot;RemovePhone.srv&quot; type=&quot;UnregisterPhone&quot;/&gt;
    &lt;add verb=&quot;*&quot; path=&quot;Relay.srv&quot; type=&quot;Relay&quot;/&gt;
  &lt;/httpHandlers&gt;
&lt;/system.web&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h3>Part 2. Windows Phone side</h3>
<p class="MsoNormal">1. Create a Windows Phone project. <br>
2. Open MainPage.xaml file and change the Grid xaml as following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;TextBox x:Name=&quot;txtBox_ServerAddress&quot; Text=&quot;http://localhost:8080/&quot;
             Margin=&quot;0,0,60,700&quot; &gt;&lt;/TextBox&gt;
    &lt;Button x:Name=&quot;btn_ServerOk&quot; Margin=&quot;400,0,0,700&quot; Content=&quot;ok&quot; Click=&quot;btn_ServerOk_Click&quot;&gt;&lt;/Button&gt;
    &lt;InkPresenter Background=&quot;White&quot; Margin=&quot;0,60,0,400&quot; 
               Name=&quot;MyIP&quot;
               MouseLeftButtonDown=&quot;MyIP_MouseLeftButtonDown&quot; 
               MouseMove=&quot;MyIP_MouseMove&quot; 
               LostMouseCapture=&quot;MyIP_LostMouseCapture&quot; /&gt;
    &lt;InkPresenter Background=&quot;White&quot; Margin=&quot;0,400,0,0&quot; 
               Name=&quot;MyIPtest&quot;
               MouseLeftButtonDown=&quot;MyIP_MouseLeftButtonDown&quot; 
               MouseMove=&quot;MyIP_MouseMove&quot;
               LostMouseCapture=&quot;MyIP_LostMouseCapture&quot; /&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;TextBox x:Name=&quot;txtBox_ServerAddress&quot; Text=&quot;http://localhost:8080/&quot;
             Margin=&quot;0,0,60,700&quot; &gt;&lt;/TextBox&gt;
    &lt;Button x:Name=&quot;btn_ServerOk&quot; Margin=&quot;400,0,0,700&quot; Content=&quot;ok&quot; Click=&quot;btn_ServerOk_Click&quot;&gt;&lt;/Button&gt;
    &lt;InkPresenter Background=&quot;White&quot; Margin=&quot;0,60,0,400&quot; 
               Name=&quot;MyIP&quot;
               MouseLeftButtonDown=&quot;MyIP_MouseLeftButtonDown&quot; 
               MouseMove=&quot;MyIP_MouseMove&quot; 
               LostMouseCapture=&quot;MyIP_LostMouseCapture&quot; /&gt;
    &lt;InkPresenter Background=&quot;White&quot; Margin=&quot;0,400,0,0&quot; 
               Name=&quot;MyIPtest&quot;
               MouseLeftButtonDown=&quot;MyIP_MouseLeftButtonDown&quot; 
               MouseMove=&quot;MyIP_MouseMove&quot;
               LostMouseCapture=&quot;MyIP_LostMouseCapture&quot; /&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Open MainPage.xaml.cs file and fill the file with the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
using System.IO;
using System.Windows.Ink;
using System.Text;


namespace CSWP7LivePainter
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpNotificationChannel pushChannel;
        string channelName = &quot;LivePainterChannel&quot;;
        Guid id = new Guid();
        string serverHost = &quot;&quot;;
        public MainPage()
        {
            InitializeComponent();
            id = Guid.NewGuid();
        }


        /// &lt;summary&gt;
        /// This method will get the Notification Channel URI.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private HttpNotificationChannel GetPushChannel()
        {
            HttpNotificationChannel pushChannel = HttpNotificationChannel.Find(channelName);
            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);


                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated &#43;=
                    new EventHandler&lt;NotificationChannelUriEventArgs&gt;(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred &#43;=
                    new EventHandler&lt;NotificationChannelErrorEventArgs&gt;(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived &#43;=
                    new EventHandler&lt;HttpNotificationEventArgs&gt;(PushChannel_HttpNotificationReceived);


                pushChannel.Open();
            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated &#43;=
                    new EventHandler&lt;NotificationChannelUriEventArgs&gt;(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred &#43;=
                    new EventHandler&lt;NotificationChannelErrorEventArgs&gt;(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived &#43;=
                    new EventHandler&lt;HttpNotificationEventArgs&gt;(PushChannel_HttpNotificationReceived);


                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(pushChannel.ChannelUri.ToString());


                MessageBox.Show(String.Format(&quot;Channel Uri remains {0}&quot;,
                                pushChannel.ChannelUri.ToString()));
            }


            return pushChannel;
        }


        /// &lt;summary&gt;
        /// Send http request to tell server that I am online and register 
        /// this device to server. 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Device id&lt;/param&gt;
        /// &lt;param name=&quot;uri&quot;&gt;Notification channel URI&lt;/param&gt;
        void RegisterDevice(Guid id, Uri uri)
        {
            string serviceURL = serverHost&#43;&quot;AddPhone.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString() &#43; &quot;&amp;channelUri=&quot; &#43; uri.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
            webClient.UploadStringCompleted &#43;=
                new UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
        }


        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt; MessageBox.Show(&quot;upload device info done&quot;));
        }


        /// &lt;summary&gt;
        /// Tell server that this app is closed and unregister from server. 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Device id.&lt;/param&gt;
        void UnRegisterPhone(Guid id)
        {
            string serviceURL = serverHost &#43; &quot;RemovePhone.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
        }


        /// &lt;summary&gt;
        /// This event will raise when channel uri is updated. 
        /// &lt;/summary&gt;
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt;
            {
                RegisterDevice(id, e.ChannelUri);
                MessageBox.Show(String.Format(&quot;Channel Uri updated {0}&quot;, e.ChannelUri.ToString()));
            });
        }


        /// &lt;summary&gt;
        /// Event handler for push notification errors.
        /// &lt;/summary&gt;
        void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            Dispatcher.BeginInvoke(() =&gt;
                MessageBox.Show(String.Format(&quot;A push notification {0} error occurred.  {1} ({2}) {3}&quot;,
                                              e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData)));
        }


        /// &lt;summary&gt;
        /// Event handler for when a raw notification arrives.  For this sample, the raw 
        /// data is simply displayed in a MessageBox.
        /// &lt;/summary&gt;
        void PushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt;
            {
                Stream bodyStream = e.Notification.Body;
                Stroke stroke = GetStroke(bodyStream);
                this.MyIPtest.Strokes.Add(stroke);
            });
        }


        /// &lt;summary&gt;
        /// This method will deal with the raw stroke info from server. 
        /// First read bytes from a UTF8 stream. then extract the points array
        /// from bytes array. and final turns to be a Stroke object that 
        /// can be showed in InkPresenter. 
        /// &lt;/summary&gt;
        private Stroke GetStroke(Stream strokeStream)
        {
            BinaryReader br = new BinaryReader(strokeStream);
            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            byte[] strokeBytes = br.ReadBytes((int)strokeStream.Length);
            string strokeString = encoder.GetString(strokeBytes, 0, strokeBytes.Length);


            double[] strokeArray = StringToDoubleArray(strokeString);
            int arrayLength = strokeArray.Length;
            Stroke stroke = new Stroke();
            StylusPoint sp;
            for (int i = 0; i &lt; arrayLength; i = i &#43; 2)
            {
                sp = new StylusPoint();
                sp.X = strokeArray[i];
                sp.Y = strokeArray[i &#43; 1];
                stroke.StylusPoints.Add(sp);
            }
            return stroke;
        }


        Stroke newStroke;
        /// &lt;summary&gt;
        /// When mouse capture lost, call the SendPointsInfo to server. 
        /// &lt;/summary&gt;
        public void MyIP_LostMouseCapture(object sender, MouseEventArgs e)
        {
            this.MyIP.ReleaseMouseCapture();
            if (newStroke == null)
            {
                return;
            }


            SendPointsInfo();
            newStroke = null;
        }


        /// &lt;summary&gt;
        /// The method will do the real send jobs. first, get the points info
        /// and construct these position as a array.We can also serialize
        /// these info as xml string. but passing Array around will save space 
        /// and time. 
        /// &lt;/summary&gt;
        private void SendPointsInfo()
        {
            var points = newStroke.StylusPoints;
            double[] strokArray = new double[points.Count * 2];
            int i = 0;
            foreach (var point in points)
            {
                strokArray[i] = point.X;
                i&#43;&#43;;
                strokArray[i] = point.Y;
                i&#43;&#43;;
            }


            string strokeString = DoubleArrayToString(strokArray);


            string serviceURL = serverHost &#43; &quot;Relay.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString() &#43; &quot;&amp;strokeString=&quot; &#43; strokeString;
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
        }


        /// &lt;summary&gt;
        /// Change the points array to a string, a points string seperated by
        /// comma. for exampe:[10,11,12,13] will be transfered to 
        /// &quot;10,11,12,13,&quot;
        /// &lt;/summary&gt;
        private string DoubleArrayToString(double[] doubleArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i &lt; doubleArray.Length; i&#43;&#43;)
            {
                sb.Append(doubleArray[i].ToString());
                sb.Append(&quot;,&quot;);
            }
            return sb.ToString();
        }


        /// &lt;summary&gt;
        /// This method funcation extract points array from a points string. 
        /// please do a comparation with DoubleArrayToString method. 
        /// &lt;/summary&gt;
        private double[] StringToDoubleArray(string strokeString)
        {
            string[] stringArray = strokeString.Split(',');
            double[] strokeArray = new double[stringArray.Length - 1];
            for (int i = 0; i &lt; strokeArray.Length; i&#43;&#43;)
            {
                strokeArray[i] = Double.Parse(stringArray[i]);
            }
            return strokeArray;
        }


        /// &lt;summary&gt;
        /// This method capture mouse down event and initialize related objects. 
        /// &lt;/summary&gt;
        private void MyIP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyIP.CaptureMouse();
            StylusPointCollection myStylusPointCollection = new StylusPointCollection();
            myStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(MyIP));
            newStroke = new Stroke(myStylusPointCollection);
            newStroke.DrawingAttributes.Color = Colors.Blue;
            MyIP.Strokes.Add(newStroke);
        }


        /// &lt;summary&gt;
        /// Add stroke info into shared stroke object(newStroke).
        /// &lt;/summary&gt;
        private void MyIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (newStroke != null)
            {
                newStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(MyIP));
            }
        }


        /// &lt;summary&gt;
        /// Unregister the device when user turn away from this page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            //delete deveice info from server
            UnRegisterPhone(id);
        }


        private void btn_ServerOk_Click(object sender, RoutedEventArgs e)
        {
            serverHost = txtBox_ServerAddress.Text;
            pushChannel = this.GetPushChannel();
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
using System.IO;
using System.Windows.Ink;
using System.Text;


namespace CSWP7LivePainter
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpNotificationChannel pushChannel;
        string channelName = &quot;LivePainterChannel&quot;;
        Guid id = new Guid();
        string serverHost = &quot;&quot;;
        public MainPage()
        {
            InitializeComponent();
            id = Guid.NewGuid();
        }


        /// &lt;summary&gt;
        /// This method will get the Notification Channel URI.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private HttpNotificationChannel GetPushChannel()
        {
            HttpNotificationChannel pushChannel = HttpNotificationChannel.Find(channelName);
            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);


                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated &#43;=
                    new EventHandler&lt;NotificationChannelUriEventArgs&gt;(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred &#43;=
                    new EventHandler&lt;NotificationChannelErrorEventArgs&gt;(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived &#43;=
                    new EventHandler&lt;HttpNotificationEventArgs&gt;(PushChannel_HttpNotificationReceived);


                pushChannel.Open();
            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated &#43;=
                    new EventHandler&lt;NotificationChannelUriEventArgs&gt;(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred &#43;=
                    new EventHandler&lt;NotificationChannelErrorEventArgs&gt;(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived &#43;=
                    new EventHandler&lt;HttpNotificationEventArgs&gt;(PushChannel_HttpNotificationReceived);


                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(pushChannel.ChannelUri.ToString());


                MessageBox.Show(String.Format(&quot;Channel Uri remains {0}&quot;,
                                pushChannel.ChannelUri.ToString()));
            }


            return pushChannel;
        }


        /// &lt;summary&gt;
        /// Send http request to tell server that I am online and register 
        /// this device to server. 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Device id&lt;/param&gt;
        /// &lt;param name=&quot;uri&quot;&gt;Notification channel URI&lt;/param&gt;
        void RegisterDevice(Guid id, Uri uri)
        {
            string serviceURL = serverHost&#43;&quot;AddPhone.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString() &#43; &quot;&amp;channelUri=&quot; &#43; uri.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
            webClient.UploadStringCompleted &#43;=
                new UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
        }


        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt; MessageBox.Show(&quot;upload device info done&quot;));
        }


        /// &lt;summary&gt;
        /// Tell server that this app is closed and unregister from server. 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Device id.&lt;/param&gt;
        void UnRegisterPhone(Guid id)
        {
            string serviceURL = serverHost &#43; &quot;RemovePhone.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
        }


        /// &lt;summary&gt;
        /// This event will raise when channel uri is updated. 
        /// &lt;/summary&gt;
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt;
            {
                RegisterDevice(id, e.ChannelUri);
                MessageBox.Show(String.Format(&quot;Channel Uri updated {0}&quot;, e.ChannelUri.ToString()));
            });
        }


        /// &lt;summary&gt;
        /// Event handler for push notification errors.
        /// &lt;/summary&gt;
        void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            Dispatcher.BeginInvoke(() =&gt;
                MessageBox.Show(String.Format(&quot;A push notification {0} error occurred.  {1} ({2}) {3}&quot;,
                                              e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData)));
        }


        /// &lt;summary&gt;
        /// Event handler for when a raw notification arrives.  For this sample, the raw 
        /// data is simply displayed in a MessageBox.
        /// &lt;/summary&gt;
        void PushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(() =&gt;
            {
                Stream bodyStream = e.Notification.Body;
                Stroke stroke = GetStroke(bodyStream);
                this.MyIPtest.Strokes.Add(stroke);
            });
        }


        /// &lt;summary&gt;
        /// This method will deal with the raw stroke info from server. 
        /// First read bytes from a UTF8 stream. then extract the points array
        /// from bytes array. and final turns to be a Stroke object that 
        /// can be showed in InkPresenter. 
        /// &lt;/summary&gt;
        private Stroke GetStroke(Stream strokeStream)
        {
            BinaryReader br = new BinaryReader(strokeStream);
            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            byte[] strokeBytes = br.ReadBytes((int)strokeStream.Length);
            string strokeString = encoder.GetString(strokeBytes, 0, strokeBytes.Length);


            double[] strokeArray = StringToDoubleArray(strokeString);
            int arrayLength = strokeArray.Length;
            Stroke stroke = new Stroke();
            StylusPoint sp;
            for (int i = 0; i &lt; arrayLength; i = i &#43; 2)
            {
                sp = new StylusPoint();
                sp.X = strokeArray[i];
                sp.Y = strokeArray[i &#43; 1];
                stroke.StylusPoints.Add(sp);
            }
            return stroke;
        }


        Stroke newStroke;
        /// &lt;summary&gt;
        /// When mouse capture lost, call the SendPointsInfo to server. 
        /// &lt;/summary&gt;
        public void MyIP_LostMouseCapture(object sender, MouseEventArgs e)
        {
            this.MyIP.ReleaseMouseCapture();
            if (newStroke == null)
            {
                return;
            }


            SendPointsInfo();
            newStroke = null;
        }


        /// &lt;summary&gt;
        /// The method will do the real send jobs. first, get the points info
        /// and construct these position as a array.We can also serialize
        /// these info as xml string. but passing Array around will save space 
        /// and time. 
        /// &lt;/summary&gt;
        private void SendPointsInfo()
        {
            var points = newStroke.StylusPoints;
            double[] strokArray = new double[points.Count * 2];
            int i = 0;
            foreach (var point in points)
            {
                strokArray[i] = point.X;
                i&#43;&#43;;
                strokArray[i] = point.Y;
                i&#43;&#43;;
            }


            string strokeString = DoubleArrayToString(strokArray);


            string serviceURL = serverHost &#43; &quot;Relay.srv&quot;;
            string postData = &quot;id=&quot; &#43; id.ToString() &#43; &quot;&amp;strokeString=&quot; &#43; strokeString;
            WebClient webClient = new WebClient();
            webClient.Headers[&quot;Content-type&quot;] = &quot;application/x-www-form-urlencoded&quot;;
            webClient.UploadStringAsync(new Uri(serviceURL), &quot;POST&quot;, postData);
        }


        /// &lt;summary&gt;
        /// Change the points array to a string, a points string seperated by
        /// comma. for exampe:[10,11,12,13] will be transfered to 
        /// &quot;10,11,12,13,&quot;
        /// &lt;/summary&gt;
        private string DoubleArrayToString(double[] doubleArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i &lt; doubleArray.Length; i&#43;&#43;)
            {
                sb.Append(doubleArray[i].ToString());
                sb.Append(&quot;,&quot;);
            }
            return sb.ToString();
        }


        /// &lt;summary&gt;
        /// This method funcation extract points array from a points string. 
        /// please do a comparation with DoubleArrayToString method. 
        /// &lt;/summary&gt;
        private double[] StringToDoubleArray(string strokeString)
        {
            string[] stringArray = strokeString.Split(',');
            double[] strokeArray = new double[stringArray.Length - 1];
            for (int i = 0; i &lt; strokeArray.Length; i&#43;&#43;)
            {
                strokeArray[i] = Double.Parse(stringArray[i]);
            }
            return strokeArray;
        }


        /// &lt;summary&gt;
        /// This method capture mouse down event and initialize related objects. 
        /// &lt;/summary&gt;
        private void MyIP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyIP.CaptureMouse();
            StylusPointCollection myStylusPointCollection = new StylusPointCollection();
            myStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(MyIP));
            newStroke = new Stroke(myStylusPointCollection);
            newStroke.DrawingAttributes.Color = Colors.Blue;
            MyIP.Strokes.Add(newStroke);
        }


        /// &lt;summary&gt;
        /// Add stroke info into shared stroke object(newStroke).
        /// &lt;/summary&gt;
        private void MyIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (newStroke != null)
            {
                newStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(MyIP));
            }
        }


        /// &lt;summary&gt;
        /// Unregister the device when user turn away from this page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            //delete deveice info from server
            UnRegisterPhone(id);
        }


        private void btn_ServerOk_Click(object sender, RoutedEventArgs e)
        {
            serverHost = txtBox_ServerAddress.Text;
            pushChannel = this.GetPushChannel();
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal">For more about <span class="SpellE"><span class="GramE">InkPresenter</span></span><span class="GramE"> ,</span> please check this link:<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.inkpresenter(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.inkpresenter(VS.95).aspx</a></p>
<p class="MsoNormal">About how to create a <span class="SpellE"><span class="GramE">Httphandler</span></span><span class="GramE"> ,</span> see this kb:<br>
<a href="http://support.microsoft.com/kb/308001">http://support.microsoft.com/kb/308001</a></p>
<p class="MsoNormal"><span class="GramE">About Notification Push.</span> Please see<span class="GramE">:</span><br>
<a href="http://msdn.microsoft.com/en-us/library/ff402537(VS.92).aspx">http://msdn.microsoft.com/en-us/library/ff402537(VS.92).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
