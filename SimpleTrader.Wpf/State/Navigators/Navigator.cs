using System.Windows.Input;
using SimpleTrader.Wpf.Commands;
using SimpleTrader.Wpf.Models;
using SimpleTrader.Wpf.ViewModels;
using SimpleTrader.Wpf.ViewModels.Factories;

namespace SimpleTrader.Wpf.State.Navigators
{
    public class Navigator: ObservableObject,INavigator
    {
        private readonly IRootSimpleTraderViewModelFactory _viewModelFactory;
        private ViewModelBase _currentViewModel;

        public Navigator(IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            UpdateViewModelCommand=new UpdateCurrentViewModelCommand(this,viewModelFactory);
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