/****************************** Module Header ******************************\
* Module Name:	Photo.cpp
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* A model class representing a photo.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "StdAfx.h"
#include "Photo.h"


Photo::Photo(void)
	: m_photoDuration(0),
	m_transitionDuration(0),
	m_pTransition(nullptr)
{
}


Photo::~Photo(void)
{
	if (this->m_pTransition != nullptr)
	{
		delete this->m_pTransition;
		this->m_pTransition = nullptr;
	}
}
