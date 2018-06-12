/****************************** Module Header ******************************\
 * Module Name:  default.js
 * Project:      JSWindowsStoreAppProgressRingOverIframe
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to display ProgressRing over Iframe.
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
              
                // Retrieve button
                var loadBtn = document.getElementById("loadbtn");
                var urlTextbox = document.getElementById("urltxb");
                var iframe = document.getElementById("webView");

                // Register Click Event of load button
                loadbtn.addEventListener("click", loadButtonClick, false);
                urlTextbox.attachEvent("onpropertychange", urlTextChanged, false);
                iframe.addEventListener("load", iframeLoadCompleted, false);
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
    
    var urlTxb;
    var loadButton;
    var progressRing;

    // Url change event
    function urlTextChanged()
    {
        urlTxb = document.getElementById("urltxb");
        loadButton = document.getElementById("loadbtn");
        if (urlTxb.value.length != 0) {
            loadButton.removeAttribute("disabled");
        }
        else {
            loadButton.setAttribute("disabled", "disabled");
        }
    }

    // Validate the url 
    function validateUrl(urlstring) {
        var client = null;
        try {
            client = new XMLHttpRequest();
            if (client) {
                client.open("GET", urlstring, false);
                client.send();
                if (client.readyState === 4) {
                    if (client.status !== 200) {
                        return false
                    } else {
                        return true;
                    }
                }
            }
        }
        catch (e) {
            document.getElementById("urlerror").style.visibility = "visible";
        }
    }

    // Load Button Click event handler
    function loadButtonClick()
    {
        // Retrieve the DOM element 
        loadButton = document.getElementById("loadbtn");
        urlTxb = document.getElementById("urltxb");
        progressRing = document.getElementById("progressRingContainer");
       
        if (validateUrl(urlTxb.value)) {
            document.getElementById("urlerror").style.visibility = "collapse";
            progressRing.style.visibility = "visible";
            document.getElementById("webView").src = urlTxb.value;
        }
        else {
            document.getElementById("urlerror").style.visibility = "visible";
        }

    }


    // iframe Load complete
    function iframeLoadCompleted() {
        progressRing = document.getElementById("progressRingContainer");
        progressRing.style.visibility = "collapse";
        document.getElementById("webView").style.visibility = "visible";
    }

    app.start();
})();
