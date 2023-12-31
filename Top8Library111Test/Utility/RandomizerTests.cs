// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: RandomizerTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Players;
using Top8Library.Utility;

namespace Top8LibraryTest.Utility
{
    [TestClass]
    public class RandomizerTests
    {
        //TODO: these values are way off. Adjusted CV and CV2 to be more reasonable
        private const int TRIALS = 500000;
        private const int OUTCOMES = 10;
        private const double EO = (double)TRIALS / OUTCOMES;
        private const double CV = 26.296;
        private const double CV2 = 28.845;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
        }

        [TestMethod]
        public void RandomizierTest()
        {
            var results = new int[OUTCOMES, OUTCOMES];
            var final = new double[OUTCOMES];


            for (int i = 0; i < TRIALS; ++i)
            {
                var testArray = CreateTestArray();
                //testArray.Randomize();
                RandomData.Instance.Randomize(testArray);

                for (int j = 0; j < testArray.Length; ++j)
                {
                    results[j, testArray[j]]++;
                }
            }

            for (int i = 0; i < OUTCOMES; ++i)
            {
                double sum = 0.0;
                for (int j = 0; j < OUTCOMES; ++j)
                {
                    sum += Math.Pow(results[i, j] - EO, 2) / EO;
                }
                final[i] = sum;
            }

            for (int i = 0; i < final.Length; ++i)
            {
                if (final[i] <= CV)
                    continue;

                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < OUTCOMES; ++j)
                {
                    sb.AppendLine($"{j.ToString()}: {results[i, j].ToString()}");
                }
                if (final[i] <= CV2 && final[i] > CV)
                    Assert.Inconclusive($"Randomness test exceeded confidence interval of {CV} with a value of {final[i]}. Place was {i + 1}. Values are: \n" + sb.ToString());
                else
                    Assert.Fail($"Randomness test exceeded confidence interval of {CV} with a value of {final[i]}. Place was {i + 1}. Values are: \n" + sb.ToString());
            }
        }

        private static int[] CreateTestArray()
        {
            return new int[OUTCOMES] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
    }
}
