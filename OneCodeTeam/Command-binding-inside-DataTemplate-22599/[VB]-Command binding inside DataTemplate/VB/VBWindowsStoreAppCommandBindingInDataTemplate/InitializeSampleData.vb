Imports System.Collections.ObjectModel
Imports VBWindowsStoreAppCommandBindingInDataTemplate.Model



Public Class InitializeSampleData
    Public Shared Function GetData() As ObservableCollection(Of Customer)
        Dim Customers As New ObservableCollection(Of Customer)()

        Customers.Add(New Customer() With { _
            .Id = 1, _
            .Name = "Allen", _
            .Sex = True, _
            .Age = 25, _
            .Vip = True _
        })
        Customers.Add(New Customer() With { _
            .Id = 2, _
            .Name = "Carter", _
            .Sex = True, _
            .Age = 26, _
            .Vip = True _
        })
        Customers.Add(New Customer() With { _
            .Id = 3, _
            .Name = "Rose", _
            .Sex = True, _
            .Age = 30, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 4, _
            .Name = "Daisy", _
            .Sex = False, _
            .Age = 20, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 5, _
            .Name = "Mary", _
            .Sex = False, _
            .Age = 15, _
            .Vip = True _
        })
        Customers.Add(New Customer() With { _
            .Id = 6, _
            .Name = "Ray", _
            .Sex = True, _
            .Age = 39, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 7, _
            .Name = "Sherry", _
            .Sex = False, _
            .Age = 55, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 8, _
            .Name = "Lisa", _
            .Sex = False, _
            .Age = 32, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 9, _
            .Name = "Judy", _
            .Sex = False, _
            .Age = 19, _
            .Vip = True _
        })
        Customers.Add(New Customer() With { _
            .Id = 10, _
            .Name = "Jack", _
            .Sex = True, _
            .Age = 28, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 11, _
            .Name = "May", _
            .Sex = False, _
            .Age = 20, _
            .Vip = False _
        })
        Customers.Add(New Customer() With { _
            .Id = 12, _
            .Name = "Vivian", _
            .Sex = False, _
            .Age = 32, _
            .Vip = True _
        })

        Return Customers
    End Function
End Class
