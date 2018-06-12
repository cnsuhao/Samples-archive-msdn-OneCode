# How to dynamically bind event handler in .aspx page to a control in .ascx page
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Event Handler
* Dynamically bind
## IsPublished
* True
## ModifiedDate
* 2014-03-06 07:49:16
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h2 class="MsoNormal"><strong>Introduction</strong></h2>
<p class="MsoNormal"><span lang="EN-US">Developers always want to bind a control event to at run time.
</span></p>
<p class="MsoNormal"><span lang="EN-US">This sample will demonstrate how to dynamically bind an event handler on an aspx page to a control on an ascx page. You can find&nbsp;answers for all the following questions in this code sample:
</span></p>
<p class="MsoNormal"><a name="OLE_LINK2"></a><a name="OLE_LINK3"><span><span lang="EN-US">How to get handler string and use reflection to bind click event to specific method.
</span></span></a></p>
<p class="MsoNormal"><span><span><span lang="EN-US">How to write Handler for Click event in external classes.
</span></span></span></p>
<h2><strong>Running the Sample</strong></h2>
<p class="MsoNormal"><span lang="EN-US">You can directly run the sample. </span>
</p>
<h2><strong>Using the Code</strong></h2>
<p class="MsoNormal"><span lang="EN-US">The code sample provides the following functions to solve the questions above.
</span></p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<h3><strong>How to get handler string and use reflection to bind click event to specific method.</strong></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected void Page_Load(object sender, EventArgs e)
       {        
               XElement root = XElement.Load(Server.MapPath(&quot;~/SourceFile.xml&quot;));
               var images = root.Element(&quot;Images&quot;);
               var imageElements = images.Elements(&quot;Image&quot;);
               foreach (var imageElement in imageElements)
               {
                   var lbtn = new LinkButton();

                   //Use image Name as linkButton Text
                   var strArray=imageElement.Element(&quot;URL&quot;).Value.Split('/');
                   lbtn.Text =strArray[strArray.Length-1];
                  
                   //Bind click event with relection method
                   lbtn.Click &#43;= (ibtnSender, imageClickArgs) =&gt; {
                       Type clickHandlerType = typeof(ClickHandlers);
                       ConstructorInfo constructor = clickHandlerType.GetConstructor(Type.EmptyTypes);
                       Object clickHandlerObject = constructor.Invoke(new Object[] { });

                       var method = clickHandlerType.GetMethod(imageElement.Element(&quot;ClickHandler&quot;).Value);
                       Object[] addHandlerArgs = { ibtnSender,imageClickArgs };
                       method.Invoke(clickHandlerObject, addHandlerArgs);
                   };

                   lbtn.ID = imageElement.Element(&quot;ID&quot;).Value;
                   
                   pnlImages.Controls.Add(lbtn);
           }
       } 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XElement&nbsp;root&nbsp;=&nbsp;XElement.Load(Server.MapPath(<span class="cs__string">&quot;~/SourceFile.xml&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;images&nbsp;=&nbsp;root.Element(<span class="cs__string">&quot;Images&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageElements&nbsp;=&nbsp;images.Elements(<span class="cs__string">&quot;Image&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;imageElement&nbsp;<span class="cs__keyword">in</span>&nbsp;imageElements)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lbtn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinkButton();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;image&nbsp;Name&nbsp;as&nbsp;linkButton&nbsp;Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;strArray=imageElement.Element(<span class="cs__string">&quot;URL&quot;</span>).Value.Split(<span class="cs__string">'/'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbtn.Text&nbsp;=strArray[strArray.Length<span class="cs__number">-1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Bind&nbsp;click&nbsp;event&nbsp;with&nbsp;relection&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbtn.Click&nbsp;&#43;=&nbsp;(ibtnSender,&nbsp;imageClickArgs)&nbsp;=&gt;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;clickHandlerType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(ClickHandlers);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConstructorInfo&nbsp;constructor&nbsp;=&nbsp;clickHandlerType.GetConstructor(Type.EmptyTypes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Object&nbsp;clickHandlerObject&nbsp;=&nbsp;constructor.Invoke(<span class="cs__keyword">new</span>&nbsp;Object[]&nbsp;{&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;method&nbsp;=&nbsp;clickHandlerType.GetMethod(imageElement.Element(<span class="cs__string">&quot;ClickHandler&quot;</span>).Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Object[]&nbsp;addHandlerArgs&nbsp;=&nbsp;{&nbsp;ibtnSender,imageClickArgs&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method.Invoke(clickHandlerObject,&nbsp;addHandlerArgs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbtn.ID&nbsp;=&nbsp;imageElement.Element(<span class="cs__string">&quot;ID&quot;</span>).Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pnlImages.Controls.Add(lbtn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:10px">The code above use Linq to XML get the ClickHandler value in XMl, then use the reflection add this ClickHeandler to click event.</span></p>
<p class="MsoNormal"><span lang="EN-US">If you want to get method names of a given type in .Net, you can use method<strong><a href="http://msdn2.microsoft.com/en-us/library/4d848zkb.aspx"><span style="font-weight:normal">Type.GetMethods</span></a></strong>.
 This method returns array of&nbsp;<strong><a href="http://msdn2.microsoft.com/en-us/library/system.reflection.methodinfo_members.aspx"><span style="font-weight:normal">MethodInfo</span></a></strong>&nbsp;objects. MethodInfo contains many informations about
 the method and of course a method name (MethodInfo.Name). To filter returned methods (for example if you want to get only public static methods) use<a href="http://msdn2.microsoft.com/en-us/library/System.Reflection.BindingFlags.aspx">BindingFlags</a><span>&nbsp;parameter
 when calling GetMethods method. Required are at least two flags, one from&nbsp;Public/NonPublic<span>&nbsp;and one of&nbsp;Instance/Static<span>&nbsp;flags. Of course you can use all four flags and also DeclaredOnly and FlattenHierarchy. BindingFlags enumeration
 and MethodInfo class are declared in System.Reflection namespace.</span> </span>
</span></span></p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<h3><strong>How to write Handler for Click event in external classes.</strong></h3>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ClickHandlers
   {
       XElement root = XElement.Load(HttpContext.Current.Server.MapPath(&quot;SourceFile.xml&quot;));
       public void ResponseImageURL(object sender, EventArgs e)
       {
           var lbtn = (LinkButton)sender;
           string lbtnID = lbtn.ID;

           var images = root.Element(&quot;Images&quot;);
           var imageElements = images.Elements(&quot;Image&quot;);
           var imageURL = (from i in imageElements
                           where i.Element(&quot;ID&quot;).Value == lbtnID
                           select i.Element(&quot;URL&quot;)).First().Value;
                          
           System.Web.HttpContext.Current.Response.Write(string.Format(&quot;The {0}'s absolute path is:{1}&quot;,lbtn.Text,imageURL));
       }


       public void ResponseImageID(object sender, EventArgs e)
       {
           var lbtn = (LinkButton)sender;          
           System.Web.HttpContext.Current.Response.Write(string.Format(&quot;The {0}'s ID:{1}&quot;, lbtn.Text, lbtn.ID));

       }
   }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ClickHandlers&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XElement&nbsp;root&nbsp;=&nbsp;XElement.Load(HttpContext.Current.Server.MapPath(<span class="cs__string">&quot;SourceFile.xml&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ResponseImageURL(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lbtn&nbsp;=&nbsp;(LinkButton)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;lbtnID&nbsp;=&nbsp;lbtn.ID;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;images&nbsp;=&nbsp;root.Element(<span class="cs__string">&quot;Images&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageElements&nbsp;=&nbsp;images.Elements(<span class="cs__string">&quot;Image&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageURL&nbsp;=&nbsp;(from&nbsp;i&nbsp;<span class="cs__keyword">in</span>&nbsp;imageElements&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;i.Element(<span class="cs__string">&quot;ID&quot;</span>).Value&nbsp;==&nbsp;lbtnID&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;i.Element(<span class="cs__string">&quot;URL&quot;</span>)).First().Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Web.HttpContext.Current.Response.Write(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;The&nbsp;{0}'s&nbsp;absolute&nbsp;path&nbsp;is:{1}&quot;</span>,lbtn.Text,imageURL));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ResponseImageID(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lbtn&nbsp;=&nbsp;(LinkButton)sender;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Web.HttpContext.Current.Response.Write(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;The&nbsp;{0}'s&nbsp;ID:{1}&quot;</span>,&nbsp;lbtn.Text,&nbsp;lbtn.ID));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</strong>
<p></p>
<p class="MsoNormal"><span lang="EN-US">The code above bind the specific click event to the link button control.
</span></p>
<h2><strong>More Information</strong></h2>
<p class="MsoNormal"><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/ms173183(v=vs.90).aspx">http://msdn.microsoft.com/en-us/library/ms173183(v=vs.90).aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
