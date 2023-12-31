// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToBackgroundColorConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Globalization;
using ViewModel.POCOs;
using Xamarin.Forms;

namespace ViewModel.Converters
{
    internal class PlaceToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;

            int place = (int)value;

            var list = (IList<Standing>)((ListView)parameter).ItemsSource;

            Standing currentPlayer = null;
            currentPlayer = list[place - 1];            

            int cutoff = list.Count > 8 ? list[8].Points : int.MaxValue;

            switch (place)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:                    
                    return currentPlayer.Points > cutoff ? Color.Green : Color.Yellow;                
                default:
                    return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
