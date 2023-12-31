// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SimulatedMatchRecordTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top8Library.Players;
using Top8Library.POCOs;

namespace Top8LibraryTest.POCOs
{
    [TestClass]
    public class SimulatedMatchRecordTests
    {
        [TestMethod]
        public void GetRecordsTest()
        {
            bool pass = false;
            try
            {
                var record = new SimulatedMatchRecord(null, null, null, false, false);
            }
            catch (ArgumentNullException)
            {
                pass = true;
            }
            Assert.IsTrue(pass);

            pass = false;
            try
            {
                var record = new SimulatedMatchRecord(new SimulatedPlayer(), null, null, false, false);
                record.GetResult();
            }
            catch (InvalidOperationException)
            {
                pass = true;
            }
            Assert.IsTrue(pass);
        }
    }
}
