// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedTournament.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Utility;

namespace Top8Library.Tournaments
{
    internal class SimulatedTournament : ITournament
    {
        private readonly IList<IBasePlayer> _players;
        private readonly bool _unintentionalDraws;
        private readonly bool _intentionalDraws;
        private readonly bool _doubleLosses;
        private Stack<Tuple<IBasePlayer, IBasePlayer>> _pairedPlayers;
        private bool _completed;
        private Day _currentDay;
        private decimal _winPct;
        private decimal _drawPct;
        private decimal _dlossPct;
        private readonly PlayerPairer.PairDelagate _playerPairer;
        private readonly PlayerSorter.SortDelagate _sort;

        public SimulatedTournament(IList<IBasePlayer> players, Day days, bool intentionalDraws = true, bool unintentionalDraws = true, bool doubleLosses = true)
        {
            _players = players;
            _currentDay = days;
            _intentionalDraws = intentionalDraws;
            _unintentionalDraws = unintentionalDraws;
            _doubleLosses = doubleLosses;
            _sort = PlayerSorter.GetSorter(_players.Count);
            _playerPairer = PlayerPairer.GetPlayerPairer();
        }

        private IList<IBasePlayer> GetActivePlayers()
        {
            _sort(_players);
            int activePlayers = _currentDay.ActivePlayers;
            if (activePlayers <= 0 || activePlayers >= _players.Count)
                return _players;

            List<IBasePlayer> retVal = new List<IBasePlayer>();

            for (int i = 0; i < activePlayers; ++i)
            {
                if (!((SimulatedPlayer)_players[i]).HasBye)
                {
                    retVal.Add(_players[i]);
                }
            }

            return retVal;
        }

        public bool Completed => _completed;

        public void Run()
        {
            PreTournamentAction();
            while (_currentDay != null)
            {
                PreDayAction();
                int rounds = _currentDay.Rounds;
                for (int i = 0; i < rounds; ++i)
                {
                    PreRoundAction();
                    if ((rounds - i <= 2) /*&& IsFinalDay()*/ && _intentionalDraws)
                        ProcessRound(rounds - i);
                    else
                        ProcessRound();
                    PostRoundAction();
                }
                PostDayAction();
            }
            PostTournamentAction();
        }

        protected void ProcessRound(int rounds)
        {
            int top8Slots = Math.Min(8, _currentDay.DailyCut);
            int top8Pairs = top8Slots >> 1;

            Stack<Tuple<IBasePlayer, IBasePlayer>> drawing = new Stack<Tuple<IBasePlayer, IBasePlayer>>(top8Pairs);
            for (int i = 0; i < top8Pairs; ++i)
            {
                drawing.Push(_pairedPlayers.Pop());
            }

            while (drawing.Count > 0 &&
                  ((drawing.Peek().Item2 != null && !drawing.Peek().Item2.CanDraw(new SimulatedDrawState(rounds, top8Slots - drawing.Count * 2, _pairedPlayers))) ||
                  !drawing.Peek().Item1.CanDraw(new SimulatedDrawState(rounds, top8Slots - drawing.Count * 2, _pairedPlayers))))
            {
                _pairedPlayers.Push(drawing.Pop());
            }
            Draw(drawing);
            ProcessRound();
        }

        private void Draw(Stack<Tuple<IBasePlayer, IBasePlayer>> drawing)
        {
            while (drawing.Count > 0)
            {
                var pair = drawing.Pop();
                AddRecord(pair.Item1, pair.Item2, drew: true);
            }
        }

        protected void ProcessRound()
        {
            while (_pairedPlayers.Count > 0)
            {
                var match = _pairedPlayers.Pop();
                if (match.Item2 != null)
                {
                    decimal roll = RandomData.Instance.NextDecimal();

                    if (roll.Between(0, _winPct))
                    {
                        decimal chance = ((IHasOdds)match.Item1).Vs(match.Item2);
                        roll = RandomData.Instance.NextDecimal();

                        if (roll.Between(0, chance))
                            AddRecord(match.Item1, match.Item2);
                        else
                            AddRecord(match.Item2, match.Item1);
                    }
                    else if (roll.Between(_winPct, _winPct + _drawPct))
                    {
                        AddRecord(match.Item1, match.Item2, drew: true);
                    }
                    else if (_doubleLosses && roll.Between(_winPct + _drawPct, _winPct + _drawPct + _dlossPct))
                    {
                        AddRecord(match.Item1, match.Item2, doubleLoss: true);
                    }
                    else
                    {//something went wrong
                        throw new Exception("Invalid match result.");
                    }
                }
                else
                {
                    AddRecord(match.Item1, match.Item2);
                }
            }
        }

        private void AddRecord(IBasePlayer winner, IBasePlayer loser, bool drew = false, bool doubleLoss = false)
        {
            winner.AddRecord(new SimulatedMatchRecord(winner, loser, winner, drew, doubleLoss));
            loser?.AddRecord(new SimulatedMatchRecord(loser, winner, winner, drew, doubleLoss));
        }

        public ReadOnlyCollection<IBasePlayer> GetResults() => Completed ? new ReadOnlyCollection<IBasePlayer>(_players) : null;

        protected void PreTournamentAction()
        {
            _winPct = 0.97169176740202500557287165187m;
            _drawPct = _unintentionalDraws ? 0.02789955534350398704747304489m : 0;
            _dlossPct = _doubleLosses ? 0.00040867725447100737965530322m : 0;
            decimal total = _winPct + _drawPct + _dlossPct;
            //Scale percents to 100
            _winPct /= total;
            _drawPct /= total;
            _dlossPct /= total;

            Debug.Assert(_winPct + _drawPct + _dlossPct == 1m);
        }

        protected void PreDayAction()
        {
        }

        protected void PreRoundAction()
        {
            _pairedPlayers = _playerPairer(new ReadOnlyCollection<IBasePlayer>(GetActivePlayers()));
        }

        protected void PostRoundAction()
        {
            _players.AwardByes();
            _sort(_players);
        }

        protected void PostDayAction()
        {
            AdvanceCurrentDay();
        }

        protected void PostTournamentAction()
        {
            _completed = true;
        }

        //private bool IsFinalDay()
        //{
        //    //(i == _days.Count - 1)
        //    return true;
        //}

        private void AdvanceCurrentDay()
        {
            _currentDay = _currentDay.Next;
        }
    }
}
