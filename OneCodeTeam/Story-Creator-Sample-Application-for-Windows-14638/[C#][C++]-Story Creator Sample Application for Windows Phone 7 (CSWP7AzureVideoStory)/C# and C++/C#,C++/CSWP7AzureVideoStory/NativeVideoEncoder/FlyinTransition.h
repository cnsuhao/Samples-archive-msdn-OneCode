/****************************** Module Header ******************************\
* Module Name:	FlyinTransition.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* Implements a simple fly in transition.
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
#include "string"

using namespace std;

enum FlyDirection
{
	Left,
	Right,
	Up,
	Down
};

class FlyinTransition :
	public TransitionBase
{
public:
	FlyinTransition(void);
	~FlyinTransition(void);

	BYTE* GetOutputFrame(float time);
	void ParseXml(XmlParser* pParser);

	FlyDirection GetDirection()
	{
		return this->m_direction;
	}

	void SetDirection(FlyDirection value)
	{
		this->m_direction = value;
	}

private:
	FlyDirection m_direction;
};
