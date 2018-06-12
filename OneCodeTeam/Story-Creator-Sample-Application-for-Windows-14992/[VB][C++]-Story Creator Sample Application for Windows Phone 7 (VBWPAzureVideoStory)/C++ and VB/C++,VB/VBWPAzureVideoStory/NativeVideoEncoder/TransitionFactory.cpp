/****************************** Module Header ******************************\
* Module Name:	TransitionFactory.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* A base class that provides some default implementation.A factory class used to create transitions.
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
#include "TransitionFactory.h"
#include "FadeTransition.h"
#include "FlyinTransition.h"

TransitionFactory::TransitionFactory(void)
{
}


TransitionFactory::~TransitionFactory(void)
{
}

// Since C++ doesn't support reflection, we'll have to use a if block...
void TransitionFactory::CreateTransition(wstring transitionName, TransitionBase** output, int frameWidth, int frameHeight)
{
	*output = nullptr;
	if (transitionName == L"Fade Transition")
	{
		*output = new FadeTransition();
	}
	else if (transitionName == L"Fly In Transition")
	{
		*output = new FlyinTransition();
	}
	// Add more transitions in the future.

	if ((*output) != nullptr)
	{
		(*output)->SetFrameWidth(frameWidth);
		(*output)->SetFrameHeight(frameHeight);
	}
}