# Windows user controls demo (CppWindowsUserControls)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* User Controls
* Windows UI
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:29:43
## Description

<h1><span style="font-family:������">WIN32 APPLICATION</span> (<span style="font-family:������">CppWindowsUserControls</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">CppWindowsUserControls contains simple examples of how to create user controls defined in user32.dll. The controls include Buttons, Combo-boxes, Edits, List-boxes, RichEdit(in msftedit.dll or riched20.dll or riched32.dll), Scrollbars,
 and Statics.<span style="">&nbsp; </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53077/1/image.png" alt="" width="312" height="298" align="middle">
</span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��Button�� the UI is: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53078/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��ListBox�� the UI is: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53079/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��ComboBox�� the UI is : </span>
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53080/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��ScrollBar�� the UI is: </span>
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53081/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��Edit�� the UI is: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53082/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click ��Static�� the UI is: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53083/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When we click��RichEdit�� the UI is: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53084/1/image.png" alt="" width="406" height="335" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. According to the CppWindowsDialog example, build up the dialogs for use in this example:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#define IDD_MAINDIALOG                  103
#define IDD_BUTTONDIALOG                130
#define IDD_COMBOBOXDIALOG              131
#define IDD_EDITDIALOG                  132
#define IDD_RICHEDITDIALOG              133
#define IDD_LISTBOXDIALOG               134
#define IDD_SCROLLBARDIALOG             135
#define IDD_STATICDIALOG                136
#define IDB_BITMAP1                     139
#define IDC_BUTTON_BUTTON               1000
#define IDC_BUTTON_COMBOBOX             1001
#define IDC_BUTTON_EDIT                 1002
#define IDC_BUTTON_LISTBOX              1003
#define IDC_BUTTON_SCROLLBAR            1004
#define IDC_BUTTON_STATIC               1005
#define IDC_BUTTON_RICHEDIT             1006
#define IDC_STATIC                      -1

</pre>
<pre id="codePreview" class="cplusplus">
#define IDD_MAINDIALOG                  103
#define IDD_BUTTONDIALOG                130
#define IDD_COMBOBOXDIALOG              131
#define IDD_EDITDIALOG                  132
#define IDD_RICHEDITDIALOG              133
#define IDD_LISTBOXDIALOG               134
#define IDD_SCROLLBARDIALOG             135
#define IDD_STATICDIALOG                136
#define IDB_BITMAP1                     139
#define IDC_BUTTON_BUTTON               1000
#define IDC_BUTTON_COMBOBOX             1001
#define IDC_BUTTON_EDIT                 1002
#define IDC_BUTTON_LISTBOX              1003
#define IDC_BUTTON_SCROLLBAR            1004
#define IDC_BUTTON_STATIC               1005
#define IDC_BUTTON_RICHEDIT             1006
#define IDC_STATIC                      -1

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">IDD_MAINDIALOG - The main dialog, having the buttons to show the sub-dialogs that demonstrate the use of every
<span class="GramE">types</span> of user-controls. </p>
<p class="MsoNormal">IDD_BUTTONDIALOG - Demonstrate the various types of button.
</p>
<p class="MsoNormal">IDD_COMBOBOXDIALOG - Demonstrate the various types of comboxbox.
</p>
<p class="MsoNormal">IDD_EDITDIALOG - Demonstrate the various types of edit control.
</p>
<p class="MsoNormal">IDD_RICHEDITDIALOG - Demonstrate the richedit control. </p>
<p class="MsoNormal">IDD_LISTBOXDIALOG - Demonstrate the listbox control. </p>
<p class="MsoNormal">IDD_SCROLLBARDIALOG - Demonstrate the scrollbar control. </p>
<p class="MsoNormal">IDD_STATICDIALOG - Demonstrate the various types of static control.
</p>
<p class="MsoNormal">Step2. In each dialog's WM_INITDIALOG event handler, create controls using the CreateWindowEx API. For example,
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
RECT rc = { 20, 20, 150, 30 };
HWND hBtn = CreateWindowEx(0, L&quot;BUTTON&quot;, L&quot;Default Push Button&quot;, 
    BS_DEFPUSHBUTTON | WS_CHILD | WS_VISIBLE, 
    rc.left, rc.top, rc.right, rc.bottom, 
    hWnd, reinterpret_cast&lt;HMENU&gt;(IDC_DEFPUSHBUTTON), g_hInst, 0);
if (hBtn)
{
    SendMessage(hBtn, WM_SETFONT, reinterpret_cast&lt;WPARAM&gt;(hFont), TRUE);
}

</pre>
<pre id="codePreview" class="cplusplus">
RECT rc = { 20, 20, 150, 30 };
HWND hBtn = CreateWindowEx(0, L&quot;BUTTON&quot;, L&quot;Default Push Button&quot;, 
    BS_DEFPUSHBUTTON | WS_CHILD | WS_VISIBLE, 
    rc.left, rc.top, rc.right, rc.bottom, 
    hWnd, reinterpret_cast&lt;HMENU&gt;(IDC_DEFPUSHBUTTON), g_hInst, 0);
if (hBtn)
{
    SendMessage(hBtn, WM_SETFONT, reinterpret_cast&lt;WPARAM&gt;(hFont), TRUE);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The various control types are created by varying the style bits.
</p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms633574.aspx">MSDN: About Window Classes</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://winapi.foosyerdoos.org.uk/info/user_cntrls.php">Creating Windows and User Controls</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms632680.aspx">MSDN: CreateWindowEx</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/bb773169.aspx">MSDN: Control Library</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
