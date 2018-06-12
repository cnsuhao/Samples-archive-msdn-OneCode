/****************************** Module Header ******************************\
* Module Name:    MyImageSource.h
* Project:        MyImageSourceWinRT
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
#pragma once 
 
using namespace Microsoft::WRL; 

namespace MyImageSourceWinRT 
{
    public ref class MyImageSource sealed : Windows::UI::Xaml::Media::Imaging::SurfaceImageSource 
    { 
    public: 
        MyImageSource(UINT pixelWidth, UINT pixelHeight, bool isOpaque); 
 
        void BeginDraw(Windows::Foundation::Rect updateRect); 
        void BeginDraw()    { BeginDraw(Windows::Foundation::Rect(0, 0, (float)m_width, (float)m_height)); } 
        void EndDraw(); 
 
        void SetDpi(float dpi); 
 
        void Clear(Windows::UI::Color color); 
        void FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect); 
 		void SaveSurfaceImageToFile();

    protected: 
        void CreateDeviceIndependentResources(); 
        void CreateDeviceResources(); 

	private:
		void SaveBitmapToStream(
			_In_ ComPtr<IWICBitmap> wicBitmap,
			_In_ ComPtr<IWICImagingFactory2> wicFactory2,
			_In_ REFGUID wicFormat,
			_In_ IStream* stream
			);

        Microsoft::WRL::ComPtr<ISurfaceImageSourceNative>   m_sisNative; 
 
        // Direct3D device 
        Microsoft::WRL::ComPtr<ID3D11Device>                m_d3dDevice; 
 
        // Direct2D objects 
        Microsoft::WRL::ComPtr<ID2D1Device>                 m_d2dDevice; 
        Microsoft::WRL::ComPtr<ID2D1DeviceContext>          m_d2dContext; 

		ComPtr<ID2D1Factory1>								m_d2dFactory;
 		ComPtr<IWICImagingFactory2>							m_wicFactory;		
		ComPtr<IWICBitmap>                                  m_wicBitmap;
		ComPtr<ID2D1RenderTarget>							m_wicBitmapRenderTarget;
		ComPtr<ID2D1Bitmap1>								m_d2dBitmap;
        UINT                                                m_width; 
        UINT                                                m_height; 
    }; 
}


