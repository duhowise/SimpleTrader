using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public interface IRootSimpleTraderViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}