<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <script src="~/Scripts/jquery-2.0.3.min.js"></script>
</head>
<body>
    <div>
        <table id="grid">
            <thead>
                <tr>
                    <td>Name</td>
                    <td>Email</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Jim</td>
                    <td>Jim@Onecode.com</td>
                </tr>
                <tr>
                    <td>Sam</td>
                    <td>Sam@Onecode.com</td>
                </tr>
            </tbody>
        </table>
    </div>
    <button id="btnSubmit" onclick="saveEntities();">Submit</button>
    <script type="text/javascript">
        var userInfos = [];
        function saveEntities() {
            var trs = $("#grid tbody tr");
            $(trs).each(function () {
                var userInfo = {
                    Name: $(this).children().first().text(),
                    Email: $(this).children().last().text()
                }
                userInfos.push(userInfo);
            });
            var json = JSON.stringify(userInfos);
            alert('Start to transfer data:' + json);
            $.ajax({
                type: "POST",
                contentType: "application/json",
                data: "{'data':'" + json + "'}",
                url: "Home/saveUserInfos",
                dataType: "json",
                success: function (xhr) { alert(xhr); },
                error: function (xhr) { alert(xhr); }
            });
        }
    </script>
</body>
</html>
