using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IPTEntity.Entidades
{
    public class SolicitudEmpleo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El documento es obligatorio")]
        public string UsuarioId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellidos { get; set; }
        public string ResumenCV { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public string TipoDiscapacidad { get; set; }
        [Required]
        public string EstadoEmpleado { get; set; } //=> Este campo, es para saber si el empleado tiene empleo o está desempleado en el momento.
    }
}
