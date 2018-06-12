'*************************** Module Header ******************************'
' Module Name:  NotePadToolbarButton.vb
' Project:      VBIEToolbarButton
' Copyright (c) Microsoft Corporation.
' 
' To add a button to IE toolbar and menu, you can follow these steps:
' 
' 1. Create a valid GUID for this ComVisible class. 
' 
' 2. Implement the IObjectWithSite and IOleCommandTarget interfaces.  
'   
'   In order to invoke a Component Object Model (COM) object from Internet Explorer, 
'   it must implement IOleCommandTarget. Only one command is supported per object; 
'   the COM object's IOleCommandTarget.Exec is always called with nCmdID=0 and with 
'   VARIANT arguments set to NULL. Additionally, the implementation of 
'   IOleCommandTarget.QueryStatus is always called with cCmds=1.
'
'   If the COM object needs to access the browser or Dynamic HTML (DHTML) Object Model 
'   of the active page, it must implement IObjectWithSite. Internet Explorer calls 
'   IObjectWithSite.SetSite with a pointer to IShellBrowser.
' 
' 3. Register this assembly to COM.
'    
'    Use RegistrationServices to register this assembly in the IEToolbarButtonInstaller
'    class.
'   
' 4. Create a new key (using the GUID as the name) in the registry under: 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}
'    {GUID} is the valid GUID that you created in step 1.
' 
' 5. Create the following string values in the registry under the new key:
' 
'    ButtonText - Set the value to the label you want for the toolbar button.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\ButtonText
'    
'    HotIcon - Set the full path of the .ico file that contains the three color icons.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\HotIcon
'    
'    Icon - Set the full path of the .ico file that contains the three grayscale icons.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Icon
' 
'    Default Visible - To make the toolbar button to appear on the Internet Explorer toolbar 
'    by default, set Default Visible to "Yes", otherwise set Default Visible to "No". 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Default Visible
' 
'    MenuText - This is the text you want to be displayed in the menu. This text does not support 
'    any underlining of characters for shortcut keys, because there is no way to prevent conflicts. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuText
' 
'    MenuCustomize - Set the value to "help" to have the menu item appear in the Help menu. If
'    this string value doesn't exist or is set to something other than "help", the menu item will 
'    appear in the Tools menu. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuCustomize
' 
'    MenuStatusBar - This is the text you want displayed in the status bar when the menu item 
'    is highlighted. This text should describe what the script associated with this menu item will do. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuStatusBar
' 
' 6. The following register key values are required to complete the creation of a toolbar button
'    that implements a COM object.
'    
'    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
'    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
' 
'    ClsidExtension - Set the value of ClsidExtension equal to the GUID of the COM object.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\ClsidExtension   
' 
' 7. The following register key values are required to complete the creation of a toolbar button that 
'    runs a script.
'    
'    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
'    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
'    
'    Script - Set the value of Script to the full path of the script to run.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Script
' 
' 8. The following register key values are required to complete the creation of a toolbar button that 
'    runs an executable file.
'    
'    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
'    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
'    
'    Exec - Set the value of Exec to the full path of the .exe file to run.
'    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Exec
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32
Imports SHDocVw

<ComVisible(True)>
<Guid("c0e8ae32-0758-4c8d-ab71-23b361fe8964")>
Public Class NotePadToolbarButton
    Implements NativeMethods.IObjectWithSite, NativeMethods.IOleCommandTarget

    Private Const IEExtensionsRegisterKeyPath As String = "Software\Microsoft\Internet Explorer\Extensions"

    ' Current IE instance. For IE7 or later version, an IE Tab is just 
    ' an IE instance.
    Private ieInstance As InternetExplorer

