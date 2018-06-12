'****************************** Module Header ******************************\
' Module Name:  ViewModel.vb
' Project:      VBWP8CollectionViewSource
' Copyright (c) Microsoft Corporation
'
' This is the ViewModel.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Collections.ObjectModel
Imports System.IO.IsolatedStorage
Imports System.Windows
Imports VBWP8CollectionViewSource.ModelNamespace

Namespace ViewModelNamespace
    Public Class ViewModel
        ' Collection of ReadinessAndLevel.
        Public Property ReadinessAndLevels() As ObservableCollection(Of ReadinessAndLevel)
            Get
                Return _readinessAndLevels
            End Get
            Set(value As ObservableCollection(Of ReadinessAndLevel))
                _readinessAndLevels = value
            End Set
        End Property
        Private _readinessAndLevels As ObservableCollection(Of ReadinessAndLevel)

        ''' <summary>
        ''' Get ReadinessAndLevels.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GetReadinessAndLevels()
            If IsolatedStorageSettings.ApplicationSettings.Count > 0 Then
                GetSavedReadinessAndLevels()
            Else
                GetDefaultReadinessAndLevels()
            End If
        End Sub

        ''' <summary>
        ''' Initialization data.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GetDefaultReadinessAndLevels()
            Dim a As New ObservableCollection(Of ReadinessAndLevel)()

            ' Items to collect
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "ASPNET", _
                 .Type = "Item" _
            })
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "SharePoint", _
                 .Type = "Item" _
            })
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "Azure", _
                 .Type = "Item" _
            })
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "Windows Phone", _
                 .Type = "Item" _
            })

            ' Levels to complete
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "Level 100", _
                 .Type = "Level" _
            })
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "Level 200", _
                 .Type = "Level" _
            })
            a.Add(New ReadinessAndLevel() With { _
                 .Name = "Level 300", _
                 .Type = "Level" _
            })

            ReadinessAndLevels = a
            'MessageBox.Show("Got ReadinessAndLevels from default");
        End Sub

        ''' <summary>
        ''' IsolatedStorage data.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GetSavedReadinessAndLevels()
            Dim a As New ObservableCollection(Of ReadinessAndLevel)()

            For Each o As [Object] In IsolatedStorageSettings.ApplicationSettings.Values
                a.Add(DirectCast(o, ReadinessAndLevel))
            Next

            ReadinessAndLevels = a
            'MessageBox.Show("Got ReadinessAndLevels from storage");
        End Sub

        ''' <summary>
        ''' Save data to IsolatedStorage.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveReadinessAndLevels()
            Dim settings As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings

            For Each a As ReadinessAndLevel In ReadinessAndLevels
                If settings.Contains(a.Name) Then
                    settings(a.Name) = a
                Else
                    settings.Add(a.Name, a.GetCopy())
                End If
            Next

            settings.Save()
            MessageBox.Show("Finished saving ReadinessAndLevels")
        End Sub
    End Class

End Namespace
