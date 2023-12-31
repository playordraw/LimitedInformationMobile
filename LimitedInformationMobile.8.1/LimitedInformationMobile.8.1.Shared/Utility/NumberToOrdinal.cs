// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: NumberToOrdinal.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
namespace Top8Library.Utility
{
    internal static class Utility
    {
        public static string GetOrdinal(int number)
        {
            string retVal;
            int tens = ((number / 10) % 10);
            if (tens != 1)
            {
                int ones = number % 10;
                switch (ones)
                {
                    case 1:
                        retVal = "st";
                        break;
                    case 2:
                        retVal = "nd";
                        break;
                    case 3:
                        retVal = "rd";
                        break;
                    default:
                        retVal = "th";
                        break;
                }
            }
            else
            {
                retVal = "th";
            }

            return retVal;
        }
    }
}
