# How to dynamically bind an event handler in.aspx page to a control in .ascx page
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* .NET
* Web App Development
## Topics
* Event Handler
* Dynamically bind
## IsPublished
* True
## ModifiedDate
* 2014-11-19 07:05:31
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><strong>Dynamically bind an event handler in an ASP.NET .aspx page to a control in an .ascx page (</strong><strong>VB</strong><strong>ASPNETDynamicallyBindEvent)</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>Developers always want to bind a control event to at run time.</p>
<p>This sample will demonstrate how to dynamically bind an event handler on an aspx page to a control on an ascx page. You can find&nbsp;answers for all the following questions in this code sample:</p>
<p>How to get handler string and use reflection to bind click event to specific method.</p>
<p>How to write Handler for Click event in external classes.</p>
<h2><strong>Running the Sample</strong></h2>
<p>You can directly run the sample.</p>
<h2><strong>Using the Code</strong></h2>
<p>The code sample provides the following functions to solve the questions above.</p>
<p><strong>How to get handler string and use reflection to bind click event to specific method.</strong></p>
<p class="MsoNormal">&nbsp;</p>
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
<pre id="codePreview" class="csharp">protected void Page_Load(object sender, EventArgs e)
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
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The code above use Linq to XML get the ClickHandler value in XMl, then use the reflection add this ClickHeandler to click event.</p>
<p>If you want to get method names of a given type in .Net, you can use method<strong><a href="http://msdn2.microsoft.com/en-us/library/4d848zkb.aspx">Type.GetMethods</a></strong>. This method returns array of&nbsp;<strong><a href="http://msdn2.microsoft.com/en-us/library/system.reflection.methodinfo_members.aspx">MethodInfo</a></strong>&nbsp;objects.
 MethodInfo contains many informations about the method and of course a method name (MethodInfo.Name). To filter returned methods (for example if you want to get only public static methods) use<a href="http://msdn2.microsoft.com/en-us/library/System.Reflection.BindingFlags.aspx">BindingFlags</a>&nbsp;parameter
 when calling GetMethods method. Required are at least two flags, one from&nbsp;Public/NonPublic&nbsp;and one of&nbsp;Instance/Static&nbsp;flags. Of course you can use all four flags and also DeclaredOnly and FlattenHierarchy. BindingFlags enumeration and MethodInfo
 class are declared in System.Reflection namespace.</p>
<p><strong>How to write Handler for Click event in external classes.</strong></p>
<p class="MsoNormal">&nbsp;</p>
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
<pre id="codePreview" class="csharp">public class ClickHandlers
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
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The code above bind the specific click event to the link button control.</p>
<h2><strong>More Information</strong></h2>
<p><a href="http://msdn.microsoft.com/en-us/library/ms173183(v=vs.90).aspx">http://msdn.microsoft.com/en-us/library/ms173183(v=vs.90).aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
