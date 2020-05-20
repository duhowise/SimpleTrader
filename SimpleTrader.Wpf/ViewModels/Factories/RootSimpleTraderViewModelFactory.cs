using System;
using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public class RootSimpleTraderViewModelFactory:IRootSimpleTraderViewModelFactory 
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly BuyViewModel _buyViewModel;

        public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory, BuyViewModel buyViewModel)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _buyViewModel = buyViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModel;
                default: throw new ArgumentException("The view type has no view model",nameof(viewType));
            }
        }
    }

}