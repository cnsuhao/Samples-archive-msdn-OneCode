/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cpp
 * Project:      CppWindowsStoreAppDynamicFontsize
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to set Dynamic Fontsize for TextBlock
 * 
 * MainPage.xaml.cpp
 * Implementation of the MainPage class
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "pch.h"
#include "MainPage.xaml.h"
#include <cmath>

using namespace CppWindowsStoreAppDynamicFontsize;
using namespace std;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

MainPage::MainPage()
{
	InitializeComponent();

	m_originalFontSize = this->ContentTextBlock->FontSize;
	m_fixedTextBlockHeight = this->ContentTextBlock->Height;
	m_previousTextLength = this->ContentTextBlock->Text->Length();
}

/// <summary>
/// Populates the page with content passed during navigation.  Any saved state is also
/// provided when recreating a page from a prior session.
/// </summary>
/// <param name="navigationParameter">The parameter value passed to
/// <see cref="Frame::Navigate(Type, Object)"/> when this page was initially requested.
/// </param>
/// <param name="pageState">A map of state preserved by this page during an earlier
/// session.  This will be null the first time a page is visited.</param>
void MainPage::LoadState(Object^ navigationParameter, IMap<String^, Object^>^ pageState)
{
	(void) navigationParameter;	// Unused parameter
	(void) pageState;	// Unused parameter
}

/// <summary>
/// Preserves state associated with this page in case the application is suspended or the
/// page is discarded from the navigation cache.  Values must conform to the serialization
/// requirements of <see cref="SuspensionManager::SessionState"/>.
/// </summary>
/// <param name="pageState">An empty map to be populated with serializable state.</param>
void MainPage::SaveState(IMap<String^, Object^>^ pageState)
{
	(void) pageState;	// Unused parameter
}

// When user delete some text, TextBlock_SizeChanged event will not be raised.
// In this scenario, we should manually raise it.
void CppWindowsStoreAppDynamicFontsize::MainPage::ContextText_TextChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::TextChangedEventArgs^ e)
{
	if(m_previousTextLength > this->ContentTextBox->Text->Length() && 
		this->ContentTextBlock->FontSize < m_originalFontSize)
	{
		// By doing this, TextBlock_SizeChanged event may be fired.
        this->ContentTextBlock->FontSize = m_originalFontSize;
	}
	m_previousTextLength = this->ContentTextBox->Text->Length();
}


void CppWindowsStoreAppDynamicFontsize::MainPage::TextBlock_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e)
{
	TextBlock^ contentTextBlock = dynamic_cast<TextBlock^> (sender);
	if(contentTextBlock != nullptr)
	{
		// Reset the font size.
		if(this->ContentTextBlock->ActualHeight > m_fixedTextBlockHeight)
		{
			// Compute the factor.
			double fontsizeMultiplier = sqrt(m_fixedTextBlockHeight / this->ContentTextBlock->ActualHeight);

			// Set the new font size.
			this->ContentTextBlock->FontSize = floor(this->ContentTextBlock->FontSize * fontsizeMultiplier);
		}
	}
}


void CppWindowsStoreAppDynamicFontsize::MainPage::FooterClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
		Windows::System::Launcher::LaunchUriAsync(ref new Uri((safe_cast<HyperlinkButton^>(sender))->Tag->ToString()));
}
