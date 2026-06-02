using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auth;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResult>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _authenticationService.LoginAsync(request, cancellationToken);
        return result.IsAuthenticated ? Ok(result) : Unauthorized(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResult>> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _authenticationService.RegisterAsync(request, cancellationToken);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("check")]
    public async Task<ActionResult<object>> CheckCredentials([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _authenticationService.LoginAsync(request, cancellationToken);
        return Ok(new
        {
            ok = result.IsAuthenticated,
            message = result.Message,
            employeeNumber = result.EmployeeNumber,
            name = result.Name,
            role = result.Role
        });
    }
}
