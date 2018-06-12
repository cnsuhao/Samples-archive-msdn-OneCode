/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppUnvsAppWebViewHighlight.Windows
* Copyright (c) Microsoft Corporation.
*
* This code sample shows how to search and highlight the search term in WebView
* in Universal apps.
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

using namespace CppUnvsAppWebViewHighlight;

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
using namespace Windows::Storage;
using namespace Concurrency;


MainPage::MainPage()
{
	InitializeComponent();

	m_highlightFunctionJS = nullptr;
}

void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appx:///highlight.js"))).then([this](StorageFile^ highlightFile)
	{
		create_task(FileIO::ReadTextAsync(highlightFile)).then([this](String^ s)
		{
			m_highlightFunctionJS = s;
		});
	});
}

void MainPage::HighlightButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if (HighlightTerm->Text == "")
	{
		return;
	}
	Platform::Collections::Vector<String^>^ arguments = ref new Platform::Collections::Vector<String^>(1);
	arguments->SetAt(0, m_highlightFunctionJS + " HighlightFunction('" + HighlightTerm->Text + "');");

	create_task(this->MyWebView->InvokeScriptAsync(ref new String(L"eval"), arguments));
}


void MainPage::ClearButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if (HighlightTerm->Text == "")
	{
		return;
	}
	Platform::Collections::Vector<String^>^ arguments = ref new Platform::Collections::Vector<String^>(1);
	arguments->SetAt(0, m_highlightFunctionJS + " RestoreFunction();");

	create_task(this->MyWebView->InvokeScriptAsync(ref new String(L"eval"), arguments)).then([this](String^ result)
	{		
		HighlightTerm->Text = "";
	});
}


void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto uri = ref new Uri((String^)((HyperlinkButton^)sender)->Tag);
	Windows::System::Launcher::LaunchUriAsync(uri);
}


void MainPage::Page_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e)
{
	if (e->NewSize.Width <= 500)
	{
		VisualStateManager::GoToState(this, "MinimalLayout", true);
	}
	else if (e->NewSize.Width < e->NewSize.Height)
	{
		VisualStateManager::GoToState(this, "PortraitLayout", true);
	}
	else
	{
		VisualStateManager::GoToState(this, "DefaultLayout", true);
	}
}


void MainPage::MyWebView_NavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
	HighLightBtn->IsEnabled = true;
	ClearBtn->IsEnabled = true;
}
