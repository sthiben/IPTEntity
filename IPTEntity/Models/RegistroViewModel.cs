using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electronico válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        
        public string  Password {get; set; }
    }
}
