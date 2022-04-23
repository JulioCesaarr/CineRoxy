using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Request;
using UsuariosApi.Service;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaSenhaResetUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaSenhaResetUsuario(request);
            if(resultado.IsFailed)return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

    }
}
