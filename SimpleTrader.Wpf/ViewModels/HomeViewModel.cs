namespace SimpleTrader.Wpf.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private readonly MajorIndexViewModel _majorIndexViewModel;

        public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
        {
            _majorIndexViewModel = majorIndexViewModel;
        }
    }
}