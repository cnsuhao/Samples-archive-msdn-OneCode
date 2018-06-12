/****************************** Module Header ******************************\
* Module Name:	XmlParser.cpp
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* A simple XML parser. Advanced features (such as namespaces and schema validation) are not supported.
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
#include "XmlParser.h"
#include "codecvt" 
#include "cstdlib"
#include "locale" 
#include "fstream"
#include "ErrorCodes.h"

using namespace std;

XmlParser::XmlParser() :
	m_fileContent(nullptr),
	m_fileSize(0),
	m_currentChar(1),
	m_currentElementName(),
	m_isSelfCloseTag(false)
{
	this->m_attributes = map<wstring, wstring>();
}

XmlParser::~XmlParser(void)
{
	if (this->m_fileContent != nullptr)
	{
		delete this->m_fileContent;
	}
	this->m_attributes.clear();
}

// Create the XmlParser, and read the source file.
// We perform 2 I/O on the file.
// First, use Win32 API to obtain the file length, so we can allocate the buffer.
// Second, use C++ STL to read the file.
// Using Win32 API helps us to obtain file attributes,
// while STL helps us to convert the UTF-8 file to wide chars.
// The performance hit is minimum,
// as the Win32 API simply fetches file attributes without reading the file content.
HRESULT XmlParser::Create(XmlParser** parser, wstring fileName)
{
	HRESULT hr = S_OK;

	*parser = new XmlParser();

	// Open the file.
	HANDLE hFileHandle = CreateFile(
		fileName.c_str(),
		GENERIC_READ,
		FILE_SHARE_READ,
		nullptr,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		nullptr);

	if (hFileHandle == INVALID_HANDLE_VALUE)
	{
		return ERROR_FILE_INVALID;
	}

	// Get the file size.
	(*parser)->m_fileSize = GetFileSize(hFileHandle, nullptr);
	if ((*parser)->m_fileSize == INVALID_FILE_SIZE)
	{
		return INVALID_FILE_SIZE;
	}

	// Close the file. We'll use C++ STL to read it.
	CloseHandle(hFileHandle);

	(*parser)->m_fileContent = new wchar_t[(*parser)->m_fileSize];
	for (int i = 0; i < (*parser)->m_fileSize; i++)
	{
		(*parser)->m_fileContent[i] = 0;
	}
	
	// Open the file again using STL.
	wifstream fileStream;
	fileStream.open(fileName);

	// Convert the UTF-8 stream to wide string.
	codecvt_utf8<wchar_t>* converter = new codecvt_utf8<wchar_t>(); 
	const locale empty_locale = locale::empty(); 
	const locale utf8_locale = locale(empty_locale, converter);
	fileStream.imbue(utf8_locale);

	// Read the file content.
	fileStream.read((*parser)->m_fileContent, (*parser)->m_fileSize);

	fileStream.close();
	return hr;
}

// Read the xml declaration.
// <?xml version="1.0" encoding="utf-8"?>
// In this version, we simply skip the character.
HRESULT XmlParser::ReadDeclaration()
{
	if (this->m_fileContent == nullptr)
	{
		return ERROR_FILE_INVALID;
	}

	// In this version, we don't do much error checking.
	// So simply move the character to the first '>'.
	while (this->m_fileContent[this->m_currentChar] != '>')
	{
		this->m_currentChar++;
	}
	return S_OK;
}

// Read the current node and advances the reader to the next node.
HRESULT XmlParser::ReadStartElement()
{
	if (this->m_fileContent == nullptr)
	{
		return ERROR_FILE_INVALID;
	}

	this->SaveState();

	// Skip until we encounter a start element.
	while (this->m_fileContent[this->m_currentChar] != '<')
	{
		this->m_currentChar++;
	}

	// We need to skip '<', so we can begin with the element name.
	this->m_currentChar++;
	
	// We encounter an end element, so we can't read the start element.
	if (this->m_fileContent[this->m_currentChar] == '/')
	{
		this->RollbackState();
		return E_NOTSTARTELEMENT;
	}

	bool spaceFound = false;
	wstring attributeName = L"";
	wstring attributeValue = L"";
	bool quoteFound = false;

	while (this->m_fileContent[this->m_currentChar] != '>')
	{
		// No space found yet.
		if (!spaceFound)
		{
			// The first space, indicates the element name ends here.
			if (this->m_fileContent[this->m_currentChar] == ' ')
			{
				spaceFound = true;
			}
			else
			{
				this->m_currentElementName.append(1, this->m_fileContent[this->m_currentChar]);
			}
		}
		// Now go on to attributes. We assume the xml file is well formatted,
		// so a space indicates at least one attribute must follow.
		else
		{			
			if (this->m_fileContent[this->m_currentChar] == '\"')
			{
				// Starting of the attribute value.
				if (!quoteFound)
				{
					quoteFound = true;
				}
				// End of attribute value. Insert the pair to the attributes map, and reset the variables.
				else
				{
					// TODO: C++ map automatically sorts items by key.
					// Currently we do not need to maintain the original order of attributes.
					// In the future, if the order matters, we may have to use pair instead of map,
					// which may be a bit slower due to no binary search support.
					this->m_attributes[attributeName] = attributeValue;
					attributeName.clear();
					attributeValue.clear();
					quoteFound = false;
				}
			}
			else
			{
				// Still reading attribute name.
				if (!quoteFound)
				{
					// We assume the xml is well formated, so the element name won't contain '=' or ' '.
					// The only '=' comes before '"', which we should skip.
					// ' ' may be encountered after an attribute is parsed, and we begin a new attribute.
					// In which case we should skip.
					if (this->m_fileContent[this->m_currentChar] != '='
						&& this->m_fileContent[this->m_currentChar] != ' ')
					{
						attributeName.append(1, this->m_fileContent[this->m_currentChar]);
					}
				}
				// Reading attribute value.
				else
				{
					attributeValue.append(1, this->m_fileContent[this->m_currentChar]);
				}
			}
		}

		this->m_currentChar++;

		// Not a valid xml file.
		// While we assume the xml file is valid, we can still do some simple check.
		if (this->m_currentChar > this->m_fileSize)
		{
			return E_UNEXPECTED;
		}
	}

	// Check if the tag is self closed.
	if (this->m_fileContent[this->m_currentChar - 1] == '/')
	{
		this->m_isSelfCloseTag = true;
	}

	// The while loop didn't read '>'. So read it now.
	this->m_currentChar++;
	return S_OK;
}

// Read the end element.
// Since we assume the xml file is valid, we can simply advance the pointer to '>'.
HRESULT XmlParser::ReadEndElement(void)
{
	if (this->m_fileContent == nullptr)
	{
		return ERROR_FILE_INVALID;
	}

	// The element is self closed, so return immediately.
	if (this->m_isSelfCloseTag)
	{
		this->m_isSelfCloseTag = false;
		return S_OK;
	}

	this->SaveState();

	while (this->m_fileContent[this->m_currentChar] != '>')
	{
		if (this->m_fileContent[this->m_currentChar] == '<')
		{
			// Encounter another start element, so we cannot read end element at the moment.
			if (this->m_fileContent[this->m_currentChar + 1] != '/')
			{
				this->RollbackState();
				return E_NOTENDELEMENT;
			}
		}

		this->m_currentChar++;
		
		// Not a valid xml file.
		// While we assume the xml file is valid, we can still do some simple check.
		if (this->m_currentChar > this->m_fileSize)
		{
			return E_UNEXPECTED;
		}
	}

	// Advance the pointer to pass '>'.
	this->m_currentChar++;
	return S_OK;
}

// Save the current state, so if something goes wrong, we can rollback.
// TODO: Copy all attributes may be time consuming.
// For the current version, we only have a few attributes on each element,
// so it should be generally fine.
// But in the future, consider to check conditions where we don't have to copy all attributes.
void XmlParser::SaveState()
{
	this->m_parserState.currentChar = this->m_currentChar;
	this->m_parserState.attributes = map<wstring, wstring>(this->m_attributes);
	this->m_attributes.clear();
	this->m_parserState.currentElementName = this->m_currentElementName;
	this->m_currentElementName.clear();
	this->m_parserState.isSelfCloseTag = this->m_isSelfCloseTag;
	this->m_isSelfCloseTag = false;
}

// Rollback the previous state.
void XmlParser::RollbackState()
{
	this->m_currentChar = this->m_parserState.currentChar;
	this->m_attributes = map<wstring, wstring>(this->m_parserState.attributes);
	this->m_currentElementName = this->m_parserState.currentElementName;
	this->m_isSelfCloseTag = this->m_parserState.isSelfCloseTag;
}