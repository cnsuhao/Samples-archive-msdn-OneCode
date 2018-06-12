/****************************** Module Header ******************************\
* Module Name:  JsCallWCFInWord2013.js
* Project:      JsCallWCFInWord2013
* Copyright(c)  Microsoft Corporation.
* 
* The Script is used to Call WCF Service from Task Pane App
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
        $('#getSumBtn').click(function () { callServer(); });

        // If setSelectedDataAsync method is supported by the host application
        // setDatabtn is hooked up to call the method else setDatabtn is removed
        if (Office.context.document.setSelectedDataAsync) {
            $('#setDataBtn').click(function () { setData('#resultTxt'); });
        }
        else {
            $('#setDataBtn').remove();
        }
    });
};

// Use $.ajax function to call WCF Service
function callServer() {
    var $left = $("#leftTxt").val();
    var $right = $("#rightTxt").val()
    if ($.trim($("#rightTxt").val()) == "" || $.trim($("#leftTxt").val()) == "") {
        writeError("Error: left number or right number can not be null");
        return;
    }
    var left = Number($.trim($left));
    var right = Number($.trim($right));
    if (isNaN(left) || isNaN(right)) {
        $("#leftTxt").val("");
        $("#rightTxt").val("");
        writeError("Error: please input number");
        return;
    }
    else {
        writeError("");
    }
    $.ajax({
        type: 'post',
        url: '/WCFService.svc/Add',
        contentType: 'text/json',
        data: '{"left":' + left + ',"right":' + right+'}', // post data 
        success: function (result) {
            GetResult(String(result.d));

            // set "Set Data" button enable
            $("#setDataBtn").removeAttr("disabled");
        }
    });
}

// Get return data from WCF method and displays it in a textbox 
function GetResult(text) {
    $("#resultTxt").val(text);
}

// Print error message
function writeError(text)
{
    $("#error")[0].innerText = text;
    $("#error").css("color", "red");
}

// Writes data from textbox to the current selection in the document
function setData(elementId) {
    Office.context.document.setSelectedDataAsync($(elementId).val());
}