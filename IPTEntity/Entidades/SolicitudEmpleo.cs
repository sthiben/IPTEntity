using Microsoft.EntityFrameworkCore;

namespace IPTEntity.Entidades
{
    public class SolicitudEmpleo
    {
        public int Id { get; set; }
        public int VacanteId {  get; set; }
        public Vacante Vacante { get; set; }
        public DateTime FechaSolicitud { get; set; }

        [Unicode]
        public string CVUrl {  get; set; }
        public string NombreP { get; set; }

        public string Estado {  get; set; }   




        
    }
}
