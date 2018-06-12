using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;

namespace RESTfulWCFService
{
    [ServiceContract]
    interface IUserService
    {
        [WebGet(UriTemplate = "/users",
                ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        Users GetAllUsers();
        [WebInvoke(UriTemplate = "/users",
                   Method = "POST",
                   RequestFormat = WebMessageFormat.Xml,
                   ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        User AddNewUser(User u);

        [WebGet(UriTemplate = "/users/{user_id}",
                ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        User GetUser(string user_id);
    } 
}
