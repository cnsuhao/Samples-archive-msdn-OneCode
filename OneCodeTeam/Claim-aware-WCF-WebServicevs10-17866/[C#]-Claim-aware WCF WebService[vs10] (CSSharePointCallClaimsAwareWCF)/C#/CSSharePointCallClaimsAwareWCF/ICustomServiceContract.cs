/****************************** Module Header ******************************\
* Module Name:    ICustomServiceContract.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is the interface for Wcf WebService
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.ServiceModel;

namespace CustomService
{
    [ServiceContract]
    public interface ICustomServiceContract
    {     
        [OperationContractAttribute(Name = "Add")]
        int Add(int a, int b);

        [OperationContractAttribute(Name = "HelloWorld")]
        string HelloWorld();
    }
}