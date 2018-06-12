/****************************** Module Header ******************************\
* Module Name:	VideoEncoder.cpp
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* The main class that encodes the video.
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
#include "StdAfx.h"
#include "VideoEncoder.h"
#include "XmlParser.h"
#include "ErrorCodes.h"

VideoEncoder::VideoEncoder(void) :
	m_pIWICFactory(nullptr),
	m_COMInitializedInDll(false),
	m_inputFile(L""),
	m_outputFile(L""),
	m_outputVideoFormat(MFVideoFormat_H264),
	m_frameWidth(800),
	m_frameHeight(600),
	m_videoBitRate(1500000),
	m_fps(30),
	m_pSinkWriter(nullptr)
{
	this->m_photos = list<Photo*>();
	this->m_frameStride = this->m_frameWidth * 4;
	this->m_frameBufferSize = this->m_frameStride * this->m_frameHeight;
}

VideoEncoder::~VideoEncoder(void)
{
	this->Dispose();
}

void VideoEncoder::Dispose()
{
	SafeRelease(&this->m_pIWICFactory);
	if (this->m_COMInitializedInDll)
	{
		CoUninitialize();
		this->m_COMInitializedInDll = false;
	}
	for (list<Photo*>::iterator it = this->m_photos.begin(); it != this->m_photos.end(); it++)
	{
		if (*it != nullptr)
		{
			delete *it;
			*it = nullptr;
		}
	}
	this->m_photos.clear();
	this->m_logFileStream.close();
	SafeRelease(&this->m_pSinkWriter);
}

HRESULT VideoEncoder::Encode()
{
	HRESULT hr = S_OK;
	Photo* pPhoto = nullptr;
	DWORD streamIndex = 0;
	BYTE* pCurrentBitmap = nullptr;
	BYTE* pPreviousBitmap = nullptr;
	BYTE* pFrameBuffer = nullptr;
	LONGLONG startTime = 0;
	UINT64 sampleDuration = 0;
	UINT64 transitionSampleDuration = 0;

	CheckHR(this->Initialize());
	this->m_logFileStream << "Native video encoder successfully initialized." << endl;
	CheckHR(this->ParseInputXml());
	this->m_logFileStream << "Xml configuration file successfully parsed." << endl;

	CheckHR(this->CreateSinkWriter(&this->m_pSinkWriter, &streamIndex));
	this->m_logFileStream << "Sink writer successfully created." << endl;

	// Iterate through the photo.
	for (list<Photo*>::iterator it = this->m_photos.begin(); it != this->m_photos.end(); it++)
	{
		pPhoto = *it;
		int frameSize = 0;
		// Decode the bitmap.
		CheckHR(this->DecodeFrame(pPhoto, &pCurrentBitmap, &frameSize));
		this->m_logFileStream << "Photo " << pPhoto->GetFile().c_str() << " successfully decoded." << endl;

		// Write the transition samples.
		if (pPreviousBitmap != nullptr)
		{
			transitionSampleDuration = (UINT64)(pPhoto->GetTransitionDuration() * this->m_fps);
			if (pPhoto->GetTransition() != nullptr)
			{
				pPhoto->GetTransition()->SetForegroundFrame(pPreviousBitmap);
				pPhoto->GetTransition()->SetBackgroundFrame(pCurrentBitmap);
				CheckHR(this->WriteTransitionSample(transitionSampleDuration, pPhoto->GetTransition(), streamIndex, &startTime));
				this->m_logFileStream << "Transition samples for photo " << pPhoto->GetFile().c_str() << " successfully written." << endl;
			}
		}

		// Write the photo samples.
		sampleDuration = (UINT64)(pPhoto->GetPhotoDuration() * this->m_fps);
		CheckHR(this->WritePhotoSample(sampleDuration, pCurrentBitmap, streamIndex, &startTime));
		this->m_logFileStream << "Static samples for photo " << pPhoto->GetFile().c_str() << " successfully written." << endl;

		// Release the resources associated with this photo.
		delete pPreviousBitmap;
		pPreviousBitmap = pCurrentBitmap;
	}
	hr = this->m_pSinkWriter->Finalize();
	this->m_logFileStream << "Video successfully commited." << endl;
	CheckHR(hr);
	CheckHR(MFShutdown());

cleanup:
	if (pPreviousBitmap != pCurrentBitmap && pPreviousBitmap != nullptr)
	{
		delete pPreviousBitmap;
		pPreviousBitmap = nullptr;
	}
	if (pCurrentBitmap != nullptr)
	{
		delete pCurrentBitmap;
		pCurrentBitmap = nullptr;
	}
	this->Dispose();
	return hr;
}

HRESULT VideoEncoder::Initialize()
{
	HRESULT hr = S_OK;

	this->m_logFileStream = ofstream(this->m_logFile);

	if (this->m_inputFile == L"")
	{
		this->m_logFileStream << "The input story configuration file is invalid." << endl;
		return ERROR_FILE_INVALID;
	}

	// Initialize COM.
	hr = CoInitializeEx(nullptr, COINIT_MULTITHREADED);

	// COM has not be initialized by the calling code. So we initialized it.
	if (SUCCEEDED(hr))
	{
		this->m_logFileStream << "COM initialized successfully." << endl;
		this->m_COMInitializedInDll = true;
	}

	// COM already initialized by the calling code.
	else if (hr == RPC_E_CHANGED_MODE || hr == S_FALSE)
	{
		this->m_COMInitializedInDll = false;
	}

	// COM initialization failed.
	else
	{
		return hr;
	}

	// Create WIC factory
	CheckHR(CoCreateInstance(
		CLSID_WICImagingFactory,
		nullptr,
		CLSCTX_INPROC_SERVER,
		IID_PPV_ARGS(&this->m_pIWICFactory)
		));

	// Start Media Foundation.
	CheckHR(MFStartup(MF_VERSION));
		
cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
	}
	return hr;
}

// Create the sink writer. Also returns the stream index.
HRESULT VideoEncoder::CreateSinkWriter(IMFSinkWriter** ppSinkWriter, DWORD* pStreamIndex)
{
	HRESULT hr = S_OK;
	if (this->m_outputFile == L"")
	{
		return ERROR_FILE_INVALID;
	}

	// Create the sink writer.
	*ppSinkWriter = nullptr;	
	IMFSinkWriter *pSinkWriter = nullptr;
	IMFMediaType* pOutputMediaType = nullptr;
	IMFMediaType *pInMediaType = nullptr;   
	CheckHR(MFCreateSinkWriterFromURL(this->m_outputFile.c_str(), nullptr, nullptr, &pSinkWriter));

	// Create and configure the output media type.
	CheckHR(MFCreateMediaType(&pOutputMediaType));
	CheckHR(pOutputMediaType->SetGUID(MF_MT_MAJOR_TYPE, MFMediaType_Video));
	CheckHR(pOutputMediaType->SetGUID(MF_MT_SUBTYPE, this->m_outputVideoFormat));
	CheckHR(pOutputMediaType->SetUINT32(MF_MT_AVG_BITRATE, this->m_videoBitRate));
	CheckHR(pOutputMediaType->SetUINT32(MF_MT_INTERLACE_MODE, MFVideoInterlace_Progressive));

	CheckHR(MFSetAttributeSize(pOutputMediaType, MF_MT_FRAME_SIZE, this->m_frameWidth, this->m_frameHeight));
	CheckHR(MFSetAttributeRatio(pOutputMediaType, MF_MT_FRAME_RATE, (UINT32)this->m_fps, 1));
	CheckHR(MFSetAttributeRatio(pOutputMediaType, MF_MT_PIXEL_ASPECT_RATIO, 1, 1));
	DWORD streamIndex;
	CheckHR(pSinkWriter->AddStream(pOutputMediaType, &streamIndex));

	// Set the input media type.
    CheckHR(MFCreateMediaType(&pInMediaType));   
    CheckHR(pInMediaType->SetGUID(MF_MT_MAJOR_TYPE, MFMediaType_Video));   
    CheckHR(pInMediaType->SetGUID(MF_MT_SUBTYPE, MFVideoFormat_RGB32));     
    CheckHR(pInMediaType->SetUINT32(MF_MT_INTERLACE_MODE, MFVideoInterlace_Progressive)); 

	// Input stride information is not required for all output codec. But some codecs, such as H.264, requires it.
	// If stride is ommitted or is set to a negative value, H.264 will process the image from bottom to up.
	CheckHR(pInMediaType->SetUINT32(MF_MT_DEFAULT_STRIDE, this->m_frameStride));
    CheckHR(MFSetAttributeSize(pInMediaType, MF_MT_FRAME_SIZE, this->m_frameWidth, this->m_frameHeight));
    CheckHR(MFSetAttributeRatio(pInMediaType, MF_MT_FRAME_RATE, (UINT32)this->m_fps, 1));   
    CheckHR(MFSetAttributeRatio(pInMediaType, MF_MT_PIXEL_ASPECT_RATIO, 1, 1));
    CheckHR(pSinkWriter->SetInputMediaType(streamIndex, pInMediaType, nullptr));   

	// Start to write.
	CheckHR(pSinkWriter->BeginWriting());

	*ppSinkWriter = pSinkWriter;
	(*ppSinkWriter)->AddRef();
	*pStreamIndex = streamIndex;

cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
	}
	SafeRelease(&pSinkWriter);
	SafeRelease(&pOutputMediaType);
	return hr;
}

// Parse the input xml file.
// TODO: Currently we do perform type checking.
// Need to do that in a future version.
HRESULT VideoEncoder::ParseInputXml()
{
	HRESULT hr = S_OK;
	wstring photoCountString = wstring();
	int photoCount = 0;
	XmlParser* pXmlParser;

	CheckHR(XmlParser::Create(&pXmlParser, this->m_inputFile));
	CheckHR(pXmlParser->ReadDeclaration());
	CheckHR(pXmlParser->ReadStartElement());
	photoCountString = pXmlParser->GetAttributes()[L"PhotoCount"];
	photoCount = _wtoi(photoCountString.c_str());
	for (int i = 0; i < photoCount; i++)
	{
		CheckHR(pXmlParser->ReadStartElement());
		Photo* photo = new Photo();
		photo->SetFile(pXmlParser->GetAttributes()[L"Name"]);
		photo->SetPhotoDuration(_wtoi(pXmlParser->GetAttributes()[L"PhotoDuration"].c_str()));

		// Check if the photo contains no transition. First try to read the end element of photo.
		HRESULT hrTemp = pXmlParser->ReadEndElement();

		// E_NOTENDELEMENT means we can't read end element because there's a child element (transition element).
		// So let's parse the transition element.
		// Otherwise the end element of the photo has been successfully read.
		if (hrTemp == E_NOTENDELEMENT)
		{
			CheckHR(pXmlParser->ReadStartElement());
			wstring transitionName = pXmlParser->GetAttributes()[L"Name"];
			photo->SetTransitionName(transitionName);
			photo->SetTransitionDuration(_wtoi(pXmlParser->GetAttributes()[L"Duration"].c_str()));
			TransitionBase* pTransition = nullptr;
			TransitionFactory::CreateTransition(
				transitionName,
				&pTransition,
				this->m_frameWidth,
				this->m_frameHeight);
			if (pTransition != nullptr)
			{
				pTransition->SetFrameWidth(this->m_frameWidth);
				pTransition->SetFrameHeight(this->m_frameHeight);
				pTransition->ParseXml(pXmlParser);
				photo->SetTransition(pTransition);
			}

			// End the transition element.
			CheckHR(pXmlParser->ReadEndElement());

			// End the photo element.
			CheckHR(pXmlParser->ReadEndElement());
		}
		this->m_photos.push_back(photo);
	}

cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
	}
	if (pXmlParser != nullptr)
    {
        delete pXmlParser;
        pXmlParser = nullptr;
    }
	return hr;
}

// Decode the underlying bitmap file of the photo.
HRESULT VideoEncoder::DecodeFrame(Photo* pPhoto, BYTE** ppOutputBitmap, int* pBitmapSize)
{
	HRESULT hr = S_OK;

	IWICBitmapDecoder *pDecoder  = nullptr;
	IWICBitmapFrameDecode *pFrame  = nullptr;
	IWICBitmap* pSourceBitmap = nullptr;
	IWICBitmapLock* pLock = nullptr;
	BYTE* pSourceBuffer = nullptr;
	BYTE* pDestinationBuffer = nullptr;
	UINT pixelWidth;
	UINT pixelHeight;
	WICRect lockRect;

	*ppOutputBitmap = nullptr;
		hr = m_pIWICFactory->CreateDecoderFromFilename(
		pPhoto->GetFile().c_str(),
		nullptr,
		GENERIC_READ,
		WICDecodeMetadataCacheOnDemand,
		&pDecoder
		);
	CheckHR(hr);
	this->m_logFileStream << "WIC decoder created successfully." << endl;
	GUID containerFormat;
	CheckHR(pDecoder->GetContainerFormat(&containerFormat));

	// We only support jpg files.
	if (containerFormat != GUID_ContainerFormatJpeg)
	{
		this->m_logFileStream << "Only jpeg files are supported." << endl;
		return E_NOTSUPPORTEDFORMAT;
	}

	// We only support jpg files. So there's only a single frame.
	CheckHR(pDecoder->GetFrame(0, &pFrame));

	// TODO: Currently we require all photos to be of the same size.
	// If the requirement changes in the future, modify the code.
	pFrame->GetSize(&pixelWidth, &pixelHeight);
	if (pixelWidth != this->m_frameWidth || pixelHeight != this->m_frameHeight)
	{
		this->m_logFileStream << "All photos must use fixed size." << endl;
		return E_IMAGESIZEINCORRECT;
	}

	// Create the source bitmap object.
	CheckHR(this->m_pIWICFactory->CreateBitmapFromSource(pFrame, WICBitmapCacheOnLoad, &pSourceBitmap));
	this->m_logFileStream << "Bitmap source successfully created." << endl;

	lockRect.X = 0;
	lockRect.Y = 0;
	lockRect.Width = pixelWidth;
	lockRect.Height = pixelHeight;
	CheckHR(pSourceBitmap->Lock(&lockRect, WICBitmapLockWrite, &pLock));
	UINT sourceBufferSize;
	CheckHR(pLock->GetDataPointer(&sourceBufferSize, &pSourceBuffer));

	// Convert the jpg BGR bitmap to RGBA format.
	UINT destinationBufferSize = sourceBufferSize / 3 * 4;
	pDestinationBuffer = new BYTE[destinationBufferSize];
	for (UINT i = 0, j = 0; i < sourceBufferSize; i+=3, j+=4)
	{
		pDestinationBuffer[j] = pSourceBuffer[i]; // R
		pDestinationBuffer[j + 1] = pSourceBuffer[i + 1]; // G
		pDestinationBuffer[j + 2] = pSourceBuffer[i + 2]; // B
		pDestinationBuffer[j + 3] = 255; // A
	}

	*ppOutputBitmap = pDestinationBuffer;
	*pBitmapSize = destinationBufferSize;

cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
		this->m_logFileStream << "HResult is: " << hr << endl;
	}
	if (pSourceBuffer != nullptr)
	{
		//delete pSourceBuffer;
	}
	SafeRelease(&pDecoder);
	SafeRelease(&pFrame);
	SafeRelease(&pSourceBitmap);
	SafeRelease(&pLock);

	return hr;
}

HRESULT VideoEncoder::WritePhotoSample(UINT64 sampleDuration, BYTE* pBitmap, DWORD streamIndex, LONGLONG* startTime)
{
	HRESULT hr = S_OK;
	IMFMediaBuffer* pMediaBuffer = nullptr;
	BYTE* pFrameBuffer = nullptr;
	IMFSample* pSample = nullptr;

	for (DWORD i = 0; i < sampleDuration; i++)
    {
		CheckHR(MFCreateMemoryBuffer(this->m_frameBufferSize, &pMediaBuffer));
		pMediaBuffer->Lock(&pFrameBuffer, nullptr, nullptr);
		CheckHR(MFCopyImage(pFrameBuffer, this->m_frameStride, pBitmap, this->m_frameStride, this->m_frameStride, this->m_frameHeight));
		CheckHR(pMediaBuffer->Unlock());
		CheckHR(pMediaBuffer->SetCurrentLength(this->m_frameBufferSize));
		CheckHR(MFCreateSample(&pSample));
		CheckHR(pSample->AddBuffer(pMediaBuffer));
		CheckHR(pSample->SetSampleTime(*startTime));
		CheckHR(pSample->SetSampleDuration(this->GetFrameDuration()));
		CheckHR(this->m_pSinkWriter->WriteSample(streamIndex, pSample));
		(*startTime) += this->GetFrameDuration();

		// Release resources for this sample.
		SafeRelease(&pMediaBuffer);
		SafeRelease(&pSample);
	}

cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
	}
	SafeRelease(&pMediaBuffer);
	SafeRelease(&pSample);
	return hr;
}

HRESULT VideoEncoder::WriteTransitionSample(UINT64 sampleDuration, TransitionBase* pTransition, DWORD streamIndex, LONGLONG* startTime)
{
	HRESULT hr = S_OK;
	IMFMediaBuffer* pMediaBuffer = nullptr;
	BYTE* pFrameBuffer = nullptr;
	IMFSample* pSample = nullptr;
	BYTE* pOutputFrame = nullptr;

	for (DWORD i = 0; i < sampleDuration; i++)
    {
		CheckHR(MFCreateMemoryBuffer(this->m_frameBufferSize, &pMediaBuffer));
		pMediaBuffer->Lock(&pFrameBuffer, nullptr, nullptr);
		float time = (float)i / (float)sampleDuration;
		pOutputFrame = pTransition->GetOutputFrame(time);
		CheckHR(MFCopyImage(pFrameBuffer, this->m_frameStride, pOutputFrame, this->m_frameStride, this->m_frameStride, this->m_frameHeight));
		CheckHR(pMediaBuffer->Unlock());
		CheckHR(pMediaBuffer->SetCurrentLength(this->m_frameBufferSize));
		CheckHR(MFCreateSample(&pSample));
		CheckHR(pSample->AddBuffer(pMediaBuffer));
		CheckHR(pSample->SetSampleTime(*startTime));
		CheckHR(pSample->SetSampleDuration(this->GetFrameDuration()));
		CheckHR(this->m_pSinkWriter->WriteSample(streamIndex, pSample));
		(*startTime) += this->GetFrameDuration();

		// Release resources for this sample.
		SafeRelease(&pMediaBuffer);
		SafeRelease(&pSample);
		if (pOutputFrame != nullptr)
		{
			delete pOutputFrame;
			pOutputFrame = nullptr;
		}
	}

cleanup:
	if (!SUCCEEDED(hr))
	{
		DWORD error = GetLastError();
		this->m_logFileStream << "Unexpected error: " << error << endl;
	}
	SafeRelease(&pMediaBuffer);
	SafeRelease(&pSample);
	if (pOutputFrame != nullptr)
	{
		delete pOutputFrame;
		pOutputFrame = nullptr;
	}
	return hr;
}