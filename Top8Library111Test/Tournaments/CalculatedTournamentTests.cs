// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: CalculatedTournamentTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Tournaments;

namespace Top8LibraryTest.Tournaments
{
    [TestClass]
    public class CalculatedTournamentTests
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
            ITournament tournament = new CalculatedTournament(1, 1);
            Assert.IsNull(tournament.GetResults());
            tournament.Run();
            Assert.IsNotNull(tournament.GetResults());
        }

        [TestMethod]
        public void RunTest()
        {
            CalculatedTournament tournament;
            ReadOnlyCollection<IBasePlayer> results;
            PlayerResult[] compResults;

            tournament = new CalculatedTournament(17, 5, false);
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

            tournament = new CalculatedTournament(17, 5);
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

            tournament = new CalculatedTournament(24, 5, false);
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

            tournament = new CalculatedTournament(24, 5);
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

            tournament = new CalculatedTournament(25, 5, false);
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

            tournament = new CalculatedTournament(25, 5);
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

            tournament = new CalculatedTournament(128, 7, false);
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

            tournament = new CalculatedTournament(128, 7);
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
