/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.h
 * Project:      CppWindowsStoreAppDynamicFontsize
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to set Dynamic Fontsize for TextBlock
 * 
 * MainPage.xaml.h
 * Declaration of the MainPage class
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

#include "Common\LayoutAwarePage.h" // Required by generated header
#include "MainPage.g.h"

namespace CppWindowsStoreAppDynamicFontsize
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

	protected:
		virtual void LoadState(Platform::Object^ navigationParameter,
			Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^>^ pageState) override;
		virtual void SaveState(Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^>^ pageState) override;
	private:
		void ContextText_TextChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::TextChangedEventArgs^ e);
		void TextBlock_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e);
		void FooterClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

		double m_originalFontSize;
        double m_fixedTextBlockHeight;
        unsigned int m_previousTextLength;
	};
}
