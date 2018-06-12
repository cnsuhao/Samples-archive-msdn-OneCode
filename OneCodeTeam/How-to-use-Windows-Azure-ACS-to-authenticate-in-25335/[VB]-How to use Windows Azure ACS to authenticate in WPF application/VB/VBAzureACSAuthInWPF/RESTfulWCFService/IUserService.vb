Imports System.ServiceModel.Web

<ServiceContract> _
Interface IUserService
    <WebGet(UriTemplate:="/users", ResponseFormat:=WebMessageFormat.Xml)> _
    <OperationContract> _
    Function GetAllUsers() As Users
    <WebInvoke(UriTemplate:="/users", Method:="POST", RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
    <OperationContract> _
    Function AddNewUser(u As User) As User

    <WebGet(UriTemplate:="/users/{user_id}", ResponseFormat:=WebMessageFormat.Xml)> _
    <OperationContract> _
    Function GetUser(user_id As String) As User
End Interface