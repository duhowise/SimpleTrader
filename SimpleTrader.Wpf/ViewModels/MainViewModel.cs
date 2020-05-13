using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            Navigator.UpdateViewModelCommand.Execute(ViewType.Home);
        }
        public INavigator Navigator { get; set; }=new Navigator();
    }
}