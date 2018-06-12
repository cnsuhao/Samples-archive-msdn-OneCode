/****************************** Module Header ******************************\
 * Module Name:  D2DWrapper.h
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

#pragma once

#include "DirectXSample.h"
#include "FontEnumerator.h"
using namespace Microsoft::WRL;
using namespace Windows::UI;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;

namespace WatermarkComponent
{
	/// <summary>
	/// The font weight enumeration describes common values for degree of blackness or thickness of strokes of characters in a font.
	/// Font weight values less than 1 or greater than 999 are considered to be invalid, and they are rejected by font API functions.
	/// </summary>
	public enum class FONT_WEIGHT_ENUM
	{
		/// <summary>
		/// Predefined font weight : Thin (100).
		/// </summary>
		THIN = 100,

		/// <summary>
		/// Predefined font weight : Extra-light (200).
		/// </summary>
		EXTRA_LIGHT = 200,

		/// <summary>
		/// Predefined font weight : Light (300).
		/// </summary>
		LIGHT = 300,

		/// <summary>
		/// Predefined font weight : Semi-light (350).
		/// </summary>
		SEMI_LIGHT = 350,

		/// <summary>
		/// Predefined font weight : Normal (400).
		/// </summary>
		NORMAL = 400,

		/// <summary>
		/// Predefined font weight : Medium (500).
		/// </summary>
		MEDIUM = 500,

		/// <summary>
		/// Predefined font weight : Demi-bold (600).
		/// </summary>
		DEMI_BOLD = 600,

		/// <summary>
		/// Predefined font weight : Bold (700).
		/// </summary>
		BOLD = 700,

		/// <summary>
		/// Predefined font weight : Extra-bold (800).
		/// </summary>
		EXTRA_BOLD = 800,

		/// <summary>
		/// Predefined font weight : Black (900).
		/// </summary>
		BLACK = 900,

		/// <summary>
		/// Predefined font weight : Extra-black (950).
		/// </summary>
		EXTRA_BLACK = 950,
	};

	/// <summary>
	/// The font style enumeration describes the slope style of a font face, such as Normal, Italic or Oblique.
	/// Values other than the ones defined in the enumeration are considered to be invalid, and they are rejected by font API functions.
	/// </summary>
	public enum class  FONT_STYLE_ENUM
	{
		/// <summary>
		/// Font slope style : Normal.
		/// </summary>
		NORMAL,

		/// <summary>
		/// Font slope style : Oblique.
		/// </summary>
		OBLIQUE,

		/// <summary>
		/// Font slope style : Italic.
		/// </summary>
		ITALIC

	};

	// Helper class that initializes DirectX APIs for 2D rendering.
	public ref class D2DWrapper sealed
	{
	public:
		D2DWrapper();
		void Initialize();
		void SetBitmapRenderTarget(IRandomAccessStream^  backgroundImageStream);
		void BeginDraw();
		IRandomAccessStream^ EndDraw(bool needPreview);
		void DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName,Color foregroundColor, 
			float fontSize, FONT_STYLE_ENUM fontStyle, FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName);
		void DrawImage(IRandomAccessStream^ watermarkImageStream, Point startPoint, float opacity);
		void SaveBitmapToFile();
		Platform::Array<Platform::String^>^ GetSystemFont();

	protected:
		void CreateDeviceIndependentResources();
		void CreateDeviceResources();

	private:
		void SaveBitmapToStream(
			_In_ ComPtr<ID2D1Bitmap1> d2dBitmap,
			_In_ ComPtr<IWICImagingFactory2> wicFactory2,
			_In_ ComPtr<ID2D1DeviceContext> d2dContext,
			_In_ REFGUID wicFormat,
			_In_ IStream* stream);

	private:
			ComPtr<ID2D1Factory1>					 m_d2dFactory;
			ComPtr<ID2D1Device>						 m_d2dDevice;
			ComPtr<ID2D1DeviceContext>				 m_d2dContext;
			D3D_FEATURE_LEVEL						 m_featureLevel;
			ComPtr<IWICImagingFactory2>				 m_wicFactory;
			ComPtr<IDWriteFactory1>					 m_dwriteFactory;

			ComPtr<IWICFormatConverter>				 m_backgroundBitmapConverter;
			ComPtr<IWICFormatConverter>				 m_watermarkImageConverter;

			ComPtr<ID2D1SolidColorBrush>			 m_textBrush;
			ComPtr<IDWriteTextFormat>				 m_textFormat;

			ComPtr<ID2D1Bitmap1>					 m_targetBitmap;
			ComPtr<ID2D1Bitmap1>					 m_watermarkBitmap;

			D2D1_SIZE_F								 m_renderTargetSize;

			FontEnumerator^							 m_fontEnumerator; 	
	};
}