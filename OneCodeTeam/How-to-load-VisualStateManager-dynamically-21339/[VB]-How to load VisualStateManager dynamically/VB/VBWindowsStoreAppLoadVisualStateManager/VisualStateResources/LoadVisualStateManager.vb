'***************************** Module Header ******************************\
' Module Name:  LoadVisualStateManager.vb
' Project:      VBWindowsStoreAppLoadVisualStateManager
' Copyright (c) Microsoft Corporation.
'  
' This page used to load VisualStateManager and attach it to the page
'   
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Markup

Public NotInheritable Class LoadVisualStateManager
    Private Sub New()
    End Sub
    Public Shared Sub AttachVisualStateGroups(RootGrid As Grid, Optional VisualStateGroupKey As String = "ApplicationViewStates")
        ' Creates a VisualStateManager and attaches it to the RootGrid in GroupedItemsPage.xaml
        Dim manager As New VisualStateManager()
        VisualStateManager.SetCustomVisualStateManager(RootGrid, manager)

        ' Gets a reference to the VisualStateGroup collection that now exists in the RootGrid (thanks to the above code)
        Dim states As IList(Of VisualStateGroup) = VisualStateManager.GetVisualStateGroups(RootGrid)

        ' Dynamically loads the ResourceDictionary that contains the VisualState XAML
        Dim loadedResource As ResourceDictionary = GetVisualStateXaml()

        ' Get the VisualStateGroup from Resource Dictionary
        Dim vsgDynamic As VisualStateGroup = TryCast(loadedResource(VisualStateGroupKey), VisualStateGroup)
        loadedResource.Clear()

        ' Add the dynamically loaded VisualState into the RootGrid's VisualStateGroup's collection
        states.Add(vsgDynamic)
    End Sub

    Private Shared Function GetVisualStateXaml() As ResourceDictionary
        ' Get the namespace for this class that lives in the same namespace location as the ResourceDictionary 
        Dim RunTimeNamespace = GetType(LoadVisualStateManager).GetTypeInfo().[Namespace]

        ' Load the resource dictionary into a stream
        Dim ResourceDictionaryFilename As String = "VisualStatePage.xaml"
        Dim resource As Stream = GetType(LoadVisualStateManager).GetTypeInfo().Assembly.GetManifestResourceStream(Convert.ToString(RunTimeNamespace) & "." & ResourceDictionaryFilename)

        ' Create an instance of a ResourceDictionary from the resource Stream
        Dim loadedResource As ResourceDictionary = TryCast(XamlReader.Load(New StreamReader(resource).ReadToEnd()), ResourceDictionary)

        Return loadedResource
    End Function
End Class