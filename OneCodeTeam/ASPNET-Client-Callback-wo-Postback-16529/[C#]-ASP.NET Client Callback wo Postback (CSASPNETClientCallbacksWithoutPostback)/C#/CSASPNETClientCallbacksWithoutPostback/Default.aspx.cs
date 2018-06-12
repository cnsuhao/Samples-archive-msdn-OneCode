/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETClientCallbacksWithoutPostback
* Copyright (c) Microsoft Corporation
*
* The web application illustrates how to implement a client postback or partial
* postback to raise the server code or update some elements in HTML markup. Such 
* as TextBox, ListView, GridView. As we know that we can user ASP.NET AJAX control
* to call a Asynchronous request to server, but in this sample, we will implement
* ICallbackEventHandler interface for achieving this goal by this flexible and 
* lightweight method.
* 
* This page is use to display xml file and insert, update, delete record of GridView
* control without postbacks.
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
using System.Xml;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace CSASPNETClientCallbacksWithoutPostback
{
    public partial class Default : System.Web.UI.Page, ICallbackEventHandler
    {
        private string strOutput;
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "XmlFile/NameXml.xml";

        /// <summary>
        /// Page Load method.
        /// There we define ClientScriptManager class instances for register JavaScript functions.
        /// These JS functions are use to invoke RaiseCallbackEvent method, and return string variables 
        /// to client-side.
        /// we also need invoke GridViewBind method to display information of xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Filter call back event.
            // Create ClientManager instance of this page.
            ClientScriptManager clientManager = Page.ClientScript;

            // Create a JS function for invoke WebForm_DoCallback method.
            string callBackRef = clientManager.GetCallbackEventReference(this, "arg", "FilterGetOutputFromServer", String.Empty);
            string callBackScript = "function FilterCallServerMethod(arg, context) {" + callBackRef + "; }";

            // Register functions on page.
            clientManager.RegisterClientScriptBlock(this.GetType(), "FilterGetOutputFromServer", callBackScript, true);

            // Delete call back event.
            ClientScriptManager clientManagerDelete = Page.ClientScript;
            string deleteCallBackRef = clientManagerDelete.GetCallbackEventReference(this, "arg", "DeleteGetOutputFromServer", String.Empty);
            string deleteCallBackScript = "function DeleteCallServerMethod(arg, context){" + deleteCallBackRef + ";}";
            clientManagerDelete.RegisterClientScriptBlock(this.GetType(), "DeleteGetOutputFromServer", deleteCallBackScript, true);

            // Insert call back event.
            ClientScriptManager clientManagerInsert = Page.ClientScript;
            string insertCallBackRef = clientManagerInsert.GetCallbackEventReference(this, "arg", "InsertGetOutputFromServer", String.Empty);
            string insertCallBackScript = "function InsertCallServerMethod(arg, context){" + insertCallBackRef + ";}";
            clientManagerInsert.RegisterClientScriptBlock(this.GetType(), "InsertGetOutputFromServer", insertCallBackScript, true);

            // Update call back event.
            ClientScriptManager clientManagerUpdate = Page.ClientScript;
            string updateCallBackRef = clientManagerUpdate.GetCallbackEventReference(this, "arg", "UpdateGetOutputFromServer", String.Empty);
            string updateCallBackScript = "function UpdateCallServerMethod(arg, context){" + updateCallBackRef + ";}";
            clientManagerUpdate.RegisterClientScriptBlock(this.GetType(), "UpdateGetOutputFromServer", updateCallBackScript, true);

            // GridView bind event.
            this.GridViewBind();
        }

        /// <summary>
        /// This method is use to load XML file and convert it to a DataTable variable.
        /// Set this variable as GridView' data source.
        /// </summary>
        private void GridViewBind()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNodeList nodeList = xmlDocument.SelectNodes("Root/Person");
            DataTable tabNodes = new DataTable();
            tabNodes.Columns.Add("ID", Type.GetType("System.String"));
            tabNodes.Columns.Add("FirstName", Type.GetType("System.String"));
            tabNodes.Columns.Add("LastName", Type.GetType("System.String"));
            tabNodes.Columns.Add("Age", Type.GetType("System.String"));
            foreach (XmlNode node in nodeList)
            {
                DataRow drTab = tabNodes.NewRow();
                XmlElement elePerson = (XmlElement)node;
                drTab["ID"] = node.Attributes["id"].InnerText;
                drTab["FirstName"] = node["FirstName"].InnerText;
                drTab["LastName"] = node["LastName"].InnerText;
                drTab["Age"] = node["Age"].InnerText;
                tabNodes.Rows.Add(drTab);
            }
            this.ViewState["Table"] = tabNodes;
            GvwView.DataSource = null;
            GvwView.DataSource = tabNodes;
            GvwView.DataBind();
        }


        /// <summary>
        /// This method is use to render current HtmlTextWriter object.
        /// </summary>
        private void Flush()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter))
                {
                    GvwView.RenderControl(htmlWriter);
                    htmlWriter.Flush();
                    strOutput = strWriter.ToString();
                }
            }
        }

        /// <summary>
        /// This method is use to filter similar results of your input words.
        /// and re-bind them with GridView control.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void FilterGrid(string firstName, string lastName,string age)
        {
            DataTable tabName = (DataTable)this.ViewState["Table"];
            DataView tabView = tabName.DefaultView;
            tabView.RowFilter = String.Format("FirstName Like '%{0}%' And LastName Like '%{1}%' And Age Like '%{2}%'", firstName, lastName, age);
            GvwView.DataSource = tabView;
            GvwView.DataBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to delete xml file's records and render new xml data on page.
        /// </summary>
        /// <param name="nameId"></param>
        private void DeleteName(string nameId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNode nodeList = xmlDocument.SelectSingleNode("Root");
            for (int i = 0; i < nodeList.ChildNodes.Count; i++)
            {
                XmlElement elXml = (XmlElement)nodeList.ChildNodes[i];
                if (nameId == elXml.Attributes["id"].InnerText)
                {
                    nodeList.RemoveChild(nodeList.ChildNodes[i]);
                }
            }
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to insert a new record in xml file.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void InsertName(string firstName, string lastName, string age)
        {
            string uniqueID = Guid.NewGuid().ToString().Replace("-", String.Empty);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNode nodeRoot = xmlDocument.SelectSingleNode("Root");
            XmlElement elePerson = xmlDocument.CreateElement("Person");
            elePerson.SetAttribute("id", uniqueID);
            XmlElement eleFirstName = xmlDocument.CreateElement("FirstName");
            eleFirstName.InnerText = firstName;
            XmlElement eleLastName = xmlDocument.CreateElement("LastName");
            eleLastName.InnerText = lastName;
            XmlElement eleAge = xmlDocument.CreateElement("Age");
            eleAge.InnerText = age;
            elePerson.AppendChild(eleFirstName);
            elePerson.AppendChild(eleLastName);
            elePerson.AppendChild(eleAge);
            nodeRoot.AppendChild(elePerson);
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to update the records of xml file.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void UpdateName(string id, string firstName, string lastName, string age)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNodeList nodeList = xmlDocument.SelectNodes("Root/Person");
            foreach (XmlNode nodeSingle in nodeList)
            {
                XmlElement eleSingle = (XmlElement)nodeSingle;
                if (nodeSingle.Attributes["id"].Value == id)
                {
                    XmlNode nodeFirstName = nodeSingle.ChildNodes[0];
                    XmlElement eleFirstName = (XmlElement)nodeFirstName;
                    eleFirstName.InnerText = firstName;
                    XmlNode nodeLastName = nodeSingle.ChildNodes[1];
                    XmlElement eleLastName = (XmlElement)nodeLastName;
                    eleLastName.InnerText = lastName;
                    XmlNode nodeAge = nodeSingle.ChildNodes[2];
                    XmlElement eleAge = (XmlElement)nodeAge;
                    eleAge.InnerText = age;
                }
            }
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// Return a output string variable and display it on page.
        /// </summary>
        /// <returns></returns>
        public string GetCallbackResult()
        {
            return strOutput; 
        }

        /// <summary>
        /// This method is use to receive arguments from JS functions, and check the header 
        /// of the string variable for invoke different methods.
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaiseCallbackEvent(string eventArgument)
        {
            string[] str = eventArgument.Split('|');
            if (str[0].Equals("Filter", StringComparison.OrdinalIgnoreCase))
            {
                this.FilterGrid(str[1], str[2], str[3]);
            }
            else if (str[0].Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                this.DeleteName(str[1]);
            }
            else if (str[0].Equals("Insert", StringComparison.OrdinalIgnoreCase))
            {
                this.InsertName(str[1], str[2], str[3]);
            }
            else if (str[0].Equals("Update", StringComparison.OrdinalIgnoreCase))
            {
                this.UpdateName(str[1], str[2], str[3], str[4]);
            }
        }

        /// <summary>
        /// Bind the GridView button controls' onclick events with JavaScript functions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvwView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Make sure the current GridViewRow is a data row.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Make sure the current GridViewRow is either 
                // in the normal state or an alternate row.
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    // Add client-side onclick events.
                    string id =((DataControlFieldCell)e.Row.Cells[2]).Text;
                    string firstName = ((DataControlFieldCell)e.Row.Cells[3]).Text.Replace("&nbsp;", "");
                    string lastName = ((DataControlFieldCell)e.Row.Cells[4]).Text.Replace("&nbsp;", "");
                    string age = ((DataControlFieldCell)e.Row.Cells[5]).Text.Replace("&nbsp;", "");
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add("onclick", String.Format("DeleteName('{0}'); return false;", id));
                    ((LinkButton)e.Row.Cells[0].Controls[0]).Attributes.Add("onclick", String.Format("GiveValue('{0}','{1}','{2}','{3}'); return false;", id, firstName, lastName, age));
                }
            }
        }
    }
}