namespace WebApplication2.Interfaces
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
    }
}
