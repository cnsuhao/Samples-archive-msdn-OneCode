# Use XPath to read XML (CSXPath)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* XML
## Topics
* Xpath
## IsPublished
* True
## ModifiedDate
* 2012-11-27 08:38:50
## Description

<h2><span style="font-size:14.0pt; line-height:115%">CONSOLE APPLICATION </span><span style="font-size:14.0pt; line-height:115%">(</span><span style="font-size:14.0pt; line-height:115%">CSXPath</span><span style="font-size:14.0pt; line-height:115%">)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample project shows how to use XPathDocument class to load the XML file<span style="">
</span>and manipulate. It includes two main parts, <span class="SpellE">XPathNavigator</span> usage and
<span class="SpellE">XPath</span><span style=""> </span>Expression usage. The first part shows how to use
<span class="SpellE">XPathNavigator</span> to navigate through the whole document, read its content. The second part shows how to use<span style="">
</span><span class="SpellE">XPath</span> expression to filter information.<span style="">&nbsp;
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71345/1/image.png" alt="" width="576" height="546" align="middle">
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<h3><span style="">Initialize XPathDocument and XPathNavigator instances </span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
XPathNavigator xPathNavigator;
XPathDocument xPathDoc;


// Navigate through the whole document.
// Create a new instance of XPathDocument from a XML file.
xPathDoc = new XPathDocument(&quot;books.xml&quot;);


// Call CreateNavigator method to create a navigator instance.
// And we will use this navigator object to navigate through whole document.
xPathNavigator = xPathDoc.CreateNavigator();

</pre>
<pre id="codePreview" class="csharp">
XPathNavigator xPathNavigator;
XPathDocument xPathDoc;


// Navigate through the whole document.
// Create a new instance of XPathDocument from a XML file.
xPathDoc = new XPathDocument(&quot;books.xml&quot;);


// Call CreateNavigator method to create a navigator instance.
// And we will use this navigator object to navigate through whole document.
xPathNavigator = xPathDoc.CreateNavigator();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<h3><span style="">Call <span class="SpellE">MoveToRoot</span> and <span class="SpellE">
MoveToFirstChild</span> to navigate to the book elements </span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Move to the root element.
           xPathNavigator.MoveToRoot();
           // Catalog element is the first children of the root.
           // Move to catalog element.
           xPathNavigator.MoveToFirstChild();
           // We can know a XML node's type from the NodeType property.
           // XPathNodeType has Attribute, Element, Namespace and so on.
           if (xPathNavigator.NodeType == XPathNodeType.Element)
           {
               // We can know if a Node has child nodes by checking its
               // HasChildren property. If it returns true, that node has child nodes.
               if (xPathNavigator.HasChildren == true)
               {
                   // Move to the first child which is our first book nodes.
                   xPathNavigator.MoveToFirstChild();
               }
           }

</pre>
<pre id="codePreview" class="csharp">
// Move to the root element.
           xPathNavigator.MoveToRoot();
           // Catalog element is the first children of the root.
           // Move to catalog element.
           xPathNavigator.MoveToFirstChild();
           // We can know a XML node's type from the NodeType property.
           // XPathNodeType has Attribute, Element, Namespace and so on.
           if (xPathNavigator.NodeType == XPathNodeType.Element)
           {
               // We can know if a Node has child nodes by checking its
               // HasChildren property. If it returns true, that node has child nodes.
               if (xPathNavigator.HasChildren == true)
               {
                   // Move to the first child which is our first book nodes.
                   xPathNavigator.MoveToFirstChild();
               }
           }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Loop through all books and thier children nodes. <span class="GramE">
