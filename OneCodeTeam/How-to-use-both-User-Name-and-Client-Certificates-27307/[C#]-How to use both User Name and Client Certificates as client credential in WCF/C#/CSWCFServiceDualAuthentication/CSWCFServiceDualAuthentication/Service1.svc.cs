/****************************** Module Header ******************************\
* Module Name:    Service1.cs
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

using System;
using System.ServiceModel;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;

namespace CSWCFServiceDualAuthentication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.


    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
    }

    // Define the UserName Password Validator class 

    public class MyUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "Melissa" && password == "123@abc"))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
                // When you do not want to throw an infomative fault to the client,
                // throw the following exception.
                // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
        }
    }

    // Define the Certificate Validator class

    public class CertificateValidate : X509CertificateValidator
    {  
        public override void Validate(X509Certificate2 Certificate)
        {
            //Check for the certificate

            if (Certificate == null)
                throw new ArgumentNullException("Unable to find certificate");

            // Check the Incoming client certificate
            if (Certificate.IssuerName.Name != "CN=MSIT Enterprise CA 2")
                throw new System.IdentityModel.Tokens.SecurityTokenValidationException("Cannot find the issuer");
            }        
    }
}

       



       
