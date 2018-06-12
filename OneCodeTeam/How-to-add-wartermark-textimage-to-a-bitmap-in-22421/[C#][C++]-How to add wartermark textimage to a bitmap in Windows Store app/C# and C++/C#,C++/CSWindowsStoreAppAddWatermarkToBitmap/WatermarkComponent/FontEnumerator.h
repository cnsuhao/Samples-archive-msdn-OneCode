/****************************** Module Header ******************************\
 * Module Name:  FontEnumerator.h
 * Project:      WatermarkComponent
 * Copyright (c) Microsoft Corporation.
 * 
 * This file comes from DirectWrite font enumeration sample
 * See http://code.msdn.microsoft.com/windowsapps/DirectWrite-font-60e53e0b
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

namespace WatermarkComponent
{
    public ref class FontEnumerator sealed
    {
    public:
        Platform::Array<Platform::String^>^ ListSystemFonts();
    };
}