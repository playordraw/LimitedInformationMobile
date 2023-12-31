// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: IProjectPoints.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using Top8Library.Enums;

namespace Top8Library.Players
{
    internal interface IProjectPoints
    {
        int ProjectPoints(int rounds, Result wld);
    }
}
