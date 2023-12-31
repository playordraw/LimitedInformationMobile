// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Standing.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Diagnostics.CodeAnalysis;

namespace ViewModel.POCOs
{
    public class Standing
    {
        internal Standing(int place, int points, int wins, int losses, int draws)
        {
            Place = place;
            //PlaceSuffix = "st";
            Points = points;
            Wins = wins;
            Losses = losses;
            Draws = draws;
        }

        public int Place { get; }

        /*[SuppressMessage("ReSharper", "MemberCanBeInternal")]
        public string PlaceSuffix { get; }*/

        public int Points { get; }

        public int Wins { get; }

        public int Losses { get; }

        public int Draws { get; }
    }
}
