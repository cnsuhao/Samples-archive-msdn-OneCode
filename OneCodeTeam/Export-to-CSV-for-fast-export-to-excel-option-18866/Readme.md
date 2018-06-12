# Export to CSV for fast export to excel option (DynamicsNAVRTCExportToExcel)
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Dynamics NAV
## Topics
* RTC
* Export to Excel；
## IsPublished
* True
## ModifiedDate
* 2012-09-26 03:48:28
## Description

<h1>Dynamics NAV 2009: Export to CSV for fast export to Excel option</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The code sample provides an example of how to use client-side run automations on Dynamics NAV 2009 RTC (such as export to excel functionality of table 370 Excel Buffer in Dynamics NAV 2009 standard application) to avoid performance issues
 that otherwise may rise, especially when larger data amounts are used.</p>
<p class="MsoNormal">This example uses file automation to deal with data export and minimize *chattiness* with excel automation run client side, that is otherwise used for export from RTC in standard application.</p>
<p class="MsoNormal">By exporting all data to server side created file using server side run file automation, then downloading the file to client and formatting it using few simple calls to excel automation, one reduces the 'chattiness' of excel automation
 run client side, which is what primarily creates performance issues using this functionality.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal" style="line-height:normal"><span style="color:#384b38">To implement the sample, import the object using Dynamics NAV 2009 Classic Client.
</span></p>
<p class="MsoNormal" style="line-height:normal"><span style="color:#384b38">Note!!!! Any changes you have made to the existing object will be overwritten when importing the object. The sampled object has NAV16.00.01 version.
</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal"><span style="color:#384b38">Then activate the sample code by removing comments from following code lines of table 370, trigger CreateSheet:
</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal"><span style="color:#384b38">// CreateSheetCSV(SheetName,ReportHeader,CompanyName,USERID);<br>
// EXIT; </span></p>
<p class="MsoNormal">&nbsp;</p>
<h2>Using the Code</h2>
<div class="endscriptcode">//Table 370, new trigger: CreateSheetCSV, where traditional excel // formatting code is replaced with export to file:<br>
...<br>
TextFile.CREATETEMPFILE;<br>
FileName := TextFile.NAME &#43; '.txt';<br>
TextFile.CLOSE;<br>
<br>
TextFile.CREATE(FileName);<br>
TextFile.TEXTMODE(TRUE);<br>
<br>
IF FINDFIRST THEN BEGIN<br>
&nbsp; FOR i := 1 TO STRLEN(xlColID) DO<br>
&nbsp;&nbsp;&nbsp; CurrAnsiCode := CurrAnsiCode &#43; xlColID[i];<br>
&nbsp; RecNo := xlRowID;<br>
END;<br>
<br>
IF FIND('-') THEN BEGIN<br>
&nbsp; REPEAT<br>
&nbsp;&nbsp;&nbsp; IF xlRowID &lt;&gt; RecNo THEN BEGIN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EVALUATE(CurrXlRow,RecNo);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EVALUATE(NextXlRow,xlRowID);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FOR i := 1 TO (NextXlRow -CurrXlRow) DO<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BEGIN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := CONVERTSTR(Line,CharsNavision,CharsWindows);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TextFile.WRITE(Line);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := '';<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; END;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CurrAnsiCode := 65;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AnsiCode := 0;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewLine := TRUE;<br>
&nbsp;&nbsp;&nbsp; END;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Window.UPDATE(1,ROUND(NoofRows / TotalRecNo * 10000,1));<br>
&nbsp;&nbsp;&nbsp; FOR i := 1 TO STRLEN(xlColID) DO<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AnsiCode := AnsiCode &#43; xlColID[i];<br>
&nbsp;&nbsp;&nbsp; IF ((AnsiCode - CurrAnsiCode) &gt; 1) OR (((AnsiCode - CurrAnsiCode) &gt; 0) AND NewLine) THEN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FOR i := 1 TO&nbsp; (AnsiCode - CurrAnsiCode) DO<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := Line &#43; Tab;<br>
&nbsp;&nbsp;&nbsp; IF NumberFormat = '' THEN BEGIN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IF EVALUATE(DecVal,&quot;Cell Value as Text&quot;) THEN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := Line &#43; FORMAT(DecVal) &#43; Tab<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ELSE<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line:= Line &#43; &quot;Cell Value as Text&quot; &#43; Tab<br>
&nbsp;&nbsp;&nbsp; END ELSE<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := Line &#43; &quot;Cell Value as Text&quot; &#43; Tab;<br>
&nbsp;&nbsp;&nbsp; IF Comment &lt;&gt; '' THEN<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Line := Line &#43; Comment &#43; Tab;<br>
&nbsp;&nbsp;&nbsp; NoofRows := NoofRows &#43; 1;<br>
&nbsp;&nbsp;&nbsp; RecNo := xlRowID;<br>
&nbsp;&nbsp;&nbsp; CurrAnsiCode := 0;<br>
&nbsp;&nbsp;&nbsp; AnsiCode := 0;<br>
&nbsp;&nbsp;&nbsp; FOR i := 1 TO STRLEN(xlColID) DO<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CurrAnsiCode := CurrAnsiCode &#43; xlColID[i];<br>
&nbsp;&nbsp;&nbsp; NewLine := FALSE;<br>
&nbsp; UNTIL NEXT = 0;<br>
END;<br>
...</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
