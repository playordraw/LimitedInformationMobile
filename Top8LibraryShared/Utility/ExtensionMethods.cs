// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: ExtensionMethods.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Collections.Generic;
using System.Linq;
using Top8Library.Players;

namespace Top8Library.Utility
{
    internal static class ExtensionMethods
    {
        public static T GetRandom<T>(this IList<T> source)
        {
            return source.Count == 0 ? default(T) : source.ElementAt(RandomData.Instance.Next(0, source.Count));
        }

        public static void AwardByes(this IEnumerable<IBasePlayer> players)
        {
            if (players != null)
            {
                foreach (IBasePlayer basePlayer in players)
                {
                    SimulatedPlayer player = basePlayer as SimulatedPlayer;
                    if (player != null && player.HasBye)
                    {
                        player.AwardBye();
                    }
                }
            }
        }

        public static bool Between(this decimal value, decimal start, decimal end)
        {
            return value >= start && value <= end;
        }

        /*public static void Randomize<T>(this IList<T> source)
        {
            for (int i = source.Count - 1; i > 0; --i)
            {
                int random = RandomData.Instance.Next(0, i + 1);
                T temp = source[i];
                source[i] = source[random];
                source[random] = temp;
            }
            /*for (int i = 0; i < source.Count; i++)
            {
                int random = RandomData.Instance.Next(i, source.Count);
                T temp = source[i];
                source[i] = source[random];
                source[random] = temp;
            }#1#
        }*/
    }
}
