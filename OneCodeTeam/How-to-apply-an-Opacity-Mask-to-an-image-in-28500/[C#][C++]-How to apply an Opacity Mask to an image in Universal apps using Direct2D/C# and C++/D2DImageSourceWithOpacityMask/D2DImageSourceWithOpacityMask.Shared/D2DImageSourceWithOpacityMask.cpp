/****************************** Module Header ******************************\
* Module Name:  D2DImageSourceWithOpacityMask.cpp
* Project:      D2DImageSourceWithOpacityMask
* Copyright (c) Microsoft Corporation.
*
* This sample shows how to apply opacity mask to an image.
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
#include "D2DImageSourceWithOpacityMask.h"
#include "DirectXSample.h"

#include "D2d1helper.h"
#include "Shcore.h"

using namespace D2DImageSourceWithOpacityMask;
using namespace Platform;
using namespace Microsoft::WRL;
using namespace Windows::ApplicationModel;
using namespace Windows::Graphics::Display;
using namespace Windows::UI;
using namespace Windows::UI::Xaml;
using namespace Windows::Storage;

D2DImageSource::D2DImageSource(int pixelWidth, int pixelHeight, bool isOpaque) :
SurfaceImageSource(pixelWidth, pixelHeight, isOpaque)
{
	m_width = pixelWidth;
	m_height = pixelHeight;

	CreateDeviceResources();

	Application::Current->Suspending += ref new SuspendingEventHandler(this, &D2DImageSource::OnSuspending);
}

// Initialize hardware-dependent resources.
void D2DImageSource::CreateDeviceResources()
{
	// This flag adds support for surfaces with a different color channel ordering
	// than the API default. It is required for compatibility with Direct2D.
	UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)    
	// If the project is in a debug build, enable debugging via SDK Layers.
	creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

	// This array defines the set of DirectX hardware feature levels this app will support.
	// Note the ordering should be preserved.
	// Don't forget to declare your application's minimum required feature level in its
	// description.  All applications are assumed to support 9.1 unless otherwise stated.
	const D3D_FEATURE_LEVEL featureLevels[] =
	{
		D3D_FEATURE_LEVEL_11_1,
		D3D_FEATURE_LEVEL_11_0,
		D3D_FEATURE_LEVEL_10_1,
		D3D_FEATURE_LEVEL_10_0,
		D3D_FEATURE_LEVEL_9_3,
		D3D_FEATURE_LEVEL_9_2,
		D3D_FEATURE_LEVEL_9_1,
	};

	// Create the Direct3D 11 API device object.
	DX::ThrowIfFailed(
		D3D11CreateDevice(
		nullptr,                        // Specify nullptr to use the default adapter.
		D3D_DRIVER_TYPE_HARDWARE,
		nullptr,
		creationFlags,                  // Set debug and Direct2D compatibility flags.
		featureLevels,                  // List of feature levels this app can support.
		ARRAYSIZE(featureLevels),
		D3D11_SDK_VERSION,              // Always set this to D3D11_SDK_VERSION for Windows Store apps.
		&m_d3dDevice,                   // Returns the Direct3D device created.
		nullptr,
		nullptr
		)
		);

	// Get the Direct3D 11.1 API device.
	ComPtr<IDXGIDevice> dxgiDevice;
	DX::ThrowIfFailed(
		m_d3dDevice.As(&dxgiDevice)
		);

	// Create the Direct2D device object and a corresponding context.
	DX::ThrowIfFailed(
		D2D1CreateDevice(
		dxgiDevice.Get(),
		nullptr,
		&m_d2dDevice
		)
		);

	DX::ThrowIfFailed(
		m_d2dDevice->CreateDeviceContext(
		D2D1_DEVICE_CONTEXT_OPTIONS_NONE,
		&m_d2dContext
		)
		);

	// Required for FillOpacityMask
	m_d2dContext->SetAntialiasMode(D2D1_ANTIALIAS_MODE_ALIASED);

	// Query for ISurfaceImageSourceNative interface.
	Microsoft::WRL::ComPtr<ISurfaceImageSourceNative> sisNative;
	DX::ThrowIfFailed(
		reinterpret_cast<IUnknown*>(this)->QueryInterface(IID_PPV_ARGS(&sisNative))
		);

	// Associate the DXGI device with the SurfaceImageSource.
	DX::ThrowIfFailed(
		sisNative->SetDevice(dxgiDevice.Get())
		);

	DX::ThrowIfFailed(
		CoCreateInstance(
		CLSID_WICImagingFactory,
		nullptr,
		CLSCTX_INPROC_SERVER,
		IID_PPV_ARGS(&m_wicFactory)
		)
		);
}

