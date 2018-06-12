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
                // retrieve button element
                var addButton = document.getElementById('gobtn');

                // Register Click event
                addButton.addEventListener("click", goButtonClick, false);
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

    // Go button click event handler
    function goButtonClick() {     
        // retrieve element
        var zipCode =document.getElementById('txbinputZipCode').value.trim();
        var resultSpan = document.getElementById('SpanResult');

        // Clear Result message
        resultSpan.innerHTML = "";

        // Validate input number
        if (zipCode == "") {
            writeError("Error: please input ZIP Code first.");
            return;
        }
        else if (isNaN(zipCode)) {
            writeError("Error: Zip Code must be numer");
            document.getElementById('txbinputZipCode').value = "";
            return;
        }

        // Clear error message
        document.getElementById("error").innerText = "";

        WinJS.xhr({
            type: "post",
            url: "http://wsf.cdyne.com/WeatherWS/Weather.asmx/GetCityWeatherByZIP",
            data: 'ZIP=' + zipCode,
            headers: { "Content-type": "application/x-www-form-urlencoded" },
        }).then(function (r) {
           
            var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDoc.loadXml(r.responseText);
          
            for (var i = 0; i < xmlDoc.documentElement.childNodes.length; i++)
            {
                var statenode;
                var node =xmlDoc.documentElement.childNodes[i];
                switch (xmlDoc.documentElement.childNodes[i].nodeName) {
                    case "Success":
                        if (node.innerText == "false") {
                            resultSpan.innerHTML += "<div style='font-size:28px'>Please input valid ZIP Code in U.S</div>"
                            return;
                        }
                    case "State":
                        statenode = xmlDoc.documentElement.childNodes[i];
                        break;
                    case "City":
                        resultSpan.innerHTML += "<div style='font-size:36px'>" + node.innerText + "," + statenode.innerText + "</div>";
                        break;                
                    case "Description":
                        resultSpan.innerHTML += "<div>Conditions - " + node.innerText + "</div>";
                        break;
                    case "Temperature":
                        resultSpan.innerHTML += "<div>Temperature - " + node.innerText + "F</div>";
                        break;
                    case "RelativeHumidity":
                        resultSpan.innerHTML += "<div>Relative Humidity - " + node.innerText + "</div>";
                        break;
                    case "Wind":
                        resultSpan.innerHTML += "<div>Wind - " + node.innerText + "</div>";
                        break;
                    case "Pressure":
                        resultSpan.innerHTML += "<div>Pressure - " + node.innerText + "</div>";
                        break;
                }
            }
        });
    }

    // Print error message
    function writeError(text) {
        document.getElementById("error").innerText = text;
    }
    app.start();
})();
