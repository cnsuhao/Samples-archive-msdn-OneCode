Public Class RESTUserService
    Implements IUserService
    Shared _users As New Users()
    Public Function GetAllUsers() As Users Implements IUserService.GetAllUsers
        'IN YOUR CASE YOU'D PROBABLY ACCESS A DB
        'OR A WEB SERVICE TO RETRIEVE ACTUAL DATA
        GenerateFakeUsers()
        Return _users
    End Function
    Public Function AddNewUser(u As User) As User Implements IUserService.AddNewUser
        u.UserId = Guid.NewGuid().ToString()
        'IN YOUR CASE YOU'D PROBABLY ACCESS A DB
        'OR A WEB SERVICE TO SAVE ACTUAL DATA
        _users.Add(u)
        Return u
    End Function
    Public Function GetUser(user_id As String) As User Implements IUserService.GetUser
        Dim u = FindUser(user_id)
        Return u
    End Function
    Private Function FindUser(user_id As String) As User
        'IN YOUR CASE YOU'D PROBABLY ACCESS A DB
        'OR A WEB SERVICE TO RETRIEVE ACTUAL DATA
        Return New User() With {.FirstName = "FirstName1",
             .LastName = "LastName1",
             .Email = "email1@demoDomain.com",
             .UserId = "1"
        }
    End Function
    Private Sub GenerateFakeUsers()
        _users.Add(New User() With {
             .FirstName = "FirstName1",
             .LastName = "LastName1",
             .Email = "email1@demoDomain.com",
             .UserId = "1" _
        })
        _users.Add(New User() With {
             .FirstName = "FirstName2",
             .LastName = "LastName2",
             .Email = "email2@demoDomain.com",
             .UserId = "2"
        })
    End Sub
End Class