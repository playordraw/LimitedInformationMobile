// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedTournamentTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Top8Library.Decks;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Tournaments;
using Top8Library.Utility;

namespace Top8LibraryTest.Tournaments
{
    [TestClass]
    public class SimulatedTournamentTests
    {
        /*[ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
            
        }*/

        [TestMethod]
        public void GetPlayersTest()
        {
            ITournament tournament = TournamentFactory.CreateTournament(17, 5, false, false, false);
            Assert.IsNull(tournament.GetResults());
            tournament.Run();
            Assert.IsNotNull(tournament.GetResults());
        }

        //TODO: Look at this test. Fix or remove if its not valid anymore. I think i commented it out because this test will never work the for simulated tournament.
        // I think Because of the way simulated tournament pairs playes, the results are not going to match the same results from the calculated tournament which gave byes always to the lowest player.
        //tournament = TournamentFactory.CreateTournament(24, 5, true, false, false);

        [TestMethod]
        public void Simulated_17P_1R_NotRun()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 1, false, false, false);
            SetGameWinPct(tournament);

            var results = tournament.GetResults();

            Assert.AreEqual(null, results);

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_1R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 1, false, false, false);
            SetGameWinPct(tournament);

            tournament.Run();
            var results = tournament.GetResults();
            var compResults = _17P_1R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_2R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 2, false, false, false);
            SetGameWinPct(tournament);

            tournament.Run();
            var results = tournament.GetResults();
            var compResults = _17P_2R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_3R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 3, false, false, false);
            SetGameWinPct(tournament);

            tournament.Run();
            var results = tournament.GetResults();
            var compResults = _17P_3R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_4R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 4, false, false, false);
            SetGameWinPct(tournament);

            tournament.Run();
            var results = tournament.GetResults();
            var compResults = _17P_4R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_5R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            ITournament tournament = TournamentFactory.CreateTournament(17, 5, false, false, false);
            SetGameWinPct(tournament);

            tournament.Run();
            var results = tournament.GetResults();
            var compResults = _17P_5R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_17P_5R_NoRandom_P1Wins_IntentionalDraws()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });
            mockRandom.Object.SetInstance();

            tournament = TournamentFactory.CreateTournament(17, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _17P_5R_NoRandom_P1Wins_IntentionalDraws;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_24P_5R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(24, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _24P_5R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_24P_5R_NoRandom_P1Wins_IntentionalDraws()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(24, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _24P_5R_NoRandom_P1Wins_IntentionalDraws;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_25P_5R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(25, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _25P_5R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_25P_5R_NoRandom_P1Wins_IntentionalDraws()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });


            tournament = TournamentFactory.CreateTournament(25, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _25P_5R_NoRandom_P1Wins_IntentionalDraws;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_1R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 1, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_1R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_2R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 2, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_2R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_3R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 3, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_3R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_4R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 4, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_4R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_5R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_5R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_6R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 6, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_6R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_7R_NoRandom_P1Wins()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 7, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_7R_NoRandom_P1Wins;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        [TestMethod]
        public void Simulated_128P_7R_NoRandom_P1Wins_IntentionalDraws()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Object.SetInstance();

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Setup(p => p.NextDecimal()).Returns(1m);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {

            });

            tournament = TournamentFactory.CreateTournament(128, 7, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _128P_7R_NoRandom_P1Wins_IntentionalDraws;

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }

        private static void SetGameWinPct(ITournament tournament)
        {
            FieldInfo fi = tournament.GetType().GetField("_gameWinPct", BindingFlags.Instance | BindingFlags.NonPublic);
            fi?.SetValue(tournament, 1m);
        }

        /// <summary>
        /// This test is testing to make sure unintential draws happen.
        /// All (other) randomness has been removed for predictibility.
        /// If at any point we encounter a record that does not match the expected output, the test is a pass and must return since there is no assert.pass
        /// </summary>
        [TestMethod]
        public void UnintentionalDrawTest()
        {
            Deck deck = Deck.CreateDeck($"Unknown{Guid.NewGuid().ToString()}", 1);
            DeckSharedDatabase.Instance.Add(deck);

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            bool passFlag = false;

            for (int runs = 0; runs < 10; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, false, true, false, deck);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _17P_5R_NoRandom_P1Wins;

                for (var i = 0; i < results.Count; ++i)
                {
                    var p2 = (PlayerResult)results[i].GetRecords();
                    var p1 = compResults[i];
                    if (p1.Wins != p2.Wins)
                        passFlag = true;
                    if (p1.Losses != p2.Losses)
                        passFlag = true;
                    if (p1.Draws != p2.Draws)
                        passFlag = true;

                    if (passFlag)
                        return;
                }
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();

            Assert.Inconclusive("Did not find any variation in the results. Not proof of failure.");
        }

        [TestMethod]
        public void DoubleLossTest()
        {
            DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown" + Guid.NewGuid(), 1));

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            bool passFlag = false;

            for (int runs = 0; runs < 100; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, false, false, true);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _17P_5R_NoRandom_P1Wins;

                for (var i = 0; i < results.Count; ++i)
                {
                    var p2 = (PlayerResult)results[i].GetRecords();
                    var p1 = compResults[i];
                    if (p1.Wins != p2.Wins)
                        passFlag = true;
                    if (p1.Losses != p2.Losses)
                        passFlag = true;
                    if (p1.Draws != p2.Draws)
                        passFlag = true;

                    if (passFlag)
                        return;
                }
            }

            //Undo the tinkering this test setup
            //DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 0.5m));
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();

            Assert.Inconclusive("Did not find any variation in the results. Not proof of failure.");
        }

        [TestMethod]
        public void RandomWinTest()
        {
            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            bool passFlag = false;

            for (int runs = 0; runs < 1000; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, false, false, false);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _17P_5R_NoRandom_P1Wins;

                for (var i = 0; i < results.Count; ++i)
                {
                    var p2 = (PlayerResult)results[i].GetRecords();
                    var p1 = compResults[i];
                    if (p1.Wins != p2.Wins)
                        passFlag = true;
                    if (p1.Losses != p2.Losses)
                        passFlag = true;
                    if (p1.Draws != p2.Draws)
                        passFlag = true;

                    if (passFlag)
                        return;
                }
            }

            //Undo the tinkering this test setup
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();

            Assert.Inconclusive("Did not find any variation in the results. Not proof of failure.");
        }

        [TestMethod]
        public void EverythingOnTest()
        {
            bool passFlag = false;

            for (int runs = 0; runs < 10; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, true, true, true);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _17P_5R_NoRandom_P1Wins;

                for (var i = 0; i < results.Count; ++i)
                {
                    var p2 = (PlayerResult)results[i].GetRecords();
                    var p1 = compResults[i];
                    if (p1.Wins != p2.Wins)
                        passFlag = true;
                    if (p1.Losses != p2.Losses)
                        passFlag = true;
                    if (p1.Draws != p2.Draws)
                        passFlag = true;

                    if (passFlag)
                        return;
                }
            }

            Assert.Inconclusive("Did not find any variation in the results. Not proof of failure.");
        }

        /*[TestMethod]
        public void StressTest()
        {
            for (int runs = 0; runs < 100000; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(101, 7, true, true, true);
                tournament.Run();
            }
        }*/

        private readonly PlayerResult[] _17P_1R_NoRandom_P1Wins =
        {
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(1, 0, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0),
            new PlayerResult(0, 1, 0, 0)
        };

        private readonly PlayerResult[] _17P_2R_NoRandom_P1Wins =
        {
            new PlayerResult(2, 0, 0, 0),
            new PlayerResult(2, 0, 0, 0),
            new PlayerResult(2, 0, 0, 0),
            new PlayerResult(2, 0, 0, 0),
            new PlayerResult(2, 0, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(1, 1, 0, 0),
            new PlayerResult(0, 2, 0, 0),
            new PlayerResult(0, 2, 0, 0),
            new PlayerResult(0, 2, 0, 0),
            new PlayerResult(0, 2, 0, 0)
        };

        private readonly PlayerResult[] _17P_3R_NoRandom_P1Wins =
        {
            new PlayerResult(3, 0, 0, 0),
            new PlayerResult(3, 0, 0, 0),
            new PlayerResult(3, 0, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(2, 1, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(1, 2, 0, 0),
            new PlayerResult(0, 3, 0, 0),
            new PlayerResult(0, 3, 0, 0)
        };

        private readonly PlayerResult[] _17P_4R_NoRandom_P1Wins =
        {
            new PlayerResult(4, 0, 0, 0),
            new PlayerResult(4, 0, 0, 0),
            new PlayerResult(3, 1, 0, 0),
            new PlayerResult(3, 1, 0, 0),
            new PlayerResult(3, 1, 0, 0),
            new PlayerResult(3, 1, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(2, 2, 0, 0),
            new PlayerResult(1, 3, 0, 0),
            new PlayerResult(1, 3, 0, 0),
            new PlayerResult(1, 3, 0, 0),
            new PlayerResult(1, 3, 0, 0),
            new PlayerResult(0, 4, 0, 0)
        };

        private readonly PlayerResult[] _17P_5R_NoRandom_P1Wins =
        {
                new PlayerResult(5, 0, 0, 0),
                new PlayerResult(4, 1, 0, 0),
                new PlayerResult(4, 1, 0, 0),
                new PlayerResult(4, 1, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(3, 2, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(1, 4, 0, 0),
                new PlayerResult(1, 4, 0, 0),
                new PlayerResult(1, 4, 0, 0),
                new PlayerResult(1, 4, 0, 0)
            };

        private readonly PlayerResult[] _17P_5R_NoRandom_P1Wins_IntentionalDraws =
                  {
                          new PlayerResult(4, 0, 1, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0)
                      };

        private readonly PlayerResult[] _24P_5R_NoRandom_P1Wins =
                  {
                          new PlayerResult(5, 0, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(0, 5, 0, 0)
                      };

        private readonly PlayerResult[] _24P_5R_NoRandom_P1Wins_IntentionalDraws =
                  {
                          new PlayerResult(4, 0, 1, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 1, 1, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(0, 5, 0, 0)
                      };

        private readonly PlayerResult[] _25P_5R_NoRandom_P1Wins =
                  {
                          new PlayerResult(5, 0, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0)
                      };

        private readonly PlayerResult[] _25P_5R_NoRandom_P1Wins_IntentionalDraws =
                  {
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(4, 1, 0, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 0, 2, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(3, 2, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0)
                      };

        private readonly PlayerResult[] _128P_7R_NoRandom_P1Wins =
                  {
                          new PlayerResult(7, 0, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(0, 7, 0, 0)
                      };

        private readonly PlayerResult[] _128P_1R_NoRandom_P1Wins = {new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(1, 0, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
new PlayerResult(0, 1, 0, 0),
};

        private readonly PlayerResult[] _128P_2R_NoRandom_P1Wins = {new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(2, 0, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(1, 1, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
new PlayerResult(0, 2, 0, 0),
};

        private readonly PlayerResult[] _128P_3R_NoRandom_P1Wins = {new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(3, 0, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(2, 1, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(1, 2, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
new PlayerResult(0, 3, 0, 0),
};

        private readonly PlayerResult[] _128P_4R_NoRandom_P1Wins = {
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(4, 0, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(3, 1, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(2, 2, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(1, 3, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
new PlayerResult(0, 4, 0, 0),
};

        private readonly PlayerResult[] _128P_5R_NoRandom_P1Wins = {
new PlayerResult(5, 0, 0, 0),
new PlayerResult(5, 0, 0, 0),
new PlayerResult(5, 0, 0, 0),
new PlayerResult(5, 0, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(4, 1, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(3, 2, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(2, 3, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(1, 4, 0, 0),
new PlayerResult(0, 5, 0, 0),
new PlayerResult(0, 5, 0, 0),
new PlayerResult(0, 5, 0, 0),
new PlayerResult(0, 5, 0, 0),
};

        private readonly PlayerResult[] _128P_6R_NoRandom_P1Wins = {

new PlayerResult(6, 0, 0, 0),
new PlayerResult(6, 0, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(5, 1, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(4, 2, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(3, 3, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(2, 4, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(1, 5, 0, 0),
new PlayerResult(0, 6, 0, 0),
new PlayerResult(0, 6, 0, 0),

};

        private readonly PlayerResult[] _128P_7R_NoRandom_P1Wins_IntentionalDraws =
                  {
                          new PlayerResult(6, 0, 1, 0),
                          new PlayerResult(6, 0, 1, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(6, 1, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(5, 2, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(4, 3, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(3, 4, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(2, 5, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(1, 6, 0, 0),
                          new PlayerResult(0, 7, 0, 0)
                      };
    }
}
