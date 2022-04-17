using JwtAuth.WebApi.Services;
using JwtAuth.WebApi.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace JwtAuth.Services.Tests
{
    public class AuthServiceTests
    {
        private AuthService _authService;

        private Mock<ITokenService> _tokenService;

        [SetUp]
        public void SetUp() 
        {
            _tokenService = new Mock<ITokenService>();
            _authService = new AuthService(_tokenService.Object);
        }

        [Test]
        public async Task AuthUserAsync_ReturnsSucessfullAuth() 
        {
            //Arrange
            var username = "teste1234";
            var password = "password1234";

            _tokenService.Setup(m => m.GetTokenAsync(username, "Admin")).Returns(Task.FromResult("MYJWTTOKEN"));

            //Act
            var authResponse = await _authService.AuthUserAsync(username, password);

            //Assert
            Assert.IsNotEmpty(authResponse);
        }

        [Test]
        public async Task AuthUserAsync_UserDoesNotExist() 
        {
            //Arrange
            var username = "teste";
            var password = "password1234";

            //Act
            var authResponse = await _authService.AuthUserAsync(username, password);

            //Assert
            Assert.IsNull(authResponse);
        }
    }
}