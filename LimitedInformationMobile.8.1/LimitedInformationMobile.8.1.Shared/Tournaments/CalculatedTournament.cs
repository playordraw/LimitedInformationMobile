// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedTournament.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.ObjectModel;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Utility;

namespace Top8Library.Tournaments
{
    internal class CalculatedTournament : ITournament
    {
        public CalculatedTournament(int players, int rounds) : this(players, rounds, true)
        {
        }

        public CalculatedTournament(int players, int rounds, bool includeDraws)
        {
            _rounds = rounds;
            _players = CreatePlayers(players);
            _includeDraws = includeDraws;
            _sort = PlayerSorter.GetSorter(_players.Length);
        }

        private bool _completed;
        private readonly bool _includeDraws;

        private IBasePlayer[] _players;
        private readonly int _rounds;
        private readonly PlayerSorter.SortDelagate _sort;

        private void RunWithDraws()
        {
            for (var j = 0; j < _rounds; ++j)
            {
                PreRoundAction();
                if (_rounds - j > 2)
                    ProcessRound(_players, 0);
                else
                    ProcessRound(_rounds - j, _players);
                PostRoundAction();
            }
        }

        private void RunWithoutDraws()
        {
            for (var j = 0; j < _rounds; ++j)
            {
                PreRoundAction();
                ProcessRound(_players, 0);
                PostRoundAction();
            }
        }

        private static IBasePlayer[] CreatePlayers(int players)
        {
            var odd = players & 1;
            var retVal = new IBasePlayer[players + odd];
            for (var i = players - 1; i >= 0; i--)
            {
                retVal[i] = new CalculatedPlayer();
            }

            if (odd == 1)
                retVal[players] = new ByePlayer();

            return retVal;
        }

        private static void ProcessRound(int rounds, IBasePlayer[] pairedPlayers)
        {
            var top8 = Math.Min(8, pairedPlayers.Length);
            var drawing = top8;

            for (var i = (drawing >> 1) - 1; i >= 0; --i)
            {
                var index = i * 2;
                if (!pairedPlayers[index].CanDraw(new CalculatedDrawState(rounds, top8 - drawing, pairedPlayers, index)) || !pairedPlayers[index + 1].CanDraw(new CalculatedDrawState(rounds, top8 - drawing, pairedPlayers, index)))
                {
                    drawing -= 2;
                }
                else
                {
                    break;
                }
            }

            drawing = drawing >> 1;

            Draw(pairedPlayers, drawing);
            ProcessRound(pairedPlayers, drawing);
        }

        private static void Draw(IBasePlayer[] pairedPlayers, int pairsDrawing)
        {
            for (var i = 0; i < pairsDrawing; ++i)
            {
                var result = new CalculatedMatchRecord(pairedPlayers[i * 2], pairedPlayers[i * 2 + 1], true);
                pairedPlayers[i * 2].AddRecord(result);
                pairedPlayers[i * 2 + 1].AddRecord(result);
                //AddRecord(false, false, true, pairedPlayers[i * 2]);
                //AddRecord(false, false, true, pairedPlayers[i * 2 + 1]);
            }
        }

        private static void ProcessRound(IBasePlayer[] pairedPlayers, int pairsDrawing)
        {
            for (var i = pairsDrawing; i < pairedPlayers.Length >> 1; ++i)
            {
                //AddRecord(true, false, false, pairedPlayers[i * 2]);
                var result = new CalculatedMatchRecord(pairedPlayers[i * 2], pairedPlayers[i * 2 + 1], false);
                pairedPlayers[i * 2].AddRecord(result);
                pairedPlayers[i * 2 + 1].AddRecord(result);
                //AddRecord(false, true, false, pairedPlayers[i * 2 + 1]);
            }
        }

        protected void PreRoundAction()
        {
        }

        protected void PostRoundAction()
        {
            _sort(_players);
        }

        protected void PreTournamentAction()
        {
        }

        protected void PostTournamentAction()
        {
            if (_players[_players.Length - 1] is ByePlayer)
            {
                var temp = new IBasePlayer[_players.Length - 1];
                Array.Copy(_players, temp, _players.Length - 1);
                _players = temp;
            }
        }

        public ReadOnlyCollection<IBasePlayer> GetResults() => _completed ? new ReadOnlyCollection<IBasePlayer>(_players) : null;

        public void Run()
        {
            PreTournamentAction();
            if (_includeDraws)
            {
                RunWithDraws();
            }
            else
            {
                RunWithoutDraws();
            }

            _completed = true;
            PostTournamentAction();
        }
    }
}
