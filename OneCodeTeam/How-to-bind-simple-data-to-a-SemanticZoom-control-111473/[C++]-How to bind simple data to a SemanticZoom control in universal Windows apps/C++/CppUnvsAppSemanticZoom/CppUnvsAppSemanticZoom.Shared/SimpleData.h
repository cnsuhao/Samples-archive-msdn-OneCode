/****************************** Module Header ******************************\
* Module Name:  SimpleData.h
* Project:      CppUnvsAppSemanticZoom.Shared
* Copyright (c) Microsoft Corporation.
*
* This code sample shows how to bind simple data to SemanticZoom control in Universal apps.
* For more details, please refer to:
* http://blogs.msdn.com/b/wsdevsol/archive/2014/09/18/a-simple-semanticzoom.aspx
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


namespace CppUnvsAppSemanticZoom
{
	[Windows::UI::Xaml::Data::Bindable]
	public ref class Speaker sealed: Windows::UI::Xaml::Data::INotifyPropertyChanged
	{
	private:
		bool _isPropertyChangedObserved;
		event Windows::UI::Xaml::Data::PropertyChangedEventHandler^ _privatePropertyChanged;
	protected:
		/// <summary> 
		/// Notifies listeners that a property value has changed. 
		/// </summary> 
		/// <param name="propertyName">Name of the property used to notify listeners.</param> 
		void OnPropertyChanged(Platform::String^ propertyName)
		{
			if (_isPropertyChangedObserved)
			{
				PropertyChanged(this, ref new Windows::UI::Xaml::Data::PropertyChangedEventArgs(propertyName));
			}
		}
	public:
		Speaker()
		{
			_isPropertyChangedObserved = false;
			name = ref new Platform::String;
			languages = ref new Platform::Collections::Vector < Platform::String^ >;
		}
		// in c++, it is not necessary to include definitions of add, remove, and raise. 
		//  these definitions have been made explicitly here so that we can check if the  
		//  event has listeners before firing the event 
		virtual event Windows::UI::Xaml::Data::PropertyChangedEventHandler^ PropertyChanged
		{
			virtual Windows::Foundation::EventRegistrationToken add(Windows::UI::Xaml::Data::PropertyChangedEventHandler^ e)
			{
				_isPropertyChangedObserved = true;
				return _privatePropertyChanged += e;
			}
			virtual void remove(Windows::Foundation::EventRegistrationToken t)
			{
				_privatePropertyChanged -= t;
			}

		protected:
			virtual void raise(Object^ sender, Windows::UI::Xaml::Data::PropertyChangedEventArgs^ e)
			{
				if (_isPropertyChangedObserved)
				{
					_privatePropertyChanged(sender, e);
				}
			}
		}
	public:
		property Platform::String^ Name
		{
			Platform::String^ get()
			{
				return name;
			}
			void set(Platform::String^ value)
			{
				if (!name->Equals(value))
				{
					name = value;
					OnPropertyChanged("Name");
				}
			}
		}

		property Windows::Foundation::Collections::IObservableVector<Platform::String^>^ Languages
		{
			Windows::Foundation::Collections::IObservableVector<Platform::String^>^ get()
			{
				return languages;
			}
			void set(Windows::Foundation::Collections::IObservableVector<Platform::String^>^ value)
			{
				if (languages != value)
				{
					languages = value;
					OnPropertyChanged("Languages");
				}
			}
		}
	private:
		Platform::String^ name;
		Windows::Foundation::Collections::IObservableVector<Platform::String^>^ languages;
	};
	[Windows::UI::Xaml::Data::Bindable]
	public ref class LanguageGroup sealed
	{
	internal:
		LanguageGroup(Platform::String^ language, Windows::Foundation::Collections::IObservableVector<Speaker^>^ speakers)
		{
			_language = language;
			_speakers = speakers;
		}
	public:
		property Platform::String^ Language
		{
			Platform::String^ get()
			{
				return _language;
			}
			void set(Platform::String^ value)
			{
				if (!_language->Equals(value))
				{
					_language = value;					
				}
			}
		}
		property Windows::Foundation::Collections::IObservableVector<Speaker^>^ Speakers
		{
			Windows::Foundation::Collections::IObservableVector<Speaker^>^ get()
			{
				return _speakers;
			}
			void set(Windows::Foundation::Collections::IObservableVector<Speaker^>^ value)
			{
				if (!_speakers->Equals(value))
				{
					_speakers = value;
				}
			}
		}
		property int Count
		{
			int get()
			{
				return _speakers->Size;
			}
		}
	private:
		Platform::String^ _language;
		Windows::Foundation::Collections::IObservableVector<Speaker^>^ _speakers;
	};
}