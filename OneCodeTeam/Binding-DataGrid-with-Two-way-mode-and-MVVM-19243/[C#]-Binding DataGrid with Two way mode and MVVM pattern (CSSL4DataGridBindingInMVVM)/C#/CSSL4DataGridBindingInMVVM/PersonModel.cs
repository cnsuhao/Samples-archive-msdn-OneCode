/****************************** Module Header ******************************\
* Module Name: PersonModel.cs
* Project:     CSSL4DataGridBindingInMVVM
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to bind data source with using two way mode with
* frequent changed data, the clients can be notified when properties has been 
* changed. The sample designed by MVVM pattern, the lightly pattern provides a 
* flexible way for improving code re-use, simply maintenance and testing.
* 
* The Model class is used for storing user information.
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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CSSL4DataGridBindingInMVVM
{
    /// <summary>
    /// Person Modal class, contains name, age, telephone and comment properties.
    /// The Model implement INotifyPropertyChanged interface for notifying clients
    /// that properties has been changed.
    /// </summary>
    public class PersonModel : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private string telephone;
        private string comment;
        private Regex regexInt = new Regex(@"^-?\d*$");
        public event PropertyChangedEventHandler PropertyChanged;
        public PersonModel(string name, int age, string telephone, string comment)
        {
            this.name = name;
            this.age = age;
            this.telephone = telephone;
            this.comment = comment;
        }

        public void Changed(string newValue)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newValue));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Name can not be empty.");
                name = value;
                Changed("Name");
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                int outPut;
                if (int.TryParse(value.ToString(), out outPut))
                {
                    if (outPut < 0)
                        throw new Exception("Age must be greater than zero.");
                    age = outPut;//outPut.ToString();
                    Changed("Age");
                }
                else
                {
                    throw new Exception("Age must be an integer number.");
                }
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Telephone can not be empty.");
                if (!regexInt.IsMatch(value))
                    throw new Exception("Telephone number must be comprised of numbers.");
                telephone = value;
                Changed("Telephone");
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Comment can not be empty.");
                comment = value;
                Changed("Comment");
            }
        }
    }
}
