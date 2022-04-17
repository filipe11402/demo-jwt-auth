namespace JwtAuth.WebApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthUserAsync(string username, string password);
    }
}
