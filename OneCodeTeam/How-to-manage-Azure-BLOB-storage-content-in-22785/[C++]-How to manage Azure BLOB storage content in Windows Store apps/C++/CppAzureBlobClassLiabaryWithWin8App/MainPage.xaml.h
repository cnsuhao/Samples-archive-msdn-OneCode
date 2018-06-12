/***************************** Module Header ******************************\
* Module Name:	MainPage.xaml.h
* Project:		CppAzureBlobClassLiabaryWithWin8App
* Copyright (c) Microsoft Corporation.
* 
* Windows Azure storage class library now supports windows store app.
* This sample will show you how to operate Azure blob storage in your store app, 
* including upload/download/delete file from blob storage.
*
* MainPage.xaml.h
* Declaration of the MainPage class.
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
using namespace Microsoft::WindowsAzure::Storage::Auth;
using namespace Microsoft::WindowsAzure::Storage::Blob;
using namespace Windows::Globalization;
namespace CppAzureBlobClassLiabaryWithWin8App
{
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
		void btnDelete_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void lvwBlobs_ItemClick(Platform::Object^ sender, Windows::UI::Xaml::Controls::ItemClickEventArgs^ e);
		void refreshListview();
		bool EnsureUnsnapped();

		StorageCredentials^ cred;
		CloudBlobContainer^ blobContainer;
		Calendar^ calendar;
	};
}
