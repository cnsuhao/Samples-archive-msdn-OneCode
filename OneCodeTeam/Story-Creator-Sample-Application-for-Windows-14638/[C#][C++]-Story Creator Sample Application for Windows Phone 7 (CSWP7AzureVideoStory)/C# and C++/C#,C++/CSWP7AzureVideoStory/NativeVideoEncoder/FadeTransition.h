/****************************** Module Header ******************************\
* Module Name:	FadeTransition.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* Implements a simple fade transition.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#pragma once
#include "transitionbase.h"

class FadeTransition :
	public TransitionBase
{
public:
	FadeTransition(void);
	~FadeTransition(void);

	BYTE* GetOutputFrame(float time);
};