#Region "IObjectWithSite Members"
    ''' <summary>
    ''' This method is called when the extension is instantiated and when
    ''' it is destroyed. The site is an object implemented the 
    ''' interface IShellBrowser which also implements the interface _IServiceProvider.
    ''' </summary>
    ''' <param name="site"></param>
    Public Sub SetSite(ByVal site As Object) Implements NativeMethods.IObjectWithSite.SetSite
        ' Release previous COM objects.
        If Me.ieInstance IsNot Nothing Then
            Marshal.ReleaseComObject(Me.ieInstance)
            Me.ieInstance = Nothing
        End If

        ' The site implements IServiceProvider interface and can be used to 
        ' get InternetExplorer instance.
        Dim provider = TryCast(site, NativeMethods.IServiceProvider)
        If provider IsNot Nothing Then
            Dim pguid As New System.Guid("{0002DF05-0000-0000-C000-000000000046}")
            Dim riid As New System.Guid("{00000000-0000-0000-C000-000000000046}")
            Try
                Dim webBrowser As Object = Nothing
                provider.QueryService(pguid, riid, webBrowser)
                Me.ieInstance = TryCast(webBrowser, InternetExplorer)
            Catch e1 As COMException
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Retrieves and returns the specified interface from the last site
    ''' set through SetSite(). The typical implementation will query the
    ''' previously stored pUnkSite pointer for the specified interface.
    ''' </summary>
    Public Sub GetSite(ByRef guid_Renamed As System.Guid,
                       <Out()> ByRef ppvSite As Object) _
                   Implements NativeMethods.IObjectWithSite.GetSite

        Dim punk As IntPtr = Marshal.GetIUnknownForObject(ieInstance)
        ppvSite = New Object()
        Dim ppvSiteIntPtr As IntPtr = Marshal.GetIUnknownForObject(ppvSite)
        Dim hr As Integer = Marshal.QueryInterface(punk, guid_Renamed, ppvSiteIntPtr)
        Marshal.ThrowExceptionForHR(hr)
        Marshal.Release(punk)
    End Sub
#End Region

#Region "IOleCommandTarget Members"

    Public Function QueryStatus(ByVal pguidCmdGroup As NativeMethods.GUID,
                                ByVal cCmds As Integer,
                                ByVal prgCmds As NativeMethods.OLECMD,
                                ByVal pCmdText As IntPtr) _
                            As Integer Implements NativeMethods.IOleCommandTarget.QueryStatus
        Return 0
    End Function

    ''' <summary>
    ''' When the button is clicked, it will execute the Exec method of the
    ''' IOleCommandTarget interface.
    ''' </summary>
    Public Function Exec(ByVal pguidCmdGroup As NativeMethods.GUID,
                         ByVal nCmdID As Integer,
                         ByVal nCmdexecopt As Integer,
                         ByVal pvaIn() As Object,
                         ByVal pvaOut As Integer) _
                     As Integer Implements NativeMethods.IOleCommandTarget.Exec

        Dim msg As New StringBuilder()

        Dim doc As mshtml.HTMLDocument = TryCast(ieInstance.Document, mshtml.HTMLDocument)
        Dim imgs = doc.getElementsByTagName("img")

        For Each img In imgs
            Dim imgElement As mshtml.IHTMLImgElement = TryCast(img, mshtml.IHTMLImgElement)
            If imgElement IsNot Nothing Then
                msg.Append(imgElement.src & vbLf)
            End If
        Next img

        MessageBox.Show(msg.ToString(), "Images in the page")
        Return 0
    End Function

#End Region


#Region "Com Register/UnRegister Methods"
    ''' <summary>
    ''' When this class is registered to COM, add a new key to the BHORegistryKey 
    ''' to make IE use this BHO.
    ''' On 64bit machine, if the platform of this assembly and the installer is x86,
    ''' 32 bit IE can use this BHO. If the platform of this assembly and the installer
    ''' is x64, 64 bit IE can use this BHO.
    ''' </summary>
    <ComRegisterFunction()>
    Public Shared Sub RegisterIEToolbarButton(ByVal t As Type)
        Dim toolbarRegisterKeyPath As String =
            String.Format("{0}\{1}", IEExtensionsRegisterKeyPath, t.GUID.ToString("B"))

        Using key As RegistryKey =
            Registry.LocalMachine.CreateSubKey(toolbarRegisterKeyPath)

            Dim assemblyFile As New FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)

            key.SetValue("ButtonText", "NotePad")

            key.SetValue("MenuText", "Note Pad")
            key.SetValue("MenuStatusBar", "Launch NotePad")

            ' Implement a COM object.
            key.SetValue("CLSID", "{1FBA04EE-3024-11d2-8F1F-0000F87ABD16}")
            key.SetValue("ClsidExtension", t.GUID.ToString("B"))

            ' Run an executable file.
            key.SetValue("Exec", "Notepad.exe")

            ' Run a script.
            key.SetValue("Script",
                         String.Format("{0}\Resources\GetImageList.htm", assemblyFile.Directory.FullName))

            ' Set the icon path.             
            key.SetValue("Icon",
                         String.Format("{0}\Resources\NotePadHot.ico", assemblyFile.Directory.FullName))
            key.SetValue("HotIcon",
                         String.Format("{0}\Resources\NotePadNormal.ico", assemblyFile.Directory.FullName))

            key.SetValue("Default Visible", "Yes")
        End Using
    End Sub

    ''' <summary>
    ''' When this class is unregistered from COM, delete the key.
    ''' </summary>
    <ComUnregisterFunction()>
    Public Shared Sub UnregisterIEToolbarButton(ByVal t As Type)

        Dim toolbarRegisterKeyPath As String =
            String.Format("{0}\{1}",
                          IEExtensionsRegisterKeyPath,
                          GetType(NotePadToolbarButton).GUID.ToString("B"))

        Dim key As RegistryKey =
            Registry.LocalMachine.OpenSubKey(IEExtensionsRegisterKeyPath, True)

        Dim guidString As String = t.GUID.ToString("B")
        If key IsNot Nothing Then
            key.DeleteSubKey(guidString, False)
            key.Close()
        End If
    End Sub
#End Region
End Class
