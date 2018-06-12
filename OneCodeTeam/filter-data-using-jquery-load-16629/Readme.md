# filter data using jquery load (JqueryFilterLoadDynamicContent)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* jQuery
## IsPublished
* True
## ModifiedDate
* 2012-05-10 07:53:19
## Description

<h1>Loading dynamic content in order to filter the data using jquery load() function (VBJqueryFilterLoadDynamicContent)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to load dynamic ASPX pages in order to filter the data. With using of jQuery.load() function, we can call the page with provided query string parameter and load appropriate content.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">VBJqueryFilterLoadDynamicContent</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">VBJqueryFilterLoadDynamicContent</span> </a>
web application and press Ctrl &#43; F5 to show the GetProvinces.aspx. </p>
<p class="MsoNormal">Step 2: We will see a <span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">
DropDownList</span> Control on the web page and some information of Province.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/57337/1/image.png" alt="" width="834" height="408" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span style="">&nbsp; </span>When you click the DropDownList, the page will by using like ��GetCountries.aspx?countryID=China�� call ��GetCountries.aspx�� . The selected value of the DropDownList will be as value of ��countryID��
 parameter.<br>
The following shows the result by using like ��GetCountries.aspx?countryID=China�� call ��GetCountries.aspx��.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/57338/1/image.png" alt="" width="537" height="356" align="middle">
</span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp;&nbsp; </span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as ��<span style="">VBJqueryFilterLoadDynamicContent</span>&quot;.
</p>
<p class="MsoNormal">Step 2.<span style="">&nbsp; </span>Add one web form pages and name it as ��GetCountries.aspx�� page, then add a Repeater Control to this page then rename it to &quot;rptCountries&quot;. This page will bind the query data to &quot;rptCountries&quot;
 upon request. In order to realize this page:</p>
<p class="MsoNormal">First, we need create a <span style="color:black">Province class for store information.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Province class
''' &lt;/summary&gt;
Public Class Province
    Public Property ProvinceName() As String
        Get
            Return m_ProvinceName
        End Get
        Set(ByVal value As String)
            m_ProvinceName = value
        End Set
    End Property
    Private m_ProvinceName As String
    Public Property PinYin() As String
        Get
            Return m_PinYin
        End Get
        Set(ByVal value As String)
            m_PinYin = value
        End Set
    End Property
    Private m_PinYin As String
    Public Property countryID() As String
        Get
            Return m_countryID
        End Get
        Set(ByVal value As String)
            m_countryID = value
        End Set
    End Property
    Private m_countryID As String
End Class

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Province class
''' &lt;/summary&gt;
Public Class Province
    Public Property ProvinceName() As String
        Get
            Return m_ProvinceName
        End Get
        Set(ByVal value As String)
            m_ProvinceName = value
        End Set
    End Property
    Private m_ProvinceName As String
    Public Property PinYin() As String
        Get
            Return m_PinYin
        End Get
        Set(ByVal value As String)
            m_PinYin = value
        End Set
    End Property
    Private m_PinYin As String
    Public Property countryID() As String
        Get
            Return m_countryID
        End Get
        Set(ByVal value As String)
            m_countryID = value
        End Set
    End Property
    Private m_countryID As String
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Then, we need declare a <span style="color:black">List of Province and add some instances of the Province class to the list.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">   Public Provinces As List(Of Province) 


   ''' &lt;summary&gt;
   ''' load sample data method
   ''' &lt;/summary&gt;
   Public Sub LoadSampleProvincesData()
       Provinces = New List(Of Province)()


       Provinces.Add(New Province() With {.countryID = &quot;China&quot;, .PinYin = &quot;HeBei&quot;, .ProvinceName = &quot;HeBei&quot;})
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;BeiJing&quot;, _
          .ProvinceName = &quot;BeiJing&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;ShangHai&quot;, _
          .ProvinceName = &quot;ShangHai&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;ShanXi&quot;, _
          .ProvinceName = &quot;ShanXi&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;JiangXi&quot;, _
          .ProvinceName = &quot;JiangXi&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;LiaoNing&quot;, _
          .ProvinceName = &quot;LiaoNing&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;US&quot;, _
          .PinYin = &quot;Los Angeles&quot;, _
          .ProvinceName = &quot;Los Angeles&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;US&quot;, _
          .PinYin = &quot;Detroit&quot;, _
          .ProvinceName = &quot;Detroit&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;New York&quot;, _
          .PinYin = &quot;New York&quot;, _
          .ProvinceName = &quot;New York&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;UK&quot;, _
          .PinYin = &quot;England&quot;, _
          .ProvinceName = &quot;England&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;UK&quot;, _
          .PinYin = &quot;Scotland&quot;, _
          .ProvinceName = &quot;Scotland&quot; _
       })
   End Sub

</pre>
<pre id="codePreview" class="vb">   Public Provinces As List(Of Province) 


   ''' &lt;summary&gt;
   ''' load sample data method
   ''' &lt;/summary&gt;
   Public Sub LoadSampleProvincesData()
       Provinces = New List(Of Province)()


       Provinces.Add(New Province() With {.countryID = &quot;China&quot;, .PinYin = &quot;HeBei&quot;, .ProvinceName = &quot;HeBei&quot;})
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;BeiJing&quot;, _
          .ProvinceName = &quot;BeiJing&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;ShangHai&quot;, _
          .ProvinceName = &quot;ShangHai&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;ShanXi&quot;, _
          .ProvinceName = &quot;ShanXi&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;JiangXi&quot;, _
          .ProvinceName = &quot;JiangXi&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;China&quot;, _
          .PinYin = &quot;LiaoNing&quot;, _
          .ProvinceName = &quot;LiaoNing&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;US&quot;, _
          .PinYin = &quot;Los Angeles&quot;, _
          .ProvinceName = &quot;Los Angeles&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;US&quot;, _
          .PinYin = &quot;Detroit&quot;, _
          .ProvinceName = &quot;Detroit&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;New York&quot;, _
          .PinYin = &quot;New York&quot;, _
          .ProvinceName = &quot;New York&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;UK&quot;, _
          .PinYin = &quot;England&quot;, _
          .ProvinceName = &quot;England&quot; _
       })
       Provinces.Add(New Province() With { _
          .countryID = &quot;UK&quot;, _
          .PinYin = &quot;Scotland&quot;, _
          .ProvinceName = &quot;Scotland&quot; _
       })
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="color:black"><br>
Finally, we filter Provinces data by ��countryID�� using LINQ and add the collection as data source to the repeater.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">

  Protected Overrides Sub OnInit(ByVal e As EventArgs)
      'load sample data
      LoadSampleProvincesData()
      MyBase.OnInit(e)
  End Sub




  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If Request.QueryString.Count &gt; 0 Then
          If Not String.IsNullOrEmpty(Request.QueryString(&quot;countryID&quot;)) Then
              Dim countryID As String = Request.QueryString(&quot;countryID&quot;)
              'get query string into string variable
              'filter Provinces sample data by countryID using LINQ
              'and add the collection as data source to the repeater
              rptCountries.DataSource = Provinces.Where(Function(x) x.countryID = countryID)
              'bind repeater
              rptCountries.DataBind()
          End If
      End If


  End Sub

