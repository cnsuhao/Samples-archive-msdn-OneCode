/****************************** Module Header ******************************\
* Module Name:  JSWordInsertImage.js
* Project:      JSWordInsertImage
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
    $(document).ready(function ()
    {
        var picUrl = $('#Text1');
        $('#preViewBtn').click(function ()
        {     
            if (validatePic(picUrl))
            {
                preViewPic();
                $('#insertImageBtn').removeAttr("disabled");
            }
        });
       
        $('#Text1').change(function () {
            $('#insertImageBtn').attr("disabled", "disabled");
        });

        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync)
        {       
            $('#insertImageBtn').click(function () {
                var imgHtml = "<img " + "src='" + picUrl.val() + "' img/>";
                setHTMLImage(imgHtml);
            });
        }   
    });
};

// Validate Picture Url
function validatePic(picUrl)
{
    if (picUrl.val().length == 0)
    {
        writeError("Please input online picture URL");
        return false;
    }

    var picextension = picUrl.val().substring(picUrl.val().lastIndexOf("."), picUrl.val().length);
    picextension = picextension.toLowerCase();
    if ((picextension != ".jpg") && (picextension != ".gif") && (picextension != ".jpeg") && (picextension != ".png") && (picextension != ".bmp"))
    {
        writeError("Image type must be one of gif,jpeg,jpg,png");
        picUrl.focus();

        // Clear Picture Url
        picUrl.select();
        document.selection.clear();
        return false;
    }

    $('#results')[0].innerText = "";
    return true;
}

// Preview Picture to make sure that url is valid
function preViewPic()
{
    var picaddress = $('#Text1').val();
    $('#prePic').prop("src", picaddress);
}

// Insert image 
function setHTMLImage(imgHTML)
{
    Office.context.document.setSelectedDataAsync(
        imgHTML,
        { coercionType: "html" },
        function (asyncResult) {
            if (asyncResult.status == "failed") {
                writeError('Error: ' + asyncResult.error.message);
            }
        });
}

// Print Error Message
function writeError(text)
{
    $('#results')[0].innerText = text;
    $('#results').css("color", "red");
}