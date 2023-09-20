using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Entidades
{
    public class Organizacion
    {
        public int OrganizacionID { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre  { get; set; }

        public string Direccion { get; set; }

        public string PaginaWeb { get; set; }
      
        public List<Vacante> Vacantes { get; set;}
    }
}
