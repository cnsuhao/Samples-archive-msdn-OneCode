@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ShowDetails</title>
</head>
<body>
    <div>
         <p>
                     Site Name:@ViewBag.ServerName<br/>
                     Current site PipeLineMode:@ViewBag.CurrentServerPipelineMode<br />            
                </p>       
    </div>
</body>
</html>
