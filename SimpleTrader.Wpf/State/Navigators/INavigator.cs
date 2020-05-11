using System.Windows.Input;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateViewModelCommand { get;  }
    }
}