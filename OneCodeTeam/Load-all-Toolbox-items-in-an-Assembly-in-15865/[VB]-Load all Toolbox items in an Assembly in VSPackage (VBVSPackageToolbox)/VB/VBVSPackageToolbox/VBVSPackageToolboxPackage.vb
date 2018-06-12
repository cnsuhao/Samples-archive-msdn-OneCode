'*************************** Module Header *****************************'
' Module Name:  VBVSPackageToolboxPackage.vb
' Project:      VBVSPackageToolbox
' Copyright (c) Microsoft Corporation.
' 
' Implementation of VBVSPackageToolbox
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'


Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell
Imports System.Collections
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Reflection

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
' The PackageRegistration attribute tells the registration utility (regpkg.exe) that this class needs
' to be registered as package.
'
' A Visual Studio component can be registered under different regitry roots; for instance
' when you debug your package you want to register it in the experimental hive. The DefaultRegistryRoot
' attribute specifies the registry root to use if no one is provided to regpkg.exe with
' the /root switch.
'
' The InstalledProductRegistration attribute is used to register the information needed to show this package
' in the Help/About dialog of Visual Studio.
'
' In order be loaded inside Visual Studio in a machine that does not have the VS SDK installed, 
' the package needs to have a valid load key (it can be requested at 
' http://msdn.microsoft.com/vstudio/extend/). The [ProvideLoadKey attribute tells the shell that this 
' package has a load key embedded in its resources.
'
' The ProvideMenuResource attribute is needed to let the shell know that this package exposes some menus.

<PackageRegistration(UseManagedResourcesOnly:=True), _
DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0"), _
InstalledProductRegistration(False, "#110", "#112", "1.0", IconResourceID:=400), _
ProvideLoadKey("Standard", "1.0", "Package Name", "Company", 1), _
ProvideMenuResource(1000, 1), _
Guid(GuidList.guidVBVSPackageToolboxPkgString), _
ProvideToolboxItems(1)> _
Public NotInheritable Class VBVSPackageToolboxPackage
    Inherits Package

    ''' <summary>
    ''' Default constructor of the package.
    ''' Inside this method you can place any initialization code that does not require 
    ''' any Visual Studio service because at this point the package object is created but 
    ''' not sited yet inside Visual Studio environment. The place to do all the other 
    ''' initialization is the Initialize method.
    ''' </summary>
    Public Sub New()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", Me.GetType().Name))
    End Sub

    ' List for the toolbox items provided by this package.
    Private ToolboxItemList As ArrayList

    ' Name for the Toolbox category tab for the package's toolbox items.
    Private CategoryTab As String = "LoadToolboxMemberDemo"

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Overriden Package Implementation
#Region "Package Members"

    ''' <summary>
    ''' Initialization of the package; this method is called right after the package is sited, so this is the place
    ''' where you can put all the initilaization code that rely on services provided by VisualStudio.
    ''' </summary>
    Protected Overrides Sub Initialize()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", Me.ToString()))
        MyBase.Initialize()

        ' Add our command handlers for menu (commands must exist in the .vsct file)
        Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
        If Nothing IsNot mcs Then
            ' Create the command for the menu item.
            Dim menuCommandID As New CommandID(GuidList.guidVBVSPackageToolboxCmdSet, CInt(Fix(PkgCmdIDList.cmdidInitializeToolbox)))
            Dim menuItem As New MenuCommand(AddressOf MenuItemCallback, menuCommandID)
            mcs.AddCommand(menuItem)

            ' Subscribe to the toolbox intitialized and upgraded events.
            AddHandler ToolboxInitialized, AddressOf OnRefreshToolbox
            AddHandler ToolboxUpgraded, AddressOf OnRefreshToolbox
        End If

        ' Use reflection to get the toolbox items provided in this assembly.
        ToolboxItemList = CreateItemList(Me.GetType().Assembly)
        If Nothing Is ToolboxItemList Then
            ' Unable to generate the list.
            ' Add error handling code here.
        End If
    End Sub
#End Region

    ''' <summary>
    ''' This function is the callback used to execute a command when the a menu item is clicked.
    ''' See the Initialize method to see how the menu item is associated to this function using
    ''' the OleMenuCommandService service and the MenuCommand class.
    ''' </summary>
    Private Sub MenuItemCallback(ByVal sender As Object, ByVal e As EventArgs)
        Dim pkg As IVsPackage = TryCast(GetService(GetType(Package)), Package)
        pkg.ResetDefaults(CUInt(__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS))
    End Sub

