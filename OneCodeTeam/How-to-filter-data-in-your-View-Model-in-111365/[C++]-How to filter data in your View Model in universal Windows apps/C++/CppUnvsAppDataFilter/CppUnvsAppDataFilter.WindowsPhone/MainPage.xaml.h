/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.h
* Project:      CppUnvsAppDataFilter.WindowsPhone
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

#pragma once

#include "MainPage.g.h"
#include "DoubleToMoneyConverter.h"
#include "MainViewModel.h"
using namespace CppUnvsAppDataFilter::Converters;
using namespace CppUnvsAppDataFilter::ViewModel;
namespace CppUnvsAppDataFilter
{
	public ref class MainPage sealed
	{
	public:
		MainPage();

	protected:
		virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;

	private:
		void Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		MainViewModel^ viewModel;
	};
}
