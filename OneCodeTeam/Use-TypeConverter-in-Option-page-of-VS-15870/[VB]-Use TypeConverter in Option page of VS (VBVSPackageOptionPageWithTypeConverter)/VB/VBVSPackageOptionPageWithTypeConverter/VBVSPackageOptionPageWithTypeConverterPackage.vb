'**************************** Module Header ******************************'
' Module Name:  VBVSPackageOptionPageWithTypeConverterPackage.vb
' Project:      VBVSPackageOptionPageWithTypeConverter
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to use TypeConverter in Option Page.
' A type converter can be used to convert values between data types, and to
' assist property configuration at design time by providing text-to-value
' conversion or a drop-down list of values to select from.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell


''' <summary>
''' This is the class that implements the package exposed by this assembly.
'''
''' The minimum requirement for a class to be considered a valid package for Visual Studio
''' is to implement the IVsPackage interface and register itself with the shell.
''' This package uses the helper classes defined inside the Managed Package Framework (MPF)
''' to do it: it derives from the Package class that provides the implementation of the 
''' IVsPackage interface and uses the registration attributes defined in the framework to 
''' register itself and its components with the shell.
''' </summary>
' This attribute tells the registration utility (regpkg.exe) that this class needs
' to be registered as package.
' A Visual Studio component can be registered under different regitry roots; for instance
' when you debug your package you want to register it in the experimental hive. This
' attribute specifies the registry root to use if no one is provided to regpkg.exe with
' the /root switch.
' This attribute is used to register the informations needed to show the this package
' in the Help/About dialog of Visual Studio.
' In order be loaded inside Visual Studio in a machine that has not the VS SDK installed, 
' package needs to have a valid load key (it can be requested at 
' http://msdn.microsoft.com/vstudio/extend/). This attributes tells the shell that this 
' package has a load key embedded in its resources.
' Assign ProvideOptionPage attribute to the package class for registering our Option Page.
<PackageRegistration(UseManagedResourcesOnly:=True), DefaultRegistryRoot("Software\Microsoft\VisualStudio\9.0"), InstalledProductRegistration(False, "#110", "#112", "1.0", IconResourceID:=400), ProvideLoadKey("Standard", "1.0", "CSVSPackageOptionPageWithTypeConverter", "Microsoft", 1), Guid(GuidList.guidCSVSPackageOptionPageWithTypeConverterPkgString), ProvideOptionPage(GetType(OptionsPage), "MyOptionsPage", "OptionsPageWithTypeConverter", 113, 114, True)> _
Public NotInheritable Class CSVSPackageOptionPageWithTypeConverterPackage
    Inherits Package
    ''' <summary>
    ''' Default constructor of the package.
    ''' Inside this method you can place any initialization code that does not require 
    ''' any Visual Studio service because at this point the package object is created but 
    ''' not sited yet inside Visual Studio environment. The place to do all the other 
    ''' initialization is the Initialize method.
    ''' </summary>
    Public Sub New()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", Me.ToString()))
    End Sub



    '///////////////////////////////////////////////////////////////////////////
    ' Overriden Package Implementation
#Region "Package Members"

    ''' <summary>
    ''' Initialization of the package; this method is called right after the package is sited, so this is the place
    ''' where you can put all the initilaization code that rely on services provided by VisualStudio.
    ''' </summary>
    Protected Overrides Sub Initialize()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", Me.ToString()))
        MyBase.Initialize()

    End Sub
#End Region

End Class
