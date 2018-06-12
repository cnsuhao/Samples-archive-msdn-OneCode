/****************************** Module Header ******************************\
 * Module Name: AddService.svc.cs
 * Project:      JSONWCFService
 * Copyright (c) Microsoft Corporation.
 * 
 * This class is custom JSON Service
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;

namespace JSONWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AddServiceService : IAddService
    {
        public decimal Add(string Number1, string Number2,out string error)
        {
            decimal result=0;
            error = null;
            try
            {
                result = Convert.ToDecimal(Number1) + Convert.ToDecimal(Number2);    
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }

            return result;
        }      
    }
}
