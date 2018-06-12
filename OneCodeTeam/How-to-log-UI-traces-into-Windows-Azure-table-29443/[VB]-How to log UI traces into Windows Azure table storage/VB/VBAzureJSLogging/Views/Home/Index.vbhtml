
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">

    function addTableEntity(jsonString, tableSasUrl) {
        $.ajax({
            type: 'POST',
            datatype: "json",
            data: jsonString,
            url: tableSasUrl,
            beforeSend: setHeader,
            success: function (data, status, xhr) {
                alert("upload to Azure table storage success!");
            },
            error: function (data, status, xhr) {
                alert("upload to Azure table storage failed!");
            }
        });
    }

    function setHeader(xhr) {
        xhr.setRequestHeader('x-ms-version', '2013-08-15');
        xhr.setRequestHeader('MaxDataServiceVersion', '3.0');
        xhr.setRequestHeader('Accept', 'application/json;odata=nometadata');
        xhr.setRequestHeader('Content-Type', 'application/json;odata=nometadata');
    }
    function addLogtoTableStorage() {
        var tableSasApiUrl = '@Url.RouteUrl("DefaultApi", New With {.httproute = "", .controller = "tablesas"})';
        var entity = {
            PartitionKey: 'default',
            RowKey: (new Date()).getTime().toString(),
            log: $("#txtLogItem").val()
        };
        alert(tableSasApiUrl);
        $.ajax({
            type: 'GET',
            url: tableSasApiUrl,
            dataType:'json',
            success: function (data, states, xhr) {
                if (xhr.responseText != "") {
                    alert(data.SASTokenUrl)
                    addTableEntity(JSON.stringify(entity), data.SASTokenUrl);
                }
                return xhr.responseText;
            },
            error: function (data, status, xhr) {
                alert("can't get SAS for table");
            }
        })
    }
    </script>

</head>
<body>
    <div>
        <label>This button will send the log to Azure Table storage</label>
        <br />
        <input type="text" id="txtLogItem" />
        <button id="btnGet" onclick="addLogtoTableStorage()">send the log item</button>
    </div>
</body>
</html>