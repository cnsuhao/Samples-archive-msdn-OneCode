/****************************** Module Header ******************************\
* Module Name:	TransitionFactory.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A factory class used to create transitions and their designers.
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
using System.Collections.Generic;
using System.Windows.Controls;

namespace VideoStoryCreator.Transitions
{
    public class TransitionFactory
    {
        private static Dictionary<string, Type> _transitionNameTypes = new Dictionary<string, Type>();
        private static Dictionary<string, Type> _transitionNameDesigners = new Dictionary<string, Type>();
        private static List<string> _transitionNames = new List<string>();

        static TransitionFactory()
        {
            _transitionNameTypes.Add("Fade Transition", typeof(FadeTransition));
            _transitionNames.Add("Fade Transition");

            _transitionNameTypes.Add("Fly In Transition", typeof(FlyInTransition));
            _transitionNameDesigners.Add("Fly In Transition", typeof(FlyInTransition_Design));
            _transitionNames.Add("Fly In Transition");

            // Register additional transitions here...
        }

        private TransitionFactory()
        {
        }

        /// <summary>
        /// Create a transition based on its name.
        /// </summary>
        /// <param name="name">The transition's name.</param>
        /// <returns>An ITransition object.</returns>
        public static ITransition CreateTransition(string name)
        {
            if (_transitionNameTypes.ContainsKey(name))
            {
                Type transitionType = _transitionNameTypes[name];
                try
                {
                    return Activator.CreateInstance(transitionType) as ITransition;
                }
                catch
                {
                    // TODO: Should we throw the exception or simply return null?
                }
            }
            return null;
        }

        /// <summary>
        /// For now, by default we create a fade transition.
        /// </summary>
        public static ITransition CreateDefaultTransition()
        {
            return new FadeTransition();
        }

        /// <summary>
        /// Create a transition designer based on its name.
        /// </summary>
        /// <param name="name">The transition's name.</param>
        /// <returns>A UserContro. All designers must inherite from UserControl.</returns>
        public static UserControl CreateTransitionDesigner(string name)
        {
            if (_transitionNameDesigners.ContainsKey(name) && _transitionNameDesigners[name] != null)
            {
                Type transitionDeginerType = _transitionNameDesigners[name];
                try
                {
                    return Activator.CreateInstance(transitionDeginerType) as UserControl;
                }
                catch
                {
                    // Todo: Should we throw the exception or simply return null?
                }
            }
            return null;
        }

        /// <summary>
        /// Return a list of transition names.
        /// </summary>
        public static List<string> AvailableTransitions
        {
            get { return _transitionNames; }
        }
    }
}
