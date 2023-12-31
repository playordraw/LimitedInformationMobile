// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: StatisticalStanding.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Statistics;

namespace ViewModel.POCOs
{
    public class StatisticalStanding
    {
        internal StatisticalStanding(int place, RunningStatistics stats)
        {
            Place = place;
            _stats = stats;
        }

        private readonly RunningStatistics _stats;

        public int Place { get; }

        public double Mean => _stats.Mean;

        public double Max => _stats.Maximum;

        public double Min => _stats.Minimum;

        public double Std => _stats.StandardDeviation;
    }
}
