using System.Text;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Documents;

public sealed class SimplePdfProposalRenderer : IPdfProposalRenderer
{
    public byte[] Render(SaleTransaction saleTransaction, DateTime validUntilUtc)
    {
        var text = string.Join('\n', [
            "PROPOSTA COMERCIAL - TEMPLATE V1",
            "----------------------------------------",
            $"Cliente: {saleTransaction.ClientName}",
            $"NIF: {saleTransaction.ClientNif}",
            $"Matricula: {saleTransaction.VehicleLicensePlate}",
            $"Valor Proposto: {saleTransaction.Value:0.00} EUR",
            $"Data da Transacao: {saleTransaction.TransactionDate:yyyy-MM-dd}",
            $"Valida ate: {validUntilUtc:yyyy-MM-dd}",
            "Condicoes: sujeito a disponibilidade e confirmacao final."
        ]);

        var payload = $"%PDF-1.1\n1 0 obj<</Type/Catalog/Pages 2 0 R>>endobj\n2 0 obj<</Type/Pages/Count 1/Kids[3 0 R]>>endobj\n3 0 obj<</Type/Page/Parent 2 0 R/MediaBox[0 0 612 792]/Contents 4 0 R>>endobj\n4 0 obj<</Length {text.Length + 40}>>stream\nBT /F1 12 Tf 50 750 Td ({Escape(text)}) Tj ET\nendstream\nendobj\nxref\n0 5\n0000000000 65535 f \ntrailer<</Size 5/Root 1 0 R>>\nstartxref\n0\n%%EOF";
        return Encoding.UTF8.GetBytes(payload);
    }

    private static string Escape(string value) => value.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)").Replace("\n", ") Tj 0 -14 Td (");
}
