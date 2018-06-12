/****************************** Module Header ******************************\
Module Name:  IInstanceController.cs
Project:      InstanceController.Interface
Copyright (c) Microsoft Corporation.
 
A WCF service contract.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System.Collections.Generic;
using System.ServiceModel;

namespace InstanceController.Interface
{
    [ServiceContract(Name="IInstanceControllerService",Namespace="http://www.Onecode.com")]
    public interface IInstanceController
    {
        [OperationContract]
        List<string> GetInstanceInternalEndPoint();

        [OperationContract]
        void DownLoadFileFromBlob(string ContainerName, string FileName);

        [OperationContract]
        void RunExecutableFile(string Container, string FileName);

        [OperationContract]
        bool RunScriptOnEveryInstance(string Container, string FileName);

    }
}
