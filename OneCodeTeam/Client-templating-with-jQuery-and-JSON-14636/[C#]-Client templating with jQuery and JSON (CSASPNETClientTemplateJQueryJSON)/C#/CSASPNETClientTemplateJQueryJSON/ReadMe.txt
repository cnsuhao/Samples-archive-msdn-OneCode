========================================================================
               CSASPNETClientTemplateJQueryJSON Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

This project illustrates how to display a tabular data to users based on 
some inputs in ASP.NET application. We will see how this can be addressed
with JQuery and JSON to build a tabular data display in web page. Here we
use JQuery plug-in JTemplate to make it easy.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETClientTemplateJQueryJSON.sln.

Step 2: Expand the CSASPNETClientTemplateJQueryJSON web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You can find an HTML table on the Default.aspx page, the tabular data
        display by JQuery plug-in JTemplate.

Step 4: Validation finished.

///////////////////// ////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETClientTemplateJQueryJSON".

Step 2. Add two JQuery library files in JS folder of the application, These JQuery
        library can help us create the JQuery function and JTemplate HTML table. 

Step 3. Create an ASP.NET folder named "App_Code", and add Person entity class in 
        it. The Person class is created as the data source of table.

Step 4. Add a web form and name it as "Default.aspx" in the root directory of 
        application. The HTML table host in default page with JQuery functions.
		
Step 5  The JQuery functions can receive the JSON string from code-behind file and
        constructing an HTML table using JQuery by plug-in JTemplate. The HTML code
		as shown below:
		[code]
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

	    [/code]

Step 6. The Person entity class file provide basic person properties, such as 
        Name, Age, Country, e-mail, Address, Telephone and comments. This class
		need be a serializable class.
		[code]
        private string name;
        private int age;
        private string country;
        private string address;
        private string mail;
        private string telephone;
        private string comment;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get 
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }

        public string Comment
        {
            get 
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }
		[/code]

Step 7. Create a PersonList method for returning a list of person entity instances
        as the JSON string that it will render on the default page.
		[code]
		/// <summary>
        /// This method is used to provide JSON string variable.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [WebMethod]
        public static List<Person> PersonList(int pageSize)
        {
            List<Person> personList = new List<Person>();
            Person person = new Person();
            person.Name = "Mike";
            person.Age = 20;
            person.Country = "United State";
            person.Address = "Mike's address";
            person.Mail = "mike@hotmail.com";
            person.Telephone = "13333333333";
            person.Comment = "None";
            personList.Add(person);
            Person personTwo = new Person();
            personTwo.Name = "James";
            personTwo.Age = 22;
            personTwo.Country = "United State";
            personTwo.Address = "James's address";
            personTwo.Mail = "james@hotmail.com";
            personTwo.Telephone = "13333333334";
            personTwo.Comment = "Jim's comment";
            personList.Add(personTwo);
            Person personThree = new Person();
            personThree.Name = "Nancy";
            personThree.Age = 21;
            personThree.Country = "China";
            personThree.Address = "Nancy's address";
            personThree.Mail = "nancy@hotmail.com";
            personThree.Telephone = "13333333335";
            personThree.Comment = "wang's comment";
            personList.Add(personThree);
            Person personFour = new Person();
            personFour.Name = "Lisa";
            personFour.Age = 28;
            personFour.Country = "United Kingdom";
            personFour.Address = "Lisa's address";
            personFour.Mail = "lisa@hotmail.com";
            personFour.Telephone = "13333333336";
            personFour.Comment = "li's comment";
            personList.Add(personFour);
            Person personFive = new Person();
            personFive.Name = "Sakura";
            personFive.Age = 24;
            personFive.Country = "Japan";
            personFive.Address = "Sakura's address";
            personFive.Mail = "sakura@hotmail.com";
            personFive.Telephone = "13333333337";
            personFive.Comment = "sa's comment";
            personList.Add(personFive);
            return personList;
        }
		[/code] 

Step 8. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: jQuery and Microsoft 
http://weblogs.asp.net/scottgu/archive/2008/09/28/jquery-and-microsoft.aspx

MSDN: JSON Object (Windows Scripting - JScript)
http://msdn.microsoft.com/en-us/library/cc836458(VS.85).aspx
/////////////////////////////////////////////////////////////////////////////