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
        private static readonly Dictionary<int, PlayerResult[]> _playerResults = new Dictionary<int, PlayerResult[]>();

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
            AddResults();
        }

        [TestMethod]
        public void GetPlayersTest()
        {
            ITournament tournament = TournamentFactory.CreateTournament(17, 5, false, false, false);
            Assert.IsNull(tournament.GetResults());
            tournament.Run();
            Assert.IsNotNull(tournament.GetResults());
        }

        /*[TestMethod]
        public void RunTest()
        {
            //DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 1));

            ITournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            tournament = TournamentFactory.CreateTournament(17, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[0];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(17, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[1];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => b - 1);
            mockRandom.Setup(p => p.Randomize(It.IsAny<IList<IBasePlayer>>())).Callback<IList<IBasePlayer>>((source) =>
            {
                for (int i = 0; i < source.Count; i++)
                {
                    int random = RandomData.Instance.Next(i, source.Count);
                    IBasePlayer temp = source[i];
                    source[i] = source[random];
                    source[random] = temp;
                }
            });

            tournament = TournamentFactory.CreateTournament(24, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[2];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(24, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[3];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(25, 5, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[4];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(25, 5, true, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[5];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(128, 7, false, false, false);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[6];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            tournament = TournamentFactory.CreateTournament(128, 7);
            SetGameWinPct(tournament);
            tournament.Run();
            results = tournament.GetResults();
            compResults = _playerResults[7];

            for (var i = 0; i < results.Count; ++i)
            {
                var p2 = (PlayerResult)results[i].GetRecords();
                var p1 = compResults[i];
                Assert.AreEqual(p1.Wins, p2.Wins);
                Assert.AreEqual(p1.Losses, p2.Losses);
                Assert.AreEqual(p1.Draws, p2.Draws);
            }

            //Undo the tinkering this test setup
            //DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 0.5m));
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();
        }*/

        private static void SetGameWinPct(ITournament tournament)
        {
            FieldInfo fi = tournament.GetType().GetField("_gameWinPct", BindingFlags.Instance | BindingFlags.NonPublic);
            fi?.SetValue(tournament, 1m);
        }

        [TestMethod]
        public void UnintentionalDrawTest()
        {
            DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 1));

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            bool passFlag = false;

            for (int runs = 0; runs < 10; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, false, true, false);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _playerResults[0];

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
            DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 0.5m));
            mockRandom.Reset();
            var randomData = new RandomData();
            randomData.SetInstance();

            Assert.Inconclusive("Did not find any variation in the results. Not proof of failure.");
        }

        [TestMethod]
        public void DoubleLossTest()
        {
            DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 1));

            var mockRandom = new Moq.Mock<RandomData> { CallBase = true };
            mockRandom.Setup(p => p.Next(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a);
            mockRandom.Object.SetInstance();

            bool passFlag = false;

            for (int runs = 0; runs < 100; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(17, 5, false, false, true);
                tournament.Run();
                var results = tournament.GetResults();
                var compResults = _playerResults[0];

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
            DeckSharedDatabase.Instance.Add(Deck.CreateDeck("Unknown", 0.5m));
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
                var compResults = _playerResults[0];

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
                var compResults = _playerResults[0];

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

        [TestMethod]
        public void StressTest()
        {
            for (int runs = 0; runs < 100000; ++runs)
            {
                var tournament = TournamentFactory.CreateTournament(101, 7, true, true, true);
                tournament.Run();
            }
        }

        private static void AddResults()
        {
            #region 17-5
            PlayerResult[] results =
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
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(2, 3, 0, 0),
                new PlayerResult(1, 4, 0, 0),
                new PlayerResult(1, 4, 0, 0),
                new PlayerResult(1, 4, 0, 0)
            };
            #endregion

            _playerResults.Add(0, results);

            #region 17-5
            results = new[]
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
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(2, 3, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0),
                          new PlayerResult(1, 4, 0, 0)
                      };
            #endregion

            _playerResults.Add(1, results);

            #region 24-5
            results = new[]
                      {
                          new PlayerResult(5, 0, 0, 0),
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
                          new PlayerResult(0, 5, 0, 0)
                      };
            #endregion

            _playerResults.Add(2, results);

            #region 24-5
            results = new[]
                      {
                          new PlayerResult(4, 0, 1, 0),
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
                          new PlayerResult(0, 5, 0, 0)
                      };
            #endregion

            _playerResults.Add(3, results);

            #region 25-5
            results = new[]
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
            #endregion

            _playerResults.Add(4, results);

            #region 25-5
            results = new[]
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
            #endregion

            _playerResults.Add(5, results);

            #region 128-7
            results = new[]
                      {
                          new PlayerResult(7, 0, 0, 0),
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
                          new PlayerResult(0, 7, 0, 0)
                      };
            #endregion

            _playerResults.Add(6, results);

            #region 128-7
            results = new[]
                      {
                          new PlayerResult(6, 0, 1, 0),
                          new PlayerResult(6, 0, 1, 0),
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
                          new PlayerResult(0, 7, 0, 0)
                      };
            #endregion

            _playerResults.Add(7, results);
        }
    }
}
