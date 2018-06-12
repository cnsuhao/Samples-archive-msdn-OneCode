<CollectionDataContract(Name:="users", [Namespace]:="")> _
Public Class Users
    Inherits List(Of User)
End Class
<DataContract(Name:="user", [Namespace]:="")> _
Public Class User
    <DataMember(Name:="id", Order:=1)> _
    Public UserId As String
    <DataMember(Name:="firstname", Order:=2)> _
    Public FirstName As String
    <DataMember(Name:="lastname", Order:=3)> _
    Public LastName As String
    <DataMember(Name:="email", Order:=4)> _
    Public Email As String
End Class