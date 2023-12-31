// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Top8Simulator.xaml.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 
using ViewModel.POCOs;

namespace LimitedInformationMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Top8Simulator : ContentPage
    {
        public Top8Simulator()
        {
            InitializeComponent();

            var standing = new Standing(0, 0, 0, 0, 0);//Inclluding this line for IOS
        }
    }
}
