using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUsuarioDTO.UserName, loginUsuarioDTO.Password, false, false);

            if(!result.Succeeded)
            {
                throw new ApplicationException("Usuario nao autenticado");
            }

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == loginUsuarioDTO.UserName.ToUpper());

            var token = _tokenService.GenerateToken(usuario!);

            return token;
        }
    }
}
