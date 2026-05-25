namespace StandUp.Domain.Entities;

public sealed class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Nib { get; set; }
    public string? Nif { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; } = true;
}
