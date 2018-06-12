<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETGetDesiredResultByAJAXCalls._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript"> 
　　        var xmlHttp;
        function createXMLHttpRequest() {
            if (window.ActiveXObject) {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            else if (window.XMLHttpRequest) {
                xmlHttp = new XMLHttpRequest();
            }
        }
        //Deal method 
        function AjaxRequest() {
            createXMLHttpRequest();
            var url = "example.aspx?str=" + document.getElementById("txt").value + "&type=" + document.getElementById("drpType").value;
            xmlHttp.open("GET", url, false);
            xmlHttp.onreadystatechange = onSuccessCallBack;
            xmlHttp.send(null);
        }
        //Callback method 
        function onSuccessCallBack() {
            if (xmlHttp.readyState == 4) //4 represent Complete 
            {
                if (xmlHttp.status == 200) {
                    switch (document.getElementById("drpType").value) {
                        case "1": //For plain text
                            document.getElementById("result").innerHTML = xmlHttp.responseText;
                            break;
                        case "2": //For JSON
                            var result = xmlHttp.responseText;
                            var json = eval("(" + result + ")");
                            alert(json.hello);
                            alert(json.face);
                            break;
                        case "3": //For XML                             
                            // Get XML DOM object
                            var xmlDOM = xmlHttp.responseXML;
                            // Obtain the root of the XML document
                            var xmlRoot = xmlDOM.documentElement;
                            try {
                                var xmlItem = xmlRoot.getElementsByTagName("hello");
                                alert("responseXML's value: " + xmlItem[0].firstChild.data);
                                var xmlItem = xmlRoot.getElementsByTagName("world");
                                alert("responseXML's value: " + xmlItem[0].firstChild.data);
                            }
                            catch (e) {
                                alert(e.message);
                            }
                            break;
                        default:
                    }
                }
            }
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    You can enter some information:<input type="text" id="txt" /><br />
    The type of data you need to return<select id="drpType">
        <option value="1">plain text</option>
        <option value="2">JSON</option>
        <option value="3">XML</option>
    </select>
    <br />
    <input type="button" value="Ajax Request" onclick="AjaxRequest();" />
    <hr />
    <div id="result">
    </div>
    </form>
</body>
</html>
