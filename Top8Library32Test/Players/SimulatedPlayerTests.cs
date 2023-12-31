// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedPlayerTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Decks;
using Top8Library.Enums;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Utility;

namespace Top8LibraryTest.Players
{
    [TestClass]
    public class SimulatedPlayerTests
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
            var player = new SimulatedPlayer();
            Assert.IsNotNull(player);

            var deck = Deck.CreateDeck("testing", 0.5m);
            player = new SimulatedPlayer(0, deck);
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void CanDrawTest()
        {
            Assert.IsFalse(new SimulatedPlayer().CanDraw(null));

            var roundsLeft = 1;

            var players = Scenarios["1-1"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-2"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-3"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-4"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-5"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-6"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-7"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-8"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-9"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-10"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-11"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-12"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-13"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-14"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-15"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-16"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["1-17"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 0, CreateQueue(players, 1))));
            players = Scenarios["2-1"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-2"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-3"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-4"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-5"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-6"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-7"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-8"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-9"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-10"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-11"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-12"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-13"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-14"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-15"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-16"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["2-17"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 2))));
            players = Scenarios["3-1"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-2"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-3"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-4"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-5"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-6"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-7"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-8"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-9"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-10"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-11"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-12"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-13"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-14"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-15"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-16"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["3-17"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 3))));
            players = Scenarios["4-1"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-2"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-3"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-4"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-5"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-6"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-7"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-8"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-9"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-10"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-11"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-12"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-13"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-14"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-15"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-16"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));
            players = Scenarios["4-17"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 4))));

            roundsLeft = 2;

            players = Scenarios["1-1"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-2"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-3"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-4"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-5"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-6"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-7"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-8"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-9"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-10"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-11"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-12"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-13"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-14"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-15"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["1-16"];
            Assert.IsTrue(players[1 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 1, CreateQueue(players, 1))));
            players = Scenarios["2-1"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-2"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-3"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-4"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-5"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-6"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-7"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-8"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-9"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-10"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-11"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-12"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-13"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-14"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-15"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["2-16"];
            Assert.IsTrue(players[2 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 2, CreateQueue(players, 2))));
            players = Scenarios["3-1"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-2"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-3"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-4"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-5"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-6"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-7"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-8"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-9"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-10"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-11"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-12"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-13"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-14"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-15"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["3-16"];
            Assert.IsTrue(players[3 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 3, CreateQueue(players, 3))));
            players = Scenarios["4-1"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-2"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-3"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-4"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-5"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-6"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-7"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-8"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-9"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-10"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-11"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-12"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-13"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-14"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-15"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));
            players = Scenarios["4-16"];
            Assert.IsTrue(players[4 - 1].CanDraw(new SimulatedDrawState(roundsLeft, 8 - 4, CreateQueue(players, 4))));

            players = new IBasePlayer[16];
            for (var i = 0; i < 16; ++i)
            {
                players[i] = new SimulatedPlayer();
            }
            Assert.IsFalse(players[0].CanDraw(new SimulatedDrawState(1, 0, CreateQueue(players, 1))));

            players[0].AddRecord(new SimulatedMatchRecord(players[0], null, players[0], false));

            Assert.IsFalse(players[0].CanDraw(new SimulatedDrawState(3, 0, CreateQueue(players, 1))));
        }

        [TestMethod]
        public void GetRecordsTest()
        {
            var player = new SimulatedPlayer();

            var result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            player.AddRecord(new SimulatedMatchRecord(player, player, player, true));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(1, result.Points);

            player.AddRecord(new SimulatedMatchRecord(player, player, player, false));
            result = player.GetRecords() as PlayerResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(1, result.Draws);
            Assert.AreEqual(4, result.Points);

            bool pass = false;

            try
            {
                player.AddRecord(new SimulatedMatchRecord(player, player, null, false));
                player.GetRecords();
            }
            catch (InvalidOperationException)
            {
                pass = true;
            }

            Assert.IsTrue(pass);

            player.AddRecord(new SimulatedMatchRecord(player, player, null, false, true));
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
            var player = new SimulatedPlayer();

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
            IBasePlayer player1 = new SimulatedPlayer();
            IBasePlayer player2 = new SimulatedPlayer();
            Assert.AreEqual(0, player1.CompareTo(player2));
            Assert.AreEqual(0, player1.CompareTo(player1));

            player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
            Assert.AreEqual(1, player1.CompareTo(player2));
            Assert.AreEqual(-1, player2.CompareTo(player1));
            Assert.AreEqual(0, player1.CompareTo(player1));

            Assert.AreEqual(1, player1.CompareTo(null));

            Assert.AreEqual(1, ((IComparable<IBasePlayer>)player1).CompareTo(new SimulatedByePlayer()));
        }

