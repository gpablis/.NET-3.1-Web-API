using my_books2.Models;

namespace my_books2.Data
{
    public interface IAuthRepository
    {
        ServiceResponse<int> Register(User user, string password);
        ServiceResponse<string> Login(string username, string password);
        bool UserExists(string username);

    }
}
