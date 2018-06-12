/****************************** Module Header ******************************\
* Module Name:  JSInsertOnlineImageToWord.js
* Project:      JSInsertOnlineImageToWord
* Copyright(c)  Microsoft Corporation.
* 
* The Script is used to insert image into word using JavaScript API for Office
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



// This function is run when the app is ready to start interacting with the host application
// It ensures the DOM is ready before adding click handlers to buttons
Office.initialize = function (reason)
{
    $(document).ready(function () {
        // hide insert Image button
        $('#insertImageBtn').hide();

        var picUrl = $('#imgTxt');
        // click event fire when users click "Preview Picture" button
        $('#preViewBtn').click(function () {
            // show "insert image" button if the picture Url is correct.
            if (validatePic(picUrl)) {      
                // show the insert image button
                $('#insertImageBtn').show();
            }
            else {
                // hide the insert image if the picture Url is incorrect
                $('#insertImageBtn').hide();
            }
        });

        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#insertImageBtn').click(function () {

                var imgOOXML;
                // Get a string of ooxml that represents an image
                $.ajax({
                    type: "Get",
                    url: "../Image.xml",
                    dataType: "text",
                    async: false,
                    success: function (text) {
                        var sourcetext = "http://i.msdn.microsoft.com/fp123580.AppHome2(en-us,MSDN.10).png";
                        var imgUrl = $('#imgTxt').val();
                        imgOOXML = text.replace(sourcetext, imgUrl);
                    }
                });

                setOOXMLImage(imgOOXML);
            });
        }
    });
};

// Validate Picture Url
function validatePic(picUrl) {
    if (picUrl.val().length == 0) {

        // Clear text and pircture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());

        writeError("Please input online picture URL");
        return false;
    }

    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf("."), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != ".jpg") && (picextension != ".gif") && (picextension != ".jpeg") && (picextension != ".png") && (picextension != ".bmp")) {
        writeError("Image type must be one of gif,jpeg,jpg,png");
        picUrl.focus();

        // Clear text and Picture Url
        picUrl.select();
        document.selection.clear();
        loadImageFile(picUrl.val());
        return false;
    }

    $('#results')[0].innerText = "";
    loadImageFile(picUrl.val());
    return true;
}

// Load imge to make sure the URL is valid
function loadImageFile(text)
{
    $('#prePic').prop("src", text);
}

// Insert Image by using OOXML way
function setOOXMLImage(imgOOXML) {
    if (Office.CoercionType.Ooxml) {
        Office.context.document.setSelectedDataAsync(
            imgOOXML,
            { coercionType: "ooxml" },
            function (asyncResult) {
                if (asyncResult.status == "failed") {
                    writeError('Error: ' + asyncResult.error.message);
                }
            });
    }
    else {
        writeError("Setting data as Open XML is not supported ");
    }
}

// Print Error Message
function writeError(text) {
    $('#results')[0].innerText = text;
    $('#results').css("color", "red");
}