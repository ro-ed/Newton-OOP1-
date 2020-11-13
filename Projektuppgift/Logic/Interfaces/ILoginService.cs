namespace Logic.Services
{
    public interface ILoginService
    {
        bool Login(string username, string password);
    }
}