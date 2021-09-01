using AuthJWT.WebAPI.Models;
using AuthJWT.WebAPI.Repositories;
using AuthJWT.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthJWT.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) { _logger = logger; }
        
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);
            
            if (user == null) return new NotFoundObjectResult("Não encontrado.");

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
