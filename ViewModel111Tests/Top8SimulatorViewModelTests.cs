// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Top8SimulatorViewModelTests.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel.ViewModels;

namespace ViewModelTests
{
    [TestClass]
    public class Top8SimulatorViewModelTests
    {
        [TestMethod]
        public void Top8SimulatorTest()
        {
            var vm = new Top8SimulatorViewModel();
            Assert.IsNotNull(vm);
            Assert.IsFalse(vm.RunCanExecute);
            vm.Players = 17;
            Assert.IsFalse(vm.RunCanExecute);
            vm.Rounds = 5;
            Assert.IsFalse(vm.RunCanExecute);
            vm.Iterations = 100;
            Assert.IsTrue(vm.RunCanExecute);
            vm.IntentionalDraws = true;
            vm.UnintentionalDraws = true;
            vm.DoubleLosses = true;

            Assert.IsNull(vm.Results);
            vm.RunCommand.Execute(null);
            //Assert.IsNotNull(vm.Results);
            Assert.IsFalse(vm.IsBusy);
        }

        [TestMethod]
        public void StressTest()
        {
            var vm = new Top8SimulatorViewModel();
            vm.Players = 101;
            vm.Rounds = 7;
            vm.Iterations = 100000;
            vm.IntentionalDraws = true;
            vm.UnintentionalDraws = true;
            vm.DoubleLosses = true;

            vm.Run();
        }
    }
}
