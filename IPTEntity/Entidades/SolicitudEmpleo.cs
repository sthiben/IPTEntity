using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Entidades
{
    public class SolicitudEmpleo
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string NombreP { get; set; }

        public string ResumenCV { get; set; }
        public string Orden { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string UsuariosCreacionId { get; set; }
        public IdentityUser UsuarioCreacion { get; set; }
        public int VacanteId { get; set; }
        public Vacante Vacante { get; set; }
       
        public List<ArchivoAdjunto> ArchivoAdjuntos { get; set; }

   
        public string UsuarioCreacionId { get; set; }
       
     
  
     

        public string Estado {  get; set; }   




        
    }
}
