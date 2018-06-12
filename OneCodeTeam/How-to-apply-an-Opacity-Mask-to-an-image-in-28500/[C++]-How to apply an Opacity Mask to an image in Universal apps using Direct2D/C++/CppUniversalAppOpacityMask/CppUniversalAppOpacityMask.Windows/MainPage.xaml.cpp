/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppUniversalAppOpacityMask.Windows
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

using namespace CppUniversalAppOpacityMask;

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
using namespace Windows::Storage::Pickers;
using namespace concurrency;
using namespace D2DImageSourceWithOpacityMask;


MainPage::MainPage()
{
	InitializeComponent();

	this->Loaded += ref new Windows::UI::Xaml::RoutedEventHandler(this, &MainPage::OnLoaded);
	Window::Current->SizeChanged += ref new Windows::UI::Xaml::WindowSizeChangedEventHandler(this, &MainPage::OnSizeChanged);
	_btnRender->IsEnabled = false;
}


void MainPage::OpenImageBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Pickers::FileOpenPicker^ openPicker = ref new Pickers::FileOpenPicker();
	openPicker->SuggestedStartLocation = Pickers::PickerLocationId::PicturesLibrary;
	openPicker->ViewMode = PickerViewMode::Thumbnail;
	openPicker->FileTypeFilter->Append(".jpg");
	openPicker->FileTypeFilter->Append(".bmp");
	openPicker->FileTypeFilter->Append(".png");
	create_task(openPicker->PickSingleFileAsync()).then([=](StorageFile^ file)
	{
		if (file == nullptr)
		{
			cancel_current_task();

		}
		//ImageProperties^ imagePropertise = file->Properties->GetImagePropertiesAsync();
		return file->OpenAsync(FileAccessMode::Read);

	}).then([=](Streams::IRandomAccessStream^ randomAccessStream)
	{
		m_d2dImageSource->SetSource(randomAccessStream);
		auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
		bitmapImage->SetSourceAsync(randomAccessStream);
		OrignalImage->Source = bitmapImage;
		_btnRender->IsEnabled = true;
	});
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
	// Begin updating the SurfaceImageSource
	m_d2dImageSource->BeginDraw();

	// Clear background
	m_d2dImageSource->Clear(Windows::UI::Colors::Transparent);

	// Render the source and apply the mask
	m_d2dImageSource->RenderBitmap();

	// Stop updating the SurfaceImageSource and draw its contents
	m_d2dImageSource->EndDraw();
}


void MainPage::OnLoaded(Platform::Object ^sender, Windows::UI::Xaml::RoutedEventArgs ^e)
{
	m_d2dImageSource = ref new D2DImageSource(
		(int)(ImageGrid->ActualWidth - Image->Margin.Left - Image->Margin.Right),
		(int)(ImageGrid->ActualHeight - Image->Margin.Top - Image->Margin.Bottom), false);

	// Use m_d2dImageSource as a source for the Image control
	Image->Source = m_d2dImageSource;
}


void MainPage::OnSizeChanged(Platform::Object ^sender, Windows::UI::Core::WindowSizeChangedEventArgs ^e)
{
	if (e->Size.Width <= 800)
	{
		VisualStateManager::GoToState(this, "MinimalLayout", true);
	}
	else
	{
		VisualStateManager::GoToState(this, "DefaultLayout", true);
	}
}


void MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri((safe_cast<HyperlinkButton^>(sender))->Tag->ToString()));
}

