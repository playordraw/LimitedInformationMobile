// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Day.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
namespace Top8Library.POCOs
{
    internal class Day
    {
        private Day(int dailyCut, int rounds)
        {
            DailyCut = dailyCut;
            Rounds = rounds;
            ActivePlayers = int.MaxValue;
        }

        public static Day CreateDay(int dailyCut, int rounds)
        {
            return rounds <= 0 ? null : new Day(dailyCut <= 0 ? int.MaxValue : dailyCut, rounds);
        }

        public int ActivePlayers {get;set;}
        public int DailyCut { get; }
        public int Rounds { get; }
        public Day Next {get;set;}
        public Day Previous {get;set;}
    }
}
