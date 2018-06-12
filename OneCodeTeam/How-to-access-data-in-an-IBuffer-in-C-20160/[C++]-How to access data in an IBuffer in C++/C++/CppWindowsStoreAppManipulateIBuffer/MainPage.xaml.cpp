/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cpp
 * Project:      CppWindowsStoreAppManipulateIBuffer
 * Copyright (c) Microsoft Corporation.
 *
 * IBuffers are returned in several places (WriteableBitmap::PixelBuffer being 
 * the most common request) and it isn't clear how to manipulate them. We have 
 * samples of how to do this in .Net with the AsStream extension method, but not 
 * in C++. You can create a DataReader from an IBuffer using the static FromBuffer 
 * method, and this allows you to read raw data from the IBuffer. However, 
 * DataWriter doesn't allow you to write the raw data to IBuffer. This sample 
 * demonstrates extracting the pixels from a WriteableBitmap by getting its 
 * IBufferByteAccess interface, editing the pixels, and then dynamically updating it.
 *
 * Implementation of the MainPage class.
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
#include <ppltasks.h>
#include <robuffer.h>

using namespace CppWindowsStoreAppManipulateIBuffer;
using namespace concurrency;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Storage;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Media::Imaging;
using namespace Windows::Graphics::Imaging;
using namespace Microsoft::WRL;
using namespace Windows::Storage::Pickers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

MainPage::MainPage()
{
	InitializeComponent();
	m_isImgLoaded = false;
    CompositionTarget::Rendering += ref new EventHandler<Object^>(this, &MainPage::OnCompositionTargetRendering);
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	(void) e;	// Unused parameter
}

void CppWindowsStoreAppManipulateIBuffer::MainPage::PickAFileButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	// Cache the flag.
	bool previousFlag = m_isImgLoaded;

	// Set the flag as false to stop updating the writable bitmap.
	m_isImgLoaded = false;

	FileOpenPicker^ openPicker = ref new FileOpenPicker();
    openPicker->ViewMode = PickerViewMode::Thumbnail;
    openPicker->SuggestedStartLocation = PickerLocationId::PicturesLibrary;
    openPicker->FileTypeFilter->Append(".jpg");
    openPicker->FileTypeFilter->Append(".jpeg");
    openPicker->FileTypeFilter->Append(".png");
	
	create_task(openPicker->PickSingleFileAsync()).then([this, previousFlag](StorageFile^ imgFile)
    {
		if(imgFile)
		{
			create_task(imgFile->OpenAsync(Windows::Storage::FileAccessMode::Read)).then([](IRandomAccessStream^ stream){
				return BitmapDecoder::CreateAsync(stream);
			}).then([](BitmapDecoder^ bmpDecoder){
				return bmpDecoder->GetFrameAsync(0);
			}).then([this](BitmapFrame^ bmpFrame){
				m_width = bmpFrame->PixelWidth;
				m_height = bmpFrame->PixelHeight;
				m_xCenter  = m_width/2;
				m_yCenter = m_height/2;
				return bmpFrame->GetPixelDataAsync();
			}).then([this](PixelDataProvider^ pixelProvider){
				m_srcPixels = pixelProvider->DetachPixelData();
				m_writeableBitmap = ref new WriteableBitmap(m_width,m_height);
				convertedImg->Source = m_writeableBitmap;
				
				// Get access to the pixels
				IBuffer^ buffer = m_writeableBitmap->PixelBuffer;

				// Obtain IBufferByteAccess
				ComPtr<IBufferByteAccess> pBufferByteAccess;
				ComPtr<IUnknown> pBuffer((IUnknown*)buffer);
				pBuffer.As(&pBufferByteAccess);
    
				// Get pointer to pixel bytes
				pBufferByteAccess->Buffer(&m_pDstPixels);

				// Set the flag as true.
				m_isImgLoaded = true;
			});
		}
		else 
		{
			// If user does not select a picture, let's restore the flag.
			m_isImgLoaded = previousFlag;
		}
    });
}

void MainPage::OnCompositionTargetRendering(Object^ sender, Object^ args)
{
	// Once the image is loaded successfully, then we can dynamically update the WritableBitmap.
	if(m_isImgLoaded)
	{
		// Get elapsed time
		TimeSpan timeSpan = dynamic_cast<RenderingEventArgs^>(args)->RenderingTime;

		// Calculate twistAngle from -180 to 180 degrees
		double t = (timeSpan.Duration % m_cycleDuration) / (double)m_cycleDuration;
		double tprime = 2 * (t < 0.5 ? t : 1 - t);
		double twistAngle = 2 * (tprime - 0.5) * 3.14159;

		for (int yDst = 0; yDst < m_height; yDst++)
		for (int xDst = 0; xDst < m_width; xDst++)
		{
			// Calculate length of point to center and angle
			int xDelta = xDst - m_xCenter;
			int yDelta = yDst - m_yCenter;
			double distanceToCenter = sqrt(xDelta * xDelta +
										   yDelta * yDelta);
			double angleClockwise = atan2(yDelta, xDelta);

			// Calculation angle of rotation for twisting effect
			double xEllipse = m_xCenter * cos(angleClockwise);
			double yEllipse = m_yCenter * sin(angleClockwise);
			double radius = sqrt(xEllipse * xEllipse +
								 yEllipse * yEllipse);
			double fraction = max(0.0, 1 - distanceToCenter / radius);
			double twist = fraction * twistAngle;

			// Calculate the source pixel for each destination pixel
			int xSrc = (int)(m_xCenter + (xDst - m_xCenter) * cos(twist)
									 - (yDst - m_yCenter) * sin(twist));
			int ySrc = (int)(m_yCenter + (xDst - m_xCenter) * sin(twist)
									 + (yDst - m_yCenter) * cos(twist));
			xSrc = max(0, min(m_width - 1, xSrc));
			ySrc = max(0, min(m_height - 1, ySrc));

			// Calculate the indices
			int iDst = 4 * (yDst * m_width + xDst);
			int iSrc = 4 * (ySrc * m_width + xSrc);

			// Transfer the pixel bytes
			m_pDstPixels[iDst++] = m_srcPixels[iSrc++];
			m_pDstPixels[iDst++] = m_srcPixels[iSrc++];
			m_pDstPixels[iDst++] = m_srcPixels[iSrc++];
			m_pDstPixels[iDst] = m_srcPixels[iSrc];
		}

		// Invalidate the bitmap
		m_writeableBitmap->Invalidate();
	}
}

void CppWindowsStoreAppManipulateIBuffer::MainPage::Footer_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri((safe_cast<HyperlinkButton^>(sender))->Tag->ToString()));
}


