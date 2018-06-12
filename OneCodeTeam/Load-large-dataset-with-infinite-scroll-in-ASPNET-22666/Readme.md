# Load large dataset with infinite scroll in ASP.NET
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* jQuery
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:44:58
## Description

<h1>Load Content While Scrolling With jQuery (CSASPNETInfiniteLoading)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Infinite scroll, has also been called autopagerize, unpaginate, endless pages. But essentially it is pre-fetching content from a subsequent page and adding it directly to the user on current page.<span style="">&nbsp;
</span>The code sample demonstrates loading a large number of data entries in an XML file. It support infinite scroll with the AJAX technology.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1. <span style="">&nbsp;</span>Open the CSASPNETInfiniteLoading.sln.<br>
Step 2.<span style="">&nbsp; </span>Right click Default.aspx and choose &quot;View in Browser&quot;. By default, we could see a vertical scroll on the page.</p>
<p class="MsoNormal">Just drag it scroll down, you will find the new content load infinitely meanwhile the scroll bar becomes small and small.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84676/1/image.png" alt="" width="460" height="176" align="middle">
</span></p>
<p class="MsoNormal"><br>
<span style="">&nbsp;</span><b style="">[Note]</b>: if there is no vertical scroll bar on page, just do appropriate scaling for the page till the vertical scroll bar appeared.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1.<span style="">&nbsp; </span>Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012.<br>
Step 2.<span style="">&nbsp; </span>Create a new directory, &quot;Scripts&quot;. Right-click the directory and click<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><b style="">Add</b> -&gt; <b style="">New Item</b> -&gt;
<b style="">JScript File</b>. <br>
We need to reference jquery javascript library files <b style="">jquery-1.9.1.min.js<br>
</b>Step 3.<span style="">&nbsp; </span>Create a new directory, &quot;Styles&quot;. Right-click the directory and click<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><b style="">Add</b> -&gt; <b style="">New Item</b> -&gt;
<b style="">Style Sheet File</b>. Reference site.css. <br>
Step 4.<span style="">&nbsp; </span>Open the Default.aspx. (If there is no Default.aspx, create one.)<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>In the Head block, add javascript and style references like below.
</p>
<p class="MsoNormal">Write the autocomplete javascript as below. </p>
<p class="MsoNormal">For more details, please refer to the Default.aspx in this sample.
</p>
<p class="MsoNormal">Step 7.<span style="">&nbsp; </span>Everything is ready, test the application by scrolling down the page to see what happens.</p>
<h2>More Information</h2>
<p class="MsoNormal">Load content while scrolling with jQuery.<br>
<a href="http://www.webresourcesdepot.com/load-content-while-scrolling-with-jquery/">http://www.webresourcesdepot.com/load-content-while-scrolling-with-jquery/</a></p>
<p class="MsoNormal"><span style="">&nbsp;</span><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
