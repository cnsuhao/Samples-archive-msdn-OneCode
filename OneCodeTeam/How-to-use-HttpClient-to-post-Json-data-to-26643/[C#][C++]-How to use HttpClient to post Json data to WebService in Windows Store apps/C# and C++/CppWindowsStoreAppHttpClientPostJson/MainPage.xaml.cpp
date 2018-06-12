/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cpp
* Project:      CppWindowsStoreAppHttpClientPostJson
* Copyright (c) Microsoft Corporation.
*
* The sample demonstrates how to use the HttpClient and JsonObject class to 
* post JSON data to a web service.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "pch.h"
#include "MainPage.xaml.h"

using namespace CppWindowsStoreAppHttpClientPostJson;

using namespace Platform;
using namespace Platform::Collections;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Web::Http;
using namespace Windows::Data::Json;
using namespace Windows::Storage::Streams;
using namespace concurrency;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

MainPage::MainPage()
{
	InitializeComponent();
	SetValue(_defaultViewModelProperty, ref new Map<String^,Object^>(std::less<String^>()));
	auto navigationHelper = ref new Common::NavigationHelper(this);
	SetValue(_navigationHelperProperty, navigationHelper);
	navigationHelper->LoadState += ref new Common::LoadStateEventHandler(this, &MainPage::LoadState);
	navigationHelper->SaveState += ref new Common::SaveStateEventHandler(this, &MainPage::SaveState);
	Window::Current->SizeChanged += ref new Windows::UI::Xaml::WindowSizeChangedEventHandler(this, &MainPage::OnSizeChanged);
}

DependencyProperty^ MainPage::_defaultViewModelProperty =
	DependencyProperty::Register("DefaultViewModel",
		TypeName(IObservableMap<String^,Object^>::typeid), TypeName(MainPage::typeid), nullptr);

/// <summary>
/// used as a trivial view model.
/// </summary>
IObservableMap<String^, Object^>^ MainPage::DefaultViewModel::get()
{
	return safe_cast<IObservableMap<String^, Object^>^>(GetValue(_defaultViewModelProperty));
}

DependencyProperty^ MainPage::_navigationHelperProperty =
	DependencyProperty::Register("NavigationHelper",
		TypeName(Common::NavigationHelper::typeid), TypeName(MainPage::typeid), nullptr);

/// <summary>
/// Gets an implementation of <see cref="NavigationHelper"/> designed to be
/// used as a trivial view model.
/// </summary>
Common::NavigationHelper^ MainPage::NavigationHelper::get()
{
	return safe_cast<Common::NavigationHelper^>(GetValue(_navigationHelperProperty));
}

#pragma region Navigation support

/// The methods provided in this section are simply used to allow
/// NavigationHelper to respond to the page's navigation methods.
/// 
/// Page specific logic should be placed in event handlers for the  
/// <see cref="NavigationHelper::LoadState"/>
/// and <see cref="NavigationHelper::SaveState"/>.
/// The navigation parameter is available in the LoadState method 
/// in addition to page state preserved during an earlier session.

void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedTo(e);
}

void MainPage::OnNavigatedFrom(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedFrom(e);
}

#pragma endregion

/// <summary>
/// Populates the page with content passed during navigation. Any saved state is also
/// provided when recreating a page from a prior session.
/// </summary>
/// <param name="sender">
/// The source of the event; typically <see cref="NavigationHelper"/>
/// </param>
/// <param name="e">Event data that provides both the navigation parameter passed to
/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
/// a dictionary of state preserved by this page during an earlier
/// session. The state will be null the first time a page is visited.</param>
void MainPage::LoadState(Object^ sender, Common::LoadStateEventArgs^ e)
{
	(void) sender;	// Unused parameter
	(void) e;	// Unused parameter
}

