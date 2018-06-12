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
* 2013-06-13 10:11:21
## Description

<h1>How to call web Service in Excel Using VSTO (CS<span style="">ExcelCallWebService</span>)</h1>
<h2>Introduction<span style=""> </span></h2>
<p class="Normal"><span style="">The sample demonstrates how to call web service in excel. The excel client call web service to get the returned string about weather and parse the returned string to XElement collection. Then query the collection and bind
 the value of XElement to the NameRange control. </span></p>
<h2>Building the Sample</h2>
<p class="Normal"><span style="">Before you build the sample, you must install Microsoft Office 2010 on your Operation System and be sure that Excel process is not running.
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="Normal"><span style="">Step1. Open &quot;CSExcelCallWebService.sln&quot; and click F5 to run the solution
</span></p>
<p class="Normal"><span style="">Step2. Choose the &quot;Call WebService Ribbon&quot; ribbon and input correct city name and country name. Then click &quot;Get Weather&quot; button to display the data about weather in worksheet. You will see the following
 form: </span></p>
<p class="Normal"><span style=""><img src="/site/view/file/84340/1/image.png" alt="" width="804" height="612" align="middle">
</span><span style=""></span></p>
<p class="Normal"><span style="">Step3. If you input incorrect city name or country name, you will get error message &quot;Input City or Country is error, Please check them again&quot; in cell A1.
</span></p>
<p class="Normal"><span style="">Step4. Close Excel 2010 and In the Solution Explorer, right click
</span>CS<span style="">ExcelCallWebService and click Clean. </span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="Normal"><span style="">Step1. Create Excel 2010 Workbook project in Visual Studio 2010
</span></p>
<p class="Normal"><span style="">Step2. Add a service reference: </span></p>
<p class="Normal"><span style=""><img src="/site/view/file/84341/1/image.png" alt="" width="627" height="506" align="middle">
</span><span style=""></span></p>
<p class="Normal"><span style="">Step3. Open sheet1.cs to write the code: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
///  Call Web service and display the results to the NameRange control
/// &lt;/summary&gt;
/// &lt;param name=&quot;city&quot;&gt;Search City&lt;/param&gt;
/// &lt;param name=&quot;country&quot;&gt;Search Country&lt;/param&gt;
public void DisplayWebServiceResult(string city, string country)
{
    // Get Name Range and Clear current display
    NamedRange range = (NamedRange)this.Controls[&quot;Data&quot;];
    range.Clear();


    // Initialize the value of x 
    int x = 0;


    try
    {
        // Initialize a new instance of Service Client 
        using (GlobalWeatherSoapClient weatherclien = new GlobalWeatherSoapClient())
        {
            // Call Web service method to Get Weather Data
            string xmlweatherresult = weatherclien.GetWeather(city, country);


            // Load an XElement from a string that contains XML data
            var xmldata = XElement.Parse(xmlweatherresult);


            // Query the Name and value of Weather
            var query = from weather in xmldata.Elements()
                        select new
                        {
                            weather.Name,
                            weather.Value
                        };


            if (query.Count() &gt; 0)
            {
                foreach (var item in query)
                {
                    // Use RefersToR1C1 property to change the range that a NameRange control refers to
                    range.RefersToR1C1 = String.Format(&quot;=R1C1:R{0}C2&quot;, query.Count());


                    // Update data  in range.
                    // Excel uses 1 as the base for index.
                    ((Excel.Range)range.Cells[x &#43; 1, 1]).Value2 = item.Name.ToString();
                    ((Excel.Range)range.Cells[x &#43; 1, 2]).Value2 = item.Value.ToString();
                    x&#43;&#43;;
                    if (x == query.Count() - 1)
                    {
                        break;
                    }
                }
            }
        }
    }
    catch
    {
        this.Range[&quot;A1&quot;].Value2 = &quot;Input City or Country is error, Please check them again&quot;;


        // -16776961 is represent for red
        this.Range[&quot;A1&quot;].Font.Color = -16776961;
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
///  Call Web service and display the results to the NameRange control
/// &lt;/summary&gt;
/// &lt;param name=&quot;city&quot;&gt;Search City&lt;/param&gt;
/// &lt;param name=&quot;country&quot;&gt;Search Country&lt;/param&gt;
public void DisplayWebServiceResult(string city, string country)
{
    // Get Name Range and Clear current display
    NamedRange range = (NamedRange)this.Controls[&quot;Data&quot;];
    range.Clear();


    // Initialize the value of x 
    int x = 0;


    try
    {
        // Initialize a new instance of Service Client 
        using (GlobalWeatherSoapClient weatherclien = new GlobalWeatherSoapClient())
        {
            // Call Web service method to Get Weather Data
            string xmlweatherresult = weatherclien.GetWeather(city, country);


            // Load an XElement from a string that contains XML data
            var xmldata = XElement.Parse(xmlweatherresult);


            // Query the Name and value of Weather
            var query = from weather in xmldata.Elements()
                        select new
                        {
                            weather.Name,
                            weather.Value
                        };


            if (query.Count() &gt; 0)
            {
                foreach (var item in query)
                {
                    // Use RefersToR1C1 property to change the range that a NameRange control refers to
                    range.RefersToR1C1 = String.Format(&quot;=R1C1:R{0}C2&quot;, query.Count());


                    // Update data  in range.
                    // Excel uses 1 as the base for index.
                    ((Excel.Range)range.Cells[x &#43; 1, 1]).Value2 = item.Name.ToString();
                    ((Excel.Range)range.Cells[x &#43; 1, 2]).Value2 = item.Value.ToString();
                    x&#43;&#43;;
                    if (x == query.Count() - 1)
                    {
                        break;
                    }
                }
            }
        }
    }
    catch
    {
        this.Range[&quot;A1&quot;].Value2 = &quot;Input City or Country is error, Please check them again&quot;;


        // -16776961 is represent for red
        this.Range[&quot;A1&quot;].Font.Color = -16776961;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="Normal"><span style=""></span></p>
<p class="Normal"><span style="">Step4. Create a Ribbon control to the project and design the UI, then you can input the city name and country name to get data of weather.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
       /// Get Weather method
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       private void btnGetWeather_Click(object sender, RibbonControlEventArgs e)
       {
           if (citybox.Text.Trim().Equals(string.Empty) || countrybox.Text.Trim().Equals(string.Empty))
           {
               MessageBox.Show(&quot;Please input the city or country name firstly.&quot;);
               return;
           }


           // Call web service to get Weather
           Globals.Sheet1.DisplayWebServiceResult(citybox.Text.Trim(),countrybox.Text.Trim());
       }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
       /// Get Weather method
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       private void btnGetWeather_Click(object sender, RibbonControlEventArgs e)
       {
           if (citybox.Text.Trim().Equals(string.Empty) || countrybox.Text.Trim().Equals(string.Empty))
           {
               MessageBox.Show(&quot;Please input the city or country name firstly.&quot;);
               return;
           }


           // Call web service to get Weather
           Globals.Sheet1.DisplayWebServiceResult(citybox.Text.Trim(),countrybox.Text.Trim());
       }

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
