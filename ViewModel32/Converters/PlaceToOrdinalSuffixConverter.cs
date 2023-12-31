// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToOrdinalSuffixConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Windows.UI.Xaml.Data;

namespace ViewModel.Converters
{
    public class PlaceToOrdinalSuffixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Top8Library.Utility.Utility.GetOrdinal((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
