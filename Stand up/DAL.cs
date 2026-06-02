// ═══════════════════════════════════════════════════════════════════════════
//  DAL — Data Access Layer (obsoleto).
//
//  A ligação directa ao SQL Server foi substituída pela REST API.
//  Este ficheiro existe apenas para não quebrar referências antigas.
//  Não contém código executável.
//
//  Para acesso a dados usar: ApiClient (HTTP) → ApiService (negócio)
// ═══════════════════════════════════════════════════════════════════════════
namespace DataAccessLayer
{
    [System.Obsolete("Use ApiClient e ApiService em vez do DAL directo.")]
    public sealed class DAL { }
}
