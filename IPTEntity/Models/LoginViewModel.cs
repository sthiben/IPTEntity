using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Error Campo Requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool Recuerdame { get; set; }
    }
}
