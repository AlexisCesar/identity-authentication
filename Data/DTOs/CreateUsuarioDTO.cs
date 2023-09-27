using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        // Identity vertifies if password contains special character numbers and alpha
        // so it's a good idea to add a validator for this
        // can change patterns in program builder.services
        public string PasswordConfirmation { get; set; }
    }
}
