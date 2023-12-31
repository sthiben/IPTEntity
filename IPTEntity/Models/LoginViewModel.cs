﻿using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Error Campo Requerido")]
        [EmailAddress(ErrorMessage = "Error Email Requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Error Campo Requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool Recuerdame { get; set; }
    }
}
