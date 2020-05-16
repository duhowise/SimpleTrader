using System.Windows;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
           
            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            var accountService = new AccountDataService(new SimpleTraderDbContextFactory());
            var buyStockService=new BuyStockService(new StockPriceService(),accountService);
            var buyer = await accountService.Get(1);
            await buyStockService.BuyStock(buyer, "T", 5);
            window.Show();
            base.OnStartup(e);
        }
    }
}