/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSUnvsAppSemanticZoom.WindowsPhone
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;


namespace CSUnvsAppSemanticZoom
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool IsZoomedInViewActive = (bool)value;
            return (IsZoomedInViewActive ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Speaker> AllSpeakers { get; set; }
        public ObservableCollection<LanguageGroup> AllLanguageGroups { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BuildDataSources();
            MyCollectionViewSource.Source = AllLanguageGroups;
            MySZ_ZoomedOutGridView.ItemsSource = MyCollectionViewSource.View.CollectionGroups;
        }

        private void BuildDataSources()
        {
            AllSpeakers = new ObservableCollection<Speaker>();

            Speaker Speaker1 = new Speaker();
            Speaker1.Name = "Johnny";
            Speaker1.Languages.Add("Spanish");
            AllSpeakers.Add(Speaker1);

            Speaker Speaker2 = new Speaker();
            Speaker2.Name = "Jack";
            Speaker2.Languages.Add("Arabic");
            Speaker2.Languages.Add("Portuguese");
            AllSpeakers.Add(Speaker2);

            Speaker Speaker3 = new Speaker();
            Speaker3.Name = "David";
            Speaker3.Languages.Add("Hindi");
            AllSpeakers.Add(Speaker3);

            Speaker Speaker4 = new Speaker();
            Speaker4.Name = "Andrew";
            Speaker4.Languages.Add("Hindi");
            Speaker4.Languages.Add("Italian");
            AllSpeakers.Add(Speaker4);

            Speaker Speaker5 = new Speaker();
            Speaker5.Name = "Mary";
            Speaker5.Languages.Add("Arabic");
            Speaker5.Languages.Add("Italian");
            AllSpeakers.Add(Speaker5);

            Speaker Speaker6 = new Speaker();
            Speaker6.Name = "Jane";
            Speaker6.Languages.Add("Arabic");
            AllSpeakers.Add(Speaker6);

            Speaker Speaker7 = new Speaker();
            Speaker7.Name = "Avril";
            Speaker7.Languages.Add("Arabic");
            Speaker7.Languages.Add("French");
            AllSpeakers.Add(Speaker7);

            Speaker Speaker8 = new Speaker();
            Speaker8.Name = "Martin";
            Speaker8.Languages.Add("Arabic");
            Speaker8.Languages.Add("French");
            Speaker8.Languages.Add("Portuguese");
            AllSpeakers.Add(Speaker8);

            Speaker Speaker9 = new Speaker();
            Speaker9.Name = "Jose";
            Speaker9.Languages.Add("Portugese");
            Speaker9.Languages.Add("Spanish");
            AllSpeakers.Add(Speaker9);


            this.AllLanguageGroups = new ObservableCollection<LanguageGroup>();
            LanguageGroup MyLanguageGroup;

            List<Speaker> SpanishList = new List<Speaker>();
            SpanishList.Add(Speaker1);
            SpanishList.Add(Speaker9);
            MyLanguageGroup = new LanguageGroup("Spanish", SpanishList);
            AllLanguageGroups.Add(MyLanguageGroup);

            List<Speaker> ArabicList = new List<Speaker>();
            ArabicList.Add(Speaker2);
            ArabicList.Add(Speaker5);
            ArabicList.Add(Speaker6);
            ArabicList.Add(Speaker7);
            ArabicList.Add(Speaker8);
            MyLanguageGroup = new LanguageGroup("Arabic", ArabicList);
            AllLanguageGroups.Add(MyLanguageGroup);

            List<Speaker> HindiList = new List<Speaker>();
            HindiList.Add(Speaker3);
            HindiList.Add(Speaker4);
            MyLanguageGroup = new LanguageGroup("Hindi", HindiList);
            AllLanguageGroups.Add(MyLanguageGroup);

            List<Speaker> ItalianList = new List<Speaker>();
            ItalianList.Add(Speaker4);
            ItalianList.Add(Speaker5);
            MyLanguageGroup = new LanguageGroup("Italian", ItalianList);
            AllLanguageGroups.Add(MyLanguageGroup);

            List<Speaker> FrenchList = new List<Speaker>();
            FrenchList.Add(Speaker7);
            FrenchList.Add(Speaker8);
            MyLanguageGroup = new LanguageGroup("French", FrenchList);
            AllLanguageGroups.Add(MyLanguageGroup);

            List<Speaker> PortugueseList = new List<Speaker>();
            PortugueseList.Add(Speaker2);
            PortugueseList.Add(Speaker8);
            PortugueseList.Add(Speaker9);
            MyLanguageGroup = new LanguageGroup("Portuguese", PortugueseList);
            AllLanguageGroups.Add(MyLanguageGroup);

        }

        private async void MySZ_ZoomedInGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Speaker MySpeaker = e.AddedItems[0] as Speaker;

            string SpeakerInformation = "Name: " + MySpeaker.Name + "\r\n";
            SpeakerInformation += "Known Languages: " + "\r\n";
            foreach (string L in MySpeaker.Languages)
            {
                SpeakerInformation += "   " + L + "\r\n";
            }

            var MyMessageDialog = new MessageDialog(SpeakerInformation);
            try
            {
                await MyMessageDialog.ShowAsync();
            }
            catch { }

        }

        private void ChangeViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySemanticZoom.IsZoomedInViewActive = !MySemanticZoom.IsZoomedInViewActive;
        }

        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));

        }
    }
}
