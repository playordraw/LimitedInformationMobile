// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: LandingScreen.xaml.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using ViewModel.POCOs;
using Xamarin.Forms;

namespace LimitedInformationMobile.Views
{
    public partial class LandingScreen : TabbedPage
    {
        public LandingScreen()
        {
            InitializeComponent();

            var standing = new Standing(0,0,0,0,0);//Inclluding this line for IOS
        }
    }
}
