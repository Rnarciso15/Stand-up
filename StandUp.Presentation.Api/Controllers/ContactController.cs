using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Abstractions;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class ContactController : ControllerBase
{
    private readonly IEmailSender _email;
    private readonly IConfiguration _config;

    public ContactController(IEmailSender email, IConfiguration config)
    {
        _email = email;
        _config = config;
    }

    [HttpPost]
    public async Task<IActionResult> SendContact([FromBody] ContactRequest request, CancellationToken cancellationToken)
    {
        var to = _config["Smtp:To"] ?? _config["Smtp:From"] ?? "";
        if (string.IsNullOrWhiteSpace(to)) return Ok(); // SMTP não configurado

        var subject = $"[Stand Up] Pedido de Visita — {request.Plate}";
        var body = $"""
            <h2>Novo pedido de visita</h2>
            <p><strong>Viatura:</strong> {request.Plate}</p>
            <p><strong>Nome:</strong> {request.Name}</p>
            <p><strong>Telefone:</strong> {request.Phone}</p>
            <p><strong>Mensagem:</strong> {request.Message}</p>
            <hr/>
            <p style="color:#888;font-size:12px">Stand Up — Gestão de Stand Automóvel</p>
            """;

        await _email.SendAsync(to, subject, body, cancellationToken);
        return Ok();
    }
}

public sealed record ContactRequest(string Plate, string Name, string Phone, string Message);
