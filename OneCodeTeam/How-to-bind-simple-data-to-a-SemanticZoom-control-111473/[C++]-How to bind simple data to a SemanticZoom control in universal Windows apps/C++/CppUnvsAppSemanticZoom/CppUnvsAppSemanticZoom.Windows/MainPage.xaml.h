/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.h
* Project:      CppUnvsAppSemanticZoom.Windows
* Copyright (c) Microsoft Corporation.
*
* This code sample shows how to bind simple data to SemanticZoom control in Universal apps.
* For more details, please refer to:
* http://blogs.msdn.com/b/wsdevsol/archive/2014/09/18/a-simple-semanticzoom.aspx
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

#include "SimpleData.h"
namespace CppUnvsAppSemanticZoom
{
	public ref class MainPage sealed
	{
	public:
		MainPage();
	internal:
		property Windows::Foundation::Collections::IObservableVector<Speaker^>^ AllSpeakers
		{
			Windows::Foundation::Collections::IObservableVector<Speaker^>^ get()
			{
				return _allSpeakers;
			}
			void set(Windows::Foundation::Collections::IObservableVector<Speaker^>^ value)
			{
				if (!_allSpeakers->Equals(value))
				{
					_allSpeakers = value;
				}
			}
		}
		property Windows::Foundation::Collections::IObservableVector<LanguageGroup^>^ AllLanguageGroups
		{
			Windows::Foundation::Collections::IObservableVector<LanguageGroup^>^ get()
			{
				return _allLanguageGroups;
			}
			void set(Windows::Foundation::Collections::IObservableVector<LanguageGroup^>^ value)
			{
				if (!_allLanguageGroups->Equals(value))
				{
					_allLanguageGroups = value;
				}
			}
		}
	private:
		Windows::Foundation::Collections::IObservableVector<Speaker^>^ _allSpeakers;
		Windows::Foundation::Collections::IObservableVector<LanguageGroup^>^ _allLanguageGroups;
		void BuildDataSources();
		void Page_SizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e);
		void MySZ_ZoomedInGridView_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e);
		void ChangeViewButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
	};
}
