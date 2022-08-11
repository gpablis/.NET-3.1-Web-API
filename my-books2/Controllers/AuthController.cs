using Microsoft.AspNetCore.Mvc;
using my_books2.Data;

namespace my_books2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository1;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository1 = authRepository;
        }
        
    }
}
