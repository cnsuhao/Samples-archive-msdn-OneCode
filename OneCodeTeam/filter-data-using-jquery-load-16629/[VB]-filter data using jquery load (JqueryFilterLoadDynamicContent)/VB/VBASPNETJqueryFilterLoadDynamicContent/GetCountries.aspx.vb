'****************************** Module Header ******************************\
' Module Name:    GetCountries.aspx.vb
' Project:        VBJqueryFilterLoadDynamicContent
' Copyright (c) Microsoft Corporation
'
' This page returns the query data upon request.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class GetCountries
    Inherits System.Web.UI.Page

    Public Provinces As List(Of Province)

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        'load sample data
        LoadSampleProvincesData()
        MyBase.OnInit(e)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Request.QueryString.Count > 0 Then
            If Not String.IsNullOrEmpty(Request.QueryString("countryID")) Then
                Dim countryID As String = Request.QueryString("countryID")
                'get query string into string variable
                'filter Provinces sample data by countryID using LINQ
                'and add the collection as data source to the repeater
                rptCountries.DataSource = Provinces.Where(Function(x) x.countryID = countryID)
                'bind repeater
                rptCountries.DataBind()
            End If
        End If

    End Sub

    ''' <summary>
    ''' load sample data method
    ''' </summary>
    Public Sub LoadSampleProvincesData()
        Provinces = New List(Of Province)()

        Provinces.Add(New Province() With {.countryID = "China", .PinYin = "HeBei", .ProvinceName = "HeBei"})
        Provinces.Add(New Province() With { _
           .countryID = "China", _
           .PinYin = "BeiJing", _
           .ProvinceName = "BeiJing" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "China", _
           .PinYin = "ShangHai", _
           .ProvinceName = "ShangHai" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "China", _
           .PinYin = "ShanXi", _
           .ProvinceName = "ShanXi" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "China", _
           .PinYin = "JiangXi", _
           .ProvinceName = "JiangXi" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "China", _
           .PinYin = "LiaoNing", _
           .ProvinceName = "LiaoNing" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "US", _
           .PinYin = "Los Angeles", _
           .ProvinceName = "Los Angeles" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "US", _
           .PinYin = "Detroit", _
           .ProvinceName = "Detroit" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "New York", _
           .PinYin = "New York", _
           .ProvinceName = "New York" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "UK", _
           .PinYin = "England", _
           .ProvinceName = "England" _
        })
        Provinces.Add(New Province() With { _
           .countryID = "UK", _
           .PinYin = "Scotland", _
           .ProvinceName = "Scotland" _
        })
    End Sub
End Class