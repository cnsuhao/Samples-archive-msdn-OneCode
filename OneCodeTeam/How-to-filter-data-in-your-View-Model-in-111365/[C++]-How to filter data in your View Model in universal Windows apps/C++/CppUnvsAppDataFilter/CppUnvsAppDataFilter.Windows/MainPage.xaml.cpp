/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppUnvsAppDataFilter.Windows
* Copyright (c) Microsoft Corporation.
*
* This sample demonstrates how to filter data in your View Model.
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

using namespace CppUnvsAppDataFilter;

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

MainPage::MainPage()
{
	InitializeComponent();

	viewModel = ref new MainViewModel;

	this->DataContext = viewModel;
}

void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri("http://blogs.msdn.com/b/onecode"));
}


void MainPage::Page_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e)
{
	if (e->NewSize.Width < 800)
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
