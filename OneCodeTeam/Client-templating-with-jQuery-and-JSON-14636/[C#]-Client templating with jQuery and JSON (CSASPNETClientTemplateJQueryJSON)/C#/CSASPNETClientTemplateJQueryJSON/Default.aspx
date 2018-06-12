<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETClientTemplateJQueryJSON.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JS/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="JS/jquery-jtemplates.js" type="text/javascript"></script>
    <style type="text/css">
        .jTemplates { 
                        background: #FF00FF; 
                        border: 1px solid #000; 
                        margin: 2em; 
                        border-style:dashed;
       } 
    </style>
    <script type="text/javascript">
        function GetJSONString() {
            $.ajax({
                url: "Default.aspx/PersonList",
                type: "POST",
                data: "{pageSize:5}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success:
                function success(jsonString) {
                    $('#Zone').setTemplate($("#jTemplate").html());
                    $('#Zone').processTemplate(jsonString);
                },

                error:
                function (json, status, e) {
                    var err = JSON.parse(json.responseText);
                    $("Zone").html(err.Message);
                }
            });

        }
    </script> 

</head>
<body onload="return GetJSONString()">
    <form id="form1" runat="server">
    <b>build a tabular data display in web page.</b>
    <div>
    <script id="jTemplate" type="text/html">   
        <table class="jTemplates">   
               <colgroup width="100px"></colgroup>
               <colgroup width="100px"></colgroup>
               <colgroup width="125px"></colgroup>
               <colgroup width="150px"></colgroup>
               <colgroup width="150px"></colgroup>
               <colgroup width="125px"></colgroup>
               <colgroup width="*"></colgroup>
                <tr>   
                    <td style="border-style:dashed;;">Name</td>   
                    <td style="border-style:dashed;">Age</td>   
                    <td style="border-style:dashed;">Country</td>   
                    <td style="border-style:dashed;">Address</td>   
                    <td style="border-style:dashed;">Mail</td>   
                    <td style="border-style:dashed;">Telephone</td>  
                    <td style="border-style:dashed;">Comment</td> 
                </tr>    
            {#foreach $T.d as Person}   
                <tr>   
                    <td style="border-style:dashed;">{ $T.Person.Name }</td>   
                    <td style="border-style:dashed;">{ $T.Person.Age }</td>   
                    <td style="border-style:dashed;">{ $T.Person.Country }</td>   
                    <td style="border-style:dashed;">{ $T.Person.Address }</td>   
                    <td style="border-style:dashed;">{ $T.Person.Mail }</td>   
                    <td style="border-style:dashed;">{ $T.Person.Telephone }</td> 
                    <td style="border-style:dashed;">{ $T.Person.Comment }</td>
                </tr>   
            {#/for}    
        </table>   
    </script>
    <br /> 
    <div id="Zone"> 
    </div>
    </div>
    </form>
</body>
</html>
