// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlayerSorter.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using Top8Library.Players;

namespace Top8Library.Utility
{
    internal static class PlayerSorter
    {
        public delegate void SortDelagate(IList<IBasePlayer> array);

        internal static SortDelagate GetSorter(int sortHint = 0, string type = "quick")
        {
            switch (type)
            {
                case "quick":
                    if (sortHint < 100)
                    {
                        return InsertionSortPlayers;
                    }
                    return IntroSortPlayers;
                case "stable":
                    if (sortHint < 100)
                    {
                        return InsertionSortPlayers;
                    }
                    return MergeSort;
                default:
                    return InsertionSortPlayers;
            }
        }

        internal static void InsertionSortPlayers(IList<IBasePlayer> array)
        {
            for (int j = 1; j < array.Count; ++j)
            {
                int i = j - 1;
                IBasePlayer temp = array[j];
                while (i >= 0 && array[i].CompareTo(temp) == -1)
                {
                    array[i + 1] = array[i];
                    --i;
                }
                array[i + 1] = temp;
            }
            //InsertionSortPlayers(array, 0, array.Count);
        }

        internal static void InsertionSortPlayers(IList<IBasePlayer> array, int startInclusive, int endExclusive)
        {
            for (int j = startInclusive + 1; j < endExclusive; ++j)
            {
                int i = j - 1;
                IBasePlayer temp = array[j];
                while (i >= startInclusive && array[i].CompareTo(temp) == -1)
                {
                    array[i + 1] = array[i];
                    --i;
                }
                array[i + 1] = temp;
            }
        }

        internal static void IntroSortPlayers(IList<IBasePlayer> array)
        {
            Type type = array.GetType();

            if (typeof(IBasePlayer[]) == type)
            {
                Array.Sort<IBasePlayer>((IBasePlayer[])array, (player, basePlayer) => -player.CompareTo(basePlayer));
            }
            else if (typeof(List<IBasePlayer>) == type)
            {
                ((List<IBasePlayer>)array).Sort((player, basePlayer) => -player.CompareTo(basePlayer));
            }
        }

        internal static void MergeSort(IList<IBasePlayer> array)
        {
            MergeSort(array, 0, array.Count);
        }

        private static void MergeSort(IList<IBasePlayer> array, int min, int max)
        {
            if (max - min >= 2)
            {
                int mid = (min + max) >> 1;
                MergeSort(array, min, mid);
                MergeSort(array, mid, max);

                Merge(array, min, mid, max);
            }
        }

        private static void Merge(IList<IBasePlayer> array, int min, int mid, int max)
        {
            switch (max - min)
            {
                case 1:
                    return;
                case 2:
                    if (array[mid].CompareTo(array[min]) <= 0)
                        return;

                    var temp = array[min];
                    array[min] = array[mid];
                    array[mid] = temp;
                    return;
            }

            IBasePlayer[] work = new IBasePlayer[mid - min];

            for (int i = 0; i < work.Length; ++i)
            {
                work[i] = array[i + min];
            }

            int leftIndex = 0;
            int rightIndex = mid;
            int finalInxed = min;

            while (finalInxed < max)
            {
                while (leftIndex < work.Length && (rightIndex >= max || work[leftIndex].CompareTo(array[rightIndex]) >= 0))
                    array[finalInxed++] = work[leftIndex++];

                while (rightIndex < max && (leftIndex >= work.Length || array[rightIndex].CompareTo(work[leftIndex]) > 0))
                    array[finalInxed++] = array[rightIndex++];
            }
        }
    }
}
