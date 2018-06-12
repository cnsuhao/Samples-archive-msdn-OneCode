# Use XPath to read XML (VBXPath)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* XML
## Topics
* Xpath
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:12:08
## Description

<h2><span style="font-size:14.0pt; line-height:115%">CONSOLE APPLICATION </span><span style="font-size:14.0pt; line-height:115%">(</span><span style="font-size:14.0pt; line-height:115%">VBXPath</span><span style="font-size:14.0pt; line-height:115%">)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample project shows how to use XPathDocument class to load the XML file<span style="">
</span>and manipulate. It includes two main parts, XPathNavigator usage and XPath<span style="">
</span>Expression usage. The first part shows how to use XPathNavigator to navigate through the whole document, read its content. The second part shows how to use<span style="">
</span>XPath expression to filter information.<span style="">&nbsp; </span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53708/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<h3><span style="">Initialize XPathDocument and XPathNavigator instances </span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim xPathNavigator As XPathNavigator
Dim xPathDoc As XPathDocument


' Navigate through the whole document.
' Create a new instance of XPathDocument from a XML file.
xPathDoc = New XPathDocument(&quot;books.xml&quot;)


' Call CreateNavigator method to create a navigator instance.
' And we will use this navigator object to navigate through whole document.
xPathNavigator = xPathDoc.CreateNavigator()

</pre>
<pre id="codePreview" class="vb">
Dim xPathNavigator As XPathNavigator
Dim xPathDoc As XPathDocument


' Navigate through the whole document.
' Create a new instance of XPathDocument from a XML file.
xPathDoc = New XPathDocument(&quot;books.xml&quot;)


' Call CreateNavigator method to create a navigator instance.
' And we will use this navigator object to navigate through whole document.
xPathNavigator = xPathDoc.CreateNavigator()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<h3><span style="">Call MoveToRoot and MoveToFirstChild to navigate to the book elements
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
xPathNavigator.MoveToRoot()
' Catalog element is the first children of the root.
' Move to catalog element.
xPathNavigator.MoveToFirstChild()
' We can know a XML node's type from the NodeType property.
' XPathNodeType has Attribute, Element, Namespace and so on.
If xPathNavigator.NodeType = XPathNodeType.Element Then
   ' We can know if a Node has child nodes by checking its
   ' HasChildren property. If it returns true, that node has child nodes.
   If xPathNavigator.HasChildren = True Then
      ' Move to the first child which is our first book nodes.
      xPathNavigator.MoveToFirstChild()
   End If
End If

</pre>
<pre id="codePreview" class="vb">
xPathNavigator.MoveToRoot()
' Catalog element is the first children of the root.
' Move to catalog element.
xPathNavigator.MoveToFirstChild()
' We can know a XML node's type from the NodeType property.
' XPathNodeType has Attribute, Element, Namespace and so on.
If xPathNavigator.NodeType = XPathNodeType.Element Then
   ' We can know if a Node has child nodes by checking its
   ' HasChildren property. If it returns true, that node has child nodes.
   If xPathNavigator.HasChildren = True Then
      ' Move to the first child which is our first book nodes.
      xPathNavigator.MoveToFirstChild()
   End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Loop through all books and thier children nodes. Output author, title, genre, price, publish_date, description information for each book.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Do
   ' We can know if a node has any attribute by checking
   ' the HasAttributes property. When this property returns
   ' true, we can get the specified attribute by calling
   ' navigator.GetAttribute() method.
   If xPathNavigator.HasAttributes = True Then
      Console.WriteLine(&quot;Book ID: &quot; & xPathNavigator.GetAttribute(&quot;id&quot;, &quot;&quot;))
   End If


   ' Iterate through a book node's child nodes
   ' and list all child node information, like 
   ' name, author, price, publish date and so on.
   If xPathNavigator.HasChildren Then
      xPathNavigator.MoveToFirstChild()
      Do
         Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, xPathNavigator.Name, xPathNavigator.Value)
      Loop While xPathNavigator.MoveToNext()
      ' When all child nodes are reached. The MoveToNext() method returns
      ' false. Then we need to call MoveToParent to go back to the book level.
         xPathNavigator.MoveToParent()
      End If
      ' Move to the next book element.
Loop While xPathNavigator.MoveToNext()

