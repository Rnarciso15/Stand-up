namespace StandUp.Application.Auth;

public sealed record RegisterUserRequest(
    int EmployeeNumber,
    string Name,
    string Password,
    bool IsAdmin,
    string Role);
