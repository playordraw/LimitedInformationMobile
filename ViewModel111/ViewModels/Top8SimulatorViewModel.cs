// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: Top8SimulatorViewModel.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MathNet.Numerics.Statistics;
using Top8Library.Players;
using Top8Library.POCOs;
using Top8Library.Tournaments;
using ViewModel.POCOs;
using Xamarin.Forms;

namespace ViewModel.ViewModels
{
    internal class Top8SimulatorViewModel : BindableObject
    {
        public static readonly BindableProperty PlayersProperty = BindableProperty.Create(nameof(Players), typeof(int), typeof(Top8SimulatorViewModel), 0, BindingMode.OneWayToSource, propertyChanged: PlayersChanged);

        public int Players
        {
            get { return (int)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); }
        }

        public static readonly BindableProperty RoundsProperty = BindableProperty.Create(nameof(Rounds), typeof(int), typeof(Top8SimulatorViewModel), 0, BindingMode.OneWayToSource, propertyChanged: RoundsChanged);

        public int Rounds
        {
            get { return (int)GetValue(RoundsProperty); }
            set { SetValue(RoundsProperty, value); }
        }

        public static readonly BindableProperty IterationsProperty = BindableProperty.Create(nameof(Iterations), typeof(int), typeof(Top8SimulatorViewModel), 0, BindingMode.OneWayToSource, propertyChanged: IterationsChanged);

        public int Iterations
        {
            get { return (int)GetValue(IterationsProperty); }
            set { SetValue(IterationsProperty, value); }
        }

        public static readonly BindableProperty RunCanExecuteProperty = BindableProperty.Create(nameof(RunCanExecute), typeof(bool), typeof(Top8SimulatorViewModel), default(bool));

        public bool RunCanExecute
        {
            get { return (bool)GetValue(RunCanExecuteProperty); }
            private set { SetValue(RunCanExecuteProperty, value); }
        }

        public static readonly BindableProperty ResultsProperty = BindableProperty.Create(nameof(Results), typeof(ObservableCollection<RunningStatistics>), typeof(Top8SimulatorViewModel), null);

        public ObservableCollection<RunningStatistics> Results
        {
            get { return (ObservableCollection<RunningStatistics>)GetValue(ResultsProperty); }
            private set { SetValue(ResultsProperty, value); }
        }

        public static readonly BindableProperty IntentionalDrawsProperty = BindableProperty.Create(nameof(IntentionalDraws), typeof(bool), typeof(Top8SimulatorViewModel), true, BindingMode.TwoWay);

        public bool IntentionalDraws
        {
            get { return (bool)GetValue(IntentionalDrawsProperty); }
            set { SetValue(IntentionalDrawsProperty, value); }
        }

        public static readonly BindableProperty UnintentionalDrawsProperty = BindableProperty.Create(nameof(UnintentionalDraws), typeof(bool), typeof(Top8SimulatorViewModel), true, BindingMode.TwoWay);

        public bool UnintentionalDraws
        {
            get { return (bool)GetValue(UnintentionalDrawsProperty); }
            set { SetValue(UnintentionalDrawsProperty, value); }
        }

        public static readonly BindableProperty DoubleLossesProperty = BindableProperty.Create(nameof(DoubleLosses), typeof(bool), typeof(Top8SimulatorViewModel), true, BindingMode.TwoWay);

        public bool DoubleLosses
        {
            get { return (bool)GetValue(DoubleLossesProperty); }
            set { SetValue(DoubleLossesProperty, value); }
        }

        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(Top8SimulatorViewModel), true, BindingMode.TwoWay);

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public ICommand RunCommand { get; }

        public Top8SimulatorViewModel()
        {
            RunCommand = new Command(Run, CanExecute);
        }

        private bool CanExecute()
        {
            return Players > 0 && Rounds > 0 && Iterations > 0;
        }

        public async void Run()
        {
            IsBusy = true;
            Results?.Clear();

            var result = await Action(Iterations);

            Results = new ObservableCollection<RunningStatistics>(result);

            IsBusy = false;
        }

        private Task<RunningStatistics[]> Action(int iterations)
        {
            try
            {
                RunningStatistics[] stats = new RunningStatistics[Players];
                for (int i = stats.Length - 1; i >= 0; --i)
                {
                    stats[i] = new RunningStatistics();
                }

                for (int i = iterations - 1; i >= 0; --i)
                {
                    ITournament ct = TournamentFactory.CreateTournament(Players, Rounds, IntentionalDraws, UnintentionalDraws, DoubleLosses);
                    ct.Run();
                    ReadOnlyCollection<IBasePlayer> results = ct.GetResults();
                    for (int j = results.Count - 1; j >= 0; --j)
                    {
                        PlayerResult record = (PlayerResult)results[j].GetRecords();
                        stats[j].Push(record.Points);
                    }
                }

                return Task.FromResult(stats);
            }
            catch 
            {
                return Task.FromResult(new RunningStatistics[Players]);
            }
        }

        private static void PlayersChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Top8SimulatorViewModel vm = (Top8SimulatorViewModel)bindable;
            vm.PlayersChanged();
        }

        private void PlayersChanged()
        {
            UpdateRunCanExecute();
        }

        private static void RoundsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Top8SimulatorViewModel vm = (Top8SimulatorViewModel)bindable;
            vm.RoundsChanged();
        }

        private void RoundsChanged()
        {
            UpdateRunCanExecute();
        }

        private static void IterationsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Top8SimulatorViewModel vm = (Top8SimulatorViewModel)bindable;
            vm.IterationsChanged();
        }

        private void IterationsChanged()
        {
            UpdateRunCanExecute();
        }

        public void UpdateRunCanExecute()
        {
            RunCanExecute = RunCommand.CanExecute(null);
        }
    }
}
