/****************************** Module Header ******************************\
* Module Name:	ComposePhotoViewModel.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A view model used in the compose page.
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
using System.Linq;
using System.Windows.Controls;
using VideoStoryCreator.Models;
using VideoStoryCreator.Transitions;

namespace VideoStoryCreator.ViewModels
{
    public class ComposePhotoViewModel : PhotoViewModel
    {
        public ITransition Transition { get; set; }

        private UserControl _transitionDesigner;
        public UserControl TransitionDesigner
        {
            get
            {
                return this._transitionDesigner;
            }
            set
            {
                if (this._transitionDesigner != value)
                {
                    this._transitionDesigner = value;
                    this.NotifyPropertyChange("TransitionDesigner");
                }
            }
        }

        public List<string> AvailableTransitions
        {
            get
            {
                return TransitionFactory.AvailableTransitions;
            }
        }

        /// <summary>
        /// Clone this view model.
        /// </summary>
        /// <returns>A copy of this view model.</returns>
        public ComposePhotoViewModel CopyTo()
        {
            ComposePhotoViewModel copy = new ComposePhotoViewModel()
            {
                Name = this.Name,
                PhotoDuration = this.PhotoDuration,
                TransitionDuration = this.TransitionDuration,
                MediaStream = this.MediaStream
            };
            if (this.Transition != null)
            {
                copy.Transition = this.Transition.Clone();
            }
            return copy;
        }

        /// <summary>
        /// Update values of this view model from a copy.
        /// </summary>
        public void CopyFrom(ComposePhotoViewModel source)
        {
            this.Name = source.Name;
            this.PhotoDuration = source.PhotoDuration;
            this.TransitionDuration = source.TransitionDuration;
            if (source.Transition != null)
            {
                this.Transition = source.Transition.Clone();
            }
            this.MediaStream = source.MediaStream;
        }

        /// <summary>
        /// Converts a model class to a view model class.
        /// </summary>
        public static ComposePhotoViewModel CreateFromModel(Photo model)
        {
            ComposePhotoViewModel viewModel = new ComposePhotoViewModel()
            {
                Name = model.Name,
                MediaStream = model.ThumbnailStream,
                PhotoDuration = (int)(model.PhotoDuration.TotalSeconds)                    
            };
            if (model.Transition != null)
            {
                viewModel.Transition = model.Transition;
                viewModel.TransitionDuration = (int)(model.Transition.TransitionDuration.TotalSeconds);
            }
            return viewModel;
        }

        /// <summary>
        /// Update the model corresponding to this view model.
        /// </summary>
        public void UpdateModel()
        {
            Photo photoToModify = App.MediaCollection.Where(p => p.Name == this.Name).FirstOrDefault();
            if (photoToModify != null && this.Transition != null)
            {
                photoToModify.Transition = this.Transition;
                photoToModify.Transition.TransitionDuration = TimeSpan.FromSeconds(this.TransitionDuration);
                photoToModify.PhotoDuration = TimeSpan.FromSeconds(this.PhotoDuration);
            }
        }

        /// <summary>
        ///  If the view model is removed, we need to remove the corresponding model as well.
        /// </summary>
        public void RemoveModel()
        {
            Photo model = App.MediaCollection.Where(p => p.Name == this.Name).FirstOrDefault();
            if (model != null)
            {
                model.ThumbnailStream.Close();
                App.MediaCollection.Remove(model);
            }
        }
    }
}
