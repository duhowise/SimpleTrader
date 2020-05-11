using System.Windows.Input;
using SimpleTrader.Wpf.Commands;
using SimpleTrader.Wpf.Models;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf.State.Navigators
{
    public class Navigator: ObservableObject,INavigator
    {
        private ViewModelBase _currentViewModel;

        public Navigator()
        {
            
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

        public ICommand UpdateViewModelCommand=>new UpdateCurrentViewModelCommand(this);
       
        
        
        
        
       
    }
}