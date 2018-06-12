/****************************** Module Header ******************************\
* Module Name:    MySong.cs
* Project:        CSWP8MedialibrarySong
* Copyright (c) Microsoft Corporation
*
* This class is used to store the Song and its Uri.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWP8MedialibrarySong
{
   public class MySong
    {
        /// <summary>
        /// The song which is added by custom app.
        /// </summary>
        private Song _song;
        public Song song
        {
            get
            {
                return _song;
            }
            set
            {
                _song = value;
            }
        }

        /// <summary>
        /// The path of the song.
        /// </summary>
        private Uri filePath;
        public Uri FilePath
        {
            get
            {          
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }

        /// <summary>
        /// The original Song name.
        /// </summary>
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public MySong(Song song, string filename, Uri fileUri)
        {
            this._song = song;
            this.FileName = filename;
            this.FilePath = fileUri;
        }
    }
}
