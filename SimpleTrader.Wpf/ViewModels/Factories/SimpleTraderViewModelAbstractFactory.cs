using System;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public class SimpleTraderViewModelAbstractFactory:ISimpleTraderViewModelAbstractFactory 
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                default: throw new ArgumentException("The view type has no view model",nameof(viewType));
            }
        }
    }

}