Output author, title, genre, price, publish_date, description information for each book.</span>
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
do
{
    // We can know if a node has any attribute by checking
    // the HasAttributes property. When this property returns
    // true, we can get the specified attribute by calling
    // navigator.GetAttribute() method.
    if (xPathNavigator.HasAttributes == true)
    {
        Console.WriteLine(&quot;Book ID: &quot; &#43; xPathNavigator.GetAttribute(&quot;id&quot;, &quot;&quot;));
    }


    // Iterate through a book node's child nodes
    // and list all child node information, like 
    // name, author, price, publish date and so on.
    if (xPathNavigator.HasChildren)
    {
        xPathNavigator.MoveToFirstChild();
        do
        {
            Console.Write(&quot;\t{0}:\t{1}\r\n&quot;, xPathNavigator.Name, xPathNavigator.Value);
        } while (xPathNavigator.MoveToNext());
        // When all child nodes are reached. The MoveToNext() method returns
        // false. Then we need to call MoveToParent to go back to the book level.
        xPathNavigator.MoveToParent();
    }
    // Move to the next book element.
} while (xPathNavigator.MoveToNext());

</pre>
<pre id="codePreview" class="csharp">
do
{
    // We can know if a node has any attribute by checking
    // the HasAttributes property. When this property returns
    // true, we can get the specified attribute by calling
    // navigator.GetAttribute() method.
    if (xPathNavigator.HasAttributes == true)
    {
        Console.WriteLine(&quot;Book ID: &quot; &#43; xPathNavigator.GetAttribute(&quot;id&quot;, &quot;&quot;));
    }


    // Iterate through a book node's child nodes
    // and list all child node information, like 
    // name, author, price, publish date and so on.
    if (xPathNavigator.HasChildren)
    {
        xPathNavigator.MoveToFirstChild();
        do
        {
            Console.Write(&quot;\t{0}:\t{1}\r\n&quot;, xPathNavigator.Name, xPathNavigator.Value);
        } while (xPathNavigator.MoveToNext());
        // When all child nodes are reached. The MoveToNext() method returns
        // false. Then we need to call MoveToParent to go back to the book level.
        xPathNavigator.MoveToParent();
    }
    // Move to the next book element.
} while (xPathNavigator.MoveToNext());

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use XPath Expression to select out the book with ID bk103 and output its detailed information.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Use XPath Expression to select out book bk103.
           // The expression should be &quot;/catalog/book[@id='bk103']&quot;
           // @ means to look id attribute and match bk103.
           Console.WriteLine(&quot;Use XPath Expression to select out the book with ID bk103:&quot;);
           XPathExpression expression = xPathNavigator.Compile(&quot;/catalog/book[@id='bk103']&quot;);
           XPathNodeIterator iterator = xPathNavigator.Select(expression);


           // After compile the XPath expression, we can call navigator.Select
           // to retrieve the XPathNodeIterator. With this interator, we can loop
           // trough the results filtered by the XPath expression.
           // The following codes print the book bk103's detailed information.
           while (iterator.MoveNext())
           {
               XPathNavigator nav = iterator.Current.Clone();
               Console.WriteLine(&quot;Book ID: &quot; &#43; nav.GetAttribute(&quot;id&quot;, &quot;&quot;));
               if (nav.HasChildren)
               {
                   nav.MoveToFirstChild();
                   do
                   {
                       Console.Write(&quot;\t{0}:\t{1}\r\n&quot;, nav.Name, nav.Value);
                   } while (nav.MoveToNext());
               }
           }





</pre>
<pre id="codePreview" class="csharp">
// Use XPath Expression to select out book bk103.
           // The expression should be &quot;/catalog/book[@id='bk103']&quot;
           // @ means to look id attribute and match bk103.
           Console.WriteLine(&quot;Use XPath Expression to select out the book with ID bk103:&quot;);
           XPathExpression expression = xPathNavigator.Compile(&quot;/catalog/book[@id='bk103']&quot;);
           XPathNodeIterator iterator = xPathNavigator.Select(expression);


           // After compile the XPath expression, we can call navigator.Select
           // to retrieve the XPathNodeIterator. With this interator, we can loop
           // trough the results filtered by the XPath expression.
           // The following codes print the book bk103's detailed information.
           while (iterator.MoveNext())
           {
               XPathNavigator nav = iterator.Current.Clone();
               Console.WriteLine(&quot;Book ID: &quot; &#43; nav.GetAttribute(&quot;id&quot;, &quot;&quot;));
               if (nav.HasChildren)
               {
                   nav.MoveToFirstChild();
                   do
                   {
                       Console.Write(&quot;\t{0}:\t{1}\r\n&quot;, nav.Name, nav.Value);
                   } while (nav.MoveToNext());
               }
           }





</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use <span class="SpellE">XPath</span> Expression to select out all books whose price
<span class="GramE">are</span> more than 10. </span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Use XPath to select out all books whose price are more than 10.00
// '[]' means to look into the child node to match the condition &quot;price &gt; 10&quot;.
Console.WriteLine(&quot;\r\nUse XPath Expression to select out all books whose price are more than 10:&quot;);
expression = xPathNavigator.Compile(&quot;/catalog/book[price&gt;10]&quot;);
iterator = xPathNavigator.Select(expression);

</pre>
<pre id="codePreview" class="csharp">
// Use XPath to select out all books whose price are more than 10.00
// '[]' means to look into the child node to match the condition &quot;price &gt; 10&quot;.
Console.WriteLine(&quot;\r\nUse XPath Expression to select out all books whose price are more than 10:&quot;);
expression = xPathNavigator.Compile(&quot;/catalog/book[price&gt;10]&quot;);
iterator = xPathNavigator.Select(expression);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use <span class="SpellE">XPath</span> Expression to calculate the average price of all books.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Use XPath Expression to calculate the average price of all books.
// Here in XPath, we use the sum, div, and count formula.
Console.WriteLine(&quot;\r\nUse XPath Expression to calculate the average price of all books:&quot;);
expression = xPathNavigator.Compile(&quot;sum(/catalog/book/price) div count(/catalog/book/price)&quot;);
string averagePrice = xPathNavigator.Evaluate(expression).ToString();
Console.WriteLine(&quot;The average price of the books are {0}&quot;, averagePrice);

</pre>
<pre id="codePreview" class="csharp">
// Use XPath Expression to calculate the average price of all books.
// Here in XPath, we use the sum, div, and count formula.
Console.WriteLine(&quot;\r\nUse XPath Expression to calculate the average price of all books:&quot;);
expression = xPathNavigator.Compile(&quot;sum(/catalog/book/price) div count(/catalog/book/price)&quot;);
string averagePrice = xPathNavigator.Evaluate(expression).ToString();
Console.WriteLine(&quot;The average price of the books are {0}&quot;, averagePrice);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://support.microsoft.com/kb/308343">How to navigate XML with the XPathNavigator class by using C#</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://support.microsoft.com/kb/308333">How to query XML with an XPath expression by using C#</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
