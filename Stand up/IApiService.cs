namespace Stand_up
{
    public interface IApiService
    {
        (bool ok, string name, bool isAdmin, string role, string msg) Login(int employeeNumber, string password);
        string CurrentRole { get; }
        string CurrentUserName { get; }
        bool CurrentIsAdmin { get; }
    }

    public sealed class ApiServiceFacade : IApiService
    {
        public (bool ok, string name, bool isAdmin, string role, string msg) Login(int employeeNumber, string password)
            => ApiClient.Login(employeeNumber, password);

        public string CurrentRole => ApiClient.UserRole;
        public string CurrentUserName => ApiClient.UserName;
        public bool CurrentIsAdmin => ApiClient.IsAdmin;
    }
}
