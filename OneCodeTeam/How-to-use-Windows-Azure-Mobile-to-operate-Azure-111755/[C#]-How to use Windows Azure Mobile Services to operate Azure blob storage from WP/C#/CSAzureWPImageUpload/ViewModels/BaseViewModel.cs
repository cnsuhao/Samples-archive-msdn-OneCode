/**************************** Module Header ********************************\
* Module Name:    BaseViewModel.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* BaseViewModel.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using CSAzureWPImageUpload.Common;

namespace CSAzureWPImageUpload.ViewModels
{

    public abstract class BaseViewModel : BindableBase
    {
        private string uniqueId = string.Empty;
        private string title = string.Empty;

        public BaseViewModel(string uniqueId, string title)
        {
            this.uniqueId = uniqueId;
            this.title = title;
        }

        public string UniqueId
        {
            get { return this.uniqueId; }
            set { this.SetProperty(ref this.uniqueId, value); }
        }

        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
   
}
