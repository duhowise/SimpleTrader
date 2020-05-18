using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateViewModelCommand.Execute(ViewType.Home);
        }
    }
}