/****************************** Module Header ******************************\
* Module Name:    GetCountries.aspx.cs
* Project:        CSASPNETJqueryFilterLoadDynamicContent
* Copyright (c) Microsoft Corporation
*
* This page returns the query data upon request.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETJqueryFilterLoadDynamicContent
{
    public partial class GetCountries : System.Web.UI.Page
    {

        public List<Province> Provinces;

        protected override void OnInit(EventArgs e)
        {
            //load sample data
            LoadSampleProvincesData();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["countryID"]))
                {
                    string countryID = Request.QueryString["countryID"]; //get query string into string variable

                    //filter Provinces sample data by countryID using LINQ
                    //and add the collection as data source to the repeater
                    rptCountries.DataSource = Provinces.Where(x => x.countryID == countryID);
                    rptCountries.DataBind(); //bind repeater
                }
            }

        }

        /// <summary>
        /// load sample data method
        /// </summary>
        public void LoadSampleProvincesData()
        {
            Provinces = new List<Province>();
            Provinces.Add(new Province() { countryID = "China", PinYin = "HeBei", ProvinceName = "HeBei" });
            Provinces.Add(new Province() { countryID = "China", PinYin = "BeiJing", ProvinceName = "BeiJing" });
            Provinces.Add(new Province() { countryID = "China", PinYin = "ShangHai", ProvinceName = "ShangHai" });
            Provinces.Add(new Province() { countryID = "China", PinYin = "ShanXi", ProvinceName = "ShanXi" });
            Provinces.Add(new Province() { countryID = "China", PinYin = "JiangXi", ProvinceName = "JiangXi" });
            Provinces.Add(new Province() { countryID = "China", PinYin = "LiaoNing", ProvinceName = "LiaoNing" });
            Provinces.Add(new Province() { countryID = "US", PinYin = "Los Angeles", ProvinceName = "Los Angeles" });
            Provinces.Add(new Province() { countryID = "US", PinYin = "Detroit", ProvinceName = "Detroit" });
            Provinces.Add(new Province() { countryID = "New York", PinYin = "New York", ProvinceName = "New York" });
            Provinces.Add(new Province() { countryID = "UK", PinYin = "England", ProvinceName = "England" });
            Provinces.Add(new Province() { countryID = "UK", PinYin = "Scotland", ProvinceName = "Scotland" });
        }
    }  
}
