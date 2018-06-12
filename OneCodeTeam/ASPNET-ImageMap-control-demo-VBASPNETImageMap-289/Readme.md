# ASP.NET ImageMap control demo (VBASPNETImageMap)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* ImageMap
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:32:04
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETImageMap Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to use ImageMap to create an introduction of <br>
&nbsp;the planets in Solar System via VB.NET language. When the planet in the <br>
&nbsp;image is clicked, the brief information of this planet will be displayed<br>
&nbsp;under the image and the iframe will navigate to the corresponding page in<br>
&nbsp;WikiPedia. <br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Basic ASP.NET Web Application in Visual Studio 2008 /<br>
Visual Web Developer and name it as VBASPNETImageMap.<br>
<br>
Step2. Add an ImageMap control into the page and change its ID property to<br>
imgMapSolarSystem.<br>
<br>
[NOTE] ImageMap can contain defined hotspot regions. When a user clicks a <br>
hot spot region, the control can either generate a post back to the server <br>
or navigate to a specified URL. This demo is made to generate a post back <br>
to the server and run specific code based on the hot spot region that was <br>
clicked from the ImageMap control. For an example illustrating navigating <br>
to different URLs, please refer to the following code and pay attention to<br>
the NavigateUrl property in the RectangleHotSpot tag:<br>
<br>
&lt;asp:ImageMap ID=&quot;ImageMap4Navigate&quot; ImageUrl=&quot;image.jpg&quot; runat=&quot;Server&quot;&gt;<br>
&nbsp; &nbsp;&lt;asp:RectangleHotSpot HotSpotMode=&quot;Navigate&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NavigateUrl=&quot;navigate1.htm&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AlternateText=&quot;Button 1&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Top=&quot;20&quot; Left=&quot;200&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Bottom=&quot;100&quot; Right=&quot;300&quot;&gt;<br>
&nbsp; &nbsp;&lt;/asp:RectangleHotSpot&gt;<br>
&lt;/asp:ImageMap&gt; <br>
<br>
Step3: Step3: Please copy the code here and paste it into the page, between<br>
the form tags. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ImageMap ID=&quot;imgMapSolarSystem&quot; runat=&quot;server&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ImageUrl=&quot;~/solarsystem.jpg&quot; HotSpotMode=&quot;PostBack&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:RectangleHotSpot PostBackValue=&quot;Sun&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AlternateText=&quot;Sun&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Top=&quot;0&quot; Left=&quot;0&quot; Right=&quot;110&quot; Bottom=&quot;258&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Mercury&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Mercury&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;189&quot; Y=&quot;172&quot; Radius=&quot;3&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Venus&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Venus&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;227&quot; Y=&quot;172&quot; Radius=&quot;10&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Earth&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Earth&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;277&quot; Y=&quot;172&quot; Radius=&quot;10&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Mars&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Mars&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;324&quot; Y=&quot;172&quot; Radius=&quot;8&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Jupiter&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Jupiter&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;410&quot; Y=&quot;172&quot; Radius=&quot;55&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:PolygonHotSpot PostBackValue=&quot;Saturn&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AlternateText=&quot;Saturn&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Coordinates=&quot;492,235,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 471,228,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 522,179,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 540,133,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 581,126,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 593,134,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 657,110,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 660,126,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 615,167,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 608,203,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 563,219,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 542,214&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Uranus&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Uranus&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;667&quot; Y=&quot;172&quot; Radius=&quot;21&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:CircleHotSpot PostBackValue=&quot;Neptune&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AlternateText=&quot;Neptune&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; X=&quot;736&quot; Y=&quot;172&quot; Radius=&quot;18&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HotSpotMode=&quot;PostBack&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:ImageMap&gt;<br>
<br>
[NOTE] There are three kinds of hot spots in the ImageMap control. They are<br>
RectangleHotSpot, CircleHotSpot and PolygonHotSpot. As the name implies, <br>
the RectangleHotSpot defines rectangular hot spot regions. The CircleHotSpots<br>
defines circle-shaped ones and the PolygonHotSpot is use for irregularly <br>
shaped hot spot area.<br>
To define the region of the RectangleHotSpot object, use the Left, Top, Right<br>
and Bottom property to represent the coordinate of the region itself. For the<br>
CircleHotSpot object, set the X and the Y property to the coordinate of the <br>
centre of the circle. Then set the Radius property to the distance from the <br>
center to the edge. To define the region of a PolygonHotSpot, set the <br>
Coordinates property to a string that specifies the coordinates of each vertex<br>
of the PolygonHotSpot object. A polygon vertex is a point at which two polygon<br>
edges meet. <br>
For more information about these three hot spots, please refer to the links in<br>
References part.<br>
<br>
Step4: Double-click the ImageMap control in page's Designer View to open the <br>
Code-Behind page in Visual Basic .NET language.<br>
<br>
Step5: Locate the code into the imgMapSolarSystem_Click event handler and use<br>
Select Case to create different behaviors according to the PostBackValue.<br>
<br>
[NOTE] To make the hot spot generate postback to the server, set the <br>
HotSpotMode property to Postback and use the PostBackValue property to specify <br>
a name for the region. This name will be passed in the ImageMapEventArgs event <br>
data when postback occurs. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: ImageMap Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.imagemap.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.imagemap.aspx</a><br>
<br>
MSDN: RectangleHotSpot Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.rectanglehotspot.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.rectanglehotspot.aspx</a><br>
<br>
MSDN: CircleHotSpot Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.circlehotspot.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.circlehotspot.aspx</a><br>
<br>
MSDN: PolygonHotSpot Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.polygonhotspot.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.polygonhotspot.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
