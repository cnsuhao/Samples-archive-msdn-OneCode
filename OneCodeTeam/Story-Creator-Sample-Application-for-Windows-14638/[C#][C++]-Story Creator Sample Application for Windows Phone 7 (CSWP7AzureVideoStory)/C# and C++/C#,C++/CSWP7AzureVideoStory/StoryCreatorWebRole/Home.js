/****************************** Module Header ******************************\
* Module Name:	Home.js
* Project: StoryCreatorWebRole
* Copyright (c) Microsoft Corporation.
* 
* The JavaScript file for the home page.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

var storyServiceUri = "stories";

$(document).ready(function () {
    $("#videoPlayer").hide(0);

    // Invoke the service to obtain a list of stories.
    $.ajax({
        type: "GET",
        url: storyServiceUri,
        success: function (data) {
            $("#videoTemplate").tmpl(data).appendTo("#videoList");
        }
    });
});

/// Play the selected video.
function playVideo(uri) {
    var player = $("#videoPlayer")[0];
    player.src = uri;
    player.play();
    $("#placeHolderDiv").hide(0);
    $("#videoPlayer").show(0);
}