namespace StandUp.Application.Abstractions;

public interface IPasswordHasher
{
    string Hash(string plainText);
}
