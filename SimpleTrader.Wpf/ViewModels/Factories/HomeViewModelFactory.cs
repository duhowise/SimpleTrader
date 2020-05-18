namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public class HomeViewModelFactory:ISimpleTraderViewModelFactory<HomeViewModel>
    {
        private readonly ISimpleTraderViewModelFactory<MajorIndexListingViewModel> _majorIndexViewModelFactory;

        public HomeViewModelFactory(ISimpleTraderViewModelFactory<MajorIndexListingViewModel> majorIndexViewModelFactory)
        {
            _majorIndexViewModelFactory = majorIndexViewModelFactory;
        }
        public HomeViewModel CreateViewModel()
        {
           return new HomeViewModel(_majorIndexViewModelFactory.CreateViewModel());
        }
    }
}