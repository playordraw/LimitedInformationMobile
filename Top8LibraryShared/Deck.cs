// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Deck.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;

namespace Top8Library.Decks
{
    internal class Deck
    {
        private string _name;
        private Dictionary<Deck, decimal> _vs;

        public Deck(string deck)
        {
            _name = deck;
        }

        public decimal GetOdds(Deck other)
        {
            return 0.5m;
        }
    }
}
