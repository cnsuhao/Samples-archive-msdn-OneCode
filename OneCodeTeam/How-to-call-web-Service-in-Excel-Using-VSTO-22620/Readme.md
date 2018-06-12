# How to call web Service in Excel Using VSTO
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Excel
* VSTO
* call web service
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:13:38
## Description

<h1>How to call web Service in Excel Using VSTO (<span style="">VBExcelCallWebService</span>)</h1>
<h2>Introduction<span style=""> </span></h2>
<p class="Normal"><span style="">The sample demonstrates how to call web service in excel. The excel client call web service to get the returned string about weather and parse the returned string to XElement collection. Then query the collection and bind
 the value of XElement to the NameRange control. </span></p>
<h2>Building the Sample</h2>
<p class="Normal"><span style="">Before you build the sample, you must install Microsoft Office 2010 on your Operation System and be sure that Excel process is not running.
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="Normal"><span style="">Step1. Open &quot;VBExcelCallWebService.sln&quot; and click F5 to run the solution
</span></p>
<p class="Normal"><span style="">Step2. Choose the &quot;Call WebService Ribbon&quot; ribbon and input correct city name and country name. Then click &quot;Get Weather&quot; button to display the data about weather in worksheet. You will see the following
 form: </span></p>
<p class="Normal"><span style=""><img src="/site/view/file/84366/1/image.png" alt="" width="810" height="612" align="middle">
</span><span style=""></span></p>
<p class="Normal"><span style="">Step3. If you input incorrect city name or country name, you will get error message &quot;Input City or Country is error, Please check them again&quot; in cell A1.
</span></p>
<p class="Normal"><span style="">Step4. Close Excel 2010 and In the Solution Explorer, right click VBExcelCallWebService and click Clean.
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="Normal"><span style="">Step1. Create Excel 2010 Workbook project in Visual Studio 2010
</span></p>
<p class="Normal"><span style="">Step2. Add a service reference: </span></p>
<p class="Normal"><span style=""><img src="/site/view/file/84367/1/image.png" alt="" width="627" height="506" align="middle">
</span><span style=""></span></p>
<p class="Normal"><span style="">Step3. Open sheet1.vb to write the code: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   '''  Call Web service and display the results to the NameRange control
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;city&quot;&gt;Search City&lt;/param&gt;
   ''' &lt;param name=&quot;country&quot;&gt;Search Country&lt;/param&gt;
   Public Sub DisplayWebServiceResult(city As String, country As String)
       ' Get Name Range and Clear current display
       Dim range As NamedRange = DirectCast(Me.Controls(&quot;Data&quot;), NamedRange)
       range.Clear()


       ' Initialize the value of x 
       Dim x As Integer = 0


       Try
           ' Initialize a new instance of Service Client 
           Using weatherclien As New GlobalWeatherSoapClient()
               ' Call Web service method to Get Weather Data
               Dim xmlweatherresult As String = weatherclien.GetWeather(city, country)


               ' Load an XElement from a string that contains XML data
               Dim xmldata = XElement.Parse(xmlweatherresult)


               ' Query the Name and value of Weather
               Dim query = From weather In xmldata.Elements()
                           Select weather.Name, weather.Value


               If query.Count() &gt; 0 Then
                   For Each item In query
                       ' Use RefersToR1C1 property to change the range that a NameRange control refers to
                       range.RefersToR1C1 = [String].Format(&quot;=R1C1:R{0}C2&quot;, query.Count())


                       ' Update data  in range.
                       ' Excel uses 1 as the base for index.
                       DirectCast(range.Cells(x &#43; 1, 1), Excel.Range).Value2 = item.Name.ToString()
                       DirectCast(range.Cells(x &#43; 1, 2), Excel.Range).Value2 = item.Value.ToString()
                       x &#43;= 1
                       If x = query.Count() - 1 Then
                           Exit For
                       End If
                   Next
               End If
           End Using
       Catch
           Me.Range(&quot;A1&quot;).Value2 = &quot;Input City or Country is error, Please check them again&quot;


           ' -16776961 is represent for red
           Me.Range(&quot;A1&quot;).Font.Color = -16776961
       End Try
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   '''  Call Web service and display the results to the NameRange control
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;city&quot;&gt;Search City&lt;/param&gt;
   ''' &lt;param name=&quot;country&quot;&gt;Search Country&lt;/param&gt;
   Public Sub DisplayWebServiceResult(city As String, country As String)
       ' Get Name Range and Clear current display
       Dim range As NamedRange = DirectCast(Me.Controls(&quot;Data&quot;), NamedRange)
       range.Clear()


       ' Initialize the value of x 
       Dim x As Integer = 0


       Try
           ' Initialize a new instance of Service Client 
           Using weatherclien As New GlobalWeatherSoapClient()
               ' Call Web service method to Get Weather Data
               Dim xmlweatherresult As String = weatherclien.GetWeather(city, country)


               ' Load an XElement from a string that contains XML data
               Dim xmldata = XElement.Parse(xmlweatherresult)


               ' Query the Name and value of Weather
               Dim query = From weather In xmldata.Elements()
                           Select weather.Name, weather.Value


               If query.Count() &gt; 0 Then
                   For Each item In query
                       ' Use RefersToR1C1 property to change the range that a NameRange control refers to
                       range.RefersToR1C1 = [String].Format(&quot;=R1C1:R{0}C2&quot;, query.Count())


                       ' Update data  in range.
                       ' Excel uses 1 as the base for index.
                       DirectCast(range.Cells(x &#43; 1, 1), Excel.Range).Value2 = item.Name.ToString()
                       DirectCast(range.Cells(x &#43; 1, 2), Excel.Range).Value2 = item.Value.ToString()
                       x &#43;= 1
                       If x = query.Count() - 1 Then
                           Exit For
                       End If
                   Next
               End If
           End Using
       Catch
           Me.Range(&quot;A1&quot;).Value2 = &quot;Input City or Country is error, Please check them again&quot;


           ' -16776961 is represent for red
           Me.Range(&quot;A1&quot;).Font.Color = -16776961
       End Try
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="Normal"><span style=""></span></p>
<p class="Normal"><span style="">Step4. Create a Ribbon control to the project and design the UI, then you can input the city name and country name to get data of weather.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    ''' &lt;summary&gt;
    ''' Get Weather method
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Private Sub btnGetWeather_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnGetWeather.Click
        If citybox.Text.Trim().Equals(String.Empty) OrElse countrybox.Text.Trim().Equals(String.Empty) Then
            MessageBox.Show(&quot;Please input the city or country name firstly.&quot;)
            Return
        End If


        ' Call web service to get Weather
        Globals.Sheet1.DisplayWebServiceResult(citybox.Text.Trim(), countrybox.Text.Trim())


    End Sub

</pre>
<pre id="codePreview" class="vb">
    ''' &lt;summary&gt;
    ''' Get Weather method
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Private Sub btnGetWeather_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnGetWeather.Click
        If citybox.Text.Trim().Equals(String.Empty) OrElse countrybox.Text.Trim().Equals(String.Empty) Then
            MessageBox.Show(&quot;Please input the city or country name firstly.&quot;)
            Return
        End If


        ' Call web service to get Weather
        Globals.Sheet1.DisplayWebServiceResult(citybox.Text.Trim(), countrybox.Text.Trim())


    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="Normal"><span style=""></span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/vstudio/microsoft.office.tools.excel.namedrange.aspx">NamedRange Interface</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.xml.linq.xelement.parse.aspx">XElement.Parse Method</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb387098.aspx">Linq to Xml</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
