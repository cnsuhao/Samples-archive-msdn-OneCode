# How to boost performance on Dynamics NAV RTC reports
## Requires
* 
## License
* MS-LPL
## Technologies
* Dynamics
## Topics
* NAV
* RTC reports
## IsPublished
* True
## ModifiedDate
* 2011-11-02 01:31:25
## Description

<h1>How to boost performance on Dynamics NAV RTC reports: Report 1001, Inventory Valuation (Dynamics NAV: Inventory Valuation for RTC: example of how to boost performance)</h1>
<h2>Introduction</h2>
<div>This sample is an example that illustrates how to boost performance on RTC reports. This applies to reports that are printing confined record sets (normally anything under several thousands). The attached object shows how to correctly structure the report,
 where possible, so as to avoid sending any records that will not show at the print/preview on RTC.</div>
<div>&nbsp;</div>
<div>In this example, report 1001 is modified so the dataitem used for calculation and print of footer values only (Value Entry) is removed. Footer is replaced with separate dataitem of type integer, and calculation of the values it will show is done in OnAfterGetRecord
 trigger of the parenting dataitem.</div>
<h2><span>Building the Sample</span></h2>
<div>To implement the sample, you need to import the attached object (.txt format) into Dynamics NAV 2009 R2 C/Side environment.</div>
<div>&nbsp;<br>
Note that importing this object will replace your existing 1001&nbsp; object and all changes made to it, so either take a backup of existing object or modify the object number and name from the attached file to a free number series and custom name.</div>
<h2><span style="font-size:medium; font-weight:bold">Running the Sample</span></h2>
<div>Imported object must be recompiled before running in Dynamics NAV RTC client.</div>
<h2>Using the Code</h2>
<div>The code snippet shown demonstrates how to replace dataitem (in this example: Value Entry) used for its footer section only, and calculations done there, with coded calculation in parenting dataitem (Item).</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C/AL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">- C/AL code snippet -
 
Item - OnAfterGetRecord()
 
//initialize variables used for displaying summarized values
CALCFIELDS(&quot;Bill of Materials&quot;);
InvandShipDiffer := FALSE;
 
VLEFInvQty := 0;
VLEFCostAmtAct := 0;
VLEFILEQty := 0;
TmpVETbl.DELETEALL;
 
//loop value entries for each item an summarize values in global 
//variables that are displayed as footer
VLE.SETCURRENTKEY(&quot;Item No.&quot;,&quot;Posting Date&quot;,&quot;Item Ledger Entry Type&quot;);
VLE.SETRANGE(&quot;Item No.&quot;,Item.&quot;No.&quot;);
VLE.SETFILTER(&quot;Variant Code&quot;,Item.GETFILTER(&quot;Variant Filter&quot;));
VLE.SETFILTER(&quot;Location Code&quot;,Item.GETFILTER(&quot;Location Filter&quot;));
VLE.SETFILTER(&quot;Global Dimension 1 Code&quot;,Item.GETFILTER(&quot;Global Dimension 1 Filter&quot;));
VLE.SETFILTER(&quot;Global Dimension 2 Code&quot;,Item.GETFILTER(&quot;Global Dimension 2 Filter&quot;));
IF EndDate &lt;&gt; 0D THEN
VLE.SETRANGE(&quot;Posting Date&quot;,0D,EndDate);
 
IF VLE.FINDSET THEN BEGIN
REPEAT
 
QtyOnHand := 0;
RcdIncreases := 0;
ShipDecreases := 0;
ValueOfQtyOnHand := 0;
ValueOfInvoicedQty := 0;
InvoicedQty := 0;
 
ValueOfRcdIncreases := 0;
ValueOfInvIncreases := 0;
InvIncreases := 0;
 
CostOfShipDecreases := 0;
CostOfInvDecreases := 0;
InvDecreases := 0;
 
IsPositive := GetSign;
IF VLE.&quot;Item Ledger Entry Quantity&quot; &lt;&gt; 0 THEN BEGIN
  IF VLE.&quot;Posting Date&quot; &lt; StartDate THEN
    QtyOnHand := VLE.&quot;Item Ledger Entry Quantity&quot;
  ELSE BEGIN
    IF IsPositive THEN
      RcdIncreases := VLE.&quot;Item Ledger Entry Quantity&quot;
    ELSE
      ShipDecreases := -VLE.&quot;Item Ledger Entry Quantity&quot;;
  END;
