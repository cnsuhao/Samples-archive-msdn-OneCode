/****************************** Module Header ******************************\
 * Module Name:  ViewModelBase.cs
 * Project:      CSWindowsStoreAppDeviceClient
 * Copyright (c) Microsoft Corporation.
 * 
 * View Model base class which implement the INotifyPropertyChanged interface.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.ComponentModel;

namespace CSWindowsStoreAppDeviceClient.ViewModel
{
    /// <summary>
    /// View Model base class and implement INotifyPropertyChanged interface.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Implment INotifyPropertyChanged's function, when binding data
        /// in UI control, this function will invoke PropertyChanged event.
        /// </summary>
        /// <param name="propertyName"></param>
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
