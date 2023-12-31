// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedMatchRecord.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using Top8Library.Players;

namespace Top8Library.POCOs
{
    internal class CalculatedMatchRecord
    {
        public CalculatedMatchRecord(IBasePlayer winner, IBasePlayer loser, bool drew)
        {
            Winner = winner;
            Loser = loser;
            Drew = drew;
        }

        public IBasePlayer Winner {get;}

        public IBasePlayer Loser {get;}

        public bool Drew {get;}
    }
}
