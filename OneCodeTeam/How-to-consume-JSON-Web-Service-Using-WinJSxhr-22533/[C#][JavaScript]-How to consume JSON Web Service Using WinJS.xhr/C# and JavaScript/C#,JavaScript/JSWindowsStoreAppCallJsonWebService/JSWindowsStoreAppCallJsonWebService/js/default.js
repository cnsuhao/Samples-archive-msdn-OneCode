/****************************** Module Header ******************************\
 * Module Name:  default.js
 * Project:      JSWindowsStoreAppCallJsonWebService
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to consume JSON Web Service Using WinJS.xhr.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll().then(function completed() {
                // Retrieve button element
                var addButton = document.getElementById('addbtn');

                // Register Click event
                addButton.addEventListener("click", addButtonClick, false);
            }));
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };
  
     // Add button click event handler
    function addButtonClick()
    {
        // Retrieve element
        var leftnumber = document.getElementById('txbFirstNumber').value.trim();
        var rightnumber = document.getElementById('txbSecondNumber').value.trim();
        var resultSpan = document.getElementById('SpanResult');

        // Validate input number
        if (leftnumber == "" || rightnumber == "")
        {
            writeError("Error: left number or right number can not be null");
            return;
        }

        if (isNaN(leftnumber) || isNaN(rightnumber))
        {
            writeError("Error: please input number");

            // Clear error input
            document.getElementById('txbFirstNumber').value = "";
            document.getElementById('txbSecondNumber').value = "";
            return;
        }

        // Clear error message
        document.getElementById("error").innerText = "";
        var baseURI="http://localhost:45573/AddService.svc/Add";
        var leftnumber = document.getElementById('txbFirstNumber').value.trim();
        var rightnumber = document.getElementById('txbSecondNumber').value.trim();
        WinJS.xhr({
            type: "post",
            url: baseURI,
            headers: { "Content-type": "application/json" },
            data: '{"Number1":' + leftnumber + ',"Number2":' + rightnumber + '}'
        }).then(function (r) {
            if (eval('(' + r.responseText + ')').error != null) {
                var result = eval('(' + r.responseText + ')').error;
                resultSpan.style.color = "red";
                resultSpan.innerHTML = result;
            }
            else {
                var result = JSON.parse(eval('(' + r.responseText + ')').AddResult);
                resultSpan.style.removeAttribute("color");
                resultSpan.innerHTML = result;
            }
        });
    }

    // Print error message
    function writeError(text) {
        document.getElementById("error").innerText = text;
    }
    app.start();
})();
