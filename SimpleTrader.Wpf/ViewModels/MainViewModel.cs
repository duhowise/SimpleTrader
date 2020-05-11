using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
        }
        public INavigator Navigator { get; set; }=new Navigator();
    }
}