namespace SimpleTrader.Wpf.ViewModels.Factories
{
    public interface ISimpleTraderViewModelFactory<T> where T:ViewModelBase
    {
        T CreateViewModel();
    }
}