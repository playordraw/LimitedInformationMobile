// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToOrdinalSuffixConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ViewModel.Converters
{
    internal class PlaceToOrdinalSuffixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FormattedString formattedString = new FormattedString();
            int place = (int)value;

            formattedString.Spans.Add(new Span() { Text = place.ToString(), FontSize = 35 });
            formattedString.Spans.Add(new Span() { Text = Top8Library.Utility.Utility.GetOrdinal(place) });

            //Standing standing = (parameter as BindableObject)?.BindingContext as Standing;
            //if (standing?.Count <= 1)
            //{
                return formattedString;
            //}

            //formattedString.Spans.Add(new Span() { Text = $" - " });
            //formattedString.Spans.Add(new Span() { Text = (place + standing.Count - 1).ToString(), FontSize = 35 });
            //formattedString.Spans.Add(new Span() { Text = Top8Library.Utility.Utility.GetOrdinal(place + standing.Count - 1) });

            //return formattedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
