// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: RandomData.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Collections.Generic;
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

        public virtual int Next(int minInclusive, int maxExclusive)
        {
            return rng.Next(minInclusive, maxExclusive);
        }

        public virtual decimal NextDecimal()
        {
            return rng.NextDecimal();
        }

        public virtual void Randomize<T>(IList<T> source)
        {
            for (int i = source.Count - 1; i > 0; --i)
            {
                int random = RandomData.Instance.Next(0, i + 1);
                T temp = source[i];
                source[i] = source[random];
                source[random] = temp;
            }
            /*for (int i = 0; i < source.Count; i++)
            {
                int random = RandomData.Instance.Next(i, source.Count);
                T temp = source[i];
                source[i] = source[random];
                source[random] = temp;
            }*/
        }
    }
}
