/****************************** Module Header ******************************\
 * Module Name:  default.js
 * Project:      JSWindowsStoreAppProgressOverListView
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to display ProgressRing over ListView when 
 * ListView is loading large data.
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
    var loadBtn;
    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll().then(function complete() {
                // retrieve button
                loadBtn = document.getElementById("loadButton");           

                // register Click Event for load button
                loadBtn.addEventListener("click", loadButtonClick, false);
            }));
        }
    };

    // load data into listview control
    function loadButtonClick() {   
        // clear the datasource
        document.getElementById("listView").winControl.itemDataSource = null;
        
        // set load button disabled 
        loadBtn.disabled = true;

        // set progress be visible
        document.getElementById("loadprogressring").style.visibility = "visible";
       
        // simulate listview to load large data. because the listview load data synchronously 
        setTimeout(loaddata, 2000);
    }

    function loaddata()
    {
        // get listview element
        var listviewElement = document.getElementById("listView");

        // get WinJS.UI.ListView control object
        var listViewControl = listviewElement.winControl;

        // binding data to ListView control
        listViewControl.itemDataSource = myData.dataSource;
        listViewControl.itemTemplate = document.getElementById("myItemTemplate");
        listViewControl.layout = new WinJS.UI.GridLayout();

        // force update the layout of listview control to display the binding data
        listViewControl.forceLayout();
        
        // set load button enable and set progress be invisible
        loadBtn.disabled = false;
        document.getElementById("loadprogressring").style.visibility = "collapse";
    }

    var myData = new WinJS.Binding.List([
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/60Banana.png" },
         { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/60Lemon.png" },
         { title: "Marvelous Mint", text: "Gelato", picture: "/images/60Mint.png" },
         { title: "Creamy Orange", text: "Sorbet", picture: "/images/60Orange.png" },
         { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/60Strawberry.png" },
         { title: "Very Vanilla", text: "Ice Cream", picture: "/images/60Vanilla.png" },
    ]);
    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
