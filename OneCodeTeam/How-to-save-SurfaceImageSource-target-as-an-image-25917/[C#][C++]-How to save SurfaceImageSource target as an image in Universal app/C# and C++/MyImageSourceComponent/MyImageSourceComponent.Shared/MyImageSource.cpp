/****************************** Module Header ******************************\
* Module Name:    MyImageSource.cpp
* Project:        MyImageSourceComponent
* Copyright (c) Microsoft Corporation
*
* This class derives from SurfaceImageSource class. It extends SurfaceImagSource
* to save the content to image file.
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
#include "MyImageSource.h" 
#include "DirectXSample.h" 
 
using namespace MyImageSourceComponent;
using namespace Platform; 
using namespace Windows::UI::Xaml::Media::Imaging;
using namespace Windows::Storage;
using namespace Windows::Storage::Pickers;
using namespace concurrency;
using namespace Windows::Graphics::Display;

MyImageSource::MyImageSource(UINT pixelWidth, UINT pixelHeight, bool isOpaque) : 
SurfaceImageSource((int)ConvertDipsToPixels((float)pixelWidth), (int)ConvertDipsToPixels((float)pixelHeight), isOpaque)
{ 
	m_width = (UINT)ConvertDipsToPixels((float)pixelWidth);
	m_height = (UINT)ConvertDipsToPixels((float)pixelHeight);
 
	CreateDeviceIndependentResources(); 
	CreateDeviceResources(); 
} 
// Method to convert a length in device-independent pixels (DIPs) to a length in physical pixels.
float MyImageSource::ConvertDipsToPixels(float dips)
{
	Windows::Graphics::Display::DisplayInformation^ currentDisplayInformation =
		Windows::Graphics::Display::DisplayInformation::GetForCurrentView();
	static const float dipsPerInch = 96.0f;
	return floor(dips * currentDisplayInformation->LogicalDpi / dipsPerInch + 0.5f); // Round to nearest integer.
}
// Initialize resources that are independent of hardware. 
void MyImageSource::CreateDeviceIndependentResources() 
{ 
	// Query for ISurfaceImageSourceNative interface. 
	DX::ThrowIfFailed( 
		reinterpret_cast<IUnknown*>(this)->QueryInterface(IID_PPV_ARGS(&m_sisNative)) 
		); 

	D2D1_FACTORY_OPTIONS options;

	#if defined(_DEBUG)
	// If the project is in a debug build, enable Direct2D debugging via Direct2D SDK layer.
	// Enabling SDK debug layer can help catch coding mistakes such as invalid calls and
	// resource leaking that needs to be fixed during the development cycle.
	options.debugLevel = D2D1_DEBUG_LEVEL_INFORMATION;
#endif

	DX::ThrowIfFailed(
		D2D1CreateFactory(
			D2D1_FACTORY_TYPE_SINGLE_THREADED,
			__uuidof(ID2D1Factory1),
			&options,
			&m_d2dFactory
			)
		);

	DX::ThrowIfFailed(
	CoCreateInstance(
		CLSID_WICImagingFactory, nullptr,
		CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&m_wicFactory) 
		)
	);

} 
 
// Initialize hardware-dependent resources. 
void MyImageSource::CreateDeviceResources() 
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
			D3D11_SDK_VERSION,              // Always set this to D3D11_SDK_VERSION for Metro style apps. 
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
 
	// Set DPI to the display's current DPI. 
	DisplayInformation^ currentDisplayInformation = DisplayInformation::GetForCurrentView();
	SetDpi(currentDisplayInformation->LogicalDpi);
 
	// Associate the DXGI device with the SurfaceImageSource. 
	DX::ThrowIfFailed( 
		m_sisNative->SetDevice(dxgiDevice.Get()) 
		); 
} 
 
// Sets the current DPI. 
void MyImageSource::SetDpi(float dpi) 
{ 
	// Update Direct2D's stored DPI. 
	m_d2dContext->SetDpi(dpi, dpi); 
} 
 
// Begins drawing, allowing updates to content in the specified area. 
void MyImageSource::BeginDraw(Windows::Foundation::Rect updateRect) 
{     
	POINT offset; 
	ComPtr<IDXGISurface> surface; 
 
	// Express target area as a native RECT type. 
	RECT updateRectNative;  
	updateRectNative.left = static_cast<LONG>(updateRect.Left); 
	updateRectNative.top = static_cast<LONG>(updateRect.Top); 
	updateRectNative.right = static_cast<LONG>(updateRect.Right); 
	updateRectNative.bottom = static_cast<LONG>(updateRect.Bottom); 
 
	// Begin drawing - returns a target surface and an offset to use as the top left origin when drawing. 
	HRESULT beginDrawHR = m_sisNative->BeginDraw(updateRectNative, &surface, &offset); 
  
	if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET) 
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

	// Create wic bitmap
	WICPixelFormatGUID format = GUID_WICPixelFormat32bppPBGRA;	

	DX::ThrowIfFailed(
		m_wicFactory->CreateBitmap(static_cast<UINT>(updateRect.Width), static_cast<UINT>(updateRect.Height), 
			format, WICBitmapCacheOnLoad, &m_wicBitmap)
		);

	// Create wic render target
	D2D1_RENDER_TARGET_PROPERTIES RTProps = D2D1::RenderTargetProperties(
			);
	RTProps.pixelFormat = D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM,D2D1_ALPHA_MODE_PREMULTIPLIED);

	DX::ThrowIfFailed(
		m_d2dFactory->CreateWicBitmapRenderTarget(m_wicBitmap.Get(),&RTProps,&m_wicBitmapRenderTarget)
		);

	// Begin drawing using WIC Bitmap RenderTarget.
	m_wicBitmapRenderTarget->BeginDraw();
} 
 
