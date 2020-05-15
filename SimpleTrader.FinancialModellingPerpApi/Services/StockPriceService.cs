using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModellingPrepApi.Results;

namespace SimpleTrader.FinancialModellingPrepApi.Services
{
    public class StockPriceService:IStockPriceService  
    {
        public async Task<double> GetPrice(string symbol)
        {
            var url = $"stock/real-time-price/{symbol}";
            using var client = new FinancialModellingPrepHttpClient();
            var stockPriceResult = await client.GetAsync<StockPriceResult>(url);

            if (stockPriceResult.Price==0)
            {
             throw   new InvalidSymbolException(symbol);
            }
            return stockPriceResult.Price;
        }
    }
}