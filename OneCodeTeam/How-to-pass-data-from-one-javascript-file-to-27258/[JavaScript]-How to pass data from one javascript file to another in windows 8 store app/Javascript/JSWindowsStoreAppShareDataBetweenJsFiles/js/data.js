/****************************** Module Header ******************************\
 * Module Name:  data.js
 * Project:      JSWindowsStoreAppShareDataBetweenJsFiles
 * Copyright (c) Microsoft Corporation.
 * 
 * This file provides sample data and exposes WinJS.BindingList to public.
 *  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

(function () {
    "use steict"

    // Define array variable
    var sampledataarray = [
         { name: "Tommy", age: "24", sex: "male" },
         { name: "Lily", age: "22", sex: "female" },
         { name: "Jone", age: "29", sex: "male" },
         { name: "Jack", age: "32", sex: "male" },
         { name: "Allen", age: "25", sex: "male" },
         { name: "Lisa", age: "21", sex: "female" },
         { name: "Jones", age: "22", sex: "female" },
         { name: "Carter", age: "26", sex: "male" }
    ];
    var datalist = new WinJS.Binding.List(sampledataarray);

    var publicMembers =
        {
            itemList: datalist
        };
    WinJS.Namespace.define("JSWindowsStoreAppShareDataBetweenJsFiles", publicMembers);
})();