/****************************** Module Header ******************************\
* Module Name: PersonViewModel.cs
* Project:     CSSL4DataGridBindingInMVVM
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to bind data source with using two way mode with
* frequent changed data, the clients can be notified when properties has been 
* changed. The sample designed by MVVM pattern, the lightly pattern provides a 
* flexible way for improving code re-use, simply maintenance and testing.
* 
* The ViewModel class is used to bind data to view layer and calls the 
* Command class when relative button is triggered.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections.Generic;

namespace CSSL4DataGridBindingInMVVM
{
    /// <summary>
    /// The MainPage.xaml page bind this class with Grid control, PersonViewModel
    /// class is the ViewModel layer in MVVM pattern design, this class contains 
    /// a model instances and invoke Command class.
    /// </summary>
    public class PersonViewModel
    {
        public PersonModel person
        {
            get; 
            set;
        }

        public PersonViewModel()
        {
            this.person = new PersonModel("John", 1, "13745654587", "Hello");
        }

        public PersonViewModel(string name, int age, string telephone, string comment)
        {
            this.person = new PersonModel(name, age, telephone, comment);
        }

        public ICommand GetInformation
        {
            get
            {
                return new PersonCommand(this);
            }
        }

        public ICommand SetInformation
        {
            get
            {
                return new ChangeModelCommand(this);
            }
        }

        public void UpdatePerson(PersonModel entity)
        {
            MessageBox.Show(String.Format("Name: {0} \r\n Age: {1} \r\n Telephone: {2} \r\n Comment: {3}",
                person.Name,person.Age,person.Telephone,person.Comment),"Display Message", MessageBoxButton.OK);
        }


    }
}
