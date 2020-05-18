using System;
using System.Windows.Input;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.State.Navigators;
using SimpleTrader.Wpf.ViewModels;
using SimpleTrader.Wpf.ViewModels.Factories;

namespace SimpleTrader.Wpf.Commands
{
    public class UpdateCurrentViewModelCommand :ICommand
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelAbstractFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator,ISimpleTraderViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}