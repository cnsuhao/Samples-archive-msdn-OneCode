/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppUniversalAppOpacityMask.WindowsPhone
* Copyright (c) Microsoft Corporation.
*
* This sample shows how to apply opacity mask to an image in Universal apps.
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
#include "ImagePage.xaml.h"
using namespace CppUniversalAppOpacityMask;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Storage;
using namespace Windows::Storage::Pickers;
using namespace concurrency;
using namespace D2DImageSourceWithOpacityMask;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

MainPage::MainPage()
{
	InitializeComponent();
	_btnRender->IsEnabled = false;
	this->Loaded += ref new Windows::UI::Xaml::RoutedEventHandler(this, &MainPage::OnLoaded);
	/*Windows::Phone::UI::Input::HardwareButtons::BackPressed += 
		ref new EventHandler<Windows::Phone::UI::Input::BackPressedEventArgs^>(this, &MainPage::HardwareButtons_BackPressed);
*/
	auto navigationHelper = ref new Common::NavigationHelper(this);
	SetValue(_navigationHelperProperty, navigationHelper);
	navigationHelper->SaveState += ref new Common::SaveStateEventHandler(this, &MainPage::SaveState);
	navigationHelper->LoadState += ref new Common::LoadStateEventHandler(this, &MainPage::LoadState);
}

DependencyProperty^ MainPage::_navigationHelperProperty =
DependencyProperty::Register("NavigationHelper",
TypeName(Common::NavigationHelper::typeid), TypeName(MainPage::typeid), nullptr);

/// <summary>
/// Gets an implementation of <see cref="NavigationHelper"/> designed to be
/// used as a trivial view model.
/// </summary>
Common::NavigationHelper^ MainPage::NavigationHelper::get()
{
	return safe_cast<Common::NavigationHelper^>(GetValue(_navigationHelperProperty));
}

void MainPage::SaveState(Object^ sender, Common::SaveStateEventArgs^ e)
{
	e->PageState->Insert("ImageStream", m_stream);
}

void MainPage::LoadState(Object^ sender, Common::LoadStateEventArgs^ e)
{
	if (e->PageState != nullptr && e->PageState->HasKey("ImageStream"))
	{
		m_stream = (Streams::IRandomAccessStream^)e->PageState->Lookup("ImageStream");
	}
}

void MainPage::HardwareButtons_BackPressed(Object^ sender, Windows::Phone::UI::Input::BackPressedEventArgs^ args)
{
	if (this->Frame->CurrentSourcePageType.Name == "MainPage")
	{
		this->Frame->BackStack->Clear();
	}
}

void MainPage::OnLoaded(Platform::Object ^sender, Windows::UI::Xaml::RoutedEventArgs ^e)
{
	m_d2dImageSource = ref new D2DImageSource(
		(int)(contentGrid->ActualWidth),
		(int)(contentGrid->ActualHeight), false);
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedTo(e);
}

void MainPage::OnNavigatedFrom(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedFrom(e);
}


void MainPage::OpenImageBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Pickers::FileOpenPicker^ openPicker = ref new Pickers::FileOpenPicker();
	openPicker->SuggestedStartLocation = Pickers::PickerLocationId::PicturesLibrary;
	openPicker->ViewMode = PickerViewMode::Thumbnail;
	openPicker->FileTypeFilter->Append(".jpg");
	openPicker->FileTypeFilter->Append(".bmp");
	openPicker->FileTypeFilter->Append(".png");
	
	openPicker->PickSingleFileAndContinue();
}

void MainPage::ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs^ args)
{
	if (args->Files->Size > 0)
	{
		create_task(args->Files->GetAt(0)->OpenAsync(FileAccessMode::Read)).
			then([this](Streams::IRandomAccessStream^ stream){
			auto bitmapImage = ref new Media::Imaging::BitmapImage;
			bitmapImage->SetSource(stream);
			OrignalImage->Source = bitmapImage;
			m_stream = stream;
			_btnRender->IsEnabled = true;
		});
	}
}

void MainPage::MaskComboBox_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{

	auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage;

	switch (MaskComboBox->SelectedIndex)
	{
	case 0:
		create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appx:///Assets/BitmapMask.png"))
			).then([=](StorageFile^ file)
		{
			if (file == nullptr)
			{
				cancel_current_task();
			}
			return file->OpenAsync(FileAccessMode::Read);
		}).then([=](Streams::IRandomAccessStream^ randomAccessStream)
		{
			m_d2dImageSource->SetMask(randomAccessStream);
			auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
			bitmapImage->SetSourceAsync(randomAccessStream);
			MaskImage->Source = bitmapImage;
		});
		break;
	case 1:
		create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appx:///Assets/Mask1.png"))
			).then([=](StorageFile^ file)
		{
			if (file == nullptr)
			{
				cancel_current_task();
			}
			return file->OpenAsync(FileAccessMode::Read);
		}).then([=](Streams::IRandomAccessStream^ randomAccessStream)
		{
			m_d2dImageSource->SetMask(randomAccessStream);
			auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
			bitmapImage->SetSourceAsync(randomAccessStream);
			MaskImage->Source = bitmapImage;
		});
		break;
	case 2:
		create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appx:///Assets/Mask2.png"))
			).then([=](StorageFile^ file)
		{
			if (file == nullptr)
			{
				cancel_current_task();
			}
			return file->OpenAsync(FileAccessMode::Read);
		}).then([=](Streams::IRandomAccessStream^ randomAccessStream)
		{
			m_d2dImageSource->SetMask(randomAccessStream);
			auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
			bitmapImage->SetSourceAsync(randomAccessStream);
			MaskImage->Source = bitmapImage;
		});
		break;
	}
}


void MainPage::_btnRender_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	m_d2dImageSource->SetSource(m_stream);

	// Begin updating the SurfaceImageSource
	m_d2dImageSource->BeginDraw();

	// Clear background
	m_d2dImageSource->Clear(Windows::UI::Colors::Transparent);

	// Render the source and apply the mask
	m_d2dImageSource->RenderBitmap();

	// Stop updating the SurfaceImageSource and draw its contents
	m_d2dImageSource->EndDraw();

	this->Frame->Navigate(ImagePage::typeid, m_d2dImageSource);
}

void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri((safe_cast<HyperlinkButton^>(sender))->Tag->ToString()));

}
