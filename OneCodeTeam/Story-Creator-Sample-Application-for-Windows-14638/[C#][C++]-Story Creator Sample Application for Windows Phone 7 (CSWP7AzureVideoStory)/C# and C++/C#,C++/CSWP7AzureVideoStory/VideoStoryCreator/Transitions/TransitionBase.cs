/****************************** Module Header ******************************\
* Module Name:	TransitionBase.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A base class that provides some default implementation of ITransition.
* A transition class can inherite this base class,
* or it can implement ITransition directly.
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
    public abstract class TransitionBase : ITransition
    {
        /// <summary>
        /// A derived class must implement this event.
        /// </summary>
        public virtual event EventHandler TransitionCompleted
        {
            add { throw new NotSupportedException(); }
            remove { }
        }

        public abstract string Name { get; }
        public virtual FrameworkElement ForegroundElement { get; set; }
        public virtual FrameworkElement BackgroundElement { get; set; }
        public virtual TimeSpan TransitionDuration { get; set; }

        public virtual bool ImageZIndexModified
        {
            get { return false; }
        }

        public abstract void Begin();
        public abstract void Stop();

        public virtual void Save(XElement transitionElement)
        {
            transitionElement.Add(new XAttribute("Name", this.Name));
            transitionElement.Add(new XAttribute("Duration", this.TransitionDuration.TotalSeconds));
        }

        public static ITransition Load(XElement transitionElement)
        {
            string name = transitionElement.Attribute("Name").Value;
            ITransition transition = TransitionFactory.CreateTransition(name);
            if (transition != null)
            {
                try
                {
                    string durationString = transitionElement.Attribute("Duration").Value;
                    int duration = int.Parse(durationString);
                    transition.TransitionDuration = TimeSpan.FromSeconds(duration);

                    // Todo: Need to review the design. We don't want to expose LoadChild on ITransition.
                    // But convert ITransition to TransitionBase and invoke LoadChild may not be a very good design.
                    ((TransitionBase)transition).LoadChild(transitionElement);
                }
                catch
                {
                    throw new Exception("Unable to load the transition.");
                }
            }
            return transition;
        }

        protected virtual void LoadChild(XElement transitionElement)
        { 
        }

        public abstract ITransition Clone();
    }
}
