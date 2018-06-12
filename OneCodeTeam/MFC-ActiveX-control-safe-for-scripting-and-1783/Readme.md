# MFC ActiveX control safe for scripting and initialization (MFCSafeActiveX)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* COM
* MFC
## Topics
* ActiveX
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:21:56
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVEX CONTROL DLL : MFCSafeActiveX Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
By default, MFC ActiveX controls (e.g. the MFCActiveX sample) are not marked <br>
as Safe for Scripting and Safe for Initialization. This becomes apparent when <br>
the control is hosted in Internet Explorer with the security level set to <br>
medium or high. In either of these modes, warnings may be displayed that the <br>
control's data is not safe or that the control may not be safe for scripts to <br>
use. <br>
<br>
There are two methods to mark an ActiveX control as safe for scripting and <br>
initialization, and eliminate these warnings and errors.<br>
<br>
1. Implement the IObjectSafety interface in the control.<br>
<br>
2. Modify the control's DllRegisterServer function to mark the control &quot;safe&quot;<br>
in the registry. It results in these entries in the registry:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\Component Categories\<br>
&nbsp;&nbsp;&nbsp;&nbsp;{7DD95801-9882-11CF-9FA9-00AA006C42C4} &nbsp;// CATID_SafeForScripting<br>
&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\Component Categories\<br>
&nbsp;&nbsp;&nbsp;&nbsp;{7DD95802-9882-11CF-9FA9-00AA006C42C4} &nbsp;// CATID_SafeForInitializing<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// register the control as safe for scripting<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\CLSID\{&quot;your controls GUID&quot;}\Implemented Categories\<br>
&nbsp;&nbsp;&nbsp;&nbsp;{7DD95801-9882-11CF-9FA9-00AA006C42C4} &nbsp;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// register the control as safe for initialization<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\CLSID\{&quot;your controls GUID&quot;}\Implemented Categories\<br>
&nbsp;&nbsp;&nbsp;&nbsp;{7DD95802-9882-11CF-9FA9-00AA006C42C4} &nbsp;<br>
<br>
This sample convers the second of these methods.<br>
<br>
MFCSafeActiveX exposes the following items:<br>
<br>
1. A MFC ActiveX control short-named MFCSafeActiveX that is safe for <br>
scripting and initialization<br>
<br>
Program ID: MFCSAFEACTIVEX.MFCSafeActiveXCtrl.1<br>
CLSID_MFCSafeActiveX: 1EBAE592-7515-43C2-A6F1-CDEEDF3FD82B<br>
DIID__DMFCSafeActiveX: 6267760D-4EDC-430A-A94F-1181971ABA02<br>
DIID__DMFCSafeActiveXEvents: 050C9E59-ADA3-440A-92B4-59AE97009569<br>
LIBID_MFCSafeActiveXLib: 098DB52D-2AAE-499B-B959-A430BA0FF357<br>
<br>
Dialogs:<br>
// The main dialog of the control<br>
IDD_MAINDIALOG<br>
// The property page of the control<br>
IDD_PROPPAGE_MFCACTIVEX<br>
<br>
Properties:<br>
// With both get and set accessor methods<br>
FLOAT FloatProperty<br>
<br>
Methods:<br>
// HelloWorld returns a BSTR &quot;HelloWorld&quot;<br>
BSTR HelloWorld(void);<br>
// GetProcessThreadID outputs the running process ID and thread ID<br>
void GetProcessThreadID(LONG* pdwProcessId, LONG* pdwThreadId);<br>
<br>
Events:<br>
// FloatPropertyChanging is fired before new value is set to the <br>
// FloatProperty property. The Cancel parameter allows the client to cancel <br>
// the change of FloatProperty.<br>
void FloatPropertyChanging(FLOAT NewValue, VARIANT_BOOL* Cancel);<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
HTMLEmbedActiveX -&gt; MFCSafeActiveX<br>
HTMLEmbedActiveX demonstrates the use of the safe MFC ActiveX control. <br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build MFCSafeActiveX, 1. run Visual Studio as administrator because the <br>
control needs to be registered into HKCR. 2. Be sure to build the <br>
MFCSafeActiveX project using the Release configuration.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / MFC / MFC ActiveX Control project named <br>
MFCSafeActiveX in Visual Studio 2008.<br>
<br>
Step2. In the page Control Settings, select &quot;Create control based on&quot; as
<br>
STATIC. Under &quot;Additional features&quot;, check &quot;Activates when visible&quot; and
<br>
&quot;Flicker-free activation&quot;, and un-check &quot;Has an About box dialog&quot;.<br>
<br>
B. Adding a main dialog to the control<br>
<br>
Step1. In Resource View, insert a new dialog resource and change the control <br>
ID to IDD_MAINDIALOG.<br>
<br>
Step2. Change the default properties of the dialog to Border - None, <br>
Style - Child, System Menu - False, Visible - True.<br>
<br>
Step3. Create a class for the dialog, by right clicking on the dialog and <br>
selecting Add Class. Name the class CMainDialog, with the base class CDialog.<br>
<br>
Step4. Add the member variable m_MainDialog of the type CMainDialog to the <br>
class CMFCSafeActiveXCtrl.<br>
<br>
Step5. Select the class CMFCSafeActiveXCtrl in Class View. In the Properties <br>
sheet, select the Messages icon. Add OnCreate for the WM_CREATE message. <br>
<br>
Step6. Open MFCSafeActiveXCtrl.cpp, and add the following code to the <br>
OnCreate method to create the main dialog.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;m_MainDialog.Create(IDD_MAINDIALOG, this);<br>
<br>
Step7. Add the following code to the OnDraw method to size the main dialog <br>
window and fill the background.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;m_MainDialog.MoveWindow(rcBounds, TRUE);<br>
&nbsp;&nbsp;&nbsp;&nbsp;CBrush brBackGnd(TranslateColor(AmbientBackColor()));<br>
&nbsp;&nbsp;&nbsp;&nbsp;pdc-&gt;FillRect(rcBounds, &brBackGnd);<br>
<br>
C. Adding Properties to the ActiveX control<br>
<br>
Step1. In Class View, expand the element MFCSafeActiveXLib. Right click on <br>
_DMFCSafeActiveX, and click on Add, Add Property. In the Add Property Wizard <br>
dialog, select FLOAT for Property type, and enter &quot;FloatProperty&quot; for <br>
property name. Select &quot;Get/Set methods&quot; to create the methods <br>
GetFloatProperty and SetFloatProperty.<br>
<br>
Step2. In the class CMFCSafeActiveXCtrl, add a member variable, FLOAT <br>
m_FloatField. In the class's contructor, set the variable's default value to <br>
0.0f.<br>
<br>
Step3. Associate the Get/Set methods of FloatProperty with m_FloatField.<br>
<br>
D. Adding Methods to the ActiveX control<br>
<br>
Step1. In Class View, expand the element MFCSafeActiveXLib. Right click on <br>
_DMFCSafeActiveX, and click on Add, Add Method. In the Add Method Wizard <br>
dialog, select BSTR for the return type, and enter &quot;HelloWorld&quot; for Method
<br>
name.<br>
<br>
With the almost same steps, the method GetProcessThreadID is added to get the<br>
executing process ID and thread ID:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;void GetProcessThreadID(LONG* pdwProcessId, LONG* pdwThreadId);<br>
<br>
E. Adding Events to the ActiveX control<br>
<br>
Step1. In Class View, right click on CMFCSafeActiveXCtrl, select Add, Add <br>
Event. In the Add Event Wizard, enter &quot;FloatPropertyChanging&quot; for Event name
<br>
and add two parameters: FLOAT NewValue, VARIANT_BOOL* Cancel. <br>
<br>
Step2. The event &quot;FloatPropertyChanging&quot; is fired in SetFloatProperty:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;void CMFCSafeActiveXCtrl::SetFloatProperty(FLOAT newVal)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AFX_MANAGE_STATE(AfxGetStaticModuleState());<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Fire the event, FloatPropertyChanging<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VARIANT_BOOL cancel = VARIANT_FALSE;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FloatPropertyChanging(newVal, &cancel);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (cancel == VARIANT_FALSE)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_fField = newVal;&nbsp;&nbsp;&nbsp;&nbsp;// Save the new value<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetModifiedFlag();<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Display the new value in the control UI<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CString strFloatProp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strFloatProp.Format(_T(&quot;%f&quot;), m_fField);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_MainDialog.m_StaticFloatProperty.SetWindowTextW(strFloatProp);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// else, do nothing.<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
F. Marking the control as Safe for Scripting and Initialization<br>
<br>
Step1. Implement the CreateComponentCategory, RegisterCLSIDInCategory, and <br>
UnRegisterCLSIDInCategory helper functions in cathelp.h/cpp files.<br>
<br>
Step2. Modify MFCSafeActiveX.cpp to add CLSID_SafeItem at the beginning of <br>
the file. The value of CLSID_SafeItem is taken from IMPLEMENT_OLECREATE_EX <br>
in MFCSafeActiveXCtrl.cpp. It is actually the CLSID of the ActiveX control.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;const CATID CLSID_SafeItem =<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ 0x1ebae592, 0x7515, 0x43c2,<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ 0xa6, 0xf1, 0xcd, 0xee, 0xdf, 0x3f, 0xd8, 0x2b}};<br>
<br>
Step3. Modify the DllRegisterServer method in MFCSafeActiveX.cpp, to mark the<br>
control as safe for initialization and scripting using the helper functions<br>
in cathelp.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Mark the control as safe for initializing. (Added)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = CreateComponentCategory(CATID_SafeForInitializing, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L&quot;Controls safely initializable from persistent data!&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = RegisterCLSIDInCategory(CLSID_SafeItem, CATID_SafeForInitializing);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Mark the control as safe for scripting. (Added)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = CreateComponentCategory(CATID_SafeForScripting,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L&quot;Controls safely &nbsp;scriptable!&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = RegisterCLSIDInCategory(CLSID_SafeItem, CATID_SafeForScripting);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
Step4. Modify the DllUnregisterServer method in MFCSafeActiveX.cpp, to remove<br>
the entries from the registry using the helper functions in cathelp.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Remove entries from the registry.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = UnRegisterCLSIDInCategory(CLSID_SafeItem, CATID_SafeForInitializing);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = UnRegisterCLSIDInCategory(CLSID_SafeItem, CATID_SafeForScripting);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (FAILED(hr))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hr;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to mark MFC ActiveX controls as Safe for Scripting and Initialization<br>
<a target="_blank" href="http://support.microsoft.com/kb/161873">http://support.microsoft.com/kb/161873</a><br>
<br>
SafeCtl.exe implements IObjectSafety in ActiveX control<br>
<a target="_blank" href="http://support.microsoft.com/kb/164119">http://support.microsoft.com/kb/164119</a><br>
<br>
The ABCs of MFC ActiveX Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms968497.aspx">http://msdn.microsoft.com/en-us/library/ms968497.aspx</a><br>
<br>
Signing and Marking ActiveX Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms974305.aspx">http://msdn.microsoft.com/en-us/library/ms974305.aspx</a><br>
<br>
A Complete ActiveX Web Control Tutorial<br>
<a target="_blank" href="http://www.codeproject.com/KB/COM/CompleteActiveX.aspx">http://www.codeproject.com/KB/COM/CompleteActiveX.aspx</a><br>
<br>
Packaging ActiveX Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa751974.aspx">http://msdn.microsoft.com/en-us/library/aa751974.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
