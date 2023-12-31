// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedPlayer.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Top8Library.Decks;
using Top8Library.Enums;
using Top8Library.POCOs;

namespace Top8Library.Players
{
    //[DebuggerDisplay("Win = {_wins}, Lose = {_losses}, Draw = {_draws}, Point = {_points}")]
    internal class SimulatedPlayer : IBasePlayer, IComparable<IBasePlayer>, IProjectPoints, IHasOdds
    {
        public SimulatedPlayer(int byes = 0, Deck deck = null, int context = 7)
        {
            _awardedByes = byes;
            _deck = deck;
            //_record = new LinkedList<SimulatedMatchRecord>();
            if (deck != null)
            {
                _deck = deck;
            }
            else if (!DeckSharedDatabase.Instance.TryGetValue("Unknown", out _deck))
            {
                _deck = DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", new List<KeyValuePair<Deck, decimal>>()));
            }
            _record = new Dictionary<IBasePlayer, SimulatedMatchRecord>(context);
        }

        internal SimulatedPlayer(string name) : this()
        {
            Name = name;
        }

        private int _awardedByes;
        private int _points;
        private int _wins;
        private int _losses;
        private int _draws;
        //private readonly LinkedList<SimulatedMatchRecord> _record;
        private readonly Dictionary<IBasePlayer, SimulatedMatchRecord> _record;
        private readonly Deck _deck;

        public bool HasBye => _awardedByes > 0;

        public bool HadBye { get; private set; }

        public string Name { get; set; }

        public void AwardBye()
        {
            if (!HasBye)
                return;

            AddRecord(new SimulatedMatchRecord(this, null, this, false));
            --_awardedByes;
        }

        public void GrantBye()
        {
            ++_awardedByes;
            HadBye = true;
        }

        public bool CanDraw(object gameState)
        {
            return CanDraw(gameState as SimulatedDrawState);
        }

        private bool CanDraw(SimulatedDrawState gameState)
        {
            return gameState != null && CanDraw(gameState.RoundsLeft, gameState.Top8SlotsLeft, gameState.Players);
        }

        private bool CanDraw(int rLeft, int top8, Stack<Tuple<IBasePlayer, IBasePlayer>> players)
        {
            if (top8 - players.Count * 2 >= 0)
                return true;

            var nextPair = players.Peek();
            if (nextPair.Item1.CompareTo(this) >= 0 && nextPair.Item2.CompareTo(this) >= 0)
                return false;

            double challengers;

            switch (rLeft)
            {
                case 1:
                    challengers = Math.Ceiling(CountChallengers(players, 1) * 0.5);
                    break;
                case 2:
                    var r1Challengers = CountChallengers(players, 1);
                    var r2Challengers = CountChallengers(players, 2) - r1Challengers;
                    challengers = Math.Ceiling(r1Challengers * 0.25) + Math.Floor(r1Challengers * 0.5) + Math.Ceiling(r2Challengers * 0.25);
                    break;
                default:
                    challengers = double.PositiveInfinity;
                    break;
            }

            return challengers <= top8;
        }

        private int CountChallengers(Stack<Tuple<IBasePlayer, IBasePlayer>> players, int roundsLeft)
        {
            var count = 0;
            foreach (var pair in players)
            {
                if (((IProjectPoints)pair.Item1).ProjectPoints(roundsLeft, Result.Win) >= ((IProjectPoints)this).ProjectPoints(roundsLeft, Result.Draw))
                {
                    ++count;
                }
                else
                {
                    break;
                }
                if (((IProjectPoints)pair.Item2)?.ProjectPoints(roundsLeft, Result.Win) >= ((IProjectPoints)this).ProjectPoints(roundsLeft, Result.Draw))
                {
                    ++count;
                }
            }
            return count;
        }

        public void AddRecord(object record)
        {
            AddRecord(record as SimulatedMatchRecord);
        }

        private void AddRecord(SimulatedMatchRecord record)
        {
            if (record.Opponent != null)
            {
                _record[record.Opponent] = record;
            }
            else
            {
                _record[new SimulatedByePlayer()] = record;
            }
            UpdateStats(record);
        }

        public object GetRecords()
        {
            //CalculateCurrentStats();
            return new PlayerResult(_wins, _losses, _draws, _points);
        }

        /*  private void CalculateCurrentStats()
         {
             if (_wins != null && _losses != null && _draws != null && _points != null)
                 return;

             _wins = _losses = _draws = 0;
             foreach (SimulatedMatchRecord match in _record)
                 switch (match.GetResult())
                 {
                     case Result.Win:
                         ++_wins;
                         break;
                     case Result.DoubleLoss:
                     case Result.Lose:
                         ++_losses;
                         break;
                     case Result.Draw:
                         ++_draws;
                         break;
                     default:
                         throw new ArgumentOutOfRangeException();
                 }
             _points = _wins * 3 + _draws;
         } */

        private void UpdateStats(SimulatedMatchRecord record)
        {
            //_wins = _losses = _draws = null;
            switch (record.GetResult())
            {
                case Result.Win:
                    ++_wins;
                    _points += 3;
                    break;
                case Result.DoubleLoss:
                case Result.Lose:
                    ++_losses;
                    break;
                case Result.Draw:
                    ++_draws;
                    ++_points;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int GetPoints()
        {
            //CalculateCurrentStats();
            return _points;
        }

        public bool Played(IBasePlayer other)
        {
            return Played(other as SimulatedPlayer);
        }

        public bool Played(SimulatedPlayer playerB)
        {
            if (playerB == null)
                return false;

            /* foreach (SimulatedMatchRecord match in _record)
                if (match.Opponent == playerB)
                    return true; */

            //return false;

            return _record.ContainsKey(playerB);
        }

        public int CompareTo(object other)
        {
            return CompareTo(other as SimulatedPlayer);
        }

        public int CompareTo(IBasePlayer other)
        {
            return CompareTo(other as SimulatedPlayer);
        }

        private int CompareTo(SimulatedPlayer other)
        {
            if (ReferenceEquals(null, other))
                return 1;

            return GetPoints().CompareTo(other.GetPoints());
        }

        public int ProjectPoints(int rounds, Result wld)
        {
            //CalculateCurrentStats();
            switch (wld)
            {
                case Result.Win:
                    return _points + 3 * rounds;
                case Result.Draw:
                    return _points + rounds;
                case Result.Lose:
                    return _points;
                default:
                    throw new ArgumentOutOfRangeException(nameof(wld), wld, null);
            }
        }

        public decimal Vs(IBasePlayer player)
        {
            return Vs(player as SimulatedPlayer);
        }

        public decimal Vs(SimulatedPlayer player)
        {
            if (player == null)
                return 1.0m;

            return _deck.GetOdds(player._deck);
        }
    }
}
