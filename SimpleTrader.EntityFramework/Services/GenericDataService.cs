using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T>:NonQueryDataService<T> ,IDataService<T> where T :DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<T>> GetAll()
        {

            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            var list = await context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

       
    }
}