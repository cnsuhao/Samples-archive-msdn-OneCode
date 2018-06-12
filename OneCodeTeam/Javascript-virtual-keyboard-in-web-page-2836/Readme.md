# Javascript virtual keyboard in web page (JSVirtualKeyboard)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Virtual Keyboard
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:33:59
## Description

<p style="font-family:Courier New"></p>
<h2>JSVirtualKeyboard Project Overview</h2>
<p style="font-family:Courier New"><br>
Use:<br>
<br>
This project illustrates how to make a virtual keyboard on the page. For<br>
example, if we need a password textbox somewhere and we need it can only<br>
be inputted through a virtual keyboard on the page, this sample may give<br>
a quick start to build a solution for this situation.<br>
<br>
Demo the Sample.<br>
<br>
Step1: Browse the Default.htm from the sample. We will see a TextBox and a <br>
number keyboard following the TextBox.<br>
<br>
Step2: Click the number button to enter the value into the TextBox and click<br>
Backspace button to delete a number in the TextBox.<br>
<br>
Step3: The button order of the virtual number keyboard will be changed every<br>
time the page is refreshed.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a C# / VB.NET ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step2: Add a Default HTML page into the application called Default.htm.<br>
<br>
Step3: Add an HTML Input(Text) control to the page. Set its id to &quot;tbInput&quot;.<br>
<br>
Step4: Add an HTML Div control to the page and insert 11 Input(Button) controls<br>
inside this Div. Ten of these buttons stand for ten numbers and the last one is<br>
for Backspace button. For layout purpose, please add a &lt;br /&gt; tag between every<br>
three buttons as well.<br>
<br>
&nbsp; &nbsp;&lt;div id=&quot;VirtualKey&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn1&quot; type=&quot;button&quot; value=&quot;1&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn2&quot; type=&quot;button&quot; value=&quot;2&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn3&quot; type=&quot;button&quot; value=&quot;3&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn4&quot; type=&quot;button&quot; value=&quot;4&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn5&quot; type=&quot;button&quot; value=&quot;5&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn6&quot; type=&quot;button&quot; value=&quot;6&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn7&quot; type=&quot;button&quot; value=&quot;7&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn8&quot; type=&quot;button&quot; value=&quot;8&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn9&quot; type=&quot;button&quot; value=&quot;9&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn0&quot; type=&quot;button&quot; value=&quot;0&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btnDel&quot; type=&quot;button&quot; value=&quot;Backspace&quot; /&gt;<br>
&nbsp; &nbsp;&lt;/div&gt;<br>
<br>
Step5: Create two JavaScritp functions on the page called input(e) and del(). <br>
The input(e) function will enter the number into the TextBox based on the <br>
parameter e. And the del() function will delete a number from the TextBox.<br>
<br>
&nbsp; &nbsp;function input(e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp;var tbInput = document.getElementById(&quot;tbInput<br>
&nbsp; &nbsp; &nbsp; &nbsp;tbInput.value = tbInput.value &#43; e.value;<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;function del() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;var tbInput = document.getElementById(&quot;tbInput&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;tbInput.value = tbInput.value.substr(0, tbInput.value.length - 1);<br>
&nbsp; &nbsp;}<br>
<br>
Step6: Set the onclick event of the ten number buttons equal to input(e) <br>
function and make the parameter to be the button itself. Also set the onclick<br>
event of the Backspace button to del();.<br>
<br>
&nbsp; &nbsp;&lt;div id=&quot;VirtualKey&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn1&quot; type=&quot;button&quot; value=&quot;1&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn2&quot; type=&quot;button&quot; value=&quot;2&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn3&quot; type=&quot;button&quot; value=&quot;3&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn4&quot; type=&quot;button&quot; value=&quot;4&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn5&quot; type=&quot;button&quot; value=&quot;5&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn6&quot; type=&quot;button&quot; value=&quot;6&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn7&quot; type=&quot;button&quot; value=&quot;7&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn8&quot; type=&quot;button&quot; value=&quot;8&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn9&quot; type=&quot;button&quot; value=&quot;9&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input id=&quot;btn0&quot; type=&quot;button&quot; value=&quot;0&quot; onclick=&quot;input(this);&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;btnDel&quot; type=&quot;button&quot; value=&quot;Backspace&quot; onclick=&quot;del();&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;<br>
<br>
NOTE: Till now, we can run this sample and input the number to the TextBox<br>
by click the button of the virtual number keyboard. The steps below will<br>
tell how to make the button order different when refresh the page.<br>
<br>
Step7: Set the onload event of the page to load() function to disorder the<br>
number button.<br>
<br>
&nbsp; &nbsp;function load() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;var array = new Array();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;while (array.length &lt; 10) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var temp = Math.round(Math.random() * 9);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!contain(array, temp)) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;array.push(temp);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;for (i = 0; i &lt; 10; i&#43;&#43;) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var btn = document.getElementById(&quot;btn&quot; &#43; i);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;btn.value = array[i];<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
NOTE: After the while loop, we will get an array of 10 random number from 0 <br>
to 9 without repeat. For example: (3,0,5,4,8,6,1,2,9,7). Then, we will set <br>
the value of the number buttons to each item in this array. This will give <br>
us a disordered virtual number keyboard.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
For a more advanced virtual keyboard, please refer to these links:<br>
<br>
# Creating a Keyboard with CSS and jQuery <br>
<a target="_blank" href="http://net.tutsplus.com/tutorials/javascript-ajax/creating-a-keyboard-with-css-and-jquery/">http://net.tutsplus.com/tutorials/javascript-ajax/creating-a-keyboard-with-css-and-jquery/</a><br>
<br>
# Creating a Virtual jQuery Keyboard<br>
<a target="_blank" href="http://designshack.co.uk/articles/javascript/creating-a-virtual-jquery-keyboard">http://designshack.co.uk/articles/javascript/creating-a-virtual-jquery-keyboard</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
