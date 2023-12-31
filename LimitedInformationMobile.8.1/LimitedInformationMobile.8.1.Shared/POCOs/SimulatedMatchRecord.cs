// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedMatchRecord.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Top8Library.Enums;
using Top8Library.Players;

namespace Top8Library.POCOs
{
    internal class SimulatedMatchRecord
    {
        private readonly IBasePlayer _winner;
        private readonly IBasePlayer _player;
        private readonly IBasePlayer _opponent;
        private readonly bool _drew;
        private readonly bool _doubleLoss;

        public SimulatedMatchRecord(IBasePlayer player, IBasePlayer opponent, IBasePlayer winner, bool drew) : this(player, opponent, winner, drew, false)
        {
        }

        public SimulatedMatchRecord(IBasePlayer player, IBasePlayer opponent, IBasePlayer winner, bool drew, bool doubleLoss)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player), "Cannot be null.");
            _player = player;
            _opponent = opponent;
            _winner = winner;
            _drew = drew;
            _doubleLoss = doubleLoss;

            if (!Won() &&
                !Lost() &&
                !Drew() &&
                !DoubleLoss())
                throw new InvalidOperationException();
        }

        public IBasePlayer Opponent => _opponent;

        private bool Won()
        {
            return _player.Equals(_winner) &&
                   !_drew &&
                   !_doubleLoss;
        }

        private bool Drew()
        {
            return _drew;
        }

        private bool DoubleLoss()
        {
            return _doubleLoss;
        }

        private bool Lost()
        {
            return _opponent != null &&
                   _opponent.Equals(_winner) &&
                   !_drew &&
                   !_doubleLoss;
        }

        public Result GetResult()
        {
            if (Won())
                return Result.Win;
            if (Lost())
                return Result.Lose;
            if (Drew())
                return Result.Draw;
            if (DoubleLoss())
                return Result.DoubleLoss;

            throw new InvalidOperationException();
        }
    }
}
