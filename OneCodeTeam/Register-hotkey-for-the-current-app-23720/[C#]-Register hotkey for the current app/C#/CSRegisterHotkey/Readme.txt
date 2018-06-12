================================================================================
       Windows APPLICATION: CSRegisterHotkey Overview                        
===============================================================================
/////////////////////////////////////////////////////////////////////////////
Summary:
The sample demonstrates how to register and unregister a hotkey for the current 
application.

User32.dll contains 2 extern methods RegisterHotKey and UnregisterHotKey to define 
or free a system-wide hot key. The method Application.AddMessageFilter is used to
add a message filter to monitor Windows messages as they are routed to their 
destinations. Before a message is dispatched, the method PreFilterMessage could 
handle it. 

////////////////////////////////////////////////////////////////////////////////
Demo:

Step1. Build this project in VS2008. 

Step2. Run CSRegisterHotkey.exe.

Step3. Click the textbox in the form, and press Alt+Ctrl+T. You will see "Alt,Control+T" 
       in the textbox, and the  "Register" button is enabled.

Step4. Click the "Register" button, then the textbox and the "Register" button will be 
       disabled, the "Unregister" button will be enabled.

	   Some time you may get an alert "The Hotkey is already in use.", you can try other
	   hotkey like Alt+M.

Step5. Press Alt+Ctrl+T even this application is not the active window. you will get an
       alert "Alt,Control+T is pressed. ".


/////////////////////////////////////////////////////////////////////////////
Code Logic:

1. Design a class HotKeyRegister that wraps 2 extern methods RegisterHotKey and 
   UnregisterHotKey of User32.dll. This class also supplies a static method GetModifiers
   to get the modifiers and key from the KeyData property of KeyEventArgs.

   When create a new instance of this class with the parameters handle, id, modifiers and
   key, the constructor wii call method RegisterHotKey to register the specified hotkey.

2. The enum KeyModifiers contains the supported modifiers, like CTRL, ALT and SHIFT. The 
   WinKey is also supported by the RegisterHotKey method, but keyboard shortcuts that 
   involve the WINDOWS key are reserved for use by the operating system.
       
3. Design the UI in MainFrom which contains a textbox, 2 buttons and some labels. 

   The MainFrom will handle the KeyDown event of the textbox and check whether the pressed
   keys are valid, the keys that must be pressed in combination with the key Ctrl, Shift or
   Alt, like Ctrl+Alt+T. 

   It will also handle the Click event of the buttons to define or free a system-wide hotkey.
   When the form is closed, it will dispose the HotKeyRegister instance.

/////////////////////////////////////////////////////////////////////////////
References:

RegisterHotKey Function
http://msdn.microsoft.com/en-us/library/ms646309(VS.85).aspx
UnregisterHotKey Function
http://msdn.microsoft.com/en-us/library/ms646327(VS.85).aspx
Application.AddMessageFilter Method
http://msdn.microsoft.com/en-us/library/system.windows.forms.application.addmessagefilter.aspx
IMessageFilter Interface
http://msdn.microsoft.com/en-us/library/system.windows.forms.imessagefilter.aspx


/////////////////////////////////////////////////////////////////////////////
