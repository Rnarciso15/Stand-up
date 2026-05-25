namespace StandUp.Domain.Entities;

public enum UserRole
{
    Admin = 1,
    Vendedor = 2,
    Rececao = 3
}

public sealed class User
{
    public int Id { get; set; }
    public int EmployeeNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
    public UserRole Role { get; set; } = UserRole.Vendedor;
}
