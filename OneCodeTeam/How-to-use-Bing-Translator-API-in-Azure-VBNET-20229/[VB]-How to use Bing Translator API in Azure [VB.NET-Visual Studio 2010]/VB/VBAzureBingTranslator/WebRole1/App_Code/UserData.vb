'***************************** Module Header ******************************\
'Module Name:  UserData.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This class store user's data.
' 
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
' 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************



Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web



Namespace TranslatorForAzure
	Public NotInheritable Class UserData
		Private Sub New()
        End Sub
        'This access tokent is only for test.
        'To register your application with Azure DataMarket,visit  
        'https://datamarket.azure.com/developer/applications/ using the LiveID.
        Public Shared clientID As String = "DinoBingTranslator"
        Public Shared clientSecret As String = "fzdwgtXmhazt/AEkH7BD+U+CZXpAn64xzwHdaUykN7E="
	End Class
End Namespace