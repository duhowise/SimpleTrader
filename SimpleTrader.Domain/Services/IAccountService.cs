using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
    public interface IAccountService:IDataService<Account>
    {
        Task<Account> GetByUserName(string username);
        Task<Account> GetByEmail(string email);
    }
}