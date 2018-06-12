/***************************** Module Header ******************************\
* Module Name:	MainPage.xaml.cpp
* Project:		CppAzureBlobClassLiabaryWithWin8App
* Copyright (c) Microsoft Corporation.
* 
* Windows Azure storage class library now supports windows store app.
* This sample will show you how to operate Azure blob storage in your store app, 
* including upload/download/delete file from blob storage.
*
* MainPage.xaml.cpp
* Implementation of the MainPage class.
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
#include "Constants.h"
#include <ppltasks.h>
using namespace CppAzureBlobClassLiabaryWithWin8App;
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
using namespace Windows::Storage;
using namespace Windows::Storage::Pickers;
using namespace Windows::UI::ViewManagement;
using namespace Windows::UI::Xaml::Media::Imaging;
using namespace Microsoft::WindowsAzure::Storage::Blob;
using namespace Windows::Globalization::DateTimeFormatting;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
MainPage::MainPage()
{
	InitializeComponent();

	cred = ref new StorageCredentials(ACCOUNT_NAME, ACCOUNT_KEY);
	blobContainer = ref new CloudBlobContainer( ref new Uri("http://" + ACCOUNT_NAME + ".blob.core.windows.net/imagescontainer/"), cred);

	calendar = ref new Windows::Globalization::Calendar;
}

/// <summary>
/// Invoked when this page is about to be displayed in a Frame.
/// </summary>
/// <param name="e">Event data that describes how this page was reached.  The Parameter
/// property is typically used to configure the page.</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	(void) e;	// Unused parameter
	refreshListview();
}


void CppAzureBlobClassLiabaryWithWin8App::MainPage::btnSave_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if (EnsureUnsnapped())
    {
        FileOpenPicker^ openPicker = ref new FileOpenPicker();
        openPicker->ViewMode = PickerViewMode::Thumbnail;
        openPicker->SuggestedStartLocation = PickerLocationId::PicturesLibrary;
        openPicker->FileTypeFilter->Append(".jpg");
        openPicker->FileTypeFilter->Append(".jpeg");
        openPicker->FileTypeFilter->Append(".png");

        create_task(openPicker->PickSingleFileAsync()).then([=](StorageFile^ file)
        {
            if (file)
            {
                create_task(file->OpenSequentialReadAsync()).then([=](task<Streams::IInputStream^> task)
				{
					try
					{
						Streams::IInputStream^ fileStream = task.get();
						auto blob = blobContainer->GetBlockBlobReference(file->Name);
						auto deleteBlobTask = create_task(blob->DeleteIfExistsAsync());
						deleteBlobTask.then([=](bool bRet)
						{
							auto uploadTask = create_task(blob->UploadFromStreamAsync(fileStream));
							uploadTask.then([=](void)
							{
								calendar->SetToNow();
								lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime()) + ": Save picture '" + file->Name + " ' successfully!\n");
								refreshListview();
							});
							
						});
					}
					catch(Platform::Exception^ ex)
					{
						calendar->SetToNow();
						lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime()) + ": "+ ex->Message +"\n");
					}
				});
			}
		});
	}
}

void CppAzureBlobClassLiabaryWithWin8App::MainPage::btnDelete_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if(lvwBlobs->SelectedIndex != -1)
	{
		auto item = dynamic_cast<CloudBlockBlob^> (lvwBlobs->SelectedItem);
		if(item != nullptr)
		{
			auto blob = blobContainer->GetBlockBlobReference(item->Name);
			create_task(blob->DeleteIfExistsAsync()).then([=](bool bRet)
			{
				if(bRet)
				{
					imgBlobItem->Source = nullptr;
					calendar->SetToNow();
					lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime()) + ": " + item->Name + " has been removed from blob container successfully!\n");
				}
				else
				{
					calendar->SetToNow();
					lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime()) + ": failed to remove " + item->Name + "\n");
				}
			});
		
			refreshListview();
		}
	}
}


void CppAzureBlobClassLiabaryWithWin8App::MainPage::lvwBlobs_ItemClick(Platform::Object^ sender, Windows::UI::Xaml::Controls::ItemClickEventArgs^ e)
{
	auto item = dynamic_cast<CloudBlockBlob^> (e->ClickedItem);
	if(item != nullptr)
	{
		auto blob = blobContainer->GetBlockBlobReference(item->Name);
		ApplicationData^ appData = ApplicationData::Current;
	    StorageFolder^ 	temporaryFolder = appData->TemporaryFolder;

		create_task(temporaryFolder->CreateFileAsync(item->Name, CreationCollisionOption::ReplaceExisting)).then([=](StorageFile^ file)
		{
			create_task(file->OpenAsync(FileAccessMode::ReadWrite)).then([=](Streams::IRandomAccessStream^ fileStream)
			{
				create_task(blob->DownloadToStreamAsync(fileStream->GetOutputStreamAt(0))).then([=](void)
				{
					return fileStream->FlushAsync();
				}).then([=](bool bRet)
				{
					delete fileStream;
					imgBlobItem->Source = ref new BitmapImage(ref new Uri(file->Path));
				});
			});
		}).then([=](task<void> t)
		{
			try
			{
				t.get();
			}
			catch(Platform::Exception^ ex)
			{
				calendar->SetToNow();
				lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime())+ " " + ex->Message+ "\n");
			}
		});
	}
}

void CppAzureBlobClassLiabaryWithWin8App::MainPage::refreshListview()
{
	create_task(blobContainer->CreateIfNotExistsAsync()).then([this](bool bRet)
	{
		BlobContinuationToken^ token = nullptr;
		create_task(blobContainer->ListBlobsSegmentedAsync(token)).then([this](BlobResultSegment^ blobSegment)
		{
			lvwBlobs->ItemsSource = blobSegment->Results;
		});
	});
}

bool CppAzureBlobClassLiabaryWithWin8App::MainPage::EnsureUnsnapped()
{
    // FilePicker APIs will not work if the application is in a snapped state.
    // If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
    bool unsnapped = ((ApplicationView::Value != ApplicationViewState::Snapped) || ApplicationView::TryUnsnap());
    
	if (!unsnapped)
    {
		calendar->SetToNow();
        lbState->Text += (DateTimeFormatter::LongTime->Format(calendar->GetDateTime()) + ": Cannot unsnap the sample application\n");
    }

    return unsnapped;
}