#Region "Get the Toolbox items with reflection"
    ' Scan for toolbox items in the assembly and return the list of
    ' toolbox items.
    Private Function CreateItemList(ByVal [assembly] As System.Reflection.Assembly) As ArrayList
        Dim list As New ArrayList()
        For Each possibleItem As Type In [assembly].GetTypes()
            Dim item As ToolboxItem = CreateToolboxItem(possibleItem)
            If item IsNot Nothing Then
                list.Add(item)
            End If
        Next possibleItem
        Return list
    End Function

    ' If the type represents a toolbox item, return an instance of the type;
    ' otherwise, return null.
    Private Function CreateToolboxItem(ByVal possibleItem As Type) As ToolboxItem
        ' A toolbox item must implement IComponent and must not be abstract.
        If (Not GetType(IComponent).IsAssignableFrom(possibleItem)) OrElse possibleItem.IsAbstract Then
            Return Nothing
        End If

        ' A toolbox item must have a constructor that takes a parameter of
        ' type Type or a constructor that takes no parameters.
        If Nothing Is possibleItem.GetConstructor(New Type() {GetType(Type)}) AndAlso Nothing Is possibleItem.GetConstructor(New Type() {}) Then
            Return Nothing
        End If

        Dim item As ToolboxItem = Nothing

        ' Check the custom attributes of the candidate type and attempt to
        ' create an instance of the toolbox item type.
        Dim attribs As AttributeCollection = TypeDescriptor.GetAttributes(possibleItem)
        Dim tba As ToolboxItemAttribute = TryCast(attribs(GetType(ToolboxItemAttribute)), ToolboxItemAttribute)
        If tba IsNot Nothing AndAlso (Not tba.Equals(ToolboxItemAttribute.None)) Then
            If Not tba.IsDefaultAttribute() Then
                ' This type represents a custom toolbox item implementation.
                Dim itemType As Type = tba.ToolboxItemType
                Dim ctor As ConstructorInfo = itemType.GetConstructor(New Type() {GetType(Type)})
                If ctor IsNot Nothing AndAlso itemType IsNot Nothing Then
                    item = CType(ctor.Invoke(New Object() {possibleItem}), ToolboxItem)
                Else
                    ctor = itemType.GetConstructor(New Type() {})
                    If ctor IsNot Nothing Then
                        item = CType(ctor.Invoke(New Object() {}), ToolboxItem)
                        item.Initialize(possibleItem)
                    End If
                End If
            Else
                ' This type represents a default toolbox item.
                item = New ToolboxItem(possibleItem)
            End If
        End If
        If item Is Nothing Then
            Throw New ApplicationException("Unable to create a ToolboxItem " & "object from " & possibleItem.FullName & ".")
        End If

        ' Update the display name of the toolbox item and add the item to
        ' the list.
        Dim displayName As DisplayNameAttribute = TryCast(attribs(GetType(DisplayNameAttribute)), DisplayNameAttribute)
        If displayName IsNot Nothing AndAlso (Not displayName.IsDefaultAttribute()) Then
            item.DisplayName = displayName.DisplayName
        End If

        Return item
    End Function

#End Region

#Region "The event handlers for the ToolboxInitialized and ToolboxUpgraded"
    Private Sub OnRefreshToolbox(ByVal sender As Object, ByVal e As EventArgs)
        ' Add new instances of all ToolboxItems contained in ToolboxItemList.
        Dim service As IToolboxService = TryCast(GetService(GetType(IToolboxService)), IToolboxService)
        Dim toolbox As IVsToolbox = TryCast(GetService(GetType(IVsToolbox)), IVsToolbox)

        'Remove target tab and all controls under it.
        For Each oldItem As ToolboxItem In service.GetToolboxItems(CategoryTab)
            service.RemoveToolboxItem(oldItem)
        Next oldItem
        toolbox.RemoveTab(CategoryTab)

        For Each itemFromList As ToolboxItem In ToolboxItemList
            service.AddToolboxItem(itemFromList, CategoryTab)
        Next itemFromList
        service.SelectedCategory = CategoryTab

        service.Refresh()
    End Sub

#End Region


End Class