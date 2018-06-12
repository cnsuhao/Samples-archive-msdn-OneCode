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

#pragma once
#include "string"
#include "TransitionBase.h"

using namespace std;

class TransitionFactory
{
public:
	TransitionFactory(void);
	~TransitionFactory(void);

	static void CreateTransition(wstring transitionName, TransitionBase** output, int frameWidth, int frameHeight);
};

