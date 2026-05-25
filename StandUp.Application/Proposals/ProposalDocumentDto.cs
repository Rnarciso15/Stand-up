namespace StandUp.Application.Proposals;

public sealed record ProposalDocumentDto(int Id, int SaleTransactionId, string FileName, string TemplateVersion, DateTime ValidUntilUtc, DateTime CreatedAtUtc);
