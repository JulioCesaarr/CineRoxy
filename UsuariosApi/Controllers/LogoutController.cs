
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Service;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result resultado = _logoutService.DeslogaUsuario();
            if(resultado.IsFailed)return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }
}
