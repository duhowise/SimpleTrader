using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModellingPrepApi.Services;
using SimpleTrader.Wpf.State.Navigators;
using SimpleTrader.Wpf.ViewModels;
using SimpleTrader.Wpf.ViewModels.Factories;

namespace SimpleTrader.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();

            var window = serviceProvider.GetRequiredService<MainWindow>();
            

            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();


            services.AddSingleton<ISimpleTraderViewModelAbstractFactory,SimpleTraderViewModelAbstractFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>,HomeViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>,PortFolioViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>,MajorIndexListingViewModelFactory>();


            services.AddScoped<MainWindow>(x=>new MainWindow(x.GetRequiredService<MainViewModel>()));
            services.AddScoped<MainViewModel>();
            services.AddScoped<INavigator, Navigator>();
            return services.BuildServiceProvider();
        }
    }
}