/// <summary>
/// Preserves state associated with this page in case the application is suspended or the
/// page is discarded from the navigation cache.  Values must conform to the serialization
/// requirements of <see cref="SuspensionManager::SessionState"/>.
/// </summary>
/// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
/// <param name="e">Event data that provides an empty dictionary to be populated with
/// serializable state.</param>
void MainPage::SaveState(Object^ sender, Common::SaveStateEventArgs^ e){
	(void) sender;	// Unused parameter
	(void) e; // Unused parameter
}

// Start to Call WCF service
void CppWindowsStoreAppHttpClientPostJson::MainPage::Start_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	m_dispatcher = Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher;

	// Clear text of Output textbox
	this->OutputField->Text = "";
	this->StatusBlock->Text = "";
	int age = _wtoi(this->Agetxt->Text->Data());
	if (age == 0)
	{
		NotifyUser("Age Must input number");
		return;
	}
	if (age>120 || age<0)
	{
		NotifyUser(L"Age must be between 0 and 120");
		return;
	}

	this->StartButton->IsEnabled = false;
	HttpClient^ httpClient =ref new HttpClient();
	Uri^ uri = ref new Uri("http://localhost:28539/WCFService.svc/GetData");
	Person^ p = ref new Person();
	p->Name = this->Nametxt->Text;
	p->Age = age;

	JsonObject^ postData =ref new JsonObject();
	postData->SetNamedValue("Name", JsonValue::CreateStringValue(p->Name));
	postData->SetNamedValue("Age",JsonValue::CreateStringValue(p->Age.ToString()));
	
	// async send "get" request to get response string form service
	IAsyncOperationWithProgress<HttpResponseMessage^, HttpProgress> ^accessSQLOp = httpClient->PostAsync(uri, ref new HttpStringContent(postData->Stringify(), UnicodeEncoding::Utf8,"application/json"));
	auto operationTask = create_task(accessSQLOp);
	operationTask.then([this](HttpResponseMessage^ response){
		if (response->StatusCode == HttpStatusCode::Ok)
		{
			try
			{

				auto asyncOperationWithProgress = response->Content->ReadAsStringAsync();
				create_task(asyncOperationWithProgress).then([this](Platform::String^ responJsonText)
				{
					result = GetJsonValue(responJsonText);
					m_dispatcher->RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal,
						ref new Windows::UI::Core::DispatchedHandler([this]()
					{
						this->OutputField->Text = result;
						this->StartButton->IsEnabled = true;
					}));
				});
			}
			catch (Exception^ ex)
			{
				NotifyUser(ex->Message);
				this->StartButton->IsEnabled = true;
			}
		}
	});
}


void CppWindowsStoreAppHttpClientPostJson::MainPage::FooterClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Uri("http://blogs.msdn.com/b/onecode"));
}

void MainPage::NotifyUser(Platform::String^ strMessage)
{
	this->StatusBlock->Text = strMessage;
}

// Handle Size change event
void CppWindowsStoreAppHttpClientPostJson::MainPage::OnSizeChanged(Platform::Object ^sender, Windows::UI::Core::WindowSizeChangedEventArgs ^e)
{
	if (e->Size.Width <= 500)
	{
		VisualStateManager::GoToState(this, "MinimalLayout", true);
	}
	else if (e->Size.Width < e->Size.Height)
	{
		VisualStateManager::GoToState(this, "PortraitLayout", true);
	}
	else
	{
		VisualStateManager::GoToState(this, "DefaultLayout", true);
	}
}

/// <summary>
/// Get Result from Json String
/// </summary>
/// <param name="jsonString">Json string which returns from WCF Service</param>
/// <returns>Result string</returns>
Platform::String^ CppWindowsStoreAppHttpClientPostJson::MainPage::GetJsonValue(Platform::String^ jsonString)
{
	std::wstring wstring = jsonString->Data();
	int ValueLength = wstring.find_last_of(L"\"") - (wstring.find(L":") + 2);
	std::wstring resultString = wstring.substr(wstring.find(L":") + 2, ValueLength);
	Platform::String^  value = ref new Platform::String(resultString.c_str());
	return value;
}