/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.h
* Project:        CppUniversalAppSaveSurfaceImageSource.Windows
* Copyright (c) Microsoft Corporation
*
* This code sample shows how to save the content of SurfaceImageSource to image file.
*
* MainPage.xaml.h
* Declaration of the MainPage class
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
#pragma once

#include "MainPage.g.h"
#include "MyImageSource.h"

namespace CppUniversalAppSaveSurefaceImageSouce
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
		void FooterClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void SaveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		UINT m_imageWidth;
		UINT m_imageHeight;

		MyImageSourceComponent::MyImageSource^ m_myImageSource;

		void Page_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e);
	};
}
