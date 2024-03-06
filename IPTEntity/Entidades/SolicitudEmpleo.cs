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
        [Required(ErrorMessage ="El documento es obligatorio")]
        public string UsuarioId { get; set; }
		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombres { get; set; }
		[Required(ErrorMessage = "El apellido es obligatorio")]
		public string Apellidos { get; set; }
		public string ResumenCV { get; set; }
        [AllowNull]
		public string FileName { get; set; }
        [AllowNull]
		public string FilePath { get; set; }
		public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        //public string Orden { get; set; }
        //public IdentityUser UsuarioCreacion { get; set; }
        //public int VacanteId { get; set; }
        //public Vacante Vacante { get; set; }
        //public List<ArchivoAdjunto> ArchivoAdjuntos { get; set; }
        //public string UsuarioCreacionId { get; set; }
        //public string Estado {  get; set; }     

    }
}
