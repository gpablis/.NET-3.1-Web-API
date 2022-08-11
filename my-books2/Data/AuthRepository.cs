using my_books2.Models;
using System.Linq;

namespace my_books2.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context; 
        }

        public ServiceResponse<string> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<int> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();
            
            response.Data = user.Id;

            return response;
        }

        public bool UserExists(string username)
        {
            if (_context.Users.Any(x => x.Username.ToLower() == username.ToLower()))
            { 
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));  
            }

        }

    }
}
