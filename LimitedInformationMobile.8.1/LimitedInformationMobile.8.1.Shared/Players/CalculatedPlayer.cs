// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedPlayer.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
//using System.Diagnostics;
using Top8Library.Enums;
using Top8Library.POCOs;

namespace Top8Library.Players
{
    //[DebuggerDisplay("Win = {_wins}, Lose = {_losses}, Draw = {_draws}, Point = {_points}")]
    internal class CalculatedPlayer : IBasePlayer, IComparable<IBasePlayer>, IProjectPoints
    {
        private int _draws;
        private int _losses;
        private int _points;
        private int _wins;

        private bool CanDraw(CalculatedDrawState GameState)
        {
            return GameState != null && CanDraw(GameState.RoundsLeft, GameState.Top8SlotsLeft, GameState.Players, GameState.PairIndex);
        }

        private bool CanDraw(int rLeft, int top8, IBasePlayer[] players, int pairIndex)
        {
            if (players.Length <= 8)
                return true;

            double challengers;
            var nextPlayer = pairIndex + 2;

            if (nextPlayer >= players.Length)
                return true;

            if (players[pairIndex].CompareTo(players[pairIndex + 1]) == 0 && players[nextPlayer].CompareTo(players[nextPlayer + 1]) == 0 && CompareTo(players[nextPlayer]) == 0)
                return false;

            switch (rLeft)
            {
                case 1:
                    challengers = Math.Ceiling(CountChallengers(players, 1, nextPlayer) * 0.5);
                    break;
                case 2:
                    var r1Challengers = CountChallengers(players, 1, nextPlayer);
                    var r2Challengers = CountChallengers(players, 2, nextPlayer) - r1Challengers;
                    challengers = Math.Ceiling(r1Challengers * 0.25) + Math.Floor(r1Challengers * 0.5) + Math.Ceiling(r2Challengers * 0.25);
                    break;
                default:
                    challengers = double.PositiveInfinity;
                    break;
            }

            return challengers <= top8;
        }

        private void AddRecord(CalculatedMatchRecord Record)
        {
            if (Record != null)
            {
                if (Record.Drew)
                {
                    ++_draws;
                    ++_points;
                }
                else if (ReferenceEquals(this, Record.Winner))
                {
                    ++_wins;
                    _points += 3;
                }
                else if (ReferenceEquals(this, Record.Loser))
                {
                    ++_losses;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private int CountChallengers(IBasePlayer[] players, int roundsLeft, int nextPlayer)
        {
            var count = 0;
            for (var i = nextPlayer; i < players.Length; ++i)
            {
                if (((IProjectPoints)players[i]).ProjectPoints(roundsLeft, Result.Win) >= ((IProjectPoints)this).ProjectPoints(roundsLeft, Result.Draw))
                {
                    ++count;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        private int CompareTo(ByePlayer other)
        {
            return 1;
        }

        private int CompareTo(CalculatedPlayer other)
        {
            if (ReferenceEquals(null, other))
                return 1;

            return _points.CompareTo(other._points);
        }

        public bool CanDraw(object gameState)
        {
            return CanDraw(gameState as CalculatedDrawState);
        }

        public void AddRecord(object Record)
        {
            AddRecord(Record as CalculatedMatchRecord);
        }

        public object GetRecords()
        {
            return new PlayerResult(_wins, _losses, _draws, _points);
        }

        public bool Played(IBasePlayer other)
        {
            return false;
        }

        public int CompareTo(object other)
        {
            if (ReferenceEquals(null, other))
                return 1;

            if (other is CalculatedPlayer)
            {
                return CompareTo((CalculatedPlayer)other);
            }
            if (other is ByePlayer)
            {
                return CompareTo((ByePlayer)other);
            }
            if (other is IBasePlayer)
            {
                return CompareTo((IBasePlayer)other);
            }
            throw new NotSupportedException();
        }

        public int CompareTo(IBasePlayer other)
        {
            if (ReferenceEquals(null, other))
                return 1;

            //unkown player type, let the other player try to handle the comparison
            //Could blow the stack, but the other other alternative would be to throw an error anyways.
            return -other.CompareTo(this);
        }

        int IProjectPoints.ProjectPoints(int rounds, Result wld)
        {
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
    }
}
