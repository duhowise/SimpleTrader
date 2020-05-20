using System;
using System.Windows.Input;
using SimpleTrader.Wpf.State.Navigators;
using SimpleTrader.Wpf.ViewModels.Factories;

namespace SimpleTrader.Wpf.Commands
{
    public class UpdateCurrentViewModelCommand :ICommand
    {
        private readonly INavigator _navigator;
        private readonly IRootSimpleTraderViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator,IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}