/****************************** Module Header ******************************\
 * Module Name: Service1.svc.cs
 * Project:     CSASPNETLoadAndExecuteDynamicJS
 * Copyright (c) Microsoft Corporation. 
 * This source is subject to the Microsoft Public License. 
 *
 * A simple service.
 * 
 * See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL 
 * All other rights reserved. 
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\****************************************************************************/
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web;

namespace CSASPNETLoadAndExecuteDynamicJS
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string LoadScript(string source)
        {
            // Add your operation implementation here
            return "Scripts/" + source;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
