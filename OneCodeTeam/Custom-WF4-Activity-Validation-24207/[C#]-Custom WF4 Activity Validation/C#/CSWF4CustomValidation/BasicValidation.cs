/****************************** Module Header ******************************\
* Module Name:  BasicValidation.cs
* Project:		CSWF4CustomValidation
* Copyright (c) Microsoft Corporation.
* 
* This is a custom activity inherited from NativeActivity. PersonInfo activity
* can validate the input age automatically. if the input age number is negative
* There will be a red ball appear in the designer and tell user "age must larger"
* than 0. 
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
\***************************************************************************/
using System;
using System.Activities;

namespace CSWF4CustomValidation
{
    public class PersonInfo : NativeActivity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            if (Age < 0)
            {
                metadata.AddValidationError("age must larger than 0");
            }
        }

        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine(Name + " " + Age);
        }
    }
}
