// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Top8CalcViewModel.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Tournaments;
using ViewModel.POCOs;
using Xamarin.Forms;

namespace ViewModel.ViewModels
{
    internal class Top8CalcViewModel : BindableObject
    {
        public static readonly BindableProperty PlayersProperty = BindableProperty.Create(nameof(Players), typeof(int), typeof(Top8CalcViewModel), 0, BindingMode.OneWayToSource,
            propertyChanged: PlayersChanged);

        public int Players
        {
            get { return (int)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); }
        }

        public static readonly BindableProperty RoundsProperty = BindableProperty.Create(nameof(Rounds), typeof(int), typeof(Top8CalcViewModel), 0, BindingMode.OneWayToSource,
            propertyChanged: RoundsChanged);

        public int Rounds
        {
            get { return (int)GetValue(RoundsProperty); }
            set { SetValue(RoundsProperty, value); }
        }

        public static readonly BindableProperty RunCanExecuteProperty = BindableProperty.Create(nameof(RunCanExecute), typeof(bool), typeof(Top8CalcViewModel), default(bool));

        public bool RunCanExecute
        {
            get { return (bool)GetValue(RunCanExecuteProperty); }
            private set { SetValue(RunCanExecuteProperty, value); }
        }

        public static readonly BindableProperty ResultsProperty = BindableProperty.Create(nameof(Results), typeof(IList<Standing>), typeof(Top8CalcViewModel), null);

        public IList<Standing> Results
        {
            get { return (IList<Standing>)GetValue(ResultsProperty); }
            private set { SetValue(ResultsProperty, value); }
        }

        public static readonly BindableProperty IncludeDrawsProperty = BindableProperty.Create(nameof(IncludeDraws), typeof(bool), typeof(Top8CalcViewModel), true, BindingMode.TwoWay);

        public bool IncludeDraws
        {
            get { return (bool)GetValue(IncludeDrawsProperty); }
            set { SetValue(IncludeDrawsProperty, value); }
        }

        public static readonly BindableProperty StaticIncludeDrawsProperty = BindableProperty.Create(nameof(StaticIncludeDraws), typeof(bool), typeof(Top8CalcViewModel), default(bool), BindingMode.TwoWay);

        public bool StaticIncludeDraws
        {
            get { return (bool)GetValue(StaticIncludeDrawsProperty); }
            set { SetValue(StaticIncludeDrawsProperty, value); }
        }

        public ICommand RunCommand { get; }

        public Top8CalcViewModel()
        {
            RunCommand = new Command(Run, CanExecute);
        }

        private bool CanExecute()
        {
            return Players > 0 && Rounds > 0;
        }

        private void Run()
        {
            Results?.Clear();
            StaticIncludeDraws = IncludeDraws;
            ITournament ct = TournamentFactory.CreateTournament(Players, Rounds, IncludeDraws);
            ct.Run();
            ReadOnlyCollection<IBasePlayer> results = ct.GetResults();
            Results = AllStandings(results);
        }

        private static IList<Standing> AllStandings(ReadOnlyCollection<IBasePlayer> results)
        {
            IList<Standing> temp = new List<Standing>();
            for (int i = 0; i < results.Count; ++i)
            {
                PlayerResult record = (PlayerResult)results[i].GetRecords();
                temp.Add(new Standing(i + 1, record.Points, record.Wins, record.Losses, record.Draws));
            }
            return temp;
        }

        private static void PlayersChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Top8CalcViewModel vm = (Top8CalcViewModel)bindable;
            vm.PlayersChanged();
        }

        private void PlayersChanged()
        {
            UpdateRunCanExecute();
        }

        private static void RoundsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Top8CalcViewModel vm = (Top8CalcViewModel)bindable;
            vm.RoundsChanged();
        }

        private void RoundsChanged()
        {
            UpdateRunCanExecute();
        }

        private void UpdateRunCanExecute()
        {
            RunCanExecute = RunCommand.CanExecute(null);
        }
    }
}
