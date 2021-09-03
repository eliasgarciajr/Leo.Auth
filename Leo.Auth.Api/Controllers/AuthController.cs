using Leo.Auth.Models;
using Leo.Auth.Repositories;
using Leo.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Leo.Auth.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;        

        public AuthController(ILogger<AuthController> logger) { _logger = logger; }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);
            
            if (user == null) return new NotFoundObjectResult("Usuário não localizado.");

            return new OkObjectResult(TokenService.GenerateToken(user));
        }

        [HttpPost]
        [Route("ValidatePassword")]
        [Authorize]
        public async Task<IActionResult> ValidatePassword([FromBody] UserPassword model)
        {            
            return new OkObjectResult(PasswordService.ValidatePassword(model.Password));
        }

        [HttpGet]
        [Route("GeneratePassword")]
        [Authorize]
        public async Task<IActionResult> GeneratePassword()
        {
            return new OkObjectResult(PasswordService.GeneratePassword());
        }
    }
}
