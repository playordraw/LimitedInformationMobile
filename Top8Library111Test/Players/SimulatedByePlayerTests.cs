// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedByePlayerTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Enums;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Utility;

namespace Top8LibraryTest.Players
{
    [TestClass]
    public class SimulatedByePlayerTests
    {
        [TestMethod]
        public void CtorTest()
        {
            var bp = new SimulatedByePlayer();
            Assert.IsNotNull(bp);
        }

        [TestMethod]
        public void CanDrawTest()
        {
            var bp = new SimulatedByePlayer();
            Assert.IsFalse(bp.CanDraw(null));
            Assert.IsFalse(bp.CanDraw(new CalculatedDrawState(1, 8, new IBasePlayer[] { bp, bp }, 0)));
        }

        [TestMethod]
        public void AddRecordTest()
        {
            var bp = new SimulatedByePlayer();

            var result = bp.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            bp.AddRecord(new CalculatedMatchRecord(bp, bp, true));
            result = bp.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);
        }

        [TestMethod]
        public void GetRecordsTest()
        {
            var bp = new SimulatedByePlayer();

            var result = bp.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            bp.AddRecord(new CalculatedMatchRecord(bp, bp, true));
            result = bp.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);
        }

        [TestMethod]
        public void ProjectPointsTest()
        {
            var bp = new SimulatedByePlayer();

            Assert.AreEqual(0, ((IProjectPoints)bp).ProjectPoints(2, Result.Win));
            Assert.AreEqual(0, ((IProjectPoints)bp).ProjectPoints(2, Result.Lose));
            Assert.AreEqual(0, ((IProjectPoints)bp).ProjectPoints(2, Result.Draw));
        }

        [TestMethod]
        public void CompareToTest()
        {
            //A bye player is always after anything, except itself.
            IBasePlayer bp1 = new SimulatedByePlayer();
            IBasePlayer bp2 = new SimulatedByePlayer();
            Assert.AreEqual(0, bp1.CompareTo(bp2));
            Assert.AreEqual(-1, bp1.CompareTo(new object()));
            Assert.AreEqual(-1, bp1.CompareTo(null));
            Assert.AreEqual(0, bp1.CompareTo(bp1));
        }

        [TestMethod]
        public void CompareTo2Test()
        {
            //A bye player is always after anything, except itself.
            IComparable<IBasePlayer> bp1 = new SimulatedByePlayer();
            IBasePlayer bp2 = new SimulatedByePlayer();
            Assert.AreEqual(0, bp1.CompareTo(bp2));
            Assert.AreEqual(-1, bp1.CompareTo(null));
            Assert.AreEqual(0, bp1.CompareTo((IBasePlayer)bp1));
        }

        [TestMethod]
        public void PlayedTest()
        {
            var bp = new SimulatedByePlayer();
            Assert.IsFalse(bp.Played(null));
            Assert.IsFalse(bp.Played(bp));
            Assert.IsFalse(bp.Played(new SimulatedByePlayer()));
            Assert.IsFalse(bp.Played(new CalculatedPlayer()));
            Assert.IsFalse(bp.Played(new SimulatedPlayer()));
        }

        [TestMethod]
        public void VsTest()
        {
            var player = new SimulatedByePlayer();
            Assert.AreEqual(0, player.Vs(null));
            Assert.AreEqual(0, player.Vs(new SimulatedByePlayer()));
            Assert.AreEqual(0, player.Vs(new SimulatedPlayer()));
        }
    }
}
