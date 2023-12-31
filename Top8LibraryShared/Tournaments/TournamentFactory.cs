// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: TournamentFactory.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Collections.Generic;
using Top8Library.Decks;
using Top8Library.Players;
using Top8Library.POCOs;

namespace Top8Library.Tournaments
{
    internal static class TournamentFactory
    {
        //TODO: replace parameter lists with interface.
        public static ITournament CreateTournament(int players, int rounds)
        {
            return CreateTournament(players, rounds, true);
        }

        public static ITournament CreateTournament(int players, int rounds, bool includeDraws)
        {
            if (players > 0 & rounds > 0)
                return new CalculatedTournament(players, rounds, includeDraws);
            return null;
        }

        public static ITournament CreateTournament(int players, int rounds, bool intentionalDraws, bool unintentionalDraws, bool doubleLosses)
        {
            if (!(players > 0 & rounds > 0))
                return null;


            return new SimulatedTournament(CreatePlayerList(players), Day.CreateDay(8, rounds), intentionalDraws, unintentionalDraws, doubleLosses);
        }

        public static ITournament CreateTournament(int players, Day day, bool intentionalDraws = true, bool unintentionalDraws = true, bool doubleLosses = true)
        {
            if (!(players > 0 & day != null))
                return null;


            return new SimulatedTournament(CreatePlayerList(players), day, intentionalDraws, unintentionalDraws, doubleLosses);
        }

        private static List<IBasePlayer> CreatePlayerList(int players, Deck deck = null)
        {
            var playerList = new List<IBasePlayer>(players);
            for (int i = 0; i < players; ++i)
            {
                var player = new SimulatedPlayer(0, deck) {Name = $"Player {i+1}"};
                playerList.Add(player);
            }
            return playerList;
        }

        //TODO: Replace with abstract factory or some other way of this class having a player creator injected into it. Single Responsibility.
        public static ITournament CreateTournament(int players, int rounds, bool intentionalDraws, bool unintentionalDraws, bool doubleLosses, Deck deck)
        {
            if (!(players > 0 & rounds > 0))
                return null;


            return new SimulatedTournament(CreatePlayerList(players, deck), Day.CreateDay(8, rounds), intentionalDraws, unintentionalDraws, doubleLosses);
        }
    }
}
