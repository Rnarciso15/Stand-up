using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using StandUp.Application.Abstractions;

namespace StandUp.Infrastructure.Messaging;

public sealed class SmtpEmailSender : IEmailSender
{
    private readonly string _host;
    private readonly int    _port;
    private readonly string _user;
    private readonly string _password;
    private readonly string _from;

    public SmtpEmailSender(IConfiguration configuration)
    {
        var s     = configuration.GetSection("Smtp");
        _host     = s["Host"]     ?? "smtp.gmail.com";
        _port     = int.TryParse(s["Port"], out var p) ? p : 587;
        _user     = s["User"]     ?? "";
        _password = s["Password"] ?? "";
        _from     = s["From"]     ?? _user;
    }

    public async Task SendAsync(string to, string subject, string htmlBody, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_user)) return; // SMTP não configurado — ignorar silenciosamente

        using var client = new SmtpClient(_host, _port)
        {
            Credentials = new NetworkCredential(_user, _password),
            EnableSsl   = true
        };
        using var msg = new MailMessage(_from, to, subject, htmlBody) { IsBodyHtml = true };
        await client.SendMailAsync(msg, cancellationToken);
    }
}
