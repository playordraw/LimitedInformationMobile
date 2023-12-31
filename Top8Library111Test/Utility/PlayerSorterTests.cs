// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlayerSorterTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Players;
using Top8Library.POCOs;

namespace Top8LibraryTest.Utility
{
    [TestClass]
    public class PlayerSorterTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
        }

        [TestMethod]
        public void MergeSortTest()
        {
            var list = CreateScenario11();

            Top8Library.Utility.PlayerSorter.MergeSort(list);

            var temp = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                var result1 = (PlayerResult)list[i - 1].GetRecords();
                var result2 = (PlayerResult)list[i].GetRecords();
                Assert.IsTrue(result1.Points >= result2.Points);

                if (list[i].CompareTo(temp) != 0)
                {
                    temp = list[i];
                    continue;
                }

                Assert.IsTrue(Int32.Parse(((SimulatedPlayer)temp).Name) < Int32.Parse(((SimulatedPlayer)list[i]).Name));
            }
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            var list = CreateScenario11();

            Top8Library.Utility.PlayerSorter.InsertionSortPlayers(list);

            var temp = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                var result1 = (PlayerResult) list[i - 1].GetRecords();
                var result2 = (PlayerResult) list[i].GetRecords();
                Assert.IsTrue(result1.Points >= result2.Points);

                if (list[i].CompareTo(temp) != 0)
                {
                    temp = list[i];
                    continue;
                }

                Assert.IsTrue(Int32.Parse(((SimulatedPlayer)temp).Name) < Int32.Parse(((SimulatedPlayer)list[i]).Name));
            }
        }

        private static List<IBasePlayer> CreateScenario11()
        {
            var players = new List<IBasePlayer>(17);
            for (int i = 0; i < 17; ++i)
            {
                players.Add(new SimulatedPlayer(i.ToString()));
            }

            var randomGuy = new SimulatedPlayer();

            for (int i = 3; i < 5; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].GetRecords();
            }

            for (int i = 5; i < 9; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 0; i < 3; ++i)
            {
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, players[i], false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].AddRecord(new SimulatedMatchRecord(players[i], randomGuy, randomGuy, false));
                players[i].GetRecords();
            }

            for (int i = 9; i < 12; ++i)
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