</pre>
<pre id="codePreview" class="vb">

  Protected Overrides Sub OnInit(ByVal e As EventArgs)
      'load sample data
      LoadSampleProvincesData()
      MyBase.OnInit(e)
  End Sub




  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If Request.QueryString.Count &gt; 0 Then
          If Not String.IsNullOrEmpty(Request.QueryString(&quot;countryID&quot;)) Then
              Dim countryID As String = Request.QueryString(&quot;countryID&quot;)
              'get query string into string variable
              'filter Provinces sample data by countryID using LINQ
              'and add the collection as data source to the repeater
              rptCountries.DataSource = Provinces.Where(Function(x) x.countryID = countryID)
              'bind repeater
              rptCountries.DataBind()
          End If
      End If


  End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
The following shows the code of the Repeater.<b style="">[Note]</b><span style=""> The table with id ��tableCountries��, will be used behind.</span><br>
<span style=""><img src="/site/view/file/57339/1/image.png" alt="" width="457" height="407" align="middle">
</span></p>
<p class="MsoNormal">Step 3.<span style="">&nbsp; </span>Add one web form pages and name it as ��GetProvinces.aspx�� page, then add a DropDownList Control to this page then rename it to &quot;drpCountries&quot;. This page will show to loading dynamic content
 in order to filter the data using load() function of jquery.<br>
The following shows the code of the html. <b style="">[Note]</b><span style=""> The div with id ��DivCountries��, will be used behind.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
Select a county:&lt;asp:DropDownList ID=&quot;drpCountries&quot; runat=&quot;server&quot; AutoPostBack=&quot;true&quot;&gt;
           &lt;asp:ListItem&gt;China&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;US&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;UK&lt;/asp:ListItem&gt;
       &lt;/asp:DropDownList&gt;
       <br>
       <div id="DivCountries">
       </div>

</pre>
<pre id="codePreview" class="html">
Select a county:&lt;asp:DropDownList ID=&quot;drpCountries&quot; runat=&quot;server&quot; AutoPostBack=&quot;true&quot;&gt;
           &lt;asp:ListItem&gt;China&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;US&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;UK&lt;/asp:ListItem&gt;
       &lt;/asp:DropDownList&gt;
       <br>
       <div id="DivCountries">
       </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 4. Using jQuery's selector capability, you can do this:<span style="">&nbsp;
</span>$(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);<br>
<span style="">&nbsp;</span>Now using jQuery.load() function, we can call this page with provided query string parameter and load appropriate content. This will load the content of ��tableCountries�� to ��DivCountries��. The code as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


   &lt;script type=&quot;text/javascript&quot;&gt;
       $(document).ready(function() {
           var countryId = $(&quot;#&lt;%= drpCountries.ClientID %&gt;&quot;).val();


           $(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);


       }); 
   &lt;/script&gt;

</pre>
<pre id="codePreview" class="js">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


   &lt;script type=&quot;text/javascript&quot;&gt;
       $(document).ready(function() {
           var countryId = $(&quot;#&lt;%= drpCountries.ClientID %&gt;&quot;).val();


           $(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);


       }); 
   &lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 5. Build the application and you can debug it.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
