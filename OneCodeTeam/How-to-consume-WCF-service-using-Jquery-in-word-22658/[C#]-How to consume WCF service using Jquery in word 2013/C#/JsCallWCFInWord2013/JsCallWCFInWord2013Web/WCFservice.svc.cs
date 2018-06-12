/****************************** Module Header ******************************\
* Module Name:  WCFservice.svc.cs
* Project:      JsCallWCFInWord2013
* Copyright(c)  Microsoft Corporation.
* 
* The Class is an custom WCF Service
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace jQueryWCF
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFservice
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public double Add(double left, double right)
        {
            return left + right;
        }
    }
}
