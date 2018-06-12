# Register hotkey for the current app
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Desktop App Development
## Topics
* Hotkey
## IsPublished
* True
## ModifiedDate
* 2013-07-05 03:08:22
## Description
================================================================================<br>
&nbsp; &nbsp; &nbsp; Windows APPLICATION: CSRegisterHotkey Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to register and unregister a hotkey for the current <br>
application.<br>
<br>
User32.dll contains 2 extern methods RegisterHotKey and UnregisterHotKey to define
<br>
or free a system-wide hot key. The method Application.AddMessageFilter is used to<br>
add a message filter to monitor Windows messages as they are routed to their <br>
destinations. Before a message is dispatched, the method PreFilterMessage could <br>
handle it. <br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Build this project in VS2008. <br>
<br>
Step2. Run CSRegisterHotkey.exe.<br>
<br>
Step3. Click the textbox in the form, and press Alt&#43;Ctrl&#43;T. You will see &quot;Alt,Control&#43;T&quot;
<br>
&nbsp; &nbsp; &nbsp; in the textbox, and the &nbsp;&quot;Register&quot; button is enabled.<br>
<br>
Step4. Click the &quot;Register&quot; button, then the textbox and the &quot;Register&quot; button will be
<br>
&nbsp; &nbsp; &nbsp; disabled, the &quot;Unregister&quot; button will be enabled.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Some time you may get an alert &quot;The Hotkey is already in use.&quot;, you can try other<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; hotkey like Alt&#43;M.<br>
<br>
Step5. Press Alt&#43;Ctrl&#43;T even this application is not the active window. you will get an<br>
&nbsp; &nbsp; &nbsp; alert &quot;Alt,Control&#43;T is pressed. &quot;.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
1. Design a class HotKeyRegister that wraps 2 extern methods RegisterHotKey and <br>
&nbsp; UnregisterHotKey of User32.dll. This class also supplies a static method GetModifiers<br>
&nbsp; to get the modifiers and key from the KeyData property of KeyEventArgs.<br>
<br>
&nbsp; When create a new instance of this class with the parameters handle, id, modifiers and<br>
&nbsp; key, the constructor wii call method RegisterHotKey to register the specified hotkey.<br>
<br>
2. The enum KeyModifiers contains the supported modifiers, like CTRL, ALT and SHIFT. The
<br>
&nbsp; WinKey is also supported by the RegisterHotKey method, but keyboard shortcuts that
<br>
&nbsp; involve the WINDOWS key are reserved for use by the operating system.<br>
&nbsp; &nbsp; &nbsp; <br>
3. Design the UI in MainFrom which contains a textbox, 2 buttons and some labels.
<br>
<br>
&nbsp; The MainFrom will handle the KeyDown event of the textbox and check whether the pressed<br>
&nbsp; keys are valid, the keys that must be pressed in combination with the key Ctrl, Shift or<br>
&nbsp; Alt, like Ctrl&#43;Alt&#43;T. <br>
<br>
&nbsp; It will also handle the Click event of the buttons to define or free a system-wide hotkey.<br>
&nbsp; When the form is closed, it will dispose the HotKeyRegister instance.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
RegisterHotKey Function<br>
http://msdn.microsoft.com/en-us/library/ms646309(VS.85).aspx<br>
UnregisterHotKey Function<br>
http://msdn.microsoft.com/en-us/library/ms646327(VS.85).aspx<br>
Application.AddMessageFilter Method<br>
http://msdn.microsoft.com/en-us/library/system.windows.forms.application.addmessagefilter.aspx<br>
IMessageFilter Interface<br>
http://msdn.microsoft.com/en-us/library/system.windows.forms.imessagefilter.aspx<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
