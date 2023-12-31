// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: DeckDatabase.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Top8Library.Decks
{
    internal class DeckSharedDatabase : IDictionary<string, Deck>, ICollection<KeyValuePair<string, Deck>>, IEnumerable<KeyValuePair<string, Deck>>, IDictionary, ICollection, IEnumerable
    {
        private static readonly ConcurrentDictionary<string, Deck> _Decks = new ConcurrentDictionary<string, Deck>();

        public static readonly DeckSharedDatabase Instance = new DeckSharedDatabase();

        private DeckSharedDatabase()
        {
            Deck.CreateDeck("Unknown", new List<KeyValuePair<Deck, decimal>>());
        }

        public int Count => _Decks.Count;

        public bool TryGetValue(string key, out Deck value)
        {
            return _Decks.TryGetValue(key, out value);
        }

        public Deck this[string key]
        {
            get
            {
                _Decks.TryGetValue(key, out Deck retVal);
                return retVal;
            }
            set => _Decks[key] = value;
        }

        public ICollection<string> Keys => _Decks.Keys;

        bool ICollection<KeyValuePair<string, Deck>>.IsReadOnly => ((ICollection<KeyValuePair<string, Deck>>)_Decks).IsReadOnly;

        bool ICollection.IsSynchronized => ((ICollection)_Decks).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_Decks).SyncRoot;

        bool IDictionary.IsFixedSize => ((IDictionary)_Decks).IsFixedSize;

        bool IDictionary.IsReadOnly => ((IDictionary)_Decks).IsReadOnly;

        object IDictionary.this[object key]
        {
            get => this[key as string];
            set => this[key as string] = value as Deck;
        }

        ICollection IDictionary.Keys => ((IDictionary)_Decks).Keys;

        ICollection IDictionary.Values => ((IDictionary)_Decks).Values;

        public ICollection<Deck> Values => _Decks.Values;

        public void Clear()
        {
            _Decks.Clear();
        }

        public bool ContainsKey(string key)
        {
            return _Decks.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, Deck>> GetEnumerator()
        {
            return _Decks.GetEnumerator();
        }

        void ICollection<KeyValuePair<string, Deck>>.Add(KeyValuePair<string, Deck> keyValuePair)
        {
            ((ICollection<KeyValuePair<string, Deck>>)_Decks).Add(keyValuePair);
        }

        bool ICollection<KeyValuePair<string, Deck>>.Contains(KeyValuePair<string, Deck> keyValuePair)
        {
            return ((ICollection<KeyValuePair<string, Deck>>)_Decks).Contains(keyValuePair);
        }

        void ICollection<KeyValuePair<string, Deck>>.CopyTo(KeyValuePair<string, Deck>[] array, int index)
        {
            ((ICollection<KeyValuePair<string, Deck>>)_Decks).CopyTo(array, index);
        }

        bool ICollection<KeyValuePair<string, Deck>>.Remove(KeyValuePair<string, Deck> keyValuePair)
        {
            return ((ICollection<KeyValuePair<string, Deck>>)_Decks).Remove(keyValuePair);
        }

        void IDictionary<string, Deck>.Add(string key, Deck value)
        {
            this[key] = value;
        }

        bool IDictionary<string, Deck>.Remove(string key)
        {
            return ((IDictionary<string, Deck>)_Decks).Remove(key);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)_Decks).CopyTo(array, index);
        }

        void IDictionary.Add(object key, object value)
        {
            this[key as string] = value as Deck;
        }

        bool IDictionary.Contains(object key)
        {
            return ((IDictionary)_Decks).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)_Decks).GetEnumerator();
        }

        void IDictionary.Remove(object key)
        {
            ((IDictionary)_Decks).Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Decks.GetEnumerator();
        }

        public Deck Add(Deck deck)
        {
            this[deck.Name] = deck;
            return deck;
        }

        public Deck GetOrAdd(Deck deck)
        {
            return TryGetValue(deck.Name, out Deck retVal) ? retVal : Add(deck);
        }
    }
}
