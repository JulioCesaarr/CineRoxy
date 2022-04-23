using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>>  _signInManager;
        private TokenService _tokenService;



        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitaSenhaResetUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            if(identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;  
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("falha ao solicitar redefinição");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");
            return Result.Fail("Erro ao redefinir senha");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
