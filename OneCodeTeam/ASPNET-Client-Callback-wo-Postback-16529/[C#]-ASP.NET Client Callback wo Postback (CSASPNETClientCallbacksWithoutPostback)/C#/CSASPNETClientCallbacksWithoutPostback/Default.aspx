<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETClientCallbacksWithoutPostback.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function FilterSearchGrid() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            var inputarg = "Filter|" + firstName + "|" + lastName + "|" + age;
            FilterCallServerMethod(inputarg, '');
        }

        function AddNewName() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            if (firstName == "" || lastName == "" || age == "") {
                document.getElementById('message').innerHTML = "first name, last name, age can not be null";
                return;
            }
            if (!BaseNotInt(age)) {
                document.getElementById('message').innerHTML = "age must be an integer number";
                return;
            }
            if (age > 150 || age < 0) {
                document.getElementById('message').innerHTML = "age(1-150) is too small or too large";
                return;
            }
            var inputArg = "Insert|" + firstName + "|" + lastName + "|" + age;
            InsertCallServerMethod(inputArg, '');
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
            document.getElementById('hidID').value = "";
        }

        function UpdateName() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            var id = document.getElementById("hidID").value;
            if (firstName == "" || lastName == "" || age == "") {
                document.getElementById('message').innerHTML = "first name, last name, age can not be null";
                return;
            }
            if (id == "") {
                document.getElementById('message').innerHTML = "Please click Update button before commit them";
                return;
            }
            if (!BaseNotInt(age)) {
                document.getElementById('message').innerHTML = "age must be an integer number";
                return;
            }
            if (age > 150 || age < 0) {
                document.getElementById('message').innerHTML = "age(1-150) is too small or too large";
                return;
            }
            var inputArg = "Update|" + id + "|" + firstName + "|" + lastName + "|" + age;
            UpdateCallServerMethod(inputArg, '');
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
            document.getElementById('hidID').value = "";
        }

        function DeleteName(id) {
            var nameId = id;
            var inputarg = "Delete|" + nameId;
            DeleteCallServerMethod(inputarg, '');
        }

        function GiveValue(id, firstName, lastName, age) {
            var nameId = id;
            var firstName = firstName;
            var lastName = lastName;
            var age = age;
            document.getElementById("hidID").value = nameId;
            document.getElementById("tbFirstName").value = firstName;
            document.getElementById("tbLastName").value = lastName;
            document.getElementById("tbAge").value = age;
            document.getElementById('message').innerHTML = "You can modify the information from the TextBox controls and then click the Update button to commit them."
        }

        function FilterGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "filter the result from GridView control."
        }

        function DeleteGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Delete success."
        }

        function InsertGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Insert success."
        }

        function UpdateGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Update success."
        }

        function FilterShowAll() {
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
            FilterSearchGrid();
        }

        //Check value whether an integer function
        function BaseNotInt(character) {
            var characters = character;
            characters = Trim(characters);
            if (/^[-]?\d+$/.test(characters)) {
                return true;
            }
            return false;
        }

        //Remove the whitespace of a value function
        function Trim(s) {
            var reg = new RegExp("^[ \\t]*([^ \\t]+[.]*)?[ \\t]*$");
            var s1 = new String(s);
            reg.multiline = true;
            return s1.replace(reg, "$1");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        First Name:
    <input id="tbFirstName" type="text" /> 
        <br />
        Last Name: 
    <input id="tbLastName" type="text" /> 

        <br />
        Age: 
    <input id="tbAge" type="text" /><br />
    <input id="hidID" type="hidden" />
        <input id="btnAddName" type="button" value="Add New Person"  
            onclick="AddNewName()" /> <input id="btnUpdateName" type="button" value="Commit Update Information"  onclick="UpdateName()" /> <input id="btnFilter" type="button" value="Filter Result" onclick="FilterSearchGrid()"  /> <input id="btnShowAll" type="button" value="Show All" onclick="FilterShowAll()" /> 
        <div id="id1">
        
        <asp:GridView ID="GvwView" runat="server" onrowdatabound="GvwView_RowDataBound" 
                >
            <Columns>
                <asp:ButtonField HeaderText="Update" Text="Update" />
                <asp:ButtonField Text="Delete" HeaderText="Delete" />
            </Columns>
            <EmptyDataTemplate>
                Can not find result.
            </EmptyDataTemplate>
            </asp:GridView>
    </div>
    <div id="message" style="color:Red"> 
    </div>
    </div>
    </form>
</body>
</html>
