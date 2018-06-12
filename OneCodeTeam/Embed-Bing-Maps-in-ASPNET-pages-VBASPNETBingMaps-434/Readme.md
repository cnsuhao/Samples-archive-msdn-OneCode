# Embed Bing Maps in ASP.NET pages (VBASPNETBingMaps)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Bing Maps
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:37:13
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETBingMaps Project Overview</h2>
<p style="font-family:Courier New"><br>
Use:<br>
<br>
This project illustrates how to embed Bing Maps in an ASP.NET page as well <br>
as how to display the map according to several options and how to find a <br>
location via an input.<br>
<br>
Demo the Sample.<br>
<br>
Step1: Browse the Default.aspx from the sample and you can find a map located<br>
at the left part and several inputs at the right part in the page.<br>
<br>
Step2: You can move the map via dragging the mouse in the Map area as well as<br>
zoom the map by using the the mouse wheel.<br>
<br>
Step3: If you want to find a city, New York for example, in the map, you can <br>
input the city name in the TextBox after &quot;Location&quot; and click Submit button.<br>
<br>
Step4: If you want to show a map according to your own habits, you can change <br>
the options in Show a Map area. For an instance, you can change the zoom level<br>
and set both Latitude and Longitude in the accordingly TextBox.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a VB.NET ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step2: Add a Default ASP.NET page into the application.<br>
<br>
Step3: Add a table to the page with two cells in a row. The left cell is for<br>
Bing Maps and the right cell is for more options and a search block.<br>
<br>
Step4: Add a Panel named pnlBingMap in the left cell. Also, it doesn't matter<br>
if you are using a div whose id is pnlBingMap as the panel will be rendered <br>
as a div when the page runs anyway.<br>
<br>
Step5: Create an option and a search block in the right cell. You can follow <br>
the sample or even copy the code to finish this HTML coding work.<br>
<br>
Step6: Add Bing Maps JavaScript API link to the page. The number 6.3 in the <br>
querystring stands for the API verion. It may be changed when you are tesing <br>
this sample. For a latest version, please refer to link: <br>
<a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/maps/developers/">http://www.microsoft.com/maps/developers/</a>.'&gt;<a target="_blank" href="http://www.microsoft.com/maps/developers/">http://www.microsoft.com/maps/developers/</a>.<br>
<br>
&lt;script type=&quot;text/javascript&quot; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;src=&quot;<a target="_blank" href="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.3&quot;&gt;">http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.3&quot;&gt;</a><br>
&lt;/script&gt;<br>
<br>
Step7: Create LoadMap funcion and call it when the page loads.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;function LoadMap() {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map = new VEMap('pnlBingMap');<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var LA = new VELatLong(34.0540, -118.2370);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map.LoadMap(LA, 12, style, false, VEMapMode.Mode2D, true, 1);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
NOTE: VEMap is a class defined in the Bing Map API. It achieves almost all<br>
what we need to operate the map like loading a map, changing map options or <br>
adding new shapes and pushpins to the map.<br>
<br>
Step8: Create the FindLoc() function and bind it to the click event of the<br>
Submit button in the search block.<br>
<br>
&nbsp; &nbsp;function FindLoc() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;var loc = document.getElementById(&quot;txtLocation&quot;).value;<br>
&nbsp; &nbsp; &nbsp; &nbsp;try {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;map.Find(null, loc);<br>
&nbsp; &nbsp; &nbsp; &nbsp;} catch (e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;alert(e.message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step9: Create the SetMap() function and make the Submit button in the Show a <br>
Map block link to it.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;function SetMap() {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var lat = document.getElementById(&quot;txtLatitude&quot;).value;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var lng = document.getElementById(&quot;txtLongitude&quot;).value;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (lng == &quot;&quot; | lat == &quot;&quot;) {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(&quot;You need to input both Latitude and Longitude first.&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var ddlzoom = document.getElementById(&quot;ddlZoomLevel&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var zoom = ddlzoom.options[ddlzoom.selectedIndex].value;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map.SetCenter(new VELatLong(lat, lng));<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map.SetMapStyle(style);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map.SetZoomLevel(zoom);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Bing Maps<br>
# Bing Maps Platform - AJAX Map Control Interactive SDK<br>
<a target="_blank" href="http://www.microsoft.com/maps/isdk/ajax/">http://www.microsoft.com/maps/isdk/ajax/</a><br>
<br>
Bing Maps<br>
# Developers Getting Start<br>
<a target="_blank" href="http://www.microsoft.com/maps/developers/">http://www.microsoft.com/maps/developers/</a><br>
<br>
MSDN:<br>
# VEMap Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb429586.aspx">http://msdn.microsoft.com/en-us/library/bb429586.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
