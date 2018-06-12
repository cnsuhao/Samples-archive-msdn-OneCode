/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.cpp
* Project:        CppUniversalAppSaveSurfaceImageSource.WindowsPhone
* Copyright (c) Microsoft Corporation
*
* This code sample shows how to save the content of SurfaceImageSource to image file.
*
* MainPage.xaml.h
* Declaration of the MainPage class
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

#include "pch.h"
#include "MainPage.xaml.h"

using namespace CppUniversalAppSaveSurefaceImageSouce;

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
using namespace Windows::UI;
using namespace Windows::Storage;
using namespace Windows::Storage::Pickers;
using namespace Windows::Storage::Streams;
using namespace concurrency;


MainPage::MainPage()
{
	InitializeComponent();

	m_imageWidth = (UINT)MyImage->Width;
	m_imageHeight = (UINT)MyImage->Height;
	m_myImageSource = ref new MyImageSourceComponent::MyImageSource(m_imageWidth, m_imageHeight, true);
	MyImage->Source = m_myImageSource;
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	// Begin updating the SurfaceImageSource 
	m_myImageSource->BeginDraw();


	// Clear background 
	m_myImageSource->Clear(Colors::Black);

	// Draw something...
	Rect rect;
	float startPointX = 0.0;
	float startPointY = 0.0f;
	float deltaX = 3.0f;
	float deltaY = 3.0f;

	rect.X = startPointX;
	rect.Y = startPointY;
	rect.Width = (m_imageWidth - deltaX * 2) / 2.0f;
	rect.Height = (m_imageHeight - deltaY * 2) / 2.0f;
	m_myImageSource->FillSolidRect(ColorHelper::FromArgb(255, 250, 67, 5), rect);

	rect.X = startPointX + rect.Width + 2 * deltaX;
	m_myImageSource->FillSolidRect(ColorHelper::FromArgb(255, 96, 176, 6), rect);

	rect.X = startPointX;
	rect.Y = startPointY + rect.Height + 2 * deltaY;
	m_myImageSource->FillSolidRect(ColorHelper::FromArgb(255, 14, 179, 241), rect);

	rect.X = startPointX + rect.Width + 2 * deltaX;
	m_myImageSource->FillSolidRect(ColorHelper::FromArgb(255, 247, 199, 36), rect);

	// Stop updating the SurfaceImageSource and draw its contents 
	m_myImageSource->EndDraw();
}
void MainPage::FooterClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri((safe_cast<HyperlinkButton^>(sender))->Tag->ToString()));
}


void MainPage::SaveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	FileSavePicker^ savePicker = ref new FileSavePicker;
	savePicker->FileTypeChoices->Insert("Png File", ref new Platform::Collections::Vector < String^ >{ ".png" });
	savePicker->SuggestedStartLocation = PickerLocationId::PicturesLibrary;
	savePicker->SuggestedFileName = "MyImage";
	savePicker->PickSaveFileAndContinue();
}

void MainPage::ContinueFileSavePicker(FileSavePickerContinuationEventArgs^ args)
{
	StorageFile^ file = args->File;
	create_task(file->OpenAsync(FileAccessMode::ReadWrite)).then([=](IRandomAccessStream^ stream){
		m_myImageSource->SaveSurfaceImageToFile(stream);
	});
}
