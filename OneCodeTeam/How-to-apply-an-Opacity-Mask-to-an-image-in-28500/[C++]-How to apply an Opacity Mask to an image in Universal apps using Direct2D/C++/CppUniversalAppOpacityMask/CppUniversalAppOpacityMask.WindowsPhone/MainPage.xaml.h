/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.h
* Project:      CppUniversalAppOpacityMask.WindowsPhone
* Copyright (c) Microsoft Corporation.
*
* This sample shows how to apply opacity mask to an image in Universal apps.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
#pragma once

#include "MainPage.g.h"
#include "ContinuationManager.h"
#include "Common\NavigationHelper.h"
namespace CppUniversalAppOpacityMask
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPage sealed : IFileOpenPickerContinuable
	{
	public:
		MainPage();

		/// <summary>
		/// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
		/// </summary>
		property Common::NavigationHelper^ NavigationHelper
		{
			Common::NavigationHelper^ get();
		}

		virtual void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs^ args);

	private:
		void SaveState(Platform::Object^ sender, Common::SaveStateEventArgs^ e);
		void LoadState(Platform::Object^ sender, Common::LoadStateEventArgs^ e);
		static Windows::UI::Xaml::DependencyProperty^ _navigationHelperProperty;

		Windows::Storage::Streams::IRandomAccessStream^ m_stream;
		D2DImageSourceWithOpacityMask::D2DImageSource^ m_d2dImageSource;
		void OpenImageBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void _btnRender_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void MaskComboBox_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e);

		void OnLoaded(Platform::Object ^sender, Windows::UI::Xaml::RoutedEventArgs ^e);
		void HardwareButtons_BackPressed(Platform::Object^ sender, Windows::Phone::UI::Input::BackPressedEventArgs^ args);
	protected:
		virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
		virtual void OnNavigatedFrom(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
	private:
		void Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
