/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppWindowsStoreAppWebViewAlertInterceptor
* Copyright (c) Microsoft Corporation.
*
* This code sample shows you how to intercept JavaScript alert in WebView and
* display the alert message in Windows Store apps.
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

using namespace CppWindowsStoreAppWebViewAlertInterceptor;

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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

MainPage::MainPage()
{
	InitializeComponent();

	Window::Current->SizeChanged += ref new WindowSizeChangedEventHandler(this, &MainPage::WindowSizeChanged);
}

void MainPage::WindowSizeChanged(Object^ sender, Windows::UI::Core::WindowSizeChangedEventArgs^ e)
{
	(void)sender;	// Unused parameter

	if (e->Size.Width <= 500)
	{
		VisualStateManager::GoToState(this, "MinimalLayout", true);
	}
	else if (e->Size.Width < e->Size.Height)
	{
		VisualStateManager::GoToState(this, "PortraitLayout", true);
	}
	else
	{
		VisualStateManager::GoToState(this, "DefaultLayout", true);
	}
}

void MainPage::WebViewWithJSInjection_NavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
	Platform::Collections::Vector<String^>^ arguments = ref new Platform::Collections::Vector<String^>(1);
	arguments->SetAt(0, "window.alert = function (AlertMessage) {window.external.notify(AlertMessage)}");
	this->WebViewWithJSInjection->InvokeScriptAsync("eval", arguments);
}


void MainPage::WebViewWithJSInjection_ScriptNotify(Platform::Object^ sender, Windows::UI::Xaml::Controls::NotifyEventArgs^ e)
{
	Windows::UI::Popups::MessageDialog^ dialog = ref new Windows::UI::Popups::MessageDialog(e->Value);
	dialog->ShowAsync();
}

void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto uri = ref new Uri((String^)((HyperlinkButton^)sender)->Tag);
	Windows::System::Launcher::LaunchUriAsync(uri);
}


