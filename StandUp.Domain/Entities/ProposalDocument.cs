namespace StandUp.Domain.Entities;

public sealed class ProposalDocument
{
    public const string CurrentTemplateVersion = "v1";

    public int Id { get; set; }
    public int SaleTransactionId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string TemplateVersion { get; set; } = CurrentTemplateVersion;
    public DateTime ValidUntilUtc { get; set; }
    public byte[] PdfBytes { get; set; } = [];
    public DateTime CreatedAtUtc { get; set; }
}
