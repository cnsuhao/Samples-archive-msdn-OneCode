/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.h
 * Project:      CppWindowsStoreAppManipulateIBuffer
 * Copyright (c) Microsoft Corporation.
 * 
 * Declaration of the MainPage class.
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
#include "Common\LayoutAwarePage.h" // Required by generated header

namespace CppWindowsStoreAppManipulateIBuffer
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
        void OnCompositionTargetRendering(Platform::Object^ sender, Platform::Object^ args);
		void Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

		static const int64 m_cycleDuration = 30000000;   // 3 seconds
        Platform::Array<byte>^ m_srcPixels;
        byte* m_pDstPixels;
        int m_width;
		int m_height;
		int m_xCenter;
		int m_yCenter;
		Windows::UI::Xaml::Media::Imaging::WriteableBitmap^ m_writeableBitmap;
		volatile bool m_isImgLoaded;
		void PickAFileButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
