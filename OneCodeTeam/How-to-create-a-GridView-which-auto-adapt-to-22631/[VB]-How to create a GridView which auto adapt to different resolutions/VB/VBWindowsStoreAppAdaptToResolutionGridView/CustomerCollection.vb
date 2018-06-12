'***************************** Module Header ******************************\
' Module Name:  CustomerCollection.vb
' Project:      VBWindowsStoreAppAdaptToResolutionGridView
' Copyright (c) Microsoft Corporation.
'  
' This is the demo data
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

Public Class CustomerCollection
    Public Shared Customers As New ObservableCollection(Of Customer)()
    Shared Sub New()
        Customers.Add(New Customer() With { _
            .Name = "Allen", _
            .Age = 25, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Carter", _
            .Age = 26, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Rose", _
            .Age = 30, _
            .Sex = True, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Dove", _
            .Age = 33, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Mary", _
            .Age = 30, _
            .Sex = False, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "William", _
            .Age = 42, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Daisy", _
            .Age = 16, _
            .Sex = False, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Elena", _
            .Age = 17, _
            .Sex = False, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Tracy", _
            .Age = 35, _
            .Sex = False, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Alex", _
            .Age = 23, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Mike", _
            .Age = 50, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Lisa", _
            .Age = 23, _
            .Sex = False, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Andrew", _
            .Age = 19, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Steve", _
            .Age = 39, _
            .Sex = True, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Jim", _
            .Age = 14, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Mason", _
            .Age = 25, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Michael", _
            .Age = 26, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Alan", _
            .Age = 30, _
            .Sex = True, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Steven", _
            .Age = 33, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Sherry", _
            .Age = 30, _
            .Sex = False, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Hugh", _
            .Age = 42, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Doris", _
            .Age = 16, _
            .Sex = False, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Stephanie", _
            .Age = 17, _
            .Sex = False, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Bonnie", _
            .Age = 35, _
            .Sex = False, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Alexander", _
            .Age = 23, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Bob", _
            .Age = 50, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Lucy", _
            .Age = 23, _
            .Sex = False, _
            .FavouriteSport = Sport.Basketball _
        })
        Customers.Add(New Customer() With { _
            .Name = "Jack", _
            .Age = 19, _
            .Sex = True, _
            .FavouriteSport = Sport.Football _
        })
        Customers.Add(New Customer() With { _
            .Name = "Jason", _
            .Age = 39, _
            .Sex = True, _
            .FavouriteSport = Sport.Swimming _
        })
        Customers.Add(New Customer() With { _
            .Name = "Scott", _
            .Age = 14, _
            .Sex = True, _
            .FavouriteSport = Sport.Basketball _
        })
    End Sub
End Class
