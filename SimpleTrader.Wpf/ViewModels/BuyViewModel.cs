using System.Windows.Input;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.Wpf.Commands;

namespace SimpleTrader.Wpf.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
        public BuyViewModel(IStockPriceService stockPriceService,IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand=new BuyStockCommand(this,buyStockService);
        }

        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set
            {
                if (value != null) _symbol = value;
                OnPropertyChanged();
            }
        }

        private double _stockPrice;

        public double StockPrice
        {
            get => _stockPrice;
            set
            {
                if (value > 0) _stockPrice = value;
                OnPropertyChanged();
            }
        }


        private int _sharesToBuy;

        public int SharesToBuy
        {
            get => _sharesToBuy;
            set
            {
                if (value> 0) _sharesToBuy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            } 
        }

        public double TotalPrice => SharesToBuy * StockPrice;
        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }
    }
}