void D2DImageSource::SetMask(Windows::Storage::Streams::IRandomAccessStream^ randomAccessStream)
{
	ComPtr<IWICBitmapDecoder> wicBitmapDecoder;

	ComPtr<IStream> stream;
	DX::ThrowIfFailed(
		CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&stream))
		);
	DX::ThrowIfFailed(
		m_wicFactory->CreateDecoderFromStream(
		stream.Get(),
		nullptr,
		WICDecodeMetadataCacheOnDemand,
		&wicBitmapDecoder
		)
		);

	ComPtr<IWICBitmapFrameDecode> wicBitmapFrame;
	DX::ThrowIfFailed(
		wicBitmapDecoder->GetFrame(0, &wicBitmapFrame)
		);

	ComPtr<IWICFormatConverter> wicFormatConverter;
	DX::ThrowIfFailed(
		m_wicFactory->CreateFormatConverter(&wicFormatConverter)
		);

	DX::ThrowIfFailed(
		wicFormatConverter->Initialize(
		wicBitmapFrame.Get(),
		GUID_WICPixelFormat32bppPBGRA,
		WICBitmapDitherTypeNone,
		nullptr,
		0.0,
		WICBitmapPaletteTypeCustom  // the BGRA format has no palette so this value is ignored
		)
		);

	double dpiX = 96.0f;
	double dpiY = 96.0f;

	// Some formats, such as GIF and ICO, do not have full DPI support.
	// For GIF, this method calculates the DPI values from the aspect ratio, using a base DPI of(96.0, 96.0).
	// The ICO format does not support DPI at all, and the method always returns(96.0, 96.0) for ICO images.
	// Additionally, WIC itself does not transform images based on the DPI values in an image.
	// It is up to the caller to transform an image based on the resolution returned.
	DX::ThrowIfFailed(
		wicFormatConverter->GetResolution(&dpiX, &dpiY)
		);

	DX::ThrowIfFailed(
		m_d2dContext->CreateBitmapFromWicBitmap(
		wicFormatConverter.Get(),
		nullptr,
		&m_Mask  //D2Dbitmap
		)
		);
}

void D2DImageSource::SetSource(Streams::IRandomAccessStream^ randomAccessStream)
{
	ComPtr<IWICBitmapDecoder> wicBitmapDecoder;
	ComPtr<IStream> stream;
	DX::ThrowIfFailed(
		CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&stream))
		);
	DX::ThrowIfFailed(
		m_wicFactory->CreateDecoderFromStream(
		stream.Get(),
		nullptr,
		WICDecodeMetadataCacheOnDemand,
		&wicBitmapDecoder
		)
		);


	ComPtr<IWICBitmapFrameDecode> wicBitmapFrame;
	DX::ThrowIfFailed(
		wicBitmapDecoder->GetFrame(0, &wicBitmapFrame)
		);

	ComPtr<IWICFormatConverter> wicFormatConverter;
	DX::ThrowIfFailed(
		m_wicFactory->CreateFormatConverter(&wicFormatConverter)
		);

	DX::ThrowIfFailed(
		wicFormatConverter->Initialize(
		wicBitmapFrame.Get(),
		GUID_WICPixelFormat32bppPBGRA,
		WICBitmapDitherTypeNone,
		nullptr,
		0.0,
		WICBitmapPaletteTypeCustom  // the BGRA format has no palette so this value is ignored
		)
		);

	double dpiX = 96.0f;
	double dpiY = 96.0f;

	// Some formats, such as GIF and ICO, do not have full DPI support.
	// For GIF, this method calculates the DPI values from the aspect ratio, using a base DPI of(96.0, 96.0).
	// The ICO format does not support DPI at all, and the method always returns(96.0, 96.0) for ICO images.
	// Additionally, WIC itself does not transform images based on the DPI values in an image.
	// It is up to the caller to transform an image based on the resolution returned.
	DX::ThrowIfFailed(
		wicFormatConverter->GetResolution(&dpiX, &dpiY)
		);

	DX::ThrowIfFailed(
		m_d2dContext->CreateBitmapFromWicBitmap(
		wicFormatConverter.Get(),
		nullptr,
		&m_Bitmap  //D2Dbitmap
		)
		);
}

