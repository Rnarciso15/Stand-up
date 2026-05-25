namespace StandUp.Presentation.WinForms;

public static class UserSession
{
    public static string Role { get; set; } = "Rececao";

    public static void ApplyRoleHeader(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Remove("X-User-Role");
        httpClient.DefaultRequestHeaders.Add("X-User-Role", Role);
    }
}
