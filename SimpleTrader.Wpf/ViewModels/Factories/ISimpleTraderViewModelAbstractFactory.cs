using SimpleTrader.Wpf.State.Navigators;

namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public interface ISimpleTraderViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}