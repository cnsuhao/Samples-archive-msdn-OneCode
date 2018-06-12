/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.h
* Project:        CppUniversalAppSaveSurfaceImageSource.WindowsPhone
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
#include "ContinuationManager.h"
namespace CppUniversalAppSaveSurefaceImageSouce
{
	/// <summary>
	/// Implement IFileSavePickerContinuable interface, in order that Continuation Manager can automatically
	/// trigger the method to process returned file.
	/// </summary>
	public ref class MainPage sealed: IFileSavePickerContinuable
	{
	public:
		MainPage();
		virtual void ContinueFileSavePicker(FileSavePickerContinuationEventArgs^ args);
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
