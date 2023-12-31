// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: TournamentFactoryTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.POCOs;
using Top8Library.Tournaments;

namespace Top8LibraryTest.Tournaments
{
    [TestClass]
    public class TournamentFactoryTests
    {
        [TestMethod]
        public void CreateTournamentTest()
        {
            var tourny = TournamentFactory.CreateTournament(17, 5);
            Assert.IsNotNull(tourny);
            tourny = TournamentFactory.CreateTournament(0, 0);
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(50, 10);
            Assert.IsNotNull(tourny);
            tourny = TournamentFactory.CreateTournament(-4, -10);
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, 5, false);
            Assert.IsNotNull(tourny);

            tourny = TournamentFactory.CreateTournament(-1, -1, true, true, true);
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(0, 0, true, true, true);
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, 5, true, true, true);
            Assert.IsNotNull(tourny);
            tourny = TournamentFactory.CreateTournament(-1, Day.CreateDay(0, 0));
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(0, Day.CreateDay(0, 0));
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, Day.CreateDay(-1, -1));
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, Day.CreateDay(0, 0));
            Assert.IsNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, Day.CreateDay(8, 5));
            Assert.IsNotNull(tourny);
            tourny = TournamentFactory.CreateTournament(17, null);
            Assert.IsNull(tourny);
        }
    }
}
