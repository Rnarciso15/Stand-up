namespace StandUp.Domain.Entities;

public sealed class ClientImage
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public byte[] Data { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}
