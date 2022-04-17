namespace JwtAuth.WebApi.Services.Interfaces
{
    public interface ITokenService
    {
        //You could encrypt other data such as permissions
        Task<string> GetTokenAsync(string email, string role);
    }
}
