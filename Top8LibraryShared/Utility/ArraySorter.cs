// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: ArraySorter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
//using System;
//using Top8Library.Players;

//namespace Top8Library.Utility
//{
//    internal static class ArraySorter
//    {
//        public delegate void SortDelagate(IBasePlayer[] array);

//        internal static SortDelagate GetSorter(int sortHint = 0)
//        {
//            if (sortHint < 100)
//            {
//                return InsertionSortPlayers;
//            }
//            return IntroSortPlayers;
//        }

//        private static void InsertionSortPlayers(IBasePlayer[] array)
//        {
//            for (var j = 1; j < array.Length; ++j)
//            {
//                var i = j - 1;
//                var temp = array[j];
//                while (i >= 0 && array[i].CompareTo(temp) == -1)
//                {
//                    array[i + 1] = array[i];
//                    --i;
//                }
//                array[i + 1] = temp;
//            }
//        }

//        private static void IntroSortPlayers(IBasePlayer[] array)
//        {
//            Array.Sort(array, (player, basePlayer) => -player.CompareTo(basePlayer));
//        }
//    }
//}
