using StandUp.Application.Abstractions;

namespace StandUp.Application.Auth;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        if (request.EmployeeNumber <= 0 || string.IsNullOrWhiteSpace(request.Password))
        {
            return LoginResult.Failed("Credenciais inválidas.");
        }

        var user = await _userRepository.GetByEmployeeNumberAsync(request.EmployeeNumber, cancellationToken);
        if (user is null || !user.IsActive)
        {
            return LoginResult.Failed("Utilizador não encontrado ou inativo.");
        }

        var passwordHash = _passwordHasher.Hash(request.Password);
        if (!string.Equals(user.PasswordHash, passwordHash, StringComparison.OrdinalIgnoreCase))
        {
            return LoginResult.Failed("Credenciais inválidas.");
        }

        return LoginResult.Success(user.EmployeeNumber, user.Name, user.IsAdmin, user.Role.ToString());
    }
}
