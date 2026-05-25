namespace StandUp.Application.Authorization;

public sealed class AuthorizationService : IAuthorizationService
{
    public bool IsAllowed(string currentRole, params string[] allowedRoles)
        => allowedRoles.Any(x => string.Equals(x, currentRole, StringComparison.OrdinalIgnoreCase));
}
