/****************************** Module Header ******************************\
* Module Name:	ITransition.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* An interface reprerents a transition. 
* Most code interacts with this interface rather a concrete transition class.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows;
using System.Xml.Linq;

namespace VideoStoryCreator.Transitions
{
    public interface ITransition
    {
        string Name { get; }
        TimeSpan TransitionDuration { get; set; }
        bool ImageZIndexModified { get; }

        // Foreground/BackgroundElement can be either Image or MediaElement.
        // Set these properties in the PreviewPage.
        FrameworkElement ForegroundElement { get; set; }
        FrameworkElement BackgroundElement { get; set; }

        event EventHandler TransitionCompleted;

        ITransition Clone();

        // Start/stop the transition.
        void Begin();
        void Stop();

        // Serilaize/deserialize the transition.
        void Save(XElement transitionElement);
    }
}
