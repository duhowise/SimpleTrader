using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModellingPrepApi.Services
{
    public class MajorIndexService:IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType type)
        {
            var url = $"majors-indexes/{GetUrlSuffix(type)}";
            using var client=new FinancialModellingPrepHttpClient();
            var majorIndex=   await client.GetAsync<MajorIndex>(url);
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
                    throw new Exception("major Index type does not have a suffix declared");

            }
        }
    }
}