using JwtAuth.WebApi.Entities;
using JwtAuth.WebApi.Services.Interfaces;

namespace JwtAuth.WebApi.Services
{
    public class AuthService : IAuthService
    {
        //TODO: write docs with summary
        //Testing purposes
        //Should be inside a DB with needed data encrypted
        private readonly List<User> _users = new List<User>()
        {
            new User()
            {
                Id = new Guid().ToString(),
                Username = "teste1234",
                Password = "password1234",
                Role = "Admin"
            },
            new User()
            {
                Id = new Guid().ToString(),
                Username = "papertowelhead",
                Password = "mypapertowel123",
                Role = "Client"
            }
        };

        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string> AuthUserAsync(string username, string password)
        {
            var dbUSer = _users.FirstOrDefault(token => token.Username == username);

            if (dbUSer == null) { return null; }

            return dbUSer.Password == password ?
                await _tokenService.GetTokenAsync(username, dbUSer.Role) : 
                null;
        }
    }
}