void D2DImageSource::RenderBitmap()
{
	if (m_Mask)
	{
		Microsoft::WRL::ComPtr<ID2D1BitmapBrush> bmpBrsh;

		m_d2dContext->CreateBitmapBrush(m_Bitmap.Get(), &bmpBrsh);

		m_d2dContext->FillOpacityMask(m_Mask.Get(), bmpBrsh.Get());
	}
	else
	{
		m_d2dContext->DrawBitmap(m_Bitmap.Get());
	}
}

// Begins drawing, allowing updates to content in the specified area.
void D2DImageSource::BeginDraw(Windows::Foundation::Rect updateRect)
{
	POINT offset;
	ComPtr<IDXGISurface> surface;

	// Express target area as a native RECT type.
	RECT updateRectNative;
	updateRectNative.left = static_cast<LONG>(updateRect.Left);
	updateRectNative.top = static_cast<LONG>(updateRect.Top);
	updateRectNative.right = static_cast<LONG>(updateRect.Right);
	updateRectNative.bottom = static_cast<LONG>(updateRect.Bottom);

	// Query for ISurfaceImageSourceNative interface.
	Microsoft::WRL::ComPtr<ISurfaceImageSourceNative> sisNative;
	DX::ThrowIfFailed(
		reinterpret_cast<IUnknown*>(this)->QueryInterface(IID_PPV_ARGS(&sisNative))
		);

	// Begin drawing - returns a target surface and an offset to use as the top left origin when drawing.
	HRESULT beginDrawHR = sisNative->BeginDraw(updateRectNative, &surface, &offset);

	if (SUCCEEDED(beginDrawHR))
	{
		// Create render target.
		ComPtr<ID2D1Bitmap1> bitmap;
		DX::ThrowIfFailed(
			m_d2dContext->CreateBitmapFromDxgiSurface(
			surface.Get(),
			nullptr,
			&bitmap
			)
			);


		// Set context's render target.
		m_d2dContext->SetTarget(bitmap.Get());


		// Begin drawing using D2D context.
		m_d2dContext->BeginDraw();

		// Apply a clip and transform to constrain updates to the target update area.
		// This is required to ensure coordinates within the target surface remain
		// consistent by taking into account the offset returned by BeginDraw, and
		// can also improve performance by optimizing the area that is drawn by D2D.
		// Apps should always account for the offset output parameter returned by 
		// BeginDraw, since it may not match the passed updateRect input parameter's location.
		m_d2dContext->PushAxisAlignedClip(
			D2D1::RectF(
			static_cast<float>(offset.x),
			static_cast<float>(offset.y),
			static_cast<float>(offset.x + updateRect.Width),
			static_cast<float>(offset.y + updateRect.Height)
			),
			D2D1_ANTIALIAS_MODE_ALIASED
			);

		m_d2dContext->SetTransform(
			D2D1::Matrix3x2F::Translation(
			static_cast<float>(offset.x),
			static_cast<float>(offset.y)
			)
			);
	}
	else if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET)
	{
		// If the device has been removed or reset, attempt to recreate it and continue drawing.
		CreateDeviceResources();
		BeginDraw(updateRect);
	}
	else
	{
		// Notify the caller by throwing an exception if any other error was encountered.
		DX::ThrowIfFailed(beginDrawHR);
	}
}

// Ends drawing updates started by a previous BeginDraw call.
void D2DImageSource::EndDraw()
{
	// Remove the transform and clip applied in BeginDraw since
	// the target area can change on every update.
	m_d2dContext->SetTransform(D2D1::IdentityMatrix());
	m_d2dContext->PopAxisAlignedClip();

	// Remove the render target and end drawing.
	DX::ThrowIfFailed(
		m_d2dContext->EndDraw()
		);

	m_d2dContext->SetTarget(nullptr);

	// Query for ISurfaceImageSourceNative interface.
	Microsoft::WRL::ComPtr<ISurfaceImageSourceNative> sisNative;
	DX::ThrowIfFailed(
		reinterpret_cast<IUnknown*>(this)->QueryInterface(IID_PPV_ARGS(&sisNative))
		);

	DX::ThrowIfFailed(
		sisNative->EndDraw()
		);
}

// Clears the background with the given color.
void D2DImageSource::Clear(Windows::UI::Color color)
{
	m_d2dContext->Clear(DX::ConvertToColorF(color));
}

void D2DImageSource::OnSuspending(Object ^sender, SuspendingEventArgs ^e)
{
	ComPtr<IDXGIDevice3> dxgiDevice;
	m_d3dDevice.As(&dxgiDevice);

	// Hints to the driver that the app is entering an idle state and that its memory can be used temporarily for other apps.
	dxgiDevice->Trim();
}