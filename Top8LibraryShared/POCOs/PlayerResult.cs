// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlayerResult.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
//using System.Diagnostics;

namespace Top8Library.POCOs
{
    //[DebuggerDisplay("Win = {Wins}, Lose = {Losses}, Draw = {Draws}, Point = {Points}")]
    internal class PlayerResult
    {
        internal PlayerResult(int wins, int losses, int draws, int points)
        {
            Wins = wins;
            Losses = losses;
            Draws = draws;
            Points = points;
        }

        public int Wins {get;}
        public int Losses {get;}
        public int Draws {get;}
        public int Points {get;}
    }
}
