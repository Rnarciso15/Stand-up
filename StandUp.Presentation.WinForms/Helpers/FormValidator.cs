namespace StandUp.Presentation.WinForms.Helpers;

public static class FormValidator
{
    /// <summary>Retorna mensagem de erro se o valor estiver vazio, null caso contrário.</summary>
    public static string? Required(string? value, string label) =>
        string.IsNullOrWhiteSpace(value) ? $"{label} é obrigatório." : null;

    /// <summary>Valida formato básico de email (contém @). Aceita vazio (campo opcional).</summary>
    public static string? Email(string? value) =>
        !string.IsNullOrWhiteSpace(value) && !value.Trim().Contains('@')
            ? "Email inválido." : null;

    /// <summary>
    /// Valida NIF português: exactamente 9 dígitos.
    /// </summary>
    public static string? Nif(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null; // opcional
        return value.Length != 9 || !value.All(char.IsDigit) ? "NIF inválido (9 dígitos)." : null;
    }

    /// <summary>Valida telefone: mínimo 9 dígitos, pode começar com +.</summary>
    public static string? Phone(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null; // opcional
        var digits = value.TrimStart('+').Replace(" ", "");
        return !digits.All(char.IsDigit) || digits.Length < 9
            ? "Telefone inválido." : null;
    }

    /// <summary>
    /// Faz parse de inteiro positivo. Retorna mensagem de erro ou null se válido.
    /// O valor parsed é devolvido em <paramref name="result"/>.
    /// </summary>
    public static string? PositiveInt(string? value, string label, out int result)
    {
        if (!int.TryParse(value, out result) || result <= 0)
            return $"{label} deve ser um número positivo.";
        return null;
    }

    /// <summary>
    /// Mostra MessageBox com todos os erros (não-null). Retorna true se não houver erros.
    /// </summary>
    public static bool ShowErrors(params string?[] errors)
    {
        var msgs = errors.Where(e => e != null).ToList();
        if (msgs.Count == 0) return true;

        MessageBox.Show(
            string.Join(Environment.NewLine, msgs),
            "Validação",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return false;
    }
}
