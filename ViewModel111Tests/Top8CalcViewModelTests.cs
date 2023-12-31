// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Top8CalcViewModelTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel.ViewModels;

namespace ViewModelTests
{
    [TestClass]
    public class Top8CalcViewModelTests
    {
        [TestMethod]
        public void Tests()
        {
            var vm = new Top8CalcViewModel();
            Assert.IsNotNull(vm);
            Assert.IsFalse(vm.RunCanExecute);
            vm.Players = 17;
            Assert.IsFalse(vm.RunCanExecute);
            vm.Rounds = 5;
            Assert.IsTrue(vm.RunCanExecute);
            vm.IncludeDraws = false;

            Assert.IsNull(vm.Results);
            vm.RunCommand.Execute(null);
            Assert.IsNotNull(vm.Results);

            vm.IncludeDraws = true;
            Assert.IsNotNull(vm.Results);
        }
    }
}
