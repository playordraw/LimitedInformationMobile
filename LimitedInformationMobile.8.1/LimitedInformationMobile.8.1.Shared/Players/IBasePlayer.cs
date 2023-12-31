// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: IBasePlayer.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;

namespace Top8Library.Players
{
    internal interface IBasePlayer : IComparable
    {
        bool CanDraw(object gameState);
        void AddRecord(object Record);
        object GetRecords();
        bool Played(IBasePlayer other);
    }
}