END;
 
IF VLE.&quot;Posting Date&quot; &lt; StartDate THEN
  SetAmount(ValueOfQtyOnHand,ValueOfInvoicedQty,InvoicedQty,1)
ELSE BEGIN
  IF IsPositive THEN
    SetAmount(ValueOfRcdIncreases,ValueOfInvIncreases,InvIncreases,1)
  ELSE
    SetAmount(CostOfShipDecreases,CostOfInvDecreases,InvDecreases,-1);
END;
 
ValueOfQtyOnHand := ValueOfQtyOnHand &#43; ValueOfInvoicedQty;
ValueOfRcdIncreases := ValueOfRcdIncreases &#43; ValueOfInvIncreases;
CostOfShipDecreases := CostOfShipDecreases &#43; CostOfInvDecreases;
 
ExpCostPostedToGL := VLE.&quot;Expected Cost Posted to G/L&quot;;
InvCostPostedToGL := VLE.&quot;Cost Posted to G/L&quot;;
CostPostedToGL := ExpCostPostedToGL &#43; InvCostPostedToGL;
SumTotals;
UNTIL VLE.NEXT=0;
TmpVETbl.TRANSFERFIELDS(VLE);
TmpVETbl.INSERT;
END;
 
- end -</pre>
<div class="preview">
<pre class="mysql">-&nbsp;<span class="sql__id">C</span>/<span class="sql__id">AL</span>&nbsp;<span class="sql__keyword">code</span>&nbsp;<span class="sql__id">snippet</span>&nbsp;-&nbsp;
&nbsp;&nbsp;
<span class="sql__id">Item</span>&nbsp;-&nbsp;<span class="sql__id">OnAfterGetRecord</span>()&nbsp;
&nbsp;&nbsp;
//<span class="sql__id">initialize</span>&nbsp;<span class="sql__keyword">variables</span>&nbsp;<span class="sql__id">used</span>&nbsp;<span class="sql__keyword">for</span>&nbsp;<span class="sql__id">displaying</span>&nbsp;<span class="sql__id">summarized</span>&nbsp;<span class="sql__keyword">values</span>&nbsp;
<span class="sql__id">CALCFIELDS</span>(<span class="sql__string">&quot;Bill&nbsp;of&nbsp;Materials&quot;</span>);&nbsp;
<span class="sql__id">InvandShipDiffer</span>&nbsp;:=&nbsp;<span class="sql__value">FALSE</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">VLEFInvQty</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">VLEFCostAmtAct</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">VLEFILEQty</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">TmpVETbl</span>.<span class="sql__id">DELETEALL</span>;&nbsp;
&nbsp;&nbsp;
//<span class="sql__keyword">loop</span>&nbsp;<span class="sql__keyword">value</span>&nbsp;<span class="sql__id">entries</span>&nbsp;<span class="sql__keyword">for</span>&nbsp;<span class="sql__keyword">each</span>&nbsp;<span class="sql__id">item</span>&nbsp;<span class="sql__id">an</span>&nbsp;<span class="sql__id">summarize</span>&nbsp;<span class="sql__keyword">values</span>&nbsp;<span class="sql__keyword">in</span>&nbsp;<span class="sql__keyword">global</span>&nbsp;&nbsp;
//<span class="sql__keyword">variables</span>&nbsp;<span class="sql__id">that</span>&nbsp;<span class="sql__id">are</span>&nbsp;<span class="sql__id">displayed</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__id">footer</span>&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETCURRENTKEY</span>(<span class="sql__string">&quot;Item&nbsp;No.&quot;</span>,<span class="sql__string">&quot;Posting&nbsp;Date&quot;</span>,<span class="sql__string">&quot;Item&nbsp;Ledger&nbsp;Entry&nbsp;Type&quot;</span>);&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETRANGE</span>(<span class="sql__string">&quot;Item&nbsp;No.&quot;</span>,<span class="sql__id">Item</span>.<span class="sql__string">&quot;No.&quot;</span>);&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETFILTER</span>(<span class="sql__string">&quot;Variant&nbsp;Code&quot;</span>,<span class="sql__id">Item</span>.<span class="sql__id">GETFILTER</span>(<span class="sql__string">&quot;Variant&nbsp;Filter&quot;</span>));&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETFILTER</span>(<span class="sql__string">&quot;Location&nbsp;Code&quot;</span>,<span class="sql__id">Item</span>.<span class="sql__id">GETFILTER</span>(<span class="sql__string">&quot;Location&nbsp;Filter&quot;</span>));&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETFILTER</span>(<span class="sql__string">&quot;Global&nbsp;Dimension&nbsp;1&nbsp;Code&quot;</span>,<span class="sql__id">Item</span>.<span class="sql__id">GETFILTER</span>(<span class="sql__string">&quot;Global&nbsp;Dimension&nbsp;1&nbsp;Filter&quot;</span>));&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETFILTER</span>(<span class="sql__string">&quot;Global&nbsp;Dimension&nbsp;2&nbsp;Code&quot;</span>,<span class="sql__id">Item</span>.<span class="sql__id">GETFILTER</span>(<span class="sql__string">&quot;Global&nbsp;Dimension&nbsp;2&nbsp;Filter&quot;</span>));&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">EndDate</span>&nbsp;&lt;&gt;&nbsp;<span class="sql__id">0D</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;
<span class="sql__id">VLE</span>.<span class="sql__id">SETRANGE</span>(<span class="sql__string">&quot;Posting&nbsp;Date&quot;</span>,<span class="sql__id">0D</span>,<span class="sql__id">EndDate</span>);&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">VLE</span>.<span class="sql__id">FINDSET</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
<span class="sql__keyword">REPEAT</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__id">QtyOnHand</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">RcdIncreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">ShipDecreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">ValueOfQtyOnHand</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">ValueOfInvoicedQty</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">InvoicedQty</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">ValueOfRcdIncreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">ValueOfInvIncreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">InvIncreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">CostOfShipDecreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">CostOfInvDecreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">InvDecreases</span>&nbsp;:=&nbsp;<span class="sql__number">0</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">IsPositive</span>&nbsp;:=&nbsp;<span class="sql__id">GetSign</span>;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Item&nbsp;Ledger&nbsp;Entry&nbsp;Quantity&quot;</span>&nbsp;&lt;&gt;&nbsp;<span class="sql__number">0</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Posting&nbsp;Date&quot;</span>&nbsp;&lt;&nbsp;<span class="sql__id">StartDate</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">QtyOnHand</span>&nbsp;:=&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Item&nbsp;Ledger&nbsp;Entry&nbsp;Quantity&quot;</span>&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">ELSE</span>&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">IsPositive</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">RcdIncreases</span>&nbsp;:=&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Item&nbsp;Ledger&nbsp;Entry&nbsp;Quantity&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ELSE</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">ShipDecreases</span>&nbsp;:=&nbsp;-<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Item&nbsp;Ledger&nbsp;Entry&nbsp;Quantity&quot;</span>;&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">END</span>;&nbsp;
<span class="sql__keyword">END</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Posting&nbsp;Date&quot;</span>&nbsp;&lt;&nbsp;<span class="sql__id">StartDate</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;
&nbsp;&nbsp;<span class="sql__id">SetAmount</span>(<span class="sql__id">ValueOfQtyOnHand</span>,<span class="sql__id">ValueOfInvoicedQty</span>,<span class="sql__id">InvoicedQty</span>,<span class="sql__number">1</span>)&nbsp;
<span class="sql__keyword">ELSE</span>&nbsp;<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">IsPositive</span>&nbsp;<span class="sql__keyword">THEN</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">SetAmount</span>(<span class="sql__id">ValueOfRcdIncreases</span>,<span class="sql__id">ValueOfInvIncreases</span>,<span class="sql__id">InvIncreases</span>,<span class="sql__number">1</span>)&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">ELSE</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">SetAmount</span>(<span class="sql__id">CostOfShipDecreases</span>,<span class="sql__id">CostOfInvDecreases</span>,<span class="sql__id">InvDecreases</span>,-<span class="sql__number">1</span>);&nbsp;
<span class="sql__keyword">END</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">ValueOfQtyOnHand</span>&nbsp;:=&nbsp;<span class="sql__id">ValueOfQtyOnHand</span>&nbsp;&#43;&nbsp;<span class="sql__id">ValueOfInvoicedQty</span>;&nbsp;
<span class="sql__id">ValueOfRcdIncreases</span>&nbsp;:=&nbsp;<span class="sql__id">ValueOfRcdIncreases</span>&nbsp;&#43;&nbsp;<span class="sql__id">ValueOfInvIncreases</span>;&nbsp;
<span class="sql__id">CostOfShipDecreases</span>&nbsp;:=&nbsp;<span class="sql__id">CostOfShipDecreases</span>&nbsp;&#43;&nbsp;<span class="sql__id">CostOfInvDecreases</span>;&nbsp;
&nbsp;&nbsp;
<span class="sql__id">ExpCostPostedToGL</span>&nbsp;:=&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Expected&nbsp;Cost&nbsp;Posted&nbsp;to&nbsp;G/L&quot;</span>;&nbsp;
<span class="sql__id">InvCostPostedToGL</span>&nbsp;:=&nbsp;<span class="sql__id">VLE</span>.<span class="sql__string">&quot;Cost&nbsp;Posted&nbsp;to&nbsp;G/L&quot;</span>;&nbsp;
<span class="sql__id">CostPostedToGL</span>&nbsp;:=&nbsp;<span class="sql__id">ExpCostPostedToGL</span>&nbsp;&#43;&nbsp;<span class="sql__id">InvCostPostedToGL</span>;&nbsp;
<span class="sql__id">SumTotals</span>;&nbsp;
<span class="sql__keyword">UNTIL</span>&nbsp;<span class="sql__id">VLE</span>.<span class="sql__keyword">NEXT</span>=<span class="sql__number">0</span>;&nbsp;
<span class="sql__id">TmpVETbl</span>.<span class="sql__id">TRANSFERFIELDS</span>(<span class="sql__id">VLE</span>);&nbsp;
<span class="sql__id">TmpVETbl</span>.<span class="sql__keyword">INSERT</span>;&nbsp;
<span class="sql__keyword">END</span>;&nbsp;
&nbsp;&nbsp;
-&nbsp;<span class="sql__keyword">end</span>&nbsp;-</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div>VLE and TmpVEtbl are records of type Value Entry and Value Entry (temporary). Additional variables are added to hold summarized (footer) values.</div>
<div>&nbsp;</div>
<div>One&nbsp;also needs to add an item for displaying values previously shown in Value Entry footer. Dataitem is of type integer and example below shows how to configure it to run as a footer (displayed once per item).</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C/AL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">- C/AL code snippet -
 
