namespace StandUp.Application.Authorization;

public interface IAuthorizationService
{
    bool IsAllowed(string currentRole, params string[] allowedRoles);
}