</pre>
<pre id="codePreview" class="vb">
Do
   ' We can know if a node has any attribute by checking
   ' the HasAttributes property. When this property returns
   ' true, we can get the specified attribute by calling
   ' navigator.GetAttribute() method.
   If xPathNavigator.HasAttributes = True Then
      Console.WriteLine(&quot;Book ID: &quot; & xPathNavigator.GetAttribute(&quot;id&quot;, &quot;&quot;))
   End If


   ' Iterate through a book node's child nodes
   ' and list all child node information, like 
   ' name, author, price, publish date and so on.
   If xPathNavigator.HasChildren Then
      xPathNavigator.MoveToFirstChild()
      Do
         Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, xPathNavigator.Name, xPathNavigator.Value)
      Loop While xPathNavigator.MoveToNext()
      ' When all child nodes are reached. The MoveToNext() method returns
      ' false. Then we need to call MoveToParent to go back to the book level.
         xPathNavigator.MoveToParent()
      End If
      ' Move to the next book element.
Loop While xPathNavigator.MoveToNext()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use XPath Expression to select out the book with ID bk103 and output its detailed information.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Use XPath Expression to select out the book with ID bk103:&quot;)
          Dim expression As XPathExpression = xPathNavigator.Compile(&quot;/catalog/book[@id='bk103']&quot;)
          Dim iterator As XPathNodeIterator = xPathNavigator.Select(expression)


          ' After compile the XPath expression, we can call navigator.Select
          ' to retrieve the XPathNodeIterator. With this interator, we can loop
          ' trough the results filtered by the XPath expression.
          ' The following codes print the book bk103's detailed information.
          Do While iterator.MoveNext()
              Dim nav As XPathNavigator = iterator.Current.Clone()
              Console.WriteLine(&quot;Book ID: &quot; & nav.GetAttribute(&quot;id&quot;, &quot;&quot;))
              If nav.HasChildren Then
                  nav.MoveToFirstChild()
                  Do
                      Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                  Loop While nav.MoveToNext()
              End If
          Loop

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(&quot;Use XPath Expression to select out the book with ID bk103:&quot;)
          Dim expression As XPathExpression = xPathNavigator.Compile(&quot;/catalog/book[@id='bk103']&quot;)
          Dim iterator As XPathNodeIterator = xPathNavigator.Select(expression)


          ' After compile the XPath expression, we can call navigator.Select
          ' to retrieve the XPathNodeIterator. With this interator, we can loop
          ' trough the results filtered by the XPath expression.
          ' The following codes print the book bk103's detailed information.
          Do While iterator.MoveNext()
              Dim nav As XPathNavigator = iterator.Current.Clone()
              Console.WriteLine(&quot;Book ID: &quot; & nav.GetAttribute(&quot;id&quot;, &quot;&quot;))
              If nav.HasChildren Then
                  nav.MoveToFirstChild()
                  Do
                      Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                  Loop While nav.MoveToNext()
              End If
          Loop

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use XPath Expression to select out all books whose price are more than 10.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Do While iterator.MoveNext()
              Dim nav As XPathNavigator = iterator.Current.Clone()
              Console.WriteLine(&quot;Book ID: &quot; & nav.GetAttribute(&quot;id&quot;, &quot;&quot;))
              If nav.HasChildren Then
                  nav.MoveToFirstChild()
                  Do
                      If nav.Name = &quot;title&quot; Then
                          Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                      End If
                      If nav.Name = &quot;price&quot; Then
                          Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                      End If
                  Loop While nav.MoveToNext()
              End If
          Loop

</pre>
<pre id="codePreview" class="vb">
Do While iterator.MoveNext()
              Dim nav As XPathNavigator = iterator.Current.Clone()
              Console.WriteLine(&quot;Book ID: &quot; & nav.GetAttribute(&quot;id&quot;, &quot;&quot;))
              If nav.HasChildren Then
                  nav.MoveToFirstChild()
                  Do
                      If nav.Name = &quot;title&quot; Then
                          Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                      End If
                      If nav.Name = &quot;price&quot; Then
                          Console.Write(vbTab & &quot;{0}:&quot; & vbTab & &quot;{1}&quot; & vbCrLf, nav.Name, nav.Value)
                      End If
                  Loop While nav.MoveToNext()
              End If
          Loop

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use XPath Expression to calculate the average price of all books.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(vbCrLf & &quot;Use XPath Expression to calculate the average price of all books:&quot;)
expression = xPathNavigator.Compile(&quot;sum(/catalog/book/price) div count(/catalog/book/price)&quot;)
Dim averagePrice As String = xPathNavigator.Evaluate(expression).ToString()
Console.WriteLine(&quot;The average price of the books are {0}&quot;, averagePrice)

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(vbCrLf & &quot;Use XPath Expression to calculate the average price of all books:&quot;)
expression = xPathNavigator.Compile(&quot;sum(/catalog/book/price) div count(/catalog/book/price)&quot;)
Dim averagePrice As String = xPathNavigator.Evaluate(expression).ToString()
Console.WriteLine(&quot;The average price of the books are {0}&quot;, averagePrice)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://support.microsoft.com/kb/301111/en-us">How to navigate XML with the XPathNavigator class by using VB.NET.</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