// Ends drawing updates started by a previous BeginDraw call. 
void MyImageSource::EndDraw() 
{ 
	DX::ThrowIfFailed(
		m_wicBitmapRenderTarget->EndDraw()
	);
	
	// Get D2D bitmap from wic bitmap
	DX::ThrowIfFailed(
	m_d2dContext->CreateBitmapFromWicBitmap(m_wicBitmap.Get(), &m_d2dBitmap)
		);

	// Draw D2D bitmap on DXGI surface.
	m_d2dContext->DrawBitmap(m_d2dBitmap.Get(),NULL,1.0,D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,NULL);

	// Remove the transform and clip applied in BeginDraw since 
	// the target area can change on every update. 
	m_d2dContext->SetTransform(D2D1::IdentityMatrix()); 
	m_d2dContext->PopAxisAlignedClip(); 
	
	// Remove the render target and end drawing. 
	DX::ThrowIfFailed( 
		m_d2dContext->EndDraw() 
		); 
 
	m_d2dContext->SetTarget(nullptr); 
 
	DX::ThrowIfFailed( 
		m_sisNative->EndDraw() 
		); 
} 
 
// Clears the background with the given color. 
void MyImageSource::Clear(Windows::UI::Color color) 
{ 
	m_wicBitmapRenderTarget->Clear(DX::ConvertToColorF(color)); 
} 
 
// Draws a filled rectangle with the given color and position. 
// NOTE: For saving the content of SurfaceImageSource to image file, we first create an
// off-screen WIC bitmap, then draw to this WIC Bitmap, and then we draw the wic bitmap to d2d surface.
void MyImageSource::FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect) 
{ 
	// Create a solid color D2D brush. 
	ComPtr<ID2D1SolidColorBrush> brush; 
	DX::ThrowIfFailed( 
		m_wicBitmapRenderTarget->CreateSolidColorBrush( 
			DX::ConvertToColorF(color), 
			&brush 
			) 
		); 
 
	// Draw a filled rectangle. 
	m_wicBitmapRenderTarget->FillRectangle(DX::ConvertToRectF(rect), brush.Get()); 
}


// Save the content of SurfaceImageSource to an image file.
void MyImageSource::SaveSurfaceImageToFile(Streams::IRandomAccessStream^ randomAccessStream)
{
	// Convert the RandomAccessStream to an IStream.
	ComPtr<IStream> stream;
	DX::ThrowIfFailed(
		CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&stream))
		);
	// Save as png file.
	std::shared_ptr<GUID> wicFormat = std::make_shared<GUID>(GUID_ContainerFormatPng);
	SaveBitmapToStream(m_wicBitmap, m_wicFactory, *wicFormat, stream.Get());
}

// Save WIC bitmap to a stream.
void MyImageSource::SaveBitmapToStream(
	_In_ ComPtr<IWICBitmap> wicBitmap,
	_In_ ComPtr<IWICImagingFactory2> wicFactory2,
	_In_ REFGUID wicFormat,
	_In_ IStream* stream
	)
{
	// Create and initialize WIC Bitmap Encoder.
	ComPtr<IWICBitmapEncoder> wicBitmapEncoder;
	DX::ThrowIfFailed(
		wicFactory2->CreateEncoder(
			wicFormat,
			nullptr,    // No preferred codec vendor.
			&wicBitmapEncoder
			)
		);

	DX::ThrowIfFailed(
		wicBitmapEncoder->Initialize(
			stream,
			WICBitmapEncoderNoCache
			)
		);

	// Create and initialize WIC Frame Encoder.
	ComPtr<IWICBitmapFrameEncode> wicFrameEncode;
	DX::ThrowIfFailed(
		wicBitmapEncoder->CreateNewFrame(
			&wicFrameEncode,
			nullptr     // No encoder options.
			)
		);

	DX::ThrowIfFailed(
		wicFrameEncode->Initialize(nullptr)
		);

	WICPixelFormatGUID format = GUID_WICPixelFormatDontCare;

	DX::ThrowIfFailed(
		wicFrameEncode->SetPixelFormat(&format)
		);

	DX::ThrowIfFailed(
		wicFrameEncode->WriteSource(wicBitmap.Get(),nullptr)
		);

	DX::ThrowIfFailed(
		wicFrameEncode->Commit()
		);

	DX::ThrowIfFailed(
		wicBitmapEncoder->Commit()
		);

	// Flush all memory buffers to the next-level storage object.
	DX::ThrowIfFailed(
		stream->Commit(STGC_DEFAULT)
		);
}
