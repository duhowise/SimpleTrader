using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModellingPrepApi.Services
{
    public class MajorIndexService:IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType type)
        {
            var url = $"https://financialmodelingprep.com/api/v3/majors-indexes/{GetUrlSuffix(type)}";
            using var client=new HttpClient();
            var response=   await client.GetAsync(url);
            var   jsonResponse = await response.Content.ReadAsStringAsync();
            var majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
            majorIndex.Type = type;
            return majorIndex;
        }

        private string GetUrlSuffix(MajorIndexType type)
        {
            switch (type)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    return ".DJI";

            }
        }
    }
}