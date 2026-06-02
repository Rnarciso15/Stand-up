namespace StandUp.Application.Auth;

public interface IAuthenticationService
{
    Task<LoginResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<RegisterUserResult> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);
}
