using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService:IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<Account> _accountDataService;

        public BuyStockService(IStockPriceService stockPriceService,IDataService<Account> accountDataService)
        {
            _stockPriceService = stockPriceService;
            _accountDataService = accountDataService;
        }
        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
           


            var stockPrice = await _stockPriceService.GetPrice(symbol);
            var transactionPrice = stockPrice * shares;

            if (transactionPrice>buyer.Balance)
            {
                throw new InsufficientFundsException(buyer.Balance,transactionPrice);
            }
            var assetTransaction = new AssetTransaction
            {
                Account = buyer,
                Asset = new Asset
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchase = true
            };
            buyer.AssetTransactions.Add(assetTransaction);
            buyer.Balance -= transactionPrice;
            await _accountDataService.Update(buyer.Id, buyer);
            return buyer;
        }
    }
}