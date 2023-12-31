// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedDrawState.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using Top8Library.Players;

namespace Top8Library.POCOs
{
    internal class CalculatedDrawState
    {
        public CalculatedDrawState(int roundsLeft, int top8, IBasePlayer[] players, int pairIndex)
        {
            RoundsLeft = roundsLeft;
            Top8SlotsLeft = top8;
            Players = players;
            PairIndex = pairIndex;
        }

        public int RoundsLeft {get;}

        public int Top8SlotsLeft {get;}

        public IBasePlayer[] Players {get;}

        public int PairIndex {get;}
    }
}
