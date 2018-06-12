/***************************** Module Header ******************************\
* Module Name:	MainWindow.xaml.h
* Project:		CppAzureMobileServiceWithTableStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use table storage with windows Azure mobile service.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
#pragma once

#include "MainPage.g.h"

namespace CppAzureMobileServiceWithTableStorage
{
	///// <summary>
    ///// This class name should equal to the table name you created on Azure mobile service.
    ///// </summary>
	[BindableAttribute]
	public ref class ShortMessage sealed
	{
	public:		
		ShortMessage()
		{
		}
		property int64 Id;
		property Platform::String^ PartitionKey;
		property int64 RowKey;
		property Windows::Foundation::DateTime Timestamp;
		property Platform::String^ Name;
		property Platform::String^ Message;
		property bool IsRead;
	};

	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

	protected:
		virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
	private:
		void btnSave_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void appbtnDelete_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void appbtnUpdate_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void RefreshData();
		void InsertNewMessage(ShortMessage^ message);
		void DeleteNewMessage(ShortMessage^ message, int index);
		void UpdateNewMessage(ShortMessage^ message, int index);

		Vector<ShortMessage^>^ messages; 
		Microsoft::WindowsAzure::MobileServices::IMobileServiceTable^ table;
	};
}
