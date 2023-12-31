// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: About.xaml.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.POCOs;
using Xamarin.Forms;

namespace LimitedInformationMobile.Views
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();

            var standing = new Standing(0, 0, 0, 0, 0);//Inclluding this line for IOS
        }
    }
}
