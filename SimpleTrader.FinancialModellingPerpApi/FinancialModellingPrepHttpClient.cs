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
            var response = await GetAsync($"{uri}?apikey=9254eaddfbcea5065a7fa36e5546ddc6");
            var jsonResponse = await response.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<T>(jsonResponse);
           
        }
    }
}