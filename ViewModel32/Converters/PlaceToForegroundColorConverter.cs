// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToForegroundColorConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ViewModel.Converters
{
    public class PlaceToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is SolidColorBrush))
                return null;

            Color baseColor = ((SolidColorBrush)value).Color;

            var retval = new SolidColorBrush();

            retval.Color =
            baseColor.R * 76 +
            baseColor.G * 150 +
            baseColor.B * 29 >= 128 ? Colors.Black : Colors.White;

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
