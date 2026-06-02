using StandUp.Presentation.WinForms.Helpers;

namespace StandUp.Tests.WinForms;

public class FormValidatorTests
{
    // --- Required ---
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Required_Blank_ReturnsError(string? value)
    {
        var error = FormValidator.Required(value, "Nome");
        Assert.NotNull(error);
        Assert.Contains("Nome", error);
    }

    [Fact]
    public void Required_HasValue_ReturnsNull()
    {
        Assert.Null(FormValidator.Required("João", "Nome"));
    }

    // --- Email ---
    [Theory]
    [InlineData("notanemail")]
    [InlineData("missing-at-sign")]
    public void Email_InvalidFormat_ReturnsError(string value)
    {
        Assert.NotNull(FormValidator.Email(value));
    }

    [Theory]
    [InlineData("user@example.com")]
    [InlineData("")]
    [InlineData(null)]
    public void Email_ValidOrEmpty_ReturnsNull(string? value)
    {
        Assert.Null(FormValidator.Email(value));
    }

    // --- NIF ---
    [Theory]
    [InlineData("12345678")]   // 8 dígitos
    [InlineData("1234567890")] // 10 dígitos
    [InlineData("12345678A")]  // letras
    public void Nif_Invalid_ReturnsError(string value)
    {
        Assert.NotNull(FormValidator.Nif(value));
    }

    [Theory]
    [InlineData("123456789")]
    [InlineData("")]
    [InlineData(null)]
    public void Nif_ValidOrEmpty_ReturnsNull(string? value)
    {
        Assert.Null(FormValidator.Nif(value));
    }

    // --- Phone ---
    [Theory]
    [InlineData("abc")]
    [InlineData("1234")]
    public void Phone_Invalid_ReturnsError(string value)
    {
        Assert.NotNull(FormValidator.Phone(value));
    }

    [Theory]
    [InlineData("912345678")]
    [InlineData("+351912345678")]
    [InlineData("")]
    [InlineData(null)]
    public void Phone_ValidOrEmpty_ReturnsNull(string? value)
    {
        Assert.Null(FormValidator.Phone(value));
    }

    // --- PositiveInt ---
    [Theory]
    [InlineData("0")]
    [InlineData("-5")]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData(null)]
    public void PositiveInt_Invalid_ReturnsError(string? value)
    {
        var error = FormValidator.PositiveInt(value, "Preço", out _);
        Assert.NotNull(error);
    }

    [Fact]
    public void PositiveInt_Valid_ReturnsNullAndParsedValue()
    {
        var error = FormValidator.PositiveInt("1500", "Preço", out var result);
        Assert.Null(error);
        Assert.Equal(1500, result);
    }

    // --- ShowErrors ---
    [Fact]
    public void ShowErrors_NoErrors_ReturnsTrue()
    {
        var result = FormValidator.ShowErrors(null, null, null);
        Assert.True(result);
    }
}
