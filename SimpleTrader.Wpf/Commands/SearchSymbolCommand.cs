using System;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Services;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf.Commands
{
    public class SearchSymbolCommand:ICommand
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(BuyViewModel buyViewModel,IStockPriceService stockPriceService)
        {
            _buyViewModel = buyViewModel;
            _stockPriceService = stockPriceService;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol).ConfigureAwait(false);
                _buyViewModel.StockPrice = stockPrice;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}