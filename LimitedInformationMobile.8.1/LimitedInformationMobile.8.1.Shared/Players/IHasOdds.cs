// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: IHasOdds.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
namespace Top8Library.Players
{
    internal interface IHasOdds
    {
        decimal Vs(IBasePlayer player);
    }
}
