/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETClientTemplateJQueryJSON
* Copyright (c) Microsoft Corporation
*
* This project illustrates how to display a tabular data to users based on 
* some inputs in ASP.NET application. We will see how this can be addressed
* with JQuery and JSON to build a tabular data display in web page. Here we
* use JQuery plug-in JTemplate to make it easy.
* 
* Default page shows the List of Person class and displays it in JTemplate 
* HTML table.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;

namespace CSASPNETClientTemplateJQueryJSON
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
    }
}