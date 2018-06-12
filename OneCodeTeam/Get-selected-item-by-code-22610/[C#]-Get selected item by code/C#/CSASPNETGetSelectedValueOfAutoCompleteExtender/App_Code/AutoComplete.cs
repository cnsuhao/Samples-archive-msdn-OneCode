/****************************** Module Header ******************************\
* Module Name:    AutoComplete.cs
* Project:        CSASPNETGetSelectedValueOfAutoCompleteExtender
* Copyright (c) Microsoft Corporation
*
* This WebService is used to search for movies under the conditions
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{
    private List<string> _movies = new List<string>();

    public AutoComplete()
    {
        _movies.Add("a1");
        _movies.Add("a2");
        _movies.Add("b1");
        _movies.Add("China");
        _movies.Add("c21");
        _movies.Add("Dead");
        _movies.Add("Dear");
        _movies.Add("Dream");
        _movies.Add("Empty");
        _movies.Add("Egg");
        _movies.Add("Flower");
        _movies.Add("Floor");
        _movies.Add("Great");
        _movies.Add("g");
        _movies.Add("h1");
        _movies.Add("h2");
        _movies.Add("i1");
        _movies.Add("jeep");
        _movies.Add("k");
        _movies.Add("Loop");
        _movies.Add("Man");
        _movies.Add("Nice");
        _movies.Add("O1");
        _movies.Add("Pear");
        _movies.Add("Queen");
        _movies.Add("Rest");
        _movies.Add("S1");
        _movies.Add("S2");
        _movies.Add("T1 ");
        _movies.Add("T2 ");
        _movies.Add("US");
        _movies.Add("UK");
        _movies.Add("V");
        _movies.Add("W");
        _movies.Add("X");
        _movies.Add("Y");
        _movies.Add("Z");
    }

    [WebMethod]
    public string[] GetMovies(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }

        var matches = (from m in _movies
                       where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)
                       select m).Take(count);
        return matches.ToArray();
    }
}

