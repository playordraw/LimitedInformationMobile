// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToForegroundColorConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ViewModel.Converters
{
    internal class PlaceToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color))
                return null;

            Color baseColor = (Color)value;

            return
            baseColor.R * 76 +
            baseColor.G * 150 +
            baseColor.B * 29 >= 128 ? Color.Black : Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
