using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private UsuarioService _usuarioService;

        public UsuarioController(IMapper mapper, UserManager<Usuario> userManager, UsuarioService usuarioService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDTO createUsuarioDTO)
        {
            try
            {

                Usuario usuario = _mapper.Map<Usuario>(createUsuarioDTO);

                var identityResult = await _userManager.CreateAsync(usuario, createUsuarioDTO.Password);

                if (identityResult.Succeeded)
                {
                    return Ok("Usuario cadastrado");
                }

                return BadRequest("Some problem");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //throw new Exception("Falha ao cadastrar usuario");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginUsuarioDTO)
        {
            var token = await _usuarioService.Login(loginUsuarioDTO);

            return Ok(token);
        }
    }
}
