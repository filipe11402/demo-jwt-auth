using JwtAuth.WebApi.Services;
using JwtAuth.WebApi.Settings;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace JwtAuth.Services.Tests
{
    public class JwtServiceTests
    {
        private JwtService _jwtService;

        [SetUp]
        public void SetUp() 
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("testappsettings.json")
                .Build();

            var jwtSettings = new JwtSettings()
            {
                Secret = configuration.GetValue<string>("JwtConfigs:Secret")
            };

            _jwtService = new JwtService(jwtSettings);
        }

        [Test]
        public async Task GetTokenAsync_ReturnsCreatedToken() 
        {
            var token = await _jwtService.GetTokenAsync("teste@email.com", "Admin");

            Assert.IsNotNull(token);
        }
    }
}