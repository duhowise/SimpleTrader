using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            //arrange
            var expectedUsername = "testUser";
            var password = "testPassword";
            _mockAccountService = new Mock<IAccountService>();
            _mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account
            {
                AccountHolder = new User
                    {Username = expectedUsername, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)}
            });
            _authenticationService = new AuthenticationService(_mockAccountService.Object);
        }

        [Test]
        public async Task Login_WithTheCorrectPasswordForExistingUser_ReturnsCorrectAccountUsername()
        {
            //arrange
            var expectedUsername = "testUser";
            var password = "testPassword";


            //act
            var account = await _authenticationService.Login(expectedUsername, password);
            var actualUsername = account.AccountHolder.Username;
            //assert
            Assert.AreEqual(expectedUsername, actualUsername);
        }


        [Test]
        public void Login_WithTheWrongPasswordForExistingUser_ThrowsInvalidPasswordException()
        {
            //arrange
            var expectedUsername = "testUser";
            var password = "testPassword";
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account
            {
                AccountHolder = new User
                    {Username = expectedUsername, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)}
            });
            var authenticationService = new AuthenticationService(mockAccountService.Object);

            //act
            var wrongPassword = "data";
            var invalidPasswordException =
                Assert.ThrowsAsync<InvalidPasswordException>(() =>
                    authenticationService.Login(expectedUsername, wrongPassword));
            //assert
            var actualUsername = invalidPasswordException.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }


        [Test]
        public void Login_WithNonExistentUsername_ThrowsInvalidPasswordException()
        {
            //arrange
            var expectedUsername = "testUser";
            var mockAccountService = new Mock<IAccountService>();
            var authenticationService = new AuthenticationService(mockAccountService.Object);

            //act
            var wrongPassword = "data";
            var userNotFoundException =
                Assert.ThrowsAsync<UserNotFoundException>(() =>
                    authenticationService.Login(expectedUsername, wrongPassword));
            //assert
            var actualUsername = userNotFoundException.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Register_withPasswordsNotMatching_ReturnsPasswordsDonotMatch()
        {
            //arrange
            var expected = RegistrationResult.PasswordsDoNotMatch;
            var mockAccountService = new Mock<IAccountService>();
            var authenticationService = new AuthenticationService(mockAccountService.Object);

            //Act
            var testPassword = "testPassword";
            var confirmTestPassword = "confirmTestPassword";
          var actual=await  authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), testPassword, confirmTestPassword);
            //Assert
            Assert.AreEqual(expected,actual);
        }


        [Test] public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            //arrange
            var email = "test@email.com";
            var expected = RegistrationResult.EmailAlreadyExists;
            var mockAccountService = new Mock<IAccountService>();
            var authenticationService = new AuthenticationService(mockAccountService.Object);
            mockAccountService.Setup(x => x.GetByEmail(email)).ReturnsAsync(new Account
            {
                AccountHolder = new User
                {
                    Email = email
                }
            });
            //Act
            var testPassword = "testPassword";
            var confirmTestPassword = "testPassword";
          var actual=await  authenticationService.Register(email, It.IsAny<string>(), testPassword, confirmTestPassword);
            //Assert
            Assert.AreEqual(expected,actual);
        }
        
        
        [Test] public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            //arrange
            var username = "test@email.com";
            var expected = RegistrationResult.UserNameAlreadyExists;
            var mockAccountService = new Mock<IAccountService>();
            var authenticationService = new AuthenticationService(mockAccountService.Object);
            mockAccountService.Setup(x => x.GetByUserName(username)).ReturnsAsync(new Account
            {
                AccountHolder = new User
                {
                    Username = username
                }
            });
            //Act
            var testPassword = "testPassword";
            var confirmTestPassword = "testPassword";
          var actual=await  authenticationService.Register(It.IsAny<string>(), username, testPassword, confirmTestPassword);
            //Assert
            Assert.AreEqual(expected,actual);
        }
        
        
        [Test] public async Task Register_WithNonExistentUserAndMatchingPasswords_ReturnsSuccess()
        {
            //arrange
            var expected = RegistrationResult.Success;
            var mockAccountService = new Mock<IAccountService>();
            var authenticationService = new AuthenticationService(mockAccountService.Object);
           //Act
            var testPassword = "testPassword";
            var confirmTestPassword = "testPassword";
          var actual=await  authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), testPassword, confirmTestPassword);
            //Assert
            Assert.AreEqual(expected,actual);
        }



    }
}