using JwtAuth.WebApi.Services.Interfaces;
using JwtAuth.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Auth([FromBody] AuthUserModel request) 
        {
            var authResponse = await _authService.AuthUserAsync(request.Username, request.Password);

            return authResponse == null ?
                StatusCode(StatusCodes.Status401Unauthorized) :
                StatusCode(StatusCodes.Status200OK, authResponse);
        }
    }
}
