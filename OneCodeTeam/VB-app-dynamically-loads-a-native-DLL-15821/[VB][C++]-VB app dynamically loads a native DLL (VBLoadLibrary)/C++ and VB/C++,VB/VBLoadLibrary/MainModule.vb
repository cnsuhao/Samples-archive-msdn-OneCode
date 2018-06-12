' **************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBLoadLibrary
' Copyright (c) Microsoft Corporation.
'  
' VBLoadLibrary in VB.Net mimics the behavior of CppLoadLibrary to dynamically 
' load a native DLL (LoadLibrary) get the address of a function in the export  
' table (GetProcAddress, Marshal.GetDelegateForFunctionPointer), and call it. 
' The technology is called Dynamic P/Invoke. It serves as a supplement for 
' the P/Invoke technique and is useful especially when the target DLL is not 
' in the search path of P/Invoke. If you use P/Invoke, CLR will search the 
' dll in your assembly's directory first, then search the dll in directories 
' listed in PATH environment variable. If the dll is not in any of those 
' directories, you have to use the so called Dynamic PInvoke technique that 
' is demonstrated in this code sample. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' \**************************************************************************/

#Region "Using directives"
Imports System.Runtime.InteropServices
#End Region


Module MainModule

#Region "Function Delegates"

   ' Function delegate of GetStringLength1 exported from the DLL module.
    ' The string parameter must be marshaled as LPWStr, otherwise, the
    ' string will be passed into the native as an ANSI string that the
    ' Unicode API cannot resolve appropriately.
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Private Delegate Function GetStringLength1Delegate(<MarshalAs(UnmanagedType.LPWStr)> ByVal str As String) As Integer

    ' Function delegate of GetStringLength2 exported from the DLL.
    <UnmanagedFunctionPointer(CallingConvention.StdCall)>
    Private Delegate Function GetStringLength2Delegate(<MarshalAs(UnmanagedType.LPWStr)> ByVal str As String) As Integer

    ' Function delegate of the 'PFN_COMPARE' callback function, and the 
    ' Max function that requires the callback as one of the arguments.
    <UnmanagedFunctionPointer(CallingConvention.StdCall)>
    Private Delegate Function CompareCallback(ByVal a As Integer, ByVal b As Integer) As Integer
    Private Delegate Function CompareDelegate(ByVal a As Integer, ByVal b As Integer, ByVal cmpFunc As CompareCallback) As Integer

#End Region

    Sub Main()

       Dim isLoaded As Boolean = False
        Const moduleName As String = "CppDynamicLinkLibrary"

        ' Check whether or not the module is loaded.  It should not be loaded yet.
        isLoaded = IsModuleLoaded(moduleName)
        Console.WriteLine("Module ""{0}"" is {1}loaded", moduleName, If(isLoaded, "", "not "))

        ' Load the DLL module.
        Console.WriteLine("Load the library")
        Using _lib As New UnmanagedLibrary(moduleName)
            ' Check whether or not the module is loaded.  It should be loaded now.
            isLoaded = IsModuleLoaded(moduleName)
            Console.WriteLine("Module ""{0}"" is {1}loaded", moduleName, If(isLoaded, "", "not "))

            '
            ' Call the functions exported from the module.
            '

            Dim str As String = "HelloWorld"
            Dim length As Integer

            ' Call int /*__cdecl*/ GetStringLength1(PWSTR pszString);
            Dim GetStringLength1 As GetStringLength1Delegate = _lib.GetUnmanagedFunction(Of GetStringLength1Delegate)("GetStringLength1")

            If GetStringLength1 Is Nothing Then
                Throw New EntryPointNotFoundException("Unable to find an entry point named 'GetStringLength1'")
            End If

            length = GetStringLength1(str)
            Console.WriteLine("GetStringLength1(""{0}"") => {1}", str, length)

            ' Call int __stdcall GetStringLength2(PWSTR pszString);
            Dim GetStringLength2 As GetStringLength2Delegate = _lib.GetUnmanagedFunction(Of GetStringLength2Delegate)(If(IntPtr.Size = 4, "_GetStringLength2@4", "GetStringLength2"))

            If GetStringLength2 Is Nothing Then
                Throw New EntryPointNotFoundException("Unable to find an entry point named 'GetStringLength2'")
            End If

            length = GetStringLength2(str)
            Console.WriteLine("GetStringLength2(""{0}"") => {1}", str, length)

            ' 
            ' Show how to pass an app-supplied callback function to the DLL.
            ' The app calls the DLL's CompareInts(), and CompareInts() calls 
            ' the app's Max().
            '

            Dim cmpFuncMax As New CompareCallback(AddressOf Max)
            Dim CompareInts As CompareDelegate = _lib.GetUnmanagedFunction(Of CompareDelegate)("CompareInts")
            If CompareInts Is Nothing Then
                Throw New EntryPointNotFoundException("Unable to find an entry point named 'CompareInts'")
            End If
            Dim maxResult As Integer = CompareInts(2, 3, cmpFuncMax)
            Console.WriteLine("Function: CompareInts(2, 3, Max) => {0}", maxResult)

            '
            ' The solution does not allow you to use classes or data
            ' that are exported from native C++ DLLs.
            '

            ' Dispose attempts to free the library.
            Console.WriteLine("Unload the dynamically loaded DLL")

        End Using ' The DLL module should be unloaded here because Dispose was called.

        ' Check whether or not the module is loaded.
        isLoaded = IsModuleLoaded(moduleName)
        Console.WriteLine("Module ""{0}"" is {1}loaded", moduleName, If(isLoaded, "", "not "))

    End Sub


    ''' <summary>
    ''' This is the callback function for the method Max exported from the 
    ''' DLL CppDynamicLinkLibrary.dll
    ''' </summary>
    ''' <param name="a">the first integer</param>
    ''' <param name="b">the second integer</param>
    ''' <returns>
    ''' The function returns a positive number if a > b, returns 0 if a 
    ''' equals b, and returns a negative number if a &lt; b.
    ''' </returns>
    Function Max(ByVal a As Integer, ByVal b As Integer) As Integer
        Return (a - b)
    End Function


#Region "IsModuleLoaded"

    ''' <summary>
    ''' Check whether or not the specified module is loaded in the current 
    ''' process.
    ''' </summary>
    ''' <param name="moduleName">the module name</param>
    ''' <returns>
    ''' The function returns true if the specified module is loaded in the 
    ''' current process. If the module is not loaded, the function returns
    ''' false.
    ''' </returns>
    Function IsModuleLoaded(ByVal moduleName As String) As Boolean
        ' Get the module in the process according to the module name.
        Dim hMod As IntPtr = GetModuleHandle(moduleName)
        Return (hMod <> IntPtr.Zero)
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Function GetModuleHandle(ByVal moduleName As String) As IntPtr
    End Function

#End Region

End Module
