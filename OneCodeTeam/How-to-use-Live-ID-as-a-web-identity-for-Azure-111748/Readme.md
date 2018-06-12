# How to use Live ID as a web identity for Azure-based service
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* ACS
## IsPublished
* True
## ModifiedDate
* 2015-01-19 07:12:30
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1><strong>How to use </strong><strong>ACS identify with Live ID</strong><strong>&nbsp;</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>ACS is built on the principles of claims-based identity, in .net 4.5, there is a big change in WIF, and this sample will show you how to use claims-based identity with windows Azure in Visual Studio 2012.</p>
<h2><strong>Running the Sample</strong></h2>
<p>First search &ldquo;TODO:&rdquo; in your web.config file and login.aspx file.</p>
<p>Change the value to yours.</p>
<p>For how to get that values, please read: <a href="http://www.windowsazure.com/en-us/develop/net/how-to-guides/access-control/#config-trust">
How to Authenticate Web Users with Windows Azure Active Directory Access Control</a></p>
<h2><strong>Using the Code</strong></h2>
<ol>
<li>Open Visual studio. </li><li>Click Tools-&gt;Extensions and update. Then input identity in Online search, select Identity and Access Tool and install.
</li></ol>
<p>&nbsp;<img id="132700" src="/site/view/file/132700/1/image002.jpg" alt="" width="576" height="399">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;3.<span style="font-size:10px">Reopen Visual Studio, create a cloud service named VBAzureIdentityWithLiveID
 with a web role.</span></p>
