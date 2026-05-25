using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IPdfProposalRenderer
{
    byte[] Render(SaleTransaction saleTransaction, DateTime validUntilUtc);
}