        [TestMethod]
        public void AwardByeTest()
        {
            var player = new SimulatedPlayer();
            var result = player.GetRecords() as PlayerResult;
            Assert.IsFalse(player.HasBye);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);


            player.AwardBye();
            result = player.GetRecords() as PlayerResult;
            Assert.IsFalse(player.HasBye);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            player = new SimulatedPlayer(1);
            result = player.GetRecords() as PlayerResult;
            Assert.IsTrue(player.HasBye);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(0, result.Points);

            player.AwardBye();
            result = player.GetRecords() as PlayerResult;
            Assert.IsFalse(player.HasBye);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(3, result.Points);

            player.AwardBye();
            result = player.GetRecords() as PlayerResult;
            Assert.IsFalse(player.HasBye);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Wins);
            Assert.AreEqual(0, result.Losses);
            Assert.AreEqual(0, result.Draws);
            Assert.AreEqual(3, result.Points);
        }

        [TestMethod]
        public void PlayedTest()
        {
            var player = new SimulatedPlayer();
            var playera = new SimulatedPlayer();
            var playerb = new SimulatedPlayer();
            var playerc = new SimulatedPlayer();

            player.AddRecord(new SimulatedMatchRecord(player, playera, player, false));
            player.AddRecord(new SimulatedMatchRecord(player, player, player, true));
            player.AddRecord(new SimulatedMatchRecord(player, player, player, false));
            player.AddRecord(new SimulatedMatchRecord(player, playerb, player, true));
            player.AddRecord(new SimulatedMatchRecord(player, player, player, false));
            player.AddRecord(new SimulatedMatchRecord(player, player, player, true));
            player.AddRecord(new SimulatedMatchRecord(player, player, player, false));

            Assert.IsFalse(player.Played(null));
            Assert.IsTrue(player.Played(playerb));
            Assert.IsTrue(player.Played(playera));
            Assert.IsFalse(player.Played(playerc));
        }

        [TestMethod]
        public void VsTest()
        {
            var player = new SimulatedPlayer();
            Assert.AreEqual(1.0m, player.Vs(null));
            var save = RandomData.Instance;
            new RandomData().SetInstance();
            Assert.AreEqual(0.5m, player.Vs(new SimulatedPlayer()));
            save.SetInstance();
        }

        [TestMethod]
        public void CanDrawBug001()
        {
            /*
             * There seems to be a corner case bug causing a simulated tournament with the following setup to incorrectly draw a player who's simiarlly leveled players can't draw.
             */
            var players = new List<IBasePlayer>(17);
            for (int i = 0; i < 17; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            for (int i = 0; i < 3; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].GetRecords();
            }

            for (int i = 3; i < 9; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 9; i < 15; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 15; i < 17; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            var pairedPlayers = PlayerPairer.GetPlayerPairer()(players);

            int top8Slots = 8;
            int top8Pairs = top8Slots >> 1;
            Stack<Tuple<IBasePlayer, IBasePlayer>> drawing = new Stack<Tuple<IBasePlayer, IBasePlayer>>(top8Pairs);
            for (int i = 0; i < top8Pairs; ++i)
            {
                drawing.Push(pairedPlayers.Pop());
            }

            Assert.IsFalse(drawing.Peek().Item2.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));
            Assert.IsFalse(drawing.Peek().Item1.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));

            pairedPlayers.Push(drawing.Pop());

            Assert.IsFalse(drawing.Peek().Item2.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));
            Assert.IsFalse(drawing.Peek().Item1.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));

            pairedPlayers.Push(drawing.Pop());

            Assert.IsFalse(drawing.Peek().Item2.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));
            Assert.IsTrue(drawing.Peek().Item1.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));

            pairedPlayers.Push(drawing.Pop());

            Assert.IsTrue(drawing.Peek().Item2.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));
            Assert.IsTrue(drawing.Peek().Item1.CanDraw(new SimulatedDrawState(2, top8Slots - drawing.Count * 2, pairedPlayers)));

            pairedPlayers.Push(drawing.Pop());

            Assert.AreEqual(0, drawing.Count);
        }

        private static void PopulateScenario1()
        {
            IBasePlayer player1 = new SimulatedPlayer();
            IBasePlayer player2 = new SimulatedPlayer();
            var players = new IBasePlayer[20];

            for (var j = 0; j < 3; ++j)
            {
                for (var i = 0; i < 3; ++i)
                {
                    player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                    player2.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                }
                players[j] = player1;
                players[19 - j] = player2;
                player1 = new SimulatedPlayer();
                player2 = new SimulatedPlayer();
            }

            for (var j = 0; j < 7; ++j)
            {
                player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                player1.AddRecord(new SimulatedMatchRecord(player2, player1, player2, false));
                player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                player2.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                player2.AddRecord(new SimulatedMatchRecord(player2, player1, player2, false));
                player2.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                players[j + 3] = player1;
                players[16 - j] = player2;
                player1 = new SimulatedPlayer();
                player2 = new SimulatedPlayer();
            }

            Scenarios.Add("20-5-3", players);
        }

        private static void PopulateScenario2()
        {
            IBasePlayer player1 = new SimulatedPlayer();
            IBasePlayer player2 = new SimulatedPlayer();
            var players = new IBasePlayer[20];

            for (var j = 0; j < 3; ++j)
            {
                for (var i = 0; i < 3; ++i)
                {
                    player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                    player2.AddRecord(new SimulatedMatchRecord(player2, player1, player1, false));
                }
                players[j] = player1;
                players[19 - j] = player2;
                player1 = new SimulatedPlayer();
                player2 = new SimulatedPlayer();
            }

            for (var j = 0; j < 7; ++j)
            {
                player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                player1.AddRecord(new SimulatedMatchRecord(player1, player2, player2, false));
                player1.AddRecord(new SimulatedMatchRecord(player1, player2, player1, false));
                player2.AddRecord(new SimulatedMatchRecord(player2, player1, player1, false));
                player2.AddRecord(new SimulatedMatchRecord(player2, player1, player2, false));
                player2.AddRecord(new SimulatedMatchRecord(player2, player1, player1, false));
                players[j + 3] = player1;
                players[16 - j] = player2;
                player1 = new SimulatedPlayer();
                player2 = new SimulatedPlayer();
            }

            players[0].AddRecord(new SimulatedMatchRecord(players[0], null, null, true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], null, null, true));

            for (var i = 2; i < 6; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
            }

            for (var i = 6; i < 10; ++i)
            {
                var randomGuy = new SimulatedPlayer();
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            }

            for (var i = 10; i < 14; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], null, players[i], false));
            }

            for (var i = 14; i < 18; ++i)
            {
                var randomGuy = new SimulatedPlayer();
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            }

            var randomGuy2 = new SimulatedPlayer();
            players[18].AddRecord(new SimulatedMatchRecord(players[18], null, players[18], false));
            players[19].AddRecord(new SimulatedMatchRecord(players[19], randomGuy2, randomGuy2, false));

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
                        players[k] = new SimulatedPlayer();
                        players[k].AddRecord(new SimulatedMatchRecord(players[k], null, players[k], false));
                    }
                    for (var k = i; k < j + i; ++k)
                    {
                        players[k] = new SimulatedPlayer();
                    }
                    Scenarios.Add($"{i}-{j}", players);
                }
            }
        }

        private Stack<Tuple<IBasePlayer, IBasePlayer>> CreateQueue(IBasePlayer[] players, int offset)
        {
            Stack<Tuple<IBasePlayer, IBasePlayer>> temp = new Stack<Tuple<IBasePlayer, IBasePlayer>>();

            for (int i = offset + 1; i < players.Length; i += 2)
            {
                temp.Push(new Tuple<IBasePlayer, IBasePlayer>(players[i - 1], players[i]));
            }

            if (offset < players.Length && ((players.Length - offset) & 1) == 1)
            {
                temp.Push(new Tuple<IBasePlayer, IBasePlayer>(players[players.Length - 1], null));
            }

            var retVal = new Stack<Tuple<IBasePlayer, IBasePlayer>>();

            while (temp.Count > 0)
            {
                retVal.Push(temp.Pop());
            }

            return retVal;
        }
    }
}
