// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: HubPage.xaml.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Windows.ApplicationModel.Resources;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ViewModel;
using ViewModel.Common;
using ViewModel.ViewModels;

namespace Top8Calc.Views
{
    internal sealed partial class HubPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public HubPage()
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private HubViewModel ViewModel => (HubViewModel)this.Resources["HubViewModel"];

        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //
            //Add all pages here for now.
            //
            //TODO: Add image path.
            await ViewModel.AddHubItem(typeof(Top8Calculator), "Top 8 Calculator", @"A static analysis of a tournament's likely final standings. The results will always be the same for the same inputs.", "imagepath");
            await ViewModel.AddHubItem(typeof(Top8Simulator), "Top 8 Simulator", @"A simulation of a tournament's likely final standings. The results will vary each iteration run.", "imagepath");

        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var viewType = ((HubItem)e.ClickedItem).ViewType;
            if (!Frame.Navigate(viewType))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
    }
}
