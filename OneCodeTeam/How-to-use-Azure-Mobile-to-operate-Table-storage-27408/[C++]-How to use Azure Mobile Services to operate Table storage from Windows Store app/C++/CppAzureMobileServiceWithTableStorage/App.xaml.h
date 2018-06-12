//
// App.xaml.h
// Declaration of the App class.
//

#pragma once

#include "App.g.h"

namespace CppAzureMobileServiceWithTableStorage
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	ref class App sealed
	{
	public:
		App();
		virtual void OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ args) override;
		static property Microsoft::WindowsAzure::MobileServices::MobileServiceClient^ MobileClient
		{
			Microsoft::WindowsAzure::MobileServices::MobileServiceClient^ get()
			{
				return client;
			}			
		}
	private:
		void OnSuspending(Platform::Object^ sender, Windows::ApplicationModel::SuspendingEventArgs^ e);
		static Microsoft::WindowsAzure::MobileServices::MobileServiceClient^ client;
	};
}
