using System.Windows.Input;
using SimpleTrader.Wpf.Commands;
using SimpleTrader.Wpf.Models;
using SimpleTrader.Wpf.ViewModels;
using SimpleTrader.Wpf.ViewModels.Factories;

namespace SimpleTrader.Wpf.State.Navigators
{
    public class Navigator: ObservableObject,INavigator
    {
        private readonly ISimpleTraderViewModelAbstractFactory _viewModelAbstractFactory;
        private ViewModelBase _currentViewModel;

        public Navigator(ISimpleTraderViewModelAbstractFactory viewModelAbstractFactory)
        {
            _viewModelAbstractFactory = viewModelAbstractFactory;
            UpdateViewModelCommand=new UpdateCurrentViewModelCommand(this,viewModelAbstractFactory);
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(); 
            }
        }

        public ICommand UpdateViewModelCommand { get; set; }
       
        
        
        
        
       
    }
}