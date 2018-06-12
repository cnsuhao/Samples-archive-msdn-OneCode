/****************************** Module Header ******************************\
 * Module Name:  ManagedValue.cs
 * Project:      CSMDbgEvaluateFunction
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a managed value. 
 * 
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.Samples.Debugging.MdbgEngine;

namespace CSMDbgEvaluateFunction.Debugger
{
   public  class ManagedValue
    {
       public MDbgValue MDbgValue { get; private set; }

       public string Name { get; private set; }

       public string Type { get; private set; }

       public string Value { get; private set; }


       public ManagedValue(MDbgValue value)
       {
           this.MDbgValue = value;
           this.Name = value.Name;
           this.Type = value.TypeName;
           this.Value = value.GetStringValue(0, true);
       }
    }
}
