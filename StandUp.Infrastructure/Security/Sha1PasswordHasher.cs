using System.Security.Cryptography;
using System.Text;
using StandUp.Application.Abstractions;

namespace StandUp.Infrastructure.Security;

public sealed class Sha1PasswordHasher : IPasswordHasher
{
    public string Hash(string plainText)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        var hash = SHA1.HashData(bytes);
        var sb = new StringBuilder(hash.Length * 2);
        foreach (var b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}
