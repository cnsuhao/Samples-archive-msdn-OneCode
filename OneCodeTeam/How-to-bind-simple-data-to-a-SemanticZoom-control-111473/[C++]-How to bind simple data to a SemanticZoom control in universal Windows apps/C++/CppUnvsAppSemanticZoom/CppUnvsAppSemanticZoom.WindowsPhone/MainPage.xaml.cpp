/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppUnvsAppSemanticZoom.WindowsPhone
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

#include "pch.h"
#include "MainPage.xaml.h"

using namespace CppUnvsAppSemanticZoom;

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
using namespace Windows::UI::Popups;

MainPage::MainPage()
{
	InitializeComponent();

	BuildDataSources();

	MyCollectionViewSource->Source = AllLanguageGroups;
	MySZ_ZoomedOutGridView->ItemsSource = MyCollectionViewSource->View->CollectionGroups;

}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	(void) e;	// Unused parameter

	// TODO: Prepare page for display here.

	// TODO: If your application contains multiple pages, ensure that you are
	// handling the hardware Back button by registering for the
	// Windows::Phone::UI::Input::HardwareButtons.BackPressed event.
	// If you are using the NavigationHelper provided by some templates,
	// this event is handled for you.
}

void MainPage::BuildDataSources()
{
	_allSpeakers = ref new Platform::Collections::Vector<Speaker^>();
	Speaker^ speaker1 = ref new Speaker();
	speaker1->Name = "Johnny";
	speaker1->Languages->Append("Spanish");
	_allSpeakers->Append(speaker1);

	Speaker^ speaker2 = ref new Speaker();
	speaker2->Name = "Jack";
	speaker2->Languages->Append("Arabic");
	speaker2->Languages->Append("Portuguese");
	_allSpeakers->Append(speaker2);

	Speaker^ speaker3 = ref new Speaker();
	speaker3->Name = "David";
	speaker3->Languages->Append("Hindi");
	_allSpeakers->Append(speaker3);

	Speaker^ speaker4 = ref new Speaker();
	speaker4->Name = "Andrew";
	speaker4->Languages->Append("Hindi");
	speaker4->Languages->Append("Italian");
	_allSpeakers->Append(speaker4);

	Speaker^ speaker5 = ref new Speaker();
	speaker5->Name = "Mary";
	speaker5->Languages->Append("Arabic");
	speaker5->Languages->Append("Italian");
	_allSpeakers->Append(speaker5);

	Speaker^ speaker6 = ref new Speaker();
	speaker6->Name = "Jane";
	speaker6->Languages->Append("Arabic");
	_allSpeakers->Append(speaker6);

	Speaker^ speaker7 = ref new Speaker();
	speaker7->Name = "Avril";
	speaker7->Languages->Append("Arabic");
	speaker7->Languages->Append("French");
	_allSpeakers->Append(speaker7);

	Speaker^ speaker8 = ref new Speaker();
	speaker8->Name = "Martin";
	speaker8->Languages->Append("Arabic");
	speaker8->Languages->Append("French");
	speaker8->Languages->Append("Portuguese");
	_allSpeakers->Append(speaker8);

	Speaker^ speaker9 = ref new Speaker();
	speaker9->Name = "Jose";
	speaker9->Languages->Append("Portugese");
	speaker9->Languages->Append("Spanish");
	_allSpeakers->Append(speaker9);

	_allLanguageGroups = ref new Platform::Collections::Vector<LanguageGroup^>();
	LanguageGroup^ myLanguageGroup;
	auto SpanishList = ref new Platform::Collections::Vector<Speaker^>;
	SpanishList->Append(speaker1);
	SpanishList->Append(speaker9);
	myLanguageGroup = ref new LanguageGroup("Spanish", SpanishList);
	_allLanguageGroups->Append(myLanguageGroup);

	auto ArabicList = ref new Platform::Collections::Vector<Speaker^>;
	ArabicList->Append(speaker2);
	ArabicList->Append(speaker5);
	ArabicList->Append(speaker6);
	ArabicList->Append(speaker7);
	ArabicList->Append(speaker8);
	myLanguageGroup = ref new LanguageGroup("Arabic", ArabicList);
	_allLanguageGroups->Append(myLanguageGroup);

	auto HindiList = ref new Platform::Collections::Vector<Speaker^>;
	HindiList->Append(speaker3);
	HindiList->Append(speaker4);
	myLanguageGroup = ref new LanguageGroup("Hindi", HindiList);
	_allLanguageGroups->Append(myLanguageGroup);

	auto ItalianList = ref new Platform::Collections::Vector<Speaker^>;
	ItalianList->Append(speaker4);
	ItalianList->Append(speaker5);
	myLanguageGroup = ref new LanguageGroup("Italian", ItalianList);
	_allLanguageGroups->Append(myLanguageGroup);

	auto FrenchList = ref new Platform::Collections::Vector<Speaker^>;
	FrenchList->Append(speaker7);
	FrenchList->Append(speaker8);
	myLanguageGroup = ref new LanguageGroup("French", FrenchList);
	_allLanguageGroups->Append(myLanguageGroup);

	auto PortugueseList = ref new Platform::Collections::Vector<Speaker^>;
	PortugueseList->Append(speaker2);
	PortugueseList->Append(speaker8);
	PortugueseList->Append(speaker9);
	myLanguageGroup = ref new LanguageGroup("Portuguese", PortugueseList);
	_allLanguageGroups->Append(myLanguageGroup);
}


void MainPage::MySZ_ZoomedInGridView_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	Speaker^ MySpeaker = (Speaker^)e->AddedItems->GetAt(0);

	String^ SpeakerInformation = "Name: " + MySpeaker->Name + "\r\n";
	SpeakerInformation += "Known Languages: " + "\r\n";
	for (String^ L : MySpeaker->Languages)
	{
		SpeakerInformation += "   " + L + "\r\n";
	}

	auto MyMessageDialog = ref new MessageDialog(SpeakerInformation);
	MyMessageDialog->ShowAsync();
}


void MainPage::ChangeViewButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	MySemanticZoom->IsZoomedInViewActive = !MySemanticZoom->IsZoomedInViewActive;
}


void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{

}
