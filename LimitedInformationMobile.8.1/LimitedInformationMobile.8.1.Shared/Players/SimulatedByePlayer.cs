// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedByePlayer.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Top8Library.Enums;
using Top8Library.POCOs;

namespace Top8Library.Players
{
    internal class SimulatedByePlayer : IBasePlayer, IComparable<IBasePlayer>, IProjectPoints, IHasOdds
    {
        public bool CanDraw(object gameState)
        {
            return false;
        }

        public void AddRecord(object Record)
        {
        }

        public object GetRecords()
        {
            return new PlayerResult(0, 0, 0, 0);
        }

        public bool Played(IBasePlayer other)
        {
            var sp = other as SimulatedPlayer;
            return sp != null && sp.HadBye;
        }

        public int CompareTo(object other)
        {
            return CompareTo(other as IBasePlayer);
        }

        public int CompareTo(IBasePlayer other)
        {
            if (ReferenceEquals(this, other))
                return 0;
            if (other is SimulatedByePlayer)
                return 0;
            return -1;
        }

        int IProjectPoints.ProjectPoints(int rounds, Result wld)
        {
            return 0;
        }

        public decimal Vs(IBasePlayer player)
        {
            return 0;
        }
    }
}
