using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService : NonQueryDataService<Account>, IDataService<Account>,IAccountService
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public AccountDataService(SimpleTraderDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            await using var context = _contextFactory.CreateDbContext(new[] {""});
            var list = await context.Accounts
                .Include(x=>x.AccountHolder)
                .Include(x => x.AssetTransactions).Include(x => x.AccountHolder)
                .ToListAsync();
            return list;
        }

        public async Task<Account> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext(new[] {""});
            var entity = await context.Accounts
                .Include(x => x.AccountHolder)
                    .Include(x=>x.AssetTransactions).Include(x => x.AssetTransactions).Include(x => x.AccountHolder)
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<Account> GetByUserName(string username)
        {
            await using var context = _contextFactory.CreateDbContext(new[] {""});
            return await context.Accounts.Include(a => a.AccountHolder)
                .FirstOrDefaultAsync(x => x.AccountHolder.Username == username);
        }

        public async Task<Account> GetByEmail(string email)
        {
            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            return await context.Accounts.Include(a=>a.AccountHolder).Include(x=>x.AssetTransactions).Include(x=>x.AccountHolder).FirstOrDefaultAsync(x=>x.AccountHolder.Email==email);
        }
    }
}