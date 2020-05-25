using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists
    }
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<Account> Login(string username, string password);
    }
}