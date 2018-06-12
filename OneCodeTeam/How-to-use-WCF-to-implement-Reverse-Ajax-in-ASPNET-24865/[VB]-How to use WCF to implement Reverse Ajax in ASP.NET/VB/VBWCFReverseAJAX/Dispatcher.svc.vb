Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text


<ServiceContract([Namespace]:="")> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class Dispatcher
    ' To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
    ' To create an operation that returns XML,
    '     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
    '     and include the following line in the operation body:
    '         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

    ''' <summary>
    ''' Dispatch the new message event.
    ''' </summary>
    ''' <param name="userName">The loged in user name</param>
    ''' <returns>the message content</returns>
    ''' <remarks></remarks>
    '''[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]   
    <OperationContract> _
    <WebInvoke(RequestFormat:=WebMessageFormat.Json, ResponseFormat:=WebMessageFormat.Json)> _
    Public Function WaitMessage(userName As String) As String
        Return ClientAdapter.Instance.GetMessage(userName)
    End Function
End Class