footerloop - OnAfterGetRecord()
IF Number = 1 THEN BEGIN
  IF NOT TmpVETbl.FINDSET THEN
    CurrReport.BREAK;
END ELSE
// IF TmpVETbl.NEXT = 0 THEN
    CurrReport.BREAK;
 
- end -</pre>
<div class="preview">
<pre class="mysql">-&nbsp;<span class="sql__id">C</span>/<span class="sql__id">AL</span><span class="sql__keyword">code</span><span class="sql__id">snippet</span>&nbsp;-&nbsp;
&nbsp;&nbsp;
<span class="sql__id">footerloop</span>&nbsp;-&nbsp;<span class="sql__id">OnAfterGetRecord</span>()&nbsp;
<span class="sql__keyword">IF</span><span class="sql__id">Number</span>&nbsp;=&nbsp;<span class="sql__number">1</span><span class="sql__keyword">THEN</span><span class="sql__keyword">BEGIN</span><span class="sql__keyword">IF</span><span class="sql__keyword">NOT</span><span class="sql__id">TmpVETbl</span>.<span class="sql__id">FINDSET</span><span class="sql__keyword">THEN</span><span class="sql__id">CurrReport</span>.<span class="sql__id">BREAK</span>;&nbsp;
<span class="sql__keyword">END</span><span class="sql__keyword">ELSE</span>&nbsp;
//&nbsp;<span class="sql__keyword">IF</span><span class="sql__id">TmpVETbl</span>.<span class="sql__keyword">NEXT</span>&nbsp;=&nbsp;<span class="sql__number">0</span><span class="sql__keyword">THEN</span><span class="sql__id">CurrReport</span>.<span class="sql__id">BREAK</span>;&nbsp;
&nbsp;&nbsp;
-&nbsp;<span class="sql__keyword">end</span>&nbsp;-</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">More Information</h2>
</div>
<div>For more information on this topic and example, see:</div>
<div><a href="http://blogs.msdn.com/b/nav/archive/2011/02/02/designing-reports-for-better-performance-on-rtc.aspx">http://blogs.msdn.com/b/nav/archive/2011/02/02/designing-reports-for-better-performance-on-rtc.aspx</a></div>
<div>&nbsp;</div>
<div>
<div class="endscriptcode"><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
&nbsp;</div>
</div>
</div>
