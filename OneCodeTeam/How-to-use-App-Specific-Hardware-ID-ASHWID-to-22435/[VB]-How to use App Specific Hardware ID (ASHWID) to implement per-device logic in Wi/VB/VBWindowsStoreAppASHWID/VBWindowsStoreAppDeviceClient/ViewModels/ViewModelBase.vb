'************************************* Module Header ***********************\
' Module Name:  ViewModelBase.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
' View Model base class which implement the INotifyPropertyChanged interface.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

''' <summary>
''' View Model base class which implement INotifyPropertyChanged interface.
''' </summary>
''' <remarks></remarks>
Public MustInherit Class ViewModelBase
    Implements INotifyPropertyChanged

    ''' <summary>
    ''' Property Changed Event
    ''' </summary>
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' Implment INotifyPropertyChanged's function, when binding data
    ''' in UI control, this function will invoke PropertyChanged event.
    ''' </summary>
    ''' <param name="propertyName"></param>
    Public Overridable Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class

