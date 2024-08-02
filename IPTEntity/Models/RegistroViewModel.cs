using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de usuario.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string  Password {get; set; }
    }
}
