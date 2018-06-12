/***************************** Module Header ******************************\
* Module Name:	MainWindow.xaml.cpp
* Project:		CppAzureMobileServiceWithTableStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use table storage with windows Azure mobile service.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

#include "pch.h"
#include "MainPage.xaml.h"
#include <ppltasks.h>
using namespace CppAzureMobileServiceWithTableStorage;
using namespace concurrency;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Data::Json;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

MainPage::MainPage()
{
	InitializeComponent();
	messages = ref new Vector<ShortMessage^>();
	table = App::MobileClient->GetTable("ShortMessage");
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	(void) e;	// Unused parameter
	RefreshData();
}


void CppAzureMobileServiceWithTableStorage::MainPage::btnSave_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if(tbName->Text->IsEmpty() || tbMessage->Text->IsEmpty())
	{
		lbState->Text = "Name or Message can't be empty.";
	}
	else
	{
		auto message = ref new ShortMessage();
		message->Name = tbName->Text;
		message->Message = tbMessage->Text;

		InsertNewMessage(message);
	}
}


void CppAzureMobileServiceWithTableStorage::MainPage::appbtnDelete_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto message = dynamic_cast<ShortMessage^> (lvwNewMessages->SelectedItem);
	if(message != nullptr)
	{
		DeleteNewMessage(message, lvwNewMessages->SelectedIndex);
	}
}


void CppAzureMobileServiceWithTableStorage::MainPage::appbtnUpdate_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto message = dynamic_cast<ShortMessage^> (lvwNewMessages->SelectedItem);
	if(message != nullptr)
	{
		UpdateNewMessage(message, lvwNewMessages->SelectedIndex);
	}
}

void CppAzureMobileServiceWithTableStorage::MainPage::InsertNewMessage(ShortMessage^ message)
{
	// Insert a new message item to table storage.
	auto jsonObject = ref new JsonObject();
	jsonObject->Insert(L"Name", JsonValue::CreateStringValue(message->Name));
	jsonObject->Insert(L"Message", JsonValue::CreateStringValue(message->Message));
		
	create_task(table->InsertAsync(jsonObject)).then([this, message](task<IJsonValue^> task)
	{
		try
		{
			auto result = task.get()->Stringify();
			JsonObject^ obj = ref new JsonObject();
			if(JsonObject::TryParse(result, &obj))
			{
				message->PartitionKey = obj->GetNamedString("PartitionKey");
				message->RowKey =  obj->GetNamedNumber("RowKey");
				message->IsRead = obj->GetNamedBoolean("IsRead");
			}
			
			messages->Append(message);

			lbState->Text = "New message has been left.";
			tbMessage->Text = "";
			tbName->Text = "";
			lvwNewMessages->ItemsSource = messages;
		}
		catch(Exception^ ex)
		{
			lbState->Text = ex->Message;
		}
	});
}

void CppAzureMobileServiceWithTableStorage::MainPage::DeleteNewMessage(ShortMessage^ message, int index)
{
	JsonObject^ obj = ref new JsonObject();
	obj->Insert(L"id", JsonValue::CreateNumberValue(message->RowKey));

	create_task( table->DeleteAsync(obj)).then([=](task<void> t)
	{
		try
		{
			t.get();
			messages->RemoveAt(index);
			lbState->Text = "One item has been deleted.";
		}
		catch(Exception^ ex)
		{
			lbState->Text = ex->Message;
		}
	});
}

void CppAzureMobileServiceWithTableStorage::MainPage::UpdateNewMessage(ShortMessage^ message, int index)
{
	auto jsonObject = ref new JsonObject();

	// id is a trivial value.
	jsonObject->Insert(L"id", JsonValue::CreateNumberValue(message->RowKey));
	jsonObject->Insert(L"PartitionKey", JsonValue::CreateStringValue(message->PartitionKey));
	jsonObject->Insert(L"RowKey", JsonValue::CreateNumberValue(message->RowKey));
	jsonObject->Insert(L"Name", JsonValue::CreateStringValue(message->Name));
	jsonObject->Insert(L"Message", JsonValue::CreateStringValue(message->Name));
	jsonObject->Insert(L"IsRead", JsonValue::CreateStringValue("true"));

	create_task(table->UpdateAsync(jsonObject)).then([=] (task<IJsonValue^> task)
	{
		try
		{
			task.get();
			messages->RemoveAt(index);
		}
		catch(Exception^ ex)
		{
			lbState->Text = ex->Message;
		}
	});
}


void CppAzureMobileServiceWithTableStorage::MainPage::RefreshData()
{
	String^ query = "Select * from ShortMessage";

	create_task(table->ReadAsync(query)).then([this](task<IJsonValue^> task)
	{
		try
		{
			auto V = task.get();
			auto list = V->Stringify();
			JsonArray^ mapValue = ref new JsonArray();
			if(JsonArray::TryParse(list, &mapValue))
			{
				auto vec = mapValue->GetView();

				std::for_each(begin(vec), end(vec), [this](IJsonValue^ M)
				{
					ShortMessage^ message = ref new ShortMessage();
					auto obj = M->GetObject();

					message->PartitionKey = obj->GetNamedString("PartitionKey");
					message->RowKey = _wtoi64(obj->GetNamedString("RowKey")->Data());
					message->Name = obj->GetNamedString("Name");
					message->Message = obj->GetNamedString("Message");
					message->IsRead = obj->GetNamedString("IsRead") == "false" ? false : true;

					messages->Append(message);						
				});
				lvwNewMessages->ItemsSource = messages;
			}
		}
		catch(Exception^ ex)
		{
			lbState->Text = ex->Message;
		}
	});	
}