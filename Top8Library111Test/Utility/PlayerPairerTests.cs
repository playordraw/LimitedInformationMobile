// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlayerPairerTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Enums;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Utility;

namespace Top8LibraryTest.Utility
{
    [TestClass]
    public class PlayerPairerTests
    {

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
        }

        [TestMethod]
        public void TestPairing()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();

            var players = CreateScenario01();
            sorter(players);
            var queued = parier(players);

            var item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "1" && ((SimulatedPlayer)item.Item1).Name != "2")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "1" && ((SimulatedPlayer)item.Item2).Name != "2")
                Assert.Fail();
            item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "3" && ((SimulatedPlayer)item.Item1).Name != "4")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "3" && ((SimulatedPlayer)item.Item2).Name != "4")
                Assert.Fail();


            players = CreateScenario02();
            sorter(players);
            queued = parier(players);

            item = queued.Pop();
            Assert.AreEqual("1", ((SimulatedPlayer)item.Item1).Name);
            Assert.AreNotEqual("1", ((SimulatedPlayer)item.Item2).Name);
            Assert.AreEqual(1, item.Item1.CompareTo(item.Item2));
            item = queued.Pop();
            Assert.AreEqual(0, item.Item1.CompareTo(item.Item2));


            players = CreateScenario03();
            sorter(players);
            queued = parier(players);

            item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "1" && ((SimulatedPlayer)item.Item1).Name != "4")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "1" && ((SimulatedPlayer)item.Item2).Name != "4")
                Assert.Fail();
            item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "3" && ((SimulatedPlayer)item.Item1).Name != "2")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "3" && ((SimulatedPlayer)item.Item2).Name != "2")
                Assert.Fail();

            players = CreateScenario04();
            sorter(players);
            queued = parier(players);

            item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "1" && ((SimulatedPlayer)item.Item1).Name != "4")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "3" && ((SimulatedPlayer)item.Item2).Name != "2")
                Assert.Fail();
            Assert.AreEqual(1, item.Item1.CompareTo(item.Item2));
            item = queued.Pop();
            if (((SimulatedPlayer)item.Item1).Name != "1" && ((SimulatedPlayer)item.Item1).Name != "4")
                Assert.Fail();
            if (((SimulatedPlayer)item.Item2).Name != "3" && ((SimulatedPlayer)item.Item2).Name != "2")
                Assert.Fail();
            Assert.AreEqual(1, item.Item1.CompareTo(item.Item2));
        }

        [TestMethod]
        public void TestPairing2()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;
            Tuple<IBasePlayer, IBasePlayer> last;
            IBasePlayer playerA;
            IBasePlayer playerB;


            players = CreateScenario05();
            sorter(players);
            queued = parier(players).Reverse();

            last = queued.ElementAt(0);
            Assert.IsNotNull(last.Item2);
            Assert.IsFalse(last.Item1.Played(last.Item2));
            Assert.AreNotEqual(0, last.Item1.CompareTo(last.Item2));
            playerA = last.Item1.CompareTo(last.Item2) == 1 ? last.Item2 : last.Item1;
            last = queued.ElementAt(1);
            Assert.IsNotNull(last.Item2);
            Assert.IsFalse(last.Item1.Played(last.Item2));
            Assert.AreNotEqual(0, last.Item1.CompareTo(last.Item2));
            playerB = last.Item1.CompareTo(last.Item2) == 1 ? last.Item2 : last.Item1;
            Assert.IsTrue(playerA.Played(playerB));
            last = queued.ElementAt(2);
            Assert.IsNotNull(last.Item2);
            Assert.IsFalse(last.Item1.Played(last.Item2));
            Assert.AreEqual(0, last.Item1.CompareTo(last.Item2));
            last = null;

            players = CreateScenario06();
            sorter(players);
            queued = parier(players);

            playerA = null;
            playerB = null;

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                var record = (PlayerResult)pair.Item2.GetRecords();
                if (record.Wins > 0)
                    continue;

                Assert.IsFalse(pair.Item1.Played(pair.Item2));
                Assert.AreNotEqual(0, pair.Item1.CompareTo(pair.Item2));
                if (playerA == null)
                    playerA = pair.Item2;
                else
                {
                    playerB = pair.Item2;
                }
            }

            Assert.IsNotNull(playerA);
            Assert.IsNotNull(playerB);
            Assert.IsTrue(playerA.Played(playerB));
        }

        [TestMethod]
        public void TestPairing3()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;
            IBasePlayer playerA;
            IBasePlayer playerB;


            players = CreateScenario06();
            sorter(players);
            queued = parier(players);

            playerA = null;
            playerB = null;

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                var record = (PlayerResult)pair.Item2.GetRecords();
                if (record.Wins > 0)
                    continue;

                Assert.IsFalse(pair.Item1.Played(pair.Item2));
                Assert.AreNotEqual(0, pair.Item1.CompareTo(pair.Item2));
                if (playerA == null)
                    playerA = pair.Item2;
                else
                {
                    playerB = pair.Item2;
                }
            }

            Assert.IsNotNull(playerA);
            Assert.IsNotNull(playerB);
            Assert.IsTrue(playerA.Played(playerB));
        }

        [TestMethod]
        public void TestPairing4()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;
            IBasePlayer playerA;
            IBasePlayer playerB;


            players = CreateScenario07();
            sorter(players);
            queued = parier(players);

            playerA = null;
            playerB = null;

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                var record = (PlayerResult)pair.Item2.GetRecords();
                if (record.Wins > 0)
                    continue;

                Assert.IsFalse(pair.Item1.Played(pair.Item2));
                Assert.AreNotEqual(0, pair.Item1.CompareTo(pair.Item2));
                if (playerA == null)
                    playerA = pair.Item2;
                else
                {
                    playerB = pair.Item2;
                }
            }

            Assert.IsNull(playerA);
            Assert.IsNull(playerB);
        }

        [TestMethod]
        public void TestPairing5()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;
            IBasePlayer playerA;
            IBasePlayer playerB;


            players = CreateScenario08();
            sorter(players);
            queued = parier(players);

            playerA = null;
            playerB = null;

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                var record = (PlayerResult)pair.Item2.GetRecords();
                if (record.Wins > 0)
                    continue;

                Assert.IsFalse(pair.Item1.Played(pair.Item2));
                Assert.AreNotEqual(0, pair.Item1.CompareTo(pair.Item2));
                if (playerA == null)
                    playerA = pair.Item2;
                else
                {
                    playerB = pair.Item2;
                }
            }

            Assert.IsNull(playerA);
            Assert.IsNull(playerB);
        }

        [TestMethod]
        public void TestPairing6()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;


            players = CreateScenario09();
            sorter(players);
            queued = parier(players);

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                Assert.IsNull(pair.Item2);
            }
        }

        [TestMethod]
        public void TestPairing7()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;


            players = CreateScenario10();
            sorter(players);
            queued = parier(players);

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                Assert.IsNull(pair.Item2);
            }
        }

        [TestMethod]
        public void TestPairing8()
        {
            var parier = PlayerPairer.GetPlayerPairer();
            var sorter = PlayerSorter.GetSorter();


            List<IBasePlayer> players;
            IEnumerable<Tuple<IBasePlayer, IBasePlayer>> queued;


            players = CreateScenario11();
            sorter(players);
            queued = parier(players);

            Assert.AreEqual(8, queued.Count());

            foreach (Tuple<IBasePlayer, IBasePlayer> pair in queued)
            {
                Assert.IsNotNull(pair.Item2);
                Assert.IsFalse(pair.Item1.Played(pair.Item2));
            }
        }

        [TestMethod]
        public void RandomPairingTest()
        {
            var results = new Dictionary<int, Dictionary<string, int>>();
            var parier = PlayerPairer.GetPlayerPairer();

            const int TRIALS = 500000;
            const int OUTCOMES = 17;
            const double EO = (double)TRIALS / OUTCOMES;
            const double CV = 26.296;
            for (int i = 0; i < TRIALS; ++i)
            {
                var playerList = CreateScenario00();
                Stack<Tuple<IBasePlayer, IBasePlayer>> result = parier(playerList);
                for (int j = 0; result.Count > 0; ++j)
                {
                    int keyOffset = 2 * j;
                    var item = result.Pop();
                    var item1Name = ((SimulatedPlayer)item.Item1).Name;

                    if (!results.ContainsKey(keyOffset + 1))
                        results.Add(keyOffset + 1, new Dictionary<string, int>());

                    if (!results[keyOffset + 1].ContainsKey(item1Name))
                        results[keyOffset + 1].Add(item1Name, 0);

                    results[keyOffset + 1][item1Name] += 1;

                    if (item.Item2 == null)
                        continue;

                    var item2Name = ((SimulatedPlayer)item.Item2).Name;

                    if (!results.ContainsKey(keyOffset + 2))
                        results.Add(keyOffset + 2, new Dictionary<string, int>());

                    if (!results[keyOffset + 2].ContainsKey(item2Name))
                        results[keyOffset + 2].Add(item2Name, 0);

                    results[keyOffset + 2][item2Name] += 1;
                }
            }

            double[] final = new double[OUTCOMES - 1];

            for (int i = 1; i <= OUTCOMES - 1; ++i)
            {
                double sum = 0.0;
                for (int j = 1; j <= OUTCOMES; ++j)
                {
                    sum += Math.Pow(results[i][j.ToString()] - EO, 2) / EO;
                }
                final[i - 1] = sum;
            }

            for (int i = 0; i < final.Length; ++i)
            {
                if (final[i] <= CV)
                    continue;

                StringBuilder sb = new StringBuilder();
                for (int j = 1; j <= OUTCOMES; ++j)
                {
                    sb.AppendLine($"{j.ToString()}: {results[i + 1][j.ToString()].ToString()}");
                }
                if (final[i] <= 28.845 && final[i] > CV)
                    Assert.Inconclusive($"Randomness test exceeded confidence interval of {CV} with a value of {final[i]}. Place was {i + 1}. Values are: \n" + sb.ToString());
                else
                    Assert.Fail($"Randomness test exceeded confidence interval of {CV} with a value of {final[i]}. Place was {i + 1}. Values are: \n" + sb.ToString());
            }
        }

        private static List<IBasePlayer> CreateScenario00()
        {
            var players = new List<IBasePlayer>
            {
                new SimulatedPlayer("1"),
                new SimulatedPlayer("2"),
                new SimulatedPlayer("3"),
                new SimulatedPlayer("4"),
                new SimulatedPlayer("5"),
                new SimulatedPlayer("6"),
                new SimulatedPlayer("7"),
                new SimulatedPlayer("8"),
                new SimulatedPlayer("9"),
                new SimulatedPlayer("10"),
                new SimulatedPlayer("11"),
                new SimulatedPlayer("12"),
                new SimulatedPlayer("13"),
                new SimulatedPlayer("14"),
                new SimulatedPlayer("15"),
                new SimulatedPlayer("16"),
                new SimulatedPlayer("17"),
            };

            return players;
        }

        private static List<IBasePlayer> CreateScenario01()
        {
            var players = new List<IBasePlayer>
            {
                new SimulatedPlayer("1"),
                new SimulatedPlayer("2"),
                new SimulatedPlayer("3"),
                new SimulatedPlayer("4"),
            };

            players[0].AddRecord(new SimulatedMatchRecord(players[0], players[3], players[0], false));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[0], players[0], false));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[2], players[1], false));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[1], players[1], false));

            return players;
        }

        private static List<IBasePlayer> CreateScenario02()
        {
            var players = new List<IBasePlayer>
            {
                new SimulatedPlayer("1"),
                new SimulatedPlayer("2"),
                new SimulatedPlayer("3"),
                new SimulatedPlayer("4"),
            };

            players[0].AddRecord(new SimulatedMatchRecord(players[0], players[3], players[0], false));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[0], players[0], false));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[2], players[1], false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[1], players[1], false, true));

            return players;
        }

        private static List<IBasePlayer> CreateScenario03()
        {
            var players = new List<IBasePlayer>
            {
                new SimulatedPlayer("1"),
                new SimulatedPlayer("2"),
                new SimulatedPlayer("3"),
                new SimulatedPlayer("4"),
            };

            players[0].AddRecord(new SimulatedMatchRecord(players[0], null, players[0], true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], null, players[0], true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], null, players[1], false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], null, players[1], false, true));

            return players;
        }

        private static List<IBasePlayer> CreateScenario04()
        {
            var players = new List<IBasePlayer>
            {
                new SimulatedPlayer("1"),
                new SimulatedPlayer("2"),
                new SimulatedPlayer("3"),
                new SimulatedPlayer("4"),
            };

            players[0].AddRecord(new SimulatedMatchRecord(players[0], players[3], players[0], true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[0], players[0], true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[2], players[1], false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[1], players[1], false, true));

            return players;
        }

        private static List<IBasePlayer> CreateScenario05()
        {
            var players = new List<IBasePlayer>(18);
            for (int i = 0; i < 18; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            for (int i = 0; i < 2; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].GetRecords();
            }

            for (int i = 2; i < 6; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 6; i < 12; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 12; i < 16; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }


            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[17], randomGuy, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, randomGuy, false));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, randomGuy, false));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, randomGuy, false));
            players[16].GetRecords();

            players[17].AddRecord(new SimulatedMatchRecord(players[17], players[16], randomGuy, false, true));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], randomGuy, randomGuy, false));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], randomGuy, randomGuy, false));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], randomGuy, randomGuy, false));
            players[17].GetRecords();

            return players;
        }

        private static List<IBasePlayer> CreateScenario06()
        {
            var players = new List<IBasePlayer>(18);
            for (int i = 0; i < 18; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            for (int i = 0; i < 2; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].GetRecords();
            }

            for (int i = 2; i < 6; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 6; i < 12; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, players[12], false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].GetRecords();

            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, players[13], false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].GetRecords();

            players[14].AddRecord(new SimulatedMatchRecord(players[14], randomGuy, players[14], false));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], players[17], null, false, true));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], players[16], null, false, true));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], randomGuy, randomGuy, false));
            players[14].GetRecords();

            players[15].AddRecord(new SimulatedMatchRecord(players[15], randomGuy, players[15], false));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], players[17], null, false, true));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], players[16], null, false, true));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], randomGuy, randomGuy, false));
            players[15].GetRecords();

            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[17], null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[15], null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[14], null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, null, false, true));
            players[16].GetRecords();

            players[17].AddRecord(new SimulatedMatchRecord(players[17], players[16], null, false, true));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], players[15], null, false, true));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], players[14], null, false, true));
            players[17].AddRecord(new SimulatedMatchRecord(players[17], randomGuy, null, false, true));
            players[17].GetRecords();

            return players;
        }

        private static List<IBasePlayer> CreateScenario07()
        {
            var players = new List<IBasePlayer>(4);
            for (int i = 0; i < 4; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            //for (int i = 0; i < 2; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].GetRecords();
            //}

            //for (int i = 2; i < 6; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].GetRecords();
            //}

            //for (int i = 6; i < 12; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].GetRecords();
            //}

            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, players[12], false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].GetRecords();

            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, players[13], false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].GetRecords();

            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, players[0], false));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], players[3], null, false, true));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], players[2], null, false, true));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, randomGuy, false));
            players[0].GetRecords();

            players[1].AddRecord(new SimulatedMatchRecord(players[1], randomGuy, players[1], false));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[3], null, false, true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[2], null, false, true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], randomGuy, randomGuy, false));
            players[1].GetRecords();

            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[3], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[1], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[0], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], randomGuy, null, false, true));
            players[2].GetRecords();

            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[2], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[1], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[0], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], randomGuy, null, false, true));
            players[3].GetRecords();

            return players;
        }

        private static List<IBasePlayer> CreateScenario08()
        {
            var players = new List<IBasePlayer>(4);
            for (int i = 0; i < 4; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            //for (int i = 0; i < 2; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].GetRecords();
            //}

            //for (int i = 2; i < 6; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].GetRecords();
            //}

            //for (int i = 6; i < 12; ++i)
            //{
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
            //    players[i].GetRecords();
            //}

            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, players[12], false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            //players[12].GetRecords();

            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, players[13], false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            //players[13].GetRecords();

            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, players[0], false));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, null, false, true));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, null, false, true));
            players[0].AddRecord(new SimulatedMatchRecord(players[0], randomGuy, randomGuy, false));
            players[0].GetRecords();

            players[1].AddRecord(new SimulatedMatchRecord(players[1], randomGuy, players[1], false));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[3], null, false, true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], players[2], null, false, true));
            players[1].AddRecord(new SimulatedMatchRecord(players[1], randomGuy, randomGuy, false));
            players[1].GetRecords();

            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[3], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[1], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], players[0], null, false, true));
            players[2].AddRecord(new SimulatedMatchRecord(players[2], randomGuy, null, false, true));
            players[2].GetRecords();

            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[2], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[1], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], players[0], null, false, true));
            players[3].AddRecord(new SimulatedMatchRecord(players[3], randomGuy, null, false, true));
            players[3].GetRecords();

            return players;
        }

        private static List<IBasePlayer> CreateScenario09()
        {
            const int capacity = 32;
            var players = new List<IBasePlayer>(capacity);
            for (int i = 0; i < capacity; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            for (int j = 0; j < capacity; ++j)
            {
                for (int i = 0; i < capacity; ++i)
                {
                    if (i == j)
                        continue;

                    players[j].AddRecord(new SimulatedMatchRecord(players[j], players[i], null, false, true));
                }
            }

            return players;
        }

        private static List<IBasePlayer> CreateScenario10()
        {
            const int capacity = 34;
            var players = new List<IBasePlayer>(capacity);
            for (int i = 0; i < capacity; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            for (int j = 0; j < capacity; ++j)
            {
                for (int i = 0; i < capacity; ++i)
                {
                    if (i == j)
                        continue;

                    players[j].AddRecord(new SimulatedMatchRecord(players[j], players[i], null, false, true));
                }
            }

            return players;
        }

        private static List<IBasePlayer> CreateScenario11()
        {
            var players = new List<IBasePlayer>(17);
            for (int i = 0; i < 17; ++i)
            {
                players.Add(new SimulatedPlayer());
            }

            var randomGuy = new SimulatedPlayer();

            for (int i = 0; i < 2; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].GetRecords();
            }

            for (int i = 2; i < 6; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 6; i < 12; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, players[12], false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].AddRecord(new SimulatedMatchRecord(players[12], randomGuy, randomGuy, false));
            players[12].GetRecords();

            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, players[13], false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].AddRecord(new SimulatedMatchRecord(players[13], randomGuy, randomGuy, false));
            players[13].GetRecords();

            players[14].AddRecord(new SimulatedMatchRecord(players[14], randomGuy, players[14], false));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], randomGuy, null, false, true));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], players[16], null, false, true));
            players[14].AddRecord(new SimulatedMatchRecord(players[14], randomGuy, randomGuy, false));
            players[14].GetRecords();

            players[15].AddRecord(new SimulatedMatchRecord(players[15], randomGuy, players[15], false));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], randomGuy, null, false, true));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], players[16], null, false, true));
            players[15].AddRecord(new SimulatedMatchRecord(players[15], randomGuy, randomGuy, false));
            players[15].GetRecords();

            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[15], null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], players[14], null, false, true));
            players[16].AddRecord(new SimulatedMatchRecord(players[16], randomGuy, null, false, true));
            players[16].GetRecords();


            return players;
        }
    }
}
