using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountDataService;

        public AuthenticationService(IAccountService accountDataService)
        {
            _accountDataService = accountDataService;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password,
            string confirmPassword)
        {
            if (password!=confirmPassword)
            {
                return RegistrationResult.PasswordsDoNotMatch;
            }

            var emailAccount = _accountDataService.GetByEmail(email);
            if (emailAccount!=null)
            {
               return RegistrationResult.EmailAlreadyExists;
            }

            var userAccount = _accountDataService.GetByUserName(username);
            if (userAccount != null)
            {
                return RegistrationResult.UserNameAlreadyExists;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User
            {
                Email = email,
                PasswordHash = hashedPassword,
                Username = username,
                DateJoined = DateTime.UtcNow
            };

            var account = new Account
            {
                AccountHolder = user
            };

            await _accountDataService.Create(account);

            return RegistrationResult.Success;
        }

        public async Task<Account> Login(string username, string password)
        {

            var account=await _accountDataService.GetByUserName(username);
            var passwordsMatch = BCrypt.Net.BCrypt.Verify(password,account.AccountHolder.PasswordHash);

            if (!passwordsMatch)
            {
                throw  new InvalidPasswordException(username);
            }

            return account;
        }
    }
}