/****************************** Module Header ******************************\
* Module Name:	TransitionBase.cpp
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

#include "StdAfx.h"
#include "TransitionBase.h"


TransitionBase::TransitionBase(void) :
	m_transitionDuration(0),
	m_foregroundFrame(nullptr),
	m_backgroundFrame(nullptr),
	m_outputFrame(nullptr),
	m_frameSize(0),
	m_frameWidth(0),
	m_frameHeight(0)
{
}

TransitionBase::TransitionBase(TransitionBase&& other)
{
	this->m_backgroundFrame = other.m_backgroundFrame;
	this->m_foregroundFrame = other.m_foregroundFrame;
	this->m_frameHeight = other.m_frameHeight;
	this->m_frameWidth = other.m_frameWidth;
	this->m_frameSize = other.m_frameSize;
	this->m_outputFrame = other.m_outputFrame;
	this->m_transitionDuration = other.m_transitionDuration;
}

TransitionBase::~TransitionBase(void)
{
}
