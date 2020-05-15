using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleTrader.FinancialModellingPrepApi
{
    public class FinancialModellingPrepHttpClient:HttpClient
    {
        public FinancialModellingPrepHttpClient()
        {
            this.BaseAddress=new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await GetAsync(uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<T>(jsonResponse);
           
        }
    }
}