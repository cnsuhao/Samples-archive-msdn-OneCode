/**************************** Module Header ********************************\
* Module Name:    Picture.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* Picture Class.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using Newtonsoft.Json;


namespace CSAzureWPImageUpload.Models
{
    public class Picture
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }
    }
}
