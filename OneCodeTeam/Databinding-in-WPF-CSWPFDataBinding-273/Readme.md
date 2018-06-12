# Databinding in WPF (CSWPFDataBinding)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:11:31
## Description

<p style="font-family:Courier New"></p>
<h2>WPF APPLICATION : CSWPFDataBinding Project Overview<br>
<br>
WPF DataBinding Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This projects demonstrates the basics of DataBinding in WPF. The sample provides<br>
procedure code as well as XAML code, and they are achieving the same goal.<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
&nbsp; &nbsp;1. Binding mode of TextBox &quot;Name&quot; to Twoway, and UpdateSourceTrigger<br>
&nbsp; &nbsp; &nbsp; is set to PropertyChanged, so the change will be<br>
&nbsp; &nbsp; &nbsp; reflected in the Label Name which is located in the second column.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;2. Binding mode of TextBox &quot;Job&quot; is set to OnewayToSource, so that we
<br>
&nbsp; &nbsp; &nbsp; can see the Job is empty when it is located. Once you enter in the
<br>
&nbsp; &nbsp; &nbsp; TextBox &quot;Job&quot;, and switch focus, then the Label &quot;Job&quot; will appear.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;3. The custom validation rule is added to Binding's validation rule <br>
&nbsp; &nbsp; &nbsp; collections, so if you enter a value does not fall certain range,<br>
&nbsp; &nbsp; &nbsp; there's UI change which indicates input contains error.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;4. Label Salary is given a Converter in its binding, so that we can see the
<br>
&nbsp; &nbsp; &nbsp; label actually displays &quot;Total= No. $&quot;.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;5. Binding Mode of TextBox &quot;Interest&quot; is to to Oneway, so that when you
<br>
&nbsp; &nbsp; &nbsp; change the text of TextBox &quot;Interest&quot;, lable &quot;Interest&quot; in the right
<br>
&nbsp; &nbsp; &nbsp; side will not be changed even the focus is lost. However, you can
<br>
&nbsp; &nbsp; &nbsp; set the value of Interest property in the code to change the target.<br>
&nbsp; <br>
&nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
DataBinding Overview: <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms752347.aspx">
http://msdn.microsoft.com/en-us/library/ms752347.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
