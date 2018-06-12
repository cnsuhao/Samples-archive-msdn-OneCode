/****************************** Module Header ******************************\
* Module Name:	PersistenceHelper.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A helper class that serializes/deserializes the story to/from xml.
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
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Media;
using VideoStoryCreator.Models;
using VideoStoryCreator.Transitions;

namespace VideoStoryCreator
{
    public static class PersistenceHelper
    {
        /// <summary>
        /// Serialize the story to xml, and store it in isolated storage.
        /// </summary>
        internal static void StoreData()
        {
            if (!string.IsNullOrEmpty(App.CurrentStoryName))
            {
                IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();
                using (IsolatedStorageFileStream fileStream = userStore.CreateFile(App.CurrentStoryName + ".xml"))
                {
                    // Serialize the story, and save it.
                    SerializeStory().Save(fileStream);
                }

                // Save the current story name.
                using (IsolatedStorageFileStream fileStream = 
                    userStore.OpenFile("CurrentStory.txt", System.IO.FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(App.CurrentStoryName);
                    }
                }
            }
        }

        /// <summary>
        /// Read the xml file from isolated storage, and deserialize it to a story.
        /// </summary>
        internal static void RestoreData()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();

            // Read the current story name.
            if (userStore.FileExists("CurrentStory.txt"))
            {
                using (IsolatedStorageFileStream fileStream = userStore.OpenFile("CurrentStory.txt", System.IO.FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        App.CurrentStoryName = reader.ReadToEnd();
                    }
                }
            }

            // If the current story is found, load it.
            if (!string.IsNullOrEmpty(App.CurrentStoryName) && userStore.FileExists(App.CurrentStoryName + ".xml"))
            {
                ReadStoryFile(App.CurrentStoryName, userStore);
            }
        }

        /// <summary>
        /// Read the specified story file.
        /// </summary>
        /// <param name="storyName">The story name.</param>
        /// <param name="userStore">If this parameter is null, we will create one.</param>
        internal static void ReadStoryFile(string storyName, IsolatedStorageFile userStore = null)
        {
            if (userStore == null)
            {
                userStore = IsolatedStorageFile.GetUserStoreForApplication();
            }
            using (IsolatedStorageFileStream fileStream = userStore.OpenFile(storyName + ".xml", System.IO.FileMode.Open))
            {
                XDocument xdoc = XDocument.Load(fileStream);
                MediaLibrary mediaLibrary = new MediaLibrary();
                var picturesLibrary = mediaLibrary.Pictures;

                // Load all photos.
                foreach (XElement photoElement in xdoc.Root.Elements())
                {
                    try
                    {
                        Photo photo = new Photo()
                        {
                            Name = photoElement.Attribute("Name").Value,
                        };
                        string photoDurationString = photoElement.Attribute("PhotoDuration").Value;
                        int photoDuration = int.Parse(photoDurationString);
                        photo.PhotoDuration = TimeSpan.FromSeconds(photoDuration);
                        XElement transitionElement = photoElement.Element("Transition");
                        if (transitionElement != null)
                        {
                            photo.Transition = TransitionBase.Load(photoElement.Element("Transition"));
                        }
                        Picture picture = picturesLibrary.Where(p => p.Name == photo.Name).FirstOrDefault();
                        if (picture == null)
                        {
                            // Cannot find the original photo file. Possibly it has been deleted.
                            // TODO: Should we log the error? Should we continue with the next photo or throw an excpetion?
                            continue;
                        }
                        photo.ThumbnailStream = picture.GetThumbnail();
                        App.MediaCollection.Add(photo);
                    }
                    catch
                    {
                        // TODO: Should we log the error? Should we continue with the next photo or throw an excpetion?
                        continue;
                    }
                }
                mediaLibrary.Dispose();
            }
        }

        /// <summary>
        ///  Serializes the current story.
        ///  We only serialize story data, such as each photo's duration.
        ///  We don't serialize the underlying bitmap.
        /// </summary>
        /// <returns>An XDocument that describes the current story</returns>
        internal static XDocument SerializeStory()
        {
            XDocument xdoc = new XDocument(new XElement("Story",
                new XAttribute("Name", App.CurrentStoryName),
                new XAttribute("PhotoCount", App.MediaCollection.Count)
                ));

            // Save each photo as an xml element.
            foreach (Photo photo in App.MediaCollection)
            {
                XElement photoElement = new XElement("Photo");
                photoElement.Add(new XAttribute("Name", photo.Name));
                photoElement.Add(new XAttribute("PhotoDuration", photo.PhotoDuration.TotalSeconds));
                if (photo.Transition != null)
                {
                    XElement transitionElement = new XElement("Transition");
                    photo.Transition.Save(transitionElement);
                    photoElement.Add(transitionElement);
                }
                xdoc.Root.Add(photoElement);
            }
            return xdoc;
        }

        /// <summary>
        /// Enumerate all saved stories, and returns the story names.
        /// </summary>
        /// <returns>A list contains the name of each story, without the .xml extension.</returns>
        internal static List<string> EnumerateStories()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();
            return (from f in userStore.GetFileNames()
                    where f.EndsWith(".xml")
                    select f.Substring(0, f.Length - 4)).ToList();
        }
    }
}
