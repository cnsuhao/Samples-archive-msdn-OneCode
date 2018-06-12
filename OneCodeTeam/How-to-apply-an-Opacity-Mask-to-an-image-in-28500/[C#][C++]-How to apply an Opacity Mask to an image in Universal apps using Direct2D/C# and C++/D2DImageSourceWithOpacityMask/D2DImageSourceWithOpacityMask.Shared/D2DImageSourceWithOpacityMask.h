/****************************** Module Header ******************************\
* Module Name:  D2DImageSourceWithOpacityMask.h
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

#pragma once

#include "pch.h"

#include "Wincodec.h"

namespace D2DImageSourceWithOpacityMask
{
	public ref class D2DImageSource sealed : Windows::UI::Xaml::Media::Imaging::SurfaceImageSource
	{
	public:
		D2DImageSource(int pixelWidth, int pixelHeight, bool isOpaque);

		void BeginDraw(Windows::Foundation::Rect updateRect);
		void BeginDraw()    { BeginDraw(Windows::Foundation::Rect(0, 0, (float)m_width, (float)m_height)); }
		void EndDraw();

		void SetSource(Windows::Storage::Streams::IRandomAccessStream^ randomAccessStream);
		void SetMask(Windows::Storage::Streams::IRandomAccessStream^ randomAccessStream);
		void RenderBitmap();
		void Clear(Windows::UI::Color color);

	private protected:
		void OnSuspending(Platform::Object ^sender, Windows::ApplicationModel::SuspendingEventArgs ^e);
		void CreateDeviceResources();

		// Direct3D device
		Microsoft::WRL::ComPtr<ID3D11Device>                m_d3dDevice;

		// Direct2D objects
		Microsoft::WRL::ComPtr<ID2D1Device>                 m_d2dDevice;
		Microsoft::WRL::ComPtr<ID2D1DeviceContext>          m_d2dContext;

		int                                                 m_width;
		int                                                 m_height;

		// Source Bitmap
		Microsoft::WRL::ComPtr<ID2D1Bitmap1>				m_Bitmap;

		// Opacity Mask
		Microsoft::WRL::ComPtr<ID2D1Bitmap1>				m_Mask;

		// WIC components
		Microsoft::WRL::ComPtr<IWICImagingFactory2>			m_wicFactory;
	};
}
