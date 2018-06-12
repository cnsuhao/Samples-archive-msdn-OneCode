/****************************** Module Header ******************************\
* Module Name:    DirectXSample.h
* Project:        MyImageSourceWinRT
* Copyright (c) Microsoft Corporation
*
* Helper functions
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
 
#include "pch.h" 
 
namespace DX 
{ 
    inline void ThrowIfFailed(HRESULT hr) 
    { 
        if (FAILED(hr)) 
        {             
            throw Platform::Exception::CreateException(hr); 
        } 
    } 
 
    inline D2D1_COLOR_F ConvertToColorF(Windows::UI::Color color) 
    { 
        return D2D1::ColorF(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);             
    } 
 
    inline D2D1_RECT_F ConvertToRectF(Windows::Foundation::Rect source) 
    { 
        return D2D1::RectF(source.Left, source.Top, source.Right, source.Bottom); 
    } 
}