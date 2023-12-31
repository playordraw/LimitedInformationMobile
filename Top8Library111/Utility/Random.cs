// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Random.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
//using MathNet.Numerics.Random;

//namespace Top8Library.Utility
//{
//    internal class Random : RandomData
//    {
//        static Random()
//        {
//            //todo: should probably lock this for setting, just in case.
//            if (Instance == null)
//                Instance = new Random();
//        }

//        private Random()
//        {
//        }

//        private readonly MersenneTwister rng = new MersenneTwister();

//        public override int Next(int minValue, int maxValue)
//        {
//            return rng.Next(minValue, maxValue);
//        }

//        public override decimal NextDecimal()
//        {
//            return rng.NextDecimal();
//        }
//    }
//}
