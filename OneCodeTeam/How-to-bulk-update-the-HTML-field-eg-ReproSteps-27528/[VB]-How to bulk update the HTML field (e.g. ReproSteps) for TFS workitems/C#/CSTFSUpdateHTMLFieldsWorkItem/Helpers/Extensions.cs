/****************************** Module Header ******************************\
 * Module Name:  Extensions.cs
 * Project:      Common
 * Copyright (c) Microsoft Corporation.
 * 
 * Extensions class.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


namespace Common
{
    using System;

    using Microsoft.TeamFoundation.WorkItemTracking.Client;

    public static class Extensions
    {
        #region Methods

        public static bool IsDisplayable(this Field field, int revision)
        {
            if (field.FieldDefinition == null) return false;

            switch ((CoreField)field.Id)
            {
                case CoreField.History:
                case CoreField.ChangedDate:
                case CoreField.RevisedDate:
                case CoreField.ChangedBy:
                case CoreField.AuthorizedAs:
                    return false;

                default:
                    break;
            }

            if (revision == 0)
            {
                if (field.Value == null ||
                   Equals(field.Value, String.Empty) ||
                   Equals(field.Value, 0)) return false;
            }

            return true;
        }

        #endregion Methods
    }
}