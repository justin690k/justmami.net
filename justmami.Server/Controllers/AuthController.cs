using justmami.Domain.Requests;
using justmami.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace justmami.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(RegisterRequest request)
    {
        var token = await _authService.RegisterAsync(request);

        return Ok(token);
    }


    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequest request)
    {
        var token = await _authService.LoginAsync(request);

        return Ok(token);
    }
}
