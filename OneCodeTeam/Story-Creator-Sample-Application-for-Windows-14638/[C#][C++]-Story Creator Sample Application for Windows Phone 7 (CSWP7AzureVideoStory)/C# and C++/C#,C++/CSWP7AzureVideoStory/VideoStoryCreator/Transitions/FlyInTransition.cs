/****************************** Module Header ******************************\
* Module Name:	FlyInTransition.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* Implements a simple fly in transition.
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
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace VideoStoryCreator.Transitions
{
    public sealed class FlyInTransition : TransitionBase
    {
        private Storyboard _transitionStoryboard;
        private DoubleAnimationUsingKeyFrames _flyAnimation;
        private FlyDirection _direction;
        private FrameworkElement _backgroundElement;
        private FrameworkElement _foregroundElement;
        public override event EventHandler TransitionCompleted;

        public FlyInTransition()
        {
            this.TransitionDuration = TimeSpan.FromSeconds(2d);
            this._transitionStoryboard = new Storyboard();
            this._flyAnimation = new DoubleAnimationUsingKeyFrames();
            this._transitionStoryboard.Children.Add(_flyAnimation);
            this.Direction = FlyDirection.Left;
            this._transitionStoryboard.Completed += new EventHandler(TransitionStoryboard_Completed);
        }

        public override string Name
        {
            get { return "Fly In Transition"; }
        }

        public FlyDirection Direction
        {
            get { return this._direction; }
            set
            {
                this._direction = value;

                // Reset the key frames.
                this._flyAnimation.KeyFrames.Clear();
                EasingDoubleKeyFrame frame1 = null;
                EasingDoubleKeyFrame frame2 = null;

                // If BackgroundElement is null, we'll add the key frames later.
                if (this.BackgroundElement != null)
                {
                    frame1 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero) };
                    frame2 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(this.TransitionDuration) };
                }

                // Configure the property to animate depending on the fly direction.
                if (value == FlyDirection.Left || value == FlyDirection.Right)
                {
                    Storyboard.SetTargetProperty(this._flyAnimation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                    if (this.BackgroundElement != null)
                    {
                        frame1.Value = (value == FlyDirection.Left) ? -this.BackgroundElement.ActualWidth : this.BackgroundElement.ActualWidth;
                        frame2.Value = 0;
                    }
                }
                else
                {
                    Storyboard.SetTargetProperty(this._flyAnimation, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
                    if (this.BackgroundElement != null)
                    {
                        frame1.Value = (value == FlyDirection.Up) ? this.BackgroundElement.ActualHeight : -this.BackgroundElement.ActualHeight;
                        frame2.Value = 0;
                    }
                }

                if (this.BackgroundElement != null)
                {
                    this._flyAnimation.KeyFrames.Add(frame1);
                    this._flyAnimation.KeyFrames.Add(frame2);
                }
            }
        }

        public override FrameworkElement BackgroundElement
        {
            get
            {
                return this._backgroundElement;
            }
            set
            {
                if (value != null)
                {
                    this._backgroundElement = value;
                    this._backgroundElement.SetValue(Canvas.ZIndexProperty, 2);
                    Storyboard.SetTarget(this._flyAnimation, value);
                    this._backgroundElement.RenderTransform = new TranslateTransform();

                    // Reset the key frames.
                    this._transitionStoryboard.Stop();
                    this._flyAnimation.KeyFrames.Clear();
                    EasingDoubleKeyFrame frame1 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero) }; ;
                    EasingDoubleKeyFrame frame2 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(this.TransitionDuration) };

                    // Configure the property to animate depending on the fly direction.
                    if (this.Direction == FlyDirection.Left || this.Direction == FlyDirection.Right)
                    {
                        Storyboard.SetTargetProperty(this._flyAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                        frame1.Value = (this.Direction == FlyDirection.Left) ? -value.ActualWidth : value.ActualWidth;
                        frame2.Value = 0;
                    }
                    else
                    {
                        Storyboard.SetTargetProperty(this._flyAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
                        frame1.Value = (this.Direction == FlyDirection.Up) ? -value.ActualHeight : value.ActualHeight;
                        frame2.Value = 0;
                    }

                    this._flyAnimation.KeyFrames.Add(frame1);
                    this._flyAnimation.KeyFrames.Add(frame2);
                }
            }
        }

        public override FrameworkElement ForegroundElement
        {
            get { return this._foregroundElement; }
            set
            {
                if (value != null)
                {
                    this._foregroundElement = value;
                    if (value != null)
                    {
                        this._foregroundElement.SetValue(Canvas.ZIndexProperty, 0);
                    }
                }
            }
        }

        public override bool ImageZIndexModified
        {
            get
            {
                // This transition altered the background/foreground images' z-index.
                // So we must return true.
                return true;
            }
        }

        public override void Begin()
        {
            this._transitionStoryboard.Begin();
        }

        public override void Stop()
        {
            this._transitionStoryboard.Stop();
        }

        void TransitionStoryboard_Completed(object sender, EventArgs e)
        {
            // Reset the render transform as it is no longer needed.
            this.BackgroundElement.RenderTransform = null;
            if (this.TransitionCompleted != null)
            {
                this.TransitionCompleted(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Serialize additional properties specific to this transition.
        /// Namely, the FlyDirection property.
        /// </summary>
        public override void Save(XElement transitionElement)
        {
            transitionElement.Add(new XAttribute("Direction", this.Direction));
            base.Save(transitionElement);
        }

        /// <summary>
        /// Deserialize additional properties specific to this transition.
        /// Namely, the FlyDirection property.
        /// </summary>
        protected override void LoadChild(XElement transitionElement)
        {
            try
            {
                this.Direction = (FlyDirection)Enum.Parse(typeof(FlyDirection), transitionElement.Attribute("Direction").Value, true);
            }
            catch
            {
                // TODO: Is it safe to just ignore the exception, and use the default value?
            }
            base.LoadChild(transitionElement);
        }

        public override ITransition Clone()
        {
            return new FlyInTransition()
            {
                BackgroundElement = this.BackgroundElement,
                ForegroundElement = this.ForegroundElement,
                TransitionDuration = this.TransitionDuration,
                Direction = this.Direction
            };
        }

        public enum FlyDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
