// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: PlayerPairer.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Top8Library.Players;

namespace Top8Library.Utility
{
    internal static class PlayerPairer
    {
        public delegate Stack<Tuple<IBasePlayer, IBasePlayer>> PairDelagate(IReadOnlyCollection<IBasePlayer> array);

        public static PairDelagate GetPlayerPairer()
        {
            return Pair;
        }

        private static Stack<Tuple<IBasePlayer, IBasePlayer>> Pair(IReadOnlyCollection<IBasePlayer> players)
        {
            var sort = PlayerSorter.GetSorter(players.Count);
            List<IBasePlayer> playerPool = players.ToList();
            List<Tuple<IBasePlayer, IBasePlayer>> pairedPlayers = new List<Tuple<IBasePlayer, IBasePlayer>>(playerPool.Count >> 1);
            Dictionary<IBasePlayer, HashSet<IBasePlayer>> badMatchups = new Dictionary<IBasePlayer, HashSet<IBasePlayer>>();
            bool forcePairing = false;

            if ((playerPool.Count & 1) == 1)
            {
                playerPool.Add(new SimulatedByePlayer());
            }

            Debug.Assert((playerPool.Count & 1) == 0);

            while (playerPool.Count > 0)
            {
                IBasePlayer playerA = GetRandomPlayer(playerPool);
                playerPool.Remove(playerA);

                Debug.Assert(!(playerA is SimulatedByePlayer));

                IBasePlayer playerB = GetRandomPlayer(playerPool, playerA, badMatchups);
                playerPool.Remove(playerB);

                if (playerB == null && !forcePairing)
                {
                    playerPool.Insert(0, playerA);
                    if (!Unwind(playerPool, pairedPlayers, badMatchups))
                    {
                        forcePairing = true;
                    }
                    sort(playerPool);
                    continue;
                }
                pairedPlayers.Add(new Tuple<IBasePlayer, IBasePlayer>(playerA, playerB));
            }


            var retVal = new Stack<Tuple<IBasePlayer, IBasePlayer>>();

            for (int i = pairedPlayers.Count - 1; i >= 0; i--)
            {
                var pair = pairedPlayers[i];
                Debug.Assert(pair.Item1 is SimulatedByePlayer == false);
                if (pair.Item2 == null || pair.Item2 is SimulatedByePlayer)
                {
                    ((SimulatedPlayer)pair.Item1).GrantBye();
                    continue;
                }
                retVal.Push(pair);
            }

            return retVal;
        }

        private static IBasePlayer GetRandomPlayer(List<IBasePlayer> playerPool)
        {
            Debug.Assert(playerPool.Count > 0);

            IBasePlayer comparePlayer = playerPool.First();

            Debug.Assert(comparePlayer != null);

            IList<IBasePlayer> retVal = new List<IBasePlayer>();

            for (int i = 0; i < playerPool.Count; ++i)
            {
                if (playerPool[i].CompareTo(comparePlayer) == 0)
                {
                    retVal.Add(playerPool[i]);
                }
            }

            return retVal.GetRandom();
        }

        private static IBasePlayer GetRandomPlayer(List<IBasePlayer> playerPool, IBasePlayer playerA, Dictionary<IBasePlayer, HashSet<IBasePlayer>> badMatchups)
        {
            IBasePlayer playerB = null;
            IList<IBasePlayer> players = new List<IBasePlayer>(playerPool.Count);
            int index = 0;

            while (index < playerPool.Count)
            {
                IBasePlayer comparePlayer = playerPool[index];

                while (index < playerPool.Count && playerPool[index].CompareTo(comparePlayer) == 0)
                {
                    if (NotPlayed(playerA, playerPool[index], badMatchups))
                    {
                        players.Add(playerPool[index]);
                    }
                    ++index;
                }

                if (players.Count > 0)
                    return players.GetRandom();

            }

            return playerB;
        }

        private static bool NotPlayed(IBasePlayer playerA, IBasePlayer playerB, Dictionary<IBasePlayer, HashSet<IBasePlayer>> badMatchups)
        {
            return !playerA.Played(playerB) && 
                        (!badMatchups.ContainsKey(playerA) ||
                        !badMatchups[playerA].Contains(playerB));
        }

        private static bool Unwind(List<IBasePlayer> playerPool, List<Tuple<IBasePlayer, IBasePlayer>> pairedPlayers, Dictionary<IBasePlayer, HashSet<IBasePlayer>> badMatchups)
        {
            if (playerPool.Count > 32)
                return false;

            UInt32 state = 0;

            while (playerPool.Count < 32 && pairedPlayers.Count > 0)
            {
                var pair = pairedPlayers[pairedPlayers.Count - 1];
                var playerA = pair.Item1;
                var playerB = pair.Item2;

                pairedPlayers.Remove(pair);
                playerPool.Insert(0, playerB);
                playerPool.Insert(0, playerA);

                if (!Validate(0, ref state, playerPool, badMatchups))
                {
                    Debug.Assert(playerPool.Count != 6);
                    continue;
                }

                HashSet<IBasePlayer> matchups;
                if (!badMatchups.TryGetValue(playerA, out matchups))
                {
                    matchups = new HashSet<IBasePlayer>();
                    badMatchups.Add(playerA, matchups);
                }
                matchups.Add(playerB);
                if (!badMatchups.TryGetValue(playerB, out matchups))
                {
                    matchups = new HashSet<IBasePlayer>();
                    badMatchups.Add(playerB, matchups);
                }
                matchups.Add(playerA);
                return true;
            }

            return false;
        }
        private static bool Validate(int level, ref UInt32 state, List<IBasePlayer> playerPool, Dictionary<IBasePlayer, HashSet<IBasePlayer>> badMatchups)
        {
            int index = level + 1;

            //if (index >= playerPool.Count)
            //    return false;

            Debug.Assert(index < playerPool.Count);

            if (((state >> level) & 1) == 1)
            {
                return Validate(index, ref state, playerPool, badMatchups);
            }

            state |= (((uint)1) << level);

            for (int i = index; i < playerPool.Count; ++i)
            {
                if (!NotPlayed(playerPool[level], playerPool[i], badMatchups))
                    continue;

                if (((state >> i) & 1) == 1)
                    continue;

                state |= (((uint)1) << i);

                if ((state + 1) == (1 << playerPool.Count))
                {
                    return true;
                }

                if (Validate(index, ref state, playerPool, badMatchups))
                    return true;

                state ^= (((uint)1) << i);
            }

            state ^= (((uint)1) << level);

            return false;
        }
    }
}
