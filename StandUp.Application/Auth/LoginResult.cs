namespace StandUp.Application.Auth;

public sealed record LoginResult(bool IsAuthenticated, int? EmployeeNumber, string? Name, bool IsAdmin, string? Role, string Message)
{
    public static LoginResult Failed(string message) => new(false, null, null, false, null, message);
    public static LoginResult Success(int employeeNumber, string name, bool isAdmin, string role) => new(true, employeeNumber, name, isAdmin, role, "OK");
}
