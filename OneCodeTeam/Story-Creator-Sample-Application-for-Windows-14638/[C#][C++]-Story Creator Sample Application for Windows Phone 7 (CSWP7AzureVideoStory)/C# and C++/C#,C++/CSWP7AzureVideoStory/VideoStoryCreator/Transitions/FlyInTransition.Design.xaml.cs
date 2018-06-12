/****************************** Module Header ******************************\
* Module Name:	FlyInTransition_Design.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* Provides additional design surface for the fly in transition.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.Generic;
using System.Windows.Controls;

namespace VideoStoryCreator.Transitions
{
    public partial class FlyInTransition_Design : UserControl
    {
        public FlyInTransition_Design()
        {
            InitializeComponent();
            List<VideoStoryCreator.Transitions.FlyInTransition.FlyDirection> directions = new List<VideoStoryCreator.Transitions.FlyInTransition.FlyDirection>()
            {
                VideoStoryCreator.Transitions.FlyInTransition.FlyDirection.Left,
                VideoStoryCreator.Transitions.FlyInTransition.FlyDirection.Right,
                VideoStoryCreator.Transitions.FlyInTransition.FlyDirection.Up,
                VideoStoryCreator.Transitions.FlyInTransition.FlyDirection.Down
            };
            this.directionList.ItemsSource = directions;
        }
    }
}
