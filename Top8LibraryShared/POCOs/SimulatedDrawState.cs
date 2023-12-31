// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedDrawState.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using Top8Library.Players;

namespace Top8Library.POCOs
{
    class SimulatedDrawState
    {
        private readonly int _roundsLeft;
        private readonly int _top8;
        private readonly Stack<Tuple<IBasePlayer, IBasePlayer>> _pairedPlayers;

        public SimulatedDrawState(int roundsLeft, int top8, Stack<Tuple<IBasePlayer, IBasePlayer>> _pairedPlayers)
        {
            this._roundsLeft = roundsLeft;
            this._top8 = top8;
            this._pairedPlayers = _pairedPlayers;
        }

        public int RoundsLeft => _roundsLeft;
        public int Top8SlotsLeft => _top8;
        public Stack<Tuple<IBasePlayer, IBasePlayer>> Players => _pairedPlayers;
    }
}
