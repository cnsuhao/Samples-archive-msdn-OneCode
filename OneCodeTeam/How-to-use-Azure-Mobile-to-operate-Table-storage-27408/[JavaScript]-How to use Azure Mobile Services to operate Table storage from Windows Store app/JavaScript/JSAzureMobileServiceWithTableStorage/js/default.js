/***************************** Module Header ******************************\
* Module Name:	default.cs
* Project:		JSAzureMobileServiceWithTableStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use table storage with windows Azure mobile service.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

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
            } else {           
            }
            args.setPromise(WinJS.UI.processAll());

            var client = new WindowsAzure.MobileServiceClient(
                "https://[Your Azure mobile service name].azure-mobile.net/",
                 "[You Azure mobile service application key]"

            );

            // Get reference to your Azure mobile service table.
            var shortMessageTable = client.getTable('ShortMessages');
            var shortMessageList = new WinJS.Binding.List();

            // Insert short message to Azure storage function.
            var insertShortMessage = function (shortmessage) {
                shortMessageTable.insert(shortmessage).done(function (shortmessage) {
                    shortMessageList.push(shortmessage);
                    lbstate.innerHTML = 'New short message has been left';
                    txtName.innerHTML = '';
                    txtMessage.innerHTML = '';
                });
            }

            // Refresh the list view.
            var refresh = function () {
                // This code refreshes the entries in the list view be querying the shortmessage table.                
                shortMessageTable
                    // We do the query in the server side, so here we ignore 
                    //.where({isRead:true})
                    .read().done(function (results) {
                    shortMessageList = new WinJS.Binding.List(results);
                    listItems.winControl.itemDataSource = shortMessageList.dataSource;
                    });
            };

            // Delete selected item
            var deleteShortMessage = function () {
                var listview = document.getElementById("listItems").winControl;
                if (listview.selection.count() > 0) {
                    listview.selection.getItems().done(function (items) {
                        var message = {
                            //In mobile service, delete method only need to send the 'id' to 
                            //server side, so when set the id value to RowKey, and use it's value
                            //in our service bus method.
                            id: items[0].data.RowKey
                        };
                        shortMessageTable.del(message).done(function (m) {
                            shortMessageList.splice(items[0].index, 1);
                            lbstate.innerHTML = 'selected item has been deleted';
                        });
                    });                  
                }      
            }

            // update the table storage, change the IsRead property to true.
            var updateCheckedShortMessage = function (shortmessage) {
                var message = {                    
                    id: shortmessage.RowKey.toString(),
                    PartitionKey: shortmessage.PartitionKey,
                    RowKey: shortmessage.RowKey,
                    Name: shortmessage.Name,
                    Message: shortmessage.Message,
                    IsRead: shortmessage.IsRead
                };
                shortMessageTable.update(message).done(function () {
                    shortMessageList.splice(shortMessageList.indexOf(shortmessage), 1);
                    lbstate.innerHTML = 'This item has been marked as read';
                });
            };

            //Add
            btnsave.addEventListener("click", function () {
                insertShortMessage({
                    Name: txtName.value,
                    Message: txtMessage.value,
                });
            });
           
            listItems.addEventListener("change", function (eventArgs) {
                var shortMessage = eventArgs.target.dataContext.backingData;
                shortMessage.IsRead = eventArgs.target.checked;
                updateCheckedShortMessage(shortMessage);
            });
      
            document.getElementById('cmdDelete').addEventListener("click", deleteShortMessage, false);
            refresh();
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

    app.start();
})();
