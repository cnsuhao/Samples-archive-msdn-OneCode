/****************************** Module Header ******************************\
 * Module Name:  SimpleData.cs
 * Project:      CSUnvsAppSemanticZoom
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CSUnvsAppSemanticZoom
{
    public class Speaker : INotifyPropertyChanged
    {
        public override string ToString() { return Name; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private List<string> languages;

        public Speaker()
        {
            name = string.Empty;
            languages = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public List<string> Languages
        {
            get
            {
                return this.languages;
            }
            set
            {
                this.languages = value;
                this.OnPropertyChanged("Languages");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class LanguageGroup
    {
        public override string ToString() { return Language; }

        public LanguageGroup(string language, List<Speaker> speakers)
        {
            this.Language = language;
            this.Speakers = new ObservableCollection<Speaker>(speakers);
        }
        public string Language { get; set; }
        public ObservableCollection<Speaker> Speakers { get; set; }
    }

}
