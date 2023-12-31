// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: RandomData.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using MathNet.Numerics.Random;

namespace Top8Library.Utility
{
    //internal abstract class RandomData
    //{
    //    public static RandomData Instance { get; set; }

    //    public abstract int Next(int minValue, int maxValue);

    //    public abstract decimal NextDecimal();
    //}
    public class RandomData
    {
        private static readonly MersenneTwister rng = new MersenneTwister();

        private static RandomData _instance = new RandomData();

        public static RandomData Instance
        {
            get {return _instance;}
            protected set {_instance = value;}
        }

        public virtual void SetInstance()
        {
            Instance = this;
        }

        public virtual int Next(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue);
        }

        public virtual decimal NextDecimal()
        {
            return rng.NextDecimal();
        }
    }
}
