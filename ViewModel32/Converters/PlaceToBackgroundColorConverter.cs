// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlaceToBackgroundColorConverter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using ViewModel.POCOs;
using ViewModel.ViewModels;

namespace ViewModel.Converters
{
    public class PlaceToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
                return null;

            int place = (int)value;

            IList<Standing> list = ((Top8CalcViewModel)parameter).Results;

            int points = list[place - 1].Points;

            int cutoff = list.Count > 8 ? list[8].Points : int.MaxValue;

            var retVal = new SolidColorBrush();

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
                    retVal.Color = points > cutoff ? Colors.Green : Colors.Yellow;
                    break;
                default:
                    retVal.Color = Colors.Red;
                    break;
            }

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
