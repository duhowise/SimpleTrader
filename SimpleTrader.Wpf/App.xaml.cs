using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.ViewModels;

namespace SimpleTrader.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
           
            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };

          var price=  new StockPriceService().GetPrice("AAPL");
            window.Show();
            base.OnStartup(e);
        }
    }
}