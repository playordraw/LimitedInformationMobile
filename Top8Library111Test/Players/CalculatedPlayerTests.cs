// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedPlayerTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Enums;
using Top8Library.Players;
using Top8Library.POCOs;

namespace Top8LibraryTest.Players
{
    [TestClass]
    public class CalculatedPlayerTests
    {
        private static readonly Dictionary<string, IBasePlayer[]> Scenarios = new Dictionary<string, IBasePlayer[]>();

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
            PopulateScenario1();
            PopulateScenario2();
            PopulateScenario3();
        }

        [TestMethod]
        public void CtorTest()
        {
            var player = new CalculatedPlayer();
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void CanDrawTest()
        {
            var player = new CalculatedPlayer();
            Assert.IsFalse(player.CanDraw((object)null));
            Assert.IsTrue(player.CanDraw((object)new CalculatedDrawState(1, 8, new IBasePlayer[] { player, player }, 0)));
            Assert.IsTrue(player.CanDraw((object)new CalculatedDrawState(1, 0, new IBasePlayer[] { player, player, player }, 0)));

            var roundsLeft = 1;

            var players = Scenarios["1-1"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-2"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-3"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-4"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-5"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-6"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-7"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-8"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-9"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-10"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-11"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-12"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-13"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-14"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-15"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-16"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-17"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["2-1"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-2"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-3"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-4"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-5"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-6"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-7"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-8"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-9"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-10"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-11"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-12"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-13"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-14"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-15"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-16"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-17"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["3-1"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-2"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-3"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-4"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-5"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-6"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-7"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-8"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-9"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-10"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-11"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-12"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-13"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-14"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-15"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-16"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-17"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["4-1"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-2"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-3"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-4"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-5"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-6"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-7"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-8"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-9"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-10"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-11"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-12"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-13"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-14"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-15"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-16"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-17"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));

            roundsLeft = 2;

            players = Scenarios["1-1"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-2"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-3"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-4"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-5"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-6"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-7"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-8"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-9"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-10"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-11"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-12"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-13"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-14"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-15"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["1-16"];
            Assert.IsTrue(players[1 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 1, players, 0)));
            players = Scenarios["2-1"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-2"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-3"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-4"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-5"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-6"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-7"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-8"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-9"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-10"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-11"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-12"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-13"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-14"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-15"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["2-16"];
            Assert.IsTrue(players[2 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 2, players, 0)));
            players = Scenarios["3-1"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-2"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-3"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-4"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-5"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-6"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-7"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-8"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-9"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-10"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-11"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-12"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-13"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-14"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-15"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["3-16"];
            Assert.IsTrue(players[3 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 3, players, 2)));
            players = Scenarios["4-1"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-2"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-3"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-4"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-5"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-6"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-7"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-8"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-9"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-10"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-11"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-12"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-13"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-14"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-15"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));
            players = Scenarios["4-16"];
            Assert.IsTrue(players[4 - 1].CanDraw(new CalculatedDrawState(roundsLeft, 8 - 4, players, 2)));

            players = new IBasePlayer[16];
            for (var i = 0; i < 16; ++i)
            {
                players[i] = new CalculatedPlayer();
            }
            Assert.IsFalse(player.CanDraw((object)new CalculatedDrawState(1, 0, players, 0)));

            players[0].AddRecord(new CalculatedMatchRecord(players[0], null, false));

            Assert.IsFalse(player.CanDraw((object)new CalculatedDrawState(3, 0, players, 0)));
        }

        [TestMethod]
        public void AddRecordTest()
        {
            var player = new CalculatedPlayer();

            var result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            player.AddRecord(new CalculatedMatchRecord(player, player, true));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(1, result.Points);

            player.AddRecord(new CalculatedMatchRecord(player, player, false));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(4, result.Points);

            player.AddRecord(new CalculatedMatchRecord(null, player, false));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(1, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(4, result.Points);
        }

        [TestMethod]
        public void GetRecordsTest()
        {
            var player = new CalculatedPlayer();

            var result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            player.AddRecord(new CalculatedMatchRecord(player, player, true));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(1, result.Points);

            player.AddRecord(new CalculatedMatchRecord(player, player, false));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(4, result.Points);

            player.AddRecord(new CalculatedMatchRecord(null, player, false));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(1, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(4, result.Points);
        }

        [TestMethod]
        public void ProjectPointsTest()
        {
            var player = new CalculatedPlayer();

            Assert.AreEqual(3, ((IProjectPoints)player).ProjectPoints(1, Result.Win));
            Assert.AreEqual(0, ((IProjectPoints)player).ProjectPoints(1, Result.Lose));
            Assert.AreEqual(1, ((IProjectPoints)player).ProjectPoints(1, Result.Draw));

            Assert.AreEqual(6, ((IProjectPoints)player).ProjectPoints(2, Result.Win));
            Assert.AreEqual(0, ((IProjectPoints)player).ProjectPoints(2, Result.Lose));
            Assert.AreEqual(2, ((IProjectPoints)player).ProjectPoints(2, Result.Draw));

            try
            {
                ((IProjectPoints)player).ProjectPoints(2, (Result)Int32.MaxValue);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CompareToTest()
        {
            //A bye player is always after anything, except itself.
            IBasePlayer player1 = new CalculatedPlayer();
            IBasePlayer player2 = new CalculatedPlayer();
            Assert.AreEqual(0, player1.CompareTo(player2));
            Assert.AreEqual(0, player1.CompareTo(player1));

            player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
            Assert.AreEqual(1, player1.CompareTo(player2));
            Assert.AreEqual(-1, player2.CompareTo(player1));
            Assert.AreEqual(0, player1.CompareTo(player1));

            Assert.AreEqual(1, player1.CompareTo(new ByePlayer()));

            Assert.AreEqual(1, player1.CompareTo(null));
            Assert.AreEqual(1, ((IBasePlayer)player1).CompareTo(null));
        }

        [TestMethod]
        public void PlayedTest()
        {
            var player = new CalculatedPlayer();
            var playera = new CalculatedPlayer();
            var playerb = new CalculatedPlayer();
            var playerc = new CalculatedPlayer();

            player.AddRecord(new CalculatedMatchRecord(player, player, false));
            player.AddRecord(new CalculatedMatchRecord(player, player, true));
            player.AddRecord(new CalculatedMatchRecord(player, player, false));
            player.AddRecord(new CalculatedMatchRecord(player, player, true));
            player.AddRecord(new CalculatedMatchRecord(player, player, false));
            player.AddRecord(new CalculatedMatchRecord(player, player, true));
            player.AddRecord(new CalculatedMatchRecord(player, player, false));

            Assert.IsFalse(player.Played(null));
            Assert.IsFalse(player.Played(playerb));
            Assert.IsFalse(player.Played(playera));
            Assert.IsFalse(player.Played(playerc));
        }

        private static void PopulateScenario1()
        {
            IBasePlayer player1 = new CalculatedPlayer();
            IBasePlayer player2 = new CalculatedPlayer();
            var players = new IBasePlayer[20];

            for (var j = 0; j < 3; ++j)
            {
                for (var i = 0; i < 3; ++i)
                {
                    player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                    player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                }
                players[j] = player1;
                players[19 - j] = player2;
                player1 = new CalculatedPlayer();
                player2 = new CalculatedPlayer();
            }

            for (var j = 0; j < 7; ++j)
            {
                player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player1.AddRecord(new CalculatedMatchRecord(player2, player1, false));
                player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player2.AddRecord(new CalculatedMatchRecord(player2, player1, false));
                player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                players[j + 3] = player1;
                players[16 - j] = player2;
                player1 = new CalculatedPlayer();
                player2 = new CalculatedPlayer();
            }

            Scenarios.Add("20-5-3", players);
        }

        private static void PopulateScenario2()
        {
            IBasePlayer player1 = new CalculatedPlayer();
            IBasePlayer player2 = new CalculatedPlayer();
            var players = new IBasePlayer[20];

            for (var j = 0; j < 3; ++j)
            {
                for (var i = 0; i < 3; ++i)
                {
                    player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                    player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                }
                players[j] = player1;
                players[19 - j] = player2;
                player1 = new CalculatedPlayer();
                player2 = new CalculatedPlayer();
            }

            for (var j = 0; j < 7; ++j)
            {
                player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player1.AddRecord(new CalculatedMatchRecord(player2, player1, false));
                player1.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                player2.AddRecord(new CalculatedMatchRecord(player2, player1, false));
                player2.AddRecord(new CalculatedMatchRecord(player1, player2, false));
                players[j + 3] = player1;
                players[16 - j] = player2;
                player1 = new CalculatedPlayer();
                player2 = new CalculatedPlayer();
            }

            players[0].AddRecord(new CalculatedMatchRecord(null, null, true));
            players[1].AddRecord(new CalculatedMatchRecord(null, null, true));

            for (var i = 2; i < 6; ++i)
            {
                players[i].AddRecord(new CalculatedMatchRecord(players[i], null, false));
            }

            for (var i = 6; i < 10; ++i)
            {
                players[i].AddRecord(new CalculatedMatchRecord(null, players[i], false));
            }

            for (var i = 10; i < 14; ++i)
            {
                players[i].AddRecord(new CalculatedMatchRecord(players[i], null, false));
            }

            for (var i = 14; i < 18; ++i)
            {
                players[i].AddRecord(new CalculatedMatchRecord(null, players[i], false));
            }

            players[18].AddRecord(new CalculatedMatchRecord(players[18], null, false));
            players[19].AddRecord(new CalculatedMatchRecord(null, players[19], false));

            Scenarios.Add("20-5-4", players);
        }

        private static void PopulateScenario3()
        {
            for (var i = 1; i < 5; ++i)
            {
                for (var j = 1; j < 18; ++j)
                {
                    var players = new IBasePlayer[j + i];
                    for (var k = 0; k < i; ++k)
                    {
                        players[k] = new CalculatedPlayer();
                        players[k].AddRecord(new CalculatedMatchRecord(players[k], null, false));
                    }
                    for (var k = i; k < j + i; ++k)
                    {
                        players[k] = new CalculatedPlayer();
                    }
                    Scenarios.Add($"{i}-{j}", players);
                }
            }
        }
    }
}
