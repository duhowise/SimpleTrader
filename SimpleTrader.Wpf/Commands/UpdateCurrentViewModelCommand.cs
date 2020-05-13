using System;
using System.Windows.Input;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.State.Navigators;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf.Commands
{
    public class UpdateCurrentViewModelCommand :ICommand
    {
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewtype)
            {
                switch (viewtype)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel=new HomeViewModel(MajorIndexListingViewModel.LoadMajorIndexViewModel(new MajorIndexService()));
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel=new PortfolioViewModel();
                        break;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}