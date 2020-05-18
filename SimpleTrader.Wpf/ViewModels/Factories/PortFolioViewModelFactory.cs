namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public class PortFolioViewModelFactory:ISimpleTraderViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}