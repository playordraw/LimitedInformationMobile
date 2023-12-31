// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Deck.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Top8Library.Utility;

namespace Top8Library.Decks
{
    internal class Deck
    {
        private string _name;
        private readonly Dictionary<Deck, decimal> _vs = new Dictionary<Deck, decimal>();

        private Deck()
        {
        }

        //Special override of the mirror match for testing.
        internal static Deck CreateDeck(string name, decimal mirror)
        {
            if (!mirror.Between(0, 1))
                throw new ArgumentOutOfRangeException(nameof(mirror), mirror, "Value must be between 0 and 1");

            var deck = new Deck { _name = name };
            deck._vs[deck] = mirror;
            return deck;
        }

        public static Deck CreateDeck(string name, IList<KeyValuePair<Deck, decimal>> odds)
        {
            Debug.Assert(odds != null);
            var deck = new Deck { _name = name };
            foreach (var pair in odds)
            {
                if (!pair.Value.Between(0, 1))
                    throw new ArgumentOutOfRangeException(nameof(pair.Value), pair.Value, "Value must be between 0 and 1");
                deck._vs[pair.Key] = pair.Value;
            }
            deck._vs[deck] = 0.5m;
            return deck;
        }

        public string Name => _name;

        public decimal GetOdds(Deck other)
        {
            decimal result;

            if (_vs.TryGetValue(other, out result))
                //if (_vs.ContainsKey(other))
                //return _vs[other];
                return result;

            if (other._vs.TryGetValue(this, out result))
                //if (other._vs.ContainsKey(this))
                //return 1 - other._vs[this];
                return 1 - result;

            throw new KeyNotFoundException("No deck archetype found");
        }
    }
}
