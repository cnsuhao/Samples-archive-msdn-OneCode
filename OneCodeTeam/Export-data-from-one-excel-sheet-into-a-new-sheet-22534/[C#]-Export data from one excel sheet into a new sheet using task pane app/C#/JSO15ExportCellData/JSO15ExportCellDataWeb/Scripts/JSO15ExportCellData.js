/****************************** Module Header ******************************\
* Module Name:  JSO15ExportCellData.js
* Project:      JSO15ExportCellDataWeb
* Copyright(c)  Microsoft Corporation.
* 
* The Script is used to Export data from one excel sheet to a new sheet
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
        $('#btnExport').click(function () {
            // Start to export
            exportNewSheet("#sourceRange", "#exportedRange");
        });
    });
};

// Export data from one excel sheet to a new sheet 
function exportNewSheet(sourceRange,exportedRange) 
{
    var sourceData;

    // Clear Message, then Validate
    writeMessage("");

    // Validate the input 
    var $sourcerange = $(sourceRange).val();
    var $exportedrange = $(sourceRange).val();
    if ($.trim($sourcerange) == "" || $.trim($exportedrange) == "") {
        writeMessage("Error : Source Range and Exported Range can not be empty!");
        return;
    }
 
    // Add a Binding in one excel sheet
    Office.context.document.bindings.addFromNamedItemAsync($(sourceRange).val(), Office.BindingType.Matrix, { id: "sourceBinding" }, function (asyncResult) {
        if (asyncResult.status == Office.AsyncResultStatus.Failed) {
            writeMessage("Error: " + asyncResult.error.message);
        }
        else {
            // Read data from source binding
            Office.select("bindings#sourceBinding").getDataAsync({ coercionType: Office.CoercionType.Matrix }, function (asyncResult) {
                if (asyncResult.status == Office.AsyncResultStatus.Failed) {
                    writeMessage("Error: " + asyncResult.error.message);
                }
                else {
                    sourceData = asyncResult.value;

                    // Write data into a new sheet
                    writeBoundData(exportedRange, sourceData);
                }
            });
        }
    });  
}

// Write Data from one sheet into a new sheet
function writeBoundData(exportedRange, sourceData)
{
    // Add a Binding in a new sheet
    Office.context.document.bindings.addFromNamedItemAsync($(exportedRange).val(), Office.BindingType.Matrix, { id: "exportedBinding" }, function (asyncResult) {
        if (asyncResult.status == Office.AsyncResultStatus.Failed) {
            writeMessage("Error: " + asyncResult.error.message);
        }
        else {
            // Write data in one excel to the binding in the new sheet
            Office.select("bindings#exportedBinding").setDataAsync(sourceData, { coercionType: "matrix" }, function (asyncResult) {
                if (asyncResult.status == Office.AsyncResultStatus.Failed) {
                    writeMessage("Error: " + asyncResult.error.message);
                }
                else {
                    writeMessage("Export data from one sheet to a new sheet successfully!");
                }
            });
        }
    });
}

// Print Message 
function writeMessage(message)
{
    $("#message")[0].innerText = message;
    $("#message").css("color","red");
}