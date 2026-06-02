using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

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

    public async Task<RegisterUserResult> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        if (request.EmployeeNumber <= 0 || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new RegisterUserResult(false, "Dados de registo invalidos.");
        }

        if (await _userRepository.ExistsByEmployeeNumberAsync(request.EmployeeNumber, cancellationToken))
        {
            return new RegisterUserResult(false, "Numero de funcionario ja existe.");
        }

        if (!Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role))
        {
            role = request.IsAdmin ? UserRole.Admin : UserRole.Vendedor;
        }

        var user = new User
        {
            EmployeeNumber = request.EmployeeNumber,
            Name = request.Name.Trim(),
            PasswordHash = _passwordHasher.Hash(request.Password),
            IsActive = true,
            IsAdmin = request.IsAdmin,
            Role = request.IsAdmin ? UserRole.Admin : role
        };

        await _userRepository.AddAsync(user, cancellationToken);
        return new RegisterUserResult(true, "Utilizador criado com sucesso.");
    }
}
