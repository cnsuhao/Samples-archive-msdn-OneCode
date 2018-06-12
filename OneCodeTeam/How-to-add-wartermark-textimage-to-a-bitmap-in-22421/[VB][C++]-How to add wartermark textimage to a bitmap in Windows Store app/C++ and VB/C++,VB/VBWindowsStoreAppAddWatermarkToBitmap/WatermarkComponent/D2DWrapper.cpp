/****************************** Module Header ******************************\
 * Module Name:  D2DWrapper.cpp
 * Project:      WatermarkComponent
 * Copyright (c) Microsoft Corporation.
 * 
 * This class is designed to draw text or image to a bitmap render target.
 * 
 * To use this helper class, please follow the following steps:
 * 1. New an instance of the class.
 * 2. Call the Initialize() function to initialize the resources.
 * 3. Call SetBitmapRenderTarget() function to set the render target.
 * 4. Before you draw anything, please call BeginDraw() function.
 * 5. Draw something. This component only implements two simple drawing methods:
 *    DrawText and DrawImage. Actually, you can draw anything you want by using 
 *    the D2D rendering engine.
 * 6. Call EndDraw(bool needPreview). This method returns a valid IRandomAccessStream 
 *    reference if needPreview is true, otherwise, it will return NULL. 
 * 7. If you want to save the bitmap to a file, you can call SaveBitmapToFile().
 * 8. This class also supplies a helper function to retrieve the system fonts.
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
#include "D2DWrapper.h"
using namespace concurrency;
using namespace D2D1;
using namespace Windows::Storage;
using namespace WatermarkComponent;

// Constructor.
D2DWrapper::D2DWrapper(): m_fontEnumerator(nullptr)
{
}

// Initialize the DirectX resources required to run.
void D2DWrapper::Initialize()
{
    CreateDeviceIndependentResources();
    CreateDeviceResources();
}


// These are the resources required independent of the device.
void D2DWrapper::CreateDeviceIndependentResources()
{
	D2D1_FACTORY_OPTIONS options;
    ZeroMemory(&options, sizeof(D2D1_FACTORY_OPTIONS));


    DX::ThrowIfFailed(
		D2D1CreateFactory(
        D2D1_FACTORY_TYPE_SINGLE_THREADED,
        __uuidof(ID2D1Factory1),
        &options,
        &m_d2dFactory)
		);

	DX::ThrowIfFailed(
		CoCreateInstance(
            CLSID_WICImagingFactory,
            nullptr,
            CLSCTX_INPROC_SERVER,
            IID_PPV_ARGS(&m_wicFactory))
        );

    DX::ThrowIfFailed(
		DWriteCreateFactory(
            DWRITE_FACTORY_TYPE_SHARED,
            __uuidof(IDWriteFactory),
            &m_dwriteFactory)
        );
}

// These are the resources that depend on the device.
void D2DWrapper::CreateDeviceResources()
{
 
	// This flag adds support for surfaces with a different color channel ordering than the API default.
    // You need it for compatibility with Direct2D.
    UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

	
    // This array defines the set of DirectX hardware feature levels this app  supports.
    // The ordering is important and you should  preserve it.
    // Don't forget to declare your app's minimum required feature level in its
    // description.  All apps are assumed to support 9.1 unless otherwise stated.
    D3D_FEATURE_LEVEL featureLevels[] = 
    {
        D3D_FEATURE_LEVEL_11_1,
        D3D_FEATURE_LEVEL_11_0,
        D3D_FEATURE_LEVEL_10_1,
        D3D_FEATURE_LEVEL_10_0,
        D3D_FEATURE_LEVEL_9_3,
        D3D_FEATURE_LEVEL_9_2,
        D3D_FEATURE_LEVEL_9_1
    };

	
    // Create the DX11 API device object, and get a corresponding context.
    ComPtr<ID3D11Device> device;
    ComPtr<ID3D11DeviceContext> context;

    DX::ThrowIfFailed(
		D3D11CreateDevice(
			nullptr,                    // specify null to use the default adapter
			D3D_DRIVER_TYPE_HARDWARE,
			0,                          
			creationFlags,              // optionally set debug and Direct2D compatibility flags
			featureLevels,              // list of feature levels this app can support
			ARRAYSIZE(featureLevels),   // number of possible feature levels
			D3D11_SDK_VERSION,          
			&device,                    // returns the Direct3D device created
			&m_featureLevel,            // returns feature level of device created
			&context                    // returns the device immediate context
			)
		);

    ComPtr<IDXGIDevice> dxgiDevice;

    // Obtain the underlying DXGI device of the Direct3D11 device.
	DX::ThrowIfFailed(
		device.As(&dxgiDevice)
		);

    // Obtain the Direct2D device for 2-D rendering.
    DX::ThrowIfFailed(
		m_d2dFactory->CreateDevice(dxgiDevice.Get(), &m_d2dDevice)
		);

    // Get Direct2D device's corresponding device context object.
    DX::ThrowIfFailed(
		m_d2dDevice->CreateDeviceContext(
            D2D1_DEVICE_CONTEXT_OPTIONS_NONE,
            &m_d2dContext)
        );
}

// Set bitmap render target. 
void D2DWrapper::SetBitmapRenderTarget(Streams::IRandomAccessStream^  backgroundImageStream)
{
	// Clear the render target.
	m_d2dContext->SetTarget(nullptr);

	// Convert the RandomAccessStream to an IStream.
    ComPtr<IStream> stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(backgroundImageStream, IID_PPV_ARGS(&stream))
        );

	// Create the bitmap decoder.
    ComPtr<IWICBitmapDecoder> decoder;
    DX::ThrowIfFailed(
        m_wicFactory->CreateDecoderFromStream(
		    stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &decoder
            )
        );
	
	// Get the first frame. 
    ComPtr<IWICBitmapFrameDecode> frame;
    DX::ThrowIfFailed(
        decoder->GetFrame(0, &frame)
        );

    DX::ThrowIfFailed(
        m_wicFactory->CreateFormatConverter(&m_backgroundBitmapConverter)
        );

    DX::ThrowIfFailed(
        m_backgroundBitmapConverter->Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );

    double dpiX = 96.0f;
	double dpiY = 96.0f;
	DX::ThrowIfFailed(
		m_backgroundBitmapConverter->GetResolution(&dpiX, &dpiY)
		);

	DX::ThrowIfFailed(
		m_d2dContext->CreateBitmapFromWicBitmap(
			m_backgroundBitmapConverter.Get(), 
			D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_TARGET,
			D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
			static_cast<float>(dpiX),
			static_cast<float>(dpiY),0
			),
			&m_targetBitmap
			)
		);

	m_d2dContext->SetTarget(m_targetBitmap.Get());

	// Retrieve the renderTargetSize in DIPs.
	m_renderTargetSize = m_d2dContext->GetSize();
}

// Call this function before you draw.
void D2DWrapper::BeginDraw()
{
	m_d2dContext->BeginDraw();
	m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
}

// Call this function when you finish the drawing.
IRandomAccessStream^ D2DWrapper::EndDraw(bool needPreview)
{
	DX::ThrowIfFailed(
		m_d2dContext->EndDraw()
		);

	// If needPreview is true, we return a valid IRandomAccessStream reference.
	if(needPreview)
	{
		GUID wicFormat = GUID_ContainerFormatBmp;
		ComPtr<IStream> stream;
		ComPtr<ISequentialStream> ss;
		auto inMemStream =  ref new InMemoryRandomAccessStream();
		DX::ThrowIfFailed(
			CreateStreamOverRandomAccessStream(inMemStream ,IID_PPV_ARGS(&stream))
			);

		SaveBitmapToStream(m_targetBitmap, m_wicFactory, m_d2dContext, wicFormat, stream.Get());
	
		return inMemStream;
	}

	return nullptr;
}

// Draw text with the specified styles.
// Please note that startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f.
void D2DWrapper::DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName, 
						  Color foregroundColor, float fontSize, FONT_STYLE_ENUM fontStyle, 
						  FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName)
{
    // In case user input invalid startPoint, we do a simple validation.
	if(startPoint.X < 0.0f || startPoint.X > 1.0f || startPoint.Y < 0.0f || startPoint.Y > 1.0f)
	{
		throw ref new Platform::InvalidArgumentException("startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f");
	}

    // Create a DirectWrite text format object.
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            fontFamilyName->Data(),				 // font family name
            nullptr,							 // system font collection
            (DWRITE_FONT_WEIGHT)fontWeight,		 // font weight 
            (DWRITE_FONT_STYLE)fontStyle,		 // font style
            DWRITE_FONT_STRETCH_NORMAL,			 // default font stretch
            fontSize,						     // font size
            localeName->Data(),					 // locale name
            &m_textFormat
            )
        );

    // Set text alignment.
    DX::ThrowIfFailed(
        m_textFormat->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING)
        );

    // Set paragraph alignment.
    DX::ThrowIfFailed(
        m_textFormat->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );

	D2D1_RECT_F layoutRect = {startPoint.X * m_renderTargetSize.width, startPoint.Y * m_renderTargetSize.height,
		m_renderTargetSize.width, m_renderTargetSize.height};

	
	D2D1_COLOR_F textColor = D2D1::ColorF(foregroundColor.R / 255.0f, foregroundColor.G / 255.0f, 
		foregroundColor.B /255.0f, foregroundColor.A / 255.0f);

	 DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            textColor,
            &m_textBrush
            )
        );

	m_d2dContext->DrawText(text->Data(),text->Length(), m_textFormat.Get(), &layoutRect, m_textBrush.Get()); 
}

// Draw image
void D2DWrapper::DrawImage(Windows::Storage::Streams::IRandomAccessStream^ watermarkImageStream, Point startPoint, 
						   float opacity)
{
	// In case user input the invalid startPoint, we do a simple Validation.
	if(startPoint.X < 0.0f || startPoint.X > 1.0f || startPoint.Y < 0.0f || startPoint.Y > 1.0f)
	{
		throw ref new Platform::InvalidArgumentException("startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f");
	}

	// Convert the RandomAccessStream to an IStream.
    ComPtr<IStream> stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(watermarkImageStream, IID_PPV_ARGS(&stream))
        );

	// Create the bitmap decoder.
    ComPtr<IWICBitmapDecoder> decoder;
    DX::ThrowIfFailed(
        m_wicFactory->CreateDecoderFromStream(
		    stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &decoder
            )
        );

    ComPtr<IWICBitmapFrameDecode> frame;
    DX::ThrowIfFailed(
        decoder->GetFrame(0, &frame)
        );

    DX::ThrowIfFailed(
        m_wicFactory->CreateFormatConverter(&m_watermarkImageConverter)
        );

    DX::ThrowIfFailed(
        m_watermarkImageConverter->Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );

    double dpiX = 96.0f;
	double dpiY = 96.0f;

	m_watermarkImageConverter->GetResolution(&dpiX, &dpiY);
	DX::ThrowIfFailed(
	m_d2dContext->CreateBitmapFromWicBitmap(
		m_watermarkImageConverter.Get(), 
		D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_NONE,
		D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
		static_cast<float>(dpiX),
		static_cast<float>(dpiY),0
		),
		&m_watermarkBitmap
		)
	);

	D2D1_SIZE_F watermarkImageSize = m_watermarkBitmap->GetSize();

	float startPointOffsetX = startPoint.X * m_renderTargetSize.width;
	float startPointOffsetY = startPoint.Y * m_renderTargetSize.height;

	D2D1_RECT_F destinationRect = {startPointOffsetX, startPointOffsetY, startPointOffsetX + watermarkImageSize.width,
		startPointOffsetY + watermarkImageSize.height};

	m_d2dContext->DrawBitmap(m_watermarkBitmap.Get(), &destinationRect, opacity);  

}

// Save the bitmap target to file.
void D2DWrapper::SaveBitmapToFile()
{
	// Prepare a file picker for customers to input image file name.
    Pickers::FileSavePicker^ savePicker = ref new Pickers::FileSavePicker();
    auto pngExtensions = ref new Platform::Collections::Vector<Platform::String^>();
    pngExtensions->Append(".png");
    savePicker->FileTypeChoices->Insert("PNG file", pngExtensions);
    auto jpgExtensions = ref new Platform::Collections::Vector<Platform::String^>();
    jpgExtensions->Append(".jpg");
    savePicker->FileTypeChoices->Insert("JPEG file", jpgExtensions);
    auto bmpExtensions = ref new Platform::Collections::Vector<Platform::String^>();
    bmpExtensions->Append(".bmp");
    savePicker->FileTypeChoices->Insert("BMP file", bmpExtensions);
    savePicker->DefaultFileExtension = ".png";
    savePicker->SuggestedFileName = "watermark";
    savePicker->SuggestedStartLocation = Pickers::PickerLocationId::PicturesLibrary;

    std::shared_ptr<GUID> wicFormat = std::make_shared<GUID>(GUID_ContainerFormatPng);

    create_task(savePicker->PickSaveFileAsync()).then([=](StorageFile^ file)
    {
        if (file == nullptr)
        {
            // If user clicks "Cancel", reset the saving state, then cancel the current task.
            //m_screenSavingState = ScreenSavingState::NotSaved;
            cancel_current_task();
        }

        if (file->FileType == ".bmp")
        {
            *wicFormat = GUID_ContainerFormatBmp;
        }
        else if (file->FileType == ".jpg")
        {
            *wicFormat = GUID_ContainerFormatJpeg;
        }
        return file->OpenAsync(FileAccessMode::ReadWrite);

    }).then([=](Streams::IRandomAccessStream^ randomAccessStream)
    {
        // Convert the RandomAccessStream to an IStream.
        ComPtr<IStream> stream;
        DX::ThrowIfFailed(
            CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&stream))
            );

		SaveBitmapToStream(m_targetBitmap, m_wicFactory, m_d2dContext, *wicFormat, stream.Get());
	});
}

// Save render target bitmap to a stream using WIC.
void D2DWrapper::SaveBitmapToStream(
    _In_ ComPtr<ID2D1Bitmap1> d2dBitmap,
    _In_ ComPtr<IWICImagingFactory2> wicFactory2,
    _In_ ComPtr<ID2D1DeviceContext> d2dContext,
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

    // Retrieve D2D Device.
    ComPtr<ID2D1Device> d2dDevice;
    d2dContext->GetDevice(&d2dDevice);

    // Create IWICImageEncoder.
    ComPtr<IWICImageEncoder> imageEncoder;
    DX::ThrowIfFailed(
        wicFactory2->CreateImageEncoder(
            d2dDevice.Get(),
            &imageEncoder
            )
        );

    DX::ThrowIfFailed(
        imageEncoder->WriteFrame(
            d2dBitmap.Get(),
            wicFrameEncode.Get(),
            nullptr     // Use default WICImageParameter options.
            )
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

// Get system font.
Platform::Array<Platform::String^>^ D2DWrapper::GetSystemFont()
{
	if(m_fontEnumerator == nullptr)
	{
		m_fontEnumerator = ref new FontEnumerator();
	}
	return m_fontEnumerator->ListSystemFonts();
}
