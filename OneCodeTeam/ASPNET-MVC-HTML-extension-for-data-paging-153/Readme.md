# ASP.NET MVC HTML extension for data paging (CSASPNETMVCPager)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* ASP.NET MVC
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:05:44
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETMVCPager Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to customize a html extension method for paging.<br>
In this project we will define a class named Pager&lt;T&gt; to instialize some basic<br>
properties for paing, such as the total pages,how many records will be <br>
displayed in a page and so on. Then a html helper method would be define in <br>
the next CustomizePager class. <br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
ASP.NET MVC RTM and .NET Framework 3.5<br>
You can download ASP.NET MVC RTM from the following link.<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=c9ba1fe1-3ba8-439a-9e21-def90a8615a9">http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=c9ba1fe1-3ba8-439a-9e21-def90a8615a9</a><br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a Visual C# ASP.NET MVC application in Visual Studio 2008 and <br>
name it as CSASPNETMVCPager.<br>
<br>
Step2: Add a new folder named Images and add two pictures for next page or <br>
previous page.<br>
<br>
Step3: Add a new folder named Helper and add a new class file named CustomizePager.cs.<br>
<br>
Step4: Create Pager&lt;T&gt; class which is used to contain basic information about
<br>
the datasource &nbsp;and CustomizePager class which is used to render the pager html
<br>
code.<br>
&nbsp; &nbsp;public class Pager&lt;T&gt;<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// determine how many records displayed in one page<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int pageSize = 6;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// instantiate a pager object<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;collection&quot;&gt;datasource which implement ICollection&lt;T&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;currentPageIndex&quot;&gt;Current page index&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;requestBaseUrl&quot;&gt;Request base url&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Pager(ICollection&lt;T&gt; collection,int currentPageIndex,string requestBaseUrl)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//Initialize properties<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// instantiate a pager object<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;collection&quot;&gt;datasource which implement ICollection&lt;T&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;currentPageIndex&quot;&gt;Current page index&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;requestBaseUrl&quot;&gt;Request base url&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;imgUrlForUp&quot;&gt;image for previous page&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;imgUrlForDown&quot;&gt;image for next page&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Pager(ICollection&lt;T&gt; collection, int currentPageIndex, string requestBaseUrl, string imgUrlForUp, string imgUrlForDown)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//Initialize properties<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// instantiate a pager object<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;collection&quot;&gt;datasource which implement ICollection&lt;T&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;currentPageIndex&quot;&gt;Current page index&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;requestBaseUrl&quot;&gt;Request base url&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;imgUrlForUp&quot;&gt;image for previous page&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;imgUrlForDown&quot;&gt;image for next page&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;pagesSize&quot;&gt;determine the size of page numbers displayed&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Pager(IList&lt;T&gt; collection, int currentPageIndex, string requestBaseUrl, string imgUrlForUp, string imgUrlForDown, int pagesSize)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//Initialize properties<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// current page index<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int CurrentPageIndex { get; private set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// total pages<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int TotalPages { get; private set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// base url and id value construct a whole url, eg:<a target="_blank" href="http://RequestBaseUrl/id">http://RequestBaseUrl/id</a><br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string RequestBaseUrl { get; private set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// image for previous page<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string ImageUrlForUp { get; private set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// image for next page<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string ImageUrlForDown { get; private set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// size of page numbers which are displayed<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int PagesSize { get; private set; }<br>
&nbsp; &nbsp;}<br>
<br>
Step5: Create a Employee class in the Model folder as the model of the demo<br>
and a static class named EmployeeSet to generate demo data. For convenience <br>
we generate the demo data manually. You can create any data object which is <br>
inherited from ICollection&lt;T&gt; according to your requirement.<br>
<br>
Step6: Modify the Index method in the Home Controller to prepare for paging.<br>
<br>
&nbsp; &nbsp;public ActionResult Index(int ? id)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;int pageIndex = Convert.ToInt32(id);<br>
&nbsp; &nbsp; &nbsp; &nbsp;List&lt;Employee&gt; empList=EmployeeSet.Employees;<br>
&nbsp; &nbsp; &nbsp; &nbsp;int pagesSize = 5;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Pager&lt;Employee&gt; pager = new Pager&lt;Employee&gt;(empList , pageIndex, Url.Content(&quot;~/Home/Index&quot;), Url.Content(&quot;~/images/left.gif&quot;), Url.Content(&quot;~/images/right.gif&quot;), pagesSize);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;ViewData[&quot;pager&quot;] =pager;<br>
&nbsp; &nbsp; &nbsp; &nbsp;return View(empList.Skip(pager.pageSize * pageIndex).Take(pager.pageSize));<br>
&nbsp; &nbsp;}<br>
<br>
<br>
Step7: Modify the Index view in the Home folder which is in the Views folder<br>
to render the employee information and output pager.<br>
<br>
Step8: Build and run the ASP.NET project.<br>
<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="http://www.asp.net/mvc/fundamentals/">http://www.asp.net/mvc/fundamentals/</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
