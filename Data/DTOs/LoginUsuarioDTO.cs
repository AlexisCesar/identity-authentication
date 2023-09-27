using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