<p><span style="font-size:10px">&nbsp;</span><span style="font-size:10px">&nbsp; &nbsp; &nbsp;4.Right click Web Role project, and click identity and Access.</span></p>
<p>&nbsp;<img id="132701" src="/site/view/file/132701/1/image003.png" alt="" width="352" height="745"></p>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp;5. In &quot;Choose where your users are from&quot; form, choose the third one.</span></p>
<p>&nbsp;<img id="132702" src="/site/view/file/132702/1/image005.jpg" alt="" width="576" height="191"></p>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp;6. Configure your account by click (Configure&hellip;), get the Namespace and management key from your ACS portal.</span></p>
<p>&nbsp;<img id="132703" src="/site/view/file/132703/1/image007.jpg" alt="" width="576" height="410"></p>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp;7. After the configuration, you can edit the APP ID URL and Return URL for you app.</span></p>
<p>Input <a href="http://127.0.0.1:81/">http://127.0.0.1:81/</a> in both textboxes.</p>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp;8. To customize a Login page, you can download the example code from ACS management portal, or you can write them by yourself.</span></p>
<p>The most important thing is do not forget to add the IdentityProviders.js to your login page.</p>
<h3><strong>This code shows how to involve your acs login script in your app.</strong></h3>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>HTML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">html</span><pre class="hidden">&lt;script src=&quot;https://Myappfabric.accesscontrol.windows.net:443/v2/metadata/IdentityProviders.js?protocol=wsfederation&amp;realm=http%3a%2f%2flocalhost%3a64801%2f&amp;reply_to=http%3a%2f%2flocalhost%3a64801%2fcallback.aspx&amp;context=&amp;request_id=&amp;version=1.0&amp;callback=ShowSigninPage&quot; 
type=&quot;text/javascript&quot;&gt;
&lt;/script&gt;</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;https://Myappfabric.accesscontrol.windows.net:443/v2/metadata/IdentityProviders.js?protocol=wsfederation&amp;realm=http%3a%2f%2flocalhost%3a64801%2f&amp;reply_to=http%3a%2f%2flocalhost%3a64801%2fcallback.aspx&amp;context=&amp;request_id=&amp;version=1.0&amp;callback=ShowSigninPage&quot;</span>&nbsp;&nbsp;
<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<h3><strong>This code show&rsquo;s how to create the button for your IDP.</strong></h3>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>JavaScript</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">js</span><pre class="hidden">//Creates a stylized link to an identity provider's login page
       function CreateIdentityProviderButton(identityProvider) {
           var idpList = document.getElementById(&quot;IdentityProvidersList&quot;);
           var button = document.createElement(&quot;button&quot;);
           button.setAttribute(&quot;name&quot;, identityProvider.Name);
           button.setAttribute(&quot;id&quot;, identityProvider.LoginUrl);
           button.className = &quot;IdentityProvider&quot;;
           button.onclick = IdentityProviderButtonClicked;
 
           // Display an image if an image URL is present
           if (identityProvider.ImageUrl.length &gt; 0) {
 
               var img = document.createElement(&quot;img&quot;);
               img.className = &quot;IdentityProviderImage&quot;;
               img.setAttribute(&quot;src&quot;, identityProvider.ImageUrl);
               img.setAttribute(&quot;alt&quot;, identityProvider.Name);
               img.setAttribute(&quot;border&quot;, &quot;0&quot;);
               img.onLoad = ResizeImage(img);
 
               button.appendChild(img);
           }
               // Otherwise, display a text link if no image URL is present
           else if (identityProvider.ImageUrl.length === 0) {
               button.appendChild(document.createTextNode(identityProvider.Name));
           }
 
           idpList.appendChild(button);
       }</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//Creates&nbsp;a&nbsp;stylized&nbsp;link&nbsp;to&nbsp;an&nbsp;identity&nbsp;provider's&nbsp;login&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;CreateIdentityProviderButton(identityProvider)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;idpList&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;IdentityProvidersList&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;button&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.setAttribute(<span class="js__string">&quot;name&quot;</span>,&nbsp;identityProvider.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.setAttribute(<span class="js__string">&quot;id&quot;</span>,&nbsp;identityProvider.LoginUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.className&nbsp;=&nbsp;<span class="js__string">&quot;IdentityProvider&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.onclick&nbsp;=&nbsp;IdentityProviderButtonClicked;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Display&nbsp;an&nbsp;image&nbsp;if&nbsp;an&nbsp;image&nbsp;URL&nbsp;is&nbsp;present</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(identityProvider.ImageUrl.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;img&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;img&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.className&nbsp;=&nbsp;<span class="js__string">&quot;IdentityProviderImage&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.setAttribute(<span class="js__string">&quot;src&quot;</span>,&nbsp;identityProvider.ImageUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.setAttribute(<span class="js__string">&quot;alt&quot;</span>,&nbsp;identityProvider.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.setAttribute(<span class="js__string">&quot;border&quot;</span>,&nbsp;<span class="js__string">&quot;0&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.onLoad&nbsp;=&nbsp;ResizeImage(img);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.appendChild(img);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Otherwise,&nbsp;display&nbsp;a&nbsp;text&nbsp;link&nbsp;if&nbsp;no&nbsp;image&nbsp;URL&nbsp;is&nbsp;present</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__statement">if</span>&nbsp;(identityProvider.ImageUrl.length&nbsp;===&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.appendChild(document.createTextNode(identityProvider.Name));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idpList.appendChild(button);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>9. In callback.aspx page, you need to use the latest WIF code.</p>
<h3><strong>This code shows how to get current claims in new WIF.</strong></h3>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">var UserName = System.Security.Claims.ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;           
           if (UserName!=null)
           {
               Session[&quot;UserName&quot;] = UserName;
               Response.Redirect(&quot;Default.aspx&quot;);
           } 
</pre>
<div class="preview">
<pre class="csharp">var&nbsp;UserName&nbsp;=&nbsp;System.Security.Claims.ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(UserName!=<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session[<span class="cs__string">&quot;UserName&quot;</span>]&nbsp;=&nbsp;UserName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Redirect(<span class="cs__string">&quot;Default.aspx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>&nbsp;</p>
<h2><strong>More Information</strong><strong>&nbsp;</strong></h2>
<p><a href="http://www.windowsazure.com/en-us/develop/net/how-to-guides/access-control/#config-trust">http://www.windowsazure.com/en-us/develop/net/how-to-guides/access-control/#config-trust</a></p>
