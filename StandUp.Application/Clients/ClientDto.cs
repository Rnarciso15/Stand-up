namespace StandUp.Application.Clients;

public sealed record ClientDto(
    int Id,
    string Name,
    DateTime? BirthDate,
    string? Gender,
    string? Email,
    string? Phone,
    string? Nib,
    string? Nif,
    string? Address,
    bool IsActive);
