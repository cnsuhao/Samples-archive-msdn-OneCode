/****************************** Module Header ******************************\
* Module Name:    IService1.cs
* Project:        CSWCFServiceDualAuthentication
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to use both User Name and Client Certificates 
* as client credential type in WCF.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System.ServiceModel;

namespace CSWCFServiceDualAuthentication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(string value);
    }

   
}



    