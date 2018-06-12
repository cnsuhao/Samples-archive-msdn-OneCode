/****************************** Module Header ******************************\
* Module Name:  JSO15SaveWordDocument.js
* Project:      JSO15SaveWordDocumentWeb
* Copyright(c)  Microsoft Corporation.
* 
* The Script is used to save all content as word document on client machine.
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
Office.initialize = function (reason) {
    $(document).ready(function () {
        // Save All Word document on client by using JS
        $('#saveAllBtn').click(function () {
            // Clear message
            writeToPage("");
            saveAllDocument();
        });
    });
};

// Get All content in word document and save as word document
function saveAllDocument() {
    var i = 0;
    var slices = 0;
    var myFile;

    // Office.FileType.Compressed returns the entire document as a byte array(word or powerpoint)
    Office.context.document.getFileAsync(Office.FileType.Compressed, function (result) {
        if (result.status == "succeeded") {
            // If the getFileAsync call succeeded, then
            // result.value will return a valid File Object.
            myFile = result.value;
            slices = myFile.sliceCount;

            // Iterate over the file slices.
            for (i = 0; i < slices; i++) {
                var slice = myFile.getSliceAsync(i, function (result) {
                    if (result.status == "succeeded") {
                        saveAllContent(result.value.data.toString());
                    }
                    else {
                        writeToPage("Error: " + result.error.message);
                    }
                });
            }
            myFile.closeAsync();
        }
        else {
            writeToPage("Error: " + result.error.message);
        }
    });
}

// Call WCF Service to save All Content of Word document
function saveAllContent(content) {
    $.ajax({
        type: 'post',
        url: '/SaveWordService.svc/SaveAllContent',
        contentType: 'text/json',
        data: '{"bytestring":"' + content + '"}',
        success: function (result) {
            if (result.d.toString() == "0") {
                writeToPage("Failed to save word document because the file is in used.\nPlease close the file and try again.");
            }
            else {
                writeToPage("Save All content of Word document successfully!The Save Path is: " + String(result.d));
            }
        },
        error: function (XMLHttpRequest, textStatus) {
            writeToPage("Error: " + XMLHttpRequest.statusText);
        }
    });
}

// Write Message
function writeToPage(text) {
    $('#results')[0].innerText = text;
    $('#results').css("color", "red");
}