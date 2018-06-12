/****************************** Module Header ******************************\
* Module Name:	ChoosePhotoViewModel.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A view model used in the choose photo page.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


namespace VideoStoryCreator.ViewModels
{
    public class ChoosePhotoViewModel : PhotoViewModel
    {
        public bool IsSelected { get; set; }
    }
}
