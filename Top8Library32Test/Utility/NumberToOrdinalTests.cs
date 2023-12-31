// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: NumberToOrdinalTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Top8LibraryTest.Players
{
    [TestClass]
    public class NumberToOrdinalTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {//run once
        }

        [TestMethod]
        public void GetOrdinalTest()
        {
            Assert.AreEqual("st", Top8Library.Utility.Utility.GetOrdinal(1));
            Assert.AreEqual("nd", Top8Library.Utility.Utility.GetOrdinal(2));
            Assert.AreEqual("rd", Top8Library.Utility.Utility.GetOrdinal(3));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(4));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(5));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(6));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(7));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(8));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(9));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(0));
            Assert.AreEqual("nd", Top8Library.Utility.Utility.GetOrdinal(222));
            Assert.AreEqual("th", Top8Library.Utility.Utility.GetOrdinal(111));
        }
    }
}
