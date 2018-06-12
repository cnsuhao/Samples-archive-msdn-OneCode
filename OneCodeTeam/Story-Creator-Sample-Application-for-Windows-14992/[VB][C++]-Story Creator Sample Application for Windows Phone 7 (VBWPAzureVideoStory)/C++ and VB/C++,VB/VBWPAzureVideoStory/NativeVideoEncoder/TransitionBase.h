/****************************** Module Header ******************************\
* Module Name:	TransitionBase.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* A base class that provides some default implementation.
* A transition class must inherite this base class.
* Most code interacts with this base class rather a concrete transition class.
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
#include "XmlParser.h"

class TransitionBase
{
public:
	TransitionBase(void);
	TransitionBase(TransitionBase&& other);
	~TransitionBase(void);

	int GetTransitionDuration()
	{
		return this->m_transitionDuration;
	}

	void SetTransitionDuration(int value)
	{
		this->m_transitionDuration = value;
	}

	BYTE* GetForegroundFrame()
	{
		return this->m_foregroundFrame;
	}

	void SetForegroundFrame(BYTE* value)
	{
		this->m_foregroundFrame = value;
	}

	BYTE* GetBackgroundFrame()
	{
		return this->m_backgroundFrame;
	}

	void SetBackgroundFrame(BYTE* value)
	{
		this->m_backgroundFrame = value;
	}

	int GetFrameSize()
	{
		if (this->m_frameSize == 0)
		{
			this->m_frameSize = this->m_frameWidth * this->m_frameHeight * 4;
		}
		return this->m_frameSize;
	}

	int GetFrameWidth()
	{
		return this->m_frameWidth;
	}

	void SetFrameWidth(int value)
	{
		this->m_frameWidth = value;
	}

	int GetFrameHeight()
	{
		return this->m_frameHeight;
	}

	void SetFrameHeight(int value)
	{
		this->m_frameHeight = value;
	}

	virtual BYTE* GetOutputFrame(float time) = 0;

	virtual void ParseXml(XmlParser* pParser)
	{
	}

protected:
	int m_transitionDuration;
	BYTE* m_foregroundFrame;
	BYTE* m_backgroundFrame;
	BYTE* m_outputFrame;
	int m_frameWidth;
	int m_frameHeight;

private:
	int m_frameSize;